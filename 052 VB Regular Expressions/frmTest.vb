' 26/06/01 PV
' 01/10/2006 PV VS 2005

Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms


Public Class frmTest
    Inherits System.Windows.Forms.Form

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
    Private components As System.ComponentModel.Container
    Private WithEvents TextBox1 As System.Windows.Forms.TextBox
    Private WithEvents btnTestA As System.Windows.Forms.Button
    Private WithEvents btnTestRE As System.Windows.Forms.Button

    Dim WithEvents Form1 As System.Windows.Forms.Form

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Me.btnTestRE = New System.Windows.Forms.Button
        Me.btnTestA = New System.Windows.Forms.Button
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.SuspendLayout()
        '
        'btnTestRE
        '
        Me.btnTestRE.Location = New System.Drawing.Point(192, 20)
        Me.btnTestRE.Name = "btnTestRE"
        Me.btnTestRE.Size = New System.Drawing.Size(88, 23)
        Me.btnTestRE.TabIndex = 0
        Me.btnTestRE.Text = "Test RegEx"
        '
        'btnTestA
        '
        Me.btnTestA.Location = New System.Drawing.Point(192, 60)
        Me.btnTestA.Name = "btnTestA"
        Me.btnTestA.Size = New System.Drawing.Size(88, 23)
        Me.btnTestA.TabIndex = 2
        Me.btnTestA.Text = "Test Automate"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(16, 20)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(126, 20)
        Me.TextBox1.TabIndex = 1
        Me.TextBox1.Text = "F.73.123.CEE-TEST"
        '
        'frmTest
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(292, 273)
        Me.Controls.Add(Me.btnTestA)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.btnTestRE)
        Me.Name = "frmTest"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub btnTest_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTestRE.Click
        If bCtrlFournisseurRE(TextBox1.Text) Then
            MsgBox("Ok")
        Else
            MsgBox("Problème")
        End If
    End Sub

    Private Sub btnTestA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTestA.Click
        If bCtrlFournisseurA(TextBox1.Text) Then
            MsgBox("Ok")
        Else
            MsgBox("Problème")
        End If
    End Sub

End Class
