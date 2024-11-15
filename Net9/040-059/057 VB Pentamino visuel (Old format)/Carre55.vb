' 2021-09-18 	PV		VS2022, Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9

Imports System.Console

#Disable Warning CA1822 ' Mark members as static

Public Class Carre55
    Public tMotif(,) As Boolean
    Public lmax, cmax As Integer  ' Encombrement de la pièce
    Public iOffsetCol As Integer  ' Décalage de colonne pour occuper la cellule (0, 0)

    Function B(x As Integer) As Boolean
        Return x <> 0
    End Function

    Sub New()
        ReDim tMotif(5 - 1, 5 - 1)
        Dim l, c As Integer
        For l = 0 To 4
            For c = 0 To 4
                tMotif(l, c) = False
            Next
        Next
        lmax = 0
        cmax = 0
        iOffsetCol = 0
    End Sub

    Sub New(i00 As Integer, i01 As Integer, i02 As Integer, i03 As Integer, i04 As Integer,
i10 As Integer, i11 As Integer, i12 As Integer, i13 As Integer, i14 As Integer,
i20 As Integer, i21 As Integer, i22 As Integer, i23 As Integer, i24 As Integer)

        ReDim tMotif(5 - 1, 5 - 1)

        tMotif(0, 0) = B(i00) : tMotif(0, 1) = B(i01) : tMotif(0, 2) = B(i02) : tMotif(0, 3) = B(i03) : tMotif(0, 4) = B(i04)
        tMotif(1, 0) = B(i10) : tMotif(1, 1) = B(i11) : tMotif(1, 2) = B(i12) : tMotif(1, 3) = B(i13) : tMotif(1, 4) = B(i14)
        tMotif(2, 0) = B(i20) : tMotif(2, 1) = B(i21) : tMotif(2, 2) = B(i22) : tMotif(2, 3) = B(i23) : tMotif(2, 4) = B(i24)
        tMotif(3, 0) = B(0) : tMotif(3, 1) = B(0) : tMotif(3, 2) = B(0) : tMotif(3, 3) = B(0) : tMotif(3, 4) = B(0)
        tMotif(4, 0) = B(0) : tMotif(4, 1) = B(0) : tMotif(4, 2) = B(0) : tMotif(4, 3) = B(0) : tMotif(4, 4) = B(0)

        lmax = 3
        If i20 + i21 + i22 + i23 + i24 = 0 Then lmax = 2
        If i10 + i11 + i12 + i13 + i14 = 0 Then lmax = 1

        cmax = 5
        If i04 + i14 + i24 = 0 Then cmax = 4
        If i03 + i13 + i23 = 0 Then cmax = 3
        If i02 + i12 + i22 = 0 Then cmax = 2
        If i01 + i11 + i21 = 0 Then cmax = 1

        MkOffset()
    End Sub

    ' Détermine la propriété iOffsetCol, c'est à dire le nombre de colonnes qu'il
    ' faut translater le dessin à gauche pour occuper la cellule (0, 0)
    Sub MkOffset()
        If tMotif(0, 0) Then
            iOffsetCol = 0
        ElseIf tMotif(0, 1) Then
            iOffsetCol = 1
        ElseIf tMotif(0, 2) Then
            iOffsetCol = 2
        ElseIf tMotif(0, 3) Then
            iOffsetCol = 3
        Else
            iOffsetCol = 4
        End If
    End Sub

    ' Opérateur de comparaison
    Public Shared Function Egalite(l As Carre55, k As Carre55) As Boolean
        Return l.lmax = k.lmax And l.cmax = k.cmax And
        l.tMotif(0, 0) = k.tMotif(0, 0) And l.tMotif(0, 1) = k.tMotif(0, 1) And l.tMotif(0, 2) = k.tMotif(0, 2) And l.tMotif(0, 3) = k.tMotif(0, 3) And l.tMotif(0, 4) = k.tMotif(0, 4) And
        l.tMotif(1, 0) = k.tMotif(1, 0) And l.tMotif(1, 1) = k.tMotif(1, 1) And l.tMotif(1, 2) = k.tMotif(1, 2) And l.tMotif(1, 3) = k.tMotif(1, 3) And l.tMotif(1, 4) = k.tMotif(1, 4) And
        l.tMotif(2, 0) = k.tMotif(2, 0) And l.tMotif(2, 1) = k.tMotif(2, 1) And l.tMotif(2, 2) = k.tMotif(2, 2) And l.tMotif(2, 3) = k.tMotif(2, 3) And l.tMotif(2, 4) = k.tMotif(2, 4) And
        l.tMotif(3, 0) = k.tMotif(3, 0) And l.tMotif(3, 1) = k.tMotif(3, 1) And l.tMotif(3, 2) = k.tMotif(3, 2) And l.tMotif(3, 3) = k.tMotif(3, 3) And l.tMotif(3, 4) = k.tMotif(3, 4) And
        l.tMotif(4, 0) = k.tMotif(4, 0) And l.tMotif(4, 1) = k.tMotif(4, 1) And l.tMotif(4, 2) = k.tMotif(4, 2) And l.tMotif(4, 3) = k.tMotif(4, 3) And l.tMotif(4, 4) = k.tMotif(4, 4)
    End Function

    ' Transformations

    ' Transformation de ligne
    Function TL(iT As Integer, l As Integer, c As Integer) As Integer
        Select Case iT
            Case 1 : Return c
            Case 2 : If l < lmax Then Return lmax - 1 - l Else Return l
            Case 3 : If c < cmax Then Return cmax - 1 - c Else Return c
            Case 4 : Return l
            Case 5 : If c < cmax Then Return cmax - 1 - c Else Return c
            Case 6 : If l < lmax Then Return lmax - 1 - l Else Return c
            Case 7 : Return c
        End Select
        Return l ' cas 0
    End Function

    ' Transformation de colonne
    Function TC(iT As Integer, l As Integer, c As Integer) As Integer
        Select Case iT
            Case 1 : If l < lmax Then Return lmax - 1 - l Else Return l
            Case 2 : If c < cmax Then Return cmax - 1 - c Else Return c
            Case 3 : Return l
            Case 4 : If c < cmax Then Return cmax - 1 - c Else Return c
            Case 5 : If l < lmax Then Return lmax - 1 - l Else Return l
            Case 6 : Return c
            Case 7 : Return l
        End Select
        Return c ' cas 0
    End Function

    ' Transformations
    ' 0: Identité
    ' 1: 90°  sens horaire
    ' 2: 180°
    ' 3: 270° sens horaire
    ' 4: miroir Hz
    ' 5: miroir Hz + 90°  sens horaire
    ' 6: miroir Hz + 180°
    ' 7: miroir Hz + 270° sens horaire

    Public Function Transformation(iT As Integer) As Carre55
        Dim ct As New Carre55()
        Dim l, c As Integer

        For l = 0 To lmax - 1
            For c = 0 To cmax - 1
                ct.tMotif(TL(iT, l, c), TC(iT, l, c)) = tMotif(l, c)
            Next
        Next

        If (iT And 1) <> 0 Then
            ct.lmax = cmax
            ct.cmax = lmax
        Else
            ct.lmax = lmax
            ct.cmax = cmax
        End If

        ct.MkOffset()

        Return ct
    End Function

    Public Sub Dessin()
        Dim l, c As Integer

        For l = 0 To 4
            For c = 0 To 4
                If tMotif(l, c) Then
                    Write("\xdb\xdb")
                Else
                    Write("\xfa\xfa")
                End If
            Next
            WriteLine()
        Next
        WriteLine("Offset: {0}", iOffsetCol)
    End Sub

End Class
