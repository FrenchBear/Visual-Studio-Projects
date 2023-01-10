' 2012-02-25	PV  VS2010

Imports System.Drawing.Imaging

#Disable Warning IDE1006 ' Naming Styles

Public Class Form1
    Private i As Image

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        i = Image.FromFile("c:\Multiframe.tiff")
        Dim nbFrame As Integer = i.GetFrameCount(FrameDimension.Page)
        MsgBox("Nb frames: " & nbFrame)
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

    Private Sub btnF1_Click(sender As Object, e As EventArgs) Handles btnF1.Click
        i.SelectActiveFrame(FrameDimension.Page, 0)
        pbPic.Image = i
    End Sub

    Private Sub btnF2_Click(sender As Object, e As EventArgs) Handles btnF2.Click
        i.SelectActiveFrame(FrameDimension.Page, 1)
        pbPic.Image = i
    End Sub

    Private Sub btnF3_Click(sender As Object, e As EventArgs) Handles btnF3.Click
        i.SelectActiveFrame(FrameDimension.Page, 2)
        pbPic.Image = i
    End Sub

End Class