$(function() {
    var scenceid = $.query.get('scenceid');
    if (scenceid != '') {
        selectSuite($('#suiteList a')[scenceid], scenceid);
    }

});