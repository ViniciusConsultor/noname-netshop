<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeProductList.aspx.cs" MasterPageFile="~/Site.Master" Inherits="NoName.NetShop.ForeFlat.Product.HomeProductList" %>
<%@ Register Assembly="NoName.Utility" Namespace="NoName.Utility" TagPrefix="cc1" %>

<asp:Content runat="server" ID="ContentHead" ContentPlaceHolderID="head">
    <script src="../js/jquery.js" type="text/javascript"></script>
    <script src="../js/hashtable.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(function() {

            //添加收藏事件
            $('.actions a[fav="true"]').click(function() {
                addFav($(this).attr('productid'));
            });

            //商品对比事件
            $('a.button_blue3[comp]').click(function() {
                addCompare({
                    productid: $(this).attr('productid'),
                    productname: $(this).attr('productname'),
                    categoryid: $(this).attr('category'),
                    image: $(this).attr('image')
                });
            });


            function addFav(productID) {
                $.ajax({
                    url: '/api/CartOpenApi.ashx',
                    type: 'post',
                    data: 'action=addfavorite&ctype=1&cid=' + productID,
                    cache: false,
                    dataType: 'json',
                    error: function() { alert('收藏失败,请稍后重试。'); },
                    success: function(data, textStatus) {
                        if (data.Result == true) {
                            alert('收藏成功！');
                        }
                        else if (data.Message.indexOf('登录') > 0) {
                            window.open('/login.aspx?returnurl=' + encodeURIComponent('/member/dofavorite.aspx?ctype=1&cid=' + productID));
                        }
                        else {
                            alert(data.Message);
                        }
                    }
                });
            }

            var comparingProducts = new Hashtable();

            function addCompare(p) {

                var topLayer = $('#comparisonWindow');

                if (topLayer.attr('category')) {
                    if (topLayer.attr('category') == p.categoryid) {
                        if (comparingProducts.Count < 3) {
                            comparingProducts.Add(p.productid, p);
                            renderCompareHtml();
                        }
                        else {
                            alert('最多只能比较3件商品');
                        }
                    }
                    else {
                        alert('只能比较同类产品！');
                    }
                }
                else {
                    topLayer.attr('category', p.categoryid);
                    comparingProducts.Add(p.productid, p);
                    renderCompareHtml();
                }

                function remove(productid) {
                    comparingProducts.Remove(productid);
                    renderCompareHtml();
                }

                function removeAll() {
                    comparingProducts = new Hashtable();

                    topLayer.html('');
                }


                function renderCompareHtml() {
                    var compareHtml = '';

                    if (comparingProducts.Count > 0) {
                        compareHtml += '<div class="box10">';
                        compareHtml += '    <div class="title">';
                        compareHtml += '        <span style="float:left">产品比较</span>';
                        compareHtml += '        <a href="javascript:void(0)" style="float:right; margin-right:5px;" id="productCompareClose">[关闭]</a>';
                        compareHtml += '    </div>';
                        compareHtml += '    <div class="content">';
                        compareHtml += '        <ul class="itemList8" id="productCompareList">';
                        for (var cmp = 0; cmp < comparingProducts.Count; cmp++) {
                            var key = comparingProducts.Keys()[cmp];
                            var theValue = comparingProducts.GetValue(key);
                            compareHtml += '            <li>';
                            compareHtml += '                <a href="/product-' + key + '.html">';
                            compareHtml += '                    <img src="' + theValue.image + '" />';
                            compareHtml += '                    <span>' + theValue.productname + '</span>';
                            compareHtml += '                </a>';
                            compareHtml += '                <a class="remove" href="javascript:void(0);" productid=' + key + '>';
                            compareHtml += '                    <span>[移除]</span>';
                            compareHtml += '                </a>';
                            compareHtml += '            </li>';
                        }
                        compareHtml += '        </ul>';
                        compareHtml += '    </div>';
                        compareHtml += '    <div><a href="javascript:void(0);" id="productCompareGo"> <b>对比</b> </a></div>';
                        compareHtml += '</div>';

                        topLayer.html(compareHtml);

                        $('#productCompareList .remove').click(function() {
                            remove($(this).attr('productid'));
                        });
                        $('#productCompareClose').click(function() {
                            removeAll();
                        });
                        $('#productCompareGo').click(function() {
                            var pids = '';
                            $.each(comparingProducts.Keys(), function(i, n) { pids += comparingProducts.Keys()[i] + ','; });
                            window.open('/product/productcompare.aspx?pid=' + pids.substring(0, pids.length - 1));
                        });
                    }
                    else {
                        topLayer.html('');
                    }
                }
            }
        });
    </script>
</asp:Content>

<asp:Content runat="server" ID="ContentBody" ContentPlaceHolderID="cpMain">
    
    <!--Position Begin-->
    <div class="currentPosition">
    	您现在的位置: <a href="/">首页</a> &gt;&gt; <a href="#"><asp:Literal runat="server" ID="Literal_SalesName1" /></a>    	
        <div class="solutionSubNav" style="float:right">
            <div class="solutionButtonTab">
                <asp:HyperLink runat="server" ID="HyperLink1" CssClass="button_blue" NavigateUrl="HomeProductList.aspx?type=1" style="float:left" Text="热销商品" />
                <asp:HyperLink runat="server" ID="HyperLink2" CssClass="button_blue" NavigateUrl="HomeProductList.aspx?type=2" style="float:left" Text="直降特卖" />
                <asp:HyperLink runat="server" ID="HyperLink3" CssClass="button_blue" NavigateUrl="HomeProductList.aspx?type=3" style="float:left" Text="鼎鼎推荐" />
            </div>
        </div>
    </div>
    <!--Position End-->
    
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
                            <span class="text"><asp:Literal runat="server" ID="Literal_SalesName2" /></span>
                            <span class="arrow"></span>
                        </li>
                        <li class="right"></li>
                        <li class="view">
                        	<span>显示方式</span>
                            <a class="viewBtn horizontal_on" href="javascript:void(0)" onclick="viewTransfer(this)"></a>
                            <a class="viewBtn vertical" href="javascript:void(0)" onclick="viewTransfer(this)"></a>
                        </li>
                        <li class="sort">
                        </li>
                    </ul>
                    <div class="content">
						<div id="productList" class="list_horizontal">
                            <ul>
                                <asp:Repeater runat="server" ID="Repeater_Product">
                                    <ItemTemplate>
                                        <li>
                                            <a href='/product-<%# Eval("productid") %>.html' title='<%# Eval("ProductName") %>'>
                                                <img src="<%# Eval("mediumimage") %>" />
                                                <span class="price">鼎鼎价：￥<%# Eval("price") %></span>
                                                <span class="name" title='<%# Eval("ProductName") %>'><%# Eval("ProductName") %></span>
                                                <span class="commentsNum"></span>
                                            </a>
                                            <div class="actions">
                                                <a class="button_blue3" href='/product-<%# Eval("productid") %>.html'>
                                                    <span class="left"></span>
                                                    <span class="text">购买</span>
                                                    <span class="right"></span>
                                                </a>
                                                <a class="button_blue3" href="javascript:void(0);;" productid='<%# Eval("productid") %>' fav="true">
                                                    <span class="left"></span>
                                                    <span class="text">收藏</span>
                                                    <span class="right"></span>
                                                </a>
                                                <a class="button_blue3" href='javascript:void(0);;' comp="1" productid='<%# Eval("productid") %>' productname='<%# Eval("ProductName") %>' category='<%# Eval("cateid") %>' image='<%# Eval("mediumimage") %>' >
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
                                <div class="pagination">
                                    <cc1:AspNetPager CssClass="pagerclass" ID="AspNetPager" runat="server" PageSize="16"
                                        UrlPageIndexName="" AlwaysShow="true" ImagePath="/" FirstPageText='首页' ShowInputBox="Always"
                                        LastPageText='末页' NextPageText='下一页' OnPageChanged="AspNetPager_PageChanged"
                                        PrevPageText='上一页' ShowBoxThreshold="16" NumericButtonCount="8" 
                                        ShowPrevNext="True" SubmitButtonClass="buttom" ShowPageIndex="true"
                                        NumericButtonTextFormatString=''>
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
        </div>
    </div>
    <!--MainBody End-->
    
        <div class="comparisonWindow" id="comparisonWindow" style="width:220px;">
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