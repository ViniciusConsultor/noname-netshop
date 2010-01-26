<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CommentList.aspx.cs" MasterPageFile="~/Site.Master" Inherits="NoName.NetShop.ForeFlat.Product.CommentList" %>
<%@ Register Assembly="NoName.Utility" Namespace="NoName.Utility" TagPrefix="cc1" %>

<asp:Content runat="server" ContentPlaceHolderID="head"></asp:Content>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="cpMain">
    <form id="form1" runat="server">
    
    <!--Position Begin-->
    <div class="currentPosition">
    	您现在的位置: <a href="/">首页</a> &gt;&gt; <a href="#">购物街</a> &gt;&gt; <a href="#">查看产品评论</a>
    </div>
    <!--Position End-->
    
    <!--MainBody Begin-->
    <div class="comments_mainbody newline clearfix">
        <div class="box1 noPadding">
            <ul class="title">
                <li class="left"></li>
                <li><span>查看 <asp:Literal runat="server" ID="Literal_ProductName1" /> 的全部评论</span></li>
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
                    <div class="title">商品全部评论(已有<asp:Literal runat="server" ID="Literal_CommentCount" />人在此发表了评论)</div>
                    <div class="content">
                        <ul class="comments">
                            <asp:Repeater runat="server" ID="Repeater_Comments">
                                <ItemTemplate>
                                    <li>
                                        <img src="images/memberLevel1.gif" />
                                        <div class="commentRightContent">
                                            <div class="commentRightContentContainer">
                                                <div class="userInfo">
                                                    <span class="user">天空的白云</span>
                                                    <span>(双钻会员)</span>
                                                    <div class="rating">
                                                        <a href="javascript:void(0)" class="on"></a>
                                                        <a href="javascript:void(0)" class="on"></a>
                                                        <a href="javascript:void(0)" class="on"></a>
                                                        <a href="javascript:void(0)"></a>
                                                        <a href="javascript:void(0)"></a>
                                                    </div>
                                                    <span class="date">2009-02-23</span>
                                                </div>
                                                <div class="commentContent">
                                                    这个东西很好很强大？
                                                </div>
                                            </div>
                                        </div>
                                    </li>
                                </ItemTemplate>
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
                    <div class="title">发表评论</div>
                    <div class="content">
                    	<ul class="form">
                        	<li>
                            	<span class="field">打分</span>
                                <div class="section">
                                    <input class="radio" type="radio" name="rating" />
                                    <div class="component">
                                        <div class="rating">
                                            <a href="javascript:void(0)" class="on"></a>
                                            <a href="javascript:void(0)"></a>
                                            <a href="javascript:void(0)"></a>
                                            <a href="javascript:void(0)"></a>
                                            <a href="javascript:void(0)"></a>
                                        </div>
                                    </div>
                                    <label>很不喜欢</label>
                                </div>
                                <div class="section">
                                    <input class="radio" type="radio" name="rating" />
                                    <div class="component">
                                        <div class="rating">
                                            <a href="javascript:void(0)" class="on"></a>
                                            <a href="javascript:void(0)" class="on"></a>
                                            <a href="javascript:void(0)"></a>
                                            <a href="javascript:void(0)"></a>
                                            <a href="javascript:void(0)"></a>
                                        </div>
                                    </div>
                                    <label>不喜欢</label>
                                </div>
                                <div class="section">
                                    <input class="radio" type="radio" name="rating" />
                                    <div class="component">
                                        <div class="rating">
                                            <a href="javascript:void(0)" class="on"></a>
                                            <a href="javascript:void(0)" class="on"></a>
                                            <a href="javascript:void(0)" class="on"></a>
                                            <a href="javascript:void(0)"></a>
                                            <a href="javascript:void(0)"></a>
                                        </div>
                                    </div>
                                    <label>还行</label>
                                </div>
                                <div class="section">
                                    <input class="radio" type="radio" name="rating" />
                                    <div class="component">
                                        <div class="rating">
                                            <a href="javascript:void(0)" class="on"></a>
                                            <a href="javascript:void(0)" class="on"></a>
                                            <a href="javascript:void(0)" class="on"></a>
                                            <a href="javascript:void(0)" class="on"></a>
                                            <a href="javascript:void(0)"></a>
                                        </div>
                                    </div>
                                    <label>喜欢</label>
                                </div>
                                <div class="section">
                                    <input class="radio" type="radio" name="rating" />
                                    <div class="component">
                                        <div class="rating">
                                            <a href="javascript:void(0)" class="on"></a>
                                            <a href="javascript:void(0)" class="on"></a>
                                            <a href="javascript:void(0)" class="on"></a>
                                            <a href="javascript:void(0)" class="on"></a>
                                            <a href="javascript:void(0)" class="on"></a>
                                        </div>
                                    </div>
                                    <label>非常喜欢</label>
                                </div>
                            </li>
                            <li>
                            	<span class="field">评论内容</span>
                            	<asp:TextBox runat="server" ID="TextBox_CommentContent" TextMode="MultiLine" CssClass="textarea4"></asp:TextBox>
                            </li>
                            <li class="submit">
                                <asp:LinkButton runat="server" ID="Button_Comment" OnClick="Button_Comment_Click" Text="发表评论" CssClass="button_blue" />
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
    </form>
</asp:Content>