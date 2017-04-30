' Partition
' Essais de dessins de partitions
'
' 2010-01-26    PV
' 2012-02-25	PV  VS2010


Imports System.Drawing.Imaging


Public Class PartitionForm
    'ReadOnly colBackground As Color = Color.PaleGoldenrod
    ReadOnly colBackground As Color = Color.White

    ReadOnly xOff As Integer = 18
    ReadOnly yOff As Integer = 60

    ReadOnly RowHeight As Integer = 250
    ReadOnly KeyHeight As Integer = 110
    ReadOnly KeyWidth As Integer = 70
    ReadOnly LineHeight As Integer = 10

    ReadOnly MeasureWidth As Integer = 200
    ReadOnly TempsWidth As Integer = 50

    Private Sub StartButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StartButton.Click
        Dim w As Integer = 2 * xOff + KeyWidth + 4 * MeasureWidth
        Dim h As Integer = 2 * yOff + 4 * RowHeight + KeyHeight + 50
        Dim picBitmap As Bitmap = New Bitmap(w, h, PixelFormat.Format24bppRgb)
        Dim g As Graphics = Graphics.FromImage(picBitmap)
        g.Clear(colBackground)

        pic.Width = w
        pic.Height = h
        ContainerPanel.Refresh()

        pic.BackgroundImage = picBitmap
        pic.Refresh()

        For r As Integer = 0 To 4
            DrawArmature(g, r)
            For m As Integer = 0 To 3
                DrawRandomMeasure(g, r, m)
            Next
        Next
        pic.Refresh()

        pic.BackgroundImage.Save("c:\Partition.png", System.Drawing.Imaging.ImageFormat.Png)
    End Sub

    Private Sub DrawArmature(ByVal g As Graphics, ByVal nRow As Integer)
        DrawScore(g, xOff, xOff + KeyWidth, yOff + RowHeight * nRow)
        DrawScore(g, xOff, xOff + KeyWidth, yOff + KeyHeight + RowHeight * nRow)
        g.DrawLine(Pens.Black, xOff, yOff + RowHeight * nRow, xOff, yOff + KeyHeight + RowHeight * nRow + 4 * LineHeight)

        Dim f As Font
        f = New Font("Opus", 35, FontStyle.Regular, GraphicsUnit.Pixel, 0)
        g.DrawString("&", f, Brushes.Black, xOff + 1, yOff + RowHeight * nRow - 12)
        g.DrawString("4", f, Brushes.Black, xOff + 35, yOff + RowHeight * nRow - 32)
        g.DrawString("4", f, Brushes.Black, xOff + 35, yOff + RowHeight * nRow - 12)

        g.DrawString("?", f, Brushes.DarkBlue, xOff + 1, yOff + KeyHeight + RowHeight * nRow - 33)
        g.DrawString("4", f, Brushes.DarkBlue, xOff + 35, yOff + KeyHeight + RowHeight * nRow - 32)
        g.DrawString("4", f, Brushes.DarkBlue, xOff + 35, yOff + KeyHeight + RowHeight * nRow - 12)

        f = New Font("Opus Special", 150, FontStyle.Regular, GraphicsUnit.Pixel, 0)
        g.DrawString("{", f, Brushes.Black, xOff - 42, yOff + RowHeight * nRow - 140)
    End Sub

    Private Sub DrawScore(ByVal g As Graphics, ByVal x1 As Integer, ByVal xDelta As Integer, ByVal y As Integer)
        For l As Integer = 0 To 4
            g.DrawLine(Pens.Black, x1, y + l * LineHeight, x1 + xDelta, y + l * LineHeight)
        Next
    End Sub

    Private Sub DrawRandomMeasure(ByVal g As Graphics, ByVal nRow As Integer, ByVal nCol As Integer)
        DrawScore(g, xOff + KeyWidth + nCol * MeasureWidth, MeasureWidth, yOff + RowHeight * nRow)
        DrawScore(g, xOff + KeyWidth + nCol * MeasureWidth, MeasureWidth, yOff + KeyHeight + RowHeight * nRow)
        g.DrawLine(Pens.Black, xOff + KeyWidth + (nCol + 1) * MeasureWidth, yOff + RowHeight * nRow, xOff + KeyWidth + (nCol + 1) * MeasureWidth, yOff + KeyHeight + RowHeight * nRow + 4 * LineHeight)

        Dim r As Single, p As Integer
        For nTemps As Integer = 0 To 3
            If Rnd() < 0.5 Then
                r = Rnd()
                If r < 0.33 Then p = -2 Else If r < 0.66 Then p = 5 Else p = 12
                DrawNote(g, nRow, nCol, 0, nTemps, p, Brushes.Black, Pens.Black)
            Else
                If Rnd() < 0.5 Then p = 0 Else p = 7
                DrawNote(g, nRow, nCol, 0, nTemps, p, Brushes.Black, Pens.Black)
            End If

            If Rnd() < 0.5 Then
                If r < 0.33 Then p = -4 Else If r < 0.66 Then p = 3 Else p = 10
                DrawNote(g, nRow, nCol, 1, nTemps, p, Brushes.DarkBlue, Pens.DarkBlue)
            Else
                If Rnd() < 0.5 Then p = -2 Else p = 5
                DrawNote(g, nRow, nCol, 1, nTemps, p, Brushes.DarkBlue, Pens.DarkBlue)
            End If
        Next
    End Sub

    Private Sub DrawNote(ByVal g As Graphics, ByVal nRow As Integer, ByVal nCol As Integer, ByVal nKey As Integer, ByVal nTemps As Integer, ByVal p As Integer, ByVal br As Brush, ByVal pe As Pen)
        Dim x As Single = xOff + KeyWidth + nCol * MeasureWidth + TempsWidth / 2 + nTemps * TempsWidth - LineHeight / 2
        Dim y As Single = yOff + RowHeight * nRow + KeyHeight * nKey + (3.5 - p / 2) * LineHeight

        g.FillEllipse(br, x, y, LineHeight, LineHeight)
        If p <= 4 Then
            g.DrawLine(pe, x + LineHeight - 1, CSng(y + LineHeight / 2.0), x + LineHeight - 1, CSng(y + LineHeight / 2.0 - 3.5 * LineHeight))
        Else
            g.DrawLine(pe, x + LineHeight - 1, CSng(y + LineHeight / 2.0), x + LineHeight - 1, CSng(y + LineHeight / 2.0 + 3.5 * LineHeight))
        End If

        If p <= -1 Then
            Dim y0 As Single = yOff + RowHeight * nRow + KeyHeight * nKey + 5 * LineHeight
            g.DrawLine(pe, CSng(x - TempsWidth / 2.0 + LineHeight), y0, CSng(x + TempsWidth / 2.0), y0)
            If p <= -3 Then
                y0 = yOff + RowHeight * nRow + KeyHeight * nKey + 6 * LineHeight
                g.DrawLine(pe, CSng(x - TempsWidth / 2.0 + LineHeight), y0, CSng(x + TempsWidth / 2.0), y0)
            End If
        End If
        If p >= 9 Then
            Dim y0 As Single = yOff + RowHeight * nRow + KeyHeight * nKey - 1 * LineHeight
            g.DrawLine(pe, CSng(x - TempsWidth / 2.0 + LineHeight), y0, CSng(x + TempsWidth / 2.0), y0)
            If p >= 11 Then
                y0 = yOff + RowHeight * nRow + KeyHeight * nKey - 2 * LineHeight
                g.DrawLine(pe, CSng(x - TempsWidth / 2.0 + LineHeight), y0, CSng(x + TempsWidth / 2.0), y0)
            End If
        End If
    End Sub

End Class
