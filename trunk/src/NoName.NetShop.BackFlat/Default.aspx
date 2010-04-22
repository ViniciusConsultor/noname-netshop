<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NoName.NetShop.BackFlat.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
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
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <link rel="stylesheet" type="text/css" href="/css/style.css" />
</head>
<body>
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
        <div class="header" id="currentPostion"></div>
        <div class="main">
            <iframe id="mainPage" name="mainPage" width="100%" src="Welcome.aspx" scrolling="auto" frameborder="0" onload="resetIframeSize()"></iframe>
        </div>
    </div>
    </form>
</body>
</html>
