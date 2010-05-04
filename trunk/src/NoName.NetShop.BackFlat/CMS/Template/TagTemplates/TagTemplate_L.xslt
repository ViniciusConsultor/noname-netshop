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
					<span>最新二手交易</span>
				</li>
				<li class="right"></li>
				<li class="more">
					<a class="more1" href="/Magic/DealList.aspx"></a>
				</li>
			</ul>
			<div class="content">
				<div id="productList" class="list_horizontal">
					<ul>
						<xsl:for-each select="deal">
							<li>
								<a title="{pname}">
									<xsl:attribute name="href">
										<xsl:choose>
											<xsl:when test="ptype = '1'">
												/Magic/Secondhand.aspx?pid=<xsl:value-of select="pid"/>
											</xsl:when>
											<xsl:otherwise>
												/Magic/Demand.aspx?pid=<xsl:value-of select="pid"/>
											</xsl:otherwise>
										</xsl:choose> 
									</xsl:attribute>
									<img src="{mediumimage}" />
									<span class="price">
										报价：￥<xsl:value-of select="price"/>
									</span>
									<span class="name" title="{pname}">
                                        <xsl:choose>
                                            <xsl:when test="ptype = 1">
                                                <span style="color:red">[出售] </span>
                                            </xsl:when>
                                            <xsl:otherwise>
                                                <span style="color:#207720">[求购] </span> 
                                            </xsl:otherwise>
                                        </xsl:choose>
										<xsl:value-of select="pname"/>
									</span>
									<span class="commentsNum"></span>
								</a>
							</li>
						</xsl:for-each>
					</ul>
				</div>
			</div>
			<ul class="bottom">
				<li class="left"></li>
				<li class="right"></li>
			</ul>
		</div>
	</xsl:template>
</xsl:stylesheet>