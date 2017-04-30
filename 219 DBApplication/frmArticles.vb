Public Class frmArticles

    Private Sub frmArticles_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: Delete this line of code to remove the default AutoFill for 'TotoDataSet.Articles'.
        Me.ArticlesTableAdapter.Fill(Me.TotoDataSet.Articles)

    End Sub
End Class