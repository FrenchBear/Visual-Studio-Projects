' 2012-02-25	PV  VS2010
' 2021-09-19    PV  VS2022; Net6

#Disable Warning IDE1006 ' Naming Styles
#Disable Warning IDE0051 ' Remove unused private members

Public Class frmDerived
    Inherits TemplateForm

    Private Sub InitializeComponent()
        Me.Button1 = New Button
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New Point(13, 115)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New Size(166, 192)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frmDerived
        '
        Me.AutoScaleDimensions = New SizeF(6.0!, 13.0!)
        Me.ClientSize = New Size(294, 341)
        Me.Controls.Add(Me.Button1)
        Me.Name = "frmDerived"
        Me.Controls.SetChildIndex(Me.Button1, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button

    Private Sub Button1_Click(sender As System.Object, e As EventArgs) Handles Button1.Click
        MsgBox("Hello")
    End Sub

End Class