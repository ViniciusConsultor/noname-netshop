$(function() {
    $('.pagination a[page]').click(function() {
        //alert($(this).attr('page'));
        var parm = getUrlParameter();
        parm.Add('p', $(this).attr('page'));
        setUrlParameter(parm);
    });
});



