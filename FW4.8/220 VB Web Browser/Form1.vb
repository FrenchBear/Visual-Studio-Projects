' 220 Web Browser
' 2012-02-25	PV  VS2010

Public Class Form1

    Private Sub Button1_Click(sender As System.Object, e As EventArgs) Handles Button1.Click
        WebBrowser1.Url = New Uri("C:\Documents\Doc tech\All about application icons.htm")
    End Sub

    Private Sub WebBrowser1_DocumentCompleted(sender As System.Object, e As WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        MsgBox("Chargé !")
    End Sub

End Class