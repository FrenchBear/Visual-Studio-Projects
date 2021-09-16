' 222 VB Icons
' 2012-02-25	PV  VS2010

Public Class IconsForm

    Private Sub Button1_Click(sender As System.Object, e As EventArgs) Handles Button1.Click
        Dim redBrush As New SolidBrush(Color.LightSalmon)
        Dim formGraphics As Graphics
        formGraphics = Me.CreateGraphics()
        formGraphics.FillRectangle(redBrush, New Rectangle(0, 0, 300, 100))
        redBrush.Dispose()
        formGraphics.FillRectangle(Brushes.White, New Rectangle(0, 100, 300, 100))

        Dim flag As New Bitmap(10, 10)
        Dim x As Integer
        Dim y As Integer
        ' Make the entire bitmap white.
        For x = 0 To flag.Height - 1
            For y = 0 To flag.Width - 1
                flag.SetPixel(x, y, Color.White)
            Next
        Next
        ' Draw a diagonal red stripe.
        For x = 0 To flag.Height - 1
            flag.SetPixel(x, x, Color.Red)
        Next
        formGraphics.DrawImage(flag, New Point(50, 50))
        formGraphics.DrawImage(flag, New Point(50, 150))
        formGraphics.DrawImage(flag, New Point(50, 250))

        Dim bm1 As Bitmap
        bm1 = Image.FromFile("..\bmp\00002-32bit.bmp")
        formGraphics.DrawImage(bm1, 100, 50)
        formGraphics.DrawImage(bm1, 100, 150)
        formGraphics.DrawImage(bm1, 100, 250)

        Dim bm2 As Bitmap
        bm2 = Image.FromFile("..\bmp\00002-32bit.bmp")
        bm2.MakeTransparent(Color.Black)
        formGraphics.DrawImage(bm2, 100, 20)
        formGraphics.DrawImage(bm2, 100, 120)
        formGraphics.DrawImage(bm2, 100, 220)

        Dim bm3 As Bitmap
        bm3 = Image.FromFile("..\bmp\00031-24bit.bmp")

        Dim bm4 As Bitmap
        Dim Gris1 As Color = Color.FromArgb(224, 223, 227)
        Dim Gris2 As Color = Color.FromArgb(255, 0, 0)
        bm4 = New Bitmap(16, 16, Imaging.PixelFormat.Format32bppArgb)
        For y = 0 To 15
            For x = 0 To 15
                Dim p As Color
                Dim r, g, b, a As Byte
                p = bm3.GetPixel(x, y)
                r = p.R
                g = p.G
                b = p.B
                If p = Gris1 Then
                    a = 0
                Else
                    a = 255
                End If

                bm4.SetPixel(x, y, Color.FromArgb(a, r, g, b))
            Next
        Next
        bm4.Save("..\bmp\00031-32bitBis.bmp")

        bm3.MakeTransparent(Color.FromArgb(&HE0DFE3))
        formGraphics.DrawImage(bm3, 125, 20)
        formGraphics.DrawImage(bm3, 125, 120)
        formGraphics.DrawImage(bm3, 125, 220)

        Dim ic1 As Icon
        ic1 = New Icon("..\bmp\00002-8bit.ico")
        formGraphics.DrawIcon(ic1, 150, 50)
        formGraphics.DrawIcon(ic1, 150, 150)
        formGraphics.DrawIcon(ic1, 150, 250)

        Dim ic2 As Icon
        ic2 = New Icon("..\bmp\00002-32bit.ico")
        formGraphics.DrawIcon(ic2, 200, 50)
        formGraphics.DrawIcon(ic2, 200, 150)
        formGraphics.DrawIcon(ic2, 200, 250)

        formGraphics.Dispose()

    End Sub

End Class