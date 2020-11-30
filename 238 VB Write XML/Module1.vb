' Various ways of producing an Xml file
' From msdn magazine, June 2006
' 2006-05-21    PV
' 2012-02-25	PV  VS2010

Imports System.Xml

Module Module1

    ReadOnly tsHarness() As String = {
      "0001:3:3:3:3:3:Boatzee",
      "0002:5:5:2:2:2:FullHouse",
      "0003:6:5:4:3:1:SmallStraight"}

    Sub Main()
        Using_XmlTextWriter()
        Using_XmlDocument()
        Using_XPath_XslStylesheet()
        Using_DataSet()
        Using_XmlSerializer()

        Console.WriteLine("Done")
        Console.ReadLine()
    End Sub

    Sub Using_XmlTextWriter()
        Dim line, id, expected As String
        Dim tokens() As String

        Dim xtw As XmlTextWriter = New XmlTextWriter("..\..\TestResults1.xml", System.Text.Encoding.UTF8)
        With xtw
            .Formatting = Formatting.Indented
            .WriteStartDocument()
            .WriteComment("Using XmlTextWriter")
            .WriteStartElement("TestsResults")
        End With
        For Each line In tsHarness
            tokens = line.Split(":")
            id = tokens(0)
            expected = tokens(6)

            Dim h As Hand = New Hand(
              New Die(Integer.Parse(tokens(1))),
              New Die(Integer.Parse(tokens(2))),
              New Die(Integer.Parse(tokens(3))),
              New Die(Integer.Parse(tokens(4))),
              New Die(Integer.Parse(tokens(5))))

            With xtw
                .WriteStartElement("result")
                .WriteAttributeString("id", id)
                .WriteElementString("input", h.ToString)
                .WriteElementString("expected", expected)
                .WriteElementString("passfail", "Pass")
                .WriteEndElement()      ' </result>
            End With
        Next

        xtw.WriteEndElement()         ' </TestsResults>
        xtw.Close()
    End Sub

    Sub Using_XmlDocument()
        Dim line, id, expected As String
        Dim tokens() As String

        Dim xd As XmlDocument = New XmlDocument
        Dim root As XmlElement = xd.DocumentElement
        Dim xdec As XmlDeclaration = xd.CreateXmlDeclaration("1.0", "utf-8", Nothing)
        xd.InsertBefore(xdec, root)
        Dim xcom As XmlComment = xd.CreateComment("Using XmlDocument")
        xd.InsertAfter(xcom, xdec)

        Dim TestsResults As XmlElement = xd.CreateElement("TestsResults")

        For Each line In tsHarness
            tokens = line.Split(":")
            id = tokens(0)
            expected = tokens(6)

            Dim h As Hand = New Hand(
              New Die(Integer.Parse(tokens(1))),
              New Die(Integer.Parse(tokens(2))),
              New Die(Integer.Parse(tokens(3))),
              New Die(Integer.Parse(tokens(4))),
              New Die(Integer.Parse(tokens(5))))

            Dim resultEl As XmlElement = xd.CreateElement("result")
            resultEl.SetAttribute("id", id)

            Dim inputEL As XmlElement = xd.CreateElement("input")
            inputEL.InnerText = h.ToString
            resultEl.AppendChild(inputEL)

            Dim expectedEl As XmlElement = xd.CreateElement("expected")
            expectedEl.InnerText = expected
            resultEl.AppendChild(expectedEl)

            Dim passfailEl As XmlElement = xd.CreateElement("passfail")
            passfailEl.InnerText = "Pass"
            resultEl.AppendChild(passfailEl)

            TestsResults.AppendChild(resultEl)
        Next

        xd.InsertAfter(TestsResults, xcom)
        xd.Save("..\..\TestResults2.xml")
    End Sub

    Sub Using_XPath_XslStylesheet()
        ' First produce an xml file with a different format
        Dim line, id, expected As String
        Dim tokens() As String

        Dim xtw As XmlTextWriter = New XmlTextWriter("..\..\TestResults3_Intermediate.xml", System.Text.Encoding.UTF8)
        With xtw
            .Formatting = Formatting.Indented
            .WriteStartDocument()
            .WriteComment("Using XPath and XslStylesheet")
            .WriteStartElement("TheTestResults")                            ' Instead of <TestResults>
        End With
        For Each line In tsHarness
            tokens = line.Split(":")
            id = tokens(0)
            expected = tokens(6)

            Dim h As Hand = New Hand(
              New Die(Integer.Parse(tokens(1))),
              New Die(Integer.Parse(tokens(2))),
              New Die(Integer.Parse(tokens(3))),
              New Die(Integer.Parse(tokens(4))),
              New Die(Integer.Parse(tokens(5))))

            With xtw
                .WriteStartElement("aresult")                               ' Instead of <result>
                .WriteAttributeString("id", id)
                .WriteElementString("theinput", h.ToString)
                .WriteElementString("expected", expected)
                .WriteElementString("whenrun", Now.ToShortDateString & " " & Now.ToShortTimeString)       ' Extra element
                .WriteElementString("passfail", "Pass")
                .WriteEndElement()      ' </aresult>
            End With
        Next

        xtw.WriteEndElement()         ' </TheTestsResults>
        xtw.Close()

        ' Then transform this Xml file using an Xsl stylesteet
        Dim xpd As XPath.XPathDocument = New XPath.XPathDocument("..\..\TestResults3_Intermediate.xml")
        'Dim xslt As Xsl.XslTransform = New Xsl.XslTransform
        'xslt.Load("..\..\TransformSheet.xsl")
        Dim xslt2 As Xsl.XslCompiledTransform = New Xsl.XslCompiledTransform()
        xslt2.Load("..\..\TransformSheet.xsl")

        Dim xtw2 As XmlTextWriter = New XmlTextWriter("..\..\TestResults3.xml", System.Text.Encoding.UTF8) With {
            .Formatting = Formatting.Indented
        }
        xtw2.WriteStartDocument()
        xslt2.Transform(xpd, Nothing, xtw2, Nothing)
        xtw2.Close()
    End Sub

    Sub Using_DataSet()
        Dim line, id, expected As String
        Dim tokens() As String

        Dim ds As DataSet = New DataSet("TestResults")
        Dim dt As DataTable = New DataTable("result")
        With dt.Columns
            .Add("id")
            .Add("input")
            .Add("expected")
            .Add("passfail")
        End With
        dt.Columns("id").ColumnMapping = MappingType.Attribute
        ds.Tables.Add(dt)

        For Each line In tsHarness
            tokens = line.Split(":")
            id = tokens(0)
            expected = tokens(6)

            Dim h As Hand = New Hand(
              New Die(Integer.Parse(tokens(1))),
              New Die(Integer.Parse(tokens(2))),
              New Die(Integer.Parse(tokens(3))),
              New Die(Integer.Parse(tokens(4))),
              New Die(Integer.Parse(tokens(5))))

            Dim values(3) As Object
            values(0) = id
            values(1) = h.ToString
            values(2) = expected
            values(3) = "Pass"

            ds.Tables(0).Rows.Add(values)
        Next

        ds.WriteXml("..\..\TestResults4.xml")
    End Sub

    Sub Using_XmlSerializer()
        Dim line, id, expected As String
        Dim tokens() As String

        Dim s As Serialization.XmlSerializer = New Serialization.XmlSerializer(GetType(TestResults))
        Dim xtw As XmlTextWriter = New XmlTextWriter("..\..\TestResults5.xml", System.Text.Encoding.UTF8) With {
            .Formatting = Formatting.Indented
        }

        Dim testResults As TestResults = New TestResults

        For Each line In tsHarness
            tokens = line.Split(":")
            id = tokens(0)
            expected = tokens(6)

            Dim h As Hand = New Hand(
              New Die(Integer.Parse(tokens(1))),
              New Die(Integer.Parse(tokens(2))),
              New Die(Integer.Parse(tokens(3))),
              New Die(Integer.Parse(tokens(4))),
              New Die(Integer.Parse(tokens(5))))

            Dim r As Result = New Result With {
                .id = id,
                .input = h.ToString,
                .expected = expected,
                .passfail = "Pass"
            }

            testResults.Results.Add(r)
        Next

        s.Serialize(xtw, testResults)
        xtw.Close()
    End Sub

End Module

Public Class Result

    <Serialization.XmlAttribute()>
    Public id As String

    <Serialization.XmlElement("input")>
    Public input As String

    Public expected As String
    Public passfail As String
End Class

Public Class TestResults

    <Serialization.XmlElement(ElementName:="result", Type:=GetType(Result))>
    Public Results As ArrayList = New ArrayList

End Class

Class Hand
    Private ReadOnly tDice(4) As Die

    Public Sub New(d1 As Die, d2 As Die, d3 As Die, d4 As Die, d5 As Die)
        Debug.Assert(d1 IsNot Nothing)
        Debug.Assert(d2 IsNot Nothing)
        Debug.Assert(d3 IsNot Nothing)
        Debug.Assert(d4 IsNot Nothing)
        Debug.Assert(d5 IsNot Nothing)

        tDice(0) = d1
        tDice(1) = d2
        tDice(2) = d3
        tDice(3) = d4
        tDice(4) = d5
    End Sub

    Public Overrides Function ToString() As String
        Dim s As Text.StringBuilder = New Text.StringBuilder
        For i As Integer = 0 To 4
            If i > 0 Then s.Append(" ")
            s.Append(tDice(i).ToString)
        Next
        Return s.ToString
    End Function

End Class

Class Die
    Private ReadOnly value As Integer

    Public Sub New(v As Integer)
        Debug.Assert(v >= 1 And v <= 6)
        value = v
    End Sub

    Public Overrides Function ToString() As String
        Return "[" & value.ToString & "]"
    End Function

End Class