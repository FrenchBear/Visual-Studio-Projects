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

Option Explicit On
Option Compare Text

Imports System.ComponentModel
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Threading

Public Class VignettesForm
    Inherits Form

    Dim m_iGrandCote As Integer
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
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
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
        Me.GénèreButton = New Button()
        Me.TraceList = New ListBox()
        Me.SourceLabel = New Label()
        Me.SourceText = New TextBox()
        Me.DestinationText = New TextBox()
        Me.DestinationLabel = New Label()
        Me.TailleLabel = New Label()
        Me.TailleText = New TextBox()
        Me.LookupSourceButton = New Button()
        Me.LookupDestinationButton = New Button()
        Me.FolderBrowser = New FolderBrowserDialog()
        Me.QualitéText = New TextBox()
        Me.QualitéLabel = New Label()
        Me.QualitéTrackBar = New TrackBar()
        Me.Label1 = New Label()
        Me.Label2 = New Label()
        Me.RécursifCheckBox = New CheckBox()
        CType(Me.QualitéTrackBar, ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GénèreButton
        '
        Me.GénèreButton.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles)
        Me.GénèreButton.Location = New Point(754, 15)
        Me.GénèreButton.Name = "GénèreButton"
        Me.GénèreButton.Size = New Size(187, 59)
        Me.GénèreButton.TabIndex = 15
        Me.GénèreButton.Text = "&Génère"
        '
        'TraceList
        '
        Me.TraceList.Anchor = CType((((AnchorStyles.Top Or AnchorStyles.Bottom) _
            Or AnchorStyles.Left) _
            Or AnchorStyles.Right), AnchorStyles)
        Me.TraceList.ItemHeight = 25
        Me.TraceList.Location = New Point(14, 366)
        Me.TraceList.Name = "TraceList"
        Me.TraceList.Size = New Size(927, 254)
        Me.TraceList.TabIndex = 12
        '
        'SourceLabel
        '
        Me.SourceLabel.Location = New Point(14, 15)
        Me.SourceLabel.Name = "SourceLabel"
        Me.SourceLabel.Size = New Size(180, 29)
        Me.SourceLabel.TabIndex = 0
        Me.SourceLabel.Text = "Répertoire &source :"
        '
        'SourceText
        '
        Me.SourceText.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Left) _
            Or AnchorStyles.Right), AnchorStyles)
        Me.SourceText.Location = New Point(14, 44)
        Me.SourceText.Name = "SourceText"
        Me.SourceText.Size = New Size(670, 31)
        Me.SourceText.TabIndex = 1
        '
        'DestinationText
        '
        Me.DestinationText.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Left) _
            Or AnchorStyles.Right), AnchorStyles)
        Me.DestinationText.Location = New Point(14, 159)
        Me.DestinationText.Name = "DestinationText"
        Me.DestinationText.Size = New Size(670, 31)
        Me.DestinationText.TabIndex = 5
        '
        'DestinationLabel
        '
        Me.DestinationLabel.Location = New Point(14, 129)
        Me.DestinationLabel.Name = "DestinationLabel"
        Me.DestinationLabel.Size = New Size(231, 30)
        Me.DestinationLabel.TabIndex = 4
        Me.DestinationLabel.Text = "Répertoire &destination :"
        '
        'TailleLabel
        '
        Me.TailleLabel.Location = New Point(14, 218)
        Me.TailleLabel.Name = "TailleLabel"
        Me.TailleLabel.Size = New Size(245, 29)
        Me.TailleLabel.TabIndex = 7
        Me.TailleLabel.Text = "&Taille grand coté (pixels) :"
        '
        'TailleText
        '
        Me.TailleText.Location = New Point(266, 210)
        Me.TailleText.Name = "TailleText"
        Me.TailleText.Size = New Size(101, 31)
        Me.TailleText.TabIndex = 8
        Me.TailleText.Text = "2500"
        '
        'LookupSourceButton
        '
        Me.LookupSourceButton.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles)
        Me.LookupSourceButton.Location = New Point(698, 44)
        Me.LookupSourceButton.Name = "LookupSourceButton"
        Me.LookupSourceButton.Size = New Size(43, 43)
        Me.LookupSourceButton.TabIndex = 2
        Me.LookupSourceButton.Text = "..."
        '
        'LookupDestinationButton
        '
        Me.LookupDestinationButton.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles)
        Me.LookupDestinationButton.Location = New Point(698, 159)
        Me.LookupDestinationButton.Name = "LookupDestinationButton"
        Me.LookupDestinationButton.Size = New Size(43, 42)
        Me.LookupDestinationButton.TabIndex = 6
        Me.LookupDestinationButton.Text = "..."
        '
        'QualitéText
        '
        Me.QualitéText.Location = New Point(266, 284)
        Me.QualitéText.Name = "QualitéText"
        Me.QualitéText.Size = New Size(101, 31)
        Me.QualitéText.TabIndex = 10
        '
        'QualitéLabel
        '
        Me.QualitéLabel.AutoSize = True
        Me.QualitéLabel.Location = New Point(14, 292)
        Me.QualitéLabel.Name = "QualitéLabel"
        Me.QualitéLabel.Size = New Size(181, 25)
        Me.QualitéLabel.TabIndex = 9
        Me.QualitéLabel.Text = "&Qualité JPEG (0-100) :"
        '
        'QualitéTrackBar
        '
        Me.QualitéTrackBar.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Left) _
            Or AnchorStyles.Right), AnchorStyles)
        Me.QualitéTrackBar.Location = New Point(389, 270)
        Me.QualitéTrackBar.Maximum = 100
        Me.QualitéTrackBar.Name = "QualitéTrackBar"
        Me.QualitéTrackBar.Size = New Size(561, 69)
        Me.QualitéTrackBar.TabIndex = 11
        Me.QualitéTrackBar.TickFrequency = 5
        Me.QualitéTrackBar.TickStyle = TickStyle.TopLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New Point(389, 233)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New Size(57, 25)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Faible"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New Point(777, 233)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New Size(156, 25)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Sans compression"
        '
        'RécursifCheckBox
        '
        Me.RécursifCheckBox.AutoSize = True
        Me.RécursifCheckBox.Location = New Point(20, 85)
        Me.RécursifCheckBox.Name = "RécursifCheckBox"
        Me.RécursifCheckBox.Size = New Size(230, 29)
        Me.RécursifCheckBox.TabIndex = 3
        Me.RécursifCheckBox.Text = "Inclu&re les sous-dossiers"
        Me.RécursifCheckBox.UseVisualStyleBackColor = True
        '
        'VignettesForm
        '
        Me.AcceptButton = Me.GénèreButton
        Me.AutoScaleBaseSize = New Size(9, 24)
        Me.ClientSize = New Size(956, 706)
        Me.Controls.Add(Me.RécursifCheckBox)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.QualitéTrackBar)
        Me.Controls.Add(Me.QualitéText)
        Me.Controls.Add(Me.QualitéLabel)
        Me.Controls.Add(Me.LookupDestinationButton)
        Me.Controls.Add(Me.LookupSourceButton)
        Me.Controls.Add(Me.TailleText)
        Me.Controls.Add(Me.TailleLabel)
        Me.Controls.Add(Me.DestinationText)
        Me.Controls.Add(Me.DestinationLabel)
        Me.Controls.Add(Me.SourceText)
        Me.Controls.Add(Me.SourceLabel)
        Me.Controls.Add(Me.TraceList)
        Me.Controls.Add(Me.GénèreButton)
        Me.Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Me.Name = "VignettesForm"
        Me.Text = "Retaille d'images / Génération de vignettes"
        CType(Me.QualitéTrackBar, ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub GénèreButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles GénèreButton.Click
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

    Sub Génération(ByVal sSourcePath As String, ByVal sDestinationPath As String)
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


    Sub GénèreVignette(ByVal sSourcePath As String, ByVal sDestinationPath As String, ByVal sNomfic As String)
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
        eps.Param(0) = New EncoderParameter(Encoder.Quality, CLng(QualitéText.Text))
        Dim ici As ImageCodecInfo = GetEncoderInfo("image/jpeg")

        ' Et on enregistre
        imgOutput.Save(sPathVignette, ici, eps)

        Trace(sNomfic)
    End Sub


    Sub Trace(ByVal sMsg As String)
        TraceList.Items.Add(sMsg)
        TraceList.SelectedIndex = TraceList.Items.Count - 1
        TraceList.Refresh()
    End Sub

    Private Sub LookupSourceButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LookupSourceButton.Click
        FolderBrowser.SelectedPath = SourceText.Text
        FolderBrowser.ShowNewFolderButton = False
        FolderBrowser.Description = "Sélectionnez le dossier contenant les images source :"
        If FolderBrowser.ShowDialog(Me) = DialogResult.OK Then
            SourceText.Text = FolderBrowser.SelectedPath
            SourceText.SelectionStart = 0
            SourceText.SelectionLength = 999
        End If
    End Sub

    Private Sub LookupDestinationButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles LookupDestinationButton.Click
        FolderBrowser.SelectedPath = DestinationText.Text
        FolderBrowser.ShowNewFolderButton = True
        FolderBrowser.Description = "Sélectionnez le dossier de destination pour les vignettes :"
        If FolderBrowser.ShowDialog(Me) = DialogResult.OK Then
            DestinationText.Text = FolderBrowser.SelectedPath
            DestinationText.SelectionStart = 0
            DestinationText.SelectionLength = 999
        End If
    End Sub

    Private Shared Function GetEncoderInfo(ByVal mimeType As String) As ImageCodecInfo
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

    Private Sub QualitéText_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles QualitéText.TextChanged
        QualitéTrackBar.Value = Val(QualitéText.Text)
    End Sub

    Private Sub QualitéText_Scroll(ByVal sender As Object, ByVal e As EventArgs) Handles QualitéTrackBar.Scroll
        QualitéText.Text = Format(QualitéTrackBar.Value)
    End Sub

    Private Sub VignettesForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        QualitéText.Text = "90"
        ' About command in System menu
        SubclassedSystemMenu = New SubclassedSystemMenu(Me.Handle.ToInt32, "&À propos de...")
    End Sub

    Private Sub SourceText_GotFocus(ByVal sender As Object, ByVal e As EventArgs) Handles SourceText.GotFocus
        SourceText.SelectionStart = 0
        SourceText.SelectionLength = 999
    End Sub

    Private Sub DestinationText_GotFocus(ByVal sender As Object, ByVal e As EventArgs) Handles DestinationText.GotFocus
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

    Private Sub SourceText_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles SourceText.TextChanged
        If My.Computer.FileSystem.DirectoryExists(SourceText.Text) Then
            If DestinationText.Text = "" And My.Computer.FileSystem.DirectoryExists(SourceText.Text & "R") Then
                DestinationText.Text = SourceText.Text & "R"
            End If
        End If
    End Sub

End Class

