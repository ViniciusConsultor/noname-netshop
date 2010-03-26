$(function() {
    /* initialize */
    //order
    var orderType = getOrder();
    $('.sort a').removeAttr('class');
    if (orderType == 1) {
        $('.sort a[field="changetime"]').attr('class', 'on').attr('type', 1);
    }
    else if (orderType == 2) {
        $('.sort a[field="changetime"]').attr('class', 'on').attr('type', 0);
    }
    else if (orderType == 3) {
        $('.sort a[field="sales"]').attr('class', 'on').attr('type', 1);
    }
    else if (orderType == 4) {
        $('.sort a[field="sales"]').attr('class', 'on').attr('type', 0);
    }
    else if (orderType == 5) {
        $('.sort a[field="price"]').attr('class', 'on').attr('type', 1);
    }
    else if (orderType == 6) {
        $('.sort a[field="price"]').attr('class', 'on').attr('type', 0);
    }
    else if (orderType == 7) {
        $('.sort a[field="hit"]').attr('class', 'on').attr('type', 1);
    }
    else if (orderType == 8) {
        $('.sort a[field="hit"]').attr('class', 'on').attr('type', 0);
    }
    else {
        $('.sort a[field="changetime"]').attr('class', 'on').attr('type', 1);
    }

    //properity
    var initialTable = getListUrlParameter();
    //alert(initialTable.Count);
    for (var i = 0; i < initialTable.Count; i++) {
        var prop = initialTable.Keys()[i];
        var propValue = initialTable.GetValue(prop);
        $('.properity[propid=' + prop + ']').children('a[propvid=' + propValue + ']').attr('class', 'on');
    }

    //page



    /* initialize end */


    //排序事件
    $('.sort a').click(function() {
        $('.sort a').removeAttr('class');
        $(this).attr('class', 'on');
        var field = $(this).attr('field');
        var type = $(this).attr('type');

        var sortValue = 0;

        if (field == 'changetime')
            sortValue = parseInt(type) == 0 ? 1 : 2;
        else if (field == 'sales')
            sortValue = parseInt(type) == 0 ? 3 : 4;
        else if (field == 'price')
            sortValue = parseInt(type) == 0 ? 5 : 6;
        else if (field == 'hit')
            sortValue = parseInt(type) == 0 ? 7 : 8;
        else
            sortValue = 1;

        //alert(sortValue);

        setOrder(sortValue);
    });

    //属性事件
    $('.properity a').click(function() {
        debugger;
        var propID = parseInt($(this).parent().children('a[propid]').attr('propid'));
        var propValueID = parseInt($(this).attr('propvid'));

        var parmList = getListUrlParameter();
        parmList.Add(propID, propValueID);
        setListUrlParameter(parmList);


        //$('.properity a').each(function() { $(this).removeAttr('class'); });
        $(this).attr('class', 'on');
    });

    //翻页事件
    $('.pagination a[type="page"]').click(function() {
        if ($(this).attr('class') == 'prev') {
            var page = getPage();
            page = page - 1;
            setPage(page);
        }
        else if ($(this).attr('class') == 'next') {
            var page = getPage();
            page = page + 1;
            setPage(page);
        }
        else {
            var page = $(this).attr('page');
            setPage(page);
        }
    });



    function getPage() {
        var url = window.location.href;
        /(.+)(\/list[-_]+\d+)([-_]+\d+)?([-_]+o\d+)?([-_]+v.+e)?(.+)/g.test(url);

        if (RegExp.$3 == '') return 1;
        else return parseInt(RegExp.$3.replace('-', ''));
    }
    function setPage(page) {
        var url = window.location.href;
        /(.+)(\/list[-_]+\d+)([-_]+\d+)?([-_]+o\d+)?([-_]+v.+e)?(.+)/g.test(url);

        var pageString = '-' + page;
        url = RegExp.$1 + RegExp.$2 + pageString + RegExp.$5 + RegExp.$6;
        window.location.href = url;
    }

    function getOrder() {
        var url = window.location.href;
        /(.+)(\/list[-_]+\d+)([-_]+\d+)?([-_]+o\d+)?([-_]+v.+e)?(.+)/g.test(url);

        if (RegExp.$4 == '') return 1;
        else return parseInt(RegExp.$4.replace('-o', ''));
    }
    function setOrder(order) {
        var url = window.location.href;
        /(.+)(\/list[-_]+\d+)([-_]+\d+)?([-_]+o\d+)?([-_]+v.+e)?(.+)/g.test(url);

        //alert('1:' + RegExp.$1 + '\n2:' + RegExp.$2 + '\n3:' + RegExp.$3 + '\n4:' + RegExp.$4 + '\n5:' + RegExp.$5 + '\n6:' + RegExp.$6);
        //1 : url prefix
        //2 : /list-117 (category)
        //3 : -1 (page)
        //4 : -o1 (order)
        //5 : -v178-2,168-1e
        //6 : .list
        //url = RegExp.$1 + RegExp.$2 + RegExp.$4 + RegExp.$5 + RegExp.$6;

        var orderString = order == 1 ? '' : '-o' + order;
        url = RegExp.$1 + RegExp.$2 + orderString + RegExp.$5 + RegExp.$6;
        window.location.href = url;
    }

    function getListUrlParameter() {
        var url = window.location.href;

        var parameterTable = new Hashtable();

        if (url.indexOf('v') > 0 && url.indexOf('e') > 0) {
            var parmPart = url.split('v')[1].split('e')[0];

            if (parmPart.indexOf(',') < 0)
                parameterTable.Add(parmPart.split('-')[0], parmPart.split('-')[1]);
            else {
                var parmArray = parmPart.split(',');
                for (var i = 0; i < parmArray.length; i++) {
                    parameterTable.Add(parmArray[i].split('-')[0], parmArray[i].split('-')[1]);
                }
            }
        }

        return parameterTable;
    }
    function setListUrlParameter(parameterTable) {
        var url = window.location.href;
        /(.+)(\/list[-_]+\d+)([-_]+\d+)?([-_]+o\d+)?([-_]+v.+e)?(.+)/g.test(url);

        var parmPart = '';
        if (parameterTable.Count == 1) {
            var prop = parameterTable.Keys()[0];
            var propValue = parameterTable.GetValue(prop);

            if (parseInt(propValue) != -1)
                parmPart += prop + '-' + propValue + ',';
        }
        else {
            for (var i = 0; i < parameterTable.Count; i++) {
                var prop = parameterTable.Keys()[i];
                var propValue = parameterTable.GetValue(prop);

                if (parseInt(propValue) != -1)
                    parmPart += prop + '-' + propValue + ',';
            }
        }

        if (parmPart != '') {
            parmPart = '-v' + parmPart.substring(0, parmPart.lastIndexOf(',')) + 'e';
        }

        url = RegExp.$1 + RegExp.$2 + RegExp.$4 + parmPart + RegExp.$6;

        window.location = url;
    }
});