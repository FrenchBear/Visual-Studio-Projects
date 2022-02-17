Imports System.ComponentModel
Imports Microsoft.VisualBasic.CompilerServices

<DesignerGenerated()>
Partial Class Form1
    Inherits Form

    'Form overrides dispose to clean up the component list.
    <DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Button1 = New Button()
        Me.ProgressBar1 = New ProgressBar()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New Point(444, 30)
        Me.Button1.Margin = New Padding(6, 7, 6, 7)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New Size(162, 57)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Convert"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New Point(12, 119)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New Size(609, 46)
        Me.ProgressBar1.TabIndex = 1
        '
        'Form1
        '
        Me.AutoScaleDimensions = New SizeF(13.0!, 32.0!)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.ClientSize = New Size(633, 216)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.Button1)
        Me.Margin = New Padding(6, 7, 6, 7)
        Me.Name = "Form1"
        Me.Text = "Convert Ico to Bmp"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button1 As Button
    Friend WithEvents ProgressBar1 As ProgressBar
End Class
