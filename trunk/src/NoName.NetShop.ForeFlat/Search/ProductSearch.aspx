<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductSearch.aspx.cs" Title="搜索结果-鼎鼎商城" MasterPageFile="~/Site.Master" Inherits="NoName.NetShop.ForeFlat.Search.ProductSearch" %>


<asp:Content ContentPlaceHolderID="head" runat="server" ID="Head">
    <script src="/js/hashtable.js" type="text/javascript"></script>
    <script src="/js/common.search.js" type="text/javascript"></script>
</asp:Content>

<asp:Content ContentPlaceHolderID="cpMain" runat="server" ID="Body">
    <!--MainBody Begin-->
    <div class="shoppingClass_mainbody newline clearfix">
        <div class="leftColumn" id="DivLeft" runat="server">
                        
        </div>
        <div class="rightColumn">
        	<div class="rightColumnContainer">        	
            	<div class="box8 newline">
                    <ul class="title">
                        <li class="left"></li>
                        <li class="heading">
                            <span class="text">
                                <asp:Literal runat="server" ID="Literal_SearchInfo" />
                            </span>
                            <span class="arrow"></span>
                        </li>
                        <li class="right"></li>
                        <li class="view">
                        	<span>显示方式</span>
                            <a class="viewBtn horizontal_on" href="javascript:void(0)" onclick="viewTransfer(this)"></a>
                            <a class="viewBtn vertical" href="javascript:void(0)" onclick="viewTransfer(this)"></a>
                        </li>
                        <li class="sort">
                            <span>请选择排序方式</span>
							<a style="cursor:pointer;" field="changetime" type="0">上架时间</a>
                            <a style="cursor:pointer;" field="sales" type="0">销量</a>
                            <div class="sortByPrice" onmouseover="showPriceSortDropdownList(this)" onmouseout="hidePriceSortDropdownList(this)">
                                <a href="#" field="price">价格</a>
                                <ul class="priceSortOptions" id="priceSortOptions">
                                    <li>
                                        <a style="cursor:pointer;" field="price" type="0">低 - 高</a>
                                    </li>
                                    <li>
                                        <a style="cursor:pointer;" field="price" type="1">高 - 低</a>
                                    </li>
                                </ul>
                            </div>
                            <a style="cursor:pointer;" field="hit" type="0">浏览量</a>
                        </li>
                    </ul>
                    <div class="content">
						<div id="productList" class="list_horizontal">
                            <ul>
                                <asp:Repeater runat="server" ID="Repeater_ProductList">
                                    <ItemTemplate>
                                        <li>
                                            <a href='/product-<%# Eval("entityidentity") %>.html' title='<%# Eval("productname") %>' target="_blank">
                                                <img src='<%# NoName.NetShop.Product.Facade.ProductMainImageRule.GetMainImageUrl(Eval("productimage").ToString()) %>' />
                                                <span class="price">鼎城报价：￥<%# Eval("price") %></span>
                                                <span class="name" title='<%# Eval("productname") %>'><%# Eval("productname") %></span>
                                                <span class="commentsNum"></span>
                                            </a>
                                            <div class="actions">
                                                <a class="button_blue3" href="/product-<%# Eval("entityidentity") %>.html" target="_blank">
                                                    <span class="left"></span>
                                                    <span class="text">购买</span>
                                                    <span class="right"></span>
                                                </a>
                                                <a class="button_blue3" fav="true" style="cursor:pointer" productid="<%# Eval("entityidentity") %>">
                                                    <span class="left"></span>
                                                    <span class="text">收藏</span>
                                                    <span class="right"></span>
                                                </a>
                                                <a class="button_blue3" comp="true" productid="<%# Eval("entityidentity") %>" productname="<%# Eval("productname") %>" category="{categoryid}" image="{smallimage}" href="javascript:void(0)">
                                                    <span class="left"></span>
                                                    <span class="text">对比</span>
                                                    <span class="right"></span>
                                                </a>
                                            </div>
                                        </li>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </ul>
                            <div class="paginationContainer">
                            	<div class="line"></div>
                                <div class="pagination" id="Pagination" runat="server">
                                    <a class="prev" href="#"></a>
                                    <div class="pageNum">
                                        <a class="on" href="#">1</a>
                                        <a href="#">2</a>
                                        <a href="#">3</a>
                                        <a href="#">4</a>
                                        <a href="#">5</a>
                                        <a href="#">6</a>
                                        <a href="#">7</a>
                                    </div>
                                    <a class="next" href="#"></a>
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
        </div>
    </div>
    <!--MainBody End-->
    
                <div class="comparisonWindow" id="comparisonWindow" style="width:220px;">
                    <xsl:text> </xsl:text>
                </div>
                <script type="text/javascript">
                    window.onscroll = window.onload = window.onresize = function() {
                        var comparisonWindow = document.getElementById("comparisonWindow");
                        var scrollTop = document.documentElement.scrollTop;
                        var middleCoordinateY = parseInt((document.documentElement.clientHeight - comparisonWindow.clientHeight) / 2);
                        comparisonWindow.style.top = (scrollTop + middleCoordinateY) + "px";
                    }
                </script>
</asp:Content>