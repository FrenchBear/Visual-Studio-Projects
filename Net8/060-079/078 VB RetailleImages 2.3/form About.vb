﻿' Simple About form
' 2006-05-03    PV (from CheckSP)
' 2012-02-25	PV		VS2010; .Net Framework Client Profile 4.0
' 2021-09-19 	PV		VS2022, Net6
' 2023-01-10	PV		Net7

Public Class AboutForm
    Private Sub AboutForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        TitleLabel.Text = My.Application.Info.Title & " - " & My.Application.Info.Description
        CopyrightLabel.Text = My.Application.Info.Copyright
        BuildLabel.Text = "Build " & My.Application.Info.Version.ToString
    End Sub
End Class
