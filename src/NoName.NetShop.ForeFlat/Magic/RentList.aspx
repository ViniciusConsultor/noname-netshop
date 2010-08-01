<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RentList.aspx.cs" MasterPageFile="~/Site.Master" Inherits="NoName.NetShop.ForeFlat.Magic.RentList" %>
<%@ Register Assembly="NoName.Utility" Namespace="NoName.Utility" TagPrefix="cc1" %>

<asp:Content ID="ContentHeader" ContentPlaceHolderID="head" runat="server">
    <link type="text/css" rel="stylesheet" href="/css/magic.css" />
</asp:Content>

<asp:Content ID="ContentBody" ContentPlaceHolderID="cpMain" runat="server">
    <!--Position Begin-->
    <div class="currentPosition">
    	您现在的位置: <a href="/">首页</a> &gt;&gt; <a href="/channel/magic">魔力世界</a> &gt;&gt; <a href="/Magic/RentHome.aspx">视听租赁</a> &gt;&gt; <a href="#">租赁中的商品</a>
        <div class="magicSubNav">
            <div class="magicButtonTab">
                <a class="button_blue2" href="/Magic/RentHome.aspx">视听租赁</a>
                <a class="button_blue" href="/Magic/DealList.aspx">二手交易</a>
                <a class="button_blue" href="/Magic/PawnShop.aspx">视听当铺</a>
                <a class="button_blue" href="/Magic/AuctionHome.aspx">视听拍卖</a>
            </div>
        </div>
    </div>
    <!--Position End-->
    
    <!--MainBody Begin-->
    <div class="magicRentList_mainbody clearfix newline">
		<div class="rightColumn">
            <div class="box2">
                <ul class="title">
                    <li class="left"></li>
                    <li><span>最新开租</span></li>
                    <li class="right"></li>
                </ul>
                <div class="content">
                    <ul class="itemList5">
                        <asp:Repeater runat="server" ID="Repeater_NewRents">
                            <ItemTemplate>
                                <li>
                                    <a href='<%# "Rent.aspx?pid="+Eval("rentid") %>'>
                                        <img src="<%# Eval("smallimage") %>" />
                                    </a>
                                    <div class="infoContainer">
                                        <ul class="info">
                                            <li>
                                                <span class="name"><a href='<%# "Rent.aspx?pid="+Eval("rentid") %>'><%# Eval("rentname") %></a></span>
                                            </li>
                                            <li>
                                                <span class="field">租金:</span>
                                                <span class="important"><%# Convert.ToDecimal(Eval("rentprice")).ToString("0.00") %>元</span>
                                            </li>
                                            <li>
                                                <span class="field">押金:</span>
                                                <span><%# Convert.ToDecimal(Eval("cashpledge")).ToString("0.00")%>元</span>
                                            </li>
                                        </ul>
                                    </div>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
                <ul class="bottom">
                   <li class="left"></li>
                   <li class="right"></li>
                </ul>
            </div>
            
        </div>
        <div class="mainColumn">
        	<div class="mainColumnContainer">
                <div class="box1">
                    <ul class="title">
                        <li class="left"></li>
                        <li><span>租赁中的商品</span></li>
                        <li class="right"></li>
                    </ul>
                    <div class="content">
                    	<div class="list_horizontal">
                            <ul>
                                <asp:Repeater runat="server" ID="Repeater_Rentings">
                                    <ItemTemplate>                                        
                                        <li>
                                            <a href='<%# "Rent.aspx?pid="+Eval("rentid") %>' title='<%# Eval("rentname") %>'>
                                                <img src='<%# Eval("smallimage") %>' />
                                                <span class="price">月租金：￥<%# Convert.ToDecimal(Eval("rentprice")).ToString("0.00") %></span>
                                                <span class="name" title="<%# Eval("rentname") %>"><%# Eval("rentname") %></span>
                                            </a>
                                            <div class="actionsForInlineButton">
                                                <a class="button_blue3 inlineBlock" href='<%# "Rent.aspx?pid="+Eval("rentid") %>'>
                                                    <span class="left"></span>
                                                    <span class="text">我要租</span>
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
                    </div>
                    <ul class="bottom">
                       <li class="left"></li>
                       <li class="right"></li>
                    </ul>
                </div>
                
            </div>
        </div>
    </div>
    <!--MainBody End-->
</asp:Content>