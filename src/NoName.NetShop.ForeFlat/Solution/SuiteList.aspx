<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SuiteList.aspx.cs" MasterPageFile="~/Site.Master" Inherits="NoName.NetShop.ForeFlat.Solution.SuiteList" %>
<%@ Register Assembly="NoName.Utility" Namespace="NoName.Utility" TagPrefix="cc1" %>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="head">
    <link type="text/css" rel="stylesheet" href="/css/solution.css" />
    <script type="text/javascript" src="/js/solution.suitelist.js"></script>
</asp:Content>

<asp:Content runat="server" ID="Content2" ContentPlaceHolderID="cpMain">    
    <!--Position Begin-->
    <div class="currentPosition">
    	您现在的位置: <a href="/">首页</a> &gt;&gt; <a href="/Channel/solution/">解决方案</a> &gt;&gt; <a href="#">推荐套装</a>
        <div class="solutionSubNav">
            <div class="solutionButtonTab">
                <a class="button_blue" href="/solution/Demand.aspx">按需制定</a>
                <a class="button_blue2" href="/solution/SuiteList.aspx">推荐套装</a>
                <a class="button_blue" href="/solution/Home.aspx">经典套装</a>
            </div>
        </div>
    </div>
    <!--Position End-->
    
    <!--MainBody Begin-->
    <div class="solutionSuiteList_mainbody newline clearfix">
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
                                        <%# ScenceID == Convert.ToInt32(Eval("scenceid")) ? "<strong>" + Eval("scencename") + "</strong>" : Eval("scencename")%>
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
                            <span class="text"><asp:Literal runat="server" ID="Literal_SenceName" /></span>
                            <span class="arrow"></span>
                        </li>
                        <li class="right"></li>
                    </ul>
                    <div class="content">
						<div id="productList" class="list_horizontal">
                            <ul>
                                <asp:Repeater runat="server" ID="Repeater_Suites">
                                    <ItemTemplate>
                                        <li>
                                            <a href='<%# "SuiteDetail.aspx?suite="+Eval("suiteid") %>' title='<%# Eval("SuiteName") %>'>
                                                <img src='<%# Eval("mediumimage") %>' />
                                                <span class="price">套装总价：￥<%# Eval("price") %></span>
                                                <span class="name" title='<%# Eval("SuiteName") %>'><strong><%# Eval("SuiteName") %></strong></span>
                                            </a>
                                            <div class="actionsForInlineButton">
                                                <a class="button_blue3 inlineBlock" href='<%# "SuiteDetail.aspx?suite="+Eval("suiteid") %>'>
                                                    <span class="left"></span>
                                                    <span class="text">购买</span>
                                                    <span class="right"></span>
                                                </a>
                                                <a class="button_blue3 inlineBlock" style="cursor:pointer" fav="true" suiteid='<%# Eval("suiteid") %>'>
                                                    <span class="left"></span>
                                                    <span class="text">收藏</span>
                                                    <span class="right"></span>
                                                </a>
                                                <a class="button_blue3 inlineBlock" href='<%# "SuiteDetail.aspx?suite="+Eval("suiteid") %>'>
                                                    <span class="left"></span>
                                                    <span class="text">套装明细</span>
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
