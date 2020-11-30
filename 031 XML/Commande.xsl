<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

<xsl:template match="*"><xsl:apply-templates /></xsl:template>

<xsl:template match="text()"><xsl:value-of select="." /></xsl:template>

<xsl:template match="Order">

<TABLE width="100%" align="center" border="0" cellpadding="0" cellspacing ="0"  background="" borderColor="black">

	<TR>
	<TD>

		<TABLE width="100%" align="center" border="1" cellpadding="1" cellspacing ="0"  background=""  borderColor="white"
			style="WIDTH: 100%;FONT-FAMILY: Verdana, Tahoma, Helvetica, Arial; FONT-SIZE: 8pt;">
		<TR>
		<TD colspan="2" align="center" bgColor="#EEEEEE"><B>Order Information</B></TD>
		</TR>
		<TR>
		<TD width="35%" align="right"><B>Contact:</B></TD>
		<TD width="65%" align="left">
			<xsl:value-of select="Contact" />
		</TD>
		</TR>
		<TR>
		<TD width="35%" align="right"><B>Due Date:</B></TD>
		<TD width="65%" align="left">
			<xsl:value-of select="DueDate" />
		</TD>
		</TR>
		<TR>
		<TD width="35%" align="right"><B>Order Created On:</B></TD>
		<TD width="65%" align="left">
			<xsl:value-of select="CreatedDate" />
		</TD>
		</TR>
		<TR>
		<TD width="35%" align="right"><B>Order ID:</B></TD>
		<TD width="65%" align="left">
			<xsl:value-of select="@ID" />
		</TD>
		</TR>
		<TR><TD colspan="2">
		    <TABLE width="100%" align="center" border="1" cellpadding="1" cellspacing ="0"  background=""  borderColor="white"
			    style="WIDTH: 100%;FONT-FAMILY: Verdana, Tahoma, Helvetica, Arial; FONT-SIZE: 8pt;">
    			<TR>
				    <TD width="50%" valign="top">
					    <xsl:apply-templates select="Customer" />
         			</TD>
		    	    <TD width="50%" valign="top">
			     		<xsl:apply-templates select="OrderItems" />
    			    </TD>
     			</TR>
		    </TABLE>
			</TD></TR>
		</TABLE>
	</TD>
	</TR>
</TABLE>
</xsl:template>

<xsl:template match="Customer">

<TABLE width="100%" align="center" border="1" cellpadding="1" cellspacing ="0"  background=""  borderColor="white"
    style="WIDTH: 100%;FONT-FAMILY: Verdana, Tahoma, Helvetica, Arial; FONT-SIZE: 8pt;">
	<TR>
		<TD align="center" bgColor="#EEEEEE"><B>Customer Information</B></TD>
	</TR>
	<TR>
		<TD align="left">
			<xsl:value-of select="Name" /><BR />
			<xsl:value-of select="Address" /><BR />
			<xsl:value-of select="City" />, <xsl:value-of select="State" /> <xsl:value-of select="ZIP" /><BR />
		</TD>
	</TR>
	<TR>
		<TD align="center">
			<B>Customer ID:</B><xsl:value-of select="@ID" />
		</TD>
	</TR>
</TABLE>
</xsl:template>

<xsl:template match="OrderItems">
<TABLE width="100%" align="center" border="1" cellpadding="1" cellspacing ="0"  background=""  borderColor="white"
    style="WIDTH: 100%;FONT-FAMILY: Verdana, Tahoma, Helvetica, Arial; FONT-SIZE: 8pt;">
	<TR>
		<TD colspan="2" align="center" bgColor="#EEEEEE"><B>Line Items</B></TD>
	</TR>
	<TR>
		<TD width="75%" align="center" bgColor="#EEEEEE"><B>Name</B></TD>
		<TD width="25%" align="center" bgColor="#EEEEEE"><B>Qty</B></TD>
	</TR>
	<xsl:apply-templates select="OrderItem" />
</TABLE>
</xsl:template>
<xsl:template match="OrderItem">
	<TR>
		<TD width="75%" align="left">
			<xsl:value-of select="Name" />
		</TD>
		<TD width="25%" align="center">
			<xsl:value-of select="Quantity" />
		</TD>
	</TR>
</xsl:template>
</xsl:stylesheet>