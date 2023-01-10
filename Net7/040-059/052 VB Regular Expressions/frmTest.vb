' Play with Regex in VB.Net
'
' 2001-06-26    PV
' 2006-10-01    PV  VS 2005
' 2021-09-18    PV  VS2022, Net6
' 2023-01-10	PV		Net7
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

    Private WithEvents TextBox1 As Windows.Forms.TextBox
    Private WithEvents btnTestA As Windows.Forms.Button
    Private WithEvents btnTestRE As Windows.Forms.Button

    Dim WithEvents Form1 As Windows.Forms.Form

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Me.btnTestRE = New Windows.Forms.Button
        Me.btnTestA = New Windows.Forms.Button
        Me.TextBox1 = New Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'btnTestRE
        '
        Me.btnTestRE.Location = New Drawing.Point(192, 20)
        Me.btnTestRE.Name = "btnTestRE"
        Me.btnTestRE.Size = New Drawing.Size(88, 23)
        Me.btnTestRE.TabIndex = 0
        Me.btnTestRE.Text = "Test RegEx"
        '
        'btnTestA
        '
        Me.btnTestA.Location = New Drawing.Point(192, 60)
        Me.btnTestA.Name = "btnTestA"
        Me.btnTestA.Size = New Drawing.Size(88, 23)
        Me.btnTestA.TabIndex = 2
        Me.btnTestA.Text = "Test Automate"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New Drawing.Point(16, 20)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New Drawing.Size(126, 20)
        Me.TextBox1.TabIndex = 1
        Me.TextBox1.Text = "F.73.123.CEE-TEST"
        '
        'frmTest
        '
        Me.AutoScaleBaseSize = New Drawing.Size(5, 13)
        Me.ClientSize = New Drawing.Size(292, 273)
        Me.Controls.Add(Me.btnTestA)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.btnTestRE)
        Me.Name = "frmTest"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

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
