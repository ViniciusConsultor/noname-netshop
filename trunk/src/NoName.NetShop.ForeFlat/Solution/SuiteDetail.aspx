<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SuiteDetail.aspx.cs" MasterPageFile="~/Site.Master" Inherits="NoName.NetShop.ForeFlat.Solution.SuiteDetail" %>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="head">
    <link type="text/css" rel="stylesheet" href="/css/solution.css" />
</asp:Content>

<asp:Content runat="server" ID="Content2" ContentPlaceHolderID="cpMain">    
    <!--Position Begin-->
    <div class="currentPosition">
    	您现在的位置: <a href="#">首页</a> &gt;&gt; <a href="#">解决方案</a> &gt;&gt; <a href="#">超值套装</a> &gt;&gt; <a href="#">多媒体会议</a> &gt;&gt; <a href="#">A套装</a>
        <div class="solutionSubNav">
            <div class="solutionButtonTab">
                <a class="button_blue" href="#">按需制定</a>
                <a class="button_blue2" href="#">推荐套装</a>
                <a class="button_blue" href="#">经典套装</a>
            </div>
        </div>
    </div>
    <!--Position End-->
    
    <!--MainBody Begin-->
    <div class="solutionSuiteDetail_mainbody newline clearfix">
		<div class="leftColumn">
		  <div class="box2">
          <ul class="title">
                    <li class="left"></li>
                    <li><span>超值套装</span></li>
                    <li class="right"></li>
                </ul>
                <div class="content noPaddingTop">
					<ul class="articleList_1 bullet_2">
					    <asp:Repeater runat="server" ID="Repeater_Sence">
					        <ItemTemplate>
                                <li>
                                    <a href='<%# "SuiteList.aspx?s="+Eval("scenceid") %>'>
                                        <%# Eval("scencename") %>
                                    </a>
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
        <div class="rightColumn">
        	<div class="rightColumnContainer">
            	<div class="box1">
                    <ul class="title">
                        <li class="left"></li>
                        <li class="heading">
                            <span class="text"><asp:literal runat="server" ID="Literal_SuiteName" />产品明细</span>
                            <span class="arrow"></span>
                        </li>
                        <li class="right"></li>
                    </ul>
                    <div class="content">
						<div id="productList" class="list_vertical">
                            <ul>
                                <asp:Repeater runat="server" ID="Repeater_Products">
                                    <ItemTemplate>
                                        <li>
                                            <a href='<%# "/product-"+Eval("productid")+".html" %>' title='<%# Eval("productname") %>'>
                                                <img src='<%# Eval("mediumimage") %>' />
                                                <span class="name" title='<%# Eval("productname") %>'><%# Eval("productname") %></span>
                                                <span>市场价：<span class="marketPrice">￥<%# Eval("tradeprice") %></span>鼎鼎价：<span class="marketPrice">￥<%# Eval("merchantprice") %></span></span>
                                                <span class="price">套装价：￥<%# Eval("price") %></span>
                                            </a>
                                        </li>                                        
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                            <div class="subtotal">
                                <asp:LinkButton runat="server" ID="Button_Buy" CssClass="button_blue" OnClick="Button_Buy_Click" Text="放入购物车"></asp:LinkButton>
                                <div>套装总价:<span class="important"><strong>￥<asp:Literal runat="server" ID="Literal_SuiteSum" /></strong></span></div>
                            	<div>立即节省：<span class="important"><strong>￥<asp:Literal runat="server" ID="Literal_SaveValue" /></strong></span></div>
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