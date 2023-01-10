' RotorRouter
' From Complexités, JP Delahaye, P.231
'
' 2008-01-23    PV
' 2008-02-01    PV  Rescaling
' 2010-04-15    PV  VS2010
' 2021-09-20    PV  VS2022; Net6
' 2023-01-10	PV		Net7

Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging

#Disable Warning IDE1006 ' Naming Styles

Public Class frmRotorRouter
    ReadOnly col0 As Color = Color.Red
    ReadOnly col1 As Color = Color.Blue
    ReadOnly col2 As Color = Color.White
    ReadOnly col3 As Color = Color.Yellow

    'ReadOnly col0 As Color = Color.LightBlue
    'ReadOnly col1 As Color = Color.Blue
    'ReadOnly col2 As Color = Color.LightGreen
    'ReadOnly col3 As Color = Color.Green

    ReadOnly colBackground As Color = Color.PaleGoldenrod

    ReadOnly r As Integer = 100
    ReadOnly n = 15000
    ReadOnly nRefresh = 50      ' Refres every nRefresh passes

    ReadOnly picScale As Integer = 2

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        btnStart.Enabled = False

        Dim picBitmap As New Bitmap(2 * r + 1, 2 * r + 1, PixelFormat.Format24bppRgb)
        Dim picRescaled As New Bitmap(picScale * (2 * r + 1), picScale * (2 * r + 1), PixelFormat.Format24bppRgb)
        Graphics.FromImage(picBitmap).Clear(colBackground)
        pic.Width = picScale * (2 * r + 1)
        pic.Height = picScale * (2 * r + 1)
        Panel1.Refresh()

        ' Create rectangle for displaying image.
        Dim destRect As New Rectangle(0, 0, picScale * (2 * r + 1), picScale * (2 * r + 1))

        For i As Integer = 0 To n
            If i Mod nRefresh = 0 Then
                txtIterations.Text = i.ToString
                txtIterations.Refresh()
                'pic.BackgroundImage = picBitmap.GetThumbnailImage(picScale * (2 * r + 1), picScale * (2 * r + 1), Nothing, Nothing)
                'pic.Refresh()

                Dim g As Graphics = Graphics.FromImage(picRescaled)
                g.SmoothingMode = SmoothingMode.None
                g.DrawImage(picBitmap, 0, 0, picScale * (2 * r + 1), picScale * (2 * r + 1))
                pic.BackgroundImage = picRescaled
                pic.Refresh()

                Application.DoEvents()
            End If

            Dim x, y As Integer
            x = r
            y = r
            Do
                'Dim c As Color = picBitmap.GetPixel(x, y)
                'If c.ToArgb = colBackground.ToArgb Then
                'picBitmap.SetPixel(x, y, col0)
                'Exit Do
                'End If
                Select Case picBitmap.GetPixel(x, y).ToArgb
                    Case colBackground.ToArgb
                        picBitmap.SetPixel(x, y, col0)
                        Exit Do
                    Case col0.ToArgb
                        picBitmap.SetPixel(x, y, col1)
                        y += 1
                    Case col1.ToArgb
                        picBitmap.SetPixel(x, y, col2)
                        x += 1
                    Case col2.ToArgb
                        picBitmap.SetPixel(x, y, col3)
                        y -= 1
                    Case col3.ToArgb
                        picBitmap.SetPixel(x, y, col0)
                        x -= 1
                End Select
                'If x < 0 Or x > 2 * r Or y < 0 Or y > 2 * r Then Exit For
            Loop
        Next
        txtIterations.Text = n.ToString
        pic.BackgroundImage = picBitmap
        btnStart.Enabled = True
    End Sub

    ' Because of DoEvents
    Private Sub frmRotorRouter_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        End
    End Sub

End Class
