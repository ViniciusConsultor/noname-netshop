<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="ProductCompare.aspx.cs" Inherits="NoName.NetShop.ForeFlat.Product.ProductCompare" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cpMain" runat="server">
    <!--Position Begin-->
    <div class="currentPosition">
    	您现在的位置: <a href="/">首页</a> &gt;&gt; <a href="#">商品比较</a>
    </div>
    <!--Position End-->
    
    <!--MainBody Begin-->
    <div class="Comparison_mainbody clearfix newline">
    	<div class="box1">
            <ul class="title">
                <li class="left"></li>
                <li><span>商品比较</span></li>
                <li class="right"></li>
            </ul>
            <div class="content centerText">
            	<div class="table1">
                    <table  id="tblProducts" runat="server">
                    </table>
                </div>
            </div>
            <ul class="bottom">
               <li class="left"></li>
               <li class="right"></li>
            </ul>
        </div>
        
        <div class="box7 newline">
            <div class="title">本站强烈推荐</div>
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
        
    </div>
    <!--MainBody End-->
</asp:Content>
