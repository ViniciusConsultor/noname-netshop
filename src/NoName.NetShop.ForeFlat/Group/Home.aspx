<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" MasterPageFile="~/Site.Master" Inherits="NoName.NetShop.ForeFlat.Group.List" %>


<asp:Content runat="server" ID="ContentHeader" ContentPlaceHolderID="head">
    <link type="text/css" rel="stylesheet" href="/css/groupPurchase.css" />
</asp:Content>

<asp:Content runat="server" ID="ContentBody" ContentPlaceHolderID="cpMain">

    <!--MainBody Begin-->
    <div class="banner newline">
    </div>
    <div class="magicGroupPurchaseHome_mainbody newline clearfix">
        <div class="leftColumn">
            <div class="box2">
                <ul class="title">
                    <li class="left"></li>
                    <li><span>团购规则</span></li>
                    <li class="right"></li>
                </ul>
                <div class="content">
					<p class="noSpacing">
                    	1. 进入时尚前沿中的高清之世界。新款 14 英寸 Gateway  TC 系列笔记本首先追求美观，然后增添性能，最后确保成品轻便。我们的 TC 系列便携式计算机采用红酒色或深黑色外观设计，使用 Linux 操作系统并配置最高使用 Linux 操作系统并配置最高英特尔  酷睿 2 双核处理器，配备可选英特尔 迅驰 2 处理器技术和 NVIDIA® GeForce  显卡，该机型具备更多您需要和您想要的性能。
                    </p>
                    <p class="noSpacing">
                    	2. 进入时尚前沿中的高清之世界。新款 14 英寸 Gateway  TC 系列笔记本首先追求美观，然后增添性能，最后确保成品轻便。我们的 TC 系列便携式计算机采用红酒色或深黑色外观设计，使用 Linux 操作系统并配置最高使用 Linux 操作系统并配置最高英特尔  酷睿 2 双核处理器的性能。
                    </p>
                </div>
                <ul class="bottom">
                   <li class="left"></li>
                   <li class="right"></li>
                </ul>
            </div>            
        </div>
        <div class="rightColumn">
        
            <div class="box2">
                <ul class="title">
                    <li class="left"></li>
                    <li><span>本站推荐团购</span></li>
                    <li class="right"></li>
                </ul>
                <div class="content">
                    <div class="hotlist">
                        <div class="tableHeader clearfix">
                            <div class="column column1">排名</div>
                            <div class="column column2">产品</div>
                            <div class="column column3">价格</div>
                        </div>
                        <ul class="listContent">
                            <asp:Repeater runat="server" ID="Repeater_Recommend">
                                <ItemTemplate>
                                    <li>
                                        <a href="#" class="rank"><span class="rankIndex R1"></span></a>
                                        <a href="#" class="name">[明基] MP512 </a>
                                        <a href="#" class="price">￥9998</a>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                </div>
                <ul class="bottom">
                   <li class="left"></li>
                   <li class="right"></li>
                </ul>
            </div>
            
             <div class="box2 newline">
                <ul class="title">
                    <li class="left"></li>
                    <li><span>网友问答</span></li>
                    <li class="right"></li>
                    <li class="more"></li>
                </ul>
                <div class="content">
                    <ul class="itemList7">
                        <asp:Repeater runat="server" ID="Repeater_QA">
                            <ItemTemplate>
                    	        <li>
                        	        <span>天空的百余：个人用户可以发起团购吗？</span>
                                    <span>管理员：可以。但是需要缴纳一定数额的保证金。</span>
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
        <div class="midColumn">
            <div class="midColumnContainer">
                <div class="box1">
                    <ul class="title">
                        <li class="left"></li>
                        <li><span>新开团</span></li>
                        <li class="right"></li>
                        <li class="more"></li>
                    </ul>
                    <div class="content">
                        <ul class="thumbnailList_1">
                            <asp:Repeater runat="server" ID="Repeater_NewGroup">
                                <ItemTemplate>
                                    <li>
                                        <a href="#"><img src="Pictures/productPic.gif" /></a>
                                        <a href="#">
                                            <span class="price">鼎城报价：￥188.00</span>
                                            <span class="name">伊莱克斯（Electrolux）</span>
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
                
                <div class="box1 newline">
                    <ul class="title">
                        <li class="left"></li>
                        <li><span>火热进行中</span></li>
                        <li class="right"></li>
                        <li class="more"></li>
                    </ul>
                    <div class="content">
                        <ul class="thumbnailList_1">
                            <asp:Repeater runat="server" ID="Repeater_Grouping">
                                <ItemTemplate>
                                    <li>
                                        <a href="#"><img src="Pictures/productPic.gif" /></a>
                                        <a href="#">
                                            <span class="price">鼎城报价：￥188.00</span>
                                            <span class="name">伊莱克斯（Electrolux）</span>
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
                
                <div class="box1 newline">
                    <ul class="title">
                        <li class="left"></li>
                        <li><span>即将结束</span></li>
                        <li class="right"></li>
                        <li class="more"></li>
                    </ul>
                    <div class="content">
                        <ul class="thumbnailList_1">
                            <asp:Repeater runat="server" ID="Repeater_Ending">
                                <ItemTemplate>
                                    <li>
                                        <a href="#"><img src="Pictures/productPic.gif" /></a>
                                        <a href="#">
                                            <span class="price">鼎城报价：￥188.00</span>
                                            <span class="name">伊莱克斯（Electrolux）</span>
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
        </div>
    </div>
    <!--MainBody End-->

</asp:Content>