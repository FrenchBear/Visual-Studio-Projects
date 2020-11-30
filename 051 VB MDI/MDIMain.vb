' 2001 PV
' 2006-10-01    PV  VS2005
' 2012-02-25	PV  VS2010


Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Public Class Form1
    Inherits System.Windows.Forms.Form

    Public Sub New()
        MyBase.New()

        Form1 = Me

        'This call is required by the Win Form Designer.
        InitializeComponent()

        AddHandler Me.MdiChildActivate, AddressOf Me.MDIChildActivated


    End Sub

#Region " Windows Form Designer generated code "

    'Required by the Windows Form Designer
    Private ReadOnly components As System.ComponentModel.Container
    Private WithEvents cmdWindowTileV As System.Windows.Forms.MenuItem
    Private WithEvents cmdWindowTileH As System.Windows.Forms.MenuItem
    Private WithEvents cmdWindowCascade As System.Windows.Forms.MenuItem
    Private WithEvents mnuWindow As System.Windows.Forms.MenuItem
    Private WithEvents mnuFichier As System.Windows.Forms.MenuItem
    Private MainMenu1 As System.Windows.Forms.MainMenu

    Dim WithEvents Form1 As System.Windows.Forms.Form

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents cmdQuitter As System.Windows.Forms.MenuItem
    Friend WithEvents cmdNouveau1 As System.Windows.Forms.MenuItem
    Friend WithEvents cmdNouveau2 As System.Windows.Forms.MenuItem

    Private Sub InitializeComponent()
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.mnuFichier = New System.Windows.Forms.MenuItem
        Me.cmdNouveau1 = New System.Windows.Forms.MenuItem
        Me.cmdNouveau2 = New System.Windows.Forms.MenuItem
        Me.MenuItem4 = New System.Windows.Forms.MenuItem
        Me.cmdQuitter = New System.Windows.Forms.MenuItem
        Me.mnuWindow = New System.Windows.Forms.MenuItem
        Me.cmdWindowCascade = New System.Windows.Forms.MenuItem
        Me.cmdWindowTileH = New System.Windows.Forms.MenuItem
        Me.cmdWindowTileV = New System.Windows.Forms.MenuItem
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.mnuFichier, Me.mnuWindow})
        '
        'mnuFichier
        '
        Me.mnuFichier.Index = 0
        Me.mnuFichier.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.cmdNouveau1, Me.cmdNouveau2, Me.MenuItem4, Me.cmdQuitter})
        Me.mnuFichier.Text = "Fichier"
        '
        'cmdNouveau1
        '
        Me.cmdNouveau1.Index = 0
        Me.cmdNouveau1.Shortcut = System.Windows.Forms.Shortcut.CtrlN
        Me.cmdNouveau1.Text = "Nouveau document"
        '
        'cmdNouveau2
        '
        Me.cmdNouveau2.Index = 1
        Me.cmdNouveau2.Text = "Nouveau calendrier"
        '
        'MenuItem4
        '
        Me.MenuItem4.Index = 2
        Me.MenuItem4.Text = "-"
        '
        'cmdQuitter
        '
        Me.cmdQuitter.Index = 3
        Me.cmdQuitter.Text = "&Quitter"
        '
        'mnuWindow
        '
        Me.mnuWindow.Index = 1
        Me.mnuWindow.MdiList = True
        Me.mnuWindow.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.cmdWindowCascade, Me.cmdWindowTileH, Me.cmdWindowTileV})
        Me.mnuWindow.Text = "&Window"
        '
        'cmdWindowCascade
        '
        Me.cmdWindowCascade.Index = 0
        Me.cmdWindowCascade.Text = "&Cascade"
        '
        'cmdWindowTileH
        '
        Me.cmdWindowTileH.Index = 1
        Me.cmdWindowTileH.Text = "Tile &Horizontal"
        '
        'cmdWindowTileV
        '
        Me.cmdWindowTileV.Index = 2
        Me.cmdWindowTileV.Text = "Tile &Vertical"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(396, 273)
        Me.IsMdiContainer = True
        Me.Menu = Me.MainMenu1
        Me.Name = "Form1"
        Me.Text = "Form1"

    End Sub

#End Region

    Protected Sub cmdNouveau1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdNouveau1.Click
        Dim f As New frmDocument1 With {
            .MdiParent = Me
        }
        f.Show()
        f.SetFont("Arial")
    End Sub

    Protected Sub cmdNouveau2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdNouveau2.Click
        Dim f As New frmDocument2 With {
            .MdiParent = Me
        }
        f.Show()
    End Sub

    Protected Sub cmdQuitter_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdQuitter.Click
        Close()
    End Sub


    Protected Sub cmdWindowCascade_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdWindowCascade.Click
        Me.LayoutMdi(MdiLayout.Cascade)
    End Sub

    Protected Sub cmdWindowTileH_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdWindowTileH.Click
        Me.LayoutMdi(MdiLayout.TileHorizontal)
    End Sub


    Protected Sub cmdWindowTileV_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdWindowTileV.Click
        Me.LayoutMdi(MdiLayout.TileVertical)
    End Sub


    Protected Sub MDIChildActivated(ByVal sender As Object, ByVal e As System.EventArgs)
        If (Not (Me.ActiveMdiChild Is Nothing)) Then
            Me.Text = "MDI App - [" & Me.ActiveMdiChild.Text & "]"
        Else
            Me.Text = "MDI App"
        End If
    End Sub

End Class
