<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List.aspx.cs" MasterPageFile="~/Site.Master" Inherits="NoName.NetShop.ForeFlat.Brand.List" %>
<%@ Register Assembly="NoName.Utility" Namespace="NoName.Utility" TagPrefix="cc1" %>

<asp:Content runat="server" ID="ContentHeader" ContentPlaceHolderID="head">
    <link type="text/css" rel="stylesheet" href="/css/brands.css" />
</asp:Content>

<asp:Content runat="server" ID="ContentBody" ContentPlaceHolderID="cpMain">
    
    <!--Position Begin-->
    <div class="currentPosition">
    	您现在的位置: <a href="/">首页</a> &gt;&gt; <a href="/channel/brand">品牌商城</a> &gt;&gt; <a href="#">影像电器品牌区</a>
    </div>
    <!--Position End-->
    
    <!--MainBody Begin-->
    <div class="brandsMore_mainbody newline clearfix">
        <div class="box1">
            <ul class="title">
                <li class="left"></li>
                <li><span><asp:Literal runat="server" ID="Literal_CateName" /></span></li>
                <li class="right"></li>
            </ul>
            <div class="content">
                <div id="productList" class="list_horizontal">
                    <ul>
                        <asp:Repeater runat="server" ID="Repeater_Brand">
                            <ItemTemplate>
                                <li>
                                    <a href="/brand-<%# Eval("brandid") %>.html" title='<%# Eval("brandname") %>' target="_blank">
                                        <img src='<%# Eval("brandlogo") %>' style="width:180px;height:45px;"/>
                                        <span class="name" title='<%# Eval("brandname") %>'><%# Eval("brandname") %></span>
                                    </a>
                                </li>                            
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                    <div class="paginationContainer">
                        <cc1:AspNetPager CssClass="pagerclass" ID="AspNetPager" runat="server" PageSize="16"
                            UrlPageIndexName="" AlwaysShow="false" ImagePath="/" FirstPageText='首页'
                            LastPageText='末页' NextPageText='下一页' OnPageChanged="AspNetPager_PageChanged"
                            PrevPageText='上一页' NumericButtonCount="8"
                            ShowPrevNext="True" ShowPageIndex="true"
                            NumericButtonTextFormatString=''>
                        </cc1:AspNetPager>
                    </div>
                </div>
            </div>
            <ul class="bottom">
               <li class="left"></li>
               <li class="right"></li>
            </ul>
        </div>
        
    </div>
    <!--MainBody End-->
</asp:Content>