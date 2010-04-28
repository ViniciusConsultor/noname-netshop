<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="DealList.aspx.cs" Inherits="NoName.NetShop.ForeFlat.Magic.DealList" %>
<%@ Register Assembly="NoName.Utility" Namespace="NoName.Utility" TagPrefix="cc1" %>

<asp:Content ID="ContentHeader" ContentPlaceHolderID="head" runat="server">
    <link type="text/css" rel="stylesheet" href="/css/magic.css" />
    <script src="../js/magicworld.auction.js" type="text/javascript"></script>
</asp:Content>


<asp:Content ID="ContentBody" ContentPlaceHolderID="cpMain" runat="server">
    
    <!--Position Begin-->
    <div class="currentPosition">
    	您现在的位置: <a href="/">首页</a> &gt;&gt; <a href="/channel/magic">魔力世界</a> &gt;&gt; <a href="/Magic/DealHome.aspx">二手交易</a> &gt;&gt; <a href="#">所有交易</a>
        <div class="magicSubNav">
            <div class="magicButtonTab">
                <a class="button_blue" href="/Magic/RentHome.aspx">视听租赁</a>
                <a class="button_blue2" href="/Magic/DealHome.aspx">二手交易</a>
                <a class="button_blue" href="/Magic/PawnShop.aspx">视听当铺</a>
                <a class="button_blue" href="/Magic/AuctionHome.aspx">视听拍卖</a>
            </div>
        </div>
    </div>
    <!--Position End-->
    
    <!--MainBody Begin-->
    <div class="magicDealDailyUpdate_mainbody clearfix newline">
    	<div class="column">
            <div class="box1">
                <ul class="title">
                    <li class="left"></li>
                    <li><span>出售信息</span></li>
                    <li class="right"></li>
                </ul>
                <div class="content">
                    <ul class="articleList_3 bullet_2">
                        <asp:Repeater runat="server" ID="Repeater_Sale">
                            <ItemTemplate>
                                <li>
                                    <a href='<%# "Secondhand.aspx?pid="+Eval("seproductid") %>'><%# Eval("seproductname") %></a>
                                    <span><%# Convert.ToDateTime(Eval("inserttime")).ToString("MM-dd") %></span>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                    <div class="paginationParent">
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
                    <div class="submitButton">
                    	<a class="button_blue3" href="/member/CateSelect.aspx?app=Secondhand">
                            <span class="left"></span>
                            <span class="text">发布出售信息</span>
                            <span class="right"></span>
                        </a>
                    </div>
                </div>
                <ul class="bottom">
                   <li class="left"></li>
                   <li class="right"></li>
                </ul>
            </div>
        </div>
        <div class="column newblock">
            <div class="box1">
                <ul class="title">
                    <li class="left"></li>
                    <li><span>求购信息</span></li>
                    <li class="right"></li>
                </ul>
                <div class="content">
                    <ul class="articleList_3 bullet_2">
                        <asp:Repeater runat="server" ID="Repeater_Demand">
                            <ItemTemplate>
                                <li>
                                    <a href='<%# "demand.aspx?pid="+Eval("demandid") %>'><%# Eval("demandname") %></a>
                                    <span><%# Convert.ToDateTime(Eval("inserttime")).ToString("MM-dd") %></span>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                    <div class="paginationParent">
                        <div class="pagination">
                            <cc1:AspNetPager CssClass="pagerclass" ID="AspNetPager_Demand" runat="server" PageSize="12"
                                UrlPageIndexName="" AlwaysShow="true" ImagePath="/" FirstPageText='首页'
                                LastPageText='末页' NextPageText='下一页' OnPageChanged="AspNetPager_Demand_PageChanged"
                                PrevPageText='上一页' ShowBoxThreshold="16" NumericButtonCount="8"
                                ShowPrevNext="True" SubmitButtonClass="buttom" 
                                NumericButtonTextFormatString=''>
                            </cc1:AspNetPager>
                            <!--
                            <a class="prev" href="#"></a>
                            <div class="pageNum">
                                <a class="on" href="#">1</a>
                                <a href="#">2</a>
                                <a href="#">3</a>
                                <a href="#">4</a>
                                <a href="#">5</a>
                                <a href="#">6</a>
                                <a href="#">7</a>
                            </div>
                            <a class="next" href="#"></a>
                            <div class="jumpTo">
                                <span>跳转到</span><input type="text" value="1" /><span>页</span>
                            </div>
                            -->
                        </div>
                    </div>
                    <div class="submitButton">
                    	<a class="button_blue3" href="/member/CateSelect.aspx?app=Demand">
                            <span class="left"></span>
                            <span class="text">发布求购信息</span>
                            <span class="right"></span>
                        </a>
                    </div>
                </div>
                <ul class="bottom">
                   <li class="left"></li>
                   <li class="right"></li>
                </ul>
            </div>
        </div> 
    </div>
    <!--MainBody End-->
</asp:Content>