<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MagicWorldCategorySelect.ascx.cs" Inherits="NoName.NetShop.ForeFlat.Controls.MagicWorldCategorySelect" %>
<table>
    <tr>
        <td colspan="3"><h3>请选择分类：</h3></td>
    </tr>
    <tr>
        <td>
            <asp:ListBox AutoPostBack="true" Visible="false" runat="server" ID="ListBox1"></asp:ListBox>
        </td>
        <td>
            <asp:ListBox AutoPostBack="true" Visible="false" runat="server" ID="ListBox2"></asp:ListBox>
        </td>
        <td>
            <asp:ListBox AutoPostBack="true" Visible="false" runat="server" ID="ListBox3"></asp:ListBox>
        </td>
    </tr>
</table>