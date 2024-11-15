﻿' 237 VB Array.Sort
'
' 2012-02-25	PV		VS2010
' 2021-09-20 	PV		VS2022; Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9

Friend Module Module1
    Public Sub Main()
        Dim tc() As Colonne = New Colonne() {New Colonne(1, "PK"), New Colonne(3, "CreatedOn"), New Colonne(2, "Nom"), New Colonne(2, "Age")}

        Dim tc2() As Colonne = tc.Clone
        Array.Sort(tc2, New MyColumnComparer)
        For Each c As Colonne In tc2
            WriteLine("{0}: {1}", c.rang, c.nom)
        Next
    End Sub

    Public Class MyColumnComparer
        Implements IComparer

        Public Function Compare(x As Object, y As Object) As Integer Implements IComparer.Compare
            Return CType(x, Colonne).rang - CType(y, Colonne).rang
        End Function

    End Class

End Module

Friend Class Colonne
    Public rang As Integer
    Public nom As String

    Public Sub New(rang As Integer, nom As String)
        Me.rang = rang
        Me.nom = nom
    End Sub

End Class
