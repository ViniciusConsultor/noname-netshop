$(function() {
    $('#productList a[fav="true"]').click(function() {
        addFav($(this).attr('suiteid'));
    });
});



function addFav(suiteID) {
    $.ajax({
        url: '/api/CartOpenApi.ashx',
        type: 'post',
        data: 'action=addfavorite&ctype=5&cid=' + suiteID,
        cache: false,
        dataType: 'json',
        error: function() { alert('收藏失败,请稍后重试。'); },
        success: function(data, textStatus) {
            if (data.Result == true) {
                alert('收藏成功！');
            }
            else if (data.Message.indexOf('登录') > 0) {
                window.open('/login.aspx?returnurl=' + encodeURIComponent('/member/dofavorite.aspx?ctype=1&cid=' + suiteID));
            }
            else {
                alert(data.Message);
            }
        }
    });
}