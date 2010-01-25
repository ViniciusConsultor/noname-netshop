$(function() {
    /* initialize */
    var initialTable = getListUrlParameter();

    for (var i = 0; i < initialTable.Count; i++) {
        var prop = initialTable.Keys()[i];
        var propValue = initialTable.GetValue(prop);


        $('.properity[propid=' + prop + ']').children('a[propvid=' + propValue + ']').attr('class', 'on');
    }
    /* initialize end */

    $('.properity a').click(function() {
        var propID = parseInt($(this).parent().children('a[propid]').attr('propid'));
        var propValueID = parseInt($(this).attr('propvid'));

        var parmList = getListUrlParameter();
        parmList.Add(propID, propValueID);
        setListUrlParameter(parmList);


        $('.properity a').each(function() { $(this).removeAttr('class'); });
        $(this).attr('class', 'on');
    });

    function getListUrlParameter() {
        //debugger;
        var url = window.location.href;
        var parameterTable = new Hashtable();

        if (url.indexOf('v') > 0) {
            var parmPart = url.split('v')[1].split('e')[0];

            if (parmPart.indexOf(',') < 0)
                parameterTable.Add(parmPart.split('-')[0], parmPart.split('-')[1]);
            else
                for (var pv in parmPart.split(',')) {
                parameterTable.Add(pv.split('-')[0], pv.split('-')[1]);
            }
        }

        return parameterTable;
    }
    function setListUrlParameter(parameterTable) {
        //debugger;

        var url = window.location.href;
        var parmPart = '';

        for (var i = 0; i < parameterTable.Count; i++) {
            var prop = parameterTable.Keys()[i];
            var propValue = parameterTable.GetValue(prop);

            parmPart += prop + '-' + propValue + ',';
        }

        if (parmPart != '') {
            parmPart = 'v' + parmPart.substring(0, parmPart.lastIndexOf(',')) + 'e';

            if (url.indexOf('v') > 0) {
                url = url.split('v')[0] + parmPart + url.split('e')[1];
            }
            else {
                url = url.split('.')[0] + '-' + parmPart + '.' + url.split('.')[1];
            }
        }

        window.location = url;
    }
});