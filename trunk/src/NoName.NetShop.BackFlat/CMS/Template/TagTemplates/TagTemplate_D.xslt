<?xml version="1.0" encoding="utf-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:output method="html" doctype-system="http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd" doctype-public="-//W3C//DTD XHTML 1.0 Transitional//EN" indent="yes"/>

	<xsl:template match="/">
		<html xmlns="http://www.w3.org/1999/xhtml">
			<head>
			</head>
			<body>
					<xsl:apply-templates select="/tag"/>
			</body>
		</html>
	</xsl:template>


	<xsl:template match="/tag">
		<div class="row">
			<div class="headline">
				<div class="box1">
					<ul class="title">
						<li class="left"></li>
						<li>
							<span>
								<xsl:value-of select="/tag/category1/category/categoryname"/>
							</span>
						</li>
						<li class="right"></li>
						<li class="more">
							<a class="more1" href="/newslist-{/tag/category1/category/categoryname}.html"></a>
						</li>
					</ul>
					<div class="content">
						<img class="thumbnail" src="pictures/news.jpg" />
						<ul class="articleList_1 bullet_2">
							<xsl:for-each select="/tag/category1/newslist/news">
								<li>
									<a href="/news-{newsid}.html">
										<xsl:value-of select="title"/>
									</a>
								</li>
							</xsl:for-each>
						</ul>
					</div>
					<ul class="bottom">
						<li class="left"></li>
						<li class="right"></li>
					</ul>
				</div>
			</div>

			<div class="highEnd newblock">
				<div class="box1">
					<ul class="title">
						<li class="left"></li>
						<li>
							<span>
								<xsl:value-of select="/tag/category2/category/categoryname"/>
							</span>
						</li>
						<li class="right"></li>
						<li class="more">
							<a class="more1" href="/newslist-{/tag/category2/category/categoryname}.html"></a>
						</li>
					</ul>
					<div class="content">
						<ul class="articleList_1 bullet_2">
							<xsl:for-each select="/tag/category2/newslist/news">
								<li>
									<a href="/news-{newsid}.html">
										<xsl:value-of select="title"/>
									</a>
								</li>
							</xsl:for-each>
						</ul>
					</div>
					<ul class="bottom">
						<li class="left"></li>
						<li class="right"></li>
					</ul>
				</div>
			</div>
		</div>
	</xsl:template>
</xsl:stylesheet>