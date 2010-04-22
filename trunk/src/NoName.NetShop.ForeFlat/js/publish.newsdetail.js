$(function() {

    loadEvaluation();

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
                    if (data.result.toString() == 'true') {
                        alert('发表成功！');
                        loadComment();
                    }
                    else alert(data.message);
                }
            });
        }
    });



});

function loadComment() {
    var newsID = $('#news-identity').val();
    $.ajax({
        url: '/handler/newshandler.ashx',
        type: 'get',
        data: 'action=commentlist&nid=' + newsID,
        cache: false,
        dataType: 'json',
        error: function(a, b, c) { $('#comment-list').html('加载错误，请刷新页面'); },
        beforeSend: function() { $('#comment-list').html('加载中...'); },
        success: function(data, textStatus) {
            // construct html

            if (data.result) { alert(data.message); return; }
            var html = '';
            html += '<table><tr><th>用户名</th><th>内容</th><th>发表时间</th></tr>';
            $.each(data, function(i, n) { html += '<tr><td>' + n.userid + '</td><td>' + n.content + '</td><td><span>' + n.createtime + '</span></td></tr>'; });
            html += '</table>';
            $('#comment-list').html(html);


            $('#comment-text').val('');
            $('#comment-validate').val('');
            $('#comment-vimage').attr('src', '/ValiateCode.aspx?_=' + new Date().getUTCMilliseconds());

        }
    });    
}


function loadEvaluation() {
    var newsID = $('#news-identity').val();
    $.ajax({
        url: '/handler/newshandler.ashx',
        type: 'get',
        data: 'action=getevaluation&nid=' + newsID,
        cache: false,
        dataType: 'json',
        error: function(a, b, c) { $('#evaluation-list').html('加载错误，请刷新页面'); },
        beforeSend: function() { $('#evaluation-list').html('加载中...'); },
        success: function(data, textStatus) {
            // construct html
            if (data.result) { alert(data.message); return; }
            var html = '';

            html += '<h1>您觉得该条新闻如何？</h1><ul>';
            $.each(data.items, function(i, n) {
                html += '<li><span class="option">' + getEvaluationString(n.evaluation) + '</span>';
                html += '<div class="votebarParent"><div style="width:' + n.percentage + '%"><div class="votebar votebar4"><div class="light"></div></div></div></div>';
                html += '<span class="result">' + n.count + '(' + n.percentage + '%)</span>';
                html += '<input class="checkbox news-evaluation" type="checkbox" value="' + n.evaluation + '" /></li>';
            });
            html += '<li><span class="button"><a class="button_blue2" id="go-evaluation" newsid="' + newsID + '" evaluation="4" style="cursor:pointer">投票</a></span></li>';

            $('#evaluation-list').html(html);

            $('.news-evaluation').click(function() {
                $('.news-evaluation').each(function() { $(this).removeAttr('checked') });
                $(this).attr('checked', 'true');
                $('#go-evaluation').attr('evaluation', $(this).val());
            });

            $('#go-evaluation').click(function() {
                addEvaluation($(this).attr('newsid'), $(this).attr('evaluation'));
            });
        }
    });
}

function addEvaluation(newsID, evaluation) {
    $.ajax({
        url: '/handler/newshandler.ashx',
        type: 'get',
        data: 'action=addevaluation&nid=' + newsID + '&val=' + evaluation,
        cache: false,
        dataType: 'json',
        error: function(a, b, c) { alert() },
        beforeSend: function() { /*$('#go-evaluation').html('提交中...'); */ },
        success: function(data, textStatus) {
            if (data.result.toString() == 'true') {
                alert('提交成功！');
                loadEvaluation();
            }
            else alert(data.message);
        }
    })
}

function getEvaluationString(evaluation) {
    switch (parseInt(evaluation)) {
        case 1:
            return '有待提高';
        case 2:
            return '还行';
        case 3:
            return '不错';
        case 4:
            return '很好';
        default:
            return;
    }
}
