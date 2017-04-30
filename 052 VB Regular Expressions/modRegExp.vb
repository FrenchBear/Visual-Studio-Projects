' Essai d'utilisation d'expression régulière
' 2001-06-26    PV
' 2006-10-01    PV  VS2005
' 2012-02-25	PV  VS2010


Imports System.Text.RegularExpressions


Module modRegExp

    Public Function bCtrlFournisseurRE(ByVal sFour As String) As Boolean
        Dim r As Regex
        r = New Regex("^[A-Z]{1,8}\.([0-9]{1,3}|2A|2B)(\.[0-9]{1,3}){1,3}(\.CEE)?(-.*)?")
        bCtrlFournisseurRE = r.IsMatch(sFour)
    End Function

End Module




Module AnalyseTexte
    Private sText As String     ' Texte à analyser
    Private iPos As Integer     ' Position courante


    Private Function Terminé() As Boolean
        Terminé = iPos > Len(sText)
    End Function


    Private Sub Abort()
        Err.Raise(1000)
    End Sub

    Private Sub Success()
        Err.Raise(1001)
    End Sub



    Private Sub Avance(ByVal c As String)
        If Mid(sText, iPos, Len(c)) = c Then
            iPos += Len(c)
        Else
            Abort()
        End If
    End Sub

    Private Sub AvanceChiffre()
        If Mid(sText, iPos, 1) Like "#" Then
            iPos += 1
        Else
            Abort()
        End If
    End Sub

    Private Sub AvanceChiffreouAouB()
        If Mid(sText, iPos, 1) Like "[AB0-9]" Then
            iPos += 1
        Else
            Abort()
        End If
    End Sub


    Private Function Suivant(ByVal c As String) As Boolean
        Suivant = Mid(sText, iPos, Len(c)) = c
    End Function

    Private Function SuivantChiffre() As Boolean
        SuivantChiffre = Mid(sText, iPos, 1) Like "#"
    End Function




    Public Function bCtrlFournisseurA(ByVal sFour As String) As Boolean
        sText = sFour
        iPos = 1

        Dim iEtat As Integer = 1    ' Etat initial de l'automate

        Try

            Do
                Select Case iEtat
                    Case 1          ' Début du texte
                        Avance("F.")
                        AvanceChiffre()
                        AvanceChiffreouAouB()
                        Avance(".")
                        iEtat = 2

                    Case 2          ' Immédiatement après un point
                        If SuivantChiffre() Then
                            AvanceChiffre()
                            iEtat = 3
                        ElseIf Suivant("CEE") Then
                            Avance("CEE")
                            iEtat = 4
                        Else
                            Abort()
                        End If

                    Case 3          ' Après un chiffre
                        If SuivantChiffre() Then
                            AvanceChiffre()
                        ElseIf Suivant(".") Then
                            Avance(".")
                            iEtat = 2
                        Else
                            iEtat = 4
                        End If

                    Case 4          ' Fin de séquence
                        If Suivant("-") Then
                            Success()
                        ElseIf Terminé() Then
                            Success()
                        Else
                            Abort()
                        End If

                End Select
            Loop

        Catch
            bCtrlFournisseurA = Err.Number = 1001

        End Try

    End Function
End Module

