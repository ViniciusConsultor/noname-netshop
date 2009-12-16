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
                <script type="text/javascript" src="/js/list.js">
                    <xsl:text> </xsl:text>
                </script>
            </head>
            <body>
                <div class="wrapper">
                    <!--Header Begin-->
                    <div class="header">
                        <div class="top clearfix">
                            <div class="logo">
                                <xsl:text> </xsl:text>
                            </div>
                            <ul class="toplink bullet_1">
                                <li class="slogan">您好，欢迎您来到鼎鼎商城！</li>
                                <li>
                                    <a href="#">请登录</a>
                                </li>
                                <li>
                                    <a href="#">免费注册</a>
                                </li>
                                <li>
                                    <a href="#">帮助中心</a>
                                </li>
                            </ul>
                            <ul class="navigator">
                                <li>
                                    <a class="home" href="#">
                                        <xsl:text> </xsl:text>
                                    </a>
                                </li>
                                <li>
                                    <a class="shopping" href="#">
                                        <xsl:text> </xsl:text>
                                    </a>
                                </li>
                                <li>
                                    <a class="solution" href="#">
                                        <xsl:text> </xsl:text>
                                    </a>
                                </li>
                                <li>
                                    <a class="brands" href="#">
                                        <xsl:text> </xsl:text>
                                    </a>
                                </li>
                                <li>
                                    <a class="information" href="#">
                                        <xsl:text> </xsl:text>
                                    </a>
                                </li>
                                <li>
                                    <a class="magic" href="#">
                                        <xsl:text> </xsl:text>
                                    </a>
                                </li>
                            </ul>
                        </div>
                        <div class="panel">
                            <div class="edge left">
                                <xsl:text> </xsl:text>
                            </div>
                            <div class="edge right">
                                <xsl:text> </xsl:text>
                            </div>
                            <div class="middle clearfix">
                                <ul class="searchbar clearfix">
                                    <li class="label">分类搜索：</li>
                                    <li class="selectBox">
                                        <div class="border">
                                            <script type="text/javascript">
                                                var mybox=new RainySelectBox();
                                                mybox.boxName="categoriesBox";
                                                mybox.fire="click";
                                                mybox.name="categories";
                                                mybox.id="categories";
                                                mybox.width=120;
                                                mybox.listMaxHeight=300;
                                                mybox.selectedClass="currentOption";
                                                mybox.listClass="list";
                                                mybox.addOption("所有分类","0","Selected");
                                                mybox.addOption("影音器材","1");
                                                mybox.addOption("项目三","3");
                                                mybox.addOption("项目一","1");
                                                mybox.addOption("项目二","2");
                                                mybox.addOption("项目三","3");
                                                mybox.addOption("Rainy","1");
                                                mybox.addOption("项目一","1");
                                                mybox.addOption("项目二","2");
                                                mybox.addOption("项目三","3");
                                                mybox.addOption("项目一","1");
                                                mybox.addOption("项目二","2");
                                                mybox.addOption("项目三","3");
                                                mybox.show();
                                            </script>
                                        </div>
                                    </li>
                                    <li class="textField">
                                        <div class="border">
                                            <input type="text" name="keyword" />
                                        </div>
                                    </li>
                                    <li class="submit">
                                        <a href="javascript:void(0)">
                                            <xsl:text> </xsl:text>
                                        </a>
                                    </li>
                                </ul>
                                <div class="hotKeyWords">
                                    <span class="label">热门搜索：</span>
                                    <span class="words">
                                        <a href="#">音响</a>
                                        <a href="#">视频</a>
                                        <a href="#">投影</a>
                                        <a href="#">apple</a>
                                        <a href="#">IBM</a>
                                        <a href="#">视频</a>
                                        <a href="#">投影</a>
                                        <a href="#">音响</a>
                                        <a href="#">视频</a>
                                        <a href="#">投影</a>
                                        <a href="#">投影</a>
                                    </span>
                                </div>
                                <ul class="userLink">
                                    <li class="left">
                                        <xsl:text> </xsl:text>
                                    </li>
                                    <li>
                                        <a href="#">我的账户</a>
                                    </li>
                                    <li>
                                        <a href="#">购物车</a>
                                    </li>
                                    <li>
                                        <a href="#">团购</a>
                                    </li>
                                    <li>
                                        <a href="#">站内信</a>
                                    </li>
                                    <li>
                                        <a href="#">礼品兑换</a>
                                    </li>
                                    <li class="right">
                                        <xsl:text> </xsl:text>
                                    </li>
                                </ul>
                            </div>
                        </div>
                    </div>
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
                    <div class="box5 newline">
                        <ul class="top">
                            <li class="left">
                                <xsl:text> </xsl:text>
                            </li>
                            <li class="right">
                                <xsl:text> </xsl:text>
                            </li>
                        </ul>
                        <div class="content">
                            <ul class="directions clearfix">
                                <li>
                                    <span class="icon beginner">
                                        <xsl:text> </xsl:text>
                                    </span>
                                    <span class="text">
                                        新手上路
                                        <a href="#">网上订单</a>
                                        <a href="#">电话订购</a>
                                        <a href="#">在线订购</a>
                                        <a href="#">缺货说明</a>
                                    </span>
                                </li>
                                <li>
                                    <span class="icon deliver">
                                        <xsl:text> </xsl:text>
                                    </span>
                                    <span class="text">
                                        配送范围
                                        <a href="#">资费标准</a>
                                    </span>
                                </li>
                                <li>
                                    <span class="icon pay">
                                        <xsl:text> </xsl:text>
                                    </span>
                                    <span class="text">
                                        如何付款
                                        <a href="#">付款方式</a>
                                        <a href="#">汇款单招领</a>
                                    </span>
                                </li>
                                <li>
                                    <span class="icon service">
                                        <xsl:text> </xsl:text>
                                    </span>
                                    <span class="text">
                                        售后服务
                                        <a href="#">退换货原则</a>
                                        <a href="#">退换货处理</a>
                                    </span>
                                </li>
                                <li class="last">
                                    <span class="icon help">
                                        <xsl:text> </xsl:text>
                                    </span>
                                    <span class="text">
                                        需要帮助
                                        <a href="#">网忘记了密码</a>
                                        <a href="#">常见问题</a>
                                        <a href="#">联系客服</a>
                                    </span>
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
                    <div class="copyright">
                        <a href="#">关于我们</a> | <a href="#">联系我们</a> | <a href="#">招贤纳士</a> | <a href="#">本站帮助</a> | <a href="#">合作伴伙</a><br />
                        <span>
                            Copyright   ©   2004-2009  鼎城视讯  版权所有   京ICP证1234567号<br />北京市公安局海淀分局备案编号：DD009768699
                        </span>
                    </div>
                    <!--Footer End-->

                </div>
            </body>
        </html>
    </xsl:template>

    <xsl:template name="Position">
        <div class="currentPosition">
            您现在的位置:
            <xsl:for-each select="/listpage/categorypath/category">
                <xsl:choose>
                    <xsl:when test="count(/listpage/categorypath/category) = position()">
                        <a href="#">
                            <xsl:value-of select="categoryname"/>
                        </a>
                    </xsl:when>
                    <xsl:otherwise>
                        <a href="#">
                            <xsl:value-of select="categoryname"/>
                        </a> &gt;&gt;
                    </xsl:otherwise>
                </xsl:choose>
            </xsl:for-each>
        </div>
    </xsl:template>

    <xsl:template match="/listpage/properitylist/prop">
        <li class="properity">
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

    <xsl:template match="/listpage/categorylist">
        <div class="category_non-popMenu clearfix">
            <xsl:for-each select="fathercategory">
                <a class="class" href="#">
                    <xsl:value-of select="@categoryname"/>
                    <xsl:if test="soncategory">
                        <div class="subs clearfix">
                            <xsl:for-each select="soncategory">
                                <a href="#">
                                    <xsl:value-of select="@categoryname"/>
                                </a>
                            </xsl:for-each>
                        </div>
                    </xsl:if>
                </a>
            </xsl:for-each>
        </div>
    </xsl:template>

    <xsl:template match="/listpage/productlist/products/product">
        <li>
            <a href="#" title="{productname}">
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
                <a class="button_blue3" href="#">
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
                <a class="button_blue3" href="#">
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
</xsl:stylesheet>