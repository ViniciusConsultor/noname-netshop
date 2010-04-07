String.prototype.endWith = function(str) {
    if (str == null || str == "" || this.length == 0 || str.length > this.length)
        return false;
    if (this.substring(this.length - str.length) == str)
        return true;
    else
        return false;
    return true;
}

String.prototype.startWith = function(str) {
    if (str == null || str == "" || this.length == 0 || str.length > this.length)
        return false;
    if (this.substr(0, str.length) == str)
        return true;
    else
        return false;
    return true;
}


$(function() {
    $('#search-button').click(function() {
        var category = $('#search-category').val();
        var word = $('#search-word').val();

        window.open('/search/productsearch.aspx?c=' + category + '&w=' + word);
    });

    setCurrentNavigator();

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

function setCurrentNavigator() {
    var url = window.location.href;
    /http:(.+)\/(.+)/g.test(url);
    var lastHalf = RegExp.$2.toString().toLowerCase();
    var navifators = $('.navigator li a');

    if (lastHalf.startWith('channel/shopping') > 0) {
        $(navifators[1]).addClass('shoppinghover');
    }
    if (lastHalf.startWith('channel/solution') > 0) {
        $(navifators[2]).addClass('solutionhover');
    }
    if (lastHalf.startWith('channel/brand') > 0) {
        $(navifators[3]).addClass('brandshover');
    }
    if (lastHalf.startWith('channel/info') > 0) {
        $(navifators[4]).addClass('informationhover');
    }
    if (lastHalf.startWith('channel/magic') > 0) {
        $(navifators[5]).addClass('magichover');
    }
}