' 2012-02-25	PV  VS2010

Public Class ucTemplate

    Private Sub ToolStripButton1_Click(sender As System.Object, e As EventArgs)
        If GroupBox1.Dock = DockStyle.None Then
            GroupBox1.Dock = DockStyle.Top
        Else
            GroupBox1.Dock = DockStyle.None
        End If
    End Sub

End Class