' 215 VB Illusion
'
' 2012-02-25	PV  VS2010
' 2021-09-19    PV  VS2022; Net6

Imports System.Drawing.Imaging

#Disable Warning IDE1006 ' Naming Styles

Public Class Form1
    Dim picBitmap As Bitmap
    Dim g As Graphics

    ReadOnly Black As Color = Color.Black
    ReadOnly White As Color = Color.White

    ' Paramétrage du dessin
    Const k1_init As Single = 0.05       ' Marge des petits carrés

    Const k2_init As Single = 0.27        ' Taille d'un petit carré

    Dim k1 As Single = k1_init
    Dim k2 As Single = k2_init

    ' Module de dessin
    Dim iLastSize As Integer

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Dim x1, y1, iSize As Integer
        x1 = Pic.Size.Width \ 15
        y1 = Pic.Size.Height \ 15
        If x1 < y1 Then iSize = x1 Else iSize = y1
        If iSize < 1 Then Exit Sub
        If iSize = iLastSize Then Exit Sub
        iLastSize = iSize

        Redraw()
    End Sub

    Public Sub Redraw()
        picBitmap = New Bitmap(Pic.Size.Width, Pic.Size.Height, PixelFormat.Format24bppRgb)
        g = Graphics.FromImage(picBitmap)
        g.Clear(Color.PaleGoldenrod)
        Pic.BackgroundImage = picBitmap

        For l As Integer = 0 To 14
            For c As Integer = 0 To 14
                Dim bBlackSquare, bNO, bNE, bSO, bSE As Boolean
                bBlackSquare = ((l + c) And 1) = 0
                bNO = False
                bNE = False
                bSO = False
                bSE = False
                If (l - 7) ^ 2 + (c - 7) ^ 2 <= 6.2 ^ 2 Then
                    If l = 7 Then
                        If c < 7 Then
                            bNE = True
                            bSE = True
                        ElseIf c > 7 Then
                            bNO = True
                            bSO = True
                        End If
                    ElseIf c = 7 Then
                        If l < 7 Then
                            bSO = True
                            bSE = True
                        Else
                            bNO = True
                            bNE = True
                        End If
                    ElseIf (l < 7 And c < 7) Or (l > 7 And c > 7) Then
                        bNE = True
                        bSO = True
                    Else
                        bNO = True
                        bSE = True
                    End If
                End If

                g.FillRectangle(New SolidBrush(IIf(bBlackSquare, Black, White)), iLastSize * c, iLastSize * l, iLastSize, iLastSize)
                If bNO Then g.FillRectangle(New SolidBrush(IIf(bBlackSquare, White, Black)), iLastSize * (c + k1), iLastSize * (l + k1), iLastSize * k2, iLastSize * k2)
                If bNE Then g.FillRectangle(New SolidBrush(IIf(bBlackSquare, White, Black)), iLastSize * (c + 1 - k1 - k2) - 1, iLastSize * (l + k1), iLastSize * k2, iLastSize * k2)
                If bSO Then g.FillRectangle(New SolidBrush(IIf(bBlackSquare, White, Black)), iLastSize * (c + k1), iLastSize * (l + 1 - k1 - k2) - 1, iLastSize * k2, iLastSize * k2)
                If bSE Then g.FillRectangle(New SolidBrush(IIf(bBlackSquare, White, Black)), iLastSize * (c + 1 - k1 - k2) - 1, iLastSize * (l + 1 - k1 - k2) - 1, iLastSize * k2, iLastSize * k2)
            Next
        Next
    End Sub

    Private Sub Pic_Click(sender As Object, e As EventArgs) Handles Pic.Click
        Clipboard.Clear()
        Clipboard.SetImage(picBitmap)
        Beep()
    End Sub

    Private Sub tbk1_Scroll(sender As Object, e As EventArgs) Handles tbk1.Scroll
        k1 = tbk1.Value / 100
        lblk1.Text = "k1 " & k1
        Redraw()
    End Sub

    Private Sub tbk2_Scroll(sender As Object, e As EventArgs) Handles tbk2.Scroll
        k2 = tbk2.Value / 100
        lblk2.Text = "k2 " & k2
        Redraw()
    End Sub

End Class