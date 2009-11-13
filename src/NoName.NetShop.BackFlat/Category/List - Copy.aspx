<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="NoName.NetShop.BackFlat.Category.List" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="float:left;" runat="server" id="CategotyLevel1">
        <asp:ListBox ID="ListBox1" AutoPostBack="true" runat="server" Height="240px" Width="260px" onselectedindexchanged="ListBox1_SelectedIndexChanged"></asp:ListBox>
        <asp:LinkButton runat="server" ID="Button1MoveUp" Text="上移" onclick="Button1MoveUp_Click" />
        <asp:LinkButton runat="server" ID="Button1MoveDown" Text="下移" onclick="Button1MoveDown_Click" />
        <asp:LinkButton runat="server" ID="Button1Edit" Text="编辑" onclick="Button1Edit_Click" />
    </div>
    <div style="float:left;" runat="server" id="CategotyLevel2" visible="false">
        <asp:ListBox ID="ListBox2" AutoPostBack="true" runat="server"  Height="240px" Width="260px" onselectedindexchanged="ListBox2_SelectedIndexChanged"></asp:ListBox>
        <asp:LinkButton runat="server" ID="Button2MoveUp" Text="上移" onclick="Button2MoveUp_Click" />
        <asp:LinkButton runat="server" ID="Button2MoveDown" Text="下移" onclick="Button2MoveDown_Click" />
        <asp:LinkButton runat="server" ID="Button2Edit" Text="编辑" onclick="Button2Edit_Click" />
    </div>
    <div style="float:left;" runat="server" id="CategotyLevel3" visible="false">
        <asp:ListBox ID="ListBox3" runat="server" Height="240px" Width="260px"></asp:ListBox>
        <asp:LinkButton runat="server" ID="Button3MoveUp" Text="上移" onclick="Button3MoveUp_Click" />
        <asp:LinkButton runat="server" ID="Button3MoveDown" Text="下移" onclick="Button3MoveDown_Click" />
        <asp:LinkButton runat="server" ID="Button3Edit" Text="编辑" onclick="Button3Edit_Click" />
    </div>
    </form>
</body>
</html>
