<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
    <xsl:output method="html" doctype-system="http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd" doctype-public="-//W3C//DTD XHTML 1.0 Transitional//EN" indent="yes"/>

    <xsl:variable name="ProductID" select="/productpage/productinfo/product/productid"/>
    <xsl:variable name="ProductName" select="/productpage/productinfo/product/productname"/>

    <xsl:template match="/">
        <html xmlns="http://www.w3.org/1999/xhtml">
            <head>
                <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
                <title>
					<xsl:value-of select="$ProductName"/>-鼎鼎商城
                </title>
                <link type="text/css" rel="stylesheet" href="/css/common.css" />
                <link type="text/css" rel="stylesheet" href="/css/shopping.css" />
                <link type="text/css" rel="stylesheet" href="/css/Rainy.css" />
                <script type="text/javascript" src="/js/DingdingJsLib.js">
                    <xsl:text> </xsl:text>
                </script>
                <script type="text/javascript" src="/js/jquery.js">
                    <xsl:text> </xsl:text>
                </script>
                <script type="text/javascript" src="/js/mini-Rainy.js">
                    <xsl:text> </xsl:text>
                </script>
                <script type="text/javascript" src="/js/publish.product.js">
                    <xsl:text> </xsl:text>
                </script>
            </head>
            <body>
                <div class="wrapper">
                    <!--Header Begin-->
                    <xsl:call-template name="Header"/>
                    <!--Header End-->

                    <!--Position Begin-->
                    <xsl:call-template name="Position"/>
                    <!--Position End-->

                    <!--MainBody Begin-->
                    <div class="productDetail_mainbody newline clearfix">
                        <div class="rightColumn">
                            <div class="box2">
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
                                                <img src="images/thumbnail_s.jpg" />
                                                <span class="price">￥188.00</span>
                                                <span>伊莱克斯 Electrolux 全自动洗衣机</span>
                                            </a>
                                        </li>
                                        <li>
                                            <a href="#">
                                                <img src="images/thumbnail_s.jpg" />
                                                <span class="price">￥188.00</span>
                                                <span>伊莱克斯 Electrolux 全自动洗衣机</span>
                                            </a>
                                        </li>
                                        <li>
                                            <a href="#">
                                                <img src="images/thumbnail_s.jpg" />
                                                <span class="price">￥188.00</span>
                                                <span>伊莱克斯 Electrolux 全自动洗衣机</span>
                                            </a>
                                        </li>
                                        <li>
                                            <a href="#">
                                                <img src="images/thumbnail_s.jpg" />
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

                            <div class="box2 newline">
                                <ul class="title">
                                    <li class="left">
                                        <xsl:text> </xsl:text>
                                    </li>
                                    <li>
                                        <span>同品牌商品</span>
                                    </li>
                                    <li class="right">
                                        <xsl:text> </xsl:text>
                                    </li>
                                </ul>
                                <div class="content">
                                    <ul class="articleList_2 bullet_2">
                                        <xsl:apply-templates select="/productpage/samebrandproducts/product"/>
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
                                <div class="box1 noPadding">
                                    <ul class="title">
                                        <li class="left">
                                            <xsl:text> </xsl:text>
                                        </li>
                                        <li>
                                            <span>商品详情</span>
                                        </li>
                                        <li class="right">
                                            <xsl:text> </xsl:text>
                                        </li>
                                    </ul>
                                    <div class="content">
                                        <xsl:apply-templates select="/productpage/productinfo/product"/>

                                        <div class="box7">
                                            <div class="title">相关服务项目</div>
                                            <div class="content">
                                                <p>
                                                    延保服务 - 延长商品保修期，购物更安心<br/>延保通 笔记本 4001-5000元（保修二年）￥483.00  <a href="#">[详细说明]</a>  <a href="#">[购买]</a>
                                                </p>
                                            </div>
                                        </div>

                                        <div class="box7">
                                            <div class="title">相关配件</div>
                                            <div class="content">
                                                <ul class="itemList2">
                                                    <li>
                                                        <a href="#" title="惠普14存经济型笔记本电脑包">
                                                            <img src="images/productPic.gif" />
                                                            <span>惠普14存经济型笔记本电脑包</span>
                                                        </a>
                                                    </li>
                                                    <li>
                                                        <a href="#" title="惠普14存经济型笔记本电脑包">
                                                            <img src="images/productPic.gif" />
                                                            <span>惠普14存经济型笔记本电脑包</span>
                                                        </a>
                                                    </li>
                                                    <li>
                                                        <a href="#" title="惠普14存经济型笔记本电脑包">
                                                            <img src="images/productPic.gif" />
                                                            <span>惠普14存经济型笔记本电脑包</span>
                                                        </a>
                                                    </li>
                                                    <li>
                                                        <a href="#" title="惠普14存经济型笔记本电脑包">
                                                            <img src="images/productPic.gif" />
                                                            <span>惠普14存经济型笔记本电脑包</span>
                                                        </a>
                                                    </li>
                                                    <li>
                                                        <a href="#" title="惠普14存经济型笔记本电脑包">
                                                            <img src="images/productPic.gif" />
                                                            <span>惠普14存经济型笔记本电脑包</span>
                                                        </a>
                                                    </li>
                                                    <li>
                                                        <a href="#" title="惠普14存经济型笔记本电脑包">
                                                            <img src="images/productPic.gif" />
                                                            <span>惠普14存经济型笔记本电脑包</span>
                                                        </a>
                                                    </li>
                                                </ul>
                                            </div>
                                        </div>

                                        <div class="box7">
                                            <div class="title">相关商品</div>
                                            <div class="content">
                                                <ul class="itemList2">
                                                    <li>
                                                        <a href="#" title="惠普14存经济型笔记本电脑包">
                                                            <img src="images/productPic.gif" />
                                                            <span>惠普14存经济型笔记本电脑包</span>
                                                        </a>
                                                    </li>
                                                    <li>
                                                        <a href="#" title="惠普14存经济型笔记本电脑包">
                                                            <img src="images/productPic.gif" />
                                                            <span>惠普14存经济型笔记本电脑包</span>
                                                        </a>
                                                    </li>
                                                    <li>
                                                        <a href="#" title="惠普14存经济型笔记本电脑包">
                                                            <img src="images/productPic.gif" />
                                                            <span>惠普14存经济型笔记本电脑包</span>
                                                        </a>
                                                    </li>
                                                    <li>
                                                        <a href="#" title="惠普14存经济型笔记本电脑包">
                                                            <img src="images/productPic.gif" />
                                                            <span>惠普14存经济型笔记本电脑包</span>
                                                        </a>
                                                    </li>
                                                    <li>
                                                        <a href="#" title="惠普14存经济型笔记本电脑包">
                                                            <img src="images/productPic.gif" />
                                                            <span>惠普14存经济型笔记本电脑包</span>
                                                        </a>
                                                    </li>
                                                    <li>
                                                        <a href="#" title="惠普14存经济型笔记本电脑包">
                                                            <img src="images/productPic.gif" />
                                                            <span>惠普14存经济型笔记本电脑包</span>
                                                        </a>
                                                    </li>
                                                </ul>
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
                        <!--sales consultant begin-->
                        <div class="box7 newline">
                            <div class="title">售前咨询</div>
                            <div class="content">
                                <ul class="questions">
                                    <li class="odd">
                                        <div class="question">
                                            <span class="user">天空的白云：</span>
                                            <span>请问你们可以提供正规发票吗？</span>
                                            <span class="date">2009-3-3</span>
                                        </div>
                                        <div class="answer">
                                            <span class="answerer">鼎视回答：</span>
                                            <span>您好。可以提供发票。谢谢您的提问。</span>
                                            <span class="date">2009-3-3</span>
                                        </div>
                                    </li>
                                    <li class="even">
                                        <div class="question">
                                            <span class="user">天空的白云：</span>
                                            <span>怎么安装系统啊？急！！！</span>
                                            <span class="date">2009-3-3</span>
                                        </div>
                                        <div class="answer">
                                            <span class="answerer">鼎视回答：</span>
                                            <span>您好！标配 linux系统，安装XP系统的话将安装光盘放入光驱，让系统从光盘启动，进入安装界面按照提示一步步的设置就可以了，感谢您对鼎视的支持！祝您购物愉快！</span>
                                            <span class="date">2009-3-3</span>
                                        </div>
                                    </li>
                                    <li class="odd">
                                        <div class="question">
                                            <span class="user">天空的白云：</span>
                                            <span>请问你们可以提供正规发票吗？</span>
                                            <span class="date">2009-3-3</span>
                                        </div>
                                        <div class="answer">
                                            <span class="answerer">鼎视回答：</span>
                                            <span>您好。可以提供发票。谢谢您的提问。</span>
                                            <span class="date">2009-3-3</span>
                                        </div>
                                    </li>
                                    <li class="even">
                                        <div class="question">
                                            <span class="user">天空的白云：</span>
                                            <span>怎么安装系统啊？急！！！</span>
                                            <span class="date">2009-3-3</span>
                                        </div>
                                        <div class="answer">
                                            <span class="answerer">鼎视回答：</span>
                                            <span>您好！标配 linux系统，安装XP系统的话将安装光盘放入光驱，让系统从光盘启动，进入安装界面按照提示一步步的设置就可以了，感谢您对鼎视的支持！祝您购物愉快！</span>
                                            <span class="date">2009-3-3</span>
                                        </div>
                                    </li>
                                </ul>
                                <div class="section padding noPaddingBottom clearfix">
                                    <div class="floatLeft">
                                        <p class="noPaddingBottom">
                                            有问题，请您在此咨询<a href="/Product/QuestionList.aspx?productid={$ProductID}">【我要咨询】</a>
                                        </p>
                                    </div>
                                    <div class="floatRight">
                                        <p class="noPaddingBottom">
                                            <a href="/Product/QuestionList.aspx?productid={$ProductID}">【查看全部咨询】</a>
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!--sales consultant end-->

                        <!--product comments begin-->
                        <xsl:apply-templates select="/productpage/comments"/>
                        <!--product comments end-->

                        <!--user topics begin-->
                        <div class="box7">
                            <div class="title">用户话题</div>
                            <div class="content">
                                <div class="table3">
                                    <table>
                                        <tr>
                                            <th>主题</th>
                                            <th>回复/浏览</th>
                                            <th>最后发表</th>
                                        </tr>
                                        <tr>
                                            <td>
                                                这个东西很好很强大？<span>2009-02-23</span>
                                            </td>
                                            <td>0/39</td>
                                            <td>
                                                <span>天空的白云</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                这个东西很好很强大？<span>2009-02-23</span>
                                            </td>
                                            <td>0/39</td>
                                            <td>
                                                <span>天空的白云</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                这个东西很好很强大？<span>2009-02-23</span>
                                            </td>
                                            <td>0/39</td>
                                            <td>
                                                <span>天空的白云</span>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div class="section padding noPaddingBottom clearfix">
                                    <div class="floatLeft">
                                        <p class="noPaddingBottom">
                                            您可以发起属于自己的话题。<a href="/Product/TopicList.aspx?productid={$ProductID}">【我要发起】</a>
                                        </p>
                                    </div>
                                    <div class="floatRight">
                                        <p class="noPaddingBottom">
                                            <a href="/Product/TopicList.aspx?productid={$ProductID}">【查看全部话题】</a>
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!--user topics end-->
                    </div>
                    <!--MainBody End-->

                    <!--Footer Begin-->
                    <xsl:call-template name="Footer"/>
                    <!--Footer End-->

                </div>
            </body>
        </html>

    </xsl:template>
    
    <!-- header start -->
    <xsl:template name="Header">
        <!--<xsl:value-of select="/productpage/standardheader" disable-output-escaping="yes"/>-->
    </xsl:template>
    <!-- header end -->

    <!-- footer start -->
    <xsl:template name="Footer">
        <!--<xsl:value-of select="/productpage/standardfooter" disable-output-escaping="yes"/>-->
    </xsl:template>
    <!-- footer end -->

    <!-- positon start -->
    <xsl:template name="Position">
        <div class="currentPosition">
            <div class="currentPosition">
                您现在的位置:
                <xsl:for-each select="/productpage/categorypath/category">
                    <xsl:choose>
                        <xsl:when test="count(/productpage/categorypath/category) = position()">
                            <a href="/list-{categoryid}.html">
                                <xsl:value-of select="categoryname"/>
                            </a> &gt;&gt;
                        </xsl:when>
                        <xsl:otherwise>
                            <a href="/list-{categoryid}.html">
                                <xsl:value-of select="categoryname"/>
                            </a> &gt;&gt;
                        </xsl:otherwise>
                    </xsl:choose>
                </xsl:for-each>
                    <xsl:value-of select="$ProductName"/>
            </div>
        </div>
    </xsl:template>
    <!-- positon end -->

    <!-- product info start -->
    <xsl:template match="/productpage/productinfo/product">
        <div class="productGeneralProperties padding">
            <div class="thumbnail" onmousemove="zoomInThumb(event,this);" onmouseover="zoomInThumb(event,this);">
                <img src="{mediumimage}" />
                <div class="targetArea">
                    <xsl:text> </xsl:text>
                </div>
                <div class="zoomInArea">
                    <img src="{largeimage}" />
                </div>
            </div>
            <div class="properties">
                <ul>
                    <li>
                        <h1>
                            <xsl:value-of select="productname"/>
                        </h1>
                    </li>
                    <li>
                        <span class="field">商品编号：</span>
                        <span>
                            <xsl:value-of select="productcode"/>
                        </span>
                    </li>
                    <li>
                        <span class="field">市 场 价：</span>
                        <span class="marketPrice">
                            ￥<xsl:value-of select="tradeprice"/>
                        </span>
                    </li>
                    <li>
                        <span class="field ddPriceField">鼎 鼎 价：</span>
                        <span class="ddPrice">
                            ￥<xsl:value-of select="actualprice"/> 
                        </span>
                    </li>
                    <li>
                        <span class="field">库存状态：</span>
                        <span>
                            <xsl:choose>
                                <xsl:when test="stock > 0">北京现货</xsl:when>
                                <xsl:otherwise><span style="color:red">北京缺货</span></xsl:otherwise>
                            </xsl:choose>
                        </span>
                    </li>
                    <li class="buttons">
                        <a class="purchase" href="/sp/addtocart.aspx?pid={productid}">
                            <xsl:text> </xsl:text>
                        </a>
                        <a class="addToFavorite" href="#">
                            <xsl:text> </xsl:text>
                        </a>
                    </li>
                </ul>
            </div>
        </div>

        <div class="productDetailTab">
            <div class="title">
                <a rel="description" class="on" href="javascript:void(0)" onclick="transferTab2(this)">产品描述</a>
                <a rel="specs" href="javascript:void(0)" onclick="transferTab2(this)">规格参数</a>
                <a rel="packageInclude" href="javascript:void(0)" onclick="transferTab2(this)">包装清单</a>
                <a rel="suites" href="javascript:void(0)" onclick="transferTab2(this)">优惠套装</a>
                <a rel="service" href="javascript:void(0)" onclick="transferTab2(this)">售后服务</a>
                <a rel="news" href="javascript:void(0)" onclick="transferTab2(this)">评测资讯</a>
            </div>
            <div id="description" style="display:none">
                <xsl:value-of select="brief" disable-output-escaping="yes"/>
            </div>
            <div id="specs" style="display:none">
				<table>
					<xsl:for-each select="/productpage/specifications/specification">
						<tr>
							<td>
								<xsl:value-of select="paraname"/>
							</td>
							<td>
								<xsl:value-of select="paravalue"/>
							</td>
						</tr>
					</xsl:for-each>
				</table>
            </div>
            <div id="packageInclude" style="display:none">
				<xsl:value-of disable-output-escaping="yes" select="packinglist"/>
			</div>
            <div id="suites" style="display:none">
				<xsl:value-of disable-output-escaping="yes" select="offerset"/>
            </div>
            <div id="service" style="display:none">
				<xsl:value-of disable-output-escaping="yes" select="saleservice"/>
			</div>
            <div id="news" style="display:none">text5</div>
            <div class="content">
                <script type="text/javascript">
                    document.write(document.getElementById("description").innerHTML);
                </script>
            </div>
        </div>
    </xsl:template>
    <!-- product info end -->
    
    <!-- comment list start -->
    <xsl:template match="/productpage/comments">
        <div class="box7">
            <div class="title">商品评论</div>
            <div class="content">
                <div class="section padding noPaddingTop">
                    已有6人在此发表了评论。
                </div>
                <ul class="comments">
                    <xsl:for-each select="comment">
                        <li>
                            <img src="images/memberLevel1.gif" />
                            <div class="commentRightContent">
                                <div class="commentRightContentContainer">
                                    <div class="userInfo">
                                        <span class="user">天空的白云</span>
                                        <span>(双钻会员)</span>
                                        <div class="rating">
                                            <a href="javascript:void(0)" class="on">
                                                <xsl:text> </xsl:text>
                                            </a>
                                            <a href="javascript:void(0)" class="on">
                                                <xsl:text> </xsl:text>
                                            </a>
                                            <a href="javascript:void(0)" class="on">
                                                <xsl:text> </xsl:text>
                                            </a>
                                            <a href="javascript:void(0)">
                                                <xsl:text> </xsl:text>
                                            </a>
                                            <a href="javascript:void(0)">
                                                <xsl:text> </xsl:text>
                                            </a>
                                        </div>
                                        <span class="date">2009-02-23</span>
                                    </div>
                                    <div class="commentContent">
                                        有6年没有用过台式机了，不太好比较性价比，不过这一款家庭用还行，并且大屏幕信息也多，可以抬着头看东西，用笔记本时间长了，颈椎很受伤，这也是我为什么买台式机的原因。
                                    </div>
                                </div>
                            </div>
                        </li>                        
                    </xsl:for-each>
                </ul>
                <div class="section padding noPaddingBottom clearfix">
                    <div class="floatLeft">
                        <p class="noPaddingBottom">
                            <a href="/Product/CommentList.aspx?productid={$ProductID}">【我要评论】</a>
                        </p>
                    </div>
                    <div class="floatRight">
                        <p class="noPaddingBottom">
                            <a href="/Product/CommentList.aspx?productid={$ProductID}">【查看全部评论】</a>
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </xsl:template>
    
    <!-- same brand prodct list start -->
    <xsl:template match="/productpage/samebrandproducts/product">
        <li>
            <a href="/product-{productid}.html" title="{productname}">
                <xsl:value-of select="productnameshort"/>
            </a>
            <span>
                ￥<xsl:value-of select="price"/>
            </span>
        </li>
    </xsl:template>
	<!-- same brand prodct list end -->

</xsl:stylesheet>