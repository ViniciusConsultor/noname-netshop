<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Left.aspx.cs" Inherits="NoName.NetShop.BackFlat.Left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>鼎鼎商城管理系统</title>
<link href="/css/css.css" type="text/css" rel="stylesheet" />
<link href="/css/style.css" type="text/css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
<div>
	<div class="head" style="text-align:center">鼎鼎商城管理系统</div>
	
<div style="border:double 3px #009999; margin:3px 3px 3px 3px;  ">
<div class="head"><B>登陆信息</B></div>
<ul>
<li>    <asp:LoginName ID="LoginName1" runat="server" FormatString="ID：{0}" />　    
    [<asp:LoginStatus ID="LoginStatus1" runat="server" OnLoggedOut="LoginStatus1_LoggedOut"  />]
</li>
<li><a target="mainFrame" href='/UserAdmin/UserInfo.aspx'>修改个人密码</a>

</li>
</ul>
</div>
<%=menu%>
</div>

    </form>
</body>
</html>
