<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CacheReset.aspx.cs" Inherits="NoName.NetShop.BackFlat.Admin.CacheReset" %>

<!DOCTYPE html PUBLIC "-//W3C//Dtd XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/Dtd/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>无标题页</title>
<link href="/css/css.css" type="text/css" rel="stylesheet" />
<link href="/css/style.css" type="text/css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:Label ID="lblResult" runat=server></asp:Label>
    <br />
    <asp:Button ID="btnResetMenuCache" Text="重置菜单缓存" runat=server OnClick="btnResetMenuCache_Click" />
        <asp:Button ID="btnResetApp" runat="server" OnClick="btnResetApp_Click" Text="重新启动web应用程序" /><br />
    <asp:Label ID="lblHttpCache" runat=server></asp:Label>
    <br />
    <asp:Button ID="btnResetHttpCache" Text="重置HTTP缓存" runat=server OnClick="btnResetHttpCache_Click" />
        <br />
    </div>
    </form>
</body>
</html>
