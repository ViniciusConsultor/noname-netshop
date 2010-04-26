<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ShowSuitCart.aspx.cs" Inherits="NoName.NetShop.ForeFlat.sp.ShowSuitCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMain" runat="server">
    <!--Position Begin-->
    <div class="currentPosition">
        您现在的位置: <a href="#">首页</a> &gt;&gt; 购物车
    </div>
    <!--Position End-->
    <!--MainBody Begin-->
    <div class="shoppingCart_mainbody clearfix newline">
        <div class="box1">
            <ul class="title">
                <li class="left"></li>
                <li><span>我的购物车</span></li>
                <li class="right"></li>
            </ul>
            <div class="content centerText">
                <div class="shoppingNavigation2">
                </div>
                <div class="table1">
                    <table>
                        <tr>
                            <th>
                                <span>商品名称</span>
                            </th>
                            <th>
                                <span>鼎鼎价</span>
                            </th>
                            <th>
                                <span>数量</span>
                            </th>
                            <th>
                                <span>赠送积分</span>
                            </th>
                            <th>
                                <span>单价合计</span>
                            </th>
                        </tr>
                        <asp:Repeater runat="server" ID="gvList" onitemcommand="gvList_ItemCommand">
                            <ItemTemplate>
                                <tr>
                                    <td>
                                        <a class="linkButton" href="<%# Eval("ProductUrl") %>" target="_blank"><%# Eval("ProductName") %></a>
                                    </td>
                                    <td>
                                        ￥<%# Convert.ToDecimal(Eval("MerchantPrice")).ToString("F2") %>
                                    </td>
                                    <td>
                                        <%# Eval("quantity") %>
                                    </td>
                                    <td>
                                        <span id='<%# Eval("Key") + "-score" %>'><%# Eval("TotalScore") %></span>
                                    </td>
                                    <td>
                                        ￥<span  id='<%# Eval("Key") + "-sum" %>'><%#Convert.ToDecimal(Eval("ProductSum")).ToString("F2") %></span>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                <tr class="bottom">
                                    <td colspan="5">
                                        合计金额：￥<%=String.Format("商品金额：{0} - 优惠金额：{1}= 订单金额：{2}",
                CurrentShopCart.ProductSum, CurrentShopCart.DerateFee, CurrentShopCart.TotalSum)%>元
                                    </td>
                                </tr>
                            </FooterTemplate>
                        </asp:Repeater>
                        <asp:Panel runat="server" ID="panNoData">
                            <tr class="bottom">
                                <td colspan="5">
                                    商城提示：您的购物车已清空。系统将在3秒后跳转至商城首页！
                                </td>
                            </tr>
                        </asp:Panel>
                    </table>
                </div>
                <div class="centerText">
                    <div class="submitButtons">
                        <a class="button_blue3" href="<%= CurrentShopCart.ContinueShopUrl %>"><span class="left"></span><span class="text">继续购物</span>
                            <span class="right"></span></a>
                             <asp:LinkButton runat="server" CssClass="button_blue3" ID="lbtnClear" 
                            onclick="lbtnClear_Click"><span class="left"></span>
                                <span class="text">清空购物车</span> <span class="right"></span></asp:LinkButton>   
                             <asp:LinkButton runat="server" ID="lbtnGoPay" CssClass="button_blue3" 
                            onclick="lbtnGoPay_Click"><span class="left"></span><span class="text">结算中心</span> <span class="right">
                                    </span></asp:LinkButton>
                    </div>
                </div>
            </div>
            <ul class="bottom">
                <li class="left"></li>
                <li class="right"></li>
            </ul>
        </div>
        <div class="box7 newline">
            <div class="title">直降特卖</div>
            <div class="content">
                <ul class="itemList3">
                    <asp:Repeater runat="server" ID="Repeater_Reduce">
                        <ItemTemplate>
                            <li>
                                <a href="/product-<%# Eval("productid") %>.html" title="<%# Eval("productname") %>">
                                    <img src="<%# Eval("mediumimage") %>" />
                                    <span><%# Eval("productname")%></span> 
                                </a>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </div>
        <div class="box7 newline">
            <div class="title">鼎鼎推荐</div>
            <div class="content">
                <ul class="itemList3">
                    <asp:Repeater runat="server" ID="Repeater_Recommend">
                        <ItemTemplate>
                            <li>
                                <a href="/product-<%# Eval("productid") %>.html" title="<%# Eval("productname") %>">
                                    <img src="<%# Eval("mediumimage") %>" />
                                    <span><%# Eval("productname")%></span> 
                                </a>
                            </li>                            
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </div>
        <div class="box7 newline">
            <div class="title">热卖榜单</div>
            <div class="content">
                <ul class="itemList3">
                    <asp:Repeater runat="server" ID="Repeater_HotSale">
                        <ItemTemplate>
                            <li>
                                <a href="/product-<%# Eval("productid") %>.html" title="<%# Eval("productname") %>">
                                    <img src="<%# Eval("mediumimage") %>" />
                                    <span><%# Eval("productname")%></span> 
                                </a>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </div>
    </div>
    <!--MainBody End-->
</asp:Content>
