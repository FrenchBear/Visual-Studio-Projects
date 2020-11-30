' 234 VB XMLConfig 2 (Serialize)
' 2012-02-25	PV  VS2010


Option Compare Text

Imports System.Xml
Imports System.Xml.Serialization
Imports System.IO


Public Class Form1
    Dim sConfigPath As String
    Dim all As CheckSPConfigurations


    Private Sub btnExecute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExecute.Click
        'If txtServer.Text = "" Or txtDatabase.Text = "" Then
        '    MsgBox("Invalid config, Server or Database empty", MsgBoxStyle.Exclamation)
        '    Exit Sub
        'End If

        ' Ok, Save config
        SaveConfig()

        MsgBox("Config saved")
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Const sConfigFile As String = "my configuration 2.xml"
        sConfigPath = Replace(Replace(My.Application.Info.DirectoryPath & "\" & sConfigFile, "\bin\debug\", "\"), "\bin\release\", "\")

        txtServer.Text = "ZEUS"
        txtDatabase.Text = "Eurodat506_EUMEDM"

        LoadConfig()

    End Sub

    Public Sub LoadConfig()
        If Not My.Computer.FileSystem.FileExists(sConfigPath) Then
            Dim c1 As New OneConfig With {
                .sConfigName = "Config #1",
                .sServer = "Server1",
                .sDatabase = "Database1",
                .tsSPExclusions = New String() {"Exclusion 1", "Exclusion 2", "Exclusion 3"}
            }
            Dim sf1 As New SourceFolder With {
                .sPath = "Path 1",
                .tsExtensions = New String() {"*.sql", "*.prc"}
            }
            Dim sf2 As New SourceFolder With {
                .sPath = "Path 2",
                .tsExtensions = New String() {"*.*"}
            }
            ReDim c1.tsfSourceFolders(1)
            c1.tsfSourceFolders(0) = sf1
            c1.tsfSourceFolders(1) = sf2

            Dim c2 As New OneConfig With {
                .sConfigName = "Config #2",
                .sServer = "Server2",
                .sDatabase = "Database2",
                .tsSPExclusions = New String() {"Exclusion 4", "Exclusion 5"}
            }
            Dim sf3 As New SourceFolder With {
                .sPath = "Path 3",
                .tsExtensions = New String() {"*.sql", "*.prc", "*.udf"}
            }
            ReDim c2.tsfSourceFolders(0)
            c2.tsfSourceFolders(0) = sf3

            all = New CheckSPConfigurations With {
                .savedOn = Now
            }
            ReDim all.Configs(1)
            all.Configs(0) = c1
            all.Configs(1) = c2

            MsgBox("New config created")
        Else
            Dim serializer As New XmlSerializer(GetType(CheckSPConfigurations))
            ' In case input format is incorrect...
            AddHandler serializer.UnknownNode, AddressOf serializer_UnknownNode
            AddHandler serializer.UnknownAttribute, AddressOf serializer_UnknownAttribute

            Dim fs As New FileStream(sConfigPath, FileMode.Open)
            all = CType(serializer.Deserialize(fs), CheckSPConfigurations)
        End If

        For Each c As OneConfig In all.Configs
            cboConfigurations.Items.Add(c.sConfigName)
        Next

    End Sub

    Private Sub serializer_UnknownNode(ByVal sender As Object, ByVal e As XmlNodeEventArgs)
        MsgBox("Unknown Node:" & e.Name & ControlChars.Tab & e.Text)
    End Sub

    Private Sub serializer_UnknownAttribute(ByVal sender As Object, ByVal e As XmlAttributeEventArgs)
        Dim attr As System.Xml.XmlAttribute = e.Attr
        MsgBox("Unknown attribute " & attr.Name & "='" & attr.Value & "'")
    End Sub


    Public Sub SaveConfig()
        ' Rename old config file .bak
        Try
            My.Computer.FileSystem.DeleteFile(sConfigPath & ".bak", FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.SendToRecycleBin)
        Catch ex As Exception
        End Try
        Try
            My.Computer.FileSystem.RenameFile(sConfigPath, IO.Path.GetFileName(sConfigPath) & ".bak")
        Catch ex As Exception
        End Try

        ' Then write new config
        Dim serializer As New XmlSerializer(GetType(CheckSPConfigurations))
        Dim writer As New StreamWriter(sConfigPath)
        serializer.Serialize(writer, all)
        writer.Close()
    End Sub

End Class


Public Class CheckSPConfigurations
    Public savedOn As Date
    Public Configs() As OneConfig
End Class

Public Class OneConfig
    <XmlAttribute("Name")>
    Public sConfigName As String

    Public sServer As String
    Public sDatabase As String
    Public tsSPExclusions() As String
    Public tsfSourceFolders() As SourceFolder
End Class

Public Class SourceFolder
    Public sPath As String
    Public tsExtensions() As String
End Class
