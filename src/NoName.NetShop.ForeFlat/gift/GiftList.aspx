<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GiftList.aspx.cs" Inherits="NoName.NetShop.ForeFlat.gift.GiftList" %>
<%@ Register Assembly="NoName.Utility" Namespace="NoName.Utility" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMain" runat="server">
  
    <!--Position Begin-->
    <div class="currentPosition">
    	您现在的位置: <a href="#">首页</a> &gt;&gt; <a href="#">礼品兑换</a>
    </div>
    <!--Position End-->
    
    <!--MainBody Begin-->
    <div class="giftList_mainbody newline clearfix">
        <div class="box1">
            <ul class="title">
                <li class="left"></li>
                <li><span>礼品列表</span></li>
                <li class="right"></li>
            </ul>
            <div class="content">
                <div id="productList" class="list_horizontal">
                    <ul>
                    <asp:Repeater runat="server" ID="rpProducts">
                    <ItemTemplate>
                        <li>
                            <a href="GiftDetail.aspx?productId=<%# Eval("ProductId") %>" title="<%# Eval("ProductName") %>">
                                <img src="<%# Eval("SmallImage") %>" alt="<%# Eval("ProductName") %>" />
                                <span class="price">兑换积分：<%# Eval("Score") %></span>
                                <span class="name" title="<%# Eval("ProductName") %>"><%# Eval("ProductName") %></span>
                            </a>
                        </li>                    
                    </ItemTemplate>
                    </asp:Repeater>
                    </ul>
                    <div class="paginationContainer">
                        <div class="line"></div>
                        <div class="pagination">
<cc1:AspNetPager ID="pageNav" runat="server" OnPageChanged="pageNav_ChangePageIndex" >
   </cc1:AspNetPager>

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
