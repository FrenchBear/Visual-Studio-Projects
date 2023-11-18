Imports System.ComponentModel

Partial Public Class Form1
    Inherits Form

    <DebuggerNonUserCode()>
    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

    End Sub

    'Form overrides dispose to clean up the component list.
    <DebuggerNonUserCode()>
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
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
        Me.Button1 = New Button
        Me.Button2 = New Button
        Me.Button3 = New Button
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New Point(205, 13)
        Me.Button1.Name = "Button1"
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Write"
        '
        'Button2
        '
        Me.Button2.Location = New Point(205, 43)
        Me.Button2.Name = "Button2"
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Read"
        '
        'Button3
        '
        Me.Button3.Location = New Point(205, 73)
        Me.Button3.Name = "Button3"
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "Iterate"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New Size(5, 13)
        Me.ClientSize = New Size(292, 266)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button

End Class
