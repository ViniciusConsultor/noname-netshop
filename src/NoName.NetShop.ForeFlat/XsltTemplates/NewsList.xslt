<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
    <xsl:output method="html" doctype-system="http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd" doctype-public="-//W3C//DTD XHTML 1.0 Transitional//EN" indent="yes"/>

	<xsl:variable name="CategoryID" select="/newslistpage/categorylist/category[last()]/categoryid"/>
	<xsl:variable name="CategoryName" select="/newslistpage/categorylist/category[last()]/categoryname"/>
	<xsl:variable name="PageIndex" select="/newslistpage/newslist/pageinfo/@currentpage"/>
	<xsl:variable name="PageCount" select="/newslistpage/newslist/pageinfo/@pagecount"/>

    <xsl:template match="/">
        <html xmlns="http://www.w3.org/1999/xhtml">
            <head>
                <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
                <title>
					<xsl:value-of select="/newslistpage/categorylist/category[last()]/categoryname"/>-鼎鼎商城
                </title>
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
				<script type="text/javascript" src="/js/publish.newslist.js">
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
						您现在的位置: <a href="/">首页</a> &gt;&gt; <a href="/channel/info">视听资讯</a>
						<xsl:for-each select="/newslistpage/categorypathlist/category">
							<xsl:text> </xsl:text>&gt;&gt; <a href="/newslist-{categoryid}.html">
								<xsl:value-of select="categoryname"/>
							</a>
						</xsl:for-each>
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
										<xsl:apply-templates select="/newslistpage/rankinglist/news" />
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
										<xsl:apply-templates select="/newslistpage/splendidnewslist/news" />
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
												<xsl:apply-templates select="/newslistpage/newslist/pageinfo" />
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
        <xsl:value-of select="/newslistpage/standardfooter" disable-output-escaping="yes"/>
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
            <xsl:when test="imageurl != '' or videourl != ''">
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
	<xsl:template match="/newslistpage/newslist/pageinfo">
		<a type="page" class="prev" style="cursor:pointer">
			<xsl:if test="$PageIndex != 1">
				<xsl:attribute name="page">
					<xsl:value-of select="$PageIndex - 1"/>
				</xsl:attribute>
			</xsl:if>
			<xsl:text> </xsl:text>
		</a>
		<div class="pageNum">
			<xsl:for-each select="page">
				<a type="page" style="cursor:pointer">
					<xsl:if test="@pageindex != $PageIndex">
						<xsl:attribute name="page">
							<xsl:value-of select="@pageindex"/>
						</xsl:attribute>
					</xsl:if>
					<xsl:if test="@pageindex = $PageIndex">
						<xsl:attribute name="class">on</xsl:attribute>
					</xsl:if>
					<xsl:value-of select="@pageindex"/>
				</a>
			</xsl:for-each>
		</div>
		<a type="page" class="next" style="cursor:pointer">
			<xsl:if test="$PageIndex != $PageCount">
				<xsl:attribute name="page">
					<xsl:value-of select="$PageIndex + 1"/>
				</xsl:attribute>
			</xsl:if>
		</a>
	</xsl:template>
    <!-- news list end -->

	<!-- ranking list start -->
	<xsl:template match="/newslistpage/rankinglist/news">
		<li>
			<a href="/news-{newsid}.html">
				<xsl:value-of select="title"/>
			</a>
		</li>
	</xsl:template>
	<!-- ranking list end -->

	<!-- hot news list start -->
	<xsl:template match="/newslistpage/splendidnewslist/news">
		<li>
			<a href="/news-{newsid}.html">
				<xsl:value-of select="title"/>
			</a>
		</li>
	</xsl:template>
	<!-- hot news list end -->
	
</xsl:stylesheet>