' AfficheImage2
' Portage de AfficheImage dans Visual Studio .Net 2003
' 11/05/2003 PV
' 14/07/2003 PV Pb plantage en icône réglé; Commande Copie Chemin
' 24/11/2004 PV Navigation F5/F6/F7

Imports System.IO
Imports System.Reflection

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
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée en utilisant le Concepteur Windows Form.
    'Ne la modifiez pas en utilisant l'éditeur de code.
    Friend WithEvents cboFichiers As ComboBox

    Friend WithEvents sbStatus As StatusBar
    Friend WithEvents Fichier As StatusBarPanel
    Friend WithEvents Réslution As StatusBarPanel
    Friend WithEvents Taille As StatusBarPanel
    Friend WithEvents Echelle As StatusBarPanel
    Friend WithEvents cmdQuitter As MenuItem
    Friend WithEvents lblPos As Label
    Friend WithEvents tbBoutons As ToolBar
    Friend WithEvents sep1 As ToolBarButton
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents sep2 As ToolBarButton
    Friend WithEvents btnPremier As ToolBarButton
    Friend WithEvents btnPrécédent As ToolBarButton
    Friend WithEvents btnSuivant As ToolBarButton
    Friend WithEvents btnDernier As ToolBarButton
    Friend WithEvents sep3 As ToolBarButton
    Friend WithEvents btnAuHasard As ToolBarButton
    Friend WithEvents sep4 As ToolBarButton
    Friend WithEvents btnEffacer As ToolBarButton
    Friend WithEvents btnOuvrir As ToolBarButton
    Friend WithEvents btnRetourArrière As ToolBarButton
    Friend WithEvents mnuAide As MenuItem
    Friend WithEvents cmdAPropos As MenuItem
    Friend WithEvents cmdOuvrir As MenuItem
    Friend WithEvents MenuItem2 As MenuItem
    Friend WithEvents MenuItem3 As MenuItem
    Friend WithEvents MenuItem8 As MenuItem
    Friend WithEvents MenuItem10 As MenuItem
    Friend WithEvents cmdPremier As MenuItem
    Friend WithEvents cmdPrécédent As MenuItem
    Friend WithEvents cmdSuivant As MenuItem
    Friend WithEvents cmdDernier As MenuItem
    Friend WithEvents cmdAuHasard As MenuItem
    Friend WithEvents cmdRetourArrière As MenuItem
    Friend WithEvents MainMenu1 As MainMenu
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents mnuNavigation As MenuItem
    Friend WithEvents cmdAffiche1Image As MenuItem
    Friend WithEvents cmdAffiche4Images As MenuItem
    Friend WithEvents mnuAffichage As MenuItem
    Friend WithEvents paClient As PictureBox
    Friend WithEvents cmd9Images As MenuItem
    Friend WithEvents cmd16images As MenuItem
    Friend WithEvents mnuEdition As MenuItem
    Friend WithEvents cmdCopieCheminImage As MenuItem
    Friend WithEvents MenuItem1 As MenuItem
    Friend WithEvents cmdAperçuWindows As MenuItem

    <DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New ComponentModel.Container
        Dim resources As Resources.ResourceManager = New Resources.ResourceManager(GetType(frmAfficheImage))
        Me.cboFichiers = New ComboBox
        Me.sbStatus = New StatusBar
        Me.Fichier = New StatusBarPanel
        Me.Réslution = New StatusBarPanel
        Me.Taille = New StatusBarPanel
        Me.Echelle = New StatusBarPanel
        Me.MainMenu1 = New MainMenu
        Me.mnuNavigation = New MenuItem
        Me.cmdOuvrir = New MenuItem
        Me.MenuItem2 = New MenuItem
        Me.cmdPremier = New MenuItem
        Me.cmdPrécédent = New MenuItem
        Me.cmdSuivant = New MenuItem
        Me.cmdDernier = New MenuItem
        Me.MenuItem8 = New MenuItem
        Me.cmdAuHasard = New MenuItem
        Me.MenuItem10 = New MenuItem
        Me.cmdRetourArrière = New MenuItem
        Me.MenuItem3 = New MenuItem
        Me.cmdQuitter = New MenuItem
        Me.mnuEdition = New MenuItem
        Me.cmdCopieCheminImage = New MenuItem
        Me.mnuAffichage = New MenuItem
        Me.cmdAffiche1Image = New MenuItem
        Me.cmdAffiche4Images = New MenuItem
        Me.cmd9Images = New MenuItem
        Me.cmd16images = New MenuItem
        Me.mnuAide = New MenuItem
        Me.cmdAPropos = New MenuItem
        Me.FolderBrowserDialog1 = New FolderBrowserDialog
        Me.lblPos = New Label
        Me.tbBoutons = New ToolBar
        Me.sep1 = New ToolBarButton
        Me.btnOuvrir = New ToolBarButton
        Me.sep2 = New ToolBarButton
        Me.btnPremier = New ToolBarButton
        Me.btnPrécédent = New ToolBarButton
        Me.btnSuivant = New ToolBarButton
        Me.btnDernier = New ToolBarButton
        Me.sep3 = New ToolBarButton
        Me.btnRetourArrière = New ToolBarButton
        Me.btnAuHasard = New ToolBarButton
        Me.sep4 = New ToolBarButton
        Me.btnEffacer = New ToolBarButton
        Me.ImageList1 = New ImageList(Me.components)
        Me.paClient = New PictureBox
        Me.MenuItem1 = New MenuItem
        Me.cmdAperçuWindows = New MenuItem
        CType(Me.Fichier, ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Réslution, ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Taille, ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Echelle, ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cboFichiers
        '
        Me.cboFichiers.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), AnchorStyles)
        Me.cboFichiers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFichiers.Location = New Point(312, 5)
        Me.cboFichiers.MaxDropDownItems = 16
        Me.cboFichiers.Name = "cboFichiers"
        Me.cboFichiers.Size = New Size(336, 21)
        Me.cboFichiers.TabIndex = 1
        '
        'sbStatus
        '
        Me.sbStatus.Location = New Point(0, 491)
        Me.sbStatus.Name = "sbStatus"
        Me.sbStatus.Panels.AddRange(New StatusBarPanel() {Me.Fichier, Me.Réslution, Me.Taille, Me.Echelle})
        Me.sbStatus.ShowPanels = True
        Me.sbStatus.Size = New Size(656, 22)
        Me.sbStatus.TabIndex = 5
        '
        'Fichier
        '
        Me.Fichier.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.Fichier.Width = 340
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.AddRange(New MenuItem() {Me.mnuNavigation, Me.mnuEdition, Me.mnuAffichage, Me.mnuAide})
        '
        'mnuNavigation
        '
        Me.mnuNavigation.Index = 0
        Me.mnuNavigation.MenuItems.AddRange(New MenuItem() {Me.cmdOuvrir, Me.MenuItem2, Me.cmdPremier, Me.cmdPrécédent, Me.cmdSuivant, Me.cmdDernier, Me.MenuItem8, Me.cmdAuHasard, Me.MenuItem10, Me.cmdRetourArrière, Me.MenuItem3, Me.cmdQuitter})
        Me.mnuNavigation.Text = "&Navigation"
        '
        'cmdOuvrir
        '
        Me.cmdOuvrir.Index = 0
        Me.cmdOuvrir.Text = "Ouvrir"
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 1
        Me.MenuItem2.Text = "-"
        '
        'cmdPremier
        '
        Me.cmdPremier.Index = 2
        Me.cmdPremier.Text = "Premier"
        '
        'cmdPrécédent
        '
        Me.cmdPrécédent.Index = 3
        Me.cmdPrécédent.Text = "Précédent"
        '
        'cmdSuivant
        '
        Me.cmdSuivant.Index = 4
        Me.cmdSuivant.Text = "Suivant"
        '
        'cmdDernier
        '
        Me.cmdDernier.Index = 5
        Me.cmdDernier.Text = "Dernier"
        '
        'MenuItem8
        '
        Me.MenuItem8.Index = 6
        Me.MenuItem8.Text = "-"
        '
        'cmdAuHasard
        '
        Me.cmdAuHasard.Index = 7
        Me.cmdAuHasard.Text = "Au hasard"
        '
        'MenuItem10
        '
        Me.MenuItem10.Index = 8
        Me.MenuItem10.Text = "-"
        '
        'cmdRetourArrière
        '
        Me.cmdRetourArrière.Index = 9
        Me.cmdRetourArrière.Text = "Retour arrière"
        '
        'MenuItem3
        '
        Me.MenuItem3.Index = 10
        Me.MenuItem3.Text = "-"
        '
        'cmdQuitter
        '
        Me.cmdQuitter.Index = 11
        Me.cmdQuitter.Text = "&Quitter"
        '
        'mnuEdition
        '
        Me.mnuEdition.Index = 1
        Me.mnuEdition.MenuItems.AddRange(New MenuItem() {Me.cmdCopieCheminImage, Me.MenuItem1, Me.cmdAperçuWindows})
        Me.mnuEdition.Text = "&Edition"
        '
        'cmdCopieCheminImage
        '
        Me.cmdCopieCheminImage.Index = 0
        Me.cmdCopieCheminImage.Text = "&Copier le chemin de l'image"
        '
        'mnuAffichage
        '
        Me.mnuAffichage.Index = 2
        Me.mnuAffichage.MenuItems.AddRange(New MenuItem() {Me.cmdAffiche1Image, Me.cmdAffiche4Images, Me.cmd9Images, Me.cmd16images})
        Me.mnuAffichage.Text = "&Affichage"
        '
        'cmdAffiche1Image
        '
        Me.cmdAffiche1Image.Index = 0
        Me.cmdAffiche1Image.Text = "&1 image"
        '
        'cmdAffiche4Images
        '
        Me.cmdAffiche4Images.Index = 1
        Me.cmdAffiche4Images.Text = "&4 images"
        '
        'cmd9Images
        '
        Me.cmd9Images.Index = 2
        Me.cmd9Images.Text = "&9 images"
        '
        'cmd16images
        '
        Me.cmd16images.Index = 3
        Me.cmd16images.Text = "1&6 images"
        '
        'mnuAide
        '
        Me.mnuAide.Index = 3
        Me.mnuAide.MenuItems.AddRange(New MenuItem() {Me.cmdAPropos})
        Me.mnuAide.Text = "&?"
        '
        'cmdAPropos
        '
        Me.cmdAPropos.Index = 0
        Me.cmdAPropos.Text = "&À propos de ..."
        '
        'FolderBrowserDialog1
        '
        Me.FolderBrowserDialog1.Description = "Sélectionnez le dossier contenant les images à afficher :"
        Me.FolderBrowserDialog1.ShowNewFolderButton = False
        '
        'lblPos
        '
        Me.lblPos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblPos.Location = New Point(216, 5)
        Me.lblPos.Name = "lblPos"
        Me.lblPos.Size = New Size(88, 21)
        Me.lblPos.TabIndex = 6
        Me.lblPos.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tbBoutons
        '
        Me.tbBoutons.Buttons.AddRange(New ToolBarButton() {Me.sep1, Me.btnOuvrir, Me.sep2, Me.btnPremier, Me.btnPrécédent, Me.btnSuivant, Me.btnDernier, Me.sep3, Me.btnRetourArrière, Me.btnAuHasard, Me.sep4, Me.btnEffacer})
        Me.tbBoutons.DropDownArrows = True
        Me.tbBoutons.ImageList = Me.ImageList1
        Me.tbBoutons.Location = New Point(0, 0)
        Me.tbBoutons.Name = "tbBoutons"
        Me.tbBoutons.ShowToolTips = True
        Me.tbBoutons.Size = New Size(656, 28)
        Me.tbBoutons.TabIndex = 7
        '
        'sep1
        '
        Me.sep1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnOuvrir
        '
        Me.btnOuvrir.ImageIndex = 0
        Me.btnOuvrir.Tag = "Ouvrir"
        Me.btnOuvrir.ToolTipText = "Ouvrir (?)"
        '
        'sep2
        '
        Me.sep2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnPremier
        '
        Me.btnPremier.ImageIndex = 1
        Me.btnPremier.Tag = "Premier"
        Me.btnPremier.ToolTipText = "Première image (Début)"
        '
        'btnPrécédent
        '
        Me.btnPrécédent.ImageIndex = 2
        Me.btnPrécédent.Tag = "Précédent"
        Me.btnPrécédent.ToolTipText = "Image précédente (-)"
        '
        'btnSuivant
        '
        Me.btnSuivant.ImageIndex = 3
        Me.btnSuivant.Tag = "Suivant"
        Me.btnSuivant.ToolTipText = "Image suivante (+)"
        '
        'btnDernier
        '
        Me.btnDernier.ImageIndex = 4
        Me.btnDernier.Tag = "Dernier"
        Me.btnDernier.ToolTipText = "Dernière image (Fin)"
        '
        'sep3
        '
        Me.sep3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnRetourArrière
        '
        Me.btnRetourArrière.ImageIndex = 7
        Me.btnRetourArrière.Tag = "RetourArrière"
        Me.btnRetourArrière.ToolTipText = "Image précédente dans l'historique (Ret.Arr)"
        '
        'btnAuHasard
        '
        Me.btnAuHasard.ImageIndex = 5
        Me.btnAuHasard.Tag = "AuHasard"
        Me.btnAuHasard.ToolTipText = "Image au hasard (*)"
        '
        'sep4
        '
        Me.sep4.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
        '
        'btnEffacer
        '
        Me.btnEffacer.ImageIndex = 6
        Me.btnEffacer.Tag = "Effacer"
        Me.btnEffacer.ToolTipText = "Supprime l'image (Suppr)"
        '
        'ImageList1
        '
        Me.ImageList1.ImageSize = New Size(16, 16)
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Silver
        '
        'paClient
        '
        Me.paClient.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), AnchorStyles)
        Me.paClient.BackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(224, Byte), CType(192, Byte))
        Me.paClient.Location = New Point(8, 32)
        Me.paClient.Name = "paClient"
        Me.paClient.Size = New Size(640, 456)
        Me.paClient.TabIndex = 10
        Me.paClient.TabStop = False
        Me.paClient.Visible = False
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 1
        Me.MenuItem1.Text = "-"
        '
        'cmdAperçuWindows
        '
        Me.cmdAperçuWindows.Index = 2
        Me.cmdAperçuWindows.Text = "&Aperçu Windows"
        '
        'frmAfficheImage
        '
        Me.AutoScaleBaseSize = New Size(5, 13)
        Me.ClientSize = New Size(656, 513)
        Me.Controls.Add(Me.paClient)
        Me.Controls.Add(Me.lblPos)
        Me.Controls.Add(Me.cboFichiers)
        Me.Controls.Add(Me.tbBoutons)
        Me.Controls.Add(Me.sbStatus)
        Me.Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Me.KeyPreview = True
        Me.Menu = Me.MainMenu1
        Me.Name = "frmAfficheImage"
        Me.Text = "AfficheImage"
        CType(Me.Fichier, ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Réslution, ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Taille, ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Echelle, ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    ' Accès au FileSystem
    Dim sRep As String

    Dim fso As Scripting.FileSystemObject

    ' Navigation
    Dim chLastKey As Char

    Dim iPos As Integer
    Dim iPosPrev As Integer     ' Previous Position

    ' Interface d'affichage
    Dim tImage() As PictureBox

    Dim tImage2() As Image
    Dim iRowSize As Integer = 0
    ReadOnly iMargin As Integer = 8

    ' Historique
    Dim PileImages As Stack

    Private Function VB6GetExeName() As String
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
        fso = New Scripting.FileSystemObject
        Analyse1Rep("")
        fso = Nothing
        sbStatus.Panels(0).Text = "Chargement terminé."
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
                            sbStatus.Panels(0).Text = "Analyse des images du dossier " & sRep & sRel & ": " & cboFichiers.Items.Count & " images"
                        End If
                    End If
                End If
            End If
            sFic = Dir()
        End While

        ' Puis on analyse les sous-répertoires
        Dim fo, sfo As Scripting.Folder
        fo = fso.GetFolder(sRep & sRel)
        For Each sfo In fo.SubFolders
            sFic = LCase(sfo.Name)
            Analyse1Rep(sRel & sFic & "\")
        Next sfo
    End Sub

    Private Sub frmAfficheImage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        sbStatus.Panels(0).Text = "AfficheImage " & sGetVersion()

        cmdOuvrir.Text = "&Ouvrir" & vbTab & "?"
        cmdPremier.Text = "Pre&mier" & vbTab & "Début"
        cmdPrécédent.Text = "&Précédent" & vbTab & "-"
        cmdSuivant.Text = "&Suivant" & vbTab & "+"
        cmdDernier.Text = "&Dernier" & vbTab & "Fin"
        cmdAuHasard.Text = "&Au hasard" & vbTab & "*"
        cmdRetourArrière.Text = "&Retour" & vbTab & "Ret.Arr"
        cmdQuitter.Text = "&Quitter" & vbTab & "Alt+F4"

        Randomize()
        Visible = True

        Ouvrir()
    End Sub

    Private Sub cboFichiers_SelectedIndexChanged(sender As System.Object, e As EventArgs) Handles cboFichiers.SelectedIndexChanged
        If iPos = cboFichiers.SelectedIndex Then Exit Sub
        iPosPrev = iPos
        iPos = cboFichiers.SelectedIndex
        AfficheImage()
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
            If iOff = 0 Then sbStatus.Panels(3).Text = FormatPercent(r1, 0)

            Dim imgOutput As Bitmap
            imgOutput = New Bitmap(tImage(iOff).Width, tImage(iOff).Height, System.Drawing.Imaging.PixelFormat.Format32bppRgb)
            Dim h As Graphics = Graphics.FromImage(imgOutput)
            h.Clear(Color.FromKnownColor(KnownColor.Control))
            h.DrawImage(tImage2(iOff), 0, 0, tImage2(iOff).Width * r1, tImage2(iOff).Height * r1)
            tImage(iOff).Image = imgOutput
        End If
    End Sub

    Private Sub frmAfficheImage_Resize(sender As Object, e As EventArgs) Handles MyBase.Resize
        ' On évite les problèmes en icône ou en fenêtre très réduite
        If paClient.Width <= 0 Or paClient.Height <= 0 Then Exit Sub

        DéfinitModeAffichage(iRowSize)
        DoAffichage()
    End Sub

    Private Sub cmdQuitter_Click(sender As System.Object, e As EventArgs) Handles cmdQuitter.Click
        Close()
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
            Case Keys.Delete : Effacer()
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
        If iPos > 0 Then
            iPosPrev = iPos
            iPos -= 1
            AfficheImage()
        End If
    End Sub

    Private Sub NavigueSuivant()
        chLastKey = "+"c
        If iPos < cboFichiers.Items.Count - 1 Then
            iPosPrev = iPos
            iPos += 1
            AfficheImage()
        End If
    End Sub

    Private Sub NavigueDernier()
        iPosPrev = iPos
        iPos = cboFichiers.Items.Count - 1
        If iPos < 0 Then iPos = 0
        AfficheImage()
    End Sub

    Private Sub tbBoutons_ButtonClick(sender As System.Object, e As ToolBarButtonClickEventArgs) Handles tbBoutons.ButtonClick
        Select Case CStr(e.Button.Tag)
            Case "Ouvrir" : Ouvrir()
            Case "Premier" : NaviguePremier()
            Case "Précédent" : NaviguePrécédent()
            Case "Suivant" : NavigueSuivant()
            Case "Dernier" : NavigueDernier()
            Case "RetourArrière" : RetourArrière()
            Case "AuHasard" : NavigueAuHasard()
            Case "Effacer" : Effacer()
            Case Else : Stop
        End Select
    End Sub

    Sub Effacer()
        If cboFichiers.Items.Count = 0 Then Exit Sub

        System.Windows.Forms.Cursor.Current = System.Windows.Forms.Cursors.WaitCursor
        Try
            tImage(0).Image = Nothing
            tImage2(0) = Nothing
            System.GC.Collect()
            System.Windows.Forms.Application.DoEvents()
            System.GC.WaitForPendingFinalizers()
            'System.Threading.Thread.Sleep(250)

            Kill(sRep & cboFichiers.SelectedItem)
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

    Sub RetourArrière()
        If PileImages Is Nothing Then Exit Sub
        If PileImages.Count <= 1 Then Exit Sub
        PileImages.Pop()
        iPosPrev = iPos
        iPos = PileImages.Pop()
        AfficheImage()
    End Sub

    Private Sub cmdAPropos_Click(sender As System.Object, e As EventArgs) Handles cmdAPropos.Click
        frmAPropos.DefInstance.ShowDialog()
    End Sub

    Private Sub cmdOuvrir_Click(sender As System.Object, e As EventArgs) Handles cmdOuvrir.Click
        Ouvrir()
    End Sub

    Private Sub cmdPremier_Click(sender As System.Object, e As EventArgs) Handles cmdPremier.Click
        NaviguePremier()
    End Sub

    Private Sub cmdPrécédent_Click(sender As System.Object, e As EventArgs) Handles cmdPrécédent.Click
        NaviguePrécédent()
    End Sub

    Private Sub cmdSuivant_Click(sender As System.Object, e As EventArgs) Handles cmdSuivant.Click
        NavigueSuivant()
    End Sub

    Private Sub cmdDernier_Click(sender As System.Object, e As EventArgs) Handles cmdDernier.Click
        NavigueDernier()
    End Sub

    Private Sub cmdAuHasard_Click(sender As System.Object, e As EventArgs) Handles cmdAuHasard.Click
        NavigueAuHasard()
    End Sub

    Private Sub cmdRetourArrière_Click(sender As System.Object, e As EventArgs) Handles cmdRetourArrière.Click
        RetourArrière()
    End Sub

    Private Sub cmdAffiche1Image_Click(sender As System.Object, e As EventArgs) Handles cmdAffiche1Image.Click
        DéfinitModeAffichage(1)
        AfficheImage()
    End Sub

    Private Sub cmdAffiche4Images_Click(sender As System.Object, e As EventArgs) Handles cmdAffiche4Images.Click
        DéfinitModeAffichage(2)
        AfficheImage()
    End Sub

    Private Sub cmd9Images_Click(sender As System.Object, e As EventArgs) Handles cmd9Images.Click
        DéfinitModeAffichage(3)
        AfficheImage()
    End Sub

    Private Sub cmd16images_Click(sender As System.Object, e As EventArgs) Handles cmd16images.Click
        DéfinitModeAffichage(4)
        AfficheImage()
    End Sub

    Sub DéfinitModeAffichage(iNewRowSize As Integer)
        Dim i As Integer

        If iNewRowSize = 0 Then iNewRowSize = 1

        If iRowSize <> iNewRowSize Then
            If tImage IsNot Nothing Then
                'MsgBox("avant: " & Me.Controls.Count)
                For i = iRowSize * iRowSize To UBound(tImage)
                    For j As Integer = 0 To Me.Controls.Count
                        If Me.Controls(i) Is tImage(i) Then
                            Me.Controls.RemoveAt(i)
                            Exit For
                        End If
                    Next
                    tImage(i) = Nothing
                Next
                'MsgBox("après: " & Me.Controls.Count)
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
                Me.Controls.Add(tImage(i))
            End If
        Next

        Dim iImageWidth As Integer = (paClient.Width - iMargin * (iRowSize - 1)) / iRowSize
        Dim iImageHeight As Integer = (paClient.Height - iMargin * (iRowSize - 1)) / iRowSize
        i = 0
        For l As Integer = 0 To iRowSize - 1
            For c As Integer = 0 To iRowSize - 1
                With tImage(i)
                    .Location = New Point(paClient.Left + c * (iImageWidth + iMargin), paClient.Top + l * (iImageHeight + iMargin))
                    .Size = New Size(iImageWidth, iImageHeight)
                End With
                i += 1
            Next
        Next

    End Sub

    Private Sub cmdCopieCheminImage_Click(sender As System.Object, e As EventArgs) Handles cmdCopieCheminImage.Click
        If cboFichiers.Items.Count = 0 Then Exit Sub

        Clipboard.SetDataObject(sRep & cboFichiers.Items(iPos))
    End Sub

    Private Sub cmdAperçuWindows_Click(sender As System.Object, e As EventArgs) Handles cmdAperçuWindows.Click
        If cboFichiers.Items.Count = 0 Then Exit Sub

        Dim sFile As String
        sFile = sRep & cboFichiers.Items(iPos)
        System.Diagnostics.Process.Start(sFile)
    End Sub

End Class