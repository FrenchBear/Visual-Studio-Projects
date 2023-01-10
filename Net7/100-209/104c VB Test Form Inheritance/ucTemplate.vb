' 2012-02-25	PV  VS2010
' 2021-09-19    PV  VS2022; Net6
' 2023-01-10	PV		Net7

Public Class TemplateUserControl

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs)
        If GroupBox1.Dock = DockStyle.None Then
            GroupBox1.Dock = DockStyle.Top
        Else
            GroupBox1.Dock = DockStyle.None
        End If
    End Sub

End Class
