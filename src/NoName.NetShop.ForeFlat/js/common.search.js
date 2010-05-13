$(function() {
    $('.pagination a[page]').click(function() {
        //alert($(this).attr('page'));
        var parm = getUrlParameter();
        parm.Add('p', $(this).attr('page'));
        setUrlParameter(parm);
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
    var parmString = '';

    for (var i = 0; i < p.Count; i++) {
        parmString += (i == 0 ? '' : '&') + p.Keys()[i] + '=' + p.GetValue(p.Keys()[i]);
    }

    if (index == -1)
        window.location = url + '?' + parmString
    else
        window.location = url.split("?")[0] + '?' + parmString;
}