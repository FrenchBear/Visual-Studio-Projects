' CheckSP About form
'
' 2006-05-03    PV
' 2012-02-25	PV  VS2010
' 2021-09-20    PV  VS2022; Net6
' 2023-01-10	PV		Net7

#Disable Warning IDE1006 ' Naming Styles

Public Class frmAbout

    Private Sub frmAbout_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblTitle.Text = My.Application.Info.Title & " - " & My.Application.Info.Description
        lblCopyright.Text = My.Application.Info.Copyright
        lblBuild.Text = "Version " & My.Application.Info.Version.ToString
    End Sub

End Class
