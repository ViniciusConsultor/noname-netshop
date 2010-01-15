$(function() {
    //首先从cookie中读取，决定当前页是否有已选择商品，并决定是否有勾选
    $.cookie('slselectproducts', '');

    $('#product-list tr input[type="checkbox"]').click(function() {
        var row = $(this).parent().parent();
        var status = $(this).attr('checked');

        if (status) {
            addProduct($(this).attr('productid'), {
                productname: $(row.children('td')[1]).text(),
                count: 1,
                price: $(row.children('td')[2]).text()
            });
        }
        else {
            removeProduct($(this).attr('productid'));
        }
        //alert(getSelectedList().count);
        //        for (var i = 0; i < selectedProducts.count; i++) {
        //            alert(selectedProducts.keys()[i]);
        //        }
        alert($.cookie('slselectproducts'));


    });



    function getSelectedList() {
        var cookieStr = $.cookie('slselectproducts');
        var selectedProducts = new Hashtable();
        if (cookieStr == null) { } // 此时cookie中尚无任何信息{}
        if (cookieStr == '') { } // 此时cookie内容被清{}
        if (cookieStr != null && cookieStr != '' && cookieStr.indexOf(';') == -1) // 此时cookie中只包含一条数据
        {
            selectedProducts.Add(cookieStr.split(',')[0], { productname: cookieStr.split(',')[1], count: cookieStr.split(',')[2], price: cookieStr.split(',')[3] });
        }
        if (cookieStr != null && cookieStr != '' && cookieStr.indexOf(';') >= 0) // 此时cookie中包含多条数据
        {
            for (var i = 0; i < cookieStr.split(';').length; i++) {
                var p = cookieStr.split(';')[i];
                selectedProducts.Add(p.split(',')[0], { productname: p.split(',')[1], count: p.split(',')[2], price: p.split(',')[3] });
            }
        }

        return selectedProducts;
    }
    function setSelectedList(selectedProducts) {
        var cookieStr = '';
        for (var i = 0; i < selectedProducts.Count; i++) {
            var key = selectedProducts.Keys()[i];
            var info = selectedProducts.GetValue(key);

            if (i != selectedProducts.Count - 1) {
                cookieStr += key + ',' + info.productname + ',' + info.count + ',' + info.price + ';';
            }
            else {
                cookieStr += key + ',' + info.productname + ',' + info.count + ',' + info.price;
            }
        }
        $.cookie('slselectproducts', cookieStr);
    }
    function addProduct(productid, productInfo) {
        //debugger;
        var selectedProducts = getSelectedList();
        selectedProducts.Add(productid, productInfo);
        setSelectedList(selectedProducts);
    }
    function removeProduct(productid) {
        var selectedProducts = getSelectedList();
        selectedProducts.Remove(productid);
        setSelectedList(selectedProducts);
    }
});

