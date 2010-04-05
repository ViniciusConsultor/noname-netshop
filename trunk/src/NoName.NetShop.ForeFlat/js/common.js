$(function() {
    $('#search-button').click(function() {
        var category = $('#search-category').val();
        var word = $('#search-word').val();

        window.open('/search/productsearch.aspx?c=' + category + '&w=' + word);
    });

});



function getUrlParameter() {
    var url = window.top.location.toString();
    var p = new Hashtable();
    var index = url.indexOf("?");
    if (index == -1)
        return null;
    else {
        var queryString = url.substr(index + 1);
        var arr = queryString.split("&");
        for (var i = 0; i < arr.length; i++) {
            p.Add(arr[i].split("=")[0], arr[i].split("=")[1]);
        }
        return p;
    }
}
function setUrlParameter(p) {
    var url = window.top.location.toString();
    var index = url.indexOf("?");
    if (index == -1)
        return null;
    else {
        var queryString = url.substr(0, index + 1);
        for (var i = 0; i < p.Count; i++) {
            queryString += (i == 0 ? '' : '&') + p.Keys()[i] + '=' + p.GetValue(p.Keys()[i]);
        }
        return queryString;
    }
}