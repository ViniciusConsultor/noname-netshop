<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SuiteList.aspx.cs" MasterPageFile="~/Site.Master" Inherits="NoName.NetShop.ForeFlat.Solution.SuiteList" %>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="head">
    <link type="text/css" rel="stylesheet" href="/css/solution.css" />
</asp:Content>

<asp:Content runat="server" ID="Content2" ContentPlaceHolderID="cpMain">    
    <!--Position Begin-->
    <div class="currentPosition">
    	您现在的位置: <a href="#">首页</a> &gt;&gt; <a href="#">解决方案</a> &gt;&gt; <a href="#">超值套装</a> &gt;&gt; <a href="#">多媒体会议</a>
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
                        <li>
                            <a href="#"><strong>多媒体会议</strong></a>
                        </li>
                        <li>
                            <a href="#">多媒体教学</a>
                        </li>
                        <li>
                            <a href="#">家庭影院</a>
                        </li>
                        <li>
                            <a href="#">影音娱乐</a>
                        </li>
                        <li>
                            <a href="#">影音游戏</a>
                        </li>
                        <li>
                            <a href="#">影音互动</a>
                        </li>
                        <li>
                            <a href="#">影音展示</a>
                        </li>
                        <li>
                            <a href="#">影音无线传输</a>
                        </li>
                        <li>
                            <a href="#">影像拼接</a>
                        </li>
                        <li>
                            <a href="#">智能影音</a>
                        </li>
                        <li>
                            <a href="#">背景音乐</a>
                        </li>
                        <li>
                            <a href="#">影像监控</a>
                        </li>
                        <li>
                            <a href="#">视频会议</a>
                        </li>
                        <li>
                            <a href="#">立体电影</a>
                        </li>
                        <li>
                            <a href="#">舞台灯光</a>
                        </li>
                        <li>
                            <a href="#">箱体背投</a>
                        </li>
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
                            <span class="text">多媒体会议</span>
                            <span class="arrow"></span>
                        </li>
                        <li class="right"></li>
                    </ul>
                    <div class="content">
						<div id="productList" class="list_horizontal">
                            <ul>
                                <li>
                                    <a href="#" title="A套装">
                                        <img src="Pictures/productPic2.jpg" />
                                        <span class="price">套装总价：￥1188.00</span>
                                        <span class="name" title="伊莱克斯（Electrolux） 全自动洗衣机"><strong>A套装</strong>：A+B+C</span>
                                    </a>
                                    <div class="actionsForInlineButton">
                                        <a class="button_blue3 inlineBlock" href="#">
                                            <span class="left"></span>
                                            <span class="text">购买</span>
                                            <span class="right"></span>
                                        </a>
                                        <a class="button_blue3 inlineBlock" href="#">
                                            <span class="left"></span>
                                            <span class="text">收藏</span>
                                            <span class="right"></span>
                                        </a>
                                        <a class="button_blue3 inlineBlock" href="#">
                                            <span class="left"></span>
                                            <span class="text">套装明细</span>
                                            <span class="right"></span>
                                        </a>
                                    </div>
                                </li>
                                <li>
                                    <a href="#" title="A套装">
                                        <img src="Pictures/productPic2.jpg" />
                                        <span class="price">套装总价：￥1188.00</span>
                                        <span class="name" title="伊莱克斯（Electrolux） 全自动洗衣机"><strong>A套装</strong>：A+B+C</span>
                                    </a>
                                    <div class="actionsForInlineButton">
                                        <a class="button_blue3 inlineBlock" href="#">
                                            <span class="left"></span>
                                            <span class="text">购买</span>
                                            <span class="right"></span>
                                        </a>
                                        <a class="button_blue3 inlineBlock" href="#">
                                            <span class="left"></span>
                                            <span class="text">收藏</span>
                                            <span class="right"></span>
                                        </a>
                                        <a class="button_blue3 inlineBlock" href="#">
                                            <span class="left"></span>
                                            <span class="text">套装明细</span>
                                            <span class="right"></span>
                                        </a>
                                    </div>
                                </li>
                                <li>
                                    <a href="#" title="A套装">
                                        <img src="Pictures/productPic2.jpg" />
                                        <span class="price">套装总价：￥1188.00</span>
                                        <span class="name" title="伊莱克斯（Electrolux） 全自动洗衣机"><strong>A套装</strong>：A+B+C</span>
                                    </a>
                                    <div class="actionsForInlineButton">
                                        <a class="button_blue3 inlineBlock" href="#">
                                            <span class="left"></span>
                                            <span class="text">购买</span>
                                            <span class="right"></span>
                                        </a>
                                        <a class="button_blue3 inlineBlock" href="#">
                                            <span class="left"></span>
                                            <span class="text">收藏</span>
                                            <span class="right"></span>
                                        </a>
                                        <a class="button_blue3 inlineBlock" href="#">
                                            <span class="left"></span>
                                            <span class="text">套装明细</span>
                                            <span class="right"></span>
                                        </a>
                                    </div>
                                </li>
                                <li>
                                    <a href="#" title="A套装">
                                        <img src="Pictures/productPic2.jpg" />
                                        <span class="price">套装总价：￥1188.00</span>
                                        <span class="name" title="伊莱克斯（Electrolux） 全自动洗衣机"><strong>A套装</strong>：A+B+C</span>
                                    </a>
                                    <div class="actionsForInlineButton">
                                        <a class="button_blue3 inlineBlock" href="#">
                                            <span class="left"></span>
                                            <span class="text">购买</span>
                                            <span class="right"></span>
                                        </a>
                                        <a class="button_blue3 inlineBlock" href="#">
                                            <span class="left"></span>
                                            <span class="text">收藏</span>
                                            <span class="right"></span>
                                        </a>
                                        <a class="button_blue3 inlineBlock" href="#">
                                            <span class="left"></span>
                                            <span class="text">套装明细</span>
                                            <span class="right"></span>
                                        </a>
                                    </div>
                                </li>
                                <li>
                                    <a href="#" title="A套装">
                                        <img src="Pictures/productPic2.jpg" />
                                        <span class="price">套装总价：￥1188.00</span>
                                        <span class="name" title="伊莱克斯（Electrolux） 全自动洗衣机"><strong>A套装</strong>：A+B+C</span>
                                    </a>
                                    <div class="actionsForInlineButton">
                                        <a class="button_blue3 inlineBlock" href="#">
                                            <span class="left"></span>
                                            <span class="text">购买</span>
                                            <span class="right"></span>
                                        </a>
                                        <a class="button_blue3 inlineBlock" href="#">
                                            <span class="left"></span>
                                            <span class="text">收藏</span>
                                            <span class="right"></span>
                                        </a>
                                        <a class="button_blue3 inlineBlock" href="#">
                                            <span class="left"></span>
                                            <span class="text">套装明细</span>
                                            <span class="right"></span>
                                        </a>
                                    </div>
                                </li>
                                <li>
                                    <a href="#" title="A套装">
                                        <img src="Pictures/productPic2.jpg" />
                                        <span class="price">套装总价：￥1188.00</span>
                                        <span class="name" title="伊莱克斯（Electrolux） 全自动洗衣机"><strong>A套装</strong>：A+B+C</span>
                                    </a>
                                    <div class="actionsForInlineButton">
                                        <a class="button_blue3 inlineBlock" href="#">
                                            <span class="left"></span>
                                            <span class="text">购买</span>
                                            <span class="right"></span>
                                        </a>
                                        <a class="button_blue3 inlineBlock" href="#">
                                            <span class="left"></span>
                                            <span class="text">收藏</span>
                                            <span class="right"></span>
                                        </a>
                                        <a class="button_blue3 inlineBlock" href="#">
                                            <span class="left"></span>
                                            <span class="text">套装明细</span>
                                            <span class="right"></span>
                                        </a>
                                    </div>
                                </li>
                                <li>
                                    <a href="#" title="A套装">
                                        <img src="Pictures/productPic2.jpg" />
                                        <span class="price">套装总价：￥1188.00</span>
                                        <span class="name" title="伊莱克斯（Electrolux） 全自动洗衣机"><strong>A套装</strong>：A+B+C</span>
                                    </a>
                                    <div class="actionsForInlineButton">
                                        <a class="button_blue3 inlineBlock" href="#">
                                            <span class="left"></span>
                                            <span class="text">购买</span>
                                            <span class="right"></span>
                                        </a>
                                        <a class="button_blue3 inlineBlock" href="#">
                                            <span class="left"></span>
                                            <span class="text">收藏</span>
                                            <span class="right"></span>
                                        </a>
                                        <a class="button_blue3 inlineBlock" href="#">
                                            <span class="left"></span>
                                            <span class="text">套装明细</span>
                                            <span class="right"></span>
                                        </a>
                                    </div>
                                </li>
                                <li>
                                    <a href="#" title="A套装">
                                        <img src="Pictures/productPic2.jpg" />
                                        <span class="price">套装总价：￥1188.00</span>
                                        <span class="name" title="伊莱克斯（Electrolux） 全自动洗衣机"><strong>A套装</strong>：A+B+C</span>
                                    </a>
                                    <div class="actionsForInlineButton">
                                        <a class="button_blue3 inlineBlock" href="#">
                                            <span class="left"></span>
                                            <span class="text">购买</span>
                                            <span class="right"></span>
                                        </a>
                                        <a class="button_blue3 inlineBlock" href="#">
                                            <span class="left"></span>
                                            <span class="text">收藏</span>
                                            <span class="right"></span>
                                        </a>
                                        <a class="button_blue3 inlineBlock" href="#">
                                            <span class="left"></span>
                                            <span class="text">套装明细</span>
                                            <span class="right"></span>
                                        </a>
                                    </div>
                                </li>
                            </ul>
                            <div class="paginationContainer">
                            	<div class="line"></div>
                                <div class="pagination">
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
