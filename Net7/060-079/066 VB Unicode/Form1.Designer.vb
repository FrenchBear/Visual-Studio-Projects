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
        Me.MenuStrip1 = New MenuStrip()
        Me.mnuFichier = New ToolStripMenuItem()
        Me.QuitterCommand = New ToolStripMenuItem()
        Me.Button1 = New Button()
        Me.TextBox1 = New TextBox()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New Size(32, 32)
        Me.MenuStrip1.Items.AddRange(New ToolStripItem() {Me.mnuFichier})
        Me.MenuStrip1.Location = New Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New Size(846, 42)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'mnuFichier
        '
        Me.mnuFichier.DropDownItems.AddRange(New ToolStripItem() {Me.QuitterCommand})
        Me.mnuFichier.Name = "mnuFichier"
        Me.mnuFichier.Size = New Size(104, 38)
        Me.mnuFichier.Text = "&Fichier"
        '
        'cmdQuitter
        '
        Me.QuitterCommand.Name = "cmdQuitter"
        Me.QuitterCommand.Size = New Size(359, 44)
        Me.QuitterCommand.Text = "&Quitter"
        '
        'Button1
        '
        Me.Button1.Location = New Point(583, 222)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New Size(150, 46)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New Point(130, 378)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New Size(413, 39)
        Me.TextBox1.TabIndex = 2
        '
        'Form1
        '
        Me.AutoScaleDimensions = New SizeF(13.0!, 32.0!)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.ClientSize = New Size(846, 594)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "Form1"
        Me.Text = "VB066 Unicode"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents mnuFichier As ToolStripMenuItem
    Friend WithEvents QuitterCommand As ToolStripMenuItem
    Friend WithEvents Button1 As Button
    Friend WithEvents TextBox1 As TextBox
End Class
