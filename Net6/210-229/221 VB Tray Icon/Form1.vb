' 221 VB Tray Icon
'
' 2012-02-25	PV  VS2010
' 2021-09-19    PV  VS2022; Net6

Public Class Form1

    Private Sub Commande1ToolStripMenuItem_Click(sender As System.Object, e As EventArgs) Handles Commande1ToolStripMenuItem.Click
        MsgBox("Commande 1")
    End Sub

    Private Sub Commande2ToolStripMenuItem_Click(sender As System.Object, e As EventArgs) Handles Commande2ToolStripMenuItem.Click
        MsgBox("Commande 2")
    End Sub

    Private Sub Commande3ToolStripMenuItem_Click(sender As System.Object, e As EventArgs) Handles Commande3ToolStripMenuItem.Click
        MsgBox("Commande 3")
    End Sub

    Private Sub NotifyIcon1_MouseDown(sender As System.Object, e As MouseEventArgs) Handles NotifyIcon1.MouseDown

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        PictureBox1.Image = New Bitmap("Music.gif")
    End Sub

End Class