$(function() {
    initiateOrder();

    $('.pagination a[page]').click(function() {
        //alert($(this).attr('page'));
        var parm = getUrlParameter();
        parm.Add('p', $(this).attr('page'));
        setUrlParameter(parm);
    });


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

        var parm = getUrlParameter();
        parm.Add('o', sortValue);
        setUrlParameter(parm);
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



});

function initiateOrder() {

    var orderType = getUrlParameter();
    if (orderType != null) orderType = orderType.GetValue('o');
    else orderType = 0;
    
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
        //$('.sort a[field="changetime"]').attr('class', 'on').attr('type', 1);
    }
}


function getUrlParameter() {
    var url = window.top.location.toString();
    var p = new Hashtable();
    var index = url.indexOf("?");
    if (index == -1)
        return null;
    else {
        var queryString = url.substr(index + 1);
        var arr = queryString.split("&");
        for (var i = 0; i < arr.length; i++) {
            p.Add(arr[i].split("=")[0], arr[i].split("=")[1]);
        }
        return p;
    }
}

function setUrlParameter(p) {
    var url = window.top.location.toString();
    var index = url.indexOf("?");
    var parmString = '';

    for (var i = 0; i < p.Count; i++) {
        parmString += (i == 0 ? '' : '&') + p.Keys()[i] + '=' + p.GetValue(p.Keys()[i]);
    }

    if (index == -1)
        window.location = url + '?' + parmString
    else
        window.location = url.split("?")[0] + '?' + parmString;
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