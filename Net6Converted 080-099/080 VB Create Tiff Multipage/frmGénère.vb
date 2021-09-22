' 2012-02-25	PV  VS2010

Imports System.Drawing.Imaging

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
    Friend WithEvents Button1 As Button

    Friend WithEvents ListCodecsButton As Button

    <DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Button1 = New Button
        Me.ListCodecsButton = New Button
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New Point(8, 8)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New Size(120, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Génère"
        '
        'btnListCodecs
        '
        Me.ListCodecsButton.Location = New Point(8, 40)
        Me.ListCodecsButton.Name = "btnListCodecs"
        Me.ListCodecsButton.Size = New Size(120, 23)
        Me.ListCodecsButton.TabIndex = 1
        Me.ListCodecsButton.Text = "List Imaging codecs"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New Size(5, 13)
        Me.ClientSize = New Size(292, 266)
        Me.Controls.Add(Me.ListCodecsButton)
        Me.Controls.Add(Me.Button1)
        Me.Name = "Form1"
        Me.Text = "TIFF Multiframe"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Button1_Click(sender As System.Object, e As EventArgs) Handles Button1.Click
        Dim multi As Bitmap
        Dim page2 As Bitmap
        Dim page3 As Bitmap

        multi = New Bitmap(1728, 2156, System.Drawing.Imaging.PixelFormat.Format24bppRgb)
        page2 = New Bitmap(1728, 2156, System.Drawing.Imaging.PixelFormat.Format24bppRgb)
        page3 = New Bitmap(1728, 2156, System.Drawing.Imaging.PixelFormat.Format24bppRgb)

        multi.SetResolution(200, 200)
        page2.SetResolution(200, 200)
        page3.SetResolution(200, 200)

        Dim g1 As Graphics = Graphics.FromImage(multi)
        Dim g2 As Graphics = Graphics.FromImage(page2)
        Dim g3 As Graphics = Graphics.FromImage(page3)

        g1.Clear(Color.FromKnownColor(KnownColor.LightCyan))
        g2.Clear(Color.FromKnownColor(KnownColor.AliceBlue))
        g3.Clear(Color.FromKnownColor(KnownColor.Chartreuse))

        Dim f As Font
        f = New Font("Arial", 12)

        g1.DrawString("Page 1", f, System.Drawing.Brushes.Black, 25, 25)
        g2.DrawString("Page 2", f, System.Drawing.Brushes.Black, 25, 25)
        g3.DrawString("Page 3", f, System.Drawing.Brushes.Black, 25, 25)

        'Declare Function OemToChar Lib "user32" Alias "OemToCharA" (ByVal lpszSrc As String, ByVal lpszDst As String) As Long
        'Declare Function CharToOem Lib "user32" Alias "CharToOemA" (ByVal lpszSrc As String, ByVal lpszDst As String) As Long

        For i As Integer = 0 To 255
            f = New Font("Courier New", 14, FontStyle.Regular, GraphicsUnit.Pixel, i)
            g1.DrawString(ChrW(&H251C) & f.GdiCharSet().ToString, f, System.Drawing.Brushes.Black, 250 * (1 + i Mod 6), 2100 / 255 * i)
        Next

        Dim myImageCodecInfo As ImageCodecInfo
        Dim myEncoder As Encoder
        Dim myEncoderParameter As EncoderParameter
        Dim myEncoderParameters As EncoderParameters

        ' Get an ImageCodecInfo object that represents the TIFF codec.
        myImageCodecInfo = GetEncoderInfo("image/tiff")
        ' Create an Encoder object based on the GUID
        ' for the SaveFlag parameter category.
        myEncoder = Encoder.SaveFlag
        ' Create an EncoderParameters object.
        ' An EncoderParameters object has an array of EncoderParameter
        ' objects. In this case, there is only one
        ' EncoderParameter object in the array.
        myEncoderParameters = New EncoderParameters(1)
        ' Save the first page (frame).
        myEncoderParameter = New EncoderParameter(myEncoder, EncoderValue.MultiFrame)
        myEncoderParameters.Param(0) = myEncoderParameter
        multi.Save("C:\Multiframe.tiff", myImageCodecInfo, myEncoderParameters)
        ' Save the second page (frame).
        myEncoderParameter = New EncoderParameter(myEncoder, EncoderValue.FrameDimensionPage)
        myEncoderParameters.Param(0) = myEncoderParameter
        multi.SaveAdd(page2, myEncoderParameters)
        ' Save the third page (frame).
        myEncoderParameter = New EncoderParameter(myEncoder, EncoderValue.FrameDimensionPage)
        myEncoderParameters.Param(0) = myEncoderParameter
        multi.SaveAdd(page3, myEncoderParameters)
        ' Close the multiple-frame file.
        myEncoderParameter = New EncoderParameter(myEncoder, EncoderValue.Flush)
        myEncoderParameters.Param(0) = myEncoderParameter
        multi.SaveAdd(myEncoderParameters)

        MsgBox("Enregistré --> C:\Multiframe.tiff")
    End Sub

    Public Shared Function GetEncoderInfo(mimeType As String) As ImageCodecInfo
        Dim j As Integer
        Dim encoders() As ImageCodecInfo
        encoders = ImageCodecInfo.GetImageEncoders()
        For j = 0 To UBound(encoders) - 1
            If encoders(j).MimeType = mimeType Then
                Return encoders(j)
            End If
        Next
        Return Nothing
    End Function

    Private Sub ListCodecsButton_Click(sender As System.Object, e As EventArgs) Handles ListCodecsButton.Click
        Dim f As New frmCodecs
        f.Show()
    End Sub

End Class