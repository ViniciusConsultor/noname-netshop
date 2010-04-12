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
		<div class="box2">
			<ul class="title">
				<li class="left"></li>
				<li>
					<span>分类导航</span>
				</li>
				<li class="right"></li>
			</ul>
			<div class="content noPaddingContentBox">
				<ul class="magicNavigator">
					<li>
						<a class="m1" href="#">
							<span></span>
						</a>
					</li>
					<li>
						<a class="m2" href="#">
							<span></span>
						</a>
					</li>
					<li>
						<a class="m3" href="#">
							<span></span>
						</a>
					</li>
					<li>
						<a class="m4" href="#">
							<span></span>
						</a>
					</li>
				</ul>
			</div>
		</div>
	</xsl:template>
</xsl:stylesheet>