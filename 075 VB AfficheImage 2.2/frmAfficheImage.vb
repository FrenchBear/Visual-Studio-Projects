' AfficheImage2
' Portage de AfficheImage dans Visual Studio .Net 2003
' 2003-05-11    PV
' 2003-07-14    PV  Pb plantage en ic�ne r�gl�; Commande Copie Chemin
' 2004-11-24    PV  Navigation F5/F6/F7
' 2005-11-12    PV  Visual STudio 2005; Efface dans la corbeille; MenuStrips
' 2012-02-25	PV  VS2010 (version 2.2, .Net Framework 4)


Imports System.IO
Imports System.Reflection

Public Class frmAfficheImage
    Inherits System.Windows.Forms.Form

#Region " Code g�n�r� par le Concepteur Windows Form "

    Public Sub New()
        MyBase.New()

        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        'Ajoutez une initialisation quelconque apr�s l'appel InitializeComponent()

    End Sub

    'La m�thode substitu�e Dispose du formulaire pour nettoyer la liste des composants.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requis par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE�: la proc�dure suivante est requise par le Concepteur Windows Form
    'Elle peut �tre modifi�e en utilisant le Concepteur Windows Form.  
    'Ne la modifiez pas en utilisant l'�diteur de code.
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents msMain As System.Windows.Forms.MenuStrip
    Friend WithEvents msNavigation As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miOuvrir As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miPremier As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miPr�c�dent As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miSuivant As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miDernier As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miAuHasard As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miRetourArri�re As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miQuitter As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents msEdition As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents msAffichage As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents msHelp As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ms1Image As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ms4Images As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ms9Images As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ms16Images As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mi�ProposDe As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miCopierCheminImage As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsMain As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbOuvrir As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbPremier As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbPr�c�dent As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSuivant As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbDernier As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbRetour As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbAuHasard As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator8 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbSupprimer As System.Windows.Forms.ToolStripButton
    Friend WithEvents miSupprimer As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblPos As System.Windows.Forms.ToolStripLabel
    Friend WithEvents cboFichiers As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents ToolStripSeparator9 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents miToolbar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tscMain As System.Windows.Forms.ToolStripContainer
    Friend WithEvents sbStatus As System.Windows.Forms.StatusBar
    Friend WithEvents Fichier As System.Windows.Forms.StatusBarPanel
    Friend WithEvents R�solution As System.Windows.Forms.StatusBarPanel
    Friend WithEvents Taille As System.Windows.Forms.StatusBarPanel
    Friend WithEvents Echelle As System.Windows.Forms.StatusBarPanel
    Friend WithEvents R�slution As System.Windows.Forms.StatusBarPanel
    Friend WithEvents miStatusbar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents miAper�uWindows As System.Windows.Forms.ToolStripMenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAfficheImage))
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.msMain = New System.Windows.Forms.MenuStrip()
        Me.msNavigation = New System.Windows.Forms.ToolStripMenuItem()
        Me.miOuvrir = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miPremier = New System.Windows.Forms.ToolStripMenuItem()
        Me.miPr�c�dent = New System.Windows.Forms.ToolStripMenuItem()
        Me.miSuivant = New System.Windows.Forms.ToolStripMenuItem()
        Me.miDernier = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.miAuHasard = New System.Windows.Forms.ToolStripMenuItem()
        Me.miRetourArri�re = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.miQuitter = New System.Windows.Forms.ToolStripMenuItem()
        Me.msEdition = New System.Windows.Forms.ToolStripMenuItem()
        Me.miSupprimer = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.miCopierCheminImage = New System.Windows.Forms.ToolStripMenuItem()
        Me.miAper�uWindows = New System.Windows.Forms.ToolStripMenuItem()
        Me.msAffichage = New System.Windows.Forms.ToolStripMenuItem()
        Me.ms1Image = New System.Windows.Forms.ToolStripMenuItem()
        Me.ms4Images = New System.Windows.Forms.ToolStripMenuItem()
        Me.ms9Images = New System.Windows.Forms.ToolStripMenuItem()
        Me.ms16Images = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator9 = New System.Windows.Forms.ToolStripSeparator()
        Me.miToolbar = New System.Windows.Forms.ToolStripMenuItem()
        Me.miStatusbar = New System.Windows.Forms.ToolStripMenuItem()
        Me.msHelp = New System.Windows.Forms.ToolStripMenuItem()
        Me.mi�ProposDe = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsMain = New System.Windows.Forms.ToolStrip()
        Me.tsbOuvrir = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbPremier = New System.Windows.Forms.ToolStripButton()
        Me.tsbPr�c�dent = New System.Windows.Forms.ToolStripButton()
        Me.tsbSuivant = New System.Windows.Forms.ToolStripButton()
        Me.tsbDernier = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbRetour = New System.Windows.Forms.ToolStripButton()
        Me.tsbAuHasard = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator8 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbSupprimer = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.lblPos = New System.Windows.Forms.ToolStripLabel()
        Me.cboFichiers = New System.Windows.Forms.ToolStripComboBox()
        Me.tscMain = New System.Windows.Forms.ToolStripContainer()
        Me.sbStatus = New System.Windows.Forms.StatusBar()
        Me.Fichier = New System.Windows.Forms.StatusBarPanel()
        Me.R�slution = New System.Windows.Forms.StatusBarPanel()
        Me.Taille = New System.Windows.Forms.StatusBarPanel()
        Me.Echelle = New System.Windows.Forms.StatusBarPanel()
        Me.msMain.SuspendLayout()
        Me.tsMain.SuspendLayout()
        Me.tscMain.ContentPanel.SuspendLayout()
        Me.tscMain.TopToolStripPanel.SuspendLayout()
        Me.tscMain.SuspendLayout()
        CType(Me.Fichier, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.R�slution, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Taille, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Echelle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'FolderBrowserDialog1
        '
        Me.FolderBrowserDialog1.Description = "S�lectionnez le dossier contenant les images � afficher :"
        Me.FolderBrowserDialog1.ShowNewFolderButton = False
        '
        'msMain
        '
        Me.msMain.Dock = System.Windows.Forms.DockStyle.None
        Me.msMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.msNavigation, Me.msEdition, Me.msAffichage, Me.msHelp})
        Me.msMain.Location = New System.Drawing.Point(0, 0)
        Me.msMain.Name = "msMain"
        Me.msMain.Size = New System.Drawing.Size(656, 24)
        Me.msMain.TabIndex = 11
        Me.msMain.Text = "MenuStrip1"
        '
        'msNavigation
        '
        Me.msNavigation.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miOuvrir, Me.ToolStripSeparator1, Me.miPremier, Me.miPr�c�dent, Me.miSuivant, Me.miDernier, Me.ToolStripSeparator2, Me.miAuHasard, Me.miRetourArri�re, Me.ToolStripSeparator4, Me.miQuitter})
        Me.msNavigation.Name = "msNavigation"
        Me.msNavigation.Size = New System.Drawing.Size(77, 20)
        Me.msNavigation.Text = "&Navigation"
        '
        'miOuvrir
        '
        Me.miOuvrir.Image = Global.AfficheImage2.My.Resources.Resources.Ouvrir
        Me.miOuvrir.Name = "miOuvrir"
        Me.miOuvrir.ShortcutKeyDisplayString = "?"
        Me.miOuvrir.Size = New System.Drawing.Size(213, 22)
        Me.miOuvrir.Text = "&Ouvrir"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(210, 6)
        '
        'miPremier
        '
        Me.miPremier.Image = Global.AfficheImage2.My.Resources.Resources.Premier
        Me.miPremier.Name = "miPremier"
        Me.miPremier.ShortcutKeyDisplayString = "Debut"
        Me.miPremier.Size = New System.Drawing.Size(213, 22)
        Me.miPremier.Text = "Premier"
        '
        'miPr�c�dent
        '
        Me.miPr�c�dent.Image = Global.AfficheImage2.My.Resources.Resources.Pr�c�dent
        Me.miPr�c�dent.Name = "miPr�c�dent"
        Me.miPr�c�dent.ShortcutKeyDisplayString = "-"
        Me.miPr�c�dent.Size = New System.Drawing.Size(213, 22)
        Me.miPr�c�dent.Text = "Pr�c�dent"
        '
        'miSuivant
        '
        Me.miSuivant.Image = Global.AfficheImage2.My.Resources.Resources.Suivant
        Me.miSuivant.Name = "miSuivant"
        Me.miSuivant.ShortcutKeyDisplayString = "+"
        Me.miSuivant.Size = New System.Drawing.Size(213, 22)
        Me.miSuivant.Text = "Suivant"
        '
        'miDernier
        '
        Me.miDernier.Image = Global.AfficheImage2.My.Resources.Resources.Dernier
        Me.miDernier.Name = "miDernier"
        Me.miDernier.ShortcutKeyDisplayString = "Fin"
        Me.miDernier.Size = New System.Drawing.Size(213, 22)
        Me.miDernier.Text = "Dernier"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(210, 6)
        '
        'miAuHasard
        '
        Me.miAuHasard.Image = Global.AfficheImage2.My.Resources.Resources.AuHasard
        Me.miAuHasard.Name = "miAuHasard"
        Me.miAuHasard.ShortcutKeyDisplayString = "*"
        Me.miAuHasard.Size = New System.Drawing.Size(213, 22)
        Me.miAuHasard.Text = "Au hasard"
        '
        'miRetourArri�re
        '
        Me.miRetourArri�re.Image = Global.AfficheImage2.My.Resources.Resources.Retour
        Me.miRetourArri�re.Name = "miRetourArri�re"
        Me.miRetourArri�re.ShortcutKeyDisplayString = "Backaspace"
        Me.miRetourArri�re.Size = New System.Drawing.Size(213, 22)
        Me.miRetourArri�re.Text = "Retour arri�re"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(210, 6)
        '
        'miQuitter
        '
        Me.miQuitter.Name = "miQuitter"
        Me.miQuitter.ShortcutKeyDisplayString = "Alt+F4"
        Me.miQuitter.Size = New System.Drawing.Size(213, 22)
        Me.miQuitter.Text = "&Quitter"
        '
        'msEdition
        '
        Me.msEdition.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miSupprimer, Me.ToolStripSeparator5, Me.miCopierCheminImage, Me.miAper�uWindows})
        Me.msEdition.Name = "msEdition"
        Me.msEdition.Size = New System.Drawing.Size(56, 20)
        Me.msEdition.Text = "&Edition"
        '
        'miSupprimer
        '
        Me.miSupprimer.Image = Global.AfficheImage2.My.Resources.Resources.Supprimer
        Me.miSupprimer.Name = "miSupprimer"
        Me.miSupprimer.ShortcutKeyDisplayString = "Suppr"
        Me.miSupprimer.Size = New System.Drawing.Size(222, 22)
        Me.miSupprimer.Text = "&Supprimer"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(219, 6)
        '
        'miCopierCheminImage
        '
        Me.miCopierCheminImage.Name = "miCopierCheminImage"
        Me.miCopierCheminImage.Size = New System.Drawing.Size(222, 22)
        Me.miCopierCheminImage.Text = "&Copier le chemin de l'image"
        '
        'miAper�uWindows
        '
        Me.miAper�uWindows.Name = "miAper�uWindows"
        Me.miAper�uWindows.Size = New System.Drawing.Size(222, 22)
        Me.miAper�uWindows.Text = "&Aper�u Windows"
        '
        'msAffichage
        '
        Me.msAffichage.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ms1Image, Me.ms4Images, Me.ms9Images, Me.ms16Images, Me.ToolStripSeparator9, Me.miToolbar, Me.miStatusbar})
        Me.msAffichage.Name = "msAffichage"
        Me.msAffichage.Size = New System.Drawing.Size(70, 20)
        Me.msAffichage.Text = "&Affichage"
        '
        'ms1Image
        '
        Me.ms1Image.Name = "ms1Image"
        Me.ms1Image.Size = New System.Drawing.Size(127, 22)
        Me.ms1Image.Text = "&1 image"
        '
        'ms4Images
        '
        Me.ms4Images.Name = "ms4Images"
        Me.ms4Images.Size = New System.Drawing.Size(127, 22)
        Me.ms4Images.Text = "&4 images"
        '
        'ms9Images
        '
        Me.ms9Images.Name = "ms9Images"
        Me.ms9Images.Size = New System.Drawing.Size(127, 22)
        Me.ms9Images.Text = "&9 images"
        '
        'ms16Images
        '
        Me.ms16Images.Name = "ms16Images"
        Me.ms16Images.Size = New System.Drawing.Size(127, 22)
        Me.ms16Images.Text = "1&6 images"
        '
        'ToolStripSeparator9
        '
        Me.ToolStripSeparator9.Name = "ToolStripSeparator9"
        Me.ToolStripSeparator9.Size = New System.Drawing.Size(124, 6)
        '
        'miToolbar
        '
        Me.miToolbar.Checked = True
        Me.miToolbar.CheckState = System.Windows.Forms.CheckState.Checked
        Me.miToolbar.Name = "miToolbar"
        Me.miToolbar.Size = New System.Drawing.Size(127, 22)
        Me.miToolbar.Text = "&Toolbar"
        '
        'miStatusbar
        '
        Me.miStatusbar.Checked = True
        Me.miStatusbar.CheckOnClick = True
        Me.miStatusbar.CheckState = System.Windows.Forms.CheckState.Checked
        Me.miStatusbar.Name = "miStatusbar"
        Me.miStatusbar.Size = New System.Drawing.Size(127, 22)
        Me.miStatusbar.Text = "Status bar"
        '
        'msHelp
        '
        Me.msHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mi�ProposDe})
        Me.msHelp.Name = "msHelp"
        Me.msHelp.Size = New System.Drawing.Size(24, 20)
        Me.msHelp.Text = "&?"
        '
        'mi�ProposDe
        '
        Me.mi�ProposDe.Image = Global.AfficheImage2.My.Resources.Resources.APropos
        Me.mi�ProposDe.Name = "mi�ProposDe"
        Me.mi�ProposDe.Size = New System.Drawing.Size(150, 22)
        Me.mi�ProposDe.Text = "&� propos de ..."
        '
        'tsMain
        '
        Me.tsMain.AllowItemReorder = True
        Me.tsMain.Dock = System.Windows.Forms.DockStyle.None
        Me.tsMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbOuvrir, Me.ToolStripSeparator6, Me.tsbPremier, Me.tsbPr�c�dent, Me.tsbSuivant, Me.tsbDernier, Me.ToolStripSeparator7, Me.tsbRetour, Me.tsbAuHasard, Me.ToolStripSeparator8, Me.tsbSupprimer, Me.ToolStripSeparator3, Me.lblPos, Me.cboFichiers})
        Me.tsMain.Location = New System.Drawing.Point(3, 24)
        Me.tsMain.Name = "tsMain"
        Me.tsMain.Size = New System.Drawing.Size(581, 25)
        Me.tsMain.TabIndex = 12
        Me.tsMain.Text = "Navigation"
        '
        'tsbOuvrir
        '
        Me.tsbOuvrir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbOuvrir.Image = Global.AfficheImage2.My.Resources.Resources.Ouvrir
        Me.tsbOuvrir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbOuvrir.Name = "tsbOuvrir"
        Me.tsbOuvrir.Size = New System.Drawing.Size(23, 22)
        Me.tsbOuvrir.Text = "Ouvrir"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(6, 25)
        '
        'tsbPremier
        '
        Me.tsbPremier.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbPremier.Image = Global.AfficheImage2.My.Resources.Resources.Premier
        Me.tsbPremier.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbPremier.Name = "tsbPremier"
        Me.tsbPremier.Size = New System.Drawing.Size(23, 22)
        Me.tsbPremier.Text = "Premier"
        '
        'tsbPr�c�dent
        '
        Me.tsbPr�c�dent.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbPr�c�dent.Image = Global.AfficheImage2.My.Resources.Resources.Pr�c�dent
        Me.tsbPr�c�dent.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbPr�c�dent.Name = "tsbPr�c�dent"
        Me.tsbPr�c�dent.Size = New System.Drawing.Size(23, 22)
        Me.tsbPr�c�dent.Text = "Pr�c�dent"
        '
        'tsbSuivant
        '
        Me.tsbSuivant.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbSuivant.Image = Global.AfficheImage2.My.Resources.Resources.Suivant
        Me.tsbSuivant.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSuivant.Name = "tsbSuivant"
        Me.tsbSuivant.Size = New System.Drawing.Size(23, 22)
        Me.tsbSuivant.Text = "Suivant"
        '
        'tsbDernier
        '
        Me.tsbDernier.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbDernier.Image = Global.AfficheImage2.My.Resources.Resources.Dernier
        Me.tsbDernier.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbDernier.Name = "tsbDernier"
        Me.tsbDernier.Size = New System.Drawing.Size(23, 22)
        Me.tsbDernier.Text = "Dernier"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 25)
        '
        'tsbRetour
        '
        Me.tsbRetour.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbRetour.Image = Global.AfficheImage2.My.Resources.Resources.Retour
        Me.tsbRetour.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRetour.Name = "tsbRetour"
        Me.tsbRetour.Size = New System.Drawing.Size(23, 22)
        Me.tsbRetour.Text = "Retour"
        '
        'tsbAuHasard
        '
        Me.tsbAuHasard.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbAuHasard.Image = Global.AfficheImage2.My.Resources.Resources.AuHasard
        Me.tsbAuHasard.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbAuHasard.Name = "tsbAuHasard"
        Me.tsbAuHasard.Size = New System.Drawing.Size(23, 22)
        Me.tsbAuHasard.Text = "Au hasard"
        '
        'ToolStripSeparator8
        '
        Me.ToolStripSeparator8.Name = "ToolStripSeparator8"
        Me.ToolStripSeparator8.Size = New System.Drawing.Size(6, 25)
        '
        'tsbSupprimer
        '
        Me.tsbSupprimer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbSupprimer.Image = Global.AfficheImage2.My.Resources.Resources.Supprimer
        Me.tsbSupprimer.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSupprimer.Name = "tsbSupprimer"
        Me.tsbSupprimer.Size = New System.Drawing.Size(23, 22)
        Me.tsbSupprimer.Text = "Supprimer"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'lblPos
        '
        Me.lblPos.Name = "lblPos"
        Me.lblPos.Size = New System.Drawing.Size(26, 22)
        Me.lblPos.Text = "Pos"
        '
        'cboFichiers
        '
        Me.cboFichiers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFichiers.Name = "cboFichiers"
        Me.cboFichiers.Size = New System.Drawing.Size(300, 25)
        '
        'tscMain
        '
        '
        'tscMain.ContentPanel
        '
        Me.tscMain.ContentPanel.AutoScroll = True
        Me.tscMain.ContentPanel.Controls.Add(Me.sbStatus)
        Me.tscMain.ContentPanel.Size = New System.Drawing.Size(656, 464)
        Me.tscMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tscMain.LeftToolStripPanelVisible = False
        Me.tscMain.Location = New System.Drawing.Point(0, 0)
        Me.tscMain.Name = "tscMain"
        Me.tscMain.RightToolStripPanelVisible = False
        Me.tscMain.Size = New System.Drawing.Size(656, 513)
        Me.tscMain.TabIndex = 13
        Me.tscMain.Text = "tscMain"
        '
        'tscMain.TopToolStripPanel
        '
        Me.tscMain.TopToolStripPanel.Controls.Add(Me.msMain)
        Me.tscMain.TopToolStripPanel.Controls.Add(Me.tsMain)
        '
        'sbStatus
        '
        Me.sbStatus.Location = New System.Drawing.Point(0, 442)
        Me.sbStatus.Name = "sbStatus"
        Me.sbStatus.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.Fichier, Me.R�slution, Me.Taille, Me.Echelle})
        Me.sbStatus.ShowPanels = True
        Me.sbStatus.Size = New System.Drawing.Size(656, 22)
        Me.sbStatus.TabIndex = 6
        '
        'Fichier
        '
        Me.Fichier.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.Fichier.Name = "Fichier"
        Me.Fichier.Width = 339
        '
        'R�slution
        '
        Me.R�slution.Name = "R�slution"
        '
        'Taille
        '
        Me.Taille.Name = "Taille"
        '
        'Echelle
        '
        Me.Echelle.Name = "Echelle"
        '
        'frmAfficheImage
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(656, 513)
        Me.Controls.Add(Me.tscMain)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MainMenuStrip = Me.msMain
        Me.Name = "frmAfficheImage"
        Me.Text = "AfficheImage"
        Me.msMain.ResumeLayout(False)
        Me.msMain.PerformLayout()
        Me.tsMain.ResumeLayout(False)
        Me.tsMain.PerformLayout()
        Me.tscMain.ContentPanel.ResumeLayout(False)
        Me.tscMain.TopToolStripPanel.ResumeLayout(False)
        Me.tscMain.TopToolStripPanel.PerformLayout()
        Me.tscMain.ResumeLayout(False)
        Me.tscMain.PerformLayout()
        CType(Me.Fichier, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.R�slution, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Taille, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Echelle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    ' Acc�s au FileSystem
    Dim sRep As String

    ' Navigation
    Dim chLastKey As Char
    Dim iPos As Integer
    Dim iPosPrev As Integer     ' Previous Position

    ' Interface d'affichage
    Dim tImage() As PictureBox
    Dim tImage2() As Image
    Dim iRowSize As Integer = 0
    Dim iMargin As Integer = 8          ' Espace entre images pour l'affichage multiple

    ' Historique
    Dim PileImages As System.Collections.Stack



    Private Sub frmAfficheImage_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        sbStatus.Panels(0).Text = "AfficheImage " & sGetVersion()
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
        D�finitModeAffichage(iRowSize)
        DoAffichage()
    End Sub

    Private Function VB6GetExeName() As String
        Return Path.GetFileName(Assembly.GetExecutingAssembly().Location)
    End Function


    Private Sub Ouvrir()
        FolderBrowserDialog1.SelectedPath = GetSetting(VB6GetExeName(), "Config", "Path", "C:\")
        Dim result As DialogResult = FolderBrowserDialog1.ShowDialog()
        If (result <> Windows.Forms.DialogResult.OK) Then Exit Sub
        sRep = FolderBrowserDialog1.SelectedPath
        SaveSetting(VB6GetExeName(), "Config", "Path", sRep)
        If Microsoft.VisualBasic.Right(sRep, 1) <> "\" Then sRep = sRep & "\"

        cboFichiers.Items.Clear()
        PileImages = New System.Collections.Stack
        Analyse1Rep("")
        sbStatus.Panels(0).Text = "Chargement termin�."
        iPos = 0
        iPosPrev = 0
        AfficheImage()
    End Sub


    Private Sub Analyse1Rep(ByRef sRel As String)
        Dim sFic As String

        ' D'abord les fichiers du r�pertoire
        ' L'acc�s avec l'objet FileSystem est beaucoup trop lent...
        sFic = Dir(sRep & sRel & "*", FileAttribute.Normal Or FileAttribute.ReadOnly Or FileAttribute.Archive)
        While sFic <> ""
            sFic = LCase(sFic)
            If Microsoft.VisualBasic.Right(sFic, 4) = ".gif" Or Microsoft.VisualBasic.Right(sFic, 4) = ".bmp" Or Microsoft.VisualBasic.Right(sFic, 5) = ".html" Or Microsoft.VisualBasic.Right(sFic, 4) = ".jpg" Or Microsoft.VisualBasic.Right(sFic, 5) = ".jpeg" Then
                ' Par convention on ignore les fichiers dont le nom commence par !
                If Microsoft.VisualBasic.Left(sFic, 1) <> "!" Then
                    If cboFichiers.Items.Count < 32766 Then
                        cboFichiers.Items.Add(sRel & sFic)
                        If cboFichiers.Items.Count Mod 100 = 0 Then
                            sbStatus.Panels(0).Text = "Analyse des images du dossier " & sRep & sRel & ": " & cboFichiers.Items.Count & " images"
                        End If
                    End If
                End If
            End If
            sFic = Dir()
        End While

        ' Puis on analyse les sous-r�pertoires
        Dim sSubDir As String
        For Each sSubDir In My.Computer.FileSystem.GetDirectories(sRep & sRel)
            sFic = My.Computer.FileSystem.GetName(sSubDir)
            Analyse1Rep(sRel & sFic & "\")
        Next
    End Sub

    Sub AfficheImage()
        ' Cas o� il n'y a rien de charg�
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
            sbStatus.Panels(0).Text = sRep & cboFichiers.SelectedItem
            If tImage2(0) Is Nothing Then
                sbStatus.Panels(1).Text = "#ERR!"
            Else
                sbStatus.Panels(1).Text = CStr(tImage2(0).Width & " x " & tImage2(0).Height)
            End If
            sbStatus.Panels(2).Text = FormatNumber(FileLen(sRep & cboFichiers.SelectedItem) / 1024, 1) & " Ko"
        End If
        Dim i As Integer
        For i = 0 To iRowSize * iRowSize - 1
            DoAffichageUneImage(i)
        Next
    End Sub

    Sub DoAffichageUneImage(ByVal iOff As Integer)
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
            If iOff = 0 Then sbStatus.Panels(3).Text = FormatPercent(r1, 0)

            Dim imgOutput As Bitmap
            imgOutput = New Bitmap(tImage(iOff).Width, tImage(iOff).Height, System.Drawing.Imaging.PixelFormat.Format32bppRgb)
            Dim h As Graphics = Graphics.FromImage(imgOutput)
            h.Clear(Color.FromKnownColor(KnownColor.Control))
            h.DrawImage(tImage2(iOff), 0, 0, tImage2(iOff).Width * r1, tImage2(iOff).Height * r1)
            tImage(iOff).Image = imgOutput
        End If
    End Sub


    Private Sub frmAfficheImage_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
        ' On �vite les probl�mes en ic�ne ou en fen�tre tr�s r�duite
        If tscMain.ContentPanel.Width <= 0 Or tscMain.ContentPanel.Height <= 0 Then Exit Sub

        D�finitModeAffichage(iRowSize)
        DoAffichage()
    End Sub

    Dim cPrefix As Integer
    Dim tMem(255) As Integer

    Private Sub frmAfficheImage_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        Dim c As Char = e.KeyChar
        Dim n As Integer = Asc(e.KeyChar)
        Select Case cPrefix
            Case Keys.F5    ' M�morise une position
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
            Case "-"c : NaviguePr�c�dent()
            Case "+"c, Chr(13) : NavigueSuivant()
            Case "*"c : NavigueAuHasard()
            Case "?"c : Ouvrir()
        End Select
    End Sub

    Private Sub frmAfficheImage_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Delete : Supprimer()
            Case Keys.Back : RetourArri�re()
            Case Keys.Home : NaviguePremier()
            Case Keys.End : NavigueDernier()
            Case Keys.F5, Keys.F6 : cPrefix = e.KeyCode
            Case Keys.F7    ' Echange la position actuelle et pr�c�dente
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

    Private Sub NaviguePr�c�dent()
        chLastKey = "-"c
        If iPos > 0 Then
            iPosPrev = iPos
            iPos = iPos - 1
            AfficheImage()
        End If
    End Sub

    Private Sub NavigueSuivant()
        chLastKey = "+"c
        If iPos < cboFichiers.Items.Count - 1 Then
            iPosPrev = iPos
            iPos = iPos + 1
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

        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Try
            tImage(0).Image = Nothing
            tImage2(0) = Nothing
            System.GC.Collect()
            System.Windows.Forms.Application.DoEvents()
            System.GC.WaitForPendingFinalizers()

            'Kill(sRep & cboFichiers.SelectedItem)
            ' On envoie dans la corbeille
            My.Computer.FileSystem.DeleteFile(sRep & cboFichiers.SelectedItem, FileIO.UIOption.OnlyErrorDialogs, FileIO.RecycleOption.SendToRecycleBin)

            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            cboFichiers.Items.RemoveAt(iPos)
            If iPos >= cboFichiers.Items.Count Then iPos = cboFichiers.Items.Count - 1
            PileImages.Pop()
            AfficheImage()
        Catch ex As Exception
            System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.Default
            MsgBox("Echec lors la suppression du fichier:" & vbCrLf & ex.Source & ": " & ex.Message)
        End Try

    End Sub

    Sub RetourArri�re()
        If PileImages Is Nothing Then Exit Sub
        If PileImages.Count <= 1 Then Exit Sub
        PileImages.Pop()
        iPosPrev = iPos
        iPos = PileImages.Pop()
        AfficheImage()
    End Sub


    '=============================================================================
    ' Menus

    Private Sub miOuvrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miOuvrir.Click
        Ouvrir()
    End Sub

    Private Sub miPremier_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miPremier.Click
        NaviguePremier()
    End Sub

    Private Sub miPr�c�dent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miPr�c�dent.Click
        NaviguePr�c�dent()
    End Sub

    Private Sub miSuivant_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSuivant.Click
        NavigueSuivant()
    End Sub

    Private Sub miDernier_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miDernier.Click
        NavigueDernier()
    End Sub

    Private Sub miAuHasard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miAuHasard.Click
        NavigueAuHasard()
    End Sub

    Private Sub miRetourArri�re_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miRetourArri�re.Click
        RetourArri�re()
    End Sub

    Private Sub miQuitter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miQuitter.Click
        Close()
    End Sub


    Private Sub miSupprimer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miSupprimer.Click
        Supprimer()
    End Sub

    Private Sub miCopierCheminImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miCopierCheminImage.Click
        DoCopieCheminImage()
    End Sub

    Private Sub miAper�uWindows_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miAper�uWindows.Click
        DoAper�uWindows()
    End Sub


    Private Sub ms1Image_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ms1Image.Click
        D�finitModeAffichage(1)
        AfficheImage()
    End Sub

    Private Sub ms4Images_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ms4Images.Click
        D�finitModeAffichage(2)
        AfficheImage()
    End Sub

    Private Sub ms9Images_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ms9Images.Click
        D�finitModeAffichage(3)
        AfficheImage()
    End Sub

    Private Sub ms16Images_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ms16Images.Click
        D�finitModeAffichage(4)
        AfficheImage()
    End Sub

    Private Sub miToolbar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miToolbar.Click
        miToolbar.Checked = Not miToolbar.Checked
        My.Settings.ToolbarVisible = miToolbar.Checked
        UpdateToolbar()
    End Sub

    Private Sub miStatusbar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles miStatusbar.Click
        ' Auto toggle: miStatusbar.CheckOnClick=True
        My.Settings.StatusbarVisible = miStatusbar.Checked
        UpdateToolbar()
    End Sub


    Private Sub mi�ProposDe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mi�ProposDe.Click
        frmAPropos.DefInstance.ShowDialog()
    End Sub


    '=============================================================================
    ' ToolBar

    Private Sub tsbOuvrir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbOuvrir.Click
        Ouvrir()
    End Sub

    Private Sub tsbPremier_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbPremier.Click
        NaviguePremier()
    End Sub

    Private Sub Pr�c�dent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbPr�c�dent.Click
        NaviguePr�c�dent()
    End Sub

    Private Sub tsbSuivant_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSuivant.Click
        NavigueSuivant()
    End Sub

    Private Sub tsbDernier_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbDernier.Click
        NavigueDernier()
    End Sub

    Private Sub tsbRetour_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRetour.Click
        RetourArri�re()
    End Sub

    Private Sub tsbAuHasard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbAuHasard.Click
        NavigueAuHasard()
    End Sub

    Private Sub tsbSupprimer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSupprimer.Click
        Supprimer()
    End Sub

    '=============================================================================

    Sub D�finitModeAffichage(ByVal iNewRowSize As Integer)
        Dim i As Integer

        If iNewRowSize = 0 Then iNewRowSize = 1

        If iRowSize <> iNewRowSize Then
            If Not tImage Is Nothing Then
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
                    .BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
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
                    .Location = New System.Drawing.Point(3 + c * (iImageWidth + iMargin), 3 + l * (iImageHeight + iMargin))
                    .Size = New System.Drawing.Size(iImageWidth, iImageHeight)
                End With
                i = i + 1
            Next
        Next
    End Sub

    Sub DoCopieCheminImage()
        If cboFichiers.Items.Count = 0 Then Exit Sub
        Clipboard.SetDataObject(sRep & cboFichiers.Items(iPos))
    End Sub

    Sub DoAper�uWindows()
        If cboFichiers.Items.Count = 0 Then Exit Sub

        Dim sFile As String
        sFile = sRep & cboFichiers.Items(iPos)
        System.Diagnostics.Process.Start(sFile)
    End Sub

    Private Sub cboFichiers_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFichiers.SelectedIndexChanged
        If iPos = cboFichiers.SelectedIndex Then Exit Sub
        iPosPrev = iPos
        iPos = cboFichiers.SelectedIndex
        AfficheImage()
    End Sub

    Private Sub tscMain_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles tscMain.Paint
        D�finitModeAffichage(iRowSize)
        DoAffichage()

        'If tscMain.BottomToolStripPanel.Contains(tsMain) Then
        '    MsgBox("Toolbar is in bottom container")
        'Else
        '    MsgBox("Toolbar is not in bottom container")
        'End If
    End Sub
End Class
