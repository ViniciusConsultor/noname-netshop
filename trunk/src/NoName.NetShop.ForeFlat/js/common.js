$(function() {
    $('#search-button').click(function() {
        var category = $('#search-category').val();
        var word = $('#search-word').val();

        window.open('/search/productsearch.aspx?c=' + category + '&w=' + word);
    });

});