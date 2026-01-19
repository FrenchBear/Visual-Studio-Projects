' RotorRouter
' From Complexités, JP Delahaye, P.231
'
' 2008-01-23    PV
' 2008-02-01 	PV		Rescaling
' 2010-04-15 	PV		VS2010
' 2021-09-20 	PV		VS2022; Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9
' 2026-01-19	PV		Net10

Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging

#Disable Warning IDE1006 ' Naming Styles

Public Class frmRotorRouter
    Private ReadOnly col0 As Color = Color.Red
    Private ReadOnly col1 As Color = Color.Blue
    Private ReadOnly col2 As Color = Color.White
    Private ReadOnly col3 As Color = Color.Yellow

    'Private ReadOnly col0 As Color = Color.LightBlue
    'Private ReadOnly col1 As Color = Color.Blue
    'Private ReadOnly col2 As Color = Color.LightGreen
    'Private ReadOnly col3 As Color = Color.Green

    Private ReadOnly colBackground As Color = Color.PaleGoldenrod

    Private ReadOnly r As Integer = 100         ' Circle radius = 1/2 size of square picture
    Private ReadOnly n = 15000                  ' Number of iterations
    Private ReadOnly nRefresh = 50              ' Refresh image every nRefresh iterations
    Private ReadOnly picScale As Integer = 2    ' Scaling factor for display

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        btnStart.Enabled = False

        ' PicBitmap is the actual bitmap surface the algorithm is running on
        Dim picBitmap As New Bitmap((2 * r) + 1, (2 * r) + 1, PixelFormat.Format24bppRgb)
        ' Pic rescaled is a copy of picBitmap taken every nRefresh iterations, rescaled of a factor picScale, and displayed
        Dim picRescaled As New Bitmap(picScale * ((2 * r) + 1), picScale * ((2 * r) + 1), PixelFormat.Format24bppRgb)

        Graphics.FromImage(picBitmap).Clear(colBackground)
        pic.Width = picScale * ((2 * r) + 1)
        pic.Height = picScale * ((2 * r) + 1)
        Panel1.Refresh()

        For i As Integer = 0 To n
            If i Mod nRefresh = 0 Then
                txtIterations.Text = i.ToString
                txtIterations.Refresh()

                Dim g As Graphics = Graphics.FromImage(picRescaled)
                g.SmoothingMode = SmoothingMode.None
                g.DrawImage(picBitmap, 0, 0, picScale * ((2 * r) + 1), picScale * ((2 * r) + 1))
                pic.BackgroundImage = picRescaled
                pic.Refresh()

                Application.DoEvents()
            End If

            ' Start at the center for each iteration
            Dim x = r, y = r
            Do
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

    ' DoEvents allows the app to be closed before it terminates
    Private Sub frmRotorRouter_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        End
    End Sub

End Class
