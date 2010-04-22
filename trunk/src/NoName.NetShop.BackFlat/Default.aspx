<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NoName.NetShop.BackFlat.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <link href="/css/css.css" type="text/css" rel="stylesheet" />
    <link href="/css/style.css" type="text/css" rel="stylesheet" />
    <link href="/css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript" src="/js/jquery.js"></script>
    <script type="text/javascript" src="/js/jquery.timers.js"></script>
    <script type="text/javascript" src="/js/jquery-ui-1.7.2.custom.min.js"></script>
    <script type="text/javascript" src="/js/date.js"></script>
    <script type="text/javascript">
        var Ka = navigator.userAgent.toLowerCase();
        var isOpera = Ka.indexOf("opera") != -1;
        var isIE = Ka.indexOf("msie") != -1 && (document.all && !isOpera);
        function clickGroup(obj) {
            obj.blur();
            var optionsNode = obj.parentNode.getElementsByTagName("ul")[0];
            if (optionsNode.style.display !== "none") {
                optionsNode.style.display = "none";
            } else {
                optionsNode.style.display = "block";
            }
        }

        if (isIE) {
            window.attachEvent("onresize", resetIframeSize);
        } else {
            window.addEventListener("resize", resetIframeSize, false);
        }

        function resetIframeSize() {
            document.getElementById("mainPage").height = document.getElementById("sidebar").clientHeight - 35;
        }

    </script>
</head>
<body>
    <div id="dialog" title="站内信" style="display:none">
	    <p>
	    </p>
    </div>
    <script language="javascript" type="text/javascript">
        function switchbar() {
            if (switchPoint.innerText == 3) {
                switchPoint.innerText = 4
                document.all("frm").style.display = "none"
            } else {
                switchPoint.innerText = 3
                document.all("frm").style.display = ""
            }
        }

        $(document).everyTime(5000, 'controlled', function() {
            $.getJSON("/commapi/ImMessage.ashx", { "action": "getmsglist", "rand": Math.floor(Math.random() * 1000) }, function(json) {
                if (json != null) {
                    $("#msgs").empty();
                    $(json).each(function(index, message) {
                        // $("#msgs").append("<a href='/message/ShowMessage.aspx?msgid=" + message.msgid + "' target='mainFrame'>" + message.subject + "</a>&nbsp;");
                        $("#msgs").append("<a onclick='return showMessage(" + message.msgid + ")'>" + message.subject + "</a>&nbsp;");
                    });
                }
            });
        });

        $.ui.dialog.defaults.bgiframe = true;

        function showMessage(msgId) {
            $.ajax({
                type: "POST",
                url: "/commapi/ImMessage.ashx",
                data: "action=getmessage&msgId=" + msgId,
                dataType: "json",
                success: function(data) {
                    if (data) {
                        var msg = "<div>" + data.Subject + "（发送时间：" + parseDate(data.InsertTime) + "）</div>";
                        msg += "<div>" + data.Content + "</div>";
                        $("#dialog").find("p").html(msg);
                        $("#dialog").dialog({ autoOpen: false }).dialog("open");
                    }
                }
            });
            return true;
        }

        function parseDate(inputstr) {
            var reg = /\\d+/
            reg.exec(inputstr);
            var td = new Date(RegExp.$1);
            return td;
        }      
    </script>
    <form id="form1" runat="server">
    <div class="left" id="sidebar">
        <div class="header">
            <div class="links">
                <a href="#">管理首页</a> | 
                <asp:LinkButton runat="server" ID="Button_LogOut" Text="退出管理" OnClick="Button_LogOut_Click" />
            </div>
        </div>
        <%=menu%>
    </div>
    <div class="right">
        <div class="header" id="currentPostion">
                                <span style="float: left;">系统公告：</span>
                                <marquee direction="left" id="msgs" onmouseover="this.stop()" onmouseout="this.start()" >滚动信息</marquee>
        </div>
        <div class="main">
            <iframe id="mainPage" name="mainPage" width="100%" src="Welcome.aspx" scrolling="auto" frameborder="0" onload="resetIframeSize()"></iframe>
        </div>
    </div>
    </form>
</body>
</html>
