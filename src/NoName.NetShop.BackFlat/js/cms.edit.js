$(function() {
    if ($('.tagGrid tr')) {
        $('.tagGrid tr').each(function(i, n) {
            if (i != 0) {
                (i % 2 == 0) ? $(this).css('background', '#ecf0f2') : $(this).css('background', '#f5f8fb');
            }
        });
    }    
});