$(function() {
    $('#comment-button').click(function() {
        var content = $('#comment-content').val();
        var demandID = $(this).attr('dmid');
        if (content == '') {
            alert('请输入评论内容');
        }
        else {
            $.ajax({
                url: '/handler/CommentHandler.ashx',
                type: 'post',
                data: 'app=6&tid=' + demandID + '&cnt=' + content,
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
});