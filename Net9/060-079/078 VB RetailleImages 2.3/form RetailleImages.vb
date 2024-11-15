' frmRetailleImages
' Application de redimensionnement d'images en VB.Net
'
' 2003-07       PV
' 2003-07-30 	PV		Contrôle de la qualité
' 2006-10-01 	PV		VS 2005
' 2007-05-18 	PV		About... in system menu
' 2007-05-21 	PV		Les images plus petites gardent leur taille; option récursive
' 2009-10-15 	PV		VS 2008 et ajout suffixe R automatiquement
' 2012-02-25	PV		VS2010; .Net Framework Client Profile 4.0
' 2021-09-19 	PV		VS2022, Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9

Option Explicit On
Option Compare Text

Imports System.ComponentModel
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Threading

Public Class VignettesForm
    Inherits Form

    Private m_iGrandCote As Integer
    Friend WithEvents RécursifCheckBox As CheckBox

    ''' <summary>About command in System menu</summary>
    Private WithEvents SubclassedSystemMenu As SubclassedSystemMenu

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
            components?.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requis par le Concepteur Windows Form
    Private ReadOnly components As IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée en utilisant le Concepteur Windows Form.  
    'Ne la modifiez pas en utilisant l'éditeur de code.
    Friend WithEvents GénèreButton As Button
    Friend WithEvents TraceList As ListBox
    Friend WithEvents SourceLabel As Label
    Friend WithEvents SourceText As TextBox
    Friend WithEvents DestinationText As TextBox
    Friend WithEvents DestinationLabel As Label
    Friend WithEvents TailleLabel As Label
    Friend WithEvents TailleText As TextBox
    Friend WithEvents LookupSourceButton As Button
    Friend WithEvents LookupDestinationButton As Button
    Friend WithEvents FolderBrowser As FolderBrowserDialog
    Friend WithEvents QualitéText As TextBox
    Friend WithEvents QualitéLabel As Label
    Friend WithEvents QualitéTrackBar As TrackBar
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    <DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources = New ComponentResourceManager(GetType(VignettesForm))
        GénèreButton = New Button()
        TraceList = New ListBox()
        SourceLabel = New Label()
        SourceText = New TextBox()
        DestinationText = New TextBox()
        DestinationLabel = New Label()
        TailleLabel = New Label()
        TailleText = New TextBox()
        LookupSourceButton = New Button()
        LookupDestinationButton = New Button()
        FolderBrowser = New FolderBrowserDialog()
        QualitéText = New TextBox()
        QualitéLabel = New Label()
        QualitéTrackBar = New TrackBar()
        Label1 = New Label()
        Label2 = New Label()
        RécursifCheckBox = New CheckBox()
        CType(QualitéTrackBar, ISupportInitialize).BeginInit()
        SuspendLayout()
        '
        'GénèreButton
        '
        GénèreButton.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        GénèreButton.Location = New Point(754, 15)
        GénèreButton.Name = "GénèreButton"
        GénèreButton.Size = New Size(187, 59)
        GénèreButton.TabIndex = 15
        GénèreButton.Text = "&Génère"
        '
        'TraceList
        '
        TraceList.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom _
            Or AnchorStyles.Left _
            Or AnchorStyles.Right
        TraceList.ItemHeight = 25
        TraceList.Location = New Point(14, 366)
        TraceList.Name = "TraceList"
        TraceList.Size = New Size(927, 254)
        TraceList.TabIndex = 12
        '
        'SourceLabel
        '
        SourceLabel.Location = New Point(14, 15)
        SourceLabel.Name = "SourceLabel"
        SourceLabel.Size = New Size(180, 29)
        SourceLabel.TabIndex = 0
        SourceLabel.Text = "Répertoire &source :"
        '
        'SourceText
        '
        SourceText.Anchor = AnchorStyles.Top Or AnchorStyles.Left _
            Or AnchorStyles.Right
        SourceText.Location = New Point(14, 44)
        SourceText.Name = "SourceText"
        SourceText.Size = New Size(670, 31)
        SourceText.TabIndex = 1
        '
        'DestinationText
        '
        DestinationText.Anchor = AnchorStyles.Top Or AnchorStyles.Left _
            Or AnchorStyles.Right
        DestinationText.Location = New Point(14, 159)
        DestinationText.Name = "DestinationText"
        DestinationText.Size = New Size(670, 31)
        DestinationText.TabIndex = 5
        '
        'DestinationLabel
        '
        DestinationLabel.Location = New Point(14, 129)
        DestinationLabel.Name = "DestinationLabel"
        DestinationLabel.Size = New Size(231, 30)
        DestinationLabel.TabIndex = 4
        DestinationLabel.Text = "Répertoire &destination :"
        '
        'TailleLabel
        '
        TailleLabel.Location = New Point(14, 218)
        TailleLabel.Name = "TailleLabel"
        TailleLabel.Size = New Size(245, 29)
        TailleLabel.TabIndex = 7
        TailleLabel.Text = "&Taille grand coté (pixels) :"
        '
        'TailleText
        '
        TailleText.Location = New Point(266, 210)
        TailleText.Name = "TailleText"
        TailleText.Size = New Size(101, 31)
        TailleText.TabIndex = 8
        TailleText.Text = "2500"
        '
        'LookupSourceButton
        '
        LookupSourceButton.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        LookupSourceButton.Location = New Point(698, 44)
        LookupSourceButton.Name = "LookupSourceButton"
        LookupSourceButton.Size = New Size(43, 43)
        LookupSourceButton.TabIndex = 2
        LookupSourceButton.Text = "..."
        '
        'LookupDestinationButton
        '
        LookupDestinationButton.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        LookupDestinationButton.Location = New Point(698, 159)
        LookupDestinationButton.Name = "LookupDestinationButton"
        LookupDestinationButton.Size = New Size(43, 42)
        LookupDestinationButton.TabIndex = 6
        LookupDestinationButton.Text = "..."
        '
        'QualitéText
        '
        QualitéText.Location = New Point(266, 284)
        QualitéText.Name = "QualitéText"
        QualitéText.Size = New Size(101, 31)
        QualitéText.TabIndex = 10
        '
        'QualitéLabel
        '
        QualitéLabel.AutoSize = True
        QualitéLabel.Location = New Point(14, 292)
        QualitéLabel.Name = "QualitéLabel"
        QualitéLabel.Size = New Size(181, 25)
        QualitéLabel.TabIndex = 9
        QualitéLabel.Text = "&Qualité JPEG (0-100) :"
        '
        'QualitéTrackBar
        '
        QualitéTrackBar.Anchor = AnchorStyles.Top Or AnchorStyles.Left _
            Or AnchorStyles.Right
        QualitéTrackBar.Location = New Point(389, 270)
        QualitéTrackBar.Maximum = 100
        QualitéTrackBar.Name = "QualitéTrackBar"
        QualitéTrackBar.Size = New Size(561, 69)
        QualitéTrackBar.TabIndex = 11
        QualitéTrackBar.TickFrequency = 5
        QualitéTrackBar.TickStyle = TickStyle.TopLeft
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Location = New Point(389, 233)
        Label1.Name = "Label1"
        Label1.Size = New Size(57, 25)
        Label1.TabIndex = 13
        Label1.Text = "Faible"
        '
        'Label2
        '
        Label2.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Label2.AutoSize = True
        Label2.Location = New Point(777, 233)
        Label2.Name = "Label2"
        Label2.Size = New Size(156, 25)
        Label2.TabIndex = 14
        Label2.Text = "Sans compression"
        '
        'RécursifCheckBox
        '
        RécursifCheckBox.AutoSize = True
        RécursifCheckBox.Location = New Point(20, 85)
        RécursifCheckBox.Name = "RécursifCheckBox"
        RécursifCheckBox.Size = New Size(230, 29)
        RécursifCheckBox.TabIndex = 3
        RécursifCheckBox.Text = "Inclu&re les sous-dossiers"
        RécursifCheckBox.UseVisualStyleBackColor = True
        '
        'VignettesForm
        '
        AcceptButton = GénèreButton
        AutoScaleBaseSize = New Size(9, 24)
        ClientSize = New Size(956, 706)
        Controls.Add(RécursifCheckBox)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(QualitéTrackBar)
        Controls.Add(QualitéText)
        Controls.Add(QualitéLabel)
        Controls.Add(LookupDestinationButton)
        Controls.Add(LookupSourceButton)
        Controls.Add(TailleText)
        Controls.Add(TailleLabel)
        Controls.Add(DestinationText)
        Controls.Add(DestinationLabel)
        Controls.Add(SourceText)
        Controls.Add(SourceLabel)
        Controls.Add(TraceList)
        Controls.Add(GénèreButton)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "VignettesForm"
        Text = "Retaille d'images / Génération de vignettes"
        CType(QualitéTrackBar, ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()

    End Sub

#End Region

    Private Sub GénèreButton_Click(sender As Object, e As EventArgs) Handles GénèreButton.Click
        Dim m_sSourcePath As String
        Dim m_sDestinationPath As String

        If Not Directory.Exists(SourceText.Text) Then
            MsgBox("Répertoire source inexistant ou inaccessible.", MsgBoxStyle.Exclamation)
            SourceText.Focus()
            Exit Sub
        End If

        'If Not System.IO.Directory.Exists(txtDestination.Text) Then
        '    MsgBox("Répertoire destination inexistant ou inaccessible.", MsgBoxStyle.Exclamation)
        '    txtDestination.Focus()
        '    Exit Sub
        'End If

        m_iGrandCote = Val(TailleText.Text)
        If m_iGrandCote < 50 Or m_iGrandCote > 3000 Then
            MsgBox("Taille du grand coté invalide (doit être comprise entre 50 et 3000)", MsgBoxStyle.Exclamation)
            TailleText.Focus()
            Exit Sub
        End If

        m_sSourcePath = SourceText.Text
        'If Microsoft.VisualBasic.Right(m_sSourcePath, 1) <> "\" Then m_sSourcePath = m_sSourcePath & "\"
        m_sDestinationPath = DestinationText.Text
        'If Microsoft.VisualBasic.Right(m_sDestinationPath, 1) <> "\" Then m_sDestinationPath = m_sDestinationPath & "\"

        If StrComp(m_sSourcePath, m_sDestinationPath, CompareMethod.Text) = 0 Then
            MsgBox("Les deux répertoires ne peuvent être identiques.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        GénèreButton.Enabled = False
        Génération(m_sSourcePath, m_sDestinationPath)
        Trace("Fin de la génération")
        GénèreButton.Enabled = True
    End Sub

    Public Sub Génération(sSourcePath As String, sDestinationPath As String)
        Trace("Génération " & sSourcePath & " --> " & sDestinationPath)

        If Not My.Computer.FileSystem.DirectoryExists(sDestinationPath) Then
            Try
                Trace("Création du dossier " & sDestinationPath)
                My.Computer.FileSystem.CreateDirectory(sDestinationPath)
            Catch ex As Exception
                Trace("Erreur durant la création: " & ex.Message)
                Exit Sub
            End Try
        End If

        Dim dir As DirectoryInfo
        dir = New DirectoryInfo(sSourcePath)
        Dim fic As FileInfo

        For Each fic In dir.GetFiles("*.jpg")
            Try
                GénèreVignette(sSourcePath, sDestinationPath, fic.Name)
                GC.Collect()
                GC.WaitForPendingFinalizers()
                Thread.Sleep(0)
            Catch
            End Try
        Next

        If RécursifCheckBox.Checked Then
            Dim subdir As DirectoryInfo
            For Each subdir In dir.GetDirectories
                If subdir.FullName <> sDestinationPath Then
                    Génération(sSourcePath & "\" & subdir.Name, sDestinationPath & "\" & subdir.Name)
                End If
            Next
        End If
    End Sub

    Public Sub GénèreVignette(sSourcePath As String, sDestinationPath As String, sNomfic As String)
        'Dim sImg As String
        Dim sPathImg As String
        Dim sPathVignette As String

        sPathImg = sSourcePath & "\" & sNomfic
        sPathVignette = sDestinationPath & "\" & sNomfic

        Dim imgSource As Bitmap
        imgSource = Image.FromFile(sPathImg)

        Dim iNewWidth, iNewHeight As Integer
        If imgSource.Width > imgSource.Height Then
            If imgSource.Width < m_iGrandCote Then
                ' Smaller images keep their size
                iNewWidth = imgSource.Width
                iNewHeight = imgSource.Height
            Else
                iNewWidth = m_iGrandCote
                iNewHeight = m_iGrandCote / imgSource.Width * imgSource.Height
            End If
        Else
            If imgSource.Height < m_iGrandCote Then
                iNewWidth = imgSource.Width
                iNewHeight = imgSource.Height
            Else
                iNewHeight = m_iGrandCote
                iNewWidth = m_iGrandCote / imgSource.Height * imgSource.Width
            End If
        End If

        Dim imgOutput As Bitmap

        ' Version compliquée avec DrawImage
        'imgOutput = New Bitmap(iNewWidth, iNewHeight, System.Drawing.Imaging.PixelFormat.Format32bppRgb)
        'Dim h As Graphics = Graphics.FromImage(imgOutput)
        'h.DrawImage(img, 0, 0, iNewWidth, iNewHeight)

        ' Version simplifiée avec le constructeur de Bitmap qui remet à l'échelle
        imgOutput = New Bitmap(imgSource, iNewWidth, iNewHeight)

        ' On contrôle la qualité
        Dim eps As New EncoderParameters(1)
        eps.Param(0) = New EncoderParameter(Encoder.Quality, QualitéText.Text)
        Dim ici As ImageCodecInfo = GetEncoderInfo("image/jpeg")

        ' Et on enregistre
        imgOutput.Save(sPathVignette, ici, eps)

        Trace(sNomfic)
    End Sub

    Public Sub Trace(sMsg As String)
        TraceList.Items.Add(sMsg)
        TraceList.SelectedIndex = TraceList.Items.Count - 1
        TraceList.Refresh()
    End Sub

    Private Sub LookupSourceButton_Click(sender As Object, e As EventArgs) Handles LookupSourceButton.Click
        FolderBrowser.SelectedPath = SourceText.Text
        FolderBrowser.ShowNewFolderButton = False
        FolderBrowser.Description = "Sélectionnez le dossier contenant les images source :"
        If FolderBrowser.ShowDialog(Me) = DialogResult.OK Then
            SourceText.Text = FolderBrowser.SelectedPath
            SourceText.SelectionStart = 0
            SourceText.SelectionLength = 999
        End If
    End Sub

    Private Sub LookupDestinationButton_Click(sender As Object, e As EventArgs) Handles LookupDestinationButton.Click
        FolderBrowser.SelectedPath = DestinationText.Text
        FolderBrowser.ShowNewFolderButton = True
        FolderBrowser.Description = "Sélectionnez le dossier de destination pour les vignettes :"
        If FolderBrowser.ShowDialog(Me) = DialogResult.OK Then
            DestinationText.Text = FolderBrowser.SelectedPath
            DestinationText.SelectionStart = 0
            DestinationText.SelectionLength = 999
        End If
    End Sub

    Private Shared Function GetEncoderInfo(mimeType As String) As ImageCodecInfo
        Dim j As Integer
        Dim encoders As ImageCodecInfo()
        encoders = ImageCodecInfo.GetImageEncoders()
        For j = 0 To encoders.Length
            If encoders(j).MimeType = mimeType Then
                Return encoders(j)
            End If
        Next j
        Return Nothing
    End Function

    Private Sub QualitéText_TextChanged(sender As Object, e As EventArgs) Handles QualitéText.TextChanged
        QualitéTrackBar.Value = Val(QualitéText.Text)
    End Sub

    Private Sub QualitéText_Scroll(sender As Object, e As EventArgs) Handles QualitéTrackBar.Scroll
        QualitéText.Text = Format(QualitéTrackBar.Value)
    End Sub

    Private Sub VignettesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        QualitéText.Text = "90"
        ' About command in System menu
        SubclassedSystemMenu = New SubclassedSystemMenu(Handle.ToInt32, "&À propos de...")
    End Sub

    Private Sub SourceText_GotFocus(sender As Object, e As EventArgs) Handles SourceText.GotFocus
        SourceText.SelectionStart = 0
        SourceText.SelectionLength = 999
    End Sub

    Private Sub DestinationText_GotFocus(sender As Object, e As EventArgs) Handles DestinationText.GotFocus
        DestinationText.SelectionStart = 0
        DestinationText.SelectionLength = 999
    End Sub

    ''' <summary>
    ''' Event handled for About command in System menu
    ''' </summary>
    Private Sub SubclassedSystemMenu_LaunchDialog() Handles SubclassedSystemMenu.LaunchDialog
        Dim frmNew As New AboutForm
        frmNew.ShowDialog(Me)
    End Sub

    Private Sub SourceText_TextChanged(sender As Object, e As EventArgs) Handles SourceText.TextChanged
        If My.Computer.FileSystem.DirectoryExists(SourceText.Text) Then
            If DestinationText.Text = "" And My.Computer.FileSystem.DirectoryExists(SourceText.Text & "R") Then
                DestinationText.Text = SourceText.Text & "R"
            End If
        End If
    End Sub

End Class

