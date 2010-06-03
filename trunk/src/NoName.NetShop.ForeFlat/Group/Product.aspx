<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Product.aspx.cs" Inherits="NoName.NetShop.ForeFlat.Group.Product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link type="text/css" rel="stylesheet" href="/css/grouppurchase.css" />
    <script type="text/javascript">
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cpMain" runat="server">
    <!--Position Begin-->
    <div class="currentPosition">
    	您现在的位置: <a href="/">首页</a> &gt;&gt; <a href="/channle/group.html">团购</a> &gt;&gt; <a href="#">商品详情</a>
    </div>
    <!--Position End-->
    
    <!--MainBody Begin-->
    <div class="magicGroupPurchaseDetail_mainbody clearfix newline">
        <div class="box1 newline">
            <ul class="title">
                <li class="left"></li>
                <li><span>商品详情</span></li>
                <li class="right"></li>
            </ul>
            <div class="content">
                        <div class="productGeneralProperties padding">
                            <div class="thumbnail" onmousemove="zoomInThumb(event,this);" onmouseover="zoomInThumb(event,this);">
                                <asp:Image runat="server" ID="Image_Small" />
                                <div class="targetArea"></div>
                                <div class="zoomInArea">
                                    <asp:Image runat="server" ID="Image_Big" />
                                </div>
                            </div>
                            <div class="properties">
                                <ul>
                                    <li>
                                        <h1><asp:Literal runat="server" ID="Literal_ProductName" /></h1>
                                    </li>
                                    <li>
                                        <span class="field">市 场 价：</span>
                                        <span class="marketPrice">￥<asp:Literal runat="server" ID="Literal_MarketPrice" /></span>
                                </li> 
                                    <li>
                                        <span class="field ddPriceField">团 购 价：</span>
                                        <span class="ddPrice">￥<asp:Literal runat="server" ID="Literal_GroupPrice" /></span>
                                    </li>
                                    <li>
                                        <span class="field">起止时间：</span>
                                        <span><asp:Literal runat="server" ID="Literal_Time" /></span>
                                    </li>
                                    <li>
                                        <span class="field">成团人数：</span>
                                        <span><asp:Literal runat="server" ID="Literal_Count" /></span>
                                    </li>
                                    <li>
                                        <span class="field">当前人数：</span>
                                        <span class="important">
                                            <strong><asp:Literal runat="server" ID="Literal_CurrentCount" /></strong>
                                        </span>
                                	</li>
                                </ul>
                            </div>
                        </div>
                        <asp:Literal runat="server" ID="Literal_Detail" Visible="false" />
                        <div class="box7">
                            <div class="title">商品简介</div>
                            <div class="content">
                                <p class="description">
                                    <asp:Literal runat="server" ID="Literal_Brief" />
                                </p>
                            </div>
                        </div>
                
                <div class="box7">
                    <div class="title">团购列表</div>
                    <div class="content">
                        <div class="table3">
                            <table>
                              <tr>
                                <th>用户名</th>
                                <th>内容</th>
                                <th>时间</th>
                              </tr>
                              <asp:Repeater runat="server" ID="Repeater_ApplyList">
                                <ItemTemplate>
                                  <tr>
                                    <td><span><%# Eval("userid") %></span></td>
                                    <td><p><%# Eval("applybrief") %></p></td>
                                    <td><%# Convert.ToDateTime(Eval("applytime")).ToString("yyyy年MM月dd日") %></td>
                                  </tr>                                    
                                </ItemTemplate>
                              </asp:Repeater>
                            </table>
                        </div>
                        <div class="leaveComment">
                            <div class="title">我要报名</div>
                            <asp:TextBox runat="server" ID="TextBox_Message" TextMode="MultiLine" />
                            <asp:TextBox runat="server" ID="TextBox_ValidateCode" />
                            <img src="/ValiateCode.aspx" style="cursor:pointer" onclick="this.src='/ValiateCode.aspx?_='+new Date().toUTCString()" />
                            <asp:LinkButton runat="server" ID="Button_Submit" Text="报 名" CssClass="button_blue" OnClick="Button_Submit_Click" />
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
    <!--MainBody End-->
</asp:Content>