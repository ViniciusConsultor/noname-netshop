$(function() {
    $('#comment-button').click(function() {
        var content = $('#comment-content').val();
        var validate = $('#comment-validate').val();
        var auctionID = $(this).attr('auid');
        if (content == '') {
            alert('请输入评论内容');
        }
        else {
            $.ajax({
                url: '/handler/CommentHandler.ashx',
                type: 'post',
                data: 'app=6&tid=' + auctionID + '&cnt=' + content + '&vld=' + validate,
                cache: false,
                dataType: 'json',
                success: function(data, textStatus) {
                    if (data.result.toString() == 'true') {
                        alert('发表成功！');
                        $('#comment-content').val('');
                        $('#comment-validate').val('');
                        window.location.reload();
                    }
                    else alert(data.message);
                }
            });
        }
    });

    $('#add-prices .button_blue').click(function() {
        return confirm("确认竞拍？");
    });
});