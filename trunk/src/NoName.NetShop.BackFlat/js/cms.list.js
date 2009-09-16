$(function() {
    $('#newPanel').css({ width: '88px' });
    $('#newPanel .content').css('display', 'none');
    $('#newPanel .title span').css('cursor', 'pointer');

    $('#newPanel .title span').click(function() {
        $('#newPanel').animate({ 'width': '100%' }, 'fast');
        $('#newPanel .content').slideDown('fast');
    });
    $('#Button2').click(function() {
        $('#newPanel').animate({ 'width': '88px' }, 'fast');
        $('#newPanel .content').slideUp('fast');
    });
    if ($('.listGrid tr')) {
        var originBg = '';
        $('.listGrid tr').hover(
            function() { originBg = $(this).css('background'); $(this).css('background', '#e4f1ff'); },
            function() { $(this).css('background', originBg); }
        );
        $('.listGrid tr').each(function(i, n) {
            if (i != 0) {
                (i % 2 == 0) ? $(this).css('background', '#f4f9ff') : $(this).css('background', '#f9f9f9');
            }
        });
    }
});