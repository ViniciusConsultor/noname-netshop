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
                    <asp:Literal runat"server" ID="Literal_Rule" />
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
                                        <a href="/group/product.aspx?productid=<%# Eval("productid") %>" class="rank"><span class="rankIndex R1"></span></a>
                                        <a href="/group/product.aspx?productid=<%# Eval("productid") %>" class="name"><%# Eval("productname") %> </a>
                                        <a href="/group/product.aspx?productid=<%# Eval("productid") %>" class="price">￥<%# Eval("groupprice") %></a>
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