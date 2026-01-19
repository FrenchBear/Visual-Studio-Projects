' 078 VB Vignettes
' Retaillage d'image avec GDI+
' PV juillet 2003
'
' 2003-07-16 	PV		Version simplifiée avec le constructeur de la classe Bitmap qui retaille
' 2003-07-30 	PV		Choix de la compression JPEG
' 2006-10-01 	PV		VS2005
' 2012-02-25	PV		VS2010
' 2021-09-19 	PV		VS2022, Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9
' 2026-01-19	PV		Net10

Imports System.ComponentModel
Imports System.Drawing.Imaging

#Disable Warning IDE0051 ' Remove unused private members

Public Class Form1
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
            components?.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requis par le Concepteur Windows Form
    Private ReadOnly components As IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée en utilisant le Concepteur Windows Form.
    'Ne la modifiez pas en utilisant l'éditeur de code.
    Friend WithEvents BtnGénère As Button

    Friend WithEvents LstTrace As ListBox

    <DebuggerStepThrough()> Private Sub InitializeComponent()
        BtnGénère = New Button
        LstTrace = New ListBox
        SuspendLayout()
        '
        'btnGénère
        '
        BtnGénère.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        BtnGénère.Location = New Point(328, 8)
        BtnGénère.Name = "btnGénère"
        BtnGénère.Size = New Size(104, 32)
        BtnGénère.TabIndex = 0
        BtnGénère.Text = "Génère"
        '
        'lstTrace
        '
        LstTrace.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom _
                Or AnchorStyles.Left _
                Or AnchorStyles.Right
        LstTrace.Location = New Point(8, 8)
        LstTrace.Name = "lstTrace"
        LstTrace.Size = New Size(312, 394)
        LstTrace.TabIndex = 1
        '
        'Form1
        '
        AutoScaleBaseSize = New Size(5, 13)
        ClientSize = New Size(440, 414)
        Controls.Add(LstTrace)
        Controls.Add(BtnGénère)
        Name = "Form1"
        Text = "Générateur de vignettes"
        ResumeLayout(False)

    End Sub

#End Region

    Private Sub BtnGénère_Click(sender As Object, e As EventArgs) Handles BtnGénère.Click
        BtnGénère.Enabled = False
        Trace("Début de la génération")

        Try
            For i As Integer = 31 To 42
                GénèreVignette(i)
            Next
        Catch ex As Exception
        Finally
            Trace("Fin de la génération")
            BtnGénère.Enabled = True
        End Try
    End Sub

    Public Sub GénèreVignette(ByRef i As Integer)
        Dim sImg As String
        Dim sPathImg As String
        Dim sPathVignette As String

        Const sPath As String = "C:\Documents PV\Mes Images\Titus\"

        sImg = "Titus " & Strings.Right(Str(1000 + i), 3) & ".jpg"
        sPathImg = sPath & sImg
        sPathVignette = sPath & "Vignettes\" & sImg

        Dim img As Bitmap
        img = Image.FromFile(sPathImg)
        Dim iNewWidth, iNewHeight As Integer
        If img.Width > img.Height Then
            iNewWidth = 200
            iNewHeight = 200 / img.Width * img.Height
        Else
            iNewHeight = 200
            iNewWidth = 200 / img.Height * img.Width
        End If

        ' Version simple avec un constructeur de la classe image
        Dim img2 As Bitmap
        img2 = New Bitmap(img, iNewWidth, iNewHeight)
        img2.Save(sPathVignette, ImageFormat.Jpeg)

        ' Version plus complexe où l'image est dessinnée avec DrawImage
        'Dim imgOutput As Bitmap
        'imgOutput = New Bitmap(iNewWidth, iNewHeight, System.Drawing.Imaging.PixelFormat.Format32bppRgb)
        'Dim h As Graphics = Graphics.FromImage(imgOutput)
        'h.DrawImage(img, 0, 0, iNewWidth, iNewHeight)
        'imgOutput.Save(sPathVignette, System.Drawing.Imaging.ImageFormat.Jpeg)

        Trace(sPathImg & " -> " & sPathVignette)
    End Sub

    Public Sub Trace(sMsg As String)
        LstTrace.Items.Add(sMsg)
        LstTrace.SelectedIndex = LstTrace.Items.Count - 1
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

    Private Shared Sub SaveJPGWithCompressionSetting(image As Image, szFileName As String, lCompression As Long)
        Dim eps As New EncoderParameters(1)
        eps.Param(0) = New EncoderParameter(Encoder.Quality, lCompression)
        Dim ici As ImageCodecInfo = GetEncoderInfo("image/jpeg")
        image.Save(szFileName, ici, eps)
    End Sub

End Class
