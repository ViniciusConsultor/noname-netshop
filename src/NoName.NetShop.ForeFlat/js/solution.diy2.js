var currentCategoryID = 0;

$(function() {

    getSearchData(currentCategoryID, 0, '');

    $('.equipmentCategory a').click(function() {
        currentCategoryID = $(this).attr('cateid');
        $('.equipmentCategory a').each(function() { $(this).attr('class', 'off'); });
        $(this).attr('class', 'on');
        getSearchData(currentCategoryID, 0, '');
    });

    $('#button-search').click(function() {

    });



    function getSearchData(categoryID, brandID, productName) {
        $.ajax({
            url: '/handler/SolutionHandler.ashx',
            type: 'post',
            data: getSearchPara(categoryID, brandID, productName),
            cache: false,
            dataType: 'json',
            beforeSend: function() { },
            error: function() { },
            success: function(data) {
                var html = '<div class="table2">' +
                           '     <table id="product-list">' +
                           '       <tr>' +
                           '         <th class="first"><span>商品图片</span></th>' +
                           '         <th><span>商品名称</span></th>' +
                           '         <th><span>商品价格</span></th>' +
                           '         <th><span>选用</span></th>' +
                           '       </tr>';
                $.each(data, function(i, n) {
                    html += '<tr class="' + (i % 2 == 0 ? "odd" : 'even') + '">' +
                          '  <td><a href="/product-' + n.productid + '.html" ><img src="' + n.image + '" /></a></td>' +
                          '  <td><a href="#">' + n.productname + '</a></td>' +
                          '  <td>￥' + n.price + '</td>' +
                          '  <td><input type="checkbox" productid="' + n.productid + '" /></td>' +
                          '</tr>';
                });
                html += '<tr class="bottom">' +
                        '    <td colspan="4">' +
                        '      <div class="pagination">' +
                        '      </div>' +
                        '    </td>' +
                        '  </tr>' +
                        '</table>';

                $('#list-table').html(html);

                // 添加checkbox的点击事件
                $('#product-list tr input[type="checkbox"]').click(function() {
                    var theBox = $(this);
                    var row = theBox.parent().parent();
                    var status = theBox.attr('checked');

                    $('#product-list tr input[type="checkbox"]').each(function() { if (theBox.attr('productid') != $(this).attr('productid')) $(this).attr('checked', false); });

                    if (status) {
                        //addProduct(theBox.attr('categoryid'), {
                        //    productid: theBox.attr('productid'),
                        //    productname: $(row.children('td')[1]).text(),
                        //    count: 1,
                        //    price: $(row.children('td')[2]).text()
                        //});
                        alert(theBox.attr('categoryid'));
                    }
                    else {
                        removeProduct(theBox.attr('categoryid'));
                    }
                });
                // checkbox 点击事件结束
            }
        });
    }


    function getSearchPara(categoryID, brandID, productName) {
        //debugger;
        var dataStr = '';
        var scenceID = $.url.param('scenceid');

        if (categoryID == 0) {
            categoryID = $.url.param('ids').split(',')[0];
            currentCategoryID = categoryID;
            $($('.equipmentCategory a')[0]).attr('class', 'on');
        }

        dataStr = 'scenceid=' + scenceID + '&cateid=' + categoryID;
        if (brandID != 0) dataStr += '&brandid=' + brandID;
        if (productName != '') dataStr += '&pdname=' + encodeURI(productName);

        return dataStr;
        //return $.url.param('ids');
    }


    function getSelectedList() {
        var cookieStr = $.cookie('slselectproducts');
        var selectedProducts = new Hashtable();
        if (cookieStr == null) { } // 此时cookie中尚无任何信息{}
        if (cookieStr == '') { } // 此时cookie内容被清{}
        if (cookieStr != null && cookieStr != '' && cookieStr.indexOf(';') == -1) // 此时cookie中只包含一条数据
        {
            selectedProducts.Add(cookieStr.split(',')[0], { productid: cookieStr.split(',')[1], productname: cookieStr.split(',')[2], count: cookieStr.split(',')[3], price: cookieStr.split(',')[4] });
        }
        if (cookieStr != null && cookieStr != '' && cookieStr.indexOf(';') >= 0) // 此时cookie中包含多条数据
        {
            for (var i = 0; i < cookieStr.split(';').length; i++) {
                var p = cookieStr.split(';')[i];
                selectedProducts.Add(p.split(',')[0], { productid: p.split(',')[1], productname: p.split(',')[2], count: p.split(',')[3], price: p.split(',')[4] });
            }
        }

        return selectedProducts;
    }
    function setSelectedList(selectedProducts) {
        var cookieStr = '';
        for (var i = 0; i < selectedProducts.Count; i++) {
            var key = selectedProducts.Keys()[i];
            var info = selectedProducts.GetValue(key);

            cookieStr += key + ',' + info.productid + ',' + info.productname + ',' + info.count + ',' + info.price;

            if (i != selectedProducts.Count - 1) cookieStr += ';';
        }
        $.cookie('slselectproducts', cookieStr);
    }
    function addProduct(categoryID, productInfo) {
        //debugger;
        var selectedProducts = getSelectedList();
        selectedProducts.Add(categoryID, productInfo);
        setSelectedList(selectedProducts);

        var theCateRow = $('#selected-product-list tr[categoryid="' + categoryID + '"]');
        theCateRow.attr('productid', productInfo.productid);
        $(theCateRow.children('td')[1]).html(productInfo.productname);
        $(theCateRow.children('td')[2]).html(productInfo.count);
        $(theCateRow.children('td')[3]).html(productInfo.price);
        $(theCateRow.children('td')[4]).html('<a id="delete-' + categoryID + '" class="iconButton delete" style="cursor:pointer"></a>');

        $('#delete-' + categoryID).click(function() {
            removeProduct(categoryID);
        });
    }
    function removeProduct(categoryID) {
        var selectedProducts = getSelectedList();
        selectedProducts.Remove(categoryID);
        setSelectedList(selectedProducts);

        var theCateRow = $('#selected-product-list tr[categoryid="' + categoryID + '"]');
        theCateRow.removeAttr('productid');
        $(theCateRow.children('td')[1]).html('');
        $(theCateRow.children('td')[2]).html('');
        $(theCateRow.children('td')[3]).html('');
        $(theCateRow.children('td')[4]).html('');

        $('#product-list tr input[categoryid="' + categoryID + '"]').attr('checked', false);
    }

    function clearSelect() {
        var selectedProducts = getSelectedList();
        for (var i = 0; i < selectedProducts.Count; i++) {
            var categoryID = selectedProducts.Keys()[i];
            removeProduct(categoryID);
        }
    }


});