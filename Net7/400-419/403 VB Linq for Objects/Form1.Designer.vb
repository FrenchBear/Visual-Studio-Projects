﻿Imports System.ComponentModel
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
        Me.OutText = New TextBox()
        Me.Button1 = New Button()
        Me.SuspendLayout()
        '
        'OutText
        '
        Me.OutText.Anchor = CType((((AnchorStyles.Top Or AnchorStyles.Bottom) _
                    Or AnchorStyles.Left) _
                    Or AnchorStyles.Right), AnchorStyles)
        Me.OutText.Location = New Point(12, 12)
        Me.OutText.Multiline = True
        Me.OutText.Name = "OutText"
        Me.OutText.ScrollBars = ScrollBars.Vertical
        Me.OutText.Size = New Size(500, 400)
        Me.OutText.TabIndex = 0
        '
        'Button1
        '
        Me.Button1.Location = New Point(12, 430)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New Size(75, 23)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.ClientSize = New Size(524, 465)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.OutText)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OutText As TextBox
    Friend WithEvents Button1 As Button

End Class
