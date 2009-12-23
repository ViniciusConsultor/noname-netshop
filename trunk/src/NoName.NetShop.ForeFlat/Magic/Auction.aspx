﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Auction.aspx.cs" MasterPageFile="~/Site.Master" Inherits="NoName.NetShop.ForeFlat.Magic.Auction" %>
<asp:Content ID="ContentHeader" ContentPlaceHolderID="head" runat="server">
    <link type="text/css" rel="stylesheet" href="/css/magic.css" />
    <script src="../js/magicworld.auction.js" type="text/javascript"></script>
</asp:Content>

<asp:Content ID="ContentBody" ContentPlaceHolderID="cpMain" runat="server">
    <!--Position Begin-->
    <div class="currentPosition">
    	您现在的位置: <a href="#">首页</a> &gt;&gt; <a href="#">魔力世界</a> &gt;&gt; <a href="#">视听拍卖</a> &gt;&gt; <a href="#">拍卖品详情</a>
        <div class="magicSubNav">
            <div class="magicButtonTab">
                <a class="button_blue" href="#">视听租赁</a>
                <a class="button_blue" href="#">二手交易</a>
                <a class="button_blue" href="#">视听当铺</a>
                <a class="button_blue2" href="#">视听拍卖</a>
            </div>
        </div>
    </div>
    <!--Position End-->
    
    <!--MainBody Begin-->
    <div class="magicAuctionDetail_mainbody clearfix newline">
		<div class="rightColumn">
            <div class="box2">
                <ul class="title">
                    <li class="left"></li>
                    <li><span>其它相关产品</span></li>
                    <li class="right"></li>
                </ul>
                <div class="content">
                    <ul class="itemList5">
                        <li>
                            <a href="#">
                                <img src="pictures/productPic.gif" />
                            </a>
                            <div class="infoContainer">
                                <ul class="info">
                                    <li>
                                        <span class="name"><a href="#">留声机_新开价</a></span>
                                    </li>
                                    <li>
                                        <span class="field">当前价格:</span>
                                        <span class="important">68元</span>
                                    </li>
                                    <li>
                                        <span class="field">结束时间:</span>
                                        <span class="important">09-09-06</span>
                                    </li>
                                </ul>
                            </div>
                            <span class="description">进入时尚前沿中的高清之世界。新款 14 英寸 Gateway  TC 系列笔记本首先追求美观，然后增添性能，最后确保成品轻便。我们的 TC 系列便携式计算机采用红酒色或深黑色外观设计，使用 Linux 操作系统并配置最高英特尔  酷睿 2 双核处理器，配备可选英特尔 迅驰 2 处理器技术和 NVIDIA GeForce  显卡，该机型具备更多您需要和您想要的性能。</span>
                        </li>
                        <li>
                            <a href="#">
                                <img src="pictures/productPic.gif" />
                            </a>
                            <div class="infoContainer">
                                <ul class="info">
                                    <li>
                                        <span class="name"><a href="#">留声机_新开价</a></span>
                                    </li>
                                    <li>
                                        <span class="field">当前价格:</span>
                                        <span class="important">68元</span>
                                    </li>
                                    <li>
                                        <span class="field">结束时间:</span>
                                        <span class="important">09-09-06</span>
                                    </li>
                                </ul>
                            </div>
                            <span class="description">进入时尚前沿中的高清之世界。新款 14 英寸 Gateway  TC 系列笔记本首先追求美观，然后增添性能，最后确保成品轻便。我们的 TC 系列便携式计算机采用红酒色或深黑色外观设计，使用 Linux 操作系统并配置最高英特尔  酷睿 2 双核处理器，配备可选英特尔 迅驰 2 处理器技术和 NVIDIA GeForce  显卡，该机型具备更多您需要和您想要的性能。</span>
                        </li>
                        <li>
                            <a href="#">
                                <img src="pictures/productPic.gif" />
                            </a>
                            <div class="infoContainer">
                                <ul class="info">
                                    <li>
                                        <span class="name"><a href="#">留声机_新开价</a></span>
                                    </li>
                                    <li>
                                        <span class="field">当前价格:</span>
                                        <span class="important">68元</span>
                                    </li>
                                    <li>
                                        <span class="field">结束时间:</span>
                                        <span class="important">09-09-06</span>
                                    </li>
                                </ul>
                            </div>
                            <span class="description">进入时尚前沿中的高清之世界。新款 14 英寸 Gateway  TC 系列笔记本首先追求美观，然后增添性能，最后确保成品轻便。我们的 TC 系列便携式计算机采用红酒色或深黑色外观设计，使用 Linux 操作系统并配置最高英特尔  酷睿 2 双核处理器，配备可选英特尔 迅驰 2 处理器技术和 NVIDIA GeForce  显卡，该机型具备更多您需要和您想要的性能。</span>
                        </li>
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
                        <li><span>拍卖品详情</span></li>
                        <li class="right"></li>
                    </ul>
                    <div class="content">
                    	<div class="box7">
                        	<div class="title">出价记录</div>
                            <div class="content">
                            	<div class="table3">
                                    <table>
                                      <tr>
                                        <th>出价</th>
                                        <th>时间</th>
                                        <th>用户名</th>
                                      </tr>
                                      <asp:Repeater runat="server" ID="Repeater_BidList">
                                        <ItemTemplate>
                                          <tr>
                                            <td><span class="important">￥<%# Eval("autionprice") %></span></td>
                                            <td><%# Convert.ToDateTime(Eval("auctiontime")).ToString("yyyy-MM-dd HH:mm:ss") %></td>
                                            <td><span><%# Eval("username") %></span></td>
                                          </tr>
                                        </ItemTemplate>
                                      </asp:Repeater>
                                    </table>
                                </div>
                            </div>
                        </div>
                        
                        <div class="box7">
                        	<div class="title">我要加价</div>
                            <div class="content markup" id="add-prices">
                                <asp:Repeater runat="server" ID="Repeater_AddPrices" OnItemCommand="Repeater_AddPrices_ItemCommand">
                                    <ItemTemplate>
                                        <asp:LinkButton runat="server" CssClass="button_blue inlineBlock"  ID="Button_Bid" CommandName="b" CommandArgument='<%# Eval("price") %>' Text='<%# Eval("price") %>' />
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                        
                        <div class="box7">
                        	<div class="title">拍卖品详情</div>
                            <div class="content">
								<div class="productGeneralProperties padding">
                                    <div class="thumbnail" onmousemove="zoomInThumb(event,this);" onmouseover="zoomInThumb(event,this);">
                                        <asp:Image runat="server" ID="Image_Medium" />
                                        <div class="targetArea"></div>
                                        <div class="zoomInArea">
                                            <asp:Image runat="server" ID="Image_Large" />
                                        </div>
                                    </div>
                                    <div class="properties">
                                        <ul>
                                            <li>
                                                <h1><asp:Literal runat="server" ID="Literal_ProductName" /></h1>
                                            </li> 
                                            <li>
                                                <span class="field">起 拍 价：</span><span>￥<asp:Literal runat="server" ID="Literal_StartPrice" /></span>
                                            </li>
                                            <li>
                                                <span class="field ddPriceField">当前价格：</span><span class="ddPrice">￥<asp:Literal runat="server" ID="Literal_CurrentPrice" /></span>
                                            </li>
                                            <li>
                                                <span class="field">最低加价：</span><span>￥<asp:Literal runat="server" ID="Literal_MinAddPrice" /></span>
                                            </li>
                                            <li>
                                                <span class="field">最高加价：</span><span>￥<asp:Literal runat="server" ID="Literal_MaxAddPrice" /></span>
                                            </li>
                                            <li>
                                                <span class="field">起始时间：</span><span><asp:Literal runat="server" ID="Literal_StartTime" /></span>
                                            </li>
                                            <li>
                                                <span class="field">截止时间：</span><span><asp:Literal runat="server" ID="Literal_EndTime" /></span>
                                            </li>
                                        </ul>
                                    </div>
                                </div>
                                
                                <p class="description">
                                	<asp:Literal runat="server" ID="Literal_Description" />
                                </p>
                                
                            </div>
                        </div>
                        
                        <div class="box7">
                        	<div class="title">产品评价</div>
                            <div class="content">
                            	<div class="table3">
                                    <table>
                                      <tr>
                                        <th>用户名</th>
                                        <th>内容</th>
                                        <th>时间</th>
                                      </tr>
                                        <asp:Repeater runat="server" ID="Repeater_Comment">
                                            <ItemTemplate>
                                              <tr>
                                                <td><span><%# Eval("userid") %></span></td>
                                                <td><p><%# Eval("content") %></p></td>
                                                <td><%# Convert.ToDateTime(Eval("createtime")).ToString("yyyy年MM月dd日") %></td>
                                              </tr>                                                
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </table>
                                </div>
                                <div class="leaveComment">
                                    <div class="title">我来说几句</div>
                                    <textarea id="comment-content"></textarea>
                                    <input auid='<%= AuctionID %>' type="button" id="comment-button" class"button_blue" value="发表" />
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