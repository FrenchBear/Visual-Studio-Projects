' frmRetailleImages
' Application de redimensionnement d'images en VB.Net
' PV Juillet 2003
' 2003-07-30    PV  Contrôle de la qualité
' 2006-10-01    PV  VS 2005
' 2007-05/18    PV  About... in system menu
' 2007-05-21    PV  Les images plus petites gardent leur taille; option récursive
' 2009-10-15    PV  VS 2008 et ajout suffixe R automatiquement
' 2012-02-25	PV  VS2010; .Net Framework Client Profile 4.0
' 2021-09-19    PV  VS2022, Net6

Option Explicit On
Option Compare Text
Imports System.Drawing.Imaging

Public Class VignettesForm
    Inherits System.Windows.Forms.Form

    Dim m_iGrandCote As Integer
    Friend WithEvents RécursifCheckBox As System.Windows.Forms.CheckBox

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
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requis par le Concepteur Windows Form
    Private ReadOnly components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée en utilisant le Concepteur Windows Form.  
    'Ne la modifiez pas en utilisant l'éditeur de code.
    Friend WithEvents GénèreButton As System.Windows.Forms.Button
    Friend WithEvents TraceList As System.Windows.Forms.ListBox
    Friend WithEvents SourceLabel As System.Windows.Forms.Label
    Friend WithEvents SourceText As System.Windows.Forms.TextBox
    Friend WithEvents DestinationText As System.Windows.Forms.TextBox
    Friend WithEvents DestinationLabel As System.Windows.Forms.Label
    Friend WithEvents TailleLabel As System.Windows.Forms.Label
    Friend WithEvents TailleText As System.Windows.Forms.TextBox
    Friend WithEvents LookupSourceButton As System.Windows.Forms.Button
    Friend WithEvents LookupDestinationButton As System.Windows.Forms.Button
    Friend WithEvents FolderBrowser As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents QualitéText As System.Windows.Forms.TextBox
    Friend WithEvents QualitéLabel As System.Windows.Forms.Label
    Friend WithEvents QualitéTrackBar As System.Windows.Forms.TrackBar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(VignettesForm))
        Me.GénèreButton = New System.Windows.Forms.Button
        Me.TraceList = New System.Windows.Forms.ListBox
        Me.SourceLabel = New System.Windows.Forms.Label
        Me.SourceText = New System.Windows.Forms.TextBox
        Me.DestinationText = New System.Windows.Forms.TextBox
        Me.DestinationLabel = New System.Windows.Forms.Label
        Me.TailleLabel = New System.Windows.Forms.Label
        Me.TailleText = New System.Windows.Forms.TextBox
        Me.LookupSourceButton = New System.Windows.Forms.Button
        Me.LookupDestinationButton = New System.Windows.Forms.Button
        Me.FolderBrowser = New System.Windows.Forms.FolderBrowserDialog
        Me.QualitéText = New System.Windows.Forms.TextBox
        Me.QualitéLabel = New System.Windows.Forms.Label
        Me.QualitéTrackBar = New System.Windows.Forms.TrackBar
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.RécursifCheckBox = New System.Windows.Forms.CheckBox
        CType(Me.QualitéTrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnGénère
        '
        Me.GénèreButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GénèreButton.Location = New System.Drawing.Point(315, 8)
        Me.GénèreButton.Name = "btnGénère"
        Me.GénèreButton.Size = New System.Drawing.Size(104, 32)
        Me.GénèreButton.TabIndex = 15
        Me.GénèreButton.Text = "&Génère"
        '
        'lstTrace
        '
        Me.TraceList.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TraceList.Location = New System.Drawing.Point(8, 198)
        Me.TraceList.Name = "lstTrace"
        Me.TraceList.Size = New System.Drawing.Size(411, 225)
        Me.TraceList.TabIndex = 12
        '
        'lblSource
        '
        Me.SourceLabel.Location = New System.Drawing.Point(8, 8)
        Me.SourceLabel.Name = "lblSource"
        Me.SourceLabel.Size = New System.Drawing.Size(100, 16)
        Me.SourceLabel.TabIndex = 0
        Me.SourceLabel.Text = "Répertoire &source :"
        '
        'txtSource
        '
        Me.SourceText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SourceText.Location = New System.Drawing.Point(8, 24)
        Me.SourceText.Name = "txtSource"
        Me.SourceText.Size = New System.Drawing.Size(268, 20)
        Me.SourceText.TabIndex = 1
        '
        'txtDestination
        '
        Me.DestinationText.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DestinationText.Location = New System.Drawing.Point(8, 86)
        Me.DestinationText.Name = "txtDestination"
        Me.DestinationText.Size = New System.Drawing.Size(268, 20)
        Me.DestinationText.TabIndex = 5
        '
        'lblDestination
        '
        Me.DestinationLabel.Location = New System.Drawing.Point(8, 70)
        Me.DestinationLabel.Name = "lblDestination"
        Me.DestinationLabel.Size = New System.Drawing.Size(128, 16)
        Me.DestinationLabel.TabIndex = 4
        Me.DestinationLabel.Text = "Répertoire &destination :"
        '
        'lblTaille
        '
        Me.TailleLabel.Location = New System.Drawing.Point(8, 118)
        Me.TailleLabel.Name = "lblTaille"
        Me.TailleLabel.Size = New System.Drawing.Size(136, 16)
        Me.TailleLabel.TabIndex = 7
        Me.TailleLabel.Text = "&Taille grand coté (pixels) :"
        '
        'txtTaille
        '
        Me.TailleText.Location = New System.Drawing.Point(148, 114)
        Me.TailleText.Name = "txtTaille"
        Me.TailleText.Size = New System.Drawing.Size(56, 20)
        Me.TailleText.TabIndex = 8
        Me.TailleText.Text = "2500"
        '
        'btnLookupSource
        '
        Me.LookupSourceButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LookupSourceButton.Location = New System.Drawing.Point(284, 24)
        Me.LookupSourceButton.Name = "btnLookupSource"
        Me.LookupSourceButton.Size = New System.Drawing.Size(24, 23)
        Me.LookupSourceButton.TabIndex = 2
        Me.LookupSourceButton.Text = "..."
        '
        'btnLookupDestination
        '
        Me.LookupDestinationButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LookupDestinationButton.Location = New System.Drawing.Point(284, 86)
        Me.LookupDestinationButton.Name = "btnLookupDestination"
        Me.LookupDestinationButton.Size = New System.Drawing.Size(24, 23)
        Me.LookupDestinationButton.TabIndex = 6
        Me.LookupDestinationButton.Text = "..."
        '
        'txtQualité
        '
        Me.QualitéText.Location = New System.Drawing.Point(148, 154)
        Me.QualitéText.Name = "txtQualité"
        Me.QualitéText.Size = New System.Drawing.Size(56, 20)
        Me.QualitéText.TabIndex = 10
        '
        'lblQualité
        '
        Me.QualitéLabel.AutoSize = True
        Me.QualitéLabel.Location = New System.Drawing.Point(8, 158)
        Me.QualitéLabel.Name = "lblQualité"
        Me.QualitéLabel.Size = New System.Drawing.Size(112, 13)
        Me.QualitéLabel.TabIndex = 9
        Me.QualitéLabel.Text = "&Qualité JPEG (0-100) :"
        '
        'tbQualité
        '
        Me.QualitéTrackBar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.QualitéTrackBar.Location = New System.Drawing.Point(216, 146)
        Me.QualitéTrackBar.Maximum = 100
        Me.QualitéTrackBar.Name = "tbQualité"
        Me.QualitéTrackBar.Size = New System.Drawing.Size(208, 45)
        Me.QualitéTrackBar.TabIndex = 11
        Me.QualitéTrackBar.TickFrequency = 5
        Me.QualitéTrackBar.TickStyle = System.Windows.Forms.TickStyle.TopLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(216, 126)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Faible"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(328, 126)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Sans compression"
        '
        'chkRécursif
        '
        Me.RécursifCheckBox.AutoSize = True
        Me.RécursifCheckBox.Location = New System.Drawing.Point(11, 46)
        Me.RécursifCheckBox.Name = "chkRécursif"
        Me.RécursifCheckBox.Size = New System.Drawing.Size(140, 17)
        Me.RécursifCheckBox.TabIndex = 3
        Me.RécursifCheckBox.Text = "Inclu&re les sous-dossiers"
        Me.RécursifCheckBox.UseVisualStyleBackColor = True
        '
        'frmVignettes
        '
        Me.AcceptButton = Me.GénèreButton
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(427, 431)
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
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmVignettes"
        Me.Text = "Retaille d'images / Génération de vignettes"
        CType(Me.QualitéTrackBar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub GénèreButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles GénèreButton.Click
        Dim m_sSourcePath As String
        Dim m_sDestinationPath As String

        If Not System.IO.Directory.Exists(SourceText.Text) Then
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

        Dim dir As System.IO.DirectoryInfo
        dir = New System.IO.DirectoryInfo(sSourcePath)
        Dim fic As System.IO.FileInfo

        For Each fic In dir.GetFiles("*.jpg")
            Try
                GénèreVignette(sSourcePath, sDestinationPath, fic.Name)
                System.GC.Collect()
                System.GC.WaitForPendingFinalizers()
                System.Threading.Thread.Sleep(0)
            Catch
            End Try
        Next

        If RécursifCheckBox.Checked Then
            Dim subdir As System.IO.DirectoryInfo
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

    Private Sub LookupSourceButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LookupSourceButton.Click
        FolderBrowser.SelectedPath = SourceText.Text
        FolderBrowser.ShowNewFolderButton = False
        FolderBrowser.Description = "Sélectionnez le dossier contenant les images source :"
        If FolderBrowser.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            SourceText.Text = FolderBrowser.SelectedPath
            SourceText.SelectionStart = 0
            SourceText.SelectionLength = 999
        End If
    End Sub

    Private Sub LookupDestinationButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LookupDestinationButton.Click
        FolderBrowser.SelectedPath = DestinationText.Text
        FolderBrowser.ShowNewFolderButton = True
        FolderBrowser.Description = "Sélectionnez le dossier de destination pour les vignettes :"
        If FolderBrowser.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
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

    Private Sub QualitéText_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles QualitéText.TextChanged
        QualitéTrackBar.Value = Val(QualitéText.Text)
    End Sub

    Private Sub QualitéText_Scroll(ByVal sender As Object, ByVal e As System.EventArgs) Handles QualitéTrackBar.Scroll
        QualitéText.Text = Format(QualitéTrackBar.Value)
    End Sub

    Private Sub VignettesForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        QualitéText.Text = "90"
        ' About command in System menu
        SubclassedSystemMenu = New SubclassedSystemMenu(Me.Handle.ToInt32, "&A propos de...")
    End Sub

    Private Sub SourceText_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles SourceText.GotFocus
        SourceText.SelectionStart = 0
        SourceText.SelectionLength = 999
    End Sub

    Private Sub DestinationText_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DestinationText.GotFocus
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

    Private Sub SourceText_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles SourceText.TextChanged
        If My.Computer.FileSystem.DirectoryExists(SourceText.Text) Then
            If DestinationText.Text = "" And My.Computer.FileSystem.DirectoryExists(SourceText.Text & "R") Then
                DestinationText.Text = SourceText.Text & "R"
            End If
        End If
    End Sub

End Class
