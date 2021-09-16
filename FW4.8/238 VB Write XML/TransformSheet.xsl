<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <!-- FPVI 2006-05-21
       Tests with Xml, XPath and XSL
  -->

  <xsl:template match="TheTestResults">
    <xsl:comment>Using XPath and XslStylesheet</xsl:comment>
    <TestResults>
      <xsl:apply-templates select="aresult" />
    </TestResults>
  </xsl:template>

  <xsl:template match="aresult">
    <result>
      <xsl:attribute name="id"><xsl:value-of select="@id"/></xsl:attribute>
      <xsl:apply-templates select="theinput" />
      <xsl:apply-templates select="expected" />
      <xsl:apply-templates select="passfail" />
    </result>
  </xsl:template>

  <xsl:template match="theinput">
    <input>
      <xsl:value-of select="."/>
    </input>
  </xsl:template>

  <xsl:template match="expected">
    <expected>
      <xsl:value-of select="."/>
    </expected>
  </xsl:template>

  <xsl:template match="passfail">
    <passfail>
      <xsl:value-of select="." />
    </passfail>
  </xsl:template>
  
</xsl:stylesheet>