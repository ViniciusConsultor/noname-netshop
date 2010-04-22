var VoteInfo = function() {}
VoteInfo.prototype.Show = function(container, voteId) {
    $.ajax({
        type: "POST",
        url: "/api/CartOpenApi.ashx",
        data: "action=getvote&voteid=" + voteId,
        dataType: "json",
        success: function(data) {
            if (data) {
                var seltype = data.ismulti ? "checkbox" : "radio";
                $(container).empty();
                $(container).append("<div class='topic'><input type='hidden' name='voteId' value='" + voteId + "' />" + data.topic + "</div>");
                for (var i = 0; i < data.groups.length; i++) {
                    var group = data.groups[i];
                    var appstr = "<div class='topic'>" + group.subject + "</div>";
                    appstr += "<ul class='options'>";
                    for (var j = 0; j < group.items.length; j++) {
                        var item = group.items[j];
                        appstr += "<li><input type='" + seltype + "' name='gid" + group.groupid + "' value='" + item.itemid + "'><span>" + item.subject + "</span></li>";
                    }
                    appstr += "</ul>";
                    $(container).append(appstr);
                }
            }
        }
    });
}