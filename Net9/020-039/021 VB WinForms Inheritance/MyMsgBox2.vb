﻿' Classe MyMsgBox2
' Classe de base pour un héritage visuel (simple boîte d'info)
'
' 2001-01-27    PV
' 2021-09-18 	PV		VS2022, Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9
Imports System.Windows.Forms

#Disable Warning IDE1006 ' Naming Styles
#Disable Warning IDE0052 ' Remove unread private members

Public Class MyMsgBox2
    Inherits Form

    Public Sub New()
        MyBase.New()

        Form1 = Me

        'This call is required by the Win Form Designer.
        InitializeComponent()

        'TODO: Add any initialization after the InitializeComponent() call
    End Sub

    'Form overrides dispose to clean up the component list.
    Public Shadows Sub Dispose()
        MyBase.Dispose()
        components.Dispose()
    End Sub

#Region " Windows Form Designer generated code "

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container

    Protected WithEvents btnOk As Button
    Private WithEvents txtInfo As TextBox
    Private WithEvents Label1 As Label

    Public WithEvents Form1 As Form

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        components = New System.ComponentModel.Container
        btnOk = New Button
        Label1 = New Label
        txtInfo = New TextBox

        '@design Me.TrayHeight = 0
        '@design Me.TrayLargeIcon = False
        '@design Me.TrayAutoArrange = True
        btnOk.Location = New Drawing.Point(168, 112)
        btnOk.Size = New Drawing.Size(60, 24)
        btnOk.TabIndex = 2
        btnOk.Text = "OK"

        Label1.Location = New Drawing.Point(8, 12)
        Label1.Text = "Info :"
        Label1.Size = New Drawing.Size(28, 13)
        Label1.AutoSize = True
        Label1.TabIndex = 0

        txtInfo.Location = New Drawing.Point(52, 8)
        txtInfo.Multiline = True
        txtInfo.ScrollBars = ScrollBars.Vertical
        txtInfo.TabIndex = 1
        txtInfo.Size = New Drawing.Size(300, 96)
        Text = "Information"
        MaximizeBox = False
        AutoScaleBaseSize = New Drawing.Size(5, 13)
        MinimizeBox = False
        ClientSize = New Drawing.Size(356, 141)

        Controls.Add(btnOk)
        Controls.Add(txtInfo)
        Controls.Add(Label1)
    End Sub

#End Region

    Protected Sub btnOk_Click(sender As Object, e As EventArgs)
        Close()
    End Sub

    Public Overridable Sub Info(sMsg As String)
        txtInfo.Text = sMsg
        ShowDialog()
    End Sub

End Class
