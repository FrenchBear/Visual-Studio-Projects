' frmPicResize
' Pic resize utility in VB.Net
' PV July 2003
'
' 2003-07-30 	PV		Quality Control
' 2005-12-04 	PV		English Version
' 2006-10-01 	PV		VS2005
' 2012-02-25	PV		VS2010; .Net Framework Client Profile 4.0
' 2021-09-19 	PV		VS2022, Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9

Imports System.ComponentModel
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Resources
Imports System.Threading

#Disable Warning IDE1006 ' Naming Styles

Public Class frmPicResize
    Inherits Form

    Private m_iGrandCote As Integer
    Private m_sSourcePath As String
    Private m_sDestinationPath As String

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
    Friend WithEvents lstTrace As ListBox

    Friend WithEvents lblSource As Label
    Friend WithEvents txtSource As TextBox
    Friend WithEvents txtDestination As TextBox
    Friend WithEvents lblDestination As Label
    Friend WithEvents btnLookupSource As Button
    Friend WithEvents btnLookupDestination As Button
    Friend WithEvents FolderBrowser As FolderBrowserDialog
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents lblQuality As Label
    Friend WithEvents btnGo As Button
    Friend WithEvents lblSize As Label
    Friend WithEvents txtQuality As TextBox
    Friend WithEvents txtSize As TextBox
    Friend WithEvents tbQuality As TrackBar

    <DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As New ResourceManager(GetType(frmPicResize))
        btnGo = New Button
        lstTrace = New ListBox
        lblSource = New Label
        txtSource = New TextBox
        txtDestination = New TextBox
        lblDestination = New Label
        lblSize = New Label
        txtSize = New TextBox
        btnLookupSource = New Button
        btnLookupDestination = New Button
        FolderBrowser = New FolderBrowserDialog
        txtQuality = New TextBox
        lblQuality = New Label
        tbQuality = New TrackBar
        Label1 = New Label
        Label2 = New Label
        CType(tbQuality, ISupportInitialize).BeginInit()
        SuspendLayout()
        '
        'btnGo
        '
        btnGo.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnGo.Location = New Point(328, 8)
        btnGo.Name = "btnGo"
        btnGo.Size = New Size(104, 32)
        btnGo.TabIndex = 12
        btnGo.Text = "Go"
        '
        'lstTrace
        '
        lstTrace.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom _
                    Or AnchorStyles.Left _
                    Or AnchorStyles.Right
        lstTrace.Location = New Point(8, 172)
        lstTrace.Name = "lstTrace"
        lstTrace.Size = New Size(312, 225)
        lstTrace.TabIndex = 11
        '
        'lblSource
        '
        lblSource.Location = New Point(8, 8)
        lblSource.Name = "lblSource"
        lblSource.Size = New Size(100, 16)
        lblSource.TabIndex = 0
        lblSource.Text = "Source Folder :"
        '
        'txtSource
        '
        txtSource.HideSelection = False
        txtSource.Location = New Point(8, 24)
        txtSource.Name = "txtSource"
        txtSource.Size = New Size(280, 20)
        txtSource.TabIndex = 1
        txtSource.Text = ""
        '
        'txtDestination
        '
        txtDestination.HideSelection = False
        txtDestination.Location = New Point(8, 64)
        txtDestination.Name = "txtDestination"
        txtDestination.Size = New Size(280, 20)
        txtDestination.TabIndex = 4
        txtDestination.Text = ""
        '
        'lblDestination
        '
        lblDestination.Location = New Point(8, 48)
        lblDestination.Name = "lblDestination"
        lblDestination.Size = New Size(128, 16)
        lblDestination.TabIndex = 3
        lblDestination.Text = "Target Folder :"
        '
        'lblSize
        '
        lblSize.Location = New Point(8, 96)
        lblSize.Name = "lblSize"
        lblSize.Size = New Size(136, 16)
        lblSize.TabIndex = 6
        lblSize.Text = "Large dimension (pixels) :"
        '
        'txtSize
        '
        txtSize.Location = New Point(148, 92)
        txtSize.Name = "txtSize"
        txtSize.Size = New Size(56, 20)
        txtSize.TabIndex = 7
        txtSize.Text = ""
        '
        'btnLookupSource
        '
        btnLookupSource.Location = New Point(296, 24)
        btnLookupSource.Name = "btnLookupSource"
        btnLookupSource.Size = New Size(24, 23)
        btnLookupSource.TabIndex = 2
        btnLookupSource.Text = "..."
        '
        'btnLookupDestination
        '
        btnLookupDestination.Location = New Point(296, 64)
        btnLookupDestination.Name = "btnLookupDestination"
        btnLookupDestination.Size = New Size(24, 23)
        btnLookupDestination.TabIndex = 5
        btnLookupDestination.Text = "..."
        '
        'txtQuality
        '
        txtQuality.Location = New Point(148, 132)
        txtQuality.Name = "txtQuality"
        txtQuality.Size = New Size(56, 20)
        txtQuality.TabIndex = 9
        txtQuality.Text = ""
        '
        'lblQuality
        '
        lblQuality.AutoSize = True
        lblQuality.Location = New Point(8, 136)
        lblQuality.Name = "lblQuality"
        lblQuality.Size = New Size(118, 16)
        lblQuality.TabIndex = 8
        lblQuality.Text = "JPEG Quality (0-100) :"
        '
        'tbQuality
        '
        tbQuality.Location = New Point(216, 124)
        tbQuality.Maximum = 100
        tbQuality.Name = "tbQuality"
        tbQuality.Size = New Size(220, 45)
        tbQuality.TabIndex = 10
        tbQuality.TickFrequency = 5
        tbQuality.TickStyle = TickStyle.TopLeft
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Location = New Point(216, 104)
        Label1.Name = "Label1"
        Label1.Size = New Size(63, 16)
        Label1.TabIndex = 13
        Label1.Text = "Low Quality"
        '
        'Label2
        '
        Label2.AutoSize = True
        Label2.Location = New Point(368, 104)
        Label2.Name = "Label2"
        Label2.Size = New Size(66, 16)
        Label2.TabIndex = 14
        Label2.Text = "High Quality"
        Label2.TextAlign = ContentAlignment.TopRight
        '
        'frmPicResize
        '
        AutoScaleBaseSize = New Size(5, 13)
        ClientSize = New Size(440, 414)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(tbQuality)
        Controls.Add(txtQuality)
        Controls.Add(lblQuality)
        Controls.Add(btnLookupDestination)
        Controls.Add(btnLookupSource)
        Controls.Add(txtSize)
        Controls.Add(lblSize)
        Controls.Add(txtDestination)
        Controls.Add(lblDestination)
        Controls.Add(txtSource)
        Controls.Add(lblSource)
        Controls.Add(lstTrace)
        Controls.Add(btnGo)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "frmPicResize"
        Text = "Picture Resize Tool"
        CType(tbQuality, ISupportInitialize).EndInit()
        ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnGo_Click(sender As Object, e As EventArgs) Handles btnGo.Click

        If Not Directory.Exists(txtSource.Text) Then
            MsgBox("Répertoire source inexistant ou inaccessible.", MsgBoxStyle.Exclamation)
            txtSource.Focus()
            Exit Sub
        End If

        If Not Directory.Exists(txtDestination.Text) Then
            MsgBox("Répertoire destination inexistant ou inaccessible.", MsgBoxStyle.Exclamation)
            txtDestination.Focus()
            Exit Sub
        End If

        m_iGrandCote = Val(txtSize.Text)
        If m_iGrandCote < 50 Or m_iGrandCote > 2500 Then
            MsgBox("Taille du grand coté invalide (doit être comprise entre 50 et 2500)", MsgBoxStyle.Exclamation)
            txtSize.Focus()
            Exit Sub
        End If

        m_sSourcePath = txtSource.Text
        If Microsoft.VisualBasic.Right(m_sSourcePath, 1) <> "\" Then m_sSourcePath &= "\"
        m_sDestinationPath = txtDestination.Text
        If Microsoft.VisualBasic.Right(m_sDestinationPath, 1) <> "\" Then m_sDestinationPath &= "\"

        If StrComp(m_sSourcePath, m_sDestinationPath, CompareMethod.Text) = 0 Then
            MsgBox("Les deux répertoires ne peuvent être identiques.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        btnGo.Enabled = False
        Trace("Début de la génération")

        Dim dir As DirectoryInfo
        dir = New DirectoryInfo(txtSource.Text)
        Dim fic As FileInfo

        For Each fic In dir.GetFiles("*.jpg")
            Try
                GénèreVignette(fic.Name)
                GC.Collect()
                Thread.Sleep(0)
            Catch
            End Try
        Next

        Trace("Fin de la génération")
        btnGo.Enabled = True
    End Sub

    Public Sub GénèreVignette(sNomfic As String)
        Dim sPathImg As String
        Dim sPathVignette As String

        sPathImg = m_sSourcePath & sNomfic
        sPathVignette = m_sDestinationPath & sNomfic

        Dim imgSource As Bitmap
        imgSource = Image.FromFile(sPathImg)

        Dim iNewWidth, iNewHeight As Integer
        If imgSource.Width > imgSource.Height Then
            iNewWidth = m_iGrandCote
            iNewHeight = m_iGrandCote / imgSource.Width * imgSource.Height
        Else
            iNewHeight = m_iGrandCote
            iNewWidth = m_iGrandCote / imgSource.Height * imgSource.Width
        End If

        Dim imgOutput As Bitmap

        ' Version compliquée avec DrawImage
        'imgOutput = New Bitmap(iNewWidth, iNewHeight, System.Drawing.Imaging.PixelFormat.Format32bppRgb)
        'Dim h As Graphics = Graphics.FromImage(imgOutput)
        'h.DrawImage(img, 0, 0, iNewWidth, iNewHeight)

        ' Version simplifiée avec le constructeur de Bitmap qui remet à l'échelle
        imgOutput = New Bitmap(imgSource, iNewWidth, iNewHeight)

        ' On contrôle la Quality
        Dim eps As New EncoderParameters(1)
        eps.Param(0) = New EncoderParameter(Encoder.Quality, txtQuality.Text)
        Dim ici As ImageCodecInfo = GetEncoderInfo("image/jpeg")

        ' Et on enregistre
        imgOutput.Save(sPathVignette, ici, eps)

        Trace(sNomfic)
    End Sub

    Public Sub Trace(sMsg As String)
        lstTrace.Items.Add(sMsg)
        lstTrace.SelectedIndex = lstTrace.Items.Count - 1
        lstTrace.Refresh()
    End Sub

    Private Sub btnLookupSource_Click(sender As Object, e As EventArgs) Handles btnLookupSource.Click
        FolderBrowser.SelectedPath = txtSource.Text
        FolderBrowser.ShowNewFolderButton = False
        FolderBrowser.Description = "Sélectionnez le dossier contenant les images source :"
        If FolderBrowser.ShowDialog(Me) = DialogResult.OK Then
            txtSource.Text = FolderBrowser.SelectedPath
            txtSource.SelectionStart = 0
            txtSource.SelectionLength = 999
        End If
    End Sub

    Private Sub btnLookupDestination_Click(sender As Object, e As EventArgs) Handles btnLookupDestination.Click
        FolderBrowser.SelectedPath = txtDestination.Text
        FolderBrowser.ShowNewFolderButton = True
        FolderBrowser.Description = "Sélectionnez le dossier de destination pour les vignettes :"
        If FolderBrowser.ShowDialog(Me) = DialogResult.OK Then
            txtDestination.Text = FolderBrowser.SelectedPath
            txtDestination.SelectionStart = 0
            txtDestination.SelectionLength = 999
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

    Private Sub txtQuality_TextChanged(sender As Object, e As EventArgs) Handles txtQuality.TextChanged
        tbQuality.Value = Val(txtQuality.Text)
    End Sub

    Private Sub tbQuality_Scroll(sender As Object, e As EventArgs) Handles tbQuality.Scroll
        txtQuality.Text = Format(tbQuality.Value)
    End Sub

    Private Sub frmVignettes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtQuality.Text = "90"
    End Sub

End Class
