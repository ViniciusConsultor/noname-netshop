<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CategoryListBox.ascx.cs" Inherits="NoName.NetShop.BackFlat.Controls.CategoryListBox1" %>

<style type="text/css">
    table.pdcategory{width:700px;display:block;margin:1em;}
    .pdcategory select{width:200px;height:300px;background:white;}
</style>

<table class="pdcategory">    
    <tr>
        <td colspan="3"><h3>请选择分类：</h3></td>
    </tr>
    <tr>
        <td>
            <asp:ListBox AutoPostBack="true" Visible="false" runat="server" ID="ListBox1" OnSelectedIndexChanged="ListBox1_SelectChanged" />
        </td>
        <td>
            <asp:ListBox AutoPostBack="true" Visible="false" runat="server" ID="ListBox2" OnSelectedIndexChanged="ListBox2_SelectChanged" />
        </td>
        <td>
            <asp:ListBox AutoPostBack="true" Visible="false" runat="server" ID="ListBox3" OnSelectedIndexChanged="ListBox3_SelectChanged" />
        </td>
    </tr>
</table>