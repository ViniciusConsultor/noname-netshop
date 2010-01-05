<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShowTopic.aspx.cs" Inherits="NoName.NetShop.ForeFlat.qa.ShowTopic" %>
<%@ Register Assembly="NoName.Utility" Namespace="NoName.Utility" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMain" runat="server">
    <!--Position Begin-->
    <div class="currentPosition">
    	您现在的位置: <a href="#">首页</a> &gt;&gt; <a href="#">购物街</a> &gt;&gt; <a href="#">影像商品</a> &gt;&gt; <a href="#">查看产品话题</a>
    </div>
    <!--Position End-->
    
    <!--MainBody Begin-->
    <div class="topics_mainbody newline clearfix">
        <div class="box1 noPadding">
            <ul class="title">
                <li class="left"></li>
                <li><span>查看 <asp:Literal runat="server" ID="litTopProductName"></asp:Literal> 的全部话题</span></li>
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
                    <div class="title">该商品的全部相关话题</div>
                    <div class="content">
                        <div class="table3">
                            <table>
                              <tr>
                                <th>主题</th>
                                <th>回复</th>
                                <th>最后发表</th>
                              </tr>
                              <asp:Repeater runat="server" ID="gvList">
                              <ItemTemplate>
                              <tr>
                                <td><a href="#"><%#Eval("Title") %></a><span><%# Eval("LastReplyTime", "{0:yyyy-MM-dd HH:mm}")%></span></td>
                                <td><%#Eval("ReplyNum")%></td>
                                <td><span><%#Eval("UserId") %></span></td>
                              </tr>                              
                              </ItemTemplate>
                              </asp:Repeater>
                            </table>
                        </div>
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
                    <div class="title">发表话题</div>
                    <div class="content">
                    	<ul class="form">
                            <li>
                            	<span class="field">主　　题</span>
                            	<asp:TextBox runat="server" ID="txtTile" CssClass="title"></asp:TextBox>
                            </li>
                            <li>
                            	<span class="field">话题内容</span>
                            	<asp:TextBox runat="server" ID="txtContent" TextMode="MultiLine" CssClass="content"></asp:TextBox>
                            </li>
                            <li class="submit">
                                <asp:Button CssClass="button_blue" runat="server" ID="btnDoQuestion" 
                                    onclick="btnDoQuestion_Click" Text="提交话题" />
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
