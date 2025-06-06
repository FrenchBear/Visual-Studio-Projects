﻿' 234 XMLConfig 1 (XmlDocument)
'
' 2012-02-25	PV		VS2010
' 2021-09-20 	PV		VS2022; Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9

Imports System.Xml

Friend Module Module1
    Public Sub Main()
#Disable Warning BC40000
        Dim xmlDoc As New XmlDataDocument
        'd.LoadXml("<DBToolConfig Version=""1.0""><Info><SavedOn>2006/03/28 08:01:17</SavedOn><SavedBy>FPVI</SavedBy></Info><Config name=""Conf 1""><Database server=""cc"" base=""yy"" user=""zz"" password=""tt""></Database></Config><Config name=""Conf 2""><Database server=""cc2"" base=""yy2"" user=""zz2"" password=""tt2""></Database></Config></DBToolConfig>")

        Dim xmlVersion As XmlProcessingInstruction
        xmlVersion = xmlDoc.CreateProcessingInstruction("xml", "version=""1.0"" encoding=""UTF-8""")
        xmlDoc.AppendChild(xmlVersion)

        Dim myComment As XmlComment
        myComment = xmlDoc.CreateComment("This is a comment")
        xmlDoc.AppendChild(myComment)

        Dim rootElement As XmlElement
        rootElement = xmlDoc.CreateElement("DBToolConfig")
        rootElement.SetAttribute("Version", "1.0")
        xmlDoc.AppendChild(rootElement)

        Dim InfoElement As XmlElement
        InfoElement = xmlDoc.CreateElement("Info")
        AddNode(xmlDoc, InfoElement, "SavedOn", Format(Now, "yyyy/mm/dd hh:mm:ss"))
        AddNode(xmlDoc, InfoElement, "SavedBy", "FPVI")
        rootElement.AppendChild(InfoElement)

        xmlDoc.Save("c:\test.xml")
    End Sub

#Disable Warning BC40000

    Private Sub AddNode(Doc As XmlDataDocument, BaseNode As XmlElement, sName As String, sVal As String)
        If sVal = vbNullString Then Exit Sub
        Dim PropElement As XmlElement
        PropElement = Doc.CreateElement(sName)
        PropElement.InnerText = Replace(sVal, vbCrLf, "¶")
        BaseNode.AppendChild(PropElement)
    End Sub

End Module
