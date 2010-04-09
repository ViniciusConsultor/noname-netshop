<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MagicWorldCategorySelect.ascx.cs" Inherits="NoName.NetShop.ForeFlat.Controls.MagicWorldCategorySelect" %>
<table class="category-selection">
    <tr>
        <th colspan="3"><h3>请选择分类：</h3></th>
    </tr>
    <tr>
        <td>
            <asp:ListBox AutoPostBack="true" Visible="false" runat="server" ID="ListBox1" OnSelectedIndexChanged="ListBox1_SelectChanged"></asp:ListBox>
        </td>
        <td>
            <asp:ListBox AutoPostBack="true" Visible="false" runat="server" ID="ListBox2" OnSelectedIndexChanged="ListBox2_SelectChanged"></asp:ListBox>
        </td>
        <td>
            <asp:ListBox AutoPostBack="true" Visible="false" runat="server" ID="ListBox3" OnSelectedIndexChanged="ListBox3_SelectChanged"></asp:ListBox>
        </td>
    </tr>
</table>