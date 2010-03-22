<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NoName.NetShop.BackFlat._Default" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>鼎鼎网店管理系统</title>
    <link href="/css/css.css" type="text/css" rel="stylesheet" />
    <link href="/css/style.css" type="text/css" rel="stylesheet" />

    <script src="js/jquery.js" type="text/javascript"></script>

    <script type="text/javascript" src="/js/jquery.timers.js"></script>
<link href="css/themes/base/ui.all.css" rel="stylesheet" type="text/css" />
<script src="js/jquery-ui-1.7.2.custom.min.js" type="text/javascript"></script>

</head>
<body style="margin: 0 0 0 0">
<div id="dialog" title="站内信" style="display:none">
	<p>
	</p>
</div>
    <script language="javascript" type="text/javascript">
function switchbar(){
if (switchPoint.innerText==3){
switchPoint.innerText=4
document.all("frm").style.display="none"
}else{
switchPoint.innerText=3
document.all("frm").style.display=""
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
                var msg = "<div>" + data.Subject + "（发送时间：" + data.InsertTime + "）</div>";
                msg += "<div>" + data.Content + "</div>";
                $("#dialog").find("p").html(msg);
                $("#dialog").dialog({ autoOpen: false }).dialog("open");
            }
        }
    });
    return true;
}         
    </script>

    <table style="height: 100%" cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
            <td id="frm" style="height: 443px;">
                <iframe style="z-index: 2; width: 200px; height: 100%" name="rijcm" src="left.aspx"
                    frameborder="0"></iframe>
            </td>
            <td width="10" style="height: 443px; background-color: #4397c5">
                <table height="100%" cellspacing="0" cellpadding="0" border="0">
                    <tbody>
                        <tr>
                            <td style="height: 100%" onclick="switchbar()">
                                <font style="font-size: 9pt; cursor: hand; color: white; font-family: Webdings"><span
                                    id="switchPoint">3</span> </font>
                        </tr>
                    </tbody>
                </table>
            </td>
            <td width="100%" style="height: 443px">
                <div>
                    <table width="99%" align="center" cellpadding="3" cellspacing="0" border="0">
                        <tr class="head">
                            <td height="25">
                                <span style="float: left;">系统公告：</span>
                                <marquee direction="left" id="msgs" onmouseover="this.stop()" onmouseout="this.start()" >滚动信息</marquee>
                            </td>
                            <td style="width: 200px; text-align: right">

                                <script type="text/javascript">
                                    var d = new Date();
                                    document.write("今天是：" + d.getYear() + "年" + (d.getMonth() + 1) + "月" + d.getDate() + "日");
                                </script>

                            </td>
                        </tr>
                    </table>
                </div>
                <iframe id="mainFrame" style="z-index: 1; width: 100%; height: 96%" name="mainFrame"
                    src="Welcome.aspx" frameborder="0" scrolling="yes"></iframe>
            </td>
        </tr>
    </table>
</body>
</html>
