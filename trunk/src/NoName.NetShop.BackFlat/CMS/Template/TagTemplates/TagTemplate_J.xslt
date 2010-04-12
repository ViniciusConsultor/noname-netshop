<?xml version="1.0" encoding="utf-8" ?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:output method="html" doctype-system="http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd" doctype-public="-//W3C//DTD XHTML 1.0 Transitional//EN" indent="yes"/>

	<xsl:template match="/">
		<html xmlns="http://www.w3.org/1999/xhtml">
			<head>
			</head>
			<body>
				<div class="row newline">
					<xsl:apply-templates select="/tag/pawn"/>
					<xsl:apply-templates select="/tag/rent"/>
				</div>
			</body>
		</html>
	</xsl:template>

	
	<xsl:template match="/tag/pawn">
		<div class="box1 normalBlock">
			<ul class="title">
				<li class="left"></li>
				<li>
					<span>最新典当</span>
				</li>
				<li class="right"></li>
				<li class="more">
					<a class="more1" href="/Magic/PawnList.aspx"></a>
				</li>
			</ul>
			<div class="content">
				<ul class="itemList4">
					<xsl:for-each select="pawnproduct">
						<li>
							<a href="/Magic/PawnProduct.aspx?pid={pid}">
								<img src="{image}" />
							</a>
							<div class="infoContainer">
								<ul class="info">
									<li>
										<span class="field">商品名称:</span>
										<span class="name">
											<a href="/Magic/PawnProduct.aspx?pid={pid}">留声机</a>
										</span>
									</li>
									<li>
										<span class="field">价格:</span>
										<span>
											<xsl:value-of select="price"/> 元 </span>
									</li>
									<li>
										<span class="field">绝当时间:</span>
										<span>
											<xsl:value-of select="deadtime"/>
										</span>
									</li>
								</ul>
							</div>
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
	<xsl:template match="/tag/rent">
		<div class="box1 normalBlock newblock">
			<ul class="title">
				<li class="left"></li>
				<li>
					<span>最新开租</span>
				</li>
				<li class="right"></li>
				<li class="more">
					<a class="more1" href="/Magic/RentList.aspx"></a>
				</li>
			</ul>
			<div class="content">
				<ul class="articleList_1 bullet_2">
					<xsl:for-each select="rentlist">
						<li>
							<a href="/Magic/Rent.aspx?pid={rentid}">
								<xsl:value-of select="rentname"/>
								<span class="date">(<xsl:value-of select="createtime"/>)</span>
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