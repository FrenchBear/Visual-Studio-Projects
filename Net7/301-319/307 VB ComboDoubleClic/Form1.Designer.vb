Imports System.ComponentModel
Imports Microsoft.VisualBasic.CompilerServices

<DesignerGenerated()>
Partial Class Form1
    Inherits Form

    'Form overrides dispose to clean up the component list.
    <DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.ComboBox1 = New ComboBox()
        Me.Label1 = New Label()
        Me.Label2 = New Label()
        Me.SuspendLayout()
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New Point(65, 31)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New Size(373, 21)
        Me.ComboBox1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New Point(62, 105)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New Size(182, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Combo is filled only when it is opened"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New Point(62, 130)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New Size(187, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Double-click on combo to open Form2"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.ClientSize = New Size(521, 272)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ComboBox1)
        Me.Name = "Form1"
        Me.Text = "307 VB ComboDoubleClic"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label

End Class
