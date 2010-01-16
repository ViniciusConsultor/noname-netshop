$(function() {
    //首先从cookie中读取，决定当前页是否有已选择商品，并决定是否有勾选
    initialize();

    //当点击选择框时
    $('#product-list tr input[type="checkbox"]').click(function() {
        var theBox = $(this);
        var row = theBox.parent().parent();
        var status = theBox.attr('checked');

        //排斥其余选项
        $('#product-list tr input[type="checkbox"]').each(function() { if (theBox.attr('productid') != $(this).attr('productid')) $(this).attr('checked', false); });

        if (status) {
            addProduct(theBox.attr('categoryid'), {
                productid: theBox.attr('productid'),
                productname: $(row.children('td')[1]).text(),
                count: 1,
                price: $(row.children('td')[2]).text()
            });
        }
        else {
            removeProduct(theBox.attr('categoryid'));
        }
    });

    //当点击清空选择时
    $('#clear-select').click(function() { clearSelect(); });
    //当提交选择时
    $('#submit-select').click(function() {
        var selectedProducts = getSelectedList();
        var pids = '';
        for (var i = 0; i < selectedProducts.Count; i++) {
            var productInfo = selectedProducts.GetValue(selectedProducts.Keys()[i]);
            pids += productInfo.productid;
            if (i != selectedProducts.Count - 1) pids += ',';
        }
        alert(pids);
    });

    function initialize() {
        var selectedProducts = getSelectedList();
        for (var i = 0; i < selectedProducts.Count; i++) {
            var categoryID = selectedProducts.Keys()[i];
            var productInfo = selectedProducts.GetValue(categoryID);

            var theCateRow = $('#selected-product-list tr[categoryid="' + categoryID + '"]');
            theCateRow.attr('productid', productInfo.productid);
            $(theCateRow.children('td')[1]).html(productInfo.productname);
            $(theCateRow.children('td')[2]).html(productInfo.count);
            $(theCateRow.children('td')[3]).html(productInfo.price);
            $(theCateRow.children('td')[4]).html('<a id="delete-' + categoryID + '" class="iconButton delete" style="cursor:pointer"></a>');

            $('#delete-' + categoryID).click(function() {
                removeProduct(categoryID);
            });

            $('#product-list tr input').each(function() {
                if (categoryID == $(this).attr('categoryid') && productInfo.productid == $(this).attr('productid')) {
                    $(this).attr('checked', true);
                }
            });
        }
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

