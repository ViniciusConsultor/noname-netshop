﻿<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:output method="html" doctype-system="http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd" doctype-public="-//W3C//DTD XHTML 1.0 Transitional//EN" indent="yes"/>

	<xsl:variable name="BrandID" select="/brandpage/brandinfo/brandid"/>
	<xsl:variable name="BrandName" select="/brandpage/brandinfo/brandname"/>
	<xsl:variable name="CategoryID" select="/brandpage/brandinfo/categoryid"/>
	<xsl:variable name="OrderType" select="/brandpage/brandinfo/ordertype"/>
	<xsl:variable name="PageIndex" select="/brandpage/productlist/pageinfo/@currentpage"/>
	<xsl:variable name="PageCount" select="/brandpage/productlist/pageinfo/@pagecount"/>

	<xsl:template match="/">
		<html xmlns="http://www.w3.org/1999/xhtml">
			<head>
				<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
				<title>
					<xsl:value-of select="$BrandName" />-鼎鼎商城
				</title>
				<link type="text/css" rel="stylesheet" href="/css/common.css" />
				<link type="text/css" rel="stylesheet" href="/css/shopping.css" />
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
				<script type="text/javascript" src="/js/hashtable.js">
					<xsl:text> </xsl:text>
				</script>
				<script type="text/javascript" src="/js/publish.brand.js">
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
						<a href="/">首页</a> &gt;&gt; 
						<a href="/channel/brand">品牌商城</a> &gt;&gt; 
						<a href="#">
							<xsl:value-of select="$BrandName" />
						</a>
					</div>
					<!--Position End-->

					<!--MainBody Begin-->
					<div class="brandsClass_mainbody newline clearfix">
						<div class="leftColumn">
							<xsl:apply-templates select="/brandpage/brandinfo"/>
							<xsl:apply-templates select="/brandpage/salesproducts"/>
						</div>
						<div class="rightColumn">
							<div class="rightColumnContainer">
								<div class="box7">
									<div class="title">分类筛选</div>
									<div class="content">
										<ul class="productFilter">
											<li>
												<span>分类：</span>
												<a href="/brand-{$BrandID}.html">
													<xsl:if test="$CategoryID = 0">
														<xsl:attribute name="class">
															on
														</xsl:attribute>
													</xsl:if>
													全部
												</a>
												<xsl:apply-templates select="/brandpage/brandcategory/category"/>
											</li>
										</ul>
									</div>
								</div>
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
											<a class="on" style="cursor:pointer;" field="changetime" type="0">上架时间</a>
											<a style="cursor:pointer;" field="sales" type="0">销量</a>
											<div class="sortByPrice" onmouseover="showPriceSortDropdownList(this)" onmouseout="hidePriceSortDropdownList(this)">
												<a href="#" field="price">价格</a>
												<ul class="priceSortOptions" id="priceSortOptions">
													<li>
														<a style="cursor:pointer;" field="price" type="0">低 - 高</a>
													</li>
													<li>
														<a style="cursor:pointer;" field="price" type="1">高 - 低</a>
													</li>
												</ul>
											</div>
											<a style="cursor:pointer;" field="hit" type="0">浏览量</a>
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

				<div class="comparisonWindow" id="comparisonWindow" style="width:220px;">
					<xsl:text> </xsl:text>
				</div>
				<script type="text/javascript">
					window.onscroll=window.onload=window.onresize=function(){
					var comparisonWindow = document.getElementById("comparisonWindow");
					var scrollTop = document.documentElement.scrollTop;
					var middleCoordinateY = parseInt((document.documentElement.clientHeight - comparisonWindow.clientHeight)/2);
					comparisonWindow.style.top = (scrollTop + middleCoordinateY) + "px";
					}
				</script>
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
		<xsl:value-of select="/brandpage/standardfooter" disable-output-escaping="yes"/>
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
							<img src="{mediumimage}" />
							<span class="price">鼎鼎价：￥<xsl:value-of select="price"/>
						</span>
							<span class="name" title="{productname}">
								<xsl:value-of select="productname"/>
							</span>
							<!--<span class="commentsNum">已有<xsl:value-of select="commentcount"/>人评论</span>-->
						</a>
						<div class="actions">
                            <a class="button_blue3" href="/sp/addtocart.aspx?pid={productid}">
                                <span class="left">
                                    <xsl:text> </xsl:text>
                                </span>
                                <span class="text">购买</span>
                                <span class="right">
                                    <xsl:text> </xsl:text>
                                </span>
                            </a>
                            <a class="button_blue3" fav="true" style="cursor:pointer" productid="{productid}">
                                <span class="left">
                                    <xsl:text> </xsl:text>
                                </span>
                                <span class="text">收藏</span>
                                <span class="right">
                                    <xsl:text> </xsl:text>
                                </span>
                            </a>
                            <a class="button_blue3" comp="true" productid="{productid}" productname="{productname}" category="{categoryid}" image="{smallimage}" href="javascript:void(0)">
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
				<xsl:if test="$PageCount > 1">
					<div class="line">
						<xsl:text> </xsl:text>
					</div>
					<div class="pagination">
						<a class="prev" style="cursor:pointer">
			                <xsl:if test="$PageIndex != 1">
				                <xsl:attribute name="page">
					                <xsl:value-of select="$PageIndex - 1"/>
				                </xsl:attribute>
			                </xsl:if>
			                <xsl:text> </xsl:text>
						</a>
						<div class="pageNum">							
							<xsl:for-each select="pageinfo/page">
					            <a style="cursor:pointer">
						            <xsl:choose>
							            <xsl:when test="@pageindex != $PageIndex">
								            <xsl:attribute name="page">
									            <xsl:value-of select="@pageindex"/>
								            </xsl:attribute>
							            </xsl:when>
							            <xsl:otherwise>
								            <xsl:attribute name="class">on</xsl:attribute>
							            </xsl:otherwise>
						            </xsl:choose>
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
					</div>
				</xsl:if>
			</div>
		</div>		
	</xsl:template>
	<!-- product list end -->

	<!-- same brand sales product list start -->
	<xsl:template match="/brandpage/salesproducts">
		<div class="box2 newline">
			<ul class="title">
				<li class="left">
					<xsl:text> </xsl:text>
				</li>
				<li>
					<span>此品牌下热销的商品</span>
				</li>
				<li class="right">
					<xsl:text> </xsl:text>
				</li>
			</ul>
			<div class="content noPaddingTop">
				<ul class="itemList1">
					<xsl:for-each select="product">
						<li>
							<a href="/product-{productid}.html">
								<img src="{productimage}" />
								<span class="price">
									￥<xsl:value-of select="price"/>
								</span>
								<span>
									<xsl:value-of select="productname"/>
								</span>
							</a>
						</li>
					</xsl:for-each>
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
	</xsl:template>
	<!-- same brand sales product list end -->


	<xsl:template match="/brandpage/brandcategory/category">			
		<a href="/brand-{$BrandID}-c{categoryid}.html">
			<xsl:if test="$CategoryID = categoryid">
				<xsl:attribute name="class">
					on
				</xsl:attribute>		
			</xsl:if>
			<xsl:value-of select="categoryname"/>
		</a>
	</xsl:template>

</xsl:stylesheet>