<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RentApply.aspx.cs" MasterPageFile="~/Site.Master" Inherits="NoName.NetShop.ForeFlat.Magic.RentApply" %>


<asp:Content ID="ContentHeader" ContentPlaceHolderID="head" runat="server">
    <link type="text/css" rel="stylesheet" href="/css/magic.css" />
</asp:Content>

<asp:Content ID="ContentBody" ContentPlaceHolderID="cpMain" runat="server">
    <asp:Literal runat="server" ID="Literal_Message" />
    <table>
        <tr>
            <td>租赁时间：</td>
            <td><asp:DropDownList runat="server" ID="DropDown_RentTime"></asp:DropDownList>月</td>
        </tr>
        <tr>
            <td>申请信息：</td>
            <td><asp:TextBox runat="server" ID="TextBox_RentInfo" TextMode="MultiLine" Width="400" Height="200"></asp:TextBox></td>
        </tr>
    </table>
    <asp:Button runat="server" ID="Button_Add" Text="确认" OnClick="Button_Add_Click" />
</asp:Content>