$(function() {

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