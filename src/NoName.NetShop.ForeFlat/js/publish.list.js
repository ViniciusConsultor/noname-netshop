$(function() {
    /* initialize */
    //order
var orderType = getOrder();
    $('.sort a').removeAttr('class');
    if (orderType == 1) {
        $('.sort a[field="changetime"]').attr('class', 'on').attr('type', 1);
    }
    else if (orderType == 2) {
        $('.sort a[field="changetime"]').attr('class', 'on').attr('type', 0);
    }
    else if (orderType == 3) {
        $('.sort a[field="sales"]').attr('class', 'on').attr('type', 1);
    }
    else if (orderType == 4) {
        $('.sort a[field="sales"]').attr('class', 'on').attr('type', 0);
    }
    else if (orderType == 5) {
        $('.sort a[field="price"][href]').attr('class', 'on');
    }
    else if (orderType == 6) {
        $('.sort a[field="price"][href]').attr('class', 'on');
    }
    else if (orderType == 7) {
        $('.sort a[field="hit"]').attr('class', 'on').attr('type', 1);
    }
    else if (orderType == 8) {
        $('.sort a[field="hit"]').attr('class', 'on').attr('type', 0);
    }
    else {
        $('.sort a[field="changetime"]').attr('class', 'on').attr('type', 1);
    }

    //properity
    var initialTable = getListUrlParameter();
    //alert(initialTable.Count);
    for (var i = 0; i < initialTable.Count; i++) {
        var prop = initialTable.Keys()[i];
        var propValue = initialTable.GetValue(prop);
        $('.properity[propid=' + prop + ']').children('a[propvid=' + propValue + ']').attr('class', 'on');
    }

    //page

    //brand
    //    var currentBrandID = getBrandID();
    //    $('.properity a[brand]').each(function(i, o) {
    //        if (parseInt(o.attr('brand')) == currentBrandID) {
    //        }
    //    });

    //pricerange
    //    var currentPriceRange = getPriceRange();
    //    $('.properity a[range]').each(function(i, o) {
    //    });


    /* initialize end */


    //排序事件
    $('.sort a[style]').click(function() {
        $('.sort a[style]').removeAttr('class');
        $(this).attr('class', 'on');
        var field = $(this).attr('field');
        var type = $(this).attr('type');

        var sortValue = 0;

        if (field == 'changetime') {
            sortValue = parseInt(type) == 0 ? 1 : 2;
            $(this).attr('type', parseInt(type) == 0 ? '1' : '0');
        }
        else if (field == 'sales') {
            sortValue = parseInt(type) == 0 ? 3 : 4;
            $(this).attr('type', parseInt(type) == 0 ? '1' : '0');
        }
        else if (field == 'price') {
            sortValue = parseInt(type) == 0 ? 5 : 6;
        }
        else if (field == 'hit') {
            sortValue = parseInt(type) == 0 ? 7 : 8;
            $(this).attr('type', parseInt(type) == 0 ? '1' : '0');
        }
        else
            sortValue = 1;

        //alert(sortValue);

        setOrder(sortValue);
    });

    //品牌事件
    $('.properity a[brand]').click(function() {
        $(this).attr('class', 'on');
        var brandid = $(this).attr('brand');
        setBrandID(brandid);
    });
    //价格区间事件
    $('.properity a[range]').click(function() {
        $(this).attr('class', 'on');
        var priceRange = $(this).attr('range');
        setPriceRange(priceRange);
    });

    //属性事件
    $('.properity a[propvid]').click(function() {
        var propID = parseInt($(this).parent().children('a[propid]').attr('propid'));
        var propValueID = parseInt($(this).attr('propvid'));

        var parmList = getListUrlParameter();
        parmList.Add(propID, propValueID);
        setListUrlParameter(parmList);


        //$('.properity a').each(function() { $(this).removeAttr('class'); });
        $(this).attr('class', 'on');
    });

    //翻页事件
    $('.pagination a[page]').click(function() {
        if ($(this).attr('class') == 'prev') {
            var page = getPage();
            page = page - 1;
            setPage(page);
        }
        else if ($(this).attr('class') == 'next') {
            var page = getPage();
            page = page + 1;
            setPage(page);
        }
        else {
            var page = $(this).attr('page');
            setPage(page);
        }
    });

    //添加收藏事件
    $('.actions a[fav="true"]').click(function() {
        addFav($(this).attr('productid'));
    });

    //商品对比事件
    $('a.button_blue3[comp]').click(function() {
        addCompare({
            productid: $(this).attr('productid'),
            productname: $(this).attr('productname'),
            categoryid: $(this).attr('category'),
            image: $(this).attr('image')
        });
    });



    function getPage() {
        var url = window.location.href;
        /(.+)(\/list[-_]+\d+)([-_]+\d+)?([-_]+b\d+)?([-_]+r\d+~\d+)?([-_]+o\d+)?([-_]+v.+e)?(.+)/g.test(url);

        if (RegExp.$3 == '') return 1;
        else return parseInt(RegExp.$3.replace('-', ''));
    }
    function setPage(page) {
        var url = window.location.href;
        /(.+)(\/list[-_]+\d+)([-_]+\d+)?([-_]+b\d+)?([-_]+r\d+~\d+)?([-_]+o\d+)?([-_]+v.+e)?(.+)/g.test(url);

        var pageString = '-' + page;
        url = RegExp.$1 + RegExp.$2 + pageString + RegExp.$4 + RegExp.$5 + RegExp.$6 + RegExp.$7 + RegExp.$8;
        window.location.href = url;
    }

    function getOrder() {
        var url = window.location.href;
        /(.+)(\/list[-_]+\d+)([-_]+\d+)?([-_]+b\d+)?([-_]+r\d+~\d+)?([-_]+o\d+)?([-_]+v.+e)?(.+)/g.test(url);
        //alert('1:' + RegExp.$1 + '\n2:' + RegExp.$2 + '\n3:' + RegExp.$3 + '\n4:' + RegExp.$4 + '\n5:' + RegExp.$5 + '\n6:' + RegExp.$6 + '\n7:' + RegExp.$7 + '\n8:' + RegExp.$8 + '\n9:' + RegExp.$9);


        if (RegExp.$6 == '') return 1;
        else return parseInt(RegExp.$6.replace('-o', ''));
    }
    function setOrder(order) {
        var url = window.location.href;
        /(.+)(\/list[-_]+\d+)([-_]+\d+)?([-_]+b\d+)?([-_]+r\d+~\d+)?([-_]+o\d+)?([-_]+v.+e)?(.+)/g.test(url);

        //alert('1:' + RegExp.$1 + '\n2:' + RegExp.$2 + '\n3:' + RegExp.$3 + '\n4:' + RegExp.$4 + '\n5:' + RegExp.$5 + '\n6:' + RegExp.$6);
        //1 : url prefix
        //2 : /list-117 (category)
        //3 : -1 (page)
        //4 : -b2 (brand)
        //5 : -r11~12 (price)
        //6 : -o1 (order)
        //7 : -v178-2,168-1e
        //8 : .list
        //url = RegExp.$1 + RegExp.$2 + RegExp.$4 + RegExp.$5 + RegExp.$6;

        var orderString = order == 1 ? '' : '-o' + order;
        url = RegExp.$1 + RegExp.$2 + RegExp.$4 + RegExp.$5 + orderString + RegExp.$7 + RegExp.$8;
        window.location.href = url;
    }

    function getBrandID() {
        var url = window.location.href;
        /(.+)(\/list[-_]+\d+)([-_]+\d+)?([-_]+b\d+)?([-_]+r\d+~\d+)?([-_]+o\d+)?([-_]+v.+e)?(.+)/g.test(url);
        //alert('1:' + RegExp.$1 + '\n2:' + RegExp.$2 + '\n3:' + RegExp.$3 + '\n4:' + RegExp.$4 + '\n5:' + RegExp.$5 + '\n6:' + RegExp.$6 + '\n7:' + RegExp.$7 + '\n8:' + RegExp.$8 + '\n9:' + RegExp.$9);
        if (RegExp.$4 == '') return -1;
        else return parseInt(RegExp.$4.replace('-b', ''));
    }
    function setBrandID(brandID) {
        var url = window.location.href;
        /(.+)(\/list[-_]+\d+)([-_]+\d+)?([-_]+b\d+)?([-_]+r\d+~\d+)?([-_]+o\d+)?([-_]+v.+e)?(.+)/g.test(url);

        var brandString = '';
        if (brandID != 0) {
            brandString = '-b' + brandID;
        }

        url = RegExp.$1 + RegExp.$2 + brandString + RegExp.$5 + RegExp.$6 + RegExp.$7 + RegExp.$8;
    }

    function getPriceRange() {
        var url = window.location.href;
        /(.+)(\/list[-_]+\d+)([-_]+\d+)?([-_]+b\d+)?([-_]+r\d+~\d+)?([-_]+o\d+)?([-_]+v.+e)?(.+)/g.test(url);

        if (RegExp.$5 == '') return -1;
        else return RegExp.$5.replace('-r', '');
    }
    function setPriceRange(range) {
        var url = window.location.href;
        /(.+)(\/list[-_]+\d+)([-_]+\d+)?([-_]+b\d+)?([-_]+r\d+~\d+)?([-_]+o\d+)?([-_]+v.+e)?(.+)/g.test(url);

        var rangeString = '';
        if (range != '-1') {
            rangeString = '-r' + range;
        }

        url = RegExp.$1 + RegExp.$2 + RegExp.$4 + rangeString + RegExp.$6 + RegExp.$7 + RegExp.$8;
    }

    function getListUrlParameter() {
        var url = window.location.href;

        var parameterTable = new Hashtable();

        if (url.indexOf('v') > 0 && url.indexOf('e') > 0) {
            var parmPart = url.split('v')[1].split('e')[0];

            if (parmPart.indexOf(',') < 0)
                parameterTable.Add(parmPart.split('-')[0], parmPart.split('-')[1]);
            else {
                var parmArray = parmPart.split(',');
                for (var i = 0; i < parmArray.length; i++) {
                    parameterTable.Add(parmArray[i].split('-')[0], parmArray[i].split('-')[1]);
                }
            }
        }

        return parameterTable;
    }
    function setListUrlParameter(parameterTable) {
        var url = window.location.href;
        /(.+)(\/list[-_]+\d+)([-_]+\d+)?([-_]+b\d+)?([-_]+r\d+~\d+)?([-_]+o\d+)?([-_]+v.+e)?(.+)/g.test(url);

        var parmPart = '';
        if (parameterTable.Count == 1) {
            var prop = parameterTable.Keys()[0];
            var propValue = parameterTable.GetValue(prop);

            if (parseInt(propValue) != -1)
                parmPart += prop + '-' + propValue + ',';
        }
        else {
            for (var i = 0; i < parameterTable.Count; i++) {
                var prop = parameterTable.Keys()[i];
                var propValue = parameterTable.GetValue(prop);

                if (parseInt(propValue) != -1)
                    parmPart += prop + '-' + propValue + ',';
            }
        }

        if (parmPart != '') {
            parmPart = '-v' + parmPart.substring(0, parmPart.lastIndexOf(',')) + 'e';
        }

        url = RegExp.$1 + RegExp.$2 + RegExp.$4 + RegExp.$5 + RegExp.$6 + parmPart + RegExp.$8;
        //url = RegExp.$1 + RegExp.$2 + RegExp.$4 + parmPart + RegExp.$6;

        window.location = url;
    }

    function addFav(productID) {
        $.ajax({
            url: '/api/CartOpenApi.ashx',
            type: 'post',
            data: 'action=addfavorite&ctype=1&cid=' + productID,
            cache: false,
            dataType: 'json',
            error: function() { alert('收藏失败,请稍后重试。'); },
            success: function(data, textStatus) {
                if (data.Result == true) {
                    alert('收藏成功！');
                }
                else if (data.Message.indexOf('登录') > 0) {
                    window.open('/login.aspx?returnurl=' + encodeURIComponent('/member/dofavorite.aspx?ctype=1&cid=' + productID));
                }
                else {
                    alert(data.Message);
                }
            }
        });
    }

    var comparingProducts = new Hashtable();

    function addCompare(p) {

        var topLayer = $('#comparisonWindow');

        if (topLayer.attr('category')) {
            if (topLayer.attr('category') == p.categoryid) {
                if (comparingProducts.Count < 3) {
                    comparingProducts.Add(p.productid, p);
                    renderCompareHtml();
                }
                else {
                    alert('最多只能比较3件商品');
                }
            }
            else {
                alert('只能比较同类产品！');
            }
        }
        else {
            topLayer.attr('category', p.categoryid);
            comparingProducts.Add(p.productid, p);
            renderCompareHtml();
        }

        function remove(productid) {
            comparingProducts.Remove(productid);
            renderCompareHtml();
        }

        function removeAll() {
            comparingProducts = new Hashtable();

            topLayer.html('');
        }


        function renderCompareHtml() {
            var compareHtml = '';

            if (comparingProducts.Count > 0) {
                compareHtml += '<div class="box10">';
                compareHtml += '    <div class="title">';
                compareHtml += '        <span style="float:left">产品比较</span>';
                compareHtml += '        <a href="javascript:void(0)" style="float:right; margin-right:5px;" id="productCompareClose">[关闭]</a>';
                compareHtml += '    </div>';
                compareHtml += '    <div class="content">';
                compareHtml += '        <ul class="itemList8" id="productCompareList">';
                for (var cmp = 0; cmp < comparingProducts.Count; cmp++) {
                    var key = comparingProducts.Keys()[cmp];
                    var theValue = comparingProducts.GetValue(key);
                    compareHtml += '            <li>';
                    compareHtml += '                <a href="/product-' + key + '.html">';
                    compareHtml += '                    <img src="' + theValue.image + '" />';
                    compareHtml += '                    <span>' + theValue.productname + '</span>';
                    compareHtml += '                </a>';
                    compareHtml += '                <a class="remove" href="javascript:void(0);" productid=' + key + '>';
                    compareHtml += '                    <span>[移除]</span>';
                    compareHtml += '                </a>';
                    compareHtml += '            </li>';
                }
                compareHtml += '        </ul>';
                compareHtml += '    </div>';
                compareHtml += '    <div><a href="javascript:void(0);" id="productCompareGo"> <b>对比</b> </a></div>';
                compareHtml += '</div>';

                topLayer.html(compareHtml);

                $('#productCompareList .remove').click(function() {
                    remove($(this).attr('productid'));
                });
                $('#productCompareClose').click(function() {
                    removeAll();
                });
                $('#productCompareGo').click(function() {
                    var pids = '';
                    $.each(comparingProducts.Keys(), function(i, n) { pids += comparingProducts.Keys()[i] + ','; });
                    window.open('/product/productcompare.aspx?pid=' + pids.substring(0, pids.length - 1));
                });
            }
            else {
                topLayer.html('');
            }
        }
    }
});