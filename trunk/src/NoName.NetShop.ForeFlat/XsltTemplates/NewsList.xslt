<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
    <xsl:output method="html" doctype-system="http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd" doctype-public="-//W3C//DTD XHTML 1.0 Transitional//EN" indent="yes"/>


    <xsl:template match="/">
        <html xmlns="http://www.w3.org/1999/xhtml">
            <head>
                <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
                <title>视听资讯</title>
                <link type="text/css" rel="stylesheet" href="http://dingding.uncc.cn/css/common.css" />
                <link type="text/css" rel="stylesheet" href="http://dingding.uncc.cn/css/news.css" />
                <link type="text/css" rel="stylesheet" href="http://dingding.uncc.cn/css/Rainy.css" />
                <script type="text/javascript" src="http://dingding.uncc.cn/js/DingdingJsLib.js">
                    <xsl:text> </xsl:text>
                </script>
                <script type="text/javascript" src="http://dingding.uncc.cn/js/jquery.js">
                    <xsl:text> </xsl:text>
                </script>
                <script type="text/javascript" src="http://dingding.uncc.cn/js/mini-Rainy.js">
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
                    <div class="currentPosition">
                        您现在的位置: <a href="#">首页</a> &gt;&gt; <a href="#">视听资讯栏目公共页面</a>
                    </div>
                    <!--Position End-->

                    <!--MainBody Begin-->
                    <div class="newsChildClassCommon_mainbody clearfix newline">
                        <div class="leftColumn">
                            <div class="box2">
                                <ul class="title">
                                    <li class="left">
                                        <xsl:text> </xsl:text>
                                    </li>
                                    <li>
                                        <span>分类导航</span>
                                    </li>
                                    <li class="right">
                                        <xsl:text> </xsl:text>
                                    </li>
                                </ul>
                                <div class="content noPaddingContentBox">
                                    <ul class="newsNavigator">
                                        <xsl:apply-templates select="/newslistpage/cateogrylist/category"/>
                                    </ul>
                                </div>
                            </div>
                            <div class="box2 newline">
                                <ul class="title">
                                    <li class="left">
                                        <xsl:text> </xsl:text>
                                    </li>
                                    <li>
                                        <span>资讯排行榜</span>
                                    </li>
                                    <li class="right">
                                        <xsl:text> </xsl:text>
                                    </li>
                                </ul>
                                <div class="content">
                                    <ul class="articleList_1 bullet_2">
                                        <li>
                                            <a href="#">开学好礼大放送，DIY放血大促销</a>
                                        </li>
                                        <li>
                                            <a href="#">初春必败男装 全场2折起</a>
                                        </li>
                                        <li>
                                            <a href="#">欧米茄手表3折</a>
                                        </li>
                                        <li>
                                            <a href="#">初春必败男装 全场2折起</a>
                                        </li>
                                        <li>
                                            <a href="#">欧米茄手表3折</a>
                                        </li>
                                        <li>
                                            <a href="#">开学好礼大放送，DIY放血大促销</a>
                                        </li>
                                        <li>
                                            <a href="#">初春必败男装 全场2折起</a>
                                        </li>
                                        <li>
                                            <a href="#">欧米茄手表3折</a>
                                        </li>
                                        <li>
                                            <a href="#">初春必败男装 全场2折起</a>
                                        </li>
                                        <li>
                                            <a href="#">欧米茄手表3折</a>
                                        </li>
                                        <li>
                                            <a href="#">开学好礼大放送，DIY放血大促销</a>
                                        </li>
                                        <li>
                                            <a href="#">初春必败男装 全场2折起</a>
                                        </li>
                                        <li>
                                            <a href="#">欧米茄手表3折</a>
                                        </li>
                                        <li>
                                            <a href="#">初春必败男装 全场2折起</a>
                                        </li>
                                        <li>
                                            <a href="#">欧米茄手表3折</a>
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
                            <div class="box2 newline">
                                <ul class="title">
                                    <li class="left">
                                        <xsl:text> </xsl:text>
                                    </li>
                                    <li>
                                        <span>精彩资讯导读</span>
                                    </li>
                                    <li class="right">
                                        <xsl:text> </xsl:text>
                                    </li>
                                </ul>
                                <div class="content">
                                    <ul class="articleList_1 bullet_2">
                                        <li>
                                            <a href="#">开学好礼大放送，DIY放血大促销</a>
                                        </li>
                                        <li>
                                            <a href="#">初春必败男装 全场2折起</a>
                                        </li>
                                        <li>
                                            <a href="#">欧米茄手表3折</a>
                                        </li>
                                        <li>
                                            <a href="#">初春必败男装 全场2折起</a>
                                        </li>
                                        <li>
                                            <a href="#">欧米茄手表3折</a>
                                        </li>
                                        <li>
                                            <a href="#">开学好礼大放送，DIY放血大促销</a>
                                        </li>
                                        <li>
                                            <a href="#">初春必败男装 全场2折起</a>
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
                        </div>
                        <div class="rightColumn">
                            <div class="rightColumnContainer">
                                <div class="box1">
                                    <ul class="title">
                                        <li class="left">
                                            <xsl:text> </xsl:text>
                                        </li>
                                        <li>
                                            <span>栏目名称</span>
                                        </li>
                                        <li class="right">
                                            <xsl:text> </xsl:text>
                                        </li>
                                    </ul>
                                    <div class="content">
                                        <ul class="newsList">
                                            <xsl:apply-templates select="/newslistpage/newslist/list/news"/>
                                        </ul>
                                        <div class=" paginationParent">
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

    <xsl:template match="/newslistpage/categorylist/category">
        <li>
            <a class="m1" href="{categoryid}">
                <span>
                    <xsl:value-of select="categoryname"/>
                </span>
            </a>
        </li>
    </xsl:template>

    <xsl:template match="/newslistpage/newslist/list/news">
        <xsl:choose>
            <xsl:when test="imageurl != ''">
                <li class="widthThumb">
                    <a href="#">
                        <img src="{imageurl}" />
                    </a>
                    <div class="text">
                        <div class="textContainer">
                            <h1>
                                <a href="#">
                                    <xsl:value-of select="title"/>
                                </a>
                            </h1>
                            <p>
                                <xsl:value-of select="brief"/>
                            </p>
                            <div class="more">
                                <a href="#">详细 &gt;&gt;</a>
                            </div>
                        </div>
                    </div>
                </li>
            </xsl:when>
            <xsl:otherwise>
                <li>
                    <div class="text">
                        <div class="textContainer">
                            <h1>
                                <a href="#">
                                    <xsl:value-of select="title"/>
                                </a>
                            </h1>
                            <p>
                                <xsl:value-of select="brief"/>
                            </p>
                            <div class="more">
                                <a href="#">详细 &gt;&gt;</a>
                            </div>
                        </div>
                    </div>
                </li>
            </xsl:otherwise>
        </xsl:choose>
    </xsl:template>
    
</xsl:stylesheet>