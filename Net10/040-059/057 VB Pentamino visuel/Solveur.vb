' pentamino.cpp
' Résolution de problèmes de pentaminos (pavage)
'
' 1998-12-26    PV
' 2001-08-11 	PV		Réécriture en C# et en VB
' 2001-08-12 	PV		Affichage graphique
' 2006-10-01 	PV		VS2005
' 2010-07-19	PV		VS2010
' 2021-09-18 	PV		VS2022, Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9
' 2026-01-19	PV		Net10

#Disable Warning IDE0052 ' Remove unread private members
#Disable Warning IDE0051 ' Remove unused private members

Friend Module Constantes
    Public Const MAXLIG As Integer = 12
    Public Const MAXCOL As Integer = 5
    Public Const MAXPIECE As Integer = 12
End Module

Friend Class Jeu     ' Plan de jeu
    Private ReadOnly grille(,) As Byte

    Public Sub New()
        ReDim grille(MAXLIG - 1, MAXCOL - 1)
    End Sub

    Public Sub New(j As Jeu)
        grille = CType(j.grille.Clone(), Byte(,))
    End Sub

    Default Public Property cellule(l As Integer, c As Integer) As Byte
        Get
            Return grille(l, c)
        End Get
        Set(Value As Byte)
            grille(l, c) = Value
        End Set
    End Property

End Class

Friend Class PentaminoSolveur

    Public Event Solution(iNumSol As Integer, jeu As Jeu, ByRef bStop As Boolean)
    Private Const MAXSOLUTION As Integer = 10000

    Private Shared iNbSol As Integer '= 0
    Private Shared iNbAppelPavage As Integer '= 0
    Private Shared Pow2() As Integer

    Private Shared ReadOnly PS As PentaminoSolveur '= Nothing

    ' Tableau des pentaminos à utiliser pour le problème
    Private Shared tP() As Piece

    ' Contrôle d'arrêt
    Private Shared bStop As Boolean

    Public Sub Analyse()
        Pow2 = New Integer() {1, 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024, 2048, 4096}

        ' Préparation des pièces
        Dim P1 As New Piece(1, "I"c, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
        Dim P2 As New Piece(2, "L"c, 1, 1, 1, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0)
        Dim P3 As New Piece(3, "Y"c, 1, 1, 1, 1, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0)
        Dim P4 As New Piece(4, "N"c, 1, 1, 1, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0)
        Dim P5 As New Piece(5, "V"c, 1, 1, 1, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0)
        Dim P6 As New Piece(6, "P"c, 1, 1, 1, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0)
        Dim P7 As New Piece(7, "U"c, 1, 1, 1, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0)
        Dim P8 As New Piece(8, "Z"c, 1, 1, 0, 0, 0, 0, 1, 0, 0, 0, 0, 1, 1, 0, 0)
        Dim P9 As New Piece(9, "F"c, 1, 1, 0, 0, 0, 0, 1, 1, 0, 0, 0, 1, 0, 0, 0)
        Dim P10 As New Piece(10, "T"c, 1, 1, 1, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0)
        Dim P11 As New Piece(11, "W"c, 1, 1, 0, 0, 0, 0, 1, 1, 0, 0, 0, 0, 1, 0, 0)
        Dim P12 As New Piece(12, "X"c, 0, 1, 0, 0, 0, 1, 1, 1, 0, 0, 0, 1, 0, 0, 0)

        'P1.Dessin()
        'P2.Dessin()
        'P3.Dessin()
        'P4.Dessin()
        'P5.Dessin()
        'P6.Dessin()
        'P7.Dessin()
        'P8.Dessin()
        'P9.Dessin()
        'P10.Dessin()
        'P11.Dessin()
        'P12.Dessin()
        'Console.ReadLine()

        If MAXLIG * MAXCOL <> 5 * MAXPIECE Then
            WriteLine("Constantes MAXLIG/MAXCOL/MAXPIECE incohérentes !")
            Exit Sub
        End If

        ' Pieces a utiliser
        ReDim tP(12 - 1)

        tP(0) = P2
        tP(1) = P3
        tP(2) = P6
        tP(3) = P11
        tP(4) = P8
        tP(5) = P4
        tP(6) = P5
        tP(7) = P10
        tP(8) = P9
        tP(9) = P1
        tP(10) = P7
        tP(11) = P12

        ' Plan à paver
        Dim j As New Jeu()

        ' Pavage à proprement parler
        bStop = False
        iNbSol = 0
        Pavage(0, 0, j, Pow2(MAXPIECE) - 1)
    End Sub

    Public Sub Pavage(lstart As Integer, cstart As Integer, jeu As Jeu, iMasquePieces As Integer)
        Dim l, c As Integer
        Dim bTrouvé As Boolean = False

        If bStop Or (iNbSol > MAXSOLUTION) Then Return

        iNbAppelPavage += 1

        ' On cherche une case vide à couvrir, de gauche à droite, de haut en bas
        For l = 0 To MAXLIG - 1
            For c = 0 To MAXCOL - 1
                If l = 0 And c = 0 Then ' Accélération, on part de la dernière case vide trouvée
                    l = lstart
                    c = cstart
                End If

                If jeu(l, c) = 0 Then
                    bTrouvé = True
                    Exit For
                End If
            Next
            If bTrouvé Then
                Exit For
            End If
        Next

        ' Si on n'en a pas trouvé, c'est que le pavage est terminé !
        If l = MAXLIG And c = MAXCOL Then
            iNbSol += 1
            RaiseEvent Solution(iNbSol, jeu, bStop)

#If TraceSolution Then
      WriteLine("Solution {0} trouvée", iNbSol)
      For l = 0 To MAXLIG - 1
        For c = 0 To MAXCOL - 1
          Console.Write("{0:D2} ", tP(jeu(l, c) - 1).hNumPiece)
        Next
        WriteLine()
      Next
      WriteLine()
      Console.ReadLine()
#End If

            Exit Sub
        End If

        ' On cherche parmi toutes les pieces qui restent une pièce pour couvrir la case vide
        Dim i, j As Integer
        For i = 0 To MAXPIECE - 1
            If (iMasquePieces And Pow2(i)) <> 0 Then
                For j = 0 To tP(i).iNbt - 1 ' Pour chacune des transformations
                    Dim ca As Carre55 = tP(i).c(j)
                    Dim l2, c2 As Integer
                    Dim bCollision As Boolean

                    ' Trop large,  Trop haut, Doit être décalée trop à gauche: on continue
                    If c + ca.cmax - ca.iOffsetCol > MAXCOL Or l + ca.lmax > MAXLIG Or c < ca.iOffsetCol Then
                        GoTo Cont
                    End If

                    bCollision = False
                    For l2 = 0 To ca.lmax - 1
                        For c2 = 0 To ca.cmax - 1
                            If ca.tMotif(l2, c2) And jeu(l + l2, c + c2 - ca.iOffsetCol) <> 0 Then ' Case déjà occupée
                                bCollision = True
                                Exit For
                            End If
                        Next
                        If bCollision Then Exit For
                    Next

                    If Not bCollision Then
                        ' Pièce valable! On la place
                        Dim jeu2 As New Jeu(jeu)

                        For l2 = 0 To ca.lmax - 1
                            For c2 = 0 To ca.cmax - 1
                                If ca.tMotif(l2, c2) Then jeu2(l + l2, c + c2 - ca.iOffsetCol) = CByte(i + 1)
                            Next
                        Next

                        ' On continue avec les pièces qui restent
                        Pavage(l, c, jeu2, iMasquePieces And Not Pow2(i))
                    End If

Cont:
                Next
            End If
        Next

    End Sub

End Class
