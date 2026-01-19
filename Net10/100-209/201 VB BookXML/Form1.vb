' 2006-10-01 	PV		VS2005
' 2012-02-25	PV		VS2010
' 2021-09-19 	PV		VS2022; Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9
' 2026-01-19	PV		Net10

Imports System.IO
Imports System.Xml
Imports System.Xml.Serialization

Public Class Form1
    Public Class Book
        Public Class Chapitre
            Public numéro As Integer
            Public titre As String
            Public paages As Double

            Public Sub New()
            End Sub

            Public Sub New(n As Integer, t As String, p As Double)
                numéro = n : titre = t : paages = p
            End Sub

        End Class

        Public titre As String
        Public auteur As String
        Public quantité As Integer
        Public Chapites As New List(Of Chapitre)

        Public Overrides Function ToString() As String
            ToString = "Book:" & vbCrLf &
                    "  Title: " & titre & vbCrLf &
                    "  Auteur: " & auteur & vbCrLf &
                    "  Qté: " & quantité & vbCrLf &
                    "  Chapites: " & Chapites.ToString
        End Function

    End Class

    Public Function AppPath() As String
        Return My.Application.Info.DirectoryPath.Replace("\bin", "")
    End Function

    Public Sub WriteXML()
        Dim introToVB As New Book With {
            .titre = "Intro to Visual Basic",
            .auteur = "Moi",
            .quantité = 123
        }
        With introToVB.Chapites
            .Add(New Book.Chapitre(1, "Premier chapitre", 15.2))
            .Add(New Book.Chapitre(2, "Deuxième chapitre", 10))
            .Add(New Book.Chapitre(3, "Troisième chapitre", -7.7))
        End With

        Dim writer As New XmlSerializer(GetType(Book))
        Dim file As New StreamWriter(AppPath() & "\IntroToVB.xml")
        writer.Serialize(file, introToVB)
        file.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        WriteXML()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ReadXML()
    End Sub

    Public Sub ReadXML()
        Dim reader As New XmlSerializer(GetType(Book))
        Dim file As New StreamReader(AppPath() & "\IntroToVB.xml")
        Dim introToVB As Book
#Disable Warning CA5369 ' Use XmlReader for 'XmlSerializer.Deserialize()'
        introToVB = CType(reader.Deserialize(file), Book)

        MsgBox("read: " & introToVB.ToString)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        IterateThroughNodes()
    End Sub

    Private ReadOnly xmlString As String =
    "<CodeSnippet>                         " &
    "    <Title>Create a Button</Title>       " &
    "    <Keywords>                           " &
    "        <Keyword>Button</Keyword>        " &
    "        <Keyword>Controls</Keyword>      " &
    "    </Keywords>                          " &
    "    <Code>Dim save As New Button</Code>  " &
    "</CodeSnippet>                           "

    Private Sub IterateThroughNodes()
        Dim xml As New XmlDocument
        ' This example uses LoadXml. Use the Load method to load
        ' Xml from a file.
        xml.LoadXml(xmlString)
        Dim list As String = ""
        TraverseTree(list, xml, 0)
        MsgBox(list)
    End Sub

    Private Shared Sub TraverseTree(ByRef list As String, node As XmlNode, intLevel As Integer)
        ' Print out the node name or value for the current node.
        Dim tabs As String = StrDup(intLevel, vbTab)
        Dim text = If(node.NodeType = XmlNodeType.Text, node.Value, node.Name)
        list &= tabs & text & vbCrLf

        ' If the current node has children, call this same procedure,
        ' passing in that node. Increase intLevel to indent the output.
        Dim child As XmlNode
        If node.HasChildNodes Then
            For Each child In node.ChildNodes
                Call TraverseTree(list, child, intLevel + 1)
            Next
        End If
    End Sub

End Class
