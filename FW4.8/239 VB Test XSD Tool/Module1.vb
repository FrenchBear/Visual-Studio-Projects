' 239 VB Test XSD Tool
' 2012-02-25	PV  VS2010

Module Module1

    Sub Main()
        Dim p As Project = New Project

        Dim t As TargetType = New TargetType
        p.Target = t

        Dim m1 As TargetTypeTaskMessage = New TargetTypeTaskMessage With {
            .Text = "Hello",
            .Importance = "High"
        }

        Dim m2 As TargetTypeTaskMkDir = New TargetTypeTaskMkDir With {
            .Directories = "c:\temp"
        }

        t.Items = New TaskType() {m1, m2}

        Dim s As Xml.Serialization.XmlSerializer = New Xml.Serialization.XmlSerializer(GetType(Project))
        Dim xtw As Xml.XmlTextWriter = New Xml.XmlTextWriter("..\..\p.xml", System.Text.Encoding.UTF8) With {
            .Formatting = Xml.Formatting.Indented
        }
        s.Serialize(xtw, p)
        xtw.Close()

        Console.WriteLine("Done")
        Console.ReadLine()
    End Sub

End Module