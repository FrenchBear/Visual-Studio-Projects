' frmRetailleImages
' Application de redimensionnement d'images en VB.Net
' PV Juillet 2003
' 30/07/03 PV Contr�le de la Qualité
' 01/10/2006 PV VS 2005
' 05/18/2007 PV About... in system menu
' 21/05/2007 PV Les images plus petites gardent leur taille; option r�cursive
' 15/10/2009 PV VS 2008 et ajout suffixe R automatiquement

Option Explicit On
Option Compare Text

Imports System.Drawing.Imaging

#Disable Warning IDE1006 ' Naming Styles

Public Class frmVignettes
    Inherits Form

    Dim m_iGrandCote As Integer
    Friend WithEvents chkRécursif As CheckBox

    ''' <summary>About command in System menu</summary>
    Private WithEvents mobjSubclassedSystemMenu As SubclassedSystemMenu

#Region " Code g�n�r� par le Concepteur Windows Form "

    Public Sub New()
        MyBase.New()

        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        'Ajoutez une initialisation quelconque apr�s l'appel InitializeComponent()

    End Sub

    'La m�thode substitu�e Dispose du formulaire pour nettoyer la liste des composants.
    Protected Overloads Overrides Sub Dispose(disposing As Boolean)
        If disposing Then
            components?.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requis par le Concepteur Windows Form
    Private ReadOnly components As System.ComponentModel.IContainer

    'REMARQUE�: la Procédure suivante est requise par le Concepteur Windows Form
    'Elle peut �tre modifi�e en utilisant le Concepteur Windows Form.
    'Ne la modifiez pas en utilisant l'�diteur de code.
    Friend WithEvents btnGénère As Button

    Friend WithEvents lstTrace As ListBox
    Friend WithEvents lblSource As Label
    Friend WithEvents txtSource As TextBox
    Friend WithEvents txtDestination As TextBox
    Friend WithEvents lblDestination As Label
    Friend WithEvents lblTaille As Label
    Friend WithEvents txtTaille As TextBox
    Friend WithEvents btnLookupSource As Button
    Friend WithEvents btnLookupDestination As Button
    Friend WithEvents FolderBrowser As FolderBrowserDialog
    Friend WithEvents txtQualité As TextBox
    Friend WithEvents lblQualité As Label
    Friend WithEvents tbQualité As TrackBar
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label

    <DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As New ComponentModel.ComponentResourceManager(GetType(frmVignettes))
        Me.btnGénère = New Button
        Me.lstTrace = New ListBox
        Me.lblSource = New Label
        Me.txtSource = New TextBox
        Me.txtDestination = New TextBox
        Me.lblDestination = New Label
        Me.lblTaille = New Label
        Me.txtTaille = New TextBox
        Me.btnLookupSource = New Button
        Me.btnLookupDestination = New Button
        Me.FolderBrowser = New FolderBrowserDialog
        Me.txtQualité = New TextBox
        Me.lblQualité = New Label
        Me.tbQualité = New TrackBar
        Me.Label1 = New Label
        Me.Label2 = New Label
        Me.chkRécursif = New CheckBox
        CType(Me.tbQualité, ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnGénère
        '
        Me.btnGénère.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), AnchorStyles)
        Me.btnGénère.Location = New Point(315, 8)
        Me.btnGénère.Name = "btnGénère"
        Me.btnGénère.Size = New Size(104, 32)
        Me.btnGénère.TabIndex = 15
        Me.btnGénère.Text = "&Génère"
        '
        'lstTrace
        '
        Me.lstTrace.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), AnchorStyles)
        Me.lstTrace.Location = New Point(8, 198)
        Me.lstTrace.Name = "lstTrace"
        Me.lstTrace.Size = New Size(411, 225)
        Me.lstTrace.TabIndex = 12
        '
        'lblSource
        '
        Me.lblSource.Location = New Point(8, 8)
        Me.lblSource.Name = "lblSource"
        Me.lblSource.Size = New Size(100, 16)
        Me.lblSource.TabIndex = 0
        Me.lblSource.Text = "R�pertoire &source :"
        '
        'txtSource
        '
        Me.txtSource.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), AnchorStyles)
        Me.txtSource.Location = New Point(8, 24)
        Me.txtSource.Name = "txtSource"
        Me.txtSource.Size = New Size(268, 20)
        Me.txtSource.TabIndex = 1
        '
        'txtDestination
        '
        Me.txtDestination.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), AnchorStyles)
        Me.txtDestination.Location = New Point(8, 86)
        Me.txtDestination.Name = "txtDestination"
        Me.txtDestination.Size = New Size(268, 20)
        Me.txtDestination.TabIndex = 5
        '
        'lblDestination
        '
        Me.lblDestination.Location = New Point(8, 70)
        Me.lblDestination.Name = "lblDestination"
        Me.lblDestination.Size = New Size(128, 16)
        Me.lblDestination.TabIndex = 4
        Me.lblDestination.Text = "R�pertoire &destination :"
        '
        'lblTaille
        '
        Me.lblTaille.Location = New Point(8, 118)
        Me.lblTaille.Name = "lblTaille"
        Me.lblTaille.Size = New Size(136, 16)
        Me.lblTaille.TabIndex = 7
        Me.lblTaille.Text = "&Taille grand cot� (pixels) :"
        '
        'txtTaille
        '
        Me.txtTaille.Location = New Point(148, 114)
        Me.txtTaille.Name = "txtTaille"
        Me.txtTaille.Size = New Size(56, 20)
        Me.txtTaille.TabIndex = 8
        Me.txtTaille.Text = "2500"
        '
        'btnLookupSource
        '
        Me.btnLookupSource.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), AnchorStyles)
        Me.btnLookupSource.Location = New Point(284, 24)
        Me.btnLookupSource.Name = "btnLookupSource"
        Me.btnLookupSource.Size = New Size(24, 23)
        Me.btnLookupSource.TabIndex = 2
        Me.btnLookupSource.Text = "..."
        '
        'btnLookupDestination
        '
        Me.btnLookupDestination.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), AnchorStyles)
        Me.btnLookupDestination.Location = New Point(284, 86)
        Me.btnLookupDestination.Name = "btnLookupDestination"
        Me.btnLookupDestination.Size = New Size(24, 23)
        Me.btnLookupDestination.TabIndex = 6
        Me.btnLookupDestination.Text = "..."
        '
        'txtQualité
        '
        Me.txtQualité.Location = New Point(148, 154)
        Me.txtQualité.Name = "txtQualité"
        Me.txtQualité.Size = New Size(56, 20)
        Me.txtQualité.TabIndex = 10
        '
        'lblQualité
        '
        Me.lblQualité.AutoSize = True
        Me.lblQualité.Location = New Point(8, 158)
        Me.lblQualité.Name = "lblQualité"
        Me.lblQualité.Size = New Size(112, 13)
        Me.lblQualité.TabIndex = 9
        Me.lblQualité.Text = "&Qualité JPEG (0-100) :"
        '
        'tbQualité
        '
        Me.tbQualité.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), AnchorStyles)
        Me.tbQualité.Location = New Point(216, 146)
        Me.tbQualité.Maximum = 100
        Me.tbQualité.Name = "tbQualité"
        Me.tbQualité.Size = New Size(208, 45)
        Me.tbQualité.TabIndex = 11
        Me.tbQualité.TickFrequency = 5
        Me.tbQualité.TickStyle = System.Windows.Forms.TickStyle.TopLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New Point(216, 126)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New Size(35, 13)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Faible"
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New Point(328, 126)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New Size(93, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Sans compression"
        '
        'chkRécursif
        '
        Me.chkRécursif.AutoSize = True
        Me.chkRécursif.Location = New Point(11, 46)
        Me.chkRécursif.Name = "chkRécursif"
        Me.chkRécursif.Size = New Size(140, 17)
        Me.chkRécursif.TabIndex = 3
        Me.chkRécursif.Text = "Inclu&re les sous-dossiers"
        Me.chkRécursif.UseVisualStyleBackColor = True
        '
        'frmVignettes
        '
        Me.AcceptButton = Me.btnGénère
        Me.AutoScaleBaseSize = New Size(5, 13)
        Me.ClientSize = New Size(427, 431)
        Me.Controls.Add(Me.chkRécursif)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tbQualité)
        Me.Controls.Add(Me.txtQualité)
        Me.Controls.Add(Me.lblQualité)
        Me.Controls.Add(Me.btnLookupDestination)
        Me.Controls.Add(Me.btnLookupSource)
        Me.Controls.Add(Me.txtTaille)
        Me.Controls.Add(Me.lblTaille)
        Me.Controls.Add(Me.txtDestination)
        Me.Controls.Add(Me.lblDestination)
        Me.Controls.Add(Me.txtSource)
        Me.Controls.Add(Me.lblSource)
        Me.Controls.Add(Me.lstTrace)
        Me.Controls.Add(Me.btnGénère)
        Me.Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Me.Name = "frmVignettes"
        Me.Text = "Retaille d'images / Génération de vignettes"
        CType(Me.tbQualité, ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub btnGénère_Click(sender As System.Object, e As EventArgs) Handles btnGénère.Click
        Dim m_sSourcePath As String
        Dim m_sDestinationPath As String

        If Not System.IO.Directory.Exists(txtSource.Text) Then
            MsgBox("R�pertoire source inexistant ou inaccessible.", MsgBoxStyle.Exclamation)
            txtSource.Focus()
            Exit Sub
        End If

        'If Not System.IO.Directory.Exists(txtDestination.Text) Then
        '    MsgBox("R�pertoire destination inexistant ou inaccessible.", MsgBoxStyle.Exclamation)
        '    txtDestination.Focus()
        '    Exit Sub
        'End If

        m_iGrandCote = Val(txtTaille.Text)
        If m_iGrandCote < 50 Or m_iGrandCote > 3000 Then
            MsgBox("Taille du grand cot� invalide (doit �tre comprise entre 50 et 3000)", MsgBoxStyle.Exclamation)
            txtTaille.Focus()
            Exit Sub
        End If

        m_sSourcePath = txtSource.Text
        'If Microsoft.VisualBasic.Right(m_sSourcePath, 1) <> "\" Then m_sSourcePath = m_sSourcePath & "\"
        m_sDestinationPath = txtDestination.Text
        'If Microsoft.VisualBasic.Right(m_sDestinationPath, 1) <> "\" Then m_sDestinationPath = m_sDestinationPath & "\"

        If StrComp(m_sSourcePath, m_sDestinationPath, CompareMethod.Text) = 0 Then
            MsgBox("Les deux r�pertoires ne peuvent �tre identiques.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        btnGénère.Enabled = False
        Génération(m_sSourcePath, m_sDestinationPath)
        Trace("Fin de la Génération")
        btnGénère.Enabled = True
    End Sub

    Sub Génération(sSourcePath As String, sDestinationPath As String)
        Trace("Génération " & sSourcePath & " --> " & sDestinationPath)

        If Not My.Computer.FileSystem.DirectoryExists(sDestinationPath) Then
            Try
                Trace("Cr�ation du dossier " & sDestinationPath)
                My.Computer.FileSystem.CreateDirectory(sDestinationPath)
            Catch ex As Exception
                Trace("Erreur durant la cr�ation: " & ex.Message)
                Exit Sub
            End Try
        End If

        Dim dir As IO.DirectoryInfo
        dir = New IO.DirectoryInfo(sSourcePath)
        Dim fic As IO.FileInfo

        For Each fic In dir.GetFiles("*.jpg")
            Try
                GénèreVignette(sSourcePath, sDestinationPath, fic.Name)
                System.GC.Collect()
                System.GC.WaitForPendingFinalizers()
                System.Threading.Thread.Sleep(0)
            Catch
            End Try
        Next

        If chkRécursif.Checked Then
            Dim subdir As IO.DirectoryInfo
            For Each subdir In dir.GetDirectories
                If subdir.FullName <> sDestinationPath Then
                    Génération(sSourcePath & "\" & subdir.Name, sDestinationPath & "\" & subdir.Name)
                End If
            Next
        End If
    End Sub

    Sub GénèreVignette(sSourcePath As String, sDestinationPath As String, sNomfic As String)
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

        ' Version compliqu�e avec DrawImage
        'imgOutput = New Bitmap(iNewWidth, iNewHeight, System.Drawing.Imaging.PixelFormat.Format32bppRgb)
        'Dim h As Graphics = Graphics.FromImage(imgOutput)
        'h.DrawImage(img, 0, 0, iNewWidth, iNewHeight)

        ' Version simplifi�e avec le constructeur de Bitmap qui remet � l'�chelle
        imgOutput = New Bitmap(imgSource, iNewWidth, iNewHeight)

        ' On contr�le la Qualité
        Dim eps As New EncoderParameters(1)
        eps.Param(0) = New EncoderParameter(Encoder.Quality, CLng(txtQualité.Text))
        Dim ici As ImageCodecInfo = GetEncoderInfo("image/jpeg")

        ' Et on enregistre
        imgOutput.Save(sPathVignette, ici, eps)

        Trace(sNomfic)
    End Sub

    Sub Trace(sMsg As String)
        lstTrace.Items.Add(sMsg)
        lstTrace.SelectedIndex = lstTrace.Items.Count - 1
        lstTrace.Refresh()
    End Sub

    Private Sub btnLookupSource_Click(sender As System.Object, e As EventArgs) Handles btnLookupSource.Click
        FolderBrowser.SelectedPath = txtSource.Text
        FolderBrowser.ShowNewFolderButton = False
        FolderBrowser.Description = "S�lectionnez le dossier contenant les images source :"
        If FolderBrowser.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            txtSource.Text = FolderBrowser.SelectedPath
            txtSource.SelectionStart = 0
            txtSource.SelectionLength = 999
        End If
    End Sub

    Private Sub btnLookupDestination_Click(sender As System.Object, e As EventArgs) Handles btnLookupDestination.Click
        FolderBrowser.SelectedPath = txtDestination.Text
        FolderBrowser.ShowNewFolderButton = True
        FolderBrowser.Description = "S�lectionnez le dossier de destination pour les vignettes :"
        If FolderBrowser.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            txtDestination.Text = FolderBrowser.SelectedPath
            txtDestination.SelectionStart = 0
            txtDestination.SelectionLength = 999
        End If
    End Sub

    Private Function GetEncoderInfo(mimeType As String) As ImageCodecInfo
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

    Private Sub txtQualité_TextChanged(sender As System.Object, e As EventArgs) Handles txtQualité.TextChanged
        tbQualité.Value = Val(txtQualité.Text)
    End Sub

    Private Sub tbQualité_Scroll(sender As System.Object, e As EventArgs) Handles tbQualité.Scroll
        txtQualité.Text = Format(tbQualité.Value)
    End Sub

    Private Sub frmVignettes_Load(sender As System.Object, e As EventArgs) Handles MyBase.Load
        txtQualité.Text = "90"
        ' About command in System menu
        mobjSubclassedSystemMenu = New SubclassedSystemMenu(Me.Handle.ToInt32, "&A propos de...")
    End Sub

    Private Sub txtSource_GotFocus(sender As Object, e As EventArgs) Handles txtSource.GotFocus
        txtSource.SelectionStart = 0
        txtSource.SelectionLength = 999
    End Sub

    Private Sub txtDestination_GotFocus(sender As Object, e As EventArgs) Handles txtDestination.GotFocus
        txtDestination.SelectionStart = 0
        txtDestination.SelectionLength = 999
    End Sub

    ''' <summary>
    ''' Event handled for About command in System menu
    ''' </summary>
    Private Sub mobjSubclassedSystemMenu_LaunchDialog() Handles mobjSubclassedSystemMenu.LaunchDialog
        Dim frmNew As New frmAbout
        frmNew.ShowDialog(Me)
    End Sub

    Private Sub txtSource_TextChanged(sender As System.Object, e As EventArgs) Handles txtSource.TextChanged
        If My.Computer.FileSystem.DirectoryExists(txtSource.Text) Then
            If txtDestination.Text = "" And My.Computer.FileSystem.DirectoryExists(txtSource.Text & "R") Then
                txtDestination.Text = txtSource.Text & "R"
            End If
        End If
    End Sub

End Class