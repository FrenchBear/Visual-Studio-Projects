' 2006-10-01    PV  VS2005
' 2021-09-18    PV  VS2022, Net6

Public Class Piece
    Public hNumPiece As Short   ' N° dans le jeu Katamino
    Public cPiece As Char   ' Lettre
    Public c As Carre55()    ' 8 transformations maxi
    Public iNbt As Integer   ' Nb de transformations

    '''''''''''''''''''''''''''''''''''
    ' Construction/Destruction
    '''''''''''''''''''''''''''''''''''

    Public Sub New(hNP As Short, cP As Char,
i00 As Integer, i01 As Integer, i02 As Integer, i03 As Integer, i04 As Integer,
i10 As Integer, i11 As Integer, i12 As Integer, i13 As Integer, i14 As Integer,
i20 As Integer, i21 As Integer, i22 As Integer, i23 As Integer, i24 As Integer)
        ReDim c(8 - 1)
        hNumPiece = hNP
        cPiece = cP
        c(0) = New Carre55(i00, i01, i02, i03, i04, i10, i11, i12, i13, i14, i20, i21, i22, i23, i24)
        iNbt = 1
        If i00 + i01 + i02 + i03 + i04 + i10 + i11 + i12 + i13 + i14 + i20 + i21 + i22 + i23 + i24 <> 5 Then
            WriteLine("Définition de la pièce {0} incorrecte", hNP)
        End If

        Dim i, j As Integer
        For i = 1 To 7
            Dim ct As Carre55 = c(0).Transformation(i)
            Dim bDejaVu As Boolean = False

            For j = 0 To iNbt - 1
                If Carre55.Egalite(c(j), ct) Then
                    bDejaVu = True
                    Exit For
                End If
            Next
            If Not bDejaVu Then
                c(iNbt) = ct
                iNbt += 1
            End If
        Next
    End Sub

    ' Traces
    Public Sub Dessin()
        WriteLine("Pièce {0} {1} iNbt={2}", hNumPiece, cPiece, iNbt)
    End Sub

End Class