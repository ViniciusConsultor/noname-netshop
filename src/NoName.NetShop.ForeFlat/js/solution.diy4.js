var currentCategoryID = 0;
var currentFatherCategoryID = 0;
function StringBuffer() { this.data = []; } StringBuffer.prototype.append = function() { this.data.push(arguments[0]); return this; }; StringBuffer.prototype.toString = function() { return this.data.join(""); }



$(function() {
    /* initialize category list of the scence */
    initialize();

    /* events define begin */

    /*
    *     top category list click event
    *     when the selected category has subcategory, show the subcategories and define the same click event handler function
    */
    $('#equipment-category a').click(function() {

        currentFatherCategoryID = $(this).attr('fatherid');
        currentCategoryID = $(this).attr('categoryid');

        $('#equipment-category a').each(function() { $(this).attr('class', 'off'); });
        $(this).attr('class', 'on');

        if ($(this).attr('hassub') == '1') {
            $('#equipment-sub-category').html($(this).next().html());
            $('#equipment-sub-category a').click(function() {
                $('#equipment-sub-category a').each(function() { $(this).attr('class', 'off'); });
                $(this).attr('class', 'on');

                currentFatherCategoryID = $(this).attr('fatherid');
                currentCategoryID = $(this).attr('categoryid');

                showBrandInfo(currentFatherCategoryID, currentCategoryID);
                showSearchedProduct(currentCategoryID, currentFatherCategoryID, 0, '');
            });
        }
        else $('#equipment-sub-category').html('');

        showBrandInfo(currentFatherCategoryID, currentCategoryID);
        showSearchedProduct(currentCategoryID, currentFatherCategoryID, 0, '');
    });


    //$().click();
    //$().click();
    /* events define end */

});



function initialize() {
    /* initialize category info */
    $.ajax({
        url: '/handler/solutionhandler.ashx',
        type: 'post',
        data: 'action=category&sid=' + $.query.get('ids'),
        cache: false,
        dataType: 'json',
        async: false,
        beforeSend: function() { var word = '正在加载列表...'; $('#suit-config-list-wrapper').html(word); $('#equipment-category').html(word); },
        error: function() { var word = '加载列表错误'; $('#suit-config-list-wrapper').html(word); $('#equipment-category').html(word); },
        success: function(data) {
            var html1 = new StringBuffer(), html2 = new StringBuffer();

            html1.append('<table id="selected-product-list">');
            html1.append('  <tr>');
            html1.append('      <th colspan="2"><span>配置</span></th>');
            html1.append('      <th><span>名称</span></th>');
            html1.append('      <th><span>数量</span></th>');
            html1.append('      <th><span>价格</span></th>');
            html1.append('      <th><span>删除</span></th>');
            html1.append('  </tr>');
            $.each(data, function(i, n) {
                var rowStyle = i % 2 != 0 ? 'odd' : 'even';

                html1.append('  <tr class="' + rowStyle + '" fatherid="' + n.categoryid + '" categoryid="0">');
                html1.append('      <td' + (n.subcates.length > 0 ? ' rowspan="' + n.subcates.length + '"' : '') + '>' + n.categoryname + '</td>');
                html1.append('      <td>' + (n.subcates.length > 0 ? n.subcates[0].categoryname : '') + '</td>');
                html1.append('      <td></td>');
                html1.append('      <td></td>');
                html1.append('      <td></td>');
                html1.append('      <td></td>');
                html1.append('  </tr>');

                html2.append('<a style="cursor:pointer;" class="off" fatherid="' + n.categoryid + '" categoryid="0" hassub="' + (n.subcates.length > 0 ? '1' : '0') + '">' + n.categoryname + '</a>');

                if (n.subcates.length > 0) {
                    html2.append('<div style="display:none;">');
                    $.each(n.subcates, function(j, m) {
                        if (j != 0) {
                            html1.append('  <tr class="' + rowStyle + '" fatherid="' + n.categoryid + '" categoryid="' + m.categoryid + '">');
                            html1.append('      <td>' + m.categoryname + '</td>');
                            html1.append('      <td></td>');
                            html1.append('      <td></td>');
                            html1.append('      <td></td>');
                            html1.append('      <td></td>');
                            html1.append('  </tr>');
                        }
                        html2.append('<a fatherid="' + n.categoryid + '" categoryid="' + m.categoryid + '">' + m.categoryname + '</a>');
                    });
                    html2.append('</div>');
                }
            });

            html1.append('  <tr class="bottom">');
            html1.append('      <td colspan="6">总计：￥<span id="price-sum">0</span></td>');
            html1.append('  </tr>');
            html1.append('</table>');

            html2.append('<div id="equipment-sub-category"></div>');

            $('#suit-config-list-wrapper').html(html1.toString());
            $('#equipment-category').html(html2.toString());

            /*set the primary values*/
            $($('#equipment-category a')[0]).attr('class', 'on');
            currentCategoryID = parseInt($($('#equipment-category a')[0]).attr('cateid'));

            showBrandInfo(currentCategoryID)
            showSearchedProduct(currentCategoryID, 0, 0, '');
            /*set the primary values end*/
        }
    });
    /* initialize category info end */
}


function showBrandInfo(fatherCategoryID, categoryID) {
    $.ajax({
        url: '/handler/solutionhandler.ashx',
        type: 'post',
        data: 'action=brand&cid=' + categoryID,
        cache: false,
        dataType: 'json',
        async: false,
        beforeSend: function() { },
        error: function() { },
        success: function(data) {
            //alert(data.length);
            $.each(data, function(i, n) {
                var script = '<select id="brand">';
                script += '<option value="' + n.brandname + '">' + n.brandid + '</option>';
                script += '</select>';
                $('#brand-list').html(script);

                $('#brand').change(function() {
                    showSearchedProduct(categoryID, fatherCategoryID, $(this).val(), '');
                });
            });
        }
    })
}



function showSearchedProduct(categoryid, fatherCategoryID, brandid, productName) {
    $.ajax({
        url: '/handler/solutionhandler.ashx',
        type: 'post',
        data: 'action=product&sid=' + $.query.get('ids') + '&cid=' + categoryid + '&fcid=' + fatherCategoryID + '&brandid=' + brandid + '&pdname=' + productName,
        cache: false,
        dataType: 'json',
        beforeSend: function() { $('#list-table').html('加载中...'); },
        error: function() { $('#list-table').html('加载列表错误'); },
        success: function(data) {
            debugger;
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
                          '  <td><input type="checkbox" productid="' + n.productid + '" categoryid="' + categoryid + '" fatherid="' + fatherCategoryID + '" /></td>' +
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

            // click event for the product checkbox start
            $('#product-list tr input[type="checkbox"]').click(function() {
                var theBox = $(this);
                var row = theBox.parent().parent();
                var status = theBox.attr('checked');

                $('#product-list tr input[type="checkbox"]').each(function() {
                    if (theBox.attr('productid') != $(this).attr('productid') && theBox.attr('fatherid') == $(this).attr('fatherid') && theBox.attr('categoryid') == $(this).attr('categoryid'))
                        $(this).attr('checked', false);
                });

                /****注意这里已经不再是分类ID作为主键了，而是父分类和子分类共同作为检索主键****/
                if (status) {
                    addProduct(theBox.attr('cateid'), {
                        productid: theBox.attr('productid'),
                        productname: $(row.children('td')[1]).text(),
                        count: 1,
                        price: $(row.children('td')[2]).text()
                    });
                }
                else {
                    removeProduct(theBox.attr('cateid'));
                }
            });
            // click event for the product checkbox end

        }
    });
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

    calculateTotalPrice(true);
}
function removeProduct(categoryID) {
    //debugger;
    var selectedProducts = getSelectedList();
    selectedProducts.Remove(categoryID);
    setSelectedList(selectedProducts);

    var theCateRow = $('#selected-product-list tr[categoryid="' + categoryID + '"]');
    theCateRow.removeAttr('productid');
    $(theCateRow.children('td')[1]).html('');
    $(theCateRow.children('td')[2]).html('');
    $(theCateRow.children('td')[3]).html('');
    $(theCateRow.children('td')[4]).html('');

    $('#product-list tr input[cateid="' + categoryID + '"]').attr('checked', false);
    calculateTotalPrice(false);
}