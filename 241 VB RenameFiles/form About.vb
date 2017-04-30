' CheckSP About form
' 2006-05-03    PV
' 2012-02-25	PV  VS2010

Public Class frmAbout
    Private Sub frmAbout_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblTitle.Text = My.Application.Info.Title & " - " & My.Application.Info.Description
        lblCopyright.Text = My.Application.Info.Copyright
        lblBuild.Text = "Version " & My.Application.Info.Version.ToString
    End Sub
End Class