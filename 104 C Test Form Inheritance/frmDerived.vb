' 2012-02-25	PV  VS2010

Public Class frmDerived
    Inherits frmTemplate

    Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(13, 115)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(166, 192)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frmDerived
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(294, 341)
        Me.Controls.Add(Me.Button1)
        Me.Name = "frmDerived"
        Me.Controls.SetChildIndex(Me.Button1, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        MsgBox("Hello")
    End Sub
End Class
