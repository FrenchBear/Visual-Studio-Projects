' imgTo1Bit
' Réductions d'images...
'
' 2003-08-07    PV
' 2006-10-01 	PV		VS2005
' 2012-02-25	PV		VS2010
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9
' 2026-01-19	PV		Net10

Imports System.ComponentModel
Imports System.Drawing.Imaging
Imports System.Runtime.InteropServices

#Disable Warning IDE1006 ' Naming Styles

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
    Friend WithEvents PictureBox1 As PictureBox

    Friend WithEvents PictureBox2 As PictureBox

    <DebuggerStepThrough()> Private Sub InitializeComponent()
        PictureBox1 = New PictureBox
        PictureBox2 = New PictureBox
        SuspendLayout()
        '
        'PictureBox1
        '
        PictureBox1.BorderStyle = BorderStyle.FixedSingle
        PictureBox1.Location = New Point(8, 8)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(284, 264)
        PictureBox1.TabIndex = 0
        PictureBox1.TabStop = False
        '
        'PictureBox2
        '
        PictureBox2.BorderStyle = BorderStyle.FixedSingle
        PictureBox2.Location = New Point(300, 8)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(284, 264)
        PictureBox2.TabIndex = 1
        PictureBox2.TabStop = False
        '
        'Form1
        '
        AutoScaleBaseSize = New Size(5, 13)
        ClientSize = New Size(588, 278)
        Controls.Add(PictureBox2)
        Controls.Add(PictureBox1)
        MinimizeBox = False
        Name = "Form1"
        Text = "Test ImgTo1Bit"
        ResumeLayout(False)

    End Sub

#End Region

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PictureBox1.Image = Image.FromFile("pv.jpg")
        PictureBox2.Image = imgTo1Bit(PictureBox1.Image)
    End Sub

End Class

Friend Module ConversionImages

    Public Function imgTo1Bit(imgSource As Bitmap) As Bitmap
        Dim bm As New Bitmap(imgSource.Width, imgSource.Height, PixelFormat.Format1bppIndexed)
        Dim bmd As BitmapData = bm.LockBits(New Rectangle(0, 0, bm.Width, bm.Height), ImageLockMode.ReadWrite, PixelFormat.Format1bppIndexed)

        Dim pData As IntPtr = bmd.Scan0
        Dim tbRow(bmd.Stride) As Byte
        Dim ibyte As Integer
        Dim mbit As Byte

        For y As Integer = 0 To bm.Height - 1
            ibyte = 0
            mbit = 128

            For x As Integer = 0 To bm.Width - 1
                tbRow(ibyte) = If(imgSource.GetPixel(x, y).GetBrightness() > 0.5, tbRow(ibyte) Or mbit, tbRow(ibyte) And Not mbit)
                If mbit = 1 Then
                    mbit = 128
                    ibyte += 1
                Else
                    mbit >>= 1
                End If
            Next

            Marshal.Copy(tbRow, 0, pData, bmd.Stride)
            'pData = IntPtr.op_Explicit(pData.ToInt32 + bmd.Stride)
            pData += bmd.Stride
        Next
        bm.UnlockBits(bmd)

        Return bm
    End Function

    'Sub RGPaintBitmap(ByVal x As Integer, ByVal y As Integer, ByRef tbByte As ArrayList, ByVal iWidth As Integer, ByVal iHeight As Integer, ByVal iDPIRaster As Integer)
    '  Dim bmpImage3 As New Bitmap(iWidth, iHeight, PixelFormat.Format24bppRgb)
    '  bmpImage3.SetResolution(iDPIRaster, iDPIRaster)
    '  Dim bdaImage3 As BitmapData

    '  ' verrue 1: on remonte les images en 150 dpi...
    '  If iDPIRaster = 150 Then y = y - 550

    '  bdaImage3 = bmpImage3.LockBits(New Rectangle(0, 0, iWidth, iHeight), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb)
    '  Dim pData As IntPtr = bdaImage3.Scan0
    '  Dim RowByteSize As Int32 = 3 * iWidth
    '  Dim pixBytes(RowByteSize) As Byte

    '  For l As Integer = 0 To tbByte.Count() - 1
    '    System.Runtime.InteropServices.Marshal.Copy(pData, pixBytes, 0, RowByteSize)
    '    Dim r As Byte() = CType(tbByte(l), Byte())
    '    Dim c As Integer = 0
    '    Dim i As Integer = 0
    '    For Each b As Byte In r
    '      For p As Byte = 0 To 7
    '        If b And 128 Then
    '          pixBytes(i) = 0
    '          pixBytes(i + 1) = 0
    '          pixBytes(i + 2) = 0
    '        Else
    '          pixBytes(i) = 255
    '          pixBytes(i + 1) = 255
    '          pixBytes(i + 2) = 255
    '        End If
    '        i += 3
    '        c += 1
    '        If c >= iWidth Then Exit For
    '        b <<= 1
    '      Next
    '    Next
    '    System.Runtime.InteropServices.Marshal.Copy(pixBytes, 0, pData, RowByteSize)
    '    pData = IntPtr.op_Explicit(pData.ToInt32 + bdaImage3.Stride)
    '  Next
    '  bmpImage3.UnlockBits(bdaImage3)

    'End Sub
End Module
