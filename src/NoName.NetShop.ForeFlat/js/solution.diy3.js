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
        currentCategoryID = $(this).attr('cateid');

        $('#equipment-category a').each(function() { $(this).attr('class', 'off'); });
        $(this).attr('class', 'on');

        if ($(this).attr('hassub') == '1') {
            $('#equipment-sub-category').html($(this).next().html());
            $('#equipment-sub-category a').click(function() {
                $('#equipment-sub-category a').each(function() { $(this).attr('class', 'off'); });
                $(this).attr('class', 'on');
                currentCategoryID = $(this).attr('cateid');
                showBrandInfo(currentCategoryID);
                showSearchedProduct(currentCategoryID, $(this).attr('fatherid'), 0, '');
            });
        }
        else $('#equipment-sub-category').html('');

        showBrandInfo(currentCategoryID);
        showSearchedProduct(currentCategoryID, 0, 0, '');
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

                html1.append('  <tr class="' + rowStyle + '" categoryid="' + n.categoryid + '">');
                html1.append('      <td' + (n.subcates.length > 0 ? ' rowspan="' + n.subcates.length + '"' : '') + '>' + n.categoryname + '</td>');
                html1.append('      <td>' + (n.subcates.length > 0 ? n.subcates[0].categoryname : '') + '</td>');
                html1.append('      <td></td>');
                html1.append('      <td></td>');
                html1.append('      <td></td>');
                html1.append('      <td></td>');
                html1.append('  </tr>');

                html2.append('<a style="cursor:pointer;" class="off" cateid="' + n.categoryid + '" hassub="' + (n.subcates.length > 0 ? '1' : '0') + '">' + n.categoryname + '</a>');

                if (n.subcates.length > 0) {
                    html2.append('<div style="display:none;">');
                    $.each(n.subcates, function(j, m) {
                        if (j != 0) {
                            html1.append('  <tr class="' + rowStyle + '" categoryid="' + m.categoryid + '">');
                            html1.append('      <td>' + m.categoryname + '</td>');
                            html1.append('      <td></td>');
                            html1.append('      <td></td>');
                            html1.append('      <td></td>');
                            html1.append('      <td></td>');
                            html1.append('  </tr>');
                        }
                        html2.append('<a cateid="' + m.categoryid + '" fatherid="' + n.categoryid + '">' + m.categoryname + '</a>');
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
            showSearchedProduct(currentCategoryID,0, 0, '');
            /*set the primary values end*/
        }
    });
    /* initialize category info end */
}

function showBrandInfo(categoryid) {
    $.ajax({
        url: '/handler/solutionhandler.ashx',
        type: 'post',
        data: 'action=brand&cid=' + categoryid,
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
                    showSearchedProduct(categoryid,$(this).val(),'');
                });
            });
        }
    })
}

function showSearchedProduct(categoryid,fatherCategoryID, brandid, productName) {
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
                          '  <td><input type="checkbox" productid="' + n.productid + '" cateid="' + categoryid + '" fatherid="'+fatherCategoryID+'" /></td>' +
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
        }
    }); 
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