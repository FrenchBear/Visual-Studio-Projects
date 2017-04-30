' 220 Web Browser
' 2012-02-25	PV  VS2010

Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        WebBrowser1.Url = New Uri("C:\Documents\Doc tech\All about application icons.htm")
    End Sub

    Private Sub WebBrowser1_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs) Handles WebBrowser1.DocumentCompleted
        MsgBox("Chargé !")
    End Sub
End Class
