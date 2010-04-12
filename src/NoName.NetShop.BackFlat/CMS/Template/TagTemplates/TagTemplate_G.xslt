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
		<div class="box1 newline">
			<ul class="title">
				<li class="left"></li>
				<li>
					<span>影院播报</span>
				</li>
				<li class="right"></li>
				<li class="more">
					<a class="more1" href="/newslist-43.html"></a>
				</li>
			</ul>
			<div class="content">
				<ul class="videoNews">
					<xsl:for-each select="/tag/newslist/news">
						<li>
							<a href="/news-{newsid}.html">
								<img src="{image}" />
								<span>
									<xsl:value-of select="title"/>
								</span>
								<div class="playButton"></div>
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