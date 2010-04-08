$(function() {
    $('.pagination a[page]').click(function() {
        changePage($(this).attr('page'));
    });

});

function changePage(page) {
    var url = window.location.href;
    /http:(.+)\/newslist([-|-]+\d+)([-|-]+\d+)?(.+)/g.test(url);
    //var lastHalf = RegExp.$2.toString().toLowerCase();
    window.location = 'http:' + RegExp.$1 + '/' + RegExp.$2 + (parseInt(page) == 1 ? '' : '-' + page) + RegExp.$4;
    
}