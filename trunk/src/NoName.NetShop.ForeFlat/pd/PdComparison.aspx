<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PdComparison.aspx.cs" Inherits="NoName.NetShop.ForeFlat.pd.PdComparison" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMain" runat="server">
    <!--Position Begin-->
    <div class="currentPosition">
    	您现在的位置: <a href="#">首页</a> &gt;&gt; <a href="#">商品比较</a>
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
                    <li>
                        <a href="#" title="惠普14存经济型笔记本电脑包">
                            <img src="pictures/productPic.gif" />
                            <span>惠普14存经济型笔记本电脑包</span>
                        </a>
                    </li>
                    <li>
                        <a href="#" title="惠普14存经济型笔记本电脑包">
                            <img src="pictures/productPic.gif" />
                            <span>惠普14存经济型笔记本电脑包</span>
                        </a>
                    </li>
                    <li>
                        <a href="#" title="惠普14存经济型笔记本电脑包">
                            <img src="pictures/productPic.gif" />
                            <span>惠普14存经济型笔记本电脑包</span>
                        </a>
                    </li>
                    <li>
                        <a href="#" title="惠普14存经济型笔记本电脑包">
                            <img src="pictures/productPic.gif" />
                            <span>惠普14存经济型笔记本电脑包</span>
                        </a>
                    </li>
                    <li>
                        <a href="#" title="惠普14存经济型笔记本电脑包">
                            <img src="pictures/productPic.gif" />
                            <span>惠普14存经济型笔记本电脑包</span>
                        </a>
                    </li>
                    <li>
                        <a href="#" title="惠普14存经济型笔记本电脑包">
                            <img src="pictures/productPic.gif" />
                            <span>惠普14存经济型笔记本电脑包</span>
                        </a>
                    </li>
                </ul>
            </div>
        </div>
        
    </div>
    <!--MainBody End-->
</asp:Content>
