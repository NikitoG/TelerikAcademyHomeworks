<?xml version="1.0" encoding="UTF-8"?>

<xsl:stylesheet version="1.0"
xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

  <xsl:template match="/">
    <html>
      <body>
        <h2>Telerik Academy</h2>
        <table border="1">
          <tr bgcolor="#9acd32">
            <th>Name</th>
            <th>Sex</th>
            <th>Birth Date</th>
            <th>Phone</th>
            <th>e-mail</th>
            <th>Course</th>
            <th>Specialty</th>
            <th>Faculty number</th>
            <th>Exams</th>
            <th>Enrollment</th>
          </tr>
          <xsl:for-each select="/students/student">
            <tr>
              <td>
                <xsl:value-of select="name"/>
              </td>
              <td>
                <xsl:value-of select="sex"/>
              </td>
              <td>
                <xsl:value-of select="birth-date"/>
              </td>
              <td>
                <xsl:value-of select="phone"/>
              </td>
              <td>
                <xsl:value-of select="email"/>
              </td>
              <td>
                <xsl:value-of select="course"/>
              </td>
              <td>
                <xsl:value-of select="specialty"/>
              </td>
              <td>
                <xsl:value-of select="faculty-number"/>
              </td>
              <td>
                <table border="1">
                  <tr bgcolor="#6C9ABA">
                    <th>Name</th>
                    <th>Tutor</th>
                    <th>score</th>
                  </tr>
                  <xsl:for-each select="exams/exam">
                    <tr>
                      <td>
                        <xsl:value-of select="name"/>
                      </td>
                      <td>
                        <table border="1">
                          <tr>
                            <td>
                              <xsl:value-of select="tutor/name"/>
                            </td>
                          </tr>
                          <tr>
                            <td>
                              <xsl:value-of select="tutor/endorsement"/>
                            </td>
                          </tr>
                        </table>
                      </td>
                      <td>
                        <xsl:value-of select="score"/>
                      </td>
                    </tr>
                  </xsl:for-each>
                </table>
              </td>
              <td>
                <table border="1">
                  <tr bgcolor="#6C9ABA">
                    <th>Date</th>
                    <th>Score</th>
                  </tr>
                  <tr>
                    <td>
                      <xsl:value-of select="enrollment/date"/>
                    </td>
                    <td>
                      <xsl:value-of select="enrollment/score"/>
                    </td>
                  </tr>
                </table>
              </td>
            </tr>
          </xsl:for-each>
        </table>
      </body>
    </html>
  </xsl:template>

</xsl:stylesheet>