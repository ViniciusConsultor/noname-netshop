<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GiftFinish.aspx.cs" Inherits="NoName.NetShop.ForeFlat.sp.GiftFinish" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMain" runat="server">
    <!--Position Begin-->
    <div class="currentPosition">
    	您现在的位置: <a href="#">首页</a> &gt;&gt; <a href="#">提交成功</a>
    </div>
    <!--Position End-->
    
    <!--MainBody Begin-->
    <div class="shoppingComplete_mainbody clearfix newline">
    	<div class="box1">
            <ul class="title">
                <li class="left"></li>
                <li><span>礼品兑换</span></li>
                <li class="right"></li>
            </ul>
            <div class="content centerText">
                <div class="sheet1 showResult">
                	<span class="successIcon"></span>
                    <ul>
                    	<li>
                        	<span class="bold">
                        	<asp:Literal ID="litPrompt" runat="server"></asp:Literal></span>
                        </li>
                        <li>
                            <span>您的订单号是</span>
                            <span class="important"><asp:Literal ID="litSavedOrderId" runat="server"></asp:Literal></span>
                        </li>
                        <li>
                        	您现在可以去会员中心<a class="linkButton" href="../member/MyGiftOrders.aspx">【查看订单状态】</a>，可以<a class="linkButton" href="<%=CurrentShopCart.ContinueShopUrl %>">【继续购物】</a>。
                        </li>
                    </ul>
                </div>
            </div>
            <ul class="bottom">
               <li class="left"></li>
               <li class="right"></li>
            </ul>
        </div>
        
        <div class="box7 newline">
            <div class="title">本站强烈推荐</div>
            <div class="content">
                <ul class="itemList3">
                    <li>
                        <a href="#" title="惠普14存经济型笔记本电脑包">
                            <img src="pictures/productPic.gif" />
                            <span>惠普14存经济型笔记本电脑包</span>
                        </a>
                    </li>
                    <li>
                        <a href="#" title="惠普14存经济型笔记本电脑包">
                            <img src="pictures/productPic.gif" />
                            <span>惠普14存经济型笔记本电脑包</span>
                        </a>
                    </li>
                    <li>
                        <a href="#" title="惠普14存经济型笔记本电脑包">
                            <img src="pictures/productPic.gif" />
                            <span>惠普14存经济型笔记本电脑包</span>
                        </a>
                    </li>
                    <li>
                        <a href="#" title="惠普14存经济型笔记本电脑包">
                            <img src="pictures/productPic.gif" />
                            <span>惠普14存经济型笔记本电脑包</span>
                        </a>
                    </li>
                    <li>
                        <a href="#" title="惠普14存经济型笔记本电脑包">
                            <img src="pictures/productPic.gif" />
                            <span>惠普14存经济型笔记本电脑包</span>
                        </a>
                    </li>
                    <li>
                        <a href="#" title="惠普14存经济型笔记本电脑包">
                            <img src="pictures/productPic.gif" />
                            <span>惠普14存经济型笔记本电脑包</span>
                        </a>
                    </li>
                    <li>
                        <a href="#" title="惠普14存经济型笔记本电脑包">
                            <img src="pictures/productPic.gif" />
                            <span>惠普14存经济型笔记本电脑包</span>
                        </a>
                    </li>
                    <li>
                        <a href="#" title="惠普14存经济型笔记本电脑包">
                            <img src="pictures/productPic.gif" />
                            <span>惠普14存经济型笔记本电脑包</span>
                        </a>
                    </li>
                    <li>
                        <a href="#" title="惠普14存经济型笔记本电脑包">
                            <img src="pictures/productPic.gif" />
                            <span>惠普14存经济型笔记本电脑包</span>
                        </a>
                    </li>
                    <li>
                        <a href="#" title="惠普14存经济型笔记本电脑包">
                            <img src="pictures/productPic.gif" />
                            <span>惠普14存经济型笔记本电脑包</span>
                        </a>
                    </li>
                    <li>
                        <a href="#" title="惠普14存经济型笔记本电脑包">
                            <img src="pictures/productPic.gif" />
                            <span>惠普14存经济型笔记本电脑包</span>
                        </a>
                    </li>
                    <li>
                        <a href="#" title="惠普14存经济型笔记本电脑包">
                            <img src="pictures/productPic.gif" />
                            <span>惠普14存经济型笔记本电脑包</span>
                        </a>
                    </li>
                </ul>
            </div>
        </div>
        
    </div>
    <!--MainBody End-->
</asp:Content>
