' 19 DB Application
' Essais ADO.Net 2.0
' 2004/10/19 FPVI

Public Class frmMain

    Private Sub btnClients_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClients.Click
        Dim f As New frmClients
        f.Show()
    End Sub

    Private Sub btnArticles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnArticles.Click
        Dim f As New frmArticles
        f.Show()
    End Sub

    Private Sub btnClients2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClients2.Click
        Dim f As New frmClients2
        f.Show()
    End Sub

End Class