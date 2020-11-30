' frmPicResize
' Pic resize utility in VB.Net
' PV July 2003
' 2003-07-30    PV  Quality Control
' 2005-12-04    PV  English Version
' 2006-10-01    PV  VS2005
' 2012-02-25	PV  VS2010; .Net Framework Client Profile 4.0

Imports System.Drawing
Imports System.Drawing.Imaging

Public Class frmPicResize
    Inherits System.Windows.Forms.Form

    Dim m_iGrandCote As Integer
    Dim m_sSourcePath As String
    Dim m_sDestinationPath As String

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
    Friend WithEvents lstTrace As System.Windows.Forms.ListBox
    Friend WithEvents lblSource As System.Windows.Forms.Label
    Friend WithEvents txtSource As System.Windows.Forms.TextBox
    Friend WithEvents txtDestination As System.Windows.Forms.TextBox
    Friend WithEvents lblDestination As System.Windows.Forms.Label
    Friend WithEvents btnLookupSource As System.Windows.Forms.Button
    Friend WithEvents btnLookupDestination As System.Windows.Forms.Button
    Friend WithEvents FolderBrowser As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblQuality As System.Windows.Forms.Label
    Friend WithEvents btnGo As System.Windows.Forms.Button
    Friend WithEvents lblSize As System.Windows.Forms.Label
    Friend WithEvents txtQuality As System.Windows.Forms.TextBox
    Friend WithEvents txtSize As System.Windows.Forms.TextBox
    Friend WithEvents tbQuality As System.Windows.Forms.TrackBar
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(frmPicResize))
        Me.btnGo = New System.Windows.Forms.Button
        Me.lstTrace = New System.Windows.Forms.ListBox
        Me.lblSource = New System.Windows.Forms.Label
        Me.txtSource = New System.Windows.Forms.TextBox
        Me.txtDestination = New System.Windows.Forms.TextBox
        Me.lblDestination = New System.Windows.Forms.Label
        Me.lblSize = New System.Windows.Forms.Label
        Me.txtSize = New System.Windows.Forms.TextBox
        Me.btnLookupSource = New System.Windows.Forms.Button
        Me.btnLookupDestination = New System.Windows.Forms.Button
        Me.FolderBrowser = New System.Windows.Forms.FolderBrowserDialog
        Me.txtQuality = New System.Windows.Forms.TextBox
        Me.lblQuality = New System.Windows.Forms.Label
        Me.tbQuality = New System.Windows.Forms.TrackBar
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        CType(Me.tbQuality, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnGo
        '
        Me.btnGo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGo.Location = New System.Drawing.Point(328, 8)
        Me.btnGo.Name = "btnGo"
        Me.btnGo.Size = New System.Drawing.Size(104, 32)
        Me.btnGo.TabIndex = 12
        Me.btnGo.Text = "Go"
        '
        'lstTrace
        '
        Me.lstTrace.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lstTrace.Location = New System.Drawing.Point(8, 172)
        Me.lstTrace.Name = "lstTrace"
        Me.lstTrace.Size = New System.Drawing.Size(312, 225)
        Me.lstTrace.TabIndex = 11
        '
        'lblSource
        '
        Me.lblSource.Location = New System.Drawing.Point(8, 8)
        Me.lblSource.Name = "lblSource"
        Me.lblSource.Size = New System.Drawing.Size(100, 16)
        Me.lblSource.TabIndex = 0
        Me.lblSource.Text = "Source Folder :"
        '
        'txtSource
        '
        Me.txtSource.HideSelection = False
        Me.txtSource.Location = New System.Drawing.Point(8, 24)
        Me.txtSource.Name = "txtSource"
        Me.txtSource.Size = New System.Drawing.Size(280, 20)
        Me.txtSource.TabIndex = 1
        Me.txtSource.Text = ""
        '
        'txtDestination
        '
        Me.txtDestination.HideSelection = False
        Me.txtDestination.Location = New System.Drawing.Point(8, 64)
        Me.txtDestination.Name = "txtDestination"
        Me.txtDestination.Size = New System.Drawing.Size(280, 20)
        Me.txtDestination.TabIndex = 4
        Me.txtDestination.Text = ""
        '
        'lblDestination
        '
        Me.lblDestination.Location = New System.Drawing.Point(8, 48)
        Me.lblDestination.Name = "lblDestination"
        Me.lblDestination.Size = New System.Drawing.Size(128, 16)
        Me.lblDestination.TabIndex = 3
        Me.lblDestination.Text = "Target Folder :"
        '
        'lblSize
        '
        Me.lblSize.Location = New System.Drawing.Point(8, 96)
        Me.lblSize.Name = "lblSize"
        Me.lblSize.Size = New System.Drawing.Size(136, 16)
        Me.lblSize.TabIndex = 6
        Me.lblSize.Text = "Large dimension (pixels) :"
        '
        'txtSize
        '
        Me.txtSize.Location = New System.Drawing.Point(148, 92)
        Me.txtSize.Name = "txtSize"
        Me.txtSize.Size = New System.Drawing.Size(56, 20)
        Me.txtSize.TabIndex = 7
        Me.txtSize.Text = ""
        '
        'btnLookupSource
        '
        Me.btnLookupSource.Location = New System.Drawing.Point(296, 24)
        Me.btnLookupSource.Name = "btnLookupSource"
        Me.btnLookupSource.Size = New System.Drawing.Size(24, 23)
        Me.btnLookupSource.TabIndex = 2
        Me.btnLookupSource.Text = "..."
        '
        'btnLookupDestination
        '
        Me.btnLookupDestination.Location = New System.Drawing.Point(296, 64)
        Me.btnLookupDestination.Name = "btnLookupDestination"
        Me.btnLookupDestination.Size = New System.Drawing.Size(24, 23)
        Me.btnLookupDestination.TabIndex = 5
        Me.btnLookupDestination.Text = "..."
        '
        'txtQuality
        '
        Me.txtQuality.Location = New System.Drawing.Point(148, 132)
        Me.txtQuality.Name = "txtQuality"
        Me.txtQuality.Size = New System.Drawing.Size(56, 20)
        Me.txtQuality.TabIndex = 9
        Me.txtQuality.Text = ""
        '
        'lblQuality
        '
        Me.lblQuality.AutoSize = True
        Me.lblQuality.Location = New System.Drawing.Point(8, 136)
        Me.lblQuality.Name = "lblQuality"
        Me.lblQuality.Size = New System.Drawing.Size(118, 16)
        Me.lblQuality.TabIndex = 8
        Me.lblQuality.Text = "JPEG Quality (0-100) :"
        '
        'tbQuality
        '
        Me.tbQuality.Location = New System.Drawing.Point(216, 124)
        Me.tbQuality.Maximum = 100
        Me.tbQuality.Name = "tbQuality"
        Me.tbQuality.Size = New System.Drawing.Size(220, 45)
        Me.tbQuality.TabIndex = 10
        Me.tbQuality.TickFrequency = 5
        Me.tbQuality.TickStyle = System.Windows.Forms.TickStyle.TopLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(216, 104)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(63, 16)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Low Quality"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(368, 104)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 16)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "High Quality"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'frmPicResize
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(440, 414)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tbQuality)
        Me.Controls.Add(Me.txtQuality)
        Me.Controls.Add(Me.lblQuality)
        Me.Controls.Add(Me.btnLookupDestination)
        Me.Controls.Add(Me.btnLookupSource)
        Me.Controls.Add(Me.txtSize)
        Me.Controls.Add(Me.lblSize)
        Me.Controls.Add(Me.txtDestination)
        Me.Controls.Add(Me.lblDestination)
        Me.Controls.Add(Me.txtSource)
        Me.Controls.Add(Me.lblSource)
        Me.Controls.Add(Me.lstTrace)
        Me.Controls.Add(Me.btnGo)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmPicResize"
        Me.Text = "Picture Resize Tool"
        CType(Me.tbQuality, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGo.Click

        If Not System.IO.Directory.Exists(txtSource.Text) Then
            MsgBox("Répertoire source inexistant ou inaccessible.", MsgBoxStyle.Exclamation)
            txtSource.Focus()
            Exit Sub
        End If

        If Not System.IO.Directory.Exists(txtDestination.Text) Then
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

        Dim dir As System.IO.DirectoryInfo
        dir = New System.IO.DirectoryInfo(txtSource.Text)
        Dim fic As System.IO.FileInfo

        For Each fic In dir.GetFiles("*.jpg")
            Try
                GénèreVignette(fic.Name)
                System.GC.Collect()
                System.Threading.Thread.Sleep(0)
            Catch
            End Try
        Next

        Trace("Fin de la génération")
        btnGo.Enabled = True
    End Sub


    Sub GénèreVignette(ByVal sNomfic As String)
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
        Dim eps As EncoderParameters = New EncoderParameters(1)
        eps.Param(0) = New EncoderParameter(Encoder.Quality, CLng(txtQuality.Text))
        Dim ici As ImageCodecInfo = GetEncoderInfo("image/jpeg")

        ' Et on enregistre
        imgOutput.Save(sPathVignette, ici, eps)

        Trace(sNomfic)
    End Sub


    Sub Trace(ByVal sMsg As String)
        lstTrace.Items.Add(sMsg)
        lstTrace.SelectedIndex = lstTrace.Items.Count - 1
        lstTrace.Refresh()
    End Sub

    Private Sub btnLookupSource_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLookupSource.Click
        FolderBrowser.SelectedPath = txtSource.Text
        FolderBrowser.ShowNewFolderButton = False
        FolderBrowser.Description = "Sélectionnez le dossier contenant les images source :"
        If FolderBrowser.ShowDialog(Me) = DialogResult.OK Then
            txtSource.Text = FolderBrowser.SelectedPath
            txtSource.SelectionStart = 0
            txtSource.SelectionLength = 999
        End If
    End Sub

    Private Sub btnLookupDestination_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLookupDestination.Click
        FolderBrowser.SelectedPath = txtDestination.Text
        FolderBrowser.ShowNewFolderButton = True
        FolderBrowser.Description = "Sélectionnez le dossier de destination pour les vignettes :"
        If FolderBrowser.ShowDialog(Me) = DialogResult.OK Then
            txtDestination.Text = FolderBrowser.SelectedPath
            txtDestination.SelectionStart = 0
            txtDestination.SelectionLength = 999
        End If
    End Sub

    Private Function GetEncoderInfo(ByVal mimeType As String) As ImageCodecInfo
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

    Private Sub txtQuality_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQuality.TextChanged
        tbQuality.Value = Val(txtQuality.Text)
    End Sub

    Private Sub tbQuality_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tbQuality.Scroll
        txtQuality.Text = Format(tbQuality.Value)
    End Sub

    Private Sub frmVignettes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtQuality.Text = "90"
    End Sub

End Class
