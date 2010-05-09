<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Secondhand.aspx.cs" MasterPageFile="~/Site.Master" Inherits="NoName.NetShop.ForeFlat.Magic.Secondhand" %>


<asp:Content runat="server" ID="Content_Header" ContentPlaceHolderID="head">
    <link type="text/css" rel="stylesheet" href="/css/magic.css" />
    <script src="../js/magicworld.secondhand.js" type="text/javascript"></script>
</asp:Content>

<asp:Content runat="server" ID="Content_Body" ContentPlaceHolderID="cpMain">
    <!--Position Begin-->
    <div class="currentPosition">
    	您现在的位置: <a href="/">首页</a> &gt;&gt; <a href="/channel/magic">魔力世界</a> &gt;&gt; <a href="/Magic/DealHome.aspx">二手交易</a> &gt;&gt; <a href="#">出售详细信息</a>
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
    <div class="magicDealSaleDetail_mainbody clearfix newline">
                <div class="box1">
                    <ul class="title">
                        <li class="left"></li>
                        <li><span>出售详细信息</span></li>
                        <li class="right"></li>
                    </ul>
                    <div class="content">
                        <div class="productGeneralProperties padding">
                            <div class="thumbnail" onmousemove="zoomInThumb(event,this);" onmouseover="zoomInThumb(event,this);">
                                <asp:Image runat="server" ID="Image_Small" />
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
                                        <span class="field ddPriceField">价　　格：</span><span class="ddPrice">￥<asp:Literal runat="server" ID="Literal_Price" /></span>
                                    </li>
                                    <li>
                                        <span class="field">类　　别：</span><span><asp:Literal runat="server" ID="Literal_CategoryName" /></span>
                                    </li>
                                    <li>
                                        <span class="field">数　　量：</span><span><asp:Literal runat="server" ID="Literal_Stock" /></span>
                                    </li>
                                    <li>
                                        <span class="field">新旧程度：</span><span><asp:Literal runat="server" ID="Literal_Condition" /></span>
                                    </li>
                                    <li class="userInfo">
                                    	<div class="box10">
                                        	<div class="title">
                                            	<span>卖家档案</span>
                                            </div>
                                            <div class="content">
                                            	<ul>
                                                	<li>昵称：<asp:Literal runat="server" ID="Literal_Nick" /></li>
                                                	<li>等级：<asp:Literal runat="server" ID="Literal_Level" /></li>
                                                    <li>所在地：<asp:Literal runat="server" ID="Literal_Province" /></li>
                                                    <li>联系电话：<asp:Literal runat="server" ID="Literal_Phone" /></li>
                                                </ul>
                                            </div>
                                        </div>
                                    </li>
                                </ul>
                            </div>
                        </div>
                        <div class="box7">
                            <div class="title">产品简介</div>
                            <div class="content">
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
                                    <input type="text" id="comment-validate" />
                                    <img id="comment-validate-image" src="../ValiateCode.aspx" onclick="this.src='../ValiateCode.aspx?_='+new Date().getUTCMilliseconds()" />
                                    <input seid='<%= SecondhandProductID %>' type="button" id="comment-button" class"button_blue" value="发表" />
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