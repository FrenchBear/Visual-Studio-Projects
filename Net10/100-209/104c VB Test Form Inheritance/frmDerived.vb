' 2012-02-25	PV		VS2010
' 2021-09-19 	PV		VS2022; Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9
' 2026-01-19	PV		Net10

#Disable Warning IDE1006 ' Naming Styles
#Disable Warning IDE0051 ' Remove unused private members

Public Class frmDerived
    Inherits TemplateForm

    Private Sub InitializeComponent()
        Button1 = New Button
        SuspendLayout()
        '
        'Button1
        '
        Button1.Location = New Point(13, 115)
        Button1.Name = "Button1"
        Button1.Size = New Size(166, 192)
        Button1.TabIndex = 2
        Button1.Text = "Button1"
        Button1.UseVisualStyleBackColor = True
        '
        'frmDerived
        '
        AutoScaleDimensions = New SizeF(6.0!, 13.0!)
        ClientSize = New Size(294, 341)
        Controls.Add(Button1)
        Name = "frmDerived"
        Controls.SetChildIndex(Button1, 0)
        ResumeLayout(False)
        PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MsgBox("Hello")
    End Sub

End Class
