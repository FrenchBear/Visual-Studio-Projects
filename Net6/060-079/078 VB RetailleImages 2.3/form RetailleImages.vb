' frmRetailleImages
' Application de redimensionnement d'images en VB.Net
' PV Juillet 2003
' 2003-07-30    PV  Contr�le de la qualit�
' 2006-10-01    PV  VS 2005
' 2007-05/18    PV  About... in system menu
' 2007-05-21    PV  Les images plus petites gardent leur taille; option r�cursive
' 2009-10-15    PV  VS 2008 et ajout suffixe R automatiquement
' 2012-02-25	PV  VS2010; .Net Framework Client Profile 4.0
' 2021-09-19    PV  VS2022, Net6

Option Explicit On
Option Compare Text
Imports System.Drawing.Imaging

Public Class VignettesForm
    Inherits System.Windows.Forms.Form

    Dim m_iGrandCote As Integer
    Friend WithEvents R�cursifCheckBox As System.Windows.Forms.CheckBox

    ''' <summary>About command in System menu</summary>
    Private WithEvents SubclassedSystemMenu As SubclassedSystemMenu

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
    Private ReadOnly components As System.ComponentModel.IContainer

    'REMARQUE�: la proc�dure suivante est requise par le Concepteur Windows Form
    'Elle peut �tre modifi�e en utilisant le Concepteur Windows Form.  
    'Ne la modifiez pas en utilisant l'�diteur de code.
    Friend WithEvents G�n�reButton As System.Windows.Forms.Button
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
    Friend WithEvents Qualit�Text As System.Windows.Forms.TextBox
    Friend WithEvents Qualit�Label As System.Windows.Forms.Label
    Friend WithEvents Qualit�TrackBar As System.Windows.Forms.TrackBar
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(VignettesForm))
        Me.G�n�reButton = New System.Windows.Forms.Button
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
        Me.Qualit�Text = New System.Windows.Forms.TextBox
        Me.Qualit�Label = New System.Windows.Forms.Label
        Me.Qualit�TrackBar = New System.Windows.Forms.TrackBar
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.R�cursifCheckBox = New System.Windows.Forms.CheckBox
        CType(Me.Qualit�TrackBar, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnG�n�re
        '
        Me.G�n�reButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.G�n�reButton.Location = New System.Drawing.Point(315, 8)
        Me.G�n�reButton.Name = "btnG�n�re"
        Me.G�n�reButton.Size = New System.Drawing.Size(104, 32)
        Me.G�n�reButton.TabIndex = 15
        Me.G�n�reButton.Text = "&G�n�re"
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
        Me.SourceLabel.Text = "R�pertoire &source :"
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
        Me.DestinationLabel.Text = "R�pertoire &destination :"
        '
        'lblTaille
        '
        Me.TailleLabel.Location = New System.Drawing.Point(8, 118)
        Me.TailleLabel.Name = "lblTaille"
        Me.TailleLabel.Size = New System.Drawing.Size(136, 16)
        Me.TailleLabel.TabIndex = 7
        Me.TailleLabel.Text = "&Taille grand cot� (pixels) :"
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
        'txtQualit�
        '
        Me.Qualit�Text.Location = New System.Drawing.Point(148, 154)
        Me.Qualit�Text.Name = "txtQualit�"
        Me.Qualit�Text.Size = New System.Drawing.Size(56, 20)
        Me.Qualit�Text.TabIndex = 10
        '
        'lblQualit�
        '
        Me.Qualit�Label.AutoSize = True
        Me.Qualit�Label.Location = New System.Drawing.Point(8, 158)
        Me.Qualit�Label.Name = "lblQualit�"
        Me.Qualit�Label.Size = New System.Drawing.Size(112, 13)
        Me.Qualit�Label.TabIndex = 9
        Me.Qualit�Label.Text = "&Qualit� JPEG (0-100) :"
        '
        'tbQualit�
        '
        Me.Qualit�TrackBar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Qualit�TrackBar.Location = New System.Drawing.Point(216, 146)
        Me.Qualit�TrackBar.Maximum = 100
        Me.Qualit�TrackBar.Name = "tbQualit�"
        Me.Qualit�TrackBar.Size = New System.Drawing.Size(208, 45)
        Me.Qualit�TrackBar.TabIndex = 11
        Me.Qualit�TrackBar.TickFrequency = 5
        Me.Qualit�TrackBar.TickStyle = System.Windows.Forms.TickStyle.TopLeft
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
        'chkR�cursif
        '
        Me.R�cursifCheckBox.AutoSize = True
        Me.R�cursifCheckBox.Location = New System.Drawing.Point(11, 46)
        Me.R�cursifCheckBox.Name = "chkR�cursif"
        Me.R�cursifCheckBox.Size = New System.Drawing.Size(140, 17)
        Me.R�cursifCheckBox.TabIndex = 3
        Me.R�cursifCheckBox.Text = "Inclu&re les sous-dossiers"
        Me.R�cursifCheckBox.UseVisualStyleBackColor = True
        '
        'frmVignettes
        '
        Me.AcceptButton = Me.G�n�reButton
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(427, 431)
        Me.Controls.Add(Me.R�cursifCheckBox)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Qualit�TrackBar)
        Me.Controls.Add(Me.Qualit�Text)
        Me.Controls.Add(Me.Qualit�Label)
        Me.Controls.Add(Me.LookupDestinationButton)
        Me.Controls.Add(Me.LookupSourceButton)
        Me.Controls.Add(Me.TailleText)
        Me.Controls.Add(Me.TailleLabel)
        Me.Controls.Add(Me.DestinationText)
        Me.Controls.Add(Me.DestinationLabel)
        Me.Controls.Add(Me.SourceText)
        Me.Controls.Add(Me.SourceLabel)
        Me.Controls.Add(Me.TraceList)
        Me.Controls.Add(Me.G�n�reButton)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmVignettes"
        Me.Text = "Retaille d'images / G�n�ration de vignettes"
        CType(Me.Qualit�TrackBar, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub G�n�reButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles G�n�reButton.Click
        Dim m_sSourcePath As String
        Dim m_sDestinationPath As String

        If Not System.IO.Directory.Exists(SourceText.Text) Then
            MsgBox("R�pertoire source inexistant ou inaccessible.", MsgBoxStyle.Exclamation)
            SourceText.Focus()
            Exit Sub
        End If

        'If Not System.IO.Directory.Exists(txtDestination.Text) Then
        '    MsgBox("R�pertoire destination inexistant ou inaccessible.", MsgBoxStyle.Exclamation)
        '    txtDestination.Focus()
        '    Exit Sub
        'End If

        m_iGrandCote = Val(TailleText.Text)
        If m_iGrandCote < 50 Or m_iGrandCote > 3000 Then
            MsgBox("Taille du grand cot� invalide (doit �tre comprise entre 50 et 3000)", MsgBoxStyle.Exclamation)
            TailleText.Focus()
            Exit Sub
        End If

        m_sSourcePath = SourceText.Text
        'If Microsoft.VisualBasic.Right(m_sSourcePath, 1) <> "\" Then m_sSourcePath = m_sSourcePath & "\"
        m_sDestinationPath = DestinationText.Text
        'If Microsoft.VisualBasic.Right(m_sDestinationPath, 1) <> "\" Then m_sDestinationPath = m_sDestinationPath & "\"

        If StrComp(m_sSourcePath, m_sDestinationPath, CompareMethod.Text) = 0 Then
            MsgBox("Les deux r�pertoires ne peuvent �tre identiques.", MsgBoxStyle.Exclamation)
            Exit Sub
        End If

        G�n�reButton.Enabled = False
        G�n�ration(m_sSourcePath, m_sDestinationPath)
        Trace("Fin de la g�n�ration")
        G�n�reButton.Enabled = True
    End Sub

    Sub G�n�ration(ByVal sSourcePath As String, ByVal sDestinationPath As String)
        Trace("G�n�ration " & sSourcePath & " --> " & sDestinationPath)

        If Not My.Computer.FileSystem.DirectoryExists(sDestinationPath) Then
            Try
                Trace("Cr�ation du dossier " & sDestinationPath)
                My.Computer.FileSystem.CreateDirectory(sDestinationPath)
            Catch ex As Exception
                Trace("Erreur durant la cr�ation: " & ex.Message)
                Exit Sub
            End Try
        End If

        Dim dir As System.IO.DirectoryInfo
        dir = New System.IO.DirectoryInfo(sSourcePath)
        Dim fic As System.IO.FileInfo

        For Each fic In dir.GetFiles("*.jpg")
            Try
                G�n�reVignette(sSourcePath, sDestinationPath, fic.Name)
                System.GC.Collect()
                System.GC.WaitForPendingFinalizers()
                System.Threading.Thread.Sleep(0)
            Catch
            End Try
        Next

        If R�cursifCheckBox.Checked Then
            Dim subdir As System.IO.DirectoryInfo
            For Each subdir In dir.GetDirectories
                If subdir.FullName <> sDestinationPath Then
                    G�n�ration(sSourcePath & "\" & subdir.Name, sDestinationPath & "\" & subdir.Name)
                End If
            Next
        End If
    End Sub


    Sub G�n�reVignette(ByVal sSourcePath As String, ByVal sDestinationPath As String, ByVal sNomfic As String)
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

        ' On contr�le la qualit�
        Dim eps As New EncoderParameters(1)
        eps.Param(0) = New EncoderParameter(Encoder.Quality, CLng(Qualit�Text.Text))
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
        FolderBrowser.Description = "S�lectionnez le dossier contenant les images source :"
        If FolderBrowser.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
            SourceText.Text = FolderBrowser.SelectedPath
            SourceText.SelectionStart = 0
            SourceText.SelectionLength = 999
        End If
    End Sub

    Private Sub LookupDestinationButton_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles LookupDestinationButton.Click
        FolderBrowser.SelectedPath = DestinationText.Text
        FolderBrowser.ShowNewFolderButton = True
        FolderBrowser.Description = "S�lectionnez le dossier de destination pour les vignettes :"
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

    Private Sub Qualit�Text_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Qualit�Text.TextChanged
        Qualit�TrackBar.Value = Val(Qualit�Text.Text)
    End Sub

    Private Sub Qualit�Text_Scroll(ByVal sender As Object, ByVal e As System.EventArgs) Handles Qualit�TrackBar.Scroll
        Qualit�Text.Text = Format(Qualit�TrackBar.Value)
    End Sub

    Private Sub VignettesForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Qualit�Text.Text = "90"
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
