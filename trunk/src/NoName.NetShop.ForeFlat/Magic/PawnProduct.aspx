<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PawnProduct.aspx.cs" MasterPageFile="~/Site.Master" Inherits="NoName.NetShop.ForeFlat.Magic.PawnProduct" %>

<asp:Content ID="ContentHeader" ContentPlaceHolderID="head" runat="server">
    <link type="text/css" rel="stylesheet" href="/css/magic.css" />
    <script type="text/javascript" src="/js/magicworld.pawnshop.js"></script>
</asp:Content>

<asp:Content ID="ContentBody" ContentPlaceHolderID="cpMain" runat="server">    
    <!--Position Begin-->
    <div class="currentPosition">
    	您现在的位置: <a href="/">首页</a> &gt;&gt; <a href="/channel/magic">魔力世界</a> &gt;&gt; <a href="/Magic/PawnShop.aspx">视听当铺</a> &gt;&gt; <a href="#">典当品详情</a>
        <div class="magicSubNav">
            <div class="magicButtonTab">
                <a class="button_blue" href="/Magic/RentHome.aspx">视听租赁</a>
                <a class="button_blue" href="/Magic/DealHome.aspx">二手交易</a>
                <a class="button_blue2" href="/Magic/PawnShop.aspx">视听当铺</a>
                <a class="button_blue" href="/Magic/AuctionHome.aspx">视听拍卖</a>
            </div>
        </div>
    </div>
    <!--Position End-->
    
    <!--MainBody Begin-->
    <div class="magicPawnShopDetail_mainbody clearfix newline">
        <div class="box1">
            <ul class="title">
                <li class="left"></li>
                <li><span>拍卖品详情</span></li>
                <li class="right"></li>
            </ul>
            <div class="content">
                        <div class="productGeneralProperties padding">
                            <div class="thumbnail" onmousemove="zoomInThumb(event,this);" onmouseover="zoomInThumb(event,this);">
                                <asp:Image runat="server" ID="Image_Small" />
                                <div class="targetArea"></div>
                                <div class="zoomInArea">
                                    <asp:Image runat="server" ID="Image_Medium" />
                                </div>
                            </div>                            
                            <div style="display:none" id="confirmationContent">
                                <ul class="form" style="padding:40px 20px 0 20px;">
                                	<li>
                                    	<span class="field">联系人</span>
                                        <asp:Literal runat="server" ID="Literal_UserID2" />
                                    </li>
                                    <li>
                                    	<span class="field">电　话</span>
                                        <asp:Literal runat="server" ID="Literal_Phone" />
                                    </li><li>
                                    	<span class="field">地　址</span>
                                        <asp:Literal runat="server" ID="Literal_Address" />
                                    </li>
                                </ul>
                            </div>
                            <script type="text/javascript">
                                var pawnShopRules = new Rainy.popupWindow({
                                    id: "purchaseConfirmation",
                                    width: 320,
                                    height: 200,
                                    cls: "",
                                    title: "请按照如下信息联系卖家",
                                    content: document.getElementById("confirmationContent").innerHTML
                                });
							</script>
                            <div class="properties">
                                <ul>
                                    <li>
                                        <h1><asp:Literal runat="server" ID="Literal_ProductName" /></h1>
                                    </li> 
                                    <li>
                                        <span class="field ddPriceField">价　　格：</span><span class="ddPrice">￥<asp:Literal runat="server" ID="Literal_Price" /></span>
                                    </li>
                                    <li>
                                        <span class="field">来　　源：</span><span><a href="javascript:void(0)" onclick="pawnShopRules.render()"><asp:Literal runat="server" ID="Literal_UserID" /></a>(典藏品)</span>
                                    </li>
                                    <li class="buttons">
                                        <a class="purchase" href="javascript:void(0)" onclick="pawnShopRules.render()"></a>
                                    </li>
                                </ul>
                            </div>
                        </div>
                        <div class="box7">
                            <div class="title">商品简介</div>
                            <div class="content">
                                <p class="description">
                                    <asp:Literal runat="server" ID="Literal_Brief" />
                                </p>
                            </div>
                        </div>
                
                <div class="box7">
                    <div class="title">产品评价</div>
                    <div class="content">
                        <div class="table3">
                            <table>
                              <tr>
                                <th>用户名</th>
                                <th>内容</th>
                                <th>时间</th>
                              </tr>
                              <asp:Repeater runat="server" ID="Repeater_Comment">
                                  <ItemTemplate>
                                      <tr>
                                          <td><span><%# Eval("userid") %></span></td>
                                          <td><p><%# Eval("content") %></p></td>
                                          <td><%# Convert.ToDateTime(Eval("createtime")).ToString("yyyy年MM月dd日") %></td>
                                      </tr>                                                
                                  </ItemTemplate>
                              </asp:Repeater>
                            </table>
                        </div>
                        <div class="leaveComment">
                            <div class="title">我来说几句</div>
                            <textarea id="comment-content"></textarea>
                            <input type="text" id="comment-validate" />
                            <img id="comment-validate-image" src="../ValiateCode.aspx" onclick="this.src='../ValiateCode.aspx?_='+new Date().getUTCMilliseconds()" />
                            <input pwid='<%= PawnProductID %>' type="button" id="comment-button" class"button_blue" value="发表" />
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