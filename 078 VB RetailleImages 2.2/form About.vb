' CheckSP About form
' 2006-05-03 FPVI

#Disable Warning IDE1006 ' Naming Styles

Public Class frmAbout

    Private Sub frmAbout_Load(sender As System.Object, e As EventArgs) Handles MyBase.Load
        lblTitle.Text = My.Application.Info.Title & " - " & My.Application.Info.Description
        lblCopyright.Text = My.Application.Info.Copyright
        lblBuild.Text = "Build " & My.Application.Info.Version.ToString
    End Sub

End Class