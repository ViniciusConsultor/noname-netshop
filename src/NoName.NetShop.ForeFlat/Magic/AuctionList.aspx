<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AuctionList.aspx.cs" MasterPageFile="~/Site.Master" Inherits="NoName.NetShop.ForeFlat.Magic.AuctionList" %>
<%@ Register Assembly="NoName.Utility" Namespace="NoName.Utility" TagPrefix="cc1" %>

<asp:Content ID="ContentHeader" ContentPlaceHolderID="head" runat="server">
    <link type="text/css" rel="stylesheet" href="/css/magic.css" />
</asp:Content>

<asp:Content ID="ContentBody" ContentPlaceHolderID="cpMain" runat="server">
    <!--Position Begin-->
    <div class="currentPosition">
    	您现在的位置: <a href="/">首页</a> &gt;&gt; <a href="/channel/magic">魔力世界</a> &gt;&gt; <a href="/Magic/AuctionHome.aspx">视听拍卖</a> &gt;&gt; <a href="#">拍品列表</a>
        <div class="magicSubNav">
            <div class="magicButtonTab">
                <a class="button_blue" href="/Magic/RentHome.aspx">视听租赁</a>
                <a class="button_blue" href="/Magic/DealList.aspx">二手交易</a>
                <a class="button_blue" href="/Magic/PawnShop.aspx">视听当铺</a>
                <a class="button_blue2" href="/Magic/AuctionHome.aspx">视听拍卖</a>
            </div>
        </div>
    </div>
    <!--Position End-->
    
    <!--MainBody Begin-->
    <div class="magicAuctionList_mainbody clearfix newline">
                <div class="box1">
                    <ul class="title">
                        <li class="left"></li>
                        <li><span>新开价</span></li>
                        <li class="right"></li>
                    </ul>
                    <div class="content">
                    	<ul class="itemList4">
                            <asp:Repeater runat="server" ID="Repeater_ProductList">
                                <ItemTemplate>
                        	        <li>
                            	        <a href='Auction.aspx?pid=<%# Eval("auctionid") %>' target="_blank">
                                	        <img src='<%# Eval("mediumimage")  %>' />
                                        </a>
                                        <div class="infoContainer">
                                	        <ul class="info">
                                                <li>
                                                    <span class="field">商品名称:</span>
                                                    <span class="name"><a href='Auction.aspx?pid=<%# Eval("auctionid") %>' target="_blank"><%# Eval("productname") %></a></span>
                                                </li>
                                                <li>
                                                    <span class="field">起始价格:</span>
                                                    <span><%# Eval("startprice") %>元</span>
                                                    <span class="field">当前价格:</span>
                                                    <span><%# Eval("curprice") %>元</span>
                                                </li>
                                                <li>
                                                    <span class="field">起始时间:</span>
                                                    <span><%# Convert.ToDateTime(Eval("starttime")).ToString("yyyy年MM月dd日") %></span>
                                                    <span class="field">结束时间:</span>
                                                    <span><%# Convert.ToDateTime(Eval("endtime")).ToString("yyyy年MM月dd日") %></span>
                                                </li>
                                                <li>
                                        	        <span class="field">商品说明:</span>
                                                    <span class="description"><%# Eval("brief") %></span>
                                                </li>
                                            </ul>
                                        </div>
                                    </li>                                    
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                        <div class="paginationParent">
                            <div class="pagination">
                                <cc1:AspNetPager CssClass="pagerclass" ID="AspNetPager" runat="server" PageSize="12"
                                    UrlPageIndexName="" AlwaysShow="true" ImagePath="/" FirstPageText='首页'
                                    LastPageText='末页' NextPageText='下一页' OnPageChanged="AspNetPager_PageChanged"
                                    PrevPageText='上一页' ShowBoxThreshold="16" NumericButtonCount="8"
                                    ShowPrevNext="True" SubmitButtonClass="buttom" 
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