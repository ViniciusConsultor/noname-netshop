$(function() {

    addBrowsed();
    showBrowsed();

    $('#comment-button').click(function() {
        var content = $('#comment-text').val();
        var productID = $(this).attr('productid');
        if (content == '') {
            alert('请输入评论内容');
        }
        else {
            $.ajax({
                url: '/handler/CommentHandler.ashx',
                type: 'post',
                data: 'app=5&tid=' + productID + '&cnt=' + content,
                cache: false,
                dataType: 'text',
                success: function(data, textStatus) {
                    if (data.toLowerCase() == 'true') {
                        alert('发表成功！');
                        window.location.reload();
                    }
                    else alert('添加失败');
                }
            });
        }
    });

    $('.addToFavorite').click(function() {
        var productID = $(this).attr('productid');
        addFav(productID);
    });
});

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
                window.open('/login.aspx?returnurl=' + encodeURIComponent('/member/DoFavorite.aspx?ctype=1&cid=' + productID));
            }
            else {
                alert(data.Message);
            }
        }
    });
}

function addBrowsed() {
    var browsedProducts = new Array();
    var cookieStr = $.cookie('browsedproducts');
    if (cookieStr != null && cookieStr != '') {
        for (i = 0; i < cookieStr.split(';').length - 1; i++) {
            if (cookieStr.split(';')[i].split(',')[0] != product.productid) {
                var op = new Object();
                op.productid = cookieStr.split(';')[i].split(',')[0];
                op.productname = cookieStr.split(';')[i].split(',')[1];
                op.image = cookieStr.split(';')[i].split(',')[2];

                browsedProducts.push(op);
            }
        }
    }
    if (product != null)
        browsedProducts.unshift(product);
    var newCookieStr = '';
    for (a = 0; a < browsedProducts.length; a++) {
        newCookieStr += browsedProducts[a].productid + ',' + browsedProducts[a].productname + ',' + browsedProducts[a].image + ';';
    }
    $.cookie('browsedproducts', newCookieStr);
}

function showBrowsed() {
    var browsedProducts = new Array();

    var cookieStr = $.cookie('browsedproducts');

    if (cookieStr != null && cookieStr != '') {
        for (i = 0; i < (cookieStr.split(';').length - 1 > 8 ? 8 : cookieStr.split(';').length - 1); i++) {
            var op = new Object();
            op.productid = cookieStr.split(';')[i].split(',')[0];
            op.productname = cookieStr.split(';')[i].split(',')[1];
            op.image = cookieStr.split(';')[i].split(',')[2];

            browsedProducts.push(op);
        }
    }

    var browsedProductHtml = '';

    for (i = 0; i < browsedProducts.length; i++) {
        browsedProductHtml += '<li><a href="/product-' + browsedProducts[i].productid + '.html"><img src="' + browsedProducts[i].image + '" /><span>' + browsedProducts[i].productname + '</span></a></li>';
    }
    $('#browsed-products').html(browsedProductHtml);
}
