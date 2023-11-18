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
        Me.WebBrowser1 = New WebBrowser()
        Me.Button1 = New Button()
        Me.SuspendLayout()
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Anchor = CType((((AnchorStyles.Top Or AnchorStyles.Bottom) _
            Or AnchorStyles.Left) _
            Or AnchorStyles.Right), AnchorStyles)
        Me.WebBrowser1.Location = New Point(31, 106)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.Size = New Size(1014, 762)
        Me.WebBrowser1.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New Point(31, 32)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New Size(180, 57)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Button1"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New Size(12, 32)
        Me.ClientSize = New Size(1073, 898)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.WebBrowser1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents WebBrowser1 As WebBrowser
    Friend WithEvents Button1 As Button

End Class
