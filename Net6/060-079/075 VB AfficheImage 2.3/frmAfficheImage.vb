' AfficheImage2
' Portage de AfficheImage dans Visual Studio .Net 2003
' 2003-05-11    PV
' 2003-07-14    PV  Pb plantage en icône réglé; Commande Copie Chemin
' 2004-11-24    PV  Navigation F5/F6/F7
' 2005-11-12    PV  Visual STudio 2005; Efface dans la corbeille; MenuStrips
' 2012-02-25	PV  VS2010 (version 2.2, .Net Framework 4)
' 2012-12-31	PV  2.3: Suivant/Précédent navigue iRowSize^2 images
' 2021-09-19    PV  VS2022, Net6

Imports System.ComponentModel
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Reflection
Imports System.Runtime.InteropServices
Imports Microsoft.VisualBasic.Devices
Imports Microsoft.VisualBasic.FileIO

#Disable Warning IDE1006 ' Naming Styles

Public Class frmAfficheImage
    Inherits Form

#Region " Code généré par le Concepteur Windows Form "

    Public Sub New()
        MyBase.New()

        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        'Ajoutez une initialisation quelconque après l'appel InitializeComponent()

    End Sub

    'La méthode substituée Dispose du formulaire pour nettoyer la liste des composants.
    Protected Overloads Overrides Sub Dispose(disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requis par le Concepteur Windows Form
    Private ReadOnly components As IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée en utilisant le Concepteur Windows Form.
    'Ne la modifiez pas en utilisant l'éditeur de code.
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog

    Friend WithEvents msMain As MenuStrip
    Friend WithEvents msNavigation As ToolStripMenuItem
    Friend WithEvents miOuvrir As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents miPremier As ToolStripMenuItem
    Friend WithEvents miPrécédent As ToolStripMenuItem
    Friend WithEvents miSuivant As ToolStripMenuItem
    Friend WithEvents miDernier As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents miAuHasard As ToolStripMenuItem
    Friend WithEvents miRetourArrière As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents miQuitter As ToolStripMenuItem
    Friend WithEvents msEdition As ToolStripMenuItem
    Friend WithEvents msAffichage As ToolStripMenuItem
    Friend WithEvents msHelp As ToolStripMenuItem
    Friend WithEvents ms1Image As ToolStripMenuItem
    Friend WithEvents ms4Images As ToolStripMenuItem
    Friend WithEvents ms9Images As ToolStripMenuItem
    Friend WithEvents ms16Images As ToolStripMenuItem
    Friend WithEvents miÀProposDe As ToolStripMenuItem
    Friend WithEvents miCopierCheminImage As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents tsMain As ToolStrip
    Friend WithEvents tsbOuvrir As ToolStripButton
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents tsbPremier As ToolStripButton
    Friend WithEvents tsbPrécédent As ToolStripButton
    Friend WithEvents tsbSuivant As ToolStripButton
    Friend WithEvents tsbDernier As ToolStripButton
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents tsbRetour As ToolStripButton
    Friend WithEvents tsbAuHasard As ToolStripButton
    Friend WithEvents ToolStripSeparator8 As ToolStripSeparator
    Friend WithEvents tsbSupprimer As ToolStripButton
    Friend WithEvents miSupprimer As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents lblPos As ToolStripLabel
    Friend WithEvents cboFichiers As ToolStripComboBox
    Friend WithEvents ToolStripSeparator9 As ToolStripSeparator
    Friend WithEvents miToolbar As ToolStripMenuItem
    Friend WithEvents tscMain As ToolStripContainer
    Friend WithEvents miStatusbar As ToolStripMenuItem
    Friend WithEvents sbStatus As StatusStrip
    Friend WithEvents Fichier As ToolStripStatusLabel
    Friend WithEvents Resolution As ToolStripStatusLabel
    Friend WithEvents Taille As ToolStripStatusLabel
    Friend WithEvents Echelle As ToolStripStatusLabel
    Friend WithEvents miAperçuWindows As ToolStripMenuItem

    <DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources = New ComponentResourceManager(GetType(frmAfficheImage))
        Me.FolderBrowserDialog1 = New FolderBrowserDialog()
        Me.msMain = New MenuStrip()
        Me.msNavigation = New ToolStripMenuItem()
        Me.miOuvrir = New ToolStripMenuItem()
        Me.ToolStripSeparator1 = New ToolStripSeparator()
        Me.miPremier = New ToolStripMenuItem()
        Me.miPrécédent = New ToolStripMenuItem()
        Me.miSuivant = New ToolStripMenuItem()
        Me.miDernier = New ToolStripMenuItem()
        Me.ToolStripSeparator2 = New ToolStripSeparator()
        Me.miAuHasard = New ToolStripMenuItem()
        Me.miRetourArrière = New ToolStripMenuItem()
        Me.ToolStripSeparator4 = New ToolStripSeparator()
        Me.miQuitter = New ToolStripMenuItem()
        Me.msEdition = New ToolStripMenuItem()
        Me.miSupprimer = New ToolStripMenuItem()
        Me.ToolStripSeparator5 = New ToolStripSeparator()
        Me.miCopierCheminImage = New ToolStripMenuItem()
        Me.miAperçuWindows = New ToolStripMenuItem()
        Me.msAffichage = New ToolStripMenuItem()
        Me.ms1Image = New ToolStripMenuItem()
        Me.ms4Images = New ToolStripMenuItem()
        Me.ms9Images = New ToolStripMenuItem()
        Me.ms16Images = New ToolStripMenuItem()
        Me.ToolStripSeparator9 = New ToolStripSeparator()
        Me.miToolbar = New ToolStripMenuItem()
        Me.miStatusbar = New ToolStripMenuItem()
        Me.msHelp = New ToolStripMenuItem()
        Me.miÀProposDe = New ToolStripMenuItem()
        Me.tsMain = New ToolStrip()
        Me.tsbOuvrir = New ToolStripButton()
        Me.ToolStripSeparator6 = New ToolStripSeparator()
        Me.tsbPremier = New ToolStripButton()
        Me.tsbPrécédent = New ToolStripButton()
        Me.tsbSuivant = New ToolStripButton()
        Me.tsbDernier = New ToolStripButton()
        Me.ToolStripSeparator7 = New ToolStripSeparator()
        Me.tsbRetour = New ToolStripButton()
        Me.tsbAuHasard = New ToolStripButton()
        Me.ToolStripSeparator8 = New ToolStripSeparator()
        Me.tsbSupprimer = New ToolStripButton()
        Me.ToolStripSeparator3 = New ToolStripSeparator()
        Me.lblPos = New ToolStripLabel()
        Me.cboFichiers = New ToolStripComboBox()
        Me.tscMain = New ToolStripContainer()
        Me.sbStatus = New StatusStrip()
        Me.Fichier = New ToolStripStatusLabel()
        Me.Resolution = New ToolStripStatusLabel()
        Me.Taille = New ToolStripStatusLabel()
        Me.Echelle = New ToolStripStatusLabel()
        Me.msMain.SuspendLayout()
        Me.tsMain.SuspendLayout()
        Me.tscMain.ContentPanel.SuspendLayout()
        Me.tscMain.TopToolStripPanel.SuspendLayout()
        Me.tscMain.SuspendLayout()
        Me.sbStatus.SuspendLayout()
        Me.SuspendLayout()
        '
        'FolderBrowserDialog1
        '
        Me.FolderBrowserDialog1.Description = "Sélectionnez le dossier contenant les images à afficher"
        Me.FolderBrowserDialog1.ShowNewFolderButton = False
        '
        'msMain
        '
        Me.msMain.Dock = DockStyle.None
        Me.msMain.ImageScalingSize = New Size(32, 32)
        Me.msMain.Items.AddRange(New ToolStripItem() {Me.msNavigation, Me.msEdition, Me.msAffichage, Me.msHelp})
        Me.msMain.Location = New Point(0, 0)
        Me.msMain.Name = "msMain"
        Me.msMain.Size = New Size(656, 33)
        Me.msMain.TabIndex = 11
        Me.msMain.Text = "MenuStrip1"
        '
        'msNavigation
        '
        Me.msNavigation.DropDownItems.AddRange(New ToolStripItem() {Me.miOuvrir, Me.ToolStripSeparator1, Me.miPremier, Me.miPrécédent, Me.miSuivant, Me.miDernier, Me.ToolStripSeparator2, Me.miAuHasard, Me.miRetourArrière, Me.ToolStripSeparator4, Me.miQuitter})
        Me.msNavigation.Name = "msNavigation"
        Me.msNavigation.Size = New Size(114, 29)
        Me.msNavigation.Text = "&Navigation"
        '
        'miOuvrir
        '
        Me.miOuvrir.Image = CType(resources.GetObject("miOuvrir.Image"), Image)
        Me.miOuvrir.Name = "miOuvrir"
        Me.miOuvrir.ShortcutKeyDisplayString = "?"
        Me.miOuvrir.Size = New Size(330, 42)
        Me.miOuvrir.Text = "&Ouvrir"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New Size(327, 6)
        '
        'miPremier
        '
        Me.miPremier.Image = CType(resources.GetObject("miPremier.Image"), Image)
        Me.miPremier.Name = "miPremier"
        Me.miPremier.ShortcutKeyDisplayString = "Debut"
        Me.miPremier.Size = New Size(330, 42)
        Me.miPremier.Text = "Premier"
        '
        'miPrécédent
        '
        Me.miPrécédent.Image = CType(resources.GetObject("miPrécédent.Image"), Image)
        Me.miPrécédent.Name = "miPrécédent"
        Me.miPrécédent.ShortcutKeyDisplayString = "-"
        Me.miPrécédent.Size = New Size(330, 42)
        Me.miPrécédent.Text = "Précédent"
        '
        'miSuivant
        '
        Me.miSuivant.Image = CType(resources.GetObject("miSuivant.Image"), Image)
        Me.miSuivant.Name = "miSuivant"
        Me.miSuivant.ShortcutKeyDisplayString = "+"
        Me.miSuivant.Size = New Size(330, 42)
        Me.miSuivant.Text = "Suivant"
        '
        'miDernier
        '
        Me.miDernier.Image = CType(resources.GetObject("miDernier.Image"), Image)
        Me.miDernier.Name = "miDernier"
        Me.miDernier.ShortcutKeyDisplayString = "Fin"
        Me.miDernier.Size = New Size(330, 42)
        Me.miDernier.Text = "Dernier"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New Size(327, 6)
        '
        'miAuHasard
        '
        Me.miAuHasard.Image = CType(resources.GetObject("miAuHasard.Image"), Image)
        Me.miAuHasard.Name = "miAuHasard"
        Me.miAuHasard.ShortcutKeyDisplayString = "*"
        Me.miAuHasard.Size = New Size(330, 42)
        Me.miAuHasard.Text = "Au hasard"
        '
        'miRetourArrière
        '
        Me.miRetourArrière.Image = CType(resources.GetObject("miRetourArrière.Image"), Image)
        Me.miRetourArrière.Name = "miRetourArrière"
        Me.miRetourArrière.ShortcutKeyDisplayString = "Backaspace"
        Me.miRetourArrière.Size = New Size(330, 42)
        Me.miRetourArrière.Text = "Retour arrière"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New Size(327, 6)
        '
        'miQuitter
        '
        Me.miQuitter.Name = "miQuitter"
        Me.miQuitter.ShortcutKeyDisplayString = "Alt+F4"
        Me.miQuitter.Size = New Size(330, 42)
        Me.miQuitter.Text = "&Quitter"
        '
        'msEdition
        '
        Me.msEdition.DropDownItems.AddRange(New ToolStripItem() {Me.miSupprimer, Me.ToolStripSeparator5, Me.miCopierCheminImage, Me.miAperçuWindows})
        Me.msEdition.Name = "msEdition"
        Me.msEdition.Size = New Size(83, 29)
        Me.msEdition.Text = "&Edition"
        '
        'miSupprimer
        '
        Me.miSupprimer.Image = CType(resources.GetObject("miSupprimer.Image"), Image)
        Me.miSupprimer.Name = "miSupprimer"
        Me.miSupprimer.ShortcutKeyDisplayString = "Suppr"
        Me.miSupprimer.Size = New Size(333, 34)
        Me.miSupprimer.Text = "&Supprimer"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New Size(330, 6)
        '
        'miCopierCheminImage
        '
        Me.miCopierCheminImage.Name = "miCopierCheminImage"
        Me.miCopierCheminImage.Size = New Size(333, 34)
        Me.miCopierCheminImage.Text = "&Copier le chemin de l'image"
        '
        'miAperçuWindows
        '
        Me.miAperçuWindows.Name = "miAperçuWindows"
        Me.miAperçuWindows.Size = New Size(333, 34)
        Me.miAperçuWindows.Text = "&Aperçu Windows"
        '
        'msAffichage
        '
        Me.msAffichage.DropDownItems.AddRange(New ToolStripItem() {Me.ms1Image, Me.ms4Images, Me.ms9Images, Me.ms16Images, Me.ToolStripSeparator9, Me.miToolbar, Me.miStatusbar})
        Me.msAffichage.Name = "msAffichage"
        Me.msAffichage.Size = New Size(103, 29)
        Me.msAffichage.Text = "&Affichage"
        '
        'ms1Image
        '
        Me.ms1Image.Name = "ms1Image"
        Me.ms1Image.Size = New Size(196, 34)
        Me.ms1Image.Text = "&1 image"
        '
        'ms4Images
        '
        Me.ms4Images.Name = "ms4Images"
        Me.ms4Images.Size = New Size(196, 34)
        Me.ms4Images.Text = "&4 images"
        '
        'ms9Images
        '
        Me.ms9Images.Name = "ms9Images"
        Me.ms9Images.Size = New Size(196, 34)
        Me.ms9Images.Text = "&9 images"
        '
        'ms16Images
        '
        Me.ms16Images.Name = "ms16Images"
        Me.ms16Images.Size = New Size(196, 34)
        Me.ms16Images.Text = "1&6 images"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New Size(193, 6)
        '
        'miToolbar
        '
        Me.miToolbar.Checked = True
        Me.miToolbar.CheckState = CheckState.Checked
        Me.miToolbar.Name = "miToolbar"
        Me.miToolbar.Size = New Size(196, 34)
        Me.miToolbar.Text = "&Toolbar"
        '
        'miStatusbar
        '
        Me.miStatusbar.Checked = True
        Me.miStatusbar.CheckOnClick = True
        Me.miStatusbar.CheckState = CheckState.Checked
        Me.miStatusbar.Name = "miStatusbar"
        Me.miStatusbar.Size = New Size(196, 34)
        Me.miStatusbar.Text = "Status bar"
        '
        'msHelp
        '
        Me.msHelp.DropDownItems.AddRange(New ToolStripItem() {Me.miÀProposDe})
        Me.msHelp.Name = "msHelp"
        Me.msHelp.Size = New Size(36, 29)
        Me.msHelp.Text = "&?"
        '
        'miÀProposDe
        '
        Me.miÀProposDe.Image = CType(resources.GetObject("miÀProposDe.Image"), Image)
        Me.miÀProposDe.Name = "miÀProposDe"
        Me.miÀProposDe.Size = New Size(231, 34)
        Me.miÀProposDe.Text = "&À propos de ..."
        '
        'tsMain
        '
        Me.tsMain.AllowItemReorder = True
        Me.tsMain.Dock = DockStyle.None
        Me.tsMain.ImageScalingSize = New Size(32, 32)
        Me.tsMain.Items.AddRange(New ToolStripItem() {Me.tsbOuvrir, Me.ToolStripSeparator6, Me.tsbPremier, Me.tsbPrécédent, Me.tsbSuivant, Me.tsbDernier, Me.ToolStripSeparator7, Me.tsbRetour, Me.tsbAuHasard, Me.ToolStripSeparator8, Me.tsbSupprimer, Me.ToolStripSeparator3, Me.lblPos, Me.cboFichiers})
        Me.tsMain.Location = New Point(4, 33)
        Me.tsMain.Name = "tsMain"
        Me.tsMain.Size = New Size(652, 41)
        Me.tsMain.TabIndex = 12
        Me.tsMain.Text = "Navigation"
        '
        'tsbOuvrir
        '
        Me.tsbOuvrir.DisplayStyle = ToolStripItemDisplayStyle.Image
        Me.tsbOuvrir.Image = CType(resources.GetObject("tsbOuvrir.Image"), Image)
        Me.tsbOuvrir.ImageTransparentColor = Color.Magenta
        Me.tsbOuvrir.Name = "tsbOuvrir"
        Me.tsbOuvrir.Size = New Size(36, 36)
        Me.tsbOuvrir.Text = "Ouvrir"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New Size(6, 41)
        '
        'tsbPremier
        '
        Me.tsbPremier.DisplayStyle = ToolStripItemDisplayStyle.Image
        Me.tsbPremier.Image = CType(resources.GetObject("tsbPremier.Image"), Image)
        Me.tsbPremier.ImageTransparentColor = Color.Magenta
        Me.tsbPremier.Name = "tsbPremier"
        Me.tsbPremier.Size = New Size(36, 36)
        Me.tsbPremier.Text = "Premier"
        '
        'tsbPrécédent
        '
        Me.tsbPrécédent.DisplayStyle = ToolStripItemDisplayStyle.Image
        Me.tsbPrécédent.Image = CType(resources.GetObject("tsbPrécédent.Image"), Image)
        Me.tsbPrécédent.ImageTransparentColor = Color.Magenta
        Me.tsbPrécédent.Name = "tsbPrécédent"
        Me.tsbPrécédent.Size = New Size(36, 36)
        Me.tsbPrécédent.Text = "Précédent"
        '
        'tsbSuivant
        '
        Me.tsbSuivant.DisplayStyle = ToolStripItemDisplayStyle.Image
        Me.tsbSuivant.Image = CType(resources.GetObject("tsbSuivant.Image"), Image)
        Me.tsbSuivant.ImageTransparentColor = Color.Magenta
        Me.tsbSuivant.Name = "tsbSuivant"
        Me.tsbSuivant.Size = New Size(36, 36)
        Me.tsbSuivant.Text = "Suivant"
        '
        'tsbDernier
        '
        Me.tsbDernier.DisplayStyle = ToolStripItemDisplayStyle.Image
        Me.tsbDernier.Image = CType(resources.GetObject("tsbDernier.Image"), Image)
        Me.tsbDernier.ImageTransparentColor = Color.Magenta
        Me.tsbDernier.Name = "tsbDernier"
        Me.tsbDernier.Size = New Size(36, 36)
        Me.tsbDernier.Text = "Dernier"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New Size(6, 41)
        '
        'tsbRetour
        '
        Me.tsbRetour.DisplayStyle = ToolStripItemDisplayStyle.Image
        Me.tsbRetour.Image = CType(resources.GetObject("tsbRetour.Image"), Image)
        Me.tsbRetour.ImageTransparentColor = Color.Magenta
        Me.tsbRetour.Name = "tsbRetour"
        Me.tsbRetour.Size = New Size(36, 36)
        Me.tsbRetour.Text = "Retour"
        '
        'tsbAuHasard
        '
        Me.tsbAuHasard.DisplayStyle = ToolStripItemDisplayStyle.Image
        Me.tsbAuHasard.Image = CType(resources.GetObject("tsbAuHasard.Image"), Image)
        Me.tsbAuHasard.ImageTransparentColor = Color.Magenta
        Me.tsbAuHasard.Name = "tsbAuHasard"
        Me.tsbAuHasard.Size = New Size(36, 36)
        Me.tsbAuHasard.Text = "Au hasard"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New Size(6, 41)
        '
        'tsbSupprimer
        '
        Me.tsbSupprimer.DisplayStyle = ToolStripItemDisplayStyle.Image
        Me.tsbSupprimer.Image = CType(resources.GetObject("tsbSupprimer.Image"), Image)
        Me.tsbSupprimer.ImageTransparentColor = Color.Magenta
        Me.tsbSupprimer.Name = "tsbSupprimer"
        Me.tsbSupprimer.Size = New Size(36, 36)
        Me.tsbSupprimer.Text = "Supprimer"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New Size(6, 41)
        '
        'lblPos
        '
        Me.lblPos.Name = "lblPos"
        Me.lblPos.Size = New Size(40, 36)
        Me.lblPos.Text = "Pos"
        '
        'cboFichiers
        '
        Me.cboFichiers.DropDownStyle = ComboBoxStyle.DropDownList
        Me.cboFichiers.Name = "cboFichiers"
        Me.cboFichiers.Size = New Size(300, 33)
        '
        'tscMain
        '
        '
        'tscMain.ContentPanel
        '
        Me.tscMain.ContentPanel.AutoScroll = True
        Me.tscMain.ContentPanel.Controls.Add(Me.sbStatus)
        Me.tscMain.ContentPanel.Size = New Size(656, 439)
        Me.tscMain.Dock = DockStyle.Fill
        Me.tscMain.LeftToolStripPanelVisible = False
        Me.tscMain.Location = New Point(0, 0)
        Me.tscMain.Name = "tscMain"
        Me.tscMain.RightToolStripPanelVisible = False
        Me.tscMain.Size = New Size(656, 513)
        Me.tscMain.TabIndex = 13
        Me.tscMain.Text = "tscMain"
        '
        'tscMain.TopToolStripPanel
        '
        Me.tscMain.TopToolStripPanel.Controls.Add(Me.tsMain)
        Me.tscMain.TopToolStripPanel.Controls.Add(Me.msMain)
        '
        'sbStatus
        '
        Me.sbStatus.ImageScalingSize = New Size(32, 32)
        Me.sbStatus.Items.AddRange(New ToolStripItem() {Me.Fichier, Me.Resolution, Me.Taille, Me.Echelle})
        Me.sbStatus.Location = New Point(0, 408)
        Me.sbStatus.Name = "sbStatus"
        Me.sbStatus.Size = New Size(656, 31)
        Me.sbStatus.TabIndex = 0
        Me.sbStatus.Text = "StatusStrip1"
        '
        'Fichier
        '
        Me.Fichier.Name = "Fichier"
        Me.Fichier.Size = New Size(341, 24)
        Me.Fichier.Spring = True
        '
        'Resolution
        '
        Me.Resolution.AutoSize = False
        Me.Resolution.Name = "Resolution"
        Me.Resolution.Size = New Size(100, 24)
        '
        'Taille
        '
        Me.Taille.AutoSize = False
        Me.Taille.Name = "Taille"
        Me.Taille.Size = New Size(100, 24)
        '
        'Echelle
        '
        Me.Echelle.AutoSize = False
        Me.Echelle.Name = "Echelle"
        Me.Echelle.Size = New Size(100, 24)
        '
        'frmAfficheImage
        '
        Me.AutoScaleBaseSize = New Size(9, 24)
        Me.ClientSize = New Size(656, 513)
        Me.Controls.Add(Me.tscMain)
        Me.Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.msMain
        Me.Name = "frmAfficheImage"
        Me.Text = "AfficheImage"
        Me.msMain.ResumeLayout(False)
        Me.msMain.PerformLayout()
        Me.tsMain.ResumeLayout(False)
        Me.tsMain.PerformLayout()
        Me.tscMain.ContentPanel.ResumeLayout(False)
        Me.tscMain.ContentPanel.PerformLayout()
        Me.tscMain.TopToolStripPanel.ResumeLayout(False)
        Me.tscMain.TopToolStripPanel.PerformLayout()
        Me.tscMain.ResumeLayout(False)
        Me.tscMain.PerformLayout()
        Me.sbStatus.ResumeLayout(False)
        Me.sbStatus.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    ' Accès au FileSystem
    Dim sRep As String

    ' Navigation
    Dim chLastKey As Char

    Dim iPos As Integer
    Dim iPosPrev As Integer     ' Previous Position

    ' Interface d'affichage
    Dim tImage() As PictureBox

    Dim tImage2() As Image
    Dim iRowSize As Integer = 0         ' 0 indique que les tableaux ne sont pas initialisés
    ReadOnly iMargin As Integer = 8          ' Espace entre images pour l'affichage multiple

    ' Historique
    Dim PileImages As Stack

    Private Sub frmAfficheImage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Fichier.Text = "AfficheImage " & GetVersion()
        Randomize()

        ' Update menu with saved settings
        miToolbar.Checked = My.Settings.ToolbarVisible
        miStatusbar.Checked = My.Settings.StatusbarVisible

        ' Locate Toolbar in bottom container
        'Me.tscMain.TopToolStripPanel.Controls.Remove(Me.tsMain)
        'Me.tscMain.BottomToolStripPanel.Controls.Add(Me.tsMain)

        UpdateToolbar()

        Visible = True
        Ouvrir()
    End Sub

    Sub UpdateToolbar()
        tsMain.Visible = miToolbar.Checked
        sbStatus.Visible = miStatusbar.Checked
        DéfinitModeAffichage(iRowSize)
        DoAffichage()
    End Sub

    Private Shared Function VB6GetExeName() As String
        Return Path.GetFileName(Assembly.GetExecutingAssembly().Location)
    End Function

    Private Sub Ouvrir()
        FolderBrowserDialog1.SelectedPath = GetSetting(VB6GetExeName(), "Config", "Path", "C:\")
        Dim result As DialogResult = FolderBrowserDialog1.ShowDialog()
        If (result <> DialogResult.OK) Then Exit Sub
        sRep = FolderBrowserDialog1.SelectedPath
        SaveSetting(VB6GetExeName(), "Config", "Path", sRep)
        If Microsoft.VisualBasic.Right(sRep, 1) <> "\" Then sRep &= "\"

        cboFichiers.Items.Clear()
        PileImages = New Stack
        Analyse1Rep("")
        Fichier.Text = "Chargement terminé."
        iPos = 0
        iPosPrev = 0
        AfficheImage()
    End Sub

    Private Sub Analyse1Rep(ByRef sRel As String)
        Dim sFic As String

        ' D'abord les fichiers du répertoire
        ' L'accès avec l'objet FileSystem est beaucoup trop lent...
        sFic = Dir(sRep & sRel & "*", FileAttribute.Normal Or FileAttribute.ReadOnly Or FileAttribute.Archive)
        While sFic <> ""
            sFic = LCase(sFic)
            If Microsoft.VisualBasic.Right(sFic, 4) = ".gif" Or Microsoft.VisualBasic.Right(sFic, 4) = ".bmp" Or Microsoft.VisualBasic.Right(sFic, 5) = ".html" Or Microsoft.VisualBasic.Right(sFic, 4) = ".jpg" Or Microsoft.VisualBasic.Right(sFic, 5) = ".jpeg" Then
                ' Par convention on ignore les fichiers dont le nom commence par !
                If Microsoft.VisualBasic.Left(sFic, 1) <> "!" Then
                    If cboFichiers.Items.Count < 32766 Then
                        cboFichiers.Items.Add(sRel & sFic)
                        If cboFichiers.Items.Count Mod 100 = 0 Then
                            Fichier.Text = "Analyse des images du dossier " & sRep & sRel & ": " & cboFichiers.Items.Count & " images"
                        End If
                    End If
                End If
            End If
            sFic = Dir()
        End While

        ' Puis on analyse les sous-répertoires
        Dim sSubDir As String
        Dim MyComputer = New Computer
        For Each sSubDir In MyComputer.FileSystem.GetDirectories(sRep & sRel)
            sFic = MyComputer.FileSystem.GetName(sSubDir)
            Analyse1Rep(sRel & sFic & "\")
        Next
    End Sub

    Sub AfficheImage()
        ' Cas où il n'y a rien de chargé
        If cboFichiers.Items.Count = 0 Then Exit Sub

        cboFichiers.SelectedIndex = iPos

        For i As Integer = 0 To iRowSize * iRowSize - 1
            Try
                tImage2(i) = Image.FromFile(sRep & cboFichiers.Items(iPos + i))
            Catch
                tImage2(i) = Nothing
            End Try
        Next

        DoAffichage()

        Me.Text = cboFichiers.Text & " - AfficheImage"
        lblPos.Text = iPos + 1 & "/" & cboFichiers.Items.Count

        PileImages.Push(iPos)
    End Sub

    Sub DoAffichage()
        If iPos > 0 Then
            Fichier.Text = sRep & cboFichiers.SelectedItem
            If tImage2(0) Is Nothing Then
                Resolution.Text = "#ERR!"
            Else
                Resolution.Text = CStr(tImage2(0).Width & " x " & tImage2(0).Height)
            End If
            Taille.Text = FormatNumber(FileLen(sRep & cboFichiers.SelectedItem) / 1024, 1) & " Ko"
        End If
        Dim i As Integer
        For i = 0 To iRowSize * iRowSize - 1
            DoAffichageUneImage(i)
        Next
    End Sub

    Sub DoAffichageUneImage(iOff As Integer)
        If tImage2(iOff) Is Nothing Then
            tImage(iOff).Image = Nothing
            tImage(iOff).BorderStyle = BorderStyle.FixedSingle
        Else
            tImage(iOff).BorderStyle = BorderStyle.None

            Dim r1, r2 As Single
            r1 = tImage(iOff).Width / tImage2(iOff).Width
            r2 = tImage(iOff).Height / tImage2(iOff).Height
            If r2 < r1 Then r1 = r2
            If r1 < 0 Then Exit Sub
            If iOff = 0 Then Echelle.Text = FormatPercent(r1, 0)

            Dim imgOutput As Bitmap
            imgOutput = New Bitmap(tImage(iOff).Width, tImage(iOff).Height, PixelFormat.Format32bppRgb)
            Dim h As Graphics = Graphics.FromImage(imgOutput)
            h.Clear(Color.FromKnownColor(KnownColor.Control))
            h.DrawImage(tImage2(iOff), 0, 0, tImage2(iOff).Width * r1, tImage2(iOff).Height * r1)
            tImage(iOff).Image = imgOutput
        End If
    End Sub

    Private Sub frmAfficheImage_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        ' On évite les problèmes en icône ou en fenêtre très réduite
        If tscMain.ContentPanel.Width <= 0 Or tscMain.ContentPanel.Height <= 0 Then Exit Sub

        DéfinitModeAffichage(iRowSize)
        DoAffichage()
    End Sub

    Dim cPrefix As Integer
    ReadOnly tMem(255) As Integer

    Private Sub frmAfficheImage_KeyPress(sender As Object, e As KeyPressEventArgs) Handles MyBase.KeyPress
        Dim c As Char = e.KeyChar
        Dim n As Integer = Asc(e.KeyChar)
        Select Case cPrefix
            Case Keys.F5    ' Mémorise une position
                If n < 0 Or n > 255 Then
                    Beep()
                Else
                    tMem(n) = iPos
                End If
                cPrefix = 0
                e.Handled = True
                Exit Sub

            Case Keys.F6    ' Rappelle une position
                If n < 0 Or n > 255 Then
                    Beep()
                Else
                    iPosPrev = iPos
                    iPos = tMem(n)
                    AfficheImage()
                End If
                cPrefix = 0
                e.Handled = True
                Exit Sub
        End Select

        If c = " "c Then c = chLastKey
        Select Case c
            Case "-"c : NaviguePrécédent()
            Case "+"c, Chr(13) : NavigueSuivant()
            Case "*"c : NavigueAuHasard()
            Case "?"c : Ouvrir()
        End Select
    End Sub

    Private Sub frmAfficheImage_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Delete : Supprimer()
            Case Keys.Back : RetourArrière()
            Case Keys.Home : NaviguePremier()
            Case Keys.End : NavigueDernier()
            Case Keys.F5, Keys.F6 : cPrefix = e.KeyCode
            Case Keys.F7    ' Echange la position actuelle et précédente
                Dim iPosTemp As Integer
                iPosTemp = iPos
                iPos = iPosPrev
                iPosPrev = iPosTemp
                AfficheImage()
        End Select
    End Sub

    Private Sub NavigueAuHasard()
        chLastKey = "*"c
        If cboFichiers.Items.Count = 0 Then Exit Sub
        iPosPrev = iPos
        iPos = Int(cboFichiers.Items.Count * Rnd())
        AfficheImage()
    End Sub

    Private Sub NaviguePremier()
        iPosPrev = iPos
        iPos = 0
        AfficheImage()
    End Sub

    Private Sub NaviguePrécédent()
        chLastKey = "-"c
        If iPos > iRowSize * iRowSize - 1 Then
            iPosPrev = iPos
            iPos -= iRowSize * iRowSize
            AfficheImage()
        End If
    End Sub

    Private Sub NavigueSuivant()
        chLastKey = "+"c
        If iPos < cboFichiers.Items.Count - iRowSize * iRowSize Then
            iPosPrev = iPos
            iPos += iRowSize * iRowSize
            AfficheImage()
        End If
    End Sub

    Private Sub NavigueDernier()
        iPosPrev = iPos
        iPos = cboFichiers.Items.Count - 1
        If iPos < 0 Then iPos = 0
        AfficheImage()
    End Sub

    Sub Supprimer()
        If cboFichiers.Items.Count = 0 Then Exit Sub

        Cursor.Current = Cursors.WaitCursor
        Try
            tImage(0).Image = Nothing
            tImage2(0) = Nothing
            GC.Collect()
            Application.DoEvents()
            GC.WaitForPendingFinalizers()

            'Kill(sRep & cboFichiers.SelectedItem)
            ' On envoie dans la corbeille
            Dim MyComputer = New Computer
            MyComputer.FileSystem.DeleteFile(sRep & cboFichiers.SelectedItem, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin)

            Cursor.Current = Cursors.Default
            cboFichiers.Items.RemoveAt(iPos)
            If iPos >= cboFichiers.Items.Count Then iPos = cboFichiers.Items.Count - 1
            PileImages.Pop()
            AfficheImage()
        Catch ex As Exception
            Cursor.Current = Cursors.Default
            MsgBox("Echec lors la suppression du fichier:" & vbCrLf & ex.Source & ": " & ex.Message)
        End Try

    End Sub

    Sub RetourArrière()
        If PileImages Is Nothing Then Exit Sub
        If PileImages.Count <= 1 Then Exit Sub
        PileImages.Pop()
        iPosPrev = iPos
        iPos = PileImages.Pop()
        AfficheImage()
    End Sub

    '=============================================================================
    ' Menus

    Private Sub miOuvrir_Click(sender As Object, e As EventArgs) Handles miOuvrir.Click
        Ouvrir()
    End Sub

    Private Sub miPremier_Click(sender As Object, e As EventArgs) Handles miPremier.Click
        NaviguePremier()
    End Sub

    Private Sub miPrécédent_Click(sender As Object, e As EventArgs) Handles miPrécédent.Click
        NaviguePrécédent()
    End Sub

    Private Sub miSuivant_Click(sender As Object, e As EventArgs) Handles miSuivant.Click
        NavigueSuivant()
    End Sub

    Private Sub miDernier_Click(sender As Object, e As EventArgs) Handles miDernier.Click
        NavigueDernier()
    End Sub

    Private Sub miAuHasard_Click(sender As Object, e As EventArgs) Handles miAuHasard.Click
        NavigueAuHasard()
    End Sub

    Private Sub miRetourArrière_Click(sender As Object, e As EventArgs) Handles miRetourArrière.Click
        RetourArrière()
    End Sub

    Private Sub miQuitter_Click(sender As Object, e As EventArgs) Handles miQuitter.Click
        Close()
    End Sub

    Private Sub miSupprimer_Click(sender As Object, e As EventArgs) Handles miSupprimer.Click
        Supprimer()
    End Sub

    Private Sub miCopierCheminImage_Click(sender As Object, e As EventArgs) Handles miCopierCheminImage.Click
        DoCopieCheminImage()
    End Sub

    Private Sub miAperçuWindows_Click(sender As Object, e As EventArgs) Handles miAperçuWindows.Click
        DoAperçuWindows()
    End Sub

    Private Sub ms1Image_Click(sender As Object, e As EventArgs) Handles ms1Image.Click
        DéfinitModeAffichage(1)
        AfficheImage()
    End Sub

    Private Sub ms4Images_Click(sender As Object, e As EventArgs) Handles ms4Images.Click
        DéfinitModeAffichage(2)
        AfficheImage()
    End Sub

    Private Sub ms9Images_Click(sender As Object, e As EventArgs) Handles ms9Images.Click
        DéfinitModeAffichage(3)
        AfficheImage()
    End Sub

    Private Sub ms16Images_Click(sender As Object, e As EventArgs) Handles ms16Images.Click
        DéfinitModeAffichage(4)
        AfficheImage()
    End Sub

    Private Sub miToolbar_Click(sender As Object, e As EventArgs) Handles miToolbar.Click
        miToolbar.Checked = Not miToolbar.Checked
        My.Settings.ToolbarVisible = miToolbar.Checked
        UpdateToolbar()
    End Sub

    Private Sub miStatusbar_Click(sender As Object, e As EventArgs) Handles miStatusbar.Click
        ' Auto toggle: miStatusbar.CheckOnClick=True
        My.Settings.StatusbarVisible = miStatusbar.Checked
        UpdateToolbar()
    End Sub

    Private Sub miÀProposDe_Click(sender As Object, e As EventArgs) Handles miÀProposDe.Click
        FrmAPropos.DefInstance.ShowDialog()
    End Sub

    '=============================================================================
    ' ToolBar

    Private Sub tsbOuvrir_Click(sender As Object, e As EventArgs) Handles tsbOuvrir.Click
        Ouvrir()
    End Sub

    Private Sub tsbPremier_Click(sender As Object, e As EventArgs) Handles tsbPremier.Click
        NaviguePremier()
    End Sub

    Private Sub Précédent_Click(sender As Object, e As EventArgs) Handles tsbPrécédent.Click
        NaviguePrécédent()
    End Sub

    Private Sub tsbSuivant_Click(sender As Object, e As EventArgs) Handles tsbSuivant.Click
        NavigueSuivant()
    End Sub

    Private Sub tsbDernier_Click(sender As Object, e As EventArgs) Handles tsbDernier.Click
        NavigueDernier()
    End Sub

    Private Sub tsbRetour_Click(sender As Object, e As EventArgs) Handles tsbRetour.Click
        RetourArrière()
    End Sub

    Private Sub tsbAuHasard_Click(sender As Object, e As EventArgs) Handles tsbAuHasard.Click
        NavigueAuHasard()
    End Sub

    Private Sub tsbSupprimer_Click(sender As Object, e As EventArgs) Handles tsbSupprimer.Click
        Supprimer()
    End Sub

    '=============================================================================

    Sub DéfinitModeAffichage(iNewRowSize As Integer)
        Dim i As Integer

        If iNewRowSize = 0 Then iNewRowSize = 1

        If iRowSize <> iNewRowSize Then
            If tImage IsNot Nothing Then
                For i = iRowSize * iRowSize To UBound(tImage)
                    For j As Integer = 0 To Me.Controls.Count
                        If Me.Controls(i) Is tImage(i) Then
                            Me.Controls.RemoveAt(i)
                            Exit For
                        End If
                    Next
                    tImage(i) = Nothing
                Next
            End If

            iRowSize = iNewRowSize
            ReDim Preserve tImage(iRowSize * iRowSize - 1)
            ReDim Preserve tImage2(iRowSize * iRowSize - 1)
        End If

        For i = 0 To UBound(tImage)
            If tImage(i) Is Nothing Then
                tImage(i) = New PictureBox
                With tImage(i)
                    .BorderStyle = BorderStyle.FixedSingle
                    .Name = "Image" & i + 1
                    .TabStop = False
                    .Visible = True
                End With
                'Me.Controls.Add(tImage(i))
                tscMain.ContentPanel.Controls.Add(tImage(i))
            End If
        Next
        Dim iImageWidth As Integer = ((tscMain.ContentPanel.Width - 6) - iMargin * (iRowSize - 1)) / iRowSize
        Dim iImageHeight As Integer = ((tscMain.ContentPanel.Height - IIf(sbStatus.Visible, sbStatus.Height, 0) - 6) - iMargin * (iRowSize - 1)) / iRowSize

        If iImageWidth <= 5 Then iImageWidth = 5
        If iImageHeight <= 5 Then iImageHeight = 5

        i = 0
        For l As Integer = 0 To iRowSize - 1
            For c As Integer = 0 To iRowSize - 1
                With tImage(i)
                    .Location = New Point(3 + c * (iImageWidth + iMargin), 3 + l * (iImageHeight + iMargin))
                    .Size = New Size(iImageWidth, iImageHeight)
                End With
                i += 1
            Next
        Next
    End Sub

    Sub DoCopieCheminImage()
        If cboFichiers.Items.Count = 0 Then Exit Sub
        Clipboard.SetDataObject(sRep & cboFichiers.Items(iPos))
    End Sub

    Sub DoAperçuWindows()
        If cboFichiers.Items.Count = 0 Then Exit Sub

        Dim sFile As String
        sFile = sRep & cboFichiers.Items(iPos)
        Process.Start(sFile)
    End Sub

    Private Sub cboFichiers_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboFichiers.SelectedIndexChanged
        If iPos = cboFichiers.SelectedIndex Then Exit Sub
        iPosPrev = iPos
        iPos = cboFichiers.SelectedIndex
        AfficheImage()
    End Sub

    Private Sub tscMain_Paint(sender As Object, e As PaintEventArgs) Handles tscMain.Paint
        DéfinitModeAffichage(iRowSize)
        DoAffichage()

        'If tscMain.BottomToolStripPanel.Contains(tsMain) Then
        '    MsgBox("Toolbar is in bottom container")
        'Else
        '    MsgBox("Toolbar is not in bottom container")
        'End If
    End Sub

End Class