﻿<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MemberCenter.master" CodeBehind="Add.aspx.cs" Inherits="NoName.NetShop.ForeFlat.member.Auction.Add" %>
<%@ Register Assembly="NoName.Utility" Namespace="NoName.Utility" TagPrefix="cc1" %>



<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="headerContent">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="rightContent" runat="server">
    <div>
        <asp:GridView runat="server" ID="GridView1">
        
        </asp:GridView>
    </div>
    <div>
        <cc1:AspNetPager CssClass="pagerclass" ID="AspNetPager" runat="server" PageSize="12"
            UrlPageIndexName="" AlwaysShow="true" ImagePath="/" FirstPageText='首页'
            LastPageText='末页' NextPageText='下一页'
            PrevPageText='上一页' ShowBoxThreshold="16" NumericButtonCount="8"
            ShowPrevNext="True" SubmitButtonClass="buttom" 
            NumericButtonTextFormatString=''>
        </cc1:AspNetPager>
    </div>
</asp:Content>