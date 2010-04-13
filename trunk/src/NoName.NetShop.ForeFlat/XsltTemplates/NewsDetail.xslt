<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
    <xsl:output method="html" doctype-system="http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd" doctype-public="-//W3C//DTD XHTML 1.0 Transitional//EN" indent="yes"/>

    <xsl:variable name="NewsID" select="/newspage/newsdetail/newsid"/>
    <xsl:variable name="NewsTitle" select="/newspage/newsdetail/title"/>

    <xsl:template match="/">
        <html xmlns="http://www.w3.org/1999/xhtml">
            <head>
                <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
                <title>
					<xsl:value-of select="$NewsTitle"/>-鼎鼎商城
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
                <script type="text/javascript" src="/js/publish.newsdetail.js">
                    <xsl:text> </xsl:text>
                </script>
                <script type="text/javascript" src="/flash/mediaplayer/swfobject.js">
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
                        您现在的位置: <a href="#">首页</a> &gt;&gt; <a href="#">视听资讯</a> &gt;&gt; <a href="#">产品要闻</a> &gt;&gt; <a href="#">正文</a>
                    </div>
                    <!--Position End-->

                    <!--MainBody Begin-->
                    <div class="newsArticleDetail_mainbody clearfix newline">
                        <div class="rightColumn">
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
                                        <xsl:apply-templates select="/newspage/categorylist/category"/>
                                    </ul>
                                </div>
                            </div>
                            <div class="box2 newline">
                                <ul class="title">
                                    <li class="left">
                                        <xsl:text> </xsl:text>
                                    </li>
                                    <li>
                                        <span>热门资料排行榜</span>
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
                        <div class="mainColumn">
                            <div class="mainColumnContainer">
                                <div class="box1">
                                    <ul class="title">
                                        <li class="left">
                                            <xsl:text> </xsl:text>
                                        </li>
                                        <li>
                                            <span>
                                                <xsl:value-of select="$NewsTitle"/>
                                            </span>
                                        </li>
                                        <li class="right">
                                            <xsl:text> </xsl:text>
                                        </li>
                                    </ul>
                                    <div class="content">
                                        <xsl:apply-templates select="/newspage/newsdetail"/>

                                        <div class="vote">
                                            <h1>您觉得本网建设的如何？</h1>
                                            <ul>
                                                <li>
                                                    <span class="option">很好</span>
                                                    <div class="votebarParent">
                                                        <div style="width:55%">
                                                            <div class="votebar votebar1">
                                                                <div class="light">
                                                                    <xsl:text> </xsl:text>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <span class="result">36742(55%)</span>
                                                    <input class="checkbox" type="checkbox" />
                                                </li>
                                                <li>
                                                    <span class="option">不错</span>
                                                    <div class="votebarParent">
                                                        <div style="width:20%">
                                                            <div class="votebar votebar2">
                                                                <div class="light">
                                                                    <xsl:text> </xsl:text>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <span class="result">19268(20%)</span>
                                                    <input class="checkbox" type="checkbox" />
                                                </li>
                                                <li>
                                                    <span class="option">还行</span>
                                                    <div class="votebarParent">
                                                        <div style="width:10%">
                                                            <div class="votebar votebar3">
                                                                <div class="light">
                                                                    <xsl:text> </xsl:text>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <span class="result">8742(10%)</span>
                                                    <input class="checkbox" type="checkbox" />
                                                </li>
                                                <li>
                                                    <span class="option">有待提高</span>
                                                    <div class="votebarParent">
                                                        <div style="width:15%">
                                                            <div class="votebar votebar4">
                                                                <div class="light">
                                                                    <xsl:text> </xsl:text>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <span class="result">36742(15%)</span>
                                                    <input class="checkbox" type="checkbox" />
                                                </li>
                                                <li>
                                                    <span class="button">
                                                        <a class="button_blue2" href="#">投票</a>
                                                    </span>
                                                </li>
                                            </ul>
                                        </div>

                                        <div class="table4">
                                            <table>
                                                <tr>
                                                    <th>用户名</th>
                                                    <th>内容</th>
                                                    <th>发表时间</th>
                                                </tr>
                                                <xsl:apply-templates select="/newspage/comments/comment"/>
                                            </table>
                                        </div>
                                        <div class="leaveComment">
                                            <div class="title">我来说几句</div>
                                            <textarea id="comment-text">
                                                <xsl:text> </xsl:text>
                                            </textarea>
                                            <a style="cursor:button" newsid="{$NewsID}" id="comment-button" class="button_blue">发表</a>
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
        <xsl:value-of select="/newspage/standardheader" disable-output-escaping="yes"/>
    </xsl:template>
    <!-- header end -->

    <!-- footer start -->
    <xsl:template name="Footer">
        <xsl:value-of select="/newspage/standardheader" disable-output-escaping="yes"/>
    </xsl:template>
    <!-- footer end -->

    <!-- category list start -->
    <xsl:template match="/newspage/categorylist/category">
        <li>
            <a class="m1" href="/newslist-{categoryid}.html">
                <span>
                    <xsl:value-of select="categoryname"/>
                </span>
            </a>
        </li>
    </xsl:template>
    <!-- category list end -->

    <!-- news detail start -->
    <xsl:template match="/newspage/newsdetail">
        <h1>
            <xsl:value-of select="$NewsTitle"/>
        </h1>
        <h2>
            <span>
                <xsl:value-of select="inserttime"/>
            </span>
            <span>
                文/<xsl:value-of select="author"/>
            </span>
            <span>
                出处：<xsl:value-of select="newsfrom"/>
            </span>
        </h2>
        <div class="articleContent">
            <xsl:if test="videourl != ''">
                <div align="center" id="videoContainer">
                    <xsl:text> </xsl:text>                     
                </div>
                <script type="text/javascript">
                    var s1 = new SWFObject("/flash/mediaplayer/player.swf", "ply", "400", "300", "9", "#FFFFFF");
                    s1.addParam("allowfullscreen","true");
                    s1.addParam("allowscriptaccess","always");
                    s1.addParam("flashvars", "file=<xsl:value-of select="videourl"/>&amp;image=<xsl:value-of select="imageurl"/>");
                    s1.write("videoContainer");
                </script>
            </xsl:if>
            <xsl:value-of select="newscontent" disable-output-escaping="yes"/>
        </div>
    </xsl:template>
    <!-- news detail end -->

    <!-- news comment list start -->
    <xsl:template match="/newspage/comments/comment">
        <tr>
            <td>
                <xsl:value-of select="userid"/>
            </td>
            <td>
                <xsl:value-of select="content"/>
            </td>
            <td>
                <span>
                    <xsl:value-of select="createtime"/>
                </span>
            </td>
        </tr>
    </xsl:template>
    <!-- news comment list end -->

</xsl:stylesheet>