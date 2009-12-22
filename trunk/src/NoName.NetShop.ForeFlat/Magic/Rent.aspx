<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Rent.aspx.cs" MasterPageFile="~/Site.Master" Inherits="NoName.NetShop.ForeFlat.Magic.Rent" %>

<asp:Content ID="ContentHeader" ContentPlaceHolderID="head" runat="server">
    <link type="text/css" rel="stylesheet" href="/css/magic.css" />
    <script src="../js/magicworld.rent.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function() {
            $('#<%= Button_Rent.ClientID %>').click(function() {
                return confirm("即将提交租赁申请，确认？");
            });
        });
    </script>
</asp:Content>

<asp:Content ID="ContentBody" ContentPlaceHolderID="cpMain" runat="server">
    <!--Position Begin-->
    <div class="currentPosition">
    	您现在的位置: <a href="#">首页</a> &gt;&gt; <a href="#">魔力世界</a> &gt;&gt; <a href="#">视听租赁</a> &gt;&gt; <a href="#">租赁品详情</a>
        <div class="magicSubNav">
            <div class="magicButtonTab">
                <a class="button_blue2" href="#">视听租赁</a>
                <a class="button_blue" href="#">二手交易</a>
                <a class="button_blue" href="#">视听当铺</a>
                <a class="button_blue" href="#">视听拍卖</a>
            </div>
        </div>
    </div>
    <!--Position End-->
    
    <!--MainBody Begin-->
    <div class="magicRentDetail_mainbody clearfix newline">
        <div class="box1">
            <ul class="title">
                <li class="left"></li>
                <li><span>出租品详情</span></li>
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
                                        <span class="field ddPriceField">月 租 金：</span><span class="ddPrice">￥<asp:Literal runat="server" ID="Literal_RentPrice" /></span>
                                    </li>
                                    <li>
                                        <span class="field">押　　金：</span><span>￥<asp:Literal runat="server" ID="Literal_Pledge" /></span>
                                    </li>
                                    <li>
                                        <span class="field">商品类别：</span><span><asp:Literal runat="server" ID="Literal_Category" /></span>
                                    </li>
                                    <li class="buttons">
                                        <asp:LinkButton CssClass="rent" ID="Button_Rent" runat="server" OnClick="Button_Rent_Click" />
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
                            <a id="comment-button" style="cursor:pointer" rentid='<%= RentID %>' class="button_blue">发表</a>
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