﻿<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
    <xsl:output method="html" doctype-system="http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd" doctype-public="-//W3C//DTD XHTML 1.0 Transitional//EN" indent="yes"/>

    <xsl:variable name="NewsID" select="/newspage/newsdetail/newsid"/>
    <xsl:variable name="NewsTitle" select="/newspage/newsdetail/title"/>

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
                <script type="text/javascript" src="/js/newsdetail.js">
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

    <xsl:template match="/newspage/categorylist/category">
        <li>
            <a class="m1" href="{categoryid}">
                <span>
                    <xsl:value-of select="categoryname"/>
                </span>
            </a>
        </li>
    </xsl:template>

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
            <xsl:value-of select="newscontent" disable-output-escaping="yes"/>
        </div>
    </xsl:template>

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

</xsl:stylesheet>