' Classe MyMsgBox3
' Dérive de MsgBox2
' 2001-01-27    PV

Imports System.Windows.Forms

#Disable Warning IDE1006 ' Naming Styles
#Disable Warning IDE0052 ' Remove unread private members

Public Class MyMsgBox3
    Inherits MyMsgBox2

    Public Sub New()
        MyBase.New()

        Form1 = Me

        'This call is required by the WinForm Designer.
        InitializeComponent()

        'TODO: Add any initialization after the InitializeComponent call
    End Sub

    'Form overrides dispose to clean up the component list.
    Public Shadows Sub Dispose()
        MyBase.Dispose()
        components.Dispose()
    End Sub

#Region " Windows Form Designer generated code "

    'Required by the WinForm Designer
    Private components As System.ComponentModel.Container

    Private WithEvents btnAide As Button

    Dim WithEvents Form1 As MyMsgBox2

    'NOTE: The following procedure is required by the WinForm Designer
    'It can be modified using the WinForm Designer.
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.btnAide = New Button

        '@design Me.TrayHeight = 0
        '@design Me.TrayLargeIcon = False
        '@design Me.TrayAutoArrange = True
        btnOk.Location = New Drawing.Point(52, 112)
        btnOk.BackColor = System.Drawing.Color.RosyBrown

        btnAide.Location = New Drawing.Point(124, 112)
        btnAide.Size = New Drawing.Size(56, 24)
        btnAide.TabIndex = 3
        btnAide.Text = "Aide"

        Me.AutoScaleBaseSize = New Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.RosyBrown

        Me.Controls.Add(btnAide)
    End Sub

#End Region

    Protected Sub btnAide_Click(sender As Object, e As EventArgs)
        MessageBox.Show("Aide", "Aide", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Public Overloads Overrides Sub Info(sMsg As String)
        MyBase.Info("Info: " & Chr(13) & Chr(10) & sMsg)
    End Sub

    Public Overloads Sub Info(sCode As String, sMsg As String)
        MyBase.Info("Code " & sCode & Chr(13) & Chr(10) & sMsg)
    End Sub

End Class