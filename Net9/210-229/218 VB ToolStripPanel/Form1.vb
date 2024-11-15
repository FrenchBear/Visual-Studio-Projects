' 218 VB Rafting Menus
'
' 2012-02-25	PV		VS2010
' 2021-09-19 	PV		VS2022; Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9

Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim f2 As New Form2
        f2.Show()
    End Sub

    Private Sub B1ToolStripButton_Click(sender As Object, e As EventArgs) Handles B1ToolStripButton.Click
        MsgBox("B1ToolStripButton_Click")
    End Sub

    Private Sub LabelToolStripLabel_Click(sender As Object, e As EventArgs) Handles LabelToolStripLabel.Click
        MsgBox("LabelToolStripLabel_Click")
    End Sub

    Private Sub X1ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles X1ToolStripMenuItem.Click
        MsgBox("X1ToolStripMenuItem_Click")
    End Sub

    Private Sub X2ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles X2ToolStripMenuItem.Click
        MsgBox("X2ToolStripMenuItem_Click")
    End Sub

    Private Sub SBToolStripSplitButton_Click(sender As Object, e As EventArgs) Handles SBToolStripSplitButton.Click
        MsgBox("SBToolStripSplitButton_Click")
    End Sub

    Private Sub B2ToolStripButton_Click(sender As Object, e As EventArgs) Handles B2ToolStripButton.Click
        Shell("Calc")

    End Sub

End Class
