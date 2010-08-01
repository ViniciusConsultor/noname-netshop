<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PawnList.aspx.cs" MasterPageFile="~/Site.Master" Inherits="NoName.NetShop.ForeFlat.Magic.PawnList" %>
<%@ Register Assembly="NoName.Utility" Namespace="NoName.Utility" TagPrefix="cc1" %>

<asp:Content ID="ContentHeader" ContentPlaceHolderID="head" runat="server">
    <link type="text/css" rel="stylesheet" href="/css/magic.css" />
</asp:Content>

<asp:Content ID="ContentBody" ContentPlaceHolderID="cpMain" runat="server">
    
    <!--Position Begin-->
    <div class="currentPosition">
    	您现在的位置: <a href="/">首页</a> &gt;&gt; <a href="/channel/magic">魔力世界</a> &gt;&gt; <a href="/Magic/PawnShop.aspx">视听当铺</a> &gt;&gt; <a href="#">典当品列表</a>
        <div class="magicSubNav">
            <div class="magicButtonTab">
                <a class="button_blue" href="/Magic/RentHome.aspx">视听租赁</a>
                <a class="button_blue" href="/Magic/DealList.aspx">二手交易</a>
                <a class="button_blue2" href="/Magic/PawnShop.aspx">视听当铺</a>
                <a class="button_blue" href="/Magic/AuctionHome.aspx">视听拍卖</a>
            </div>
        </div>
    </div>
    <!--Position End-->
    
    <!--MainBody Begin-->
    <div class="magicPawnShopList_mainbody clearfix newline">
        <div class="box1">
            <ul class="title">
                <li class="left"></li>
                <li><span>全部典当品</span></li>
                <li class="right"></li>
            </ul>
            <div class="content">
                <div class="list_horizontal">
                    <ul>
                        <asp:Repeater runat="server" ID="Repeater_PawnProduct">
                            <ItemTemplate>
                                <li>
                                    <a href='/Magic/PawnProduct.aspx?pid=<%# Eval("pawnproductid") %>' title='<%# Eval("pawnproductname") %>'>
                                        <img src='<%# Eval("mediumimage") %>' />
                                        <span class="price">价格：￥<%# Eval("sellingprice") %></span>
                                        <span class="name" title='<%# Eval("pawnproductname") %>'><%# Eval("pawnproductname") %></span>
                                    </a>
                                    <div class="actionsForInlineButton">
                                        <a class="button_blue3 inlineBlock" href='/Magic/PawnProduct.aspx?pid=<%# Eval("pawnproductid") %>'>
                                            <span class="left"></span>
                                            <span class="text">购买</span>
                                            <span class="right"></span>
                                        </a>
                                    </div>
                                </li>                                
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                    <div class="paginationContainer">
                        <div class="line"></div>
                        <div class="pagination">
                            <cc1:AspNetPager CssClass="pagerclass" ID="AspNetPager_Sales" runat="server" PageSize="12"
                                UrlPageIndexName="" AlwaysShow="true" ImagePath="/" FirstPageText='首页'
                                LastPageText='末页' NextPageText='下一页' OnPageChanged="AspNetPager_Sales_PageChanged"
                                PrevPageText='上一页' ShowBoxThreshold="16" NumericButtonCount="8"
                                ShowPrevNext="True" SubmitButtonClass="buttom" 
                                NumericButtonTextFormatString=''>
                            </cc1:AspNetPager>
                        </div>
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