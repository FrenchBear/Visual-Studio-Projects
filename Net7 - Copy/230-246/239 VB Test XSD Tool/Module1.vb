' 239 VB Test XSD Tool
'
' 2012-02-25	PV  VS2010
' 2021-09-20    PV  VS2022; Net6
Imports System.Text
Imports System.Xml
Imports System.Xml.Serialization

Module Module1

    Sub Main()
        Dim p As New Project

        Dim t As New TargetType
        p.Target = t

        Dim m1 As New TargetTypeTaskMessage With {
            .Text = "Hello",
            .Importance = "High"
        }

        Dim m2 As New TargetTypeTaskMkDir With {
            .Directories = "c:\temp"
        }

        t.Items = New TaskType() {m1, m2}

        Dim s As New XmlSerializer(GetType(Project))
        Dim xtw As New XmlTextWriter("..\..\p.xml", Encoding.UTF8) With {
            .Formatting = Formatting.Indented
        }
        s.Serialize(xtw, p)
        xtw.Close()
    End Sub

End Module