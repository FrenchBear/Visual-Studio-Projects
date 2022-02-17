Imports System.ComponentModel
Imports Microsoft.VisualBasic.CompilerServices

<DesignerGenerated()>
Partial Class UnknownEditor
    Inherits GenericEditor

    'Form overrides dispose to clean up the component list.
    <DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    'Required by the Windows Form Designer
    Private components As IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Button1 = New Button
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New Point(68, 142)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New Size(137, 59)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'UnknownEditor
        '
        Me.Controls.Add(Me.Button1)
        Me.Name = "UnknownEditor"
        Me.Size = New Size(285, 306)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button1 As Button

End Class
