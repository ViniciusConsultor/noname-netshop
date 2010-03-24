<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QuestionList.aspx.cs" MasterPageFile="~/Site.Master" Inherits="NoName.NetShop.ForeFlat.Product.QuestionList" %>
<%@ Register Assembly="NoName.Utility" Namespace="NoName.Utility" TagPrefix="cc1" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="head"></asp:Content>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="cpMain">
    <!--Position Begin-->
    <div class="currentPosition">
    	您现在的位置: <a href="#">首页</a> &gt;&gt; <a href="#">购物街</a> &gt;&gt; <a href="#">查看产品咨询</a>
    </div>
    <!--Position End-->
    
    <!--MainBody Begin-->
    <div class="questions_mainbody newline clearfix">
        <div class="box1 noPadding">
            <ul class="title">
                <li class="left"></li>
                <li><span>查看 <asp:Literal runat="server" ID="Literal_ProductName1" /> 的全部相关咨询</span></li>
                <li class="right"></li>
            </ul>
            <div class="content">
                <div class="productGeneralProperties padding">
                    <div class="thumbnail" onmousemove="zoomInThumb(event,this);" onmouseover="zoomInThumb(event,this);">
                        <asp:Image runat="server" ID="Image_SmallImage" />
                        <div class="targetArea"></div>
                        <div class="zoomInArea">
                            <asp:Image runat="server" ID="Image_LargeImage" />
                        </div>
                    </div>
                    <div class="properties">
                        <ul>
                            <li>
                                <h1><asp:Literal runat="server" ID="Literal_ProductName2" /></h1>
                            </li> 
                            <li>
                                <span class="field">商品编号：</span><span><asp:Literal runat="server" ID="Literal_ProductID" /></span>
                            </li>
                            <li>
                                <span class="field">市 场 价：</span><span class="marketPrice">￥<asp:Literal runat="server" ID="Literal_TradePrice" /></span>
                            </li>
                            <li>
                                <span class="field ddPriceField">鼎 鼎 价：</span><span class="ddPrice">￥<asp:Literal runat="server" ID="Literal_MerchantPrice" /></span>
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
                                <asp:HyperLink runat="server" ID="HyperLink_Buy" CssClass="purchase" />
                                <asp:HyperLink runat="server" ID="HyperLink_Favorite" CssClass="addToFavorite" />
                            </li>
                        </ul>
                    </div>
                </div>
                
                <div class="box7">
                    <div class="title">该商品的全部相关咨询</div>
                    <div class="content">
                        <ul class="questions">
                            <asp:Repeater runat="server" ID="Repeater_Question">
                                <ItemTemplate>
                                    <li class="odd">
                                        <div class="question">
                                            <span class="user">天空的白云：</span>
                                            <span>请问你们可以提供正规发票吗？</span>
                                            <span class="date">2009-3-3</span>
                                        </div>
                                        <div class="answer">
                                            <span class="answerer">鼎视回答：</span>
                                            <span>您好。可以提供发票。谢谢您的提问。</span>
                                            <span class="date">2009-3-3</span>
                                        </div>
                                    </li>
                                </ItemTemplate>
                                <AlternatingItemTemplate>
                                    <li class="even">
                                        <div class="question">
                                            <span class="user">天空的白云：</span>
                                            <span>怎么安装系统啊？急！！！</span>
                                            <span class="date">2009-3-3</span>
                                        </div>
                                        <div class="answer">
                                            <span class="answerer">鼎视回答：</span>
                                            <span>您好！标配 linux系统，安装XP系统的话将安装光盘放入光驱，让系统从光盘启动，进入安装界面按照提示一步步的设置就可以了，感谢您对鼎视的支持！祝您购物愉快！</span>
                                            <span class="date">2009-3-3</span>
                                        </div>
                                    </li>
                                </AlternatingItemTemplate>
                            </asp:Repeater>
                        </ul>
                        <div class="paginationParent">
                            <div class="pagination">
                                <cc1:AspNetPager CssClass="pagerclass" ID="AspNetPager" runat="server" PageSize="12"
                                    UrlPageIndexName="" AlwaysShow="true" ImagePath="/" FirstPageText='首页'
                                    LastPageText='末页' NextPageText='下一页' OnPageChanged="AspNetPager_PageChanged"
                                    PrevPageText='上一页' ShowBoxThreshold="16" NumericButtonCount="8"
                                    ShowPrevNext="True" SubmitButtonClass="buttom" 
                                    NumericButtonTextFormatString=''>
                                </cc1:AspNetPager>
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
                            	<asp:TextBox runat="server" ID="TextBox_QuestionContent" TextMode="MultiLine" CssClass="textarea4" />
                            </li>
                            <li class="submit">
                                <asp:LinkButton runat="server" ID="Button_Question" OnClick="Button_Question_Click" Text="提交咨询" CssClass="button_blue" />
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