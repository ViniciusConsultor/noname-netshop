<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="NoName.NetShop.BackFlat.Category.List" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="float:left;">
        <asp:ListBox ID="ListBox1" AutoPostBack="true" runat="server" Height="240px" Width="260px" onselectedindexchanged="ListBox1_SelectedIndexChanged"></asp:ListBox>
        <asp:Button runat="server" ID="Button1MoveUp" Text="上移" onclick="Button1MoveUp_Click" />
        <asp:Button runat="server" ID="Button1MoveDown" Text="下移" onclick="Button1MoveDown_Click" />
    </div>
    <div style="float:left;">
        <asp:ListBox ID="ListBox2" AutoPostBack="true" Visible="false" runat="server"  Height="240px" Width="260px" onselectedindexchanged="ListBox2_SelectedIndexChanged"></asp:ListBox>
        <asp:Button runat="server" ID="Button2MoveUp" Text="上移" onclick="Button2MoveUp_Click" />
        <asp:Button runat="server" ID="Button2MoveDown" Text="下移" onclick="Button2MoveDown_Click" />
    </div>
    <div style="float:left;">
        <asp:ListBox ID="ListBox3" Visible="false" runat="server" Height="240px" Width="260px"></asp:ListBox>
        <asp:Button runat="server" ID="Button3MoveUp" Text="上移" onclick="Button3MoveUp_Click" />
        <asp:Button runat="server" ID="Button3MoveDown" Text="下移" onclick="Button3MoveDown_Click" />
    </div>
    </form>
</body>
</html>
