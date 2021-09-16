' 2001 PV
' 2006-10-01    PV  VS2005
' 2012-02-25	PV  VS2010

Imports System.Windows.Forms

#Disable Warning IDE1006 ' Naming Styles
#Disable Warning IDE0052 ' Remove unread private members

Public Class F2
    Inherits Form

    Public g As DonneesGlobales

    Public Sub New()
        MyBase.New()

        F2 = Me

        'This call is required by the Win Form Designer.
        InitializeComponent()

        'TODO: Add any initialization after the InitializeComponent() call
    End Sub

#Region " Windows Form Designer generated code "

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container

    Private WithEvents lblNom As Label

    Dim WithEvents F2 As Form

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.lblNom = New Label()

        '@design Me.TrayHeight = 0
        '@design Me.TrayLargeIcon = False
        '@design Me.TrayAutoArrange = True
        lblNom.Location = New Drawing.Point(44, 24)
        lblNom.Text = "Label1"
        lblNom.Size = New Drawing.Size(100, 23)
        lblNom.TabIndex = 0
        Me.Text = "F2"
        Me.AutoScaleBaseSize = New Drawing.Size(5, 13)
        Me.BackColor = CType(System.Drawing.Color.FromArgb(192, 192, 255), Drawing.Color)
        Me.ClientSize = New Drawing.Size(240, 205)

        Me.Controls.Add(lblNom)
    End Sub

#End Region

    Public Sub Init(g As DonneesGlobales)
        Me.g = g
        lblNom.Text = "nom: " & g.sNom
    End Sub

End Class