$(function() {

    $('#comment-button').click(function() {
        var content = $('#comment-text').val();
        var validate = $('#comment-validate').val();
        var newsID = $(this).attr('newsid'); ;
        if (content == '') {
            alert('请输入评论内容');
        }
        else {
            $.ajax({
                url: '/handler/CommentHandler.ashx',
                type: 'post',
                data: 'app=2&tid=' + newsID + '&cnt=' + content + '&vld=' + validate,
                cache: false,
                dataType: 'json',
                error: function(event, request, settings) { alert(request); },
                success: function(data, textStatus) {
                    alert(data);
                    if (data.result.toString() == 'true') {
                        alert('发表成功！');
                        window.location.reload();
                    }
                    else alert(data.msg);
                }
            });
        }
    });
});