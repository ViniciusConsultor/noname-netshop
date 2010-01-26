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
                    <xsl:call-template name="Header" />
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
                                        <xsl:apply-templates select="/newslistpage/categorylist/category"/>
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
                    <xsl:call-template name="Footer" />
                    <!--Footer End-->

                </div>
            </body>
        </html>
    </xsl:template>


    <!-- header start -->
    <xsl:template name="Header">
        <xsl:value-of select="/newslistpage/standardheader" disable-output-escaping="yes"/>
    </xsl:template>
    <!-- header end -->

    <!-- footer start -->
    <xsl:template name="Footer">
        <xsl:value-of select="/newslistpage/standardheader" disable-output-escaping="yes"/>
    </xsl:template>
    <!-- footer end -->

    <!-- category list start -->
    <xsl:template match="/newslistpage/categorylist/category">
        <li>
            <a class="m1" href="/newslist-{categoryid}.html">
                <span>
                    <xsl:value-of select="categoryname"/>
                </span>
            </a>
        </li>
    </xsl:template>
    <!-- category list end -->

    <!-- news list start -->
    <xsl:template match="/newslistpage/newslist/list/news">
        <xsl:choose>
            <xsl:when test="imageurl != ''">
                <li class="widthThumb">
                    <a href="/news-{newsid}.html">
                        <img src="{imageurl}" />
                    </a>
                    <div class="text">
                        <div class="textContainer">
                            <h1>
                                <a href="/news-{newsid}.html">
                                    <xsl:value-of select="title"/>
                                </a>
                            </h1>
                            <p>
                                <xsl:value-of select="brief"/>
                            </p>
                            <div class="more">
                                <a href="/news-{newsid}.html">详细 &gt;&gt;</a>
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
                                <a href="/news-{newsid}.html">
                                    <xsl:value-of select="title"/>
                                </a>
                            </h1>
                            <p>
                                <xsl:value-of select="brief"/>
                            </p>
                            <div class="more">
                                <a href="/news-{newsid}.html">详细 &gt;&gt;</a>
                            </div>
                        </div>
                    </div>
                </li>
            </xsl:otherwise>
        </xsl:choose>
    </xsl:template>
    <!-- news list end -->
    
</xsl:stylesheet>