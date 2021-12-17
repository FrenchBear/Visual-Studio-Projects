' 227 VB IcoToBmp
'
' 2012-02-25	PV  VS2010 - Do not execute!
' 2021-09-19    PV  VS2022; Net6. Added progressbar and create temp folder

Imports System.IO


Public Class Form1

    'Const sSource As String = "D:\Développement\Visual Studio Projects\075 VB AfficheImage2\Icônes 2.1"
    'Const sDest As String = "D:\Développement\Visual Studio Projects\075 VB AfficheImage2\Icônes 2.1\bmp"
    Const sSource As String = "C:\Development\Icons\Office 2003 Icons\Office 2003 Alpha Icons - ico 8bit"
    Const sDest As String = "c:\temp\Office 2003 Alpha Icons (png 8bit)"

    Private Sub Button1_Click(sender As System.Object, e As EventArgs) Handles Button1.Click
        If Not Directory.Exists(sDest) Then Directory.CreateDirectory(sDest)
        Dim files = My.Computer.FileSystem.GetFiles(sSource)
        Dim sFile As String
        ProgressBar1.Maximum = files.Count
        Dim i As Integer = 0
        For Each sFile In files
            Convert(sFile)
            i += 1
            ProgressBar1.Value = i
            ProgressBar1.Refresh()
        Next
        MsgBox("Done")
    End Sub

    Sub Convert(sFile As String)
        Dim i As Image
        i = Image.FromFile(sFile)

        i.Save(Replace(sDest & "\" & My.Computer.FileSystem.GetName(sFile), ".ico", ".png"), Imaging.ImageFormat.Png)
    End Sub

End Class