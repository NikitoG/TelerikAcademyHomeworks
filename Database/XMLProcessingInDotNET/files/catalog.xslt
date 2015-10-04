<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

  <xsl:template match="/">
    <html>
      <body>
        <table border="1">
          <tr  bgcolor="#9acd32">
            <th colspan="7">Catalogue</th>
          </tr>
          <tr bgcolor="#9acd32">
            <th rowspan="2">Name</th>
            <th rowspan="2">Artist</th>
            <th rowspan="2">Year</th>
            <th rowspan="2">Producer</th>
            <th rowspan="2">Price</th>
            <th colspan="2">Songs</th>
          </tr>
          <tr bgcolor="#9acd32">
            <th>Title</th>
            <th>Lenght</th>
          </tr>
          <xsl:for-each select="/catalogue/album">
            <tr>
              <td>
                <xsl:value-of select="name"/>
              </td>
              <td>
                <xsl:value-of select="artist"/>
              </td>
              <td>
                <xsl:value-of select="year"/>
              </td>
              <td>
                <xsl:value-of select="producer"/>
              </td>
              <td>
                <xsl:value-of select="price"/>
              </td>
              <td colspan="2">
                <xsl:for-each select="/catalogue/album/song">
                  <xsl:value-of select="@title"/> - <xsl:value-of select="@length"/>
                  <hr />
                </xsl:for-each>
              </td>
            </tr>
          </xsl:for-each>
        </table>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>
