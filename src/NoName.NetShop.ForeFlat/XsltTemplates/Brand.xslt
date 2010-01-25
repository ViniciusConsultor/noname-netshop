<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:output method="html" doctype-system="http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd" doctype-public="-//W3C//DTD XHTML 1.0 Transitional//EN" indent="yes"/>

	<xsl:variable name="BrandID" select="/brandpage/brandinfo/brandid"/>
	<xsl:variable name="BrandName" select="/brandpage/brandinfo/brandname"/>
	<xsl:variable name="CategoryID" select="/brandpage/brandinfo/categoryid"/>
	<xsl:variable name="OrderType" select="/brandpage/brandinfo/ordertype"/>
	<xsl:variable name="PageIndex" select="/brandpage/productlist/pageinfo/@pageindex"/>

	<xsl:template match="/">
		<html xmlns="http://www.w3.org/1999/xhtml">
			<head>
				<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
				<title>
					<xsl:value-of select="$BrandName" />-鼎鼎商城
				</title>
				<link type="text/css" rel="stylesheet" href="/css/common.css" />
				<link type="text/css" rel="stylesheet" href="/css/brands.css" />
				<link rel="stylesheet" type="text/css" href="/css/Rainy.css" />
				<script type="text/javascript" src="/js/DingdingJsLib.js">
					<xsl:text> </xsl:text>
				</script>
				<script type="text/javascript" src="/js/jquery.js">
					<xsl:text> </xsl:text>
				</script>
				<script type="text/javascript" src="/js/mini-Rainy.js">
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
						您现在的位置: 
						<a href="#">首页</a> &gt;&gt; 
						<a href="#">品牌商城</a> &gt;&gt; 
						<a href="#">
							<xsl:value-of select="$BrandName" />
						</a>
					</div>
					<!--Position End-->

					<!--MainBody Begin-->
					<div class="brandsClass_mainbody newline clearfix">
						<div class="leftColumn">
							<xsl:apply-templates select="/brandpage/brandinfo"/>
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

						</div>
						<div class="rightColumn">
							<div class="rightColumnContainer">
								<!--
								<div class="box7">
									<div class="title">商品筛选</div>
									<div class="content">
										<ul class="productFilter">
											<li>
												<span>价格：</span>
												<a class="on" href="#">全部</a>
												<a href="#">1-500</a>
												<a href="#">501-1000</a>
												<a href="#">1001-1500</a>
												<a href="#">1501-2000</a>
												<a href="#">2001-2500</a>
												<a href="#">2501-3000</a>
											</li>
											<li>
												<span>自动化程度：</span>
												<a class="on" href="#">全部</a>
												<a href="#">全自动</a>
												<a href="#">半自动</a>
												<a href="#">其它</a>
											</li>
											<li>
												<span>驱动方式：</span>
												<a class="on" href="#">全部</a>
												<a href="#">波轮式</a>
												<a href="#">滚动式</a>
											</li>
										</ul>
									</div>
								</div>
								-->
								<div class="box8 newline">
									<ul class="title">
										<li class="left">
											<xsl:text> </xsl:text>
										</li>
										<li class="heading">
											<span class="text">商品列表</span>
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
										<xsl:apply-templates select="/brandpage/productlist"/>
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
		<xsl:value-of select="/brandpage/standardheader" disable-output-escaping="yes"/>
	</xsl:template>
	<!-- header end -->

	<!-- footer start -->
	<xsl:template name="Footer">
		<xsl:value-of select="/brandpage/standardheader" disable-output-escaping="yes"/>
	</xsl:template>
	<!-- footer end -->

	<!-- brand basic info start -->
	<xsl:template match="/brandpage/brandinfo">
		<div class="box2">
			<ul class="title">
				<li class="left">
					<xsl:text> </xsl:text>
				</li>
				<li>
					<span>品牌介绍</span>
				</li>
				<li class="right">
					<xsl:text> </xsl:text>
				</li>
			</ul>
			<div class="content">
				<img class="brandLogo" src="{brandlogo}" />
				<span class="brandDescription">
					<xsl:value-of select="brief"/>
				</span>
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

	</xsl:template>
	<!-- brand basic info end -->

	<!-- product list start -->
	<xsl:template match="/brandpage/productlist">

		<div id="productList" class="list_horizontal">
			<ul>
				<xsl:for-each select="products/product">
					<li>
						<a href="/product-{productid}.html" title="{productname}">
							<img src="Pictures/productPic.gif" />
							<span class="price">鼎城报价：￥<xsl:value-of select="price"/>
						</span>
							<span class="name" title="{productname}">
								<xsl:value-of select="productname"/>
							</span>
							<span class="commentsNum">已有<xsl:value-of select="commentcount"/>人评论</span>
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
				</xsl:for-each>
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
	</xsl:template>
	<!-- product list end -->

</xsl:stylesheet>