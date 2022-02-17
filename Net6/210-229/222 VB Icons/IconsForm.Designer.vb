Imports System.ComponentModel

Partial Public Class IconsForm
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
        Me.Button1 = New Button()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New Point(374, 13)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Button1"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New Size(5, 13)
        Me.ClientSize = New Size(461, 414)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form1"
        Me.Text = "222 VB Icons"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button1 As Button

End Class
