﻿Imports System.ComponentModel

Partial Public Class FormMain
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
        Me.TableLayoutPanel1 = New TableLayoutPanel
        Me.Button10 = New Button
        Me.Button9 = New Button
        Me.Button8 = New Button
        Me.Button6 = New Button
        Me.Button5 = New Button
        Me.Button4 = New Button
        Me.Button3 = New Button
        Me.Button2 = New Button
        Me.Label1 = New Label
        Me.Button1 = New Button
        Me.Button11 = New Button
        Me.Button7 = New Button
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((((AnchorStyles.Top Or AnchorStyles.Bottom) _
                    Or AnchorStyles.Left) _
                    Or AnchorStyles.Right), AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 3
        Me.TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 33.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 34.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Button10, 2, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Button9, 1, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Button8, 0, 2)
        Me.TableLayoutPanel1.Controls.Add(Me.Button6, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Button5, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Button4, 2, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Button3, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Button2, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Label1, 2, 1)
        Me.TableLayoutPanel1.Location = New Point(13, 13)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 33.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 33.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 34.0!))
        Me.TableLayoutPanel1.Size = New Size(382, 357)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'Button10
        '
        Me.Button10.Dock = DockStyle.Top
        Me.Button10.Location = New Point(251, 238)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New Size(128, 35)
        Me.Button10.TabIndex = 20
        Me.Button10.Text = "Button10"
        '
        'Button9
        '
        Me.Button9.Dock = DockStyle.Fill
        Me.Button9.Location = New Point(125, 238)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New Size(120, 116)
        Me.Button9.TabIndex = 19
        Me.Button9.Text = "Button9"
        '
        'Button8
        '
        Me.Button8.Dock = DockStyle.Left
        Me.Button8.Location = New Point(3, 238)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New Size(55, 116)
        Me.Button8.TabIndex = 18
        Me.Button8.Text = "Button8"
        '
        'Button6
        '
        Me.Button6.Anchor = AnchorStyles.None
        Me.Button6.Location = New Point(147, 164)
        Me.Button6.Name = "Button6"
        Me.Button6.TabIndex = 16
        Me.Button6.Text = "Button6"
        '
        'Button5
        '
        Me.Button5.Anchor = AnchorStyles.None
        Me.Button5.Location = New Point(23, 164)
        Me.Button5.Name = "Button5"
        Me.Button5.TabIndex = 15
        Me.Button5.Text = "Button5"
        '
        'Button4
        '
        Me.Button4.Anchor = AnchorStyles.None
        Me.Button4.Location = New Point(277, 47)
        Me.Button4.Name = "Button4"
        Me.Button4.TabIndex = 14
        Me.Button4.Text = "Button4"
        '
        'Button3
        '
        Me.Button3.Anchor = AnchorStyles.None
        Me.Button3.Location = New Point(147, 47)
        Me.Button3.Name = "Button3"
        Me.Button3.TabIndex = 13
        Me.Button3.Text = "Button3"
        '
        'Button2
        '
        Me.Button2.Anchor = AnchorStyles.None
        Me.Button2.Location = New Point(23, 47)
        Me.Button2.Name = "Button2"
        Me.Button2.TabIndex = 9
        Me.Button2.Text = "Button2"
        '
        'Label1
        '
        Me.Label1.Anchor = AnchorStyles.None
        Me.Label1.BorderStyle = BorderStyle.FixedSingle
        Me.Label1.Location = New Point(265, 136)
        Me.Label1.Name = "Label1"
        Me.Label1.Padding = New Padding(2)
        Me.Label1.Size = New Size(100, 79)
        Me.Label1.TabIndex = 22
        Me.Label1.Text = "Ceci est un texte très long placé dans une cellule du contrôle Layout"
        '
        'Button1
        '
        Me.Button1.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles)
        Me.Button1.Location = New Point(402, 13)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New Size(75, 36)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Basic Data Entry Form"
        '
        'Button11
        '
        Me.Button11.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles)
        Me.Button11.Location = New Point(402, 56)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New Size(75, 36)
        Me.Button11.TabIndex = 5
        Me.Button11.Text = "Form1"
        '
        'Button7
        '
        Me.Button7.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles)
        Me.Button7.Location = New Point(402, 99)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New Size(75, 36)
        Me.Button7.TabIndex = 6
        Me.Button7.Text = "Form2"
        '
        'frmMain
        '
        Me.AutoScaleBaseSize = New Size(5, 13)
        Me.ClientSize = New Size(489, 382)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button11)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "frmMain"
        Me.Text = "Form1"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Button1 As Button
    Friend WithEvents Button10 As Button
    Friend WithEvents Button9 As Button
    Friend WithEvents Button8 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button11 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Button7 As Button

End Class
