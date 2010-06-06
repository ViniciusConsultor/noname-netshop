var currentCategoryID = 0;
var currentFatherCategoryID = 0;
function StringBuffer() { this.data = []; } StringBuffer.prototype.append = function() { this.data.push(arguments[0]); return this; }; StringBuffer.prototype.toString = function() { return this.data.join(""); }

var pageSize = 5;

$(function() {
    /* initialize category list of the scence */
    initialize();

    /* events define begin */

    /*
    *     top category list click event
    *     when the selected category has subcategory, show the subcategories and define the same click event handler function
    */
    $('#equipment-category a[hassub]').click(function() {
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
                showSearchedProduct(currentCategoryID, currentFatherCategoryID, 0, '', 1);
            });
        }
        else $('#equipment-sub-category').html('');

        showBrandInfo(currentFatherCategoryID, currentCategoryID);
        showSearchedProduct(currentCategoryID, currentFatherCategoryID, 0, '', 1);
    });

    /* the submit form button click event */
    $('#submit-select').click(submitSelect);

    /* the clear selection button click event */
    $('#clear-select').click(clearSelect);

    /* the clear selection button click event */
    $('a[ordervalue]').click(function() {
        $('a[ordervalue]').removeAttr('class');
        $(this).attr('class', 'on');

        currentFatherCategoryID = 0;
        currentCategoryID = 0;

        $('#equipment-sub-category a').each(function() {
            if ($(this).attr('class') == 'on') {
                currentFatherCategoryID = $(this).attr('fatherid');
                currentCategoryID = $(this).attr('categoryid');
            }
        });

        if (currentFatherCategoryID == 0)
            $('#equipment-category a[hassub]').each(function() {
                if ($(this).attr('class') == 'on') {
                    currentFatherCategoryID = $(this).attr('fatherid');
                    currentCategoryID = $(this).attr('categoryid');
                }
            });

        showSearchedProduct(currentCategoryID, currentFatherCategoryID, 0, '', $(this).attr('ordervalue'));
    });

    /**/
    $('#button-search').click(function() {
        if ($('#search-product-name').val() != '') {
            currentFatherCategoryID = 0;
            currentCategoryID = 0;
            var orderValue = 1, brandID = 0;

            $('#equipment-sub-category a').each(function() {
                if ($(this).attr('class') == 'on') {
                    currentFatherCategoryID = $(this).attr('fatherid');
                    currentCategoryID = $(this).attr('categoryid');
                }
            });

            if (currentFatherCategoryID == 0)
                $('#equipment-category a[hassub]').each(function() {
                    if ($(this).attr('class') == 'on') {
                        currentFatherCategoryID = $(this).attr('fatherid');
                        currentCategoryID = $(this).attr('categoryid');
                    }
                });

            $('a[ordervalue]').each(function() {
                if ($(this).attr('class') == 'on') orderValue = $(this).attr('ordervalue');
            });

            if ($('#brand').html()) brandID = $('#brand').val();

            showSearchedProduct(currentCategoryID, currentFatherCategoryID, brandID, $('#search-product-name').val(), orderValue);
        }
        else {
            alert('请输入商品名称');
        }
    });
    /* events define end */

});



function initialize() {
    /* initialize category info */
    $.ajax({
        url: '/handler/solutionhandler.ashx',
        type: 'post',
        data: 'action=category&sid=' + $.query.get('scenceid'),
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

                html1.append('  <tr class="' + rowStyle + '" fatherid="' + n.categoryid + '" categoryid="' + (n.subcates.length > 0 ? n.subcates[0].categoryid : 0) + '">');
                html1.append('      <td' + (n.subcates.length > 0 ? ' rowspan="' + n.subcates.length + '"' : ' style="border-right:0"') + '>' + n.categoryname + '</td>');
                html1.append('      <td ' + (n.subcates.length > 0 ? '' : 'style="border-left:0;"') + '>' + (n.subcates.length > 0 ? n.subcates[0].categoryname : '') + '</td>');
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
            var theInitialSelectedDom = $($('#equipment-category a')[0]);
            theInitialSelectedDom.attr('class', 'on');
            currentCategoryID = parseInt(theInitialSelectedDom.attr('fatherid'));
            if (theInitialSelectedDom.attr('hassub') == '1') $('#equipment-sub-category').html(theInitialSelectedDom.next().html());
            $('#equipment-sub-category a').click(function() {
                $('#equipment-sub-category a').each(function() { $(this).attr('class', 'off'); });
                $(this).attr('class', 'on');

                currentFatherCategoryID = $(this).attr('fatherid');
                currentCategoryID = $(this).attr('categoryid');

                showBrandInfo(currentFatherCategoryID, currentCategoryID);
                showSearchedProduct(currentCategoryID, currentFatherCategoryID, 0, '', 1);
            });

            showBrandInfo(currentCategoryID, 0);
            showSearchedProduct(0, currentCategoryID, 0, '', 1);
            /*set the primary values end*/
        }
    });
    /* initialize category info end */
}


function showBrandInfo(fatherCategoryID, categoryID) {
    $.ajax({
        url: '/handler/solutionhandler.ashx',
        type: 'post',
        data: 'action=brand&cid=' + (parseInt(categoryID) == 0 ? fatherCategoryID : categoryID),
        cache: false,
        dataType: 'json',
        async: false,
        beforeSend: function() { },
        error: function() { },
        success: function(data) {
        var script = '品牌：<select id="brand">';
            
            $.each(data, function(i, n) {
                script += '<option value="' + n.brandid + '">' + n.brandname + '</option>';
            });
            
            script += '</select>';
            $('#brand-list').html(script);

            $('#brand').change(function() {
                showSearchedProduct(categoryID, fatherCategoryID, $(this).val(), '', 1);
            });
        }
    })
}



function showSearchedProduct(categoryID, fatherCategoryID, brandid, productName, OrderType) {
    $.ajax({
        url: '/handler/solutionhandler.ashx',
        type: 'post',
        data: 'action=product&sid=' + $.query.get('scenceid') + '&cid=' + categoryID + '&fcid=' + fatherCategoryID + '&brandid=' + brandid + '&pdname=' + productName + '&order=' + OrderType,
        cache: false,
        async: false,
        dataType: 'json',
        beforeSend: function() { $('#list-table').html('加载中...'); },
        error: function() { $('#list-table').html('加载列表错误'); },
        success: function(data) {
            if (data.length > 0) {
                // make pagination here

                turnPage(data, 1, fatherCategoryID);

            }
            else {
                $('#list-table').html('<div class="table2"><p>对不起，未找到相关结果。</p/></div>');
            }
        }
    });
}

function addProduct(indexKey, productInfo) {
    //debugger;
    var selectedProducts = getSelectedList();
    selectedProducts.Add(indexKey, productInfo);
    setSelectedList(selectedProducts);

    var theCateRow = $('#selected-product-list tr[fatherid="' + indexKey.split('-')[0] + '"][categoryid="' + indexKey.split('-')[1] + '"]');
    //alert(indexKey);
    //alert($(theCateRow).html());

    //return;

    theCateRow.attr('productid', productInfo.productid);
    var n = 0;
    if (theCateRow.children('td').length == 6) n = 1;

    $(theCateRow.children('td')[n + 1]).html('<span title="' + productInfo.productname + '">' + productInfo.productname.substring(0, 7) + '...</span>');
    $(theCateRow.children('td')[n + 2]).html('<a class="count-add" style="cursor:pointer"> + </a><span>' + productInfo.count + '</span><a class="count-minus" style="cursor:pointer"> - </a>');
    $(theCateRow.children('td')[n + 3]).html(productInfo.price);
    $(theCateRow.children('td')[n + 4]).html('<a id="delete-' + indexKey + '" class="iconButton delete" style="cursor:pointer"></a>');

    $('#delete-' + indexKey).click(function() {
        removeProduct(indexKey);
    });

    $(theCateRow.children('td')[n + 2]).children('.count-add').click(function() { var c = parseInt($(this).next().html()); $(this).next().html(c + 1); calculateTotalPrice(true); });
    $(theCateRow.children('td')[n + 2]).children('.count-minus').click(function() { var c = parseInt($(this).prev().html()); if ((c - 1) >= 1) $(this).prev().html(c - 1); calculateTotalPrice(true); });

    calculateTotalPrice(true);
}
function removeProduct(indexKey) {
    //debugger;
    var selectedProducts = getSelectedList();
    selectedProducts.Remove(indexKey);
    setSelectedList(selectedProducts);

    var theCateRow = $('#selected-product-list tr[fatherid="' + indexKey.split('-')[0] + '"][categoryid="' + indexKey.split('-')[1] + '"]');

    theCateRow.removeAttr('productid');
    var n = 0;
    if (theCateRow.children('td').length == 6) n = 1;

    $(theCateRow.children('td')[n + 1]).html('');
    $(theCateRow.children('td')[n + 2]).html('');
    $(theCateRow.children('td')[n + 3]).html('');
    $(theCateRow.children('td')[n + 4]).html('');

    $('#product-list tr input[categoryid="' + indexKey.split('-')[1] + '"][fatherid="' + indexKey.split('-')[0] + '"]').attr('checked', false);
    calculateTotalPrice(false);
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


function calculateTotalPrice(isAdd) {
    //debugger;
    var currentPriceSum = 0;

    $('#selected-product-list tr').each(function() {
        var n = 0;
        if ($(this).children('td').length == 6) n = 1;

        if ($(this).children('td').length >= 5 && $($(this).children('td')[n + 1]).html() != '') {
            currentPriceSum += parseFloat($($(this).children('td')[n + 3]).html().replace('￥', '')) * parseFloat($($(this).children('td')[n + 2]).children('span').html());
        }
    });

    $('#price-sum').html(currentPriceSum);
}

function clearSelect() {
    var selectedProducts = getSelectedList();
    for (var i = 0; i < selectedProducts.Count; i++) {
        var categoryID = selectedProducts.Keys()[i];
        removeProduct(categoryID);
    }
}

function submitSelect() {
    var submitParmeter = 'pid=';

    $('#selected-product-list tr').each(function(i, o) {
        if ($(o).children('td').length >= 5) {
            var n = 0;
            if ($(o).children('td').length == 6) n = 1;

            if ($(o).attr('productid')) {
                var productid = $(o).attr('productid');
                var count = $($(o).children('td')[n + 2]).children('span').html();
                submitParmeter += productid + '-' + count + ',';
            }
        }
    });
    submitParmeter = submitParmeter.substring(0, submitParmeter.length - 1);

    window.location = '/sp/addtocart.aspx?' + submitParmeter;
}

function turnPage(data, pageIndex, fatherCategoryID) {
    var html = '<div class="table2">' +
                           '     <table id="product-list">' +
                           '       <tr>' +
                           '         <th class="first"><span>商品图片</span></th>' +
                           '         <th><span>商品名称</span></th>' +
                           '         <th><span>商品价格</span></th>' +
                           '         <th><span>选用</span></th>' +
                           '       </tr>';


    var recordCount = (data == null ? 0 : data.length), pageCount = 1;
    if (recordCount % pageSize != 0) { pageCount = parseInt(recordCount / pageSize) + 1; } else { pageCount = parseInt(recordCount / pageSize); }
    var itemBegin = (pageIndex - 1) * pageSize, itemEnd = itemBegin + pageSize;
    if (pageCount == pageIndex) itemEnd = recordCount;



    for (var i = itemBegin; i < itemEnd; i++) {

        html += '<tr class="' + (i % 2 == 0 ? "odd" : 'even') + '">' +
                  '  <td><a href="' + data[i].url + '" target="_blank"><img src="' + data[i].image + '" /></a></td>' +
                  '  <td><a href="' + data[i].url + '" target="_blank">' + data[i].productname + '</a></td>' +
                  '  <td>￥' + data[i].price + '</td>' +
                  '  <td><input type="checkbox" productid="' + data[i].productid + '" categoryid="' + data[i].categoryid + '" fatherid="' + fatherCategoryID + '" /></td>' +
                  '</tr>';
    }


    var paginateHtml = '共' + recordCount + '条' + pageCount + '页';

    if (pageIndex == 1) paginateHtml += '<a class="prev" href="#"></a>';
    else paginateHtml += '<a class="prev" href="#" page="' + (pageIndex - 1) + '"></a>';
    paginateHtml += '<div class="pageNum">';

    for (var i = 1; i <= pageCount; i++) {
        if (pageIndex == i)
            paginateHtml += '<a class="on" href="#">' + i + '</a>';
        else
            paginateHtml += '<a page="' + i + '" href="#">' + i + '</a>';
    }

    paginateHtml += '</div>';
    if (pageIndex == pageCount) paginateHtml += '<a class="next" href="#"></a>';
    else paginateHtml += '<a class="next" href="#" page="' + (pageIndex + 1) + '"></a>';


    html += '<tr class="bottom">' +
            '    <td colspan="4">' +
            '      <div class="pagination">' + paginateHtml +
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
        var theKey = theBox.attr('fatherid') + '-' + theBox.attr('categoryid');
        if (status) {
            addProduct(theKey, {
                productid: theBox.attr('productid'),
                productname: $(row.children('td')[1]).text(),
                count: 1,
                price: $(row.children('td')[2]).text()
            });
        }
        else {
            removeProduct(theKey);
        }
    });
    // click event for the product checkbox end

    //paginate event
    $('.pagination a[page]').click(function() {
        turnPage(data, parseInt($(this).attr('page')), fatherCategoryID);
    });
}