' 2012-02-25	PV  VS2010
' 2023-01-10	PV		Net7

Imports System.Drawing.Imaging

#Disable Warning IDE0059 ' Unnecessary assignment of a value
#Disable Warning IDE1006 ' Naming Styles

Public Class frmCodecs
    Inherits Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(disposing As Boolean)
        If disposing Then
            components?.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private ReadOnly components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.SuspendLayout()
        '
        'frmCodecs
        '
        Me.AutoScaleBaseSize = New Size(5, 13)
        Me.ClientSize = New Size(528, 526)
        Me.Name = "frmCodecs"
        Me.Text = "frmCodecs"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmCodecs_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        GetImageEncodersExample(e)
    End Sub

    Public Shared Sub GetImageEncodersExample(e As PaintEventArgs)
        ' Get an array of available codecs.
        Dim myEncoders() As ImageCodecInfo
        myEncoders = ImageCodecInfo.GetImageEncoders()
        Dim numEncoders As Integer = myEncoders.GetLength(0)
        Dim strNumEncoders As String = numEncoders.ToString()
        Dim foreColor As Color = Color.Black
        Dim font As New Font("Arial", 8)
        Dim i As Integer = 0
        ' Get the info. for all encoders in the array.
        If numEncoders > 0 Then
            Dim myEncoderInfo(numEncoders * 10) As String
            For i = 0 To numEncoders - 1
                myEncoderInfo((i * 10)) = "Codec Name = " _
                + myEncoders(i).CodecName
                myEncoderInfo((i * 10 + 1)) = "Class ID = " _
                + myEncoders(i).Clsid.ToString()
                myEncoderInfo((i * 10 + 2)) = "DLL Name = " _
                + myEncoders(i).DllName
                myEncoderInfo((i * 10 + 3)) = "Filename Ext. = " _
                + myEncoders(i).FilenameExtension
                myEncoderInfo((i * 10 + 4)) = "Flags = " _
                + myEncoders(i).Flags.ToString()
                myEncoderInfo((i * 10 + 5)) = "Format Descrip. = " _
                + myEncoders(i).FormatDescription
                myEncoderInfo((i * 10 + 6)) = "Format ID = " _
                + myEncoders(i).FormatID.ToString()
                myEncoderInfo((i * 10 + 7)) = "MimeType = " _
                + myEncoders(i).MimeType
                myEncoderInfo((i * 10 + 8)) = "Version = " _
                + myEncoders(i).Version.ToString()
                myEncoderInfo((i * 10 + 9)) = " "
            Next i
            Dim numMyEncoderInfo As Integer = myEncoderInfo.GetLength(0)
            ' Render to the screen all the information.
            Dim j As Integer = 20
            For i = 0 To numMyEncoderInfo - 1
                e.Graphics.DrawString(myEncoderInfo(i), font,
                New SolidBrush(foreColor), 20, j)
                j += 12
            Next i
        Else
            e.Graphics.DrawString("No Encoders Found", font,
            New SolidBrush(foreColor), 20, 20)
        End If
    End Sub

End Class
