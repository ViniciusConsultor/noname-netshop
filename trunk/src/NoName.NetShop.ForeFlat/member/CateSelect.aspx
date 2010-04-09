<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CateSelect.aspx.cs" MasterPageFile="~/MemberCenter.master" Inherits="NoName.NetShop.ForeFlat.member.CateSelect" %>
<%@ Register src="../Controls/MagicWorldCategorySelect.ascx" tagname="MagicWorldCategorySelect" tagprefix="uc1" %>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="headerContent">
    <style type="text/css">
    .category-selection{width:90%;}
    .category-selection th{height:40px;}
    .category-selection h3{height:40px;padding-top:10px;margin:0;}
    .category-selection select{width:200px;height:400px;border:none;}
    </style>
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="rightContent" runat="server">
        <uc1:MagicWorldCategorySelect ID="MagicWorldCategorySelect1" runat="server" />
        <asp:Button runat="server" CssClass="category-select" ID="Button_OK" OnClick="Button_OK_Click" Text="确  定" />
</asp:Content>