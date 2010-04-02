$(function() {
    $('.pagination a[page]').click(function() {
        alert($(this).attr('page'));
    });
});