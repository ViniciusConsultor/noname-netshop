<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DealHome.aspx.cs" MasterPageFile="~/Site.Master" Inherits="NoName.NetShop.ForeFlat.Magic.DealHome" %>


<asp:Content ID="ContentHeader" ContentPlaceHolderID="head" runat="server">
    <link type="text/css" rel="stylesheet" href="/css/magic.css" />
</asp:Content>

<asp:Content ID="ContentBody" ContentPlaceHolderID="cpMain" runat="server">
    <!--Position Begin-->
    <div class="currentPosition">
    	您现在的位置: <a href="/">首页</a> &gt;&gt; <a href="/channel/magic">魔力世界</a> &gt;&gt; <a href="#">二手交易</a>
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
    <div class="magicDealHome_mainbody clearfix newline">
		<div class="row">
        	<div class="box1 block1">
                <ul class="title">
                    <li class="left"></li>
                    <li><a class="Tab_on" rel="announcement" href="javascript:void(0)" onclick="TabTransfer(this)">市场公告</a><a class="Tab_off" rel="statement" href="javascript:void(0)" onclick="TabTransfer(this)">免责声明</a></li>
                    <li class="right"></li>
                </ul>
                <div id="announcement" style="display:none">
                	<p class="noSpacing">
                    	进入时尚前沿中的高清之世界。新款 14 英寸 Gateway  TC 系列笔记本首先追求美观，然后增添性能，最后确保成品轻便。我们的 TC 系列便携式计算机采用红酒色或深黑色外观设计，使用 Linux 操作系统并配置最高使用 Linux 操作系统并配置最高英特尔  酷睿 2 双核处理器，配备可选英特尔 迅驰 2 处理器技术和 NVIDIA® GeForce  显卡，该机型具备更多您需要和您想要的性能。
                    </p>
                </div>
                <div id="statement" style="display:none">
                	<p class="noSpacing">
                    	免责声明，免责声明免责声明免责声明免责声明免责声明，免责声明免责声明免责声明最后确保成品轻便。我们的 TC 系列便携式计算机采用红酒色或深黑色外观设计，使用 Linux 操作系统并配置最高使用 Linux 操作系统并配置最高英特尔  酷睿 2 双核处理器，配备可选英特尔 迅驰 2 处理器技术和 NVIDIA® GeForce  显卡，该机型具备更多您需要和您想要的性能。
                    </p>
                </div>
                <div class="content">
                	<script type="text/javascript">
                    	document.write(document.getElementById("announcement").innerHTML);
                    </script>
                </div>
                <ul class="bottom">
                   <li class="left"></li>
                   <li class="right"></li>
                </ul>
            </div>
            
            <div class="box1 block2 newblock">
                <ul class="title">
                    <li class="left"></li>
                    <li><span>今日更新</span></li>
                    <li class="right"></li>
                    <li class="more"><a class="more1" href="#"></a></li>
                </ul>
                <div class="content">
                	<div class="column1">
                    	<div class="subTitle">出售信息</div>
                    	<ul class="articleList_1 bullet_2">
                            <li>
                                <a href="#">初春必败男装 全场2折起</a>
                            </li>
                            <li>
                                <a href="#">欧米茄手表3折</a>
                            </li>
                            <li>
                                <a href="#">初春必败男装 全场2折起</a>
                            </li>
                            <li>
                                <a href="#">欧米茄手表3折</a>
                            </li>
                            <li>
                                <a href="#">开学好礼大放送，DIY放血大促销</a>
                            </li>
                            <li>
                                <a href="#">初春必败男装 全场2折起</a>
                            </li>
                            <li>
                                <a href="#">欧米茄手表3折</a>
                            </li>
                            <li>
                                <a href="#">初春必败男装 全场2折起</a>
                            </li>
                        </ul>
                    </div>
                    <div class="column2">
                    	<div class="subTitle">求购信息</div>
                    	<ul class="articleList_1 bullet_2">
                            <li>
                                <a href="#">初春必败男装 全场2折起</a>
                            </li>
                            <li>
                                <a href="#">欧米茄手表3折</a>
                            </li>
                            <li>
                                <a href="#">初春必败男装 全场2折起</a>
                            </li>
                            <li>
                                <a href="#">欧米茄手表3折</a>
                            </li>
                            <li>
                                <a href="#">开学好礼大放送，DIY放血大促销</a>
                            </li>
                            <li>
                                <a href="#">初春必败男装 全场2折起</a>
                            </li>
                            <li>
                                <a href="#">欧米茄手表3折</a>
                            </li>
                            <li>
                                <a href="#">初春必败男装 全场2折起</a>
                            </li>
                        </ul>
                    </div>
                </div>
                <ul class="bottom">
                   <li class="left"></li>
                   <li class="right"></li>
                </ul>
            </div>
        </div>
            
        <div class="row newline">
            <div class="box1 blockN">
                <ul class="title">
                    <li class="left"></li>
                    <li><span>交易分类</span></li>
                    <li class="right"></li>
                    <li class="more"><a class="more1" href="#"></a></li>
                </ul>
                <div class="content">
                    <img src="pictures/noPic.jpg" />
                    <ul class="articleList_1 bullet_2">
                        <li>
                            <a href="#">初春必败男装 全场2折起</a>
                        </li>
                        <li>
                            <a href="#">欧米茄手表3折</a>
                        </li>
                        <li>
                            <a href="#">初春必败男装 全场2折起</a>
                        </li>
                        <li>
                            <a href="#">欧米茄手表3折</a>
                        </li>
                        <li>
                            <a href="#">开学好礼大放送，DIY放血大促销</a>
                        </li>
                        <li>
                            <a href="#">初春必败男装 全场2折起</a>
                        </li>
                        <li>
                            <a href="#">欧米茄手表3折</a>
                        </li>
                        <li>
                            <a href="#">初春必败男装 全场2折起</a>
                        </li>
                    </ul>
                </div>
                <ul class="bottom">
                   <li class="left"></li>
                   <li class="right"></li>
                </ul>
            </div>
            
            <div class="box1 blockN newblock">
                <ul class="title">
                    <li class="left"></li>
                    <li><span>交易分类</span></li>
                    <li class="right"></li>
                    <li class="more"><a class="more1" href="#"></a></li>
                </ul>
                <div class="content">
                	<img src="pictures/noPic.jpg" />
                    <ul class="articleList_1 bullet_2">
                        <li>
                            <a href="#">初春必败男装 全场2折起</a>
                        </li>
                        <li>
                            <a href="#">欧米茄手表3折</a>
                        </li>
                        <li>
                            <a href="#">初春必败男装 全场2折起</a>
                        </li>
                        <li>
                            <a href="#">欧米茄手表3折</a>
                        </li>
                        <li>
                            <a href="#">开学好礼大放送，DIY放血大促销</a>
                        </li>
                        <li>
                            <a href="#">初春必败男装 全场2折起</a>
                        </li>
                        <li>
                            <a href="#">欧米茄手表3折</a>
                        </li>
                        <li>
                            <a href="#">初春必败男装 全场2折起</a>
                        </li>
                    </ul>
                </div>
                <ul class="bottom">
                   <li class="left"></li>
                   <li class="right"></li>
                </ul>
            </div>
        </div>
        
                <div class="row newline">
            <div class="box1 blockN">
                <ul class="title">
                    <li class="left"></li>
                    <li><span>交易分类</span></li>
                    <li class="right"></li>
                    <li class="more"><a class="more1" href="#"></a></li>
                </ul>
                <div class="content">
                    <img src="pictures/noPic.jpg" />
                    <ul class="articleList_1 bullet_2">
                        <li>
                            <a href="#">初春必败男装 全场2折起</a>
                        </li>
                        <li>
                            <a href="#">欧米茄手表3折</a>
                        </li>
                        <li>
                            <a href="#">初春必败男装 全场2折起</a>
                        </li>
                        <li>
                            <a href="#">欧米茄手表3折</a>
                        </li>
                        <li>
                            <a href="#">开学好礼大放送，DIY放血大促销</a>
                        </li>
                        <li>
                            <a href="#">初春必败男装 全场2折起</a>
                        </li>
                        <li>
                            <a href="#">欧米茄手表3折</a>
                        </li>
                        <li>
                            <a href="#">初春必败男装 全场2折起</a>
                        </li>
                    </ul>
                </div>
                <ul class="bottom">
                   <li class="left"></li>
                   <li class="right"></li>
                </ul>
            </div>
            
            <div class="box1 blockN newblock">
                <ul class="title">
                    <li class="left"></li>
                    <li><span>交易分类</span></li>
                    <li class="right"></li>
                    <li class="more"><a class="more1" href="#"></a></li>
                </ul>
                <div class="content">
                	<img src="pictures/noPic.jpg" />
                    <ul class="articleList_1 bullet_2">
                        <li>
                            <a href="#">初春必败男装 全场2折起</a>
                        </li>
                        <li>
                            <a href="#">欧米茄手表3折</a>
                        </li>
                        <li>
                            <a href="#">初春必败男装 全场2折起</a>
                        </li>
                        <li>
                            <a href="#">欧米茄手表3折</a>
                        </li>
                        <li>
                            <a href="#">开学好礼大放送，DIY放血大促销</a>
                        </li>
                        <li>
                            <a href="#">初春必败男装 全场2折起</a>
                        </li>
                        <li>
                            <a href="#">欧米茄手表3折</a>
                        </li>
                        <li>
                            <a href="#">初春必败男装 全场2折起</a>
                        </li>
                    </ul>
                </div>
                <ul class="bottom">
                   <li class="left"></li>
                   <li class="right"></li>
                </ul>
            </div>
        </div>
        
    </div>
    <!--MainBody End-->
</asp:Content>