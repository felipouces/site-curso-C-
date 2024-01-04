<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="xml" indent="yes"/>

	<xsl:template match="/">
		<xsl:variable name="recentItems" select="/rss/channel/item[position() &lt;= 10]" />

		<xsl:for-each select="$recentItems">
			<div style="margin:10px; width:300px; min-height:200px; float:left;
                background:url({enclosure/@url}); background-size: cover">
				<h3 style="background-color: black; color: white; opacity: 0.7">
					<a href="{link}" target="_blank" style="color:white; text-decoration:none">
						<xsl:value-of select="title" disable-output-escaping="yes"/>
					</a>
				</h3>
				<b style="background-color: black; color: white; opacity: 0.7">
					<xsl:value-of select="category"/>
				</b>
				<i style="background-color: black; color: white; opacity: 0.7">
					<xsl:value-of select="pubDate"/>
				</i>
			</div>
		</xsl:for-each>
	</xsl:template>
</xsl:stylesheet>
