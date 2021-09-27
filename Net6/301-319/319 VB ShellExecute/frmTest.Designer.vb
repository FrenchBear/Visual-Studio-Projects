<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmTest
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.btnShellExecute = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCommand = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btnShellExecute
        '
        Me.btnShellExecute.Location = New System.Drawing.Point(26, 177)
        Me.btnShellExecute.Margin = New System.Windows.Forms.Padding(6, 7, 6, 7)
        Me.btnShellExecute.Name = "btnShellExecute"
        Me.btnShellExecute.Size = New System.Drawing.Size(195, 57)
        Me.btnShellExecute.TabIndex = 0
        Me.btnShellExecute.Text = "ShellExecute"
        Me.btnShellExecute.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(26, 22)
        Me.Label1.Margin = New System.Windows.Forms.Padding(6, 0, 6, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(130, 32)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Command:"
        '
        'txtCommand
        '
        Me.txtCommand.Location = New System.Drawing.Point(26, 62)
        Me.txtCommand.Margin = New System.Windows.Forms.Padding(6, 7, 6, 7)
        Me.txtCommand.Name = "txtCommand"
        Me.txtCommand.Size = New System.Drawing.Size(732, 39)
        Me.txtCommand.TabIndex = 2
        Me.txtCommand.Text = "%SystemRoot%\system32\mspaint.exe ""C:\Users\Pierr\OneDrive\PicturesODPerso\2005\2" &
    "005-02 Titus\Titus 028.jpg"""
        '
        'frmTest
        '
        Me.AcceptButton = Me.btnShellExecute
        Me.AutoScaleDimensions = New System.Drawing.SizeF(13.0!, 32.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(789, 655)
        Me.Controls.Add(Me.txtCommand)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnShellExecute)
        Me.Margin = New System.Windows.Forms.Padding(6, 7, 6, 7)
        Me.Name = "frmTest"
        Me.Text = "Test ShellExecute"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnShellExecute As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCommand As System.Windows.Forms.TextBox

End Class
