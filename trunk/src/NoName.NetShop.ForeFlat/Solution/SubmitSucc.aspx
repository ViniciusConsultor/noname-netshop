<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="SubmitSucc.aspx.cs" Inherits="NoName.NetShop.ForeFlat.Solution.SubmitSucc" %>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="head">
    <link type="text/css" rel="stylesheet" href="/css/solution.css" />
</asp:Content>

<asp:Content runat="server" ID="Content2" ContentPlaceHolderID="cpMain">    
    <!--Position Begin-->
    <div class="currentPosition">
    	您现在的位置: <a href="#">首页</a> &gt;&gt; <a href="#">提交成功</a>
    </div>
    <!--Position End-->
    
    <!--MainBody Begin-->
    <div class="commonComplete_mainbody clearfix newline">
    	<div class="box1">
            <ul class="title">
                <li class="left"></li>
                <li><span>提交成功</span></li>
                <li class="right"></li>
            </ul>
            <div class="content centerText">
                <div class="sheet1 showResult">
                	<span class="successIcon"></span>
                    <ul>
                    	<li>
                        	<span class="bold">您的订购单已经提交成功!</span>
                        </li>
                        <li>
                        	您的订单号是<span class="important" runat="server" id="orderid"></span> 请牢记。
                        </li>
                        <li>
							到别的频道去看看吧！
                        </li>
                    </ul>
                    <div class="otherChannel">
                    	<a href="#">首页</a>
                        <a href="#">购物街</a>
                        <a href="#">品牌商城</a>
                        <a href="#">视听咨询</a>
                        <a href="#">解决方案</a>
                        <a href="#">魔力世界</a>                        
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