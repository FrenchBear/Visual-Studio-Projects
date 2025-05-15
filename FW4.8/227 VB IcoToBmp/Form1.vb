' 227 VB IcoToBmp
' 2012-02-25	PV  VS2010 - Do not execute!

Public Class Form1

    'Const sSource As String = "D:\Développement\Visual Studio Projects\075 VB AfficheImage2\Icônes 2.1"
    'Const sDest As String = "D:\Développement\Visual Studio Projects\075 VB AfficheImage2\Icônes 2.1\bmp"
    Const sSource As String = "ZZC:\Development\Icons\Office 2003 Icons\Office 2003 Alpha Icons (ico 8bit)"

    Const sDest As String = "ZZC:\C:\Development\Icons\Office 2003 Icons\Office 2003 Alpha Icons (png 8bit)"

    Private Sub Button1_Click(sender As System.Object, e As EventArgs) Handles Button1.Click
        Dim sFile As String
        For Each sFile In My.Computer.FileSystem.GetFiles(sSource)
            Convert(sFile)
        Next
        MsgBox("Done")
    End Sub

    Sub Convert(sFile As String)
        Dim i As Image
        i = System.Drawing.Image.FromFile(sFile)

        i.Save(Replace(sDest & "\" & My.Computer.FileSystem.GetName(sFile), ".ico", ".png"), System.Drawing.Imaging.ImageFormat.Png)
    End Sub

End Class