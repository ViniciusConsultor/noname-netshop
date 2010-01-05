<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShowQuestion.aspx.cs" Inherits="NoName.NetShop.ForeFlat.qa.ShowQuestion" %>
<%@ Register Assembly="NoName.Utility" Namespace="NoName.Utility" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMain" runat="server">
    <!--Position Begin-->
    <div class="currentPosition">
    	您现在的位置: <a href="#">首页</a> &gt;&gt; <a href="#">购物街</a> &gt;&gt; <a href="#">影像商品</a> &gt;&gt; <a href="#">查看产品咨询</a>
    </div>
    <!--Position End-->
    
    <!--MainBody Begin-->
    <div class="questions_mainbody newline clearfix">
        <div class="box1 noPadding">
            <ul class="title">
                <li class="left"></li>
                <li><span>查看 <asp:Literal runat="server" ID="litTopProductName"></asp:Literal> 的全部相关咨询</span></li>
                <li class="right"></li>
            </ul>
            <div class="content">
                <div class="productGeneralProperties padding">
                    <div class="thumbnail" onmousemove="zoomInThumb(event,this);" onmouseover="zoomInThumb(event,this);">
                        <asp:Image runat="server" ID="imgProductM" />
                        <div class="targetArea"></div>
                        <div class="zoomInArea">
                            <asp:Image runat="server" ID="imgProductL" />
                        </div>
                    </div>
                    <div class="properties">
                        <ul>
                            <li>
                                <h1><asp:Literal runat="server" ID="litProductName"></asp:Literal></h1>
                            </li> 
                            <li>
                                <span class="field">商品编号：</span><span><asp:Literal runat="server" ID="litProductId"></asp:Literal></span>
                            </li>
                            <li>
                                <span class="field">市 场 价：</span><span class="marketPrice">￥<asp:Literal runat="server" ID="litTradePrice"></asp:Literal></span>
                            </li>
                            <li>
                                <span class="field ddPriceField">鼎 鼎 价：</span><span class="ddPrice">￥<asp:Literal runat="server" ID="litMerchantPrice"></asp:Literal></span>
                            </li>
                            <li>
                                <span class="field">库存状态：</span><span><asp:Literal runat="server" ID="litStock"></asp:Literal></span>
                            </li>
                            <li>
                                <span class="field">评　　分：</span>
                                <div class="rating">
                                    <a class="on" href="javascript:void(0)"></a>
                                    <a class="on" href="javascript:void(0)"></a>
                                    <a class="on" href="javascript:void(0)"></a>
                                    <a href="javascript:void(0)"></a>
                                    <a href="javascript:void(0)"></a>
                                </div>
                            </li>
                            <li class="buttons">
                                <a class="purchase" href="#"></a>
                                <a class="addToFavorite" href="#"></a>
                            </li>
                        </ul>
                    </div>
                </div>
                
                <div class="box7">
                    <div class="title">该商品的全部相关咨询</div>
                    <div class="content">
                        <ul class="questions">
                        <asp:Repeater runat="server" ID="rpList" onitemdatabound="rpList_ItemDataBound">
                        <ItemTemplate>
                            <li class="odd">
                                <div class="question">
                                    <span class="user"><%#Eval("UserId") %>：</span>
                                    <span><%#Eval("Content") %></span>
                                    <span class="date"><%#Eval("InsertTime", "{0:yyyy-MM-dd HH:mm}")%></span>
                                </div>
                                <div class="answer">
                                <asp:Repeater runat="server" ID="rpSubList">
                                <ItemTemplate>
                                    <span class="answerer">鼎视回答：</span>
                                    <span><%#Eval("Content") %></span>
                                    <span class="date"><%#Eval("AnswerTime","{0:yyyy-MM-dd HH:mm}") %></span>
                                </ItemTemplate>
                                </asp:Repeater>
                                </div>
                            </li>
                        </ItemTemplate>
                        <AlternatingItemTemplate>
                            <li class="even">
                                <div class="question">
                                    <span class="user"><%#Eval("UserId") %>：</span>
                                    <span><%#Eval("Content") %></span>
                                    <span class="date"><%#Eval("InsertTime", "{0:yyyy-MM-dd HH:mm}")%></span>
                                </div>
                                <div class="answer">
                                <asp:Repeater runat="server" ID="rpSubList">
                                <ItemTemplate>
                                    <span class="answerer">鼎视回答：</span>
                                    <span><%#Eval("Content") %></span>
                                    <span class="date"><%#Eval("AnswerTime","{0:yyyy-MM-dd HH:mm}") %></span>
                                </ItemTemplate>
                                </asp:Repeater>
                                </div>
                            </li>
                        </AlternatingItemTemplate>
                        </asp:Repeater>
                            
                        </ul>
                        <div class="paginationParent">
                            <div class="pagination">
            <cc1:aspnetpager  ID="pageNav" runat="server" PageSize="12"
                UrlPageIndexName="" AlwaysShow="true" ImagePath="/" FirstPageText='首页'
                LastPageText='末页' NextPageText='下一页'
                PrevPageText='上一页' ShowBoxThreshold="16" NumericButtonCount="8"
                ShowPrevNext="True" SubmitButtonClass="buttom" 
                NumericButtonTextFormatString='' onpagechanged="pageNav_PageChanged">
            </cc1:aspnetpager>
                            </div>
                        </div>
                    </div>
                </div>
                
                <div class="box7">
                    <div class="title">我要咨询</div>
                    <div class="content">
                    	<ul class="form">
                            <li>
                            	<span class="field">咨询内容</span>
                                <asp:TextBox TextMode="MultiLine" runat="server" id="txtContent" CssClass="textarea4"></asp:TextBox>
                            </li>
                            <li class="submit">
                            	<asp:LinkButton runat="server" ID="lbtnDoQuestion" CssClass="button_blue" 
                                    Text="提交咨询" onclick="lbtnDoQuestion_Click"></asp:LinkButton>
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
