﻿' 041 VB Enumerator
' Essai d'utilisation d'un énumérateur en VB
'
' 2001-02-18    PV
' 2006-10-01 	PV		VS2005
' 2012-02-25	PV		VS2010  Il faudra attendre VS2011 pour yield return!
' 2021-09-18 	PV		VS2022, Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9

Friend Module Module1
    Public Sub Main()
        Dim t1 As New TroisEntiers(1, 2, 3)

        Dim i As Integer
        For Each i In t1
            WriteLine(i)
        Next

        'Console.ReadLine()
    End Sub

End Module
