' 2012-02-25	PV		VS2010
' 2021-09-19 	PV		VS2022; Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9
' 2026-01-19	PV		Net10

Public Class TemplateUserControl

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs)
        GroupBox1.Dock = If(GroupBox1.Dock = DockStyle.None, DockStyle.Top, DockStyle.None)
    End Sub

End Class
