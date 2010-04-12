<?xml version="1.0" encoding="utf-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:output method="html" doctype-system="http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd" doctype-public="-//W3C//DTD XHTML 1.0 Transitional//EN" indent="yes"/>

	<xsl:template match="/">
		<html xmlns="http://www.w3.org/1999/xhtml">
			<head>
			</head>
			<body>
				<div class="row newline">
					<div class="normalBlock">
						<xsl:apply-templates select="/tag/categorynode[position() = 1]"/>
					</div>
					<div class="normalBlock newblock">
						<xsl:apply-templates select="/tag/categorynode[position() = 2]"/>
					</div>
				</div>
			</body>
		</html>
	</xsl:template>

	<xsl:template match="/tag/categorynode[position() = 1]">
		<div class="box1">
			<ul class="title">
				<li class="left"></li>
				<li>
					<span>
						<xsl:value-of select="category/categoryname"/>
					</span>
				</li>
				<li class="right"></li>
				<li class="more">
					<a class="more1" href="/newslist-{category/categoryid}.html"></a>
				</li>
			</ul>
			<div class="content">
				<ul class="articleList_1 bullet_2">
					<xsl:for-each select="newslist/news">
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
	</xsl:template>

	<xsl:template match="/tag/categorynode[position() = 2]">
		<div class="box1">
			<ul class="title">
				<li class="left"></li>
				<li>
					<span>
						<xsl:value-of select="category/categoryname"/>
					</span>
				</li>
				<li class="right"></li>
				<li class="more">
					<a class="more1" href="/newslist-{category/categoryid}.html"></a>
				</li>
			</ul>
			<div class="content">
				<ul class="articleList_1 bullet_2">
					<xsl:for-each select="newslist/news">
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
	</xsl:template>
</xsl:stylesheet>