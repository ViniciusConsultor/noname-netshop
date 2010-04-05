<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsSearch.aspx.cs" MasterPageFile="~/Site.Master" Inherits="NoName.NetShop.ForeFlat.Search.NewsSearch" %>


<asp:Content ContentPlaceHolderID="head" runat="server" ID="Head">
    <script src="/js/common.search.js" type="text/javascript"></script>
</asp:Content>

<asp:Content ContentPlaceHolderID="cpMain" runat="server" ID="Body">
    <!--Position Begin-->
    <div class="currentPosition">
    	您现在的位置: <a href="#">首页</a> &gt;&gt; <a href="#">搜索结果</a>
    </div>
    <!--Position End-->
    
    <!--MainBody Begin-->
    <div class="searchResult_mainbody clearfix newline">
        <div class="box1">
            <ul class="title">
                <li class="left"></li>
                <li><span>搜索结果</span></li>
                <li class="right"></li>
            </ul>
            <div class="content">
                <div class="section padding2">
                    <div class="sheet1">
                        <ul class="articleList_3 bullet_2">                        
                            <asp:Repeater runat="server" ID="Repeater_NewsList">
                                <ItemTemplate>
                                    <li>
                                        <a href="/news-<%# Eval("entityidentity") %>"><%# Eval("title") %></a>
                                        <span><%# Convert.ToDateTime(Eval("createtime")).ToString("yyyy-MM-dd") %></span>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                        <div class="paginationParent">
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
                
            </div>
            <ul class="bottom">
               <li class="left"></li>
               <li class="right"></li>
            </ul>
        </div>

    </div>
    <!--MainBody End-->



</asp:Content>