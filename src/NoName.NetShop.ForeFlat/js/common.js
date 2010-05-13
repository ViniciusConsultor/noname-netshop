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

        if (word != '') {
            window.open('/search/productsearch.aspx?c=' + category + '&w=' + escape(word));
        }
        else {
            alert('请输入检索词');
        }
    });

    setCurrentNavigator();

});


if (typeof Poly9 == 'undefined') {
    var Poly9 = {};
}
Poly9.URLParser = function(url) {

    this._fields = {
        'Username': 4,
        'Password': 5,
        'Port': 7,
        'Protocol': 2,
        'Host': 6,
        'Pathname': 8,
        'URL': 0,
        'Querystring': 9,
        'Fragment': 10
    };

    this._values = {};
    this._regex = null;
    this.version = 0.1;
    this._regex = /^((\w+):\/\/)?((\w+):?(\w+)?@)?([^\/\?:]+):?(\d+)?(\/?[^\?#]+)?\??([^#]+)?#?(\w*)/;
    for (var f in this._fields) {
        this['get' + f] = this._makeGetter(f);
    }

    if (typeof url != 'undefined') {
        this._parse(url);
    }
}
Poly9.URLParser.prototype.setURL = function(url) {
    this._parse(url);
}

Poly9.URLParser.prototype._initValues = function() {
    for (var f in this._fields) {
        this._values[f] = '';
    }
}

Poly9.URLParser.prototype._parse = function(url) {
    this._initValues();
    var r = this._regex.exec(url);
    if (!r) throw "DPURLParser::_parse -> Invalid URL";

    for (var f in this._fields) if (typeof r[this._fields[f]] != 'undefined') {
        this._values[f] = r[this._fields[f]];
    }
}
Poly9.URLParser.prototype._makeGetter = function(field) {
    return function() {
        return this._values[field];
    }
}  

function setCurrentNavigator() {
    var url = window.location.href;
    ///http:([a-zA-Z0-9\.-]+)\/(.+)/g.test(url);

    var p = new Poly9.URLParser(url);

    var lastHalf = p.getPathname();
    var navifators = $('.navigator li a');

    if (lastHalf.startWith('/channel/shopping')) {
        $(navifators[1]).addClass('shoppinghover');
    }
    if (lastHalf.startWith('/solution/home.aspx')) {
        $(navifators[2]).addClass('solutionhover');
    }
    if (lastHalf.startWith('/channel/brand')) {
        $(navifators[3]).addClass('brandshover');
    }
    if (lastHalf.startWith('/channel/info')) {
        $(navifators[4]).addClass('informationhover');
    }
    if (lastHalf.startWith('/channel/magic')) {
        $(navifators[5]).addClass('magichover');
    }
}

