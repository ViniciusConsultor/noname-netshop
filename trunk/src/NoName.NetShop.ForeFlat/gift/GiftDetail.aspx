<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GiftDetail.aspx.cs" Inherits="NoName.NetShop.ForeFlat.gift.GiftDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<link type="text/css" rel="stylesheet" href="../css/shopping.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMain" runat="server">
     
    <!--Position Begin-->
    <div class="currentPosition">
    	您现在的位置: <a href="#">首页</a> &gt;&gt; <a href="#">礼品兑换</a> &gt;&gt; <a href="#">礼品详情</a>
    </div>
    <!--Position End-->
    
    <!--MainBody Begin-->
    <div class="giftDetail_mainbody newline clearfix">
        <div class="box1 noPadding">
            <ul class="title">
                <li class="left"></li>
                <li><span>礼品详情</span></li>
                <li class="right"></li>
            </ul>
            <div class="content">
                <div class="productGeneralProperties padding">
                    <div class="thumbnail" onmousemove="zoomInThumb(event,this);" onmouseover="zoomInThumb(event,this);">
                        <img src="http://dingding.uncc.cn/upload/productmain/<%= model.MediumImage %>" />
                        <div class="targetArea"></div>
                        <div class="zoomInArea">
                            <img src="http://dingding.uncc.cn/upload/productmain/<%= model.LargeImage %>" />
                        </div>
                    </div>
                    <div class="properties">
                        <ul>
                            <li>
                                <h1><%= model.ProductName %></h1>
                            </li> 
                            <li>
                                <span class="field">需要积分：</span><span><%=model.Score %></span>
                            </li>
                            <li>
                                <span class="field forDescription">详细介绍：</span>
                                <span class="description">
                                	<%= model.Decription %>
                                </span>
                            </li>
                            
                            <li class="buttons">
                                <a class="exchangeGift" href="../sp/AddToCart.aspx?pid=<%=model.ProductId %>&opt=1&qua=1&cname=giftcart"></a>
                            </li>
                        </ul>
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
