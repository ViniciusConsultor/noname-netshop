<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
    <xsl:output method="html" doctype-system="http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd" doctype-public="-//W3C//DTD XHTML 1.0 Transitional//EN" indent="yes"/>

    <xsl:variable name="CategoryID" select="listpage/classificationinfo/classificationid"/>
    <xsl:variable name="CategoryName" select="listpage/classificationinfo/classificationname"/>
    <xsl:variable name="IsEndCategory" select="listpage/classificationinfo/isendclass"/>
    <xsl:variable name="PageIndex" select="listpage/productinfo/pageinfo/@currentpage"/>

    <xsl:template match="/">
        <html xmlns="http://www.w3.org/1999/xhtml">
            <head>
                <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
                <title>购物街</title>
                <link type="text/css" rel="stylesheet" href="css/common.css" />
                <link type="text/css" rel="stylesheet" href="css/shopping.css" />
                <link type="text/css" rel="stylesheet" href="css/Rainy.css" />
                <script type="text/javascript" src="js/DingdingJsLib.js">
                    <xsl:text> </xsl:text>
                </script>
                <script type="text/javascript" src="/js/jquery.js">
                    <xsl:text> </xsl:text>
                </script>
                <script type="text/javascript" src="/js/mini-Rainy.js">
                    <xsl:text> </xsl:text>
                </script>
				<script type="text/javascript" src="/js/hashtable.js">
					<xsl:text> </xsl:text>
				</script>
                <script type="text/javascript" src="/js/publish.list.js">
                    <xsl:text> </xsl:text>
                </script>
            </head>
            <body>
                <div class="wrapper">
                    <!--Header Begin-->
                    <xsl:call-template name="Header" />
                    <!--Header End-->

                    <!--Position Begin-->
                    <xsl:call-template name="Position"/>
                    <!--Position End-->

                    <!--MainBody Begin-->
                    <div class="shoppingClass_mainbody newline clearfix">
                        <div class="leftColumn">
                            <div class="box2 cateBox">
                                <ul class="title">
                                    <li class="left">
                                        <xsl:text> </xsl:text>
                                    </li>
                                    <li>
                                        <span>商品分类</span>
                                    </li>
                                    <li class="right">
                                        <xsl:text> </xsl:text>
                                    </li>
                                </ul>
                                <div class="content">
                                    <xsl:apply-templates select="/listpage/categorylist"/>
                                </div>
                                <ul class="bottom">
                                    <li class="left">
                                        <xsl:text> </xsl:text>
                                    </li>
                                    <li class="right">
                                        <xsl:text> </xsl:text>
                                    </li>
                                </ul>
                            </div>

                            <!--category brands begin-->
                            <div class="box2 newline">
                                <ul class="title">
                                    <li class="left">
                                        <xsl:text> </xsl:text>
                                    </li>
                                    <li>
                                        <span>此商品分类下的品牌</span>
                                    </li>
                                    <li class="right">
                                        <xsl:text> </xsl:text>
                                    </li>
                                </ul>
                                <div class="content">
                                    <div class="category_non-popMenu clearfix">
                                        <div class="subs clearfix">
                                            <a href="#">东芝</a>
                                            <a href="#">日立</a>
                                            <a href="#">西门子</a>
                                            <a href="#">联想</a>
                                            <a href="#">海尔</a>
                                            <a href="#">富士康</a>
                                            <a href="#">索尼</a>
                                        </div>
                                    </div>
                                </div>
                                <ul class="bottom">
                                    <li class="left">
                                        <xsl:text> </xsl:text>
                                    </li>
                                    <li class="right">
                                        <xsl:text> </xsl:text>
                                    </li>
                                </ul>
                            </div>
                            <!--category brands end-->

                            <!--category hot sales begin-->
                            <div class="box2 newline">
                                <ul class="title">
                                    <li class="left">
                                        <xsl:text> </xsl:text>
                                    </li>
                                    <li>
                                        <span>此类下热销的商品</span>
                                    </li>
                                    <li class="right">
                                        <xsl:text> </xsl:text>
                                    </li>
                                </ul>
                                <div class="content noPaddingTop">
                                    <ul class="itemList1">
                                        <li>
                                            <a href="#">
                                                <img src="Pictures/thumbnail_s.jpg" />
                                                <span class="price">￥188.00</span>
                                                <span>伊莱克斯 Electrolux 全自动洗衣机</span>
                                            </a>
                                        </li>
                                        <li>
                                            <a href="#">
                                                <img src="Pictures/thumbnail_s.jpg" />
                                                <span class="price">￥188.00</span>
                                                <span>伊莱克斯 Electrolux 全自动洗衣机</span>
                                            </a>
                                        </li>
                                        <li>
                                            <a href="#">
                                                <img src="Pictures/thumbnail_s.jpg" />
                                                <span class="price">￥188.00</span>
                                                <span>伊莱克斯 Electrolux 全自动洗衣机</span>
                                            </a>
                                        </li>
                                        <li>
                                            <a href="#">
                                                <img src="Pictures/thumbnail_s.jpg" />
                                                <span class="price">￥188.00</span>
                                                <span>伊莱克斯 Electrolux 全自动洗衣机</span>
                                            </a>
                                        </li>
                                    </ul>
                                </div>
                                <ul class="bottom">
                                    <li class="left">
                                        <xsl:text> </xsl:text>
                                    </li>
                                    <li class="right">
                                        <xsl:text> </xsl:text>
                                    </li>
                                </ul>
                            </div>
                            <!--category hot sales end-->

                        </div>
                        <div class="rightColumn">
                            <div class="rightColumnContainer">
                                <div class="box7">
                                    <div class="title">
                                        <xsl:value-of select="$CategoryID"/> - 商品筛选
                                    </div>
                                    <div class="content">
                                        <ul class="productFilter">
                                            <xsl:apply-templates select="/listpage/properitylist/prop"/>
                                        </ul>
                                    </div>
                                </div>
                                <div class="box8 newline">
                                    <ul class="title">
                                        <li class="left">
                                            <xsl:text> </xsl:text>
                                        </li>
                                        <li class="heading">
                                            <span class="text">影像商品 - 投影 - 商品列表</span>
                                            <span class="arrow">
                                                <xsl:text> </xsl:text>
                                            </span>
                                        </li>
                                        <li class="right">
                                            <xsl:text> </xsl:text>
                                        </li>
                                        <li class="view">
                                            <span>显示方式</span>
                                            <a class="viewBtn horizontal_on" href="javascript:void(0)" onclick="viewTransfer(this)">
                                                <xsl:text> </xsl:text>
                                            </a>
                                            <a class="viewBtn vertical" href="javascript:void(0)" onclick="viewTransfer(this)">
                                                <xsl:text> </xsl:text>
                                            </a>
                                        </li>
                                        <li class="sort">
                                            <span>请选择排序方式</span>
                                            <a class="on" href="#">销量</a>
                                            <a href="#">价格</a>
                                            <a href="#">上架时间</a>
                                            <a href="#">浏览量</a>
                                        </li>
                                    </ul>
                                    <div class="content">
                                        <div id="productList" class="list_horizontal">
                                            <ul>
                                                <xsl:apply-templates select="/listpage/productlist/products/product"/>
                                            </ul>
                                            <div class="paginationContainer">
                                                <div class="line">
                                                    <xsl:text> </xsl:text>
                                                </div>
                                                <div class="pagination">
                                                    <a class="prev" href="#">
                                                        <xsl:text> </xsl:text>
                                                    </a>
                                                    <div class="pageNum">
                                                        <a class="on" href="#">1</a>
                                                        <a href="#">2</a>
                                                        <a href="#">3</a>
                                                        <a href="#">4</a>
                                                        <a href="#">5</a>
                                                        <a href="#">6</a>
                                                        <a href="#">7</a>
                                                    </div>
                                                    <a class="next" href="#">
                                                        <xsl:text> </xsl:text>
                                                    </a>
                                                    <div class="jumpTo">
                                                        <span>跳转到</span>
                                                        <input type="text" value="1" />
                                                        <span>页</span>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <ul class="bottom">
                                        <li class="left">
                                            <xsl:text> </xsl:text>
                                        </li>
                                        <li class="right">
                                            <xsl:text> </xsl:text>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!--MainBody End-->

                    <!--Footer Begin-->
                    <xsl:call-template name="Footer" />
                    <!--Footer End-->

                </div>
            </body>
        </html>
    </xsl:template>

    <!-- header start -->
    <xsl:template name="Header">
        <xsl:value-of select="/listpage/standardheader" disable-output-escaping="yes"/>
    </xsl:template>
    <!-- header end -->

    <!-- footer start -->
    <xsl:template name="Footer">
        <xsl:value-of select="/listpage/standardheader" disable-output-escaping="yes"/>
    </xsl:template>
    <!-- footer end -->
    
    <!-- position start -->
    <xsl:template name="Position">
        <div class="currentPosition">
            您现在的位置:
            <xsl:for-each select="/listpage/categorypath/category">
                <xsl:choose>
                    <xsl:when test="count(/listpage/categorypath/category) = position()">
                        <a href="/list-{categoryid}.html">
                            <xsl:value-of select="categoryname"/>
                        </a>
                    </xsl:when>
                    <xsl:otherwise>
                        <a href="/list-{categoryid}.html">
                            <xsl:value-of select="categoryname"/>
                        </a> &gt;&gt;
                    </xsl:otherwise>
                </xsl:choose>
            </xsl:for-each>
        </div>
    </xsl:template>
    <!-- position end -->

    <!-- properity filter start -->
    <xsl:template match="/listpage/properitylist/prop">
        <li class="properity" propid="{propid}">
            <span>
                <xsl:value-of select="propname"/>：
            </span>
            <a style="cursor:pointer" propid="{propid}" propvid="-1">全部</a>
            <xsl:for-each select="values/value">
                <a style="cursor:pointer" propvid="{valueid}">
                    <xsl:value-of select="value"/>
                </a>
            </xsl:for-each>
        </li>
    </xsl:template>
    <!-- properity filter start -->

    <!-- category list start -->
    <xsl:template match="/listpage/categorylist">
        <div class="category_non-popMenu clearfix">
            <xsl:for-each select="fathercategory">
                <a class="class" href="/list-{@categoryid}.html">
                    <xsl:value-of select="@categoryname"/>
                    <xsl:if test="soncategory">
                        <div class="subs clearfix">
                            <xsl:for-each select="soncategory">
                                <a href="/list-{@categoryid}.html">
                                    <xsl:value-of select="@categoryname"/>
                                </a>
                            </xsl:for-each>
                        </div>
                    </xsl:if>
                </a>
            </xsl:for-each>
        </div>
    </xsl:template>
    <!-- category list start -->

    <!-- product list start -->
    <xsl:template match="/listpage/productlist/products/product">
        <li>
            <a href="/product-{productid}.html" title="{productname}">
                <img src="{mediumimage}" />
                <span class="price">
                    鼎城报价：￥<xsl:value-of select="merchantprice"/>
                </span>
                <span class="name" title="{productname}">
                    <xsl:value-of select="productname"/>
                </span>
                <span class="commentsNum">已有0人评论</span>
            </a>
            <div class="actions">
                <a class="button_blue3" href="/product-{productid}.html">
                    <span class="left">
                        <xsl:text> </xsl:text>
                    </span>
                    <span class="text">购买</span>
                    <span class="right">
                        <xsl:text> </xsl:text>
                    </span>
                </a>
                <a class="button_blue3" href="#">
                    <span class="left">
                        <xsl:text> </xsl:text>
                    </span>
                    <span class="text">收藏</span>
                    <span class="right">
                        <xsl:text> </xsl:text>
                    </span>
                </a>
                <a class="button_blue3" href="/product-{productid}.html">
                    <span class="left">
                        <xsl:text> </xsl:text>
                    </span>
                    <span class="text">对比</span>
                    <span class="right">
                        <xsl:text> </xsl:text>
                    </span>
                </a>
            </div>
        </li>
    </xsl:template>
    <!-- product list start -->

</xsl:stylesheet>