<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeProductList.aspx.cs" MasterPageFile="~/Site.Master" Inherits="NoName.NetShop.ForeFlat.Product.HomeProductList" %>
<%@ Register Assembly="NoName.Utility" Namespace="NoName.Utility" TagPrefix="cc1" %>

<asp:Content runat="server" ID="ContentHead" ContentPlaceHolderID="head">
    
</asp:Content>

<asp:Content runat="server" ID="ContentBody" ContentPlaceHolderID="cpMain">
    
    <!--Position Begin-->
    <div class="currentPosition">
    	您现在的位置: <a href="/">首页</a> &gt;&gt; <a href="#"><asp:Literal runat="server" ID="Literal_SalesName1" /></a>    	
        <div class="solutionSubNav" style="float:right">
            <div class="solutionButtonTab">
                <asp:HyperLink runat="server" ID="HyperLink1" CssClass="button_blue" NavigateUrl="HomeProductList.aspx?type=1" style="float:left" Text="热销商品" />
                <asp:HyperLink runat="server" ID="HyperLink2" CssClass="button_blue" NavigateUrl="HomeProductList.aspx?type=2" style="float:left" Text="直降特卖" />
                <asp:HyperLink runat="server" ID="HyperLink3" CssClass="button_blue" NavigateUrl="HomeProductList.aspx?type=3" style="float:left" Text="鼎鼎推荐" />
            </div>
        </div>
    </div>
    <!--Position End-->
    
    <!--MainBody Begin-->
    <div class="shoppingClass_mainbody newline clearfix">
        <div class="leftColumn" id="DivLeft" runat="server">
                        
        </div>
        <div class="rightColumn">
        	<div class="rightColumnContainer">
            	<div class="box8 newline">
                    <ul class="title">
                        <li class="left"></li>
                        <li class="heading">
                            <span class="text"><asp:Literal runat="server" ID="Literal_SalesName2" /></span>
                            <span class="arrow"></span>
                        </li>
                        <li class="right"></li>
                        <li class="view">
                        	<span>显示方式</span>
                            <a class="viewBtn horizontal_on" href="javascript:void(0)" onclick="viewTransfer(this)"></a>
                            <a class="viewBtn vertical" href="javascript:void(0)" onclick="viewTransfer(this)"></a>
                        </li>
                        <li class="sort">
                        </li>
                    </ul>
                    <div class="content">
						<div id="productList" class="list_horizontal">
                            <ul>
                                <asp:Repeater runat="server" ID="Repeater_Product">
                                    <ItemTemplate>
                                        <li>
                                            <a href='/product-<%# Eval("productid") %>.html' title='<%# Eval("ProductName") %>'>
                                                <img src="Pictures/productPic.gif" />
                                                <span class="price">鼎城报价：￥<%# Eval("price") %></span>
                                                <span class="name" title='<%# Eval("ProductName") %>'><%# Eval("ProductName") %></span>
                                                <span class="commentsNum"></span>
                                            </a>
                                            <div class="actions">
                                                <a class="button_blue3" href='/product-<%# Eval("productid") %>.html'>
                                                    <span class="left"></span>
                                                    <span class="text">购买</span>
                                                    <span class="right"></span>
                                                </a>
                                                <a class="button_blue3" href="#" favid='<%# Eval("productid") %>'>
                                                    <span class="left"></span>
                                                    <span class="text">收藏</span>
                                                    <span class="right"></span>
                                                </a>
                                                <a class="button_blue3" href='/product-<%# Eval("productid") %>.html'>
                                                    <span class="left"></span>
                                                    <span class="text">对比</span>
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
                                    <cc1:AspNetPager CssClass="pagerclass" ID="AspNetPager" runat="server" PageSize="16"
                                        UrlPageIndexName="" AlwaysShow="true" ImagePath="/" FirstPageText='首页' ShowInputBox="Always"
                                        LastPageText='末页' NextPageText='下一页' OnPageChanged="AspNetPager_PageChanged"
                                        PrevPageText='上一页' ShowBoxThreshold="16" NumericButtonCount="8" 
                                        ShowPrevNext="True" SubmitButtonClass="buttom" ShowPageIndex="true"
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