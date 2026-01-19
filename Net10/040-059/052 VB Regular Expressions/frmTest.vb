' Play with Regex in VB.Net
'
' 2001-06-26    PV
' 2006-10-01 	PV		VS 2005
' 2021-09-18 	PV		VS2022, Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9
' 2026-01-19	PV		Net10

Imports System.Windows.Forms

#Disable Warning IDE1006 ' Naming Styles
#Disable Warning IDE0052 ' Remove unread private members

Public Class frmTest
    Inherits Form

    Public Sub New()
        MyBase.New()

        Form1 = Me

        'This call is required by the Win Form Designer.
        InitializeComponent()

        'TODO: Add any initialization after the InitializeComponent() call
    End Sub

    'Form overrides dispose to clean up the component list.
    Public Overloads Sub Dispose()
        MyBase.Dispose()
        components.Dispose()
    End Sub

#Region " Windows Form Designer generated code "

    'Required by the Windows Form Designer
    Private ReadOnly components As System.ComponentModel.Container

    Private WithEvents TextBox1 As TextBox
    Private WithEvents btnTestA As Button
    Private WithEvents btnTestRE As Button

    Public WithEvents Form1 As Form

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        btnTestRE = New Button
        btnTestA = New Button
        TextBox1 = New TextBox
        SuspendLayout()
        '
        'btnTestRE
        '
        btnTestRE.Location = New Drawing.Point(192, 20)
        btnTestRE.Name = "btnTestRE"
        btnTestRE.Size = New Drawing.Size(88, 23)
        btnTestRE.TabIndex = 0
        btnTestRE.Text = "Test RegEx"
        '
        'btnTestA
        '
        btnTestA.Location = New Drawing.Point(192, 60)
        btnTestA.Name = "btnTestA"
        btnTestA.Size = New Drawing.Size(88, 23)
        btnTestA.TabIndex = 2
        btnTestA.Text = "Test Automate"
        '
        'TextBox1
        '
        TextBox1.Location = New Drawing.Point(16, 20)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Drawing.Size(126, 20)
        TextBox1.TabIndex = 1
        TextBox1.Text = "F.73.123.CEE-TEST"
        '
        'frmTest
        '
        AutoScaleBaseSize = New Drawing.Size(5, 13)
        ClientSize = New Drawing.Size(292, 273)
        Controls.Add(btnTestA)
        Controls.Add(TextBox1)
        Controls.Add(btnTestRE)
        Name = "frmTest"
        Text = "Form1"
        ResumeLayout(False)
        PerformLayout()

    End Sub

#End Region

    Private Sub btnTest_Click_1(sender As Object, e As EventArgs) Handles btnTestRE.Click
        If bCtrlFournisseurRE(TextBox1.Text) Then
            MsgBox("Ok")
        Else
            MsgBox("Problème")
        End If
    End Sub

    Private Sub btnTestA_Click(sender As Object, e As EventArgs) Handles btnTestA.Click
        If bCtrlFournisseurA(TextBox1.Text) Then
            MsgBox("Ok")
        Else
            MsgBox("Problème")
        End If
    End Sub

End Class
