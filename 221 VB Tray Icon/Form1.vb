' 221 VB Tray Icon
' 2012-02-25	PV  VS2010

Public Class Form1

    Private Sub Commande1ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Commande1ToolStripMenuItem.Click
        MsgBox("Commande 1")
    End Sub

    Private Sub Commande2ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Commande2ToolStripMenuItem.Click
        MsgBox("Commande 2")
    End Sub

    Private Sub Commande3ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Commande3ToolStripMenuItem.Click
        MsgBox("Commande 3")
    End Sub

    Private Sub NotifyIcon1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseDown

    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        PictureBox1.Image = New Bitmap("..\Music.gif")
    End Sub
End Class
