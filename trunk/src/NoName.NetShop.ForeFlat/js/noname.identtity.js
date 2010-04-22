var Identity = function() {}
Identity.prototype.Show = function(container) {
    $.get("/api/CartOpenApi.ashx", { action: "getindentity" }, function(data) {
        $(container).empty();
        if (data) {
            $(container).append("<li class='slogan'>" + data.userName + "您好，欢迎您来到鼎鼎商城！</li><li><a href='#'>帮助中心</a></li>");
        }
        else {
            $(container).append("<li><a href='/Login.aspx'>请登录</a></li><li><a href='/RegPerson.aspx'>免费注册</a></li><li><a href='#'>帮助中心</a></li>");
        }

    });
}
