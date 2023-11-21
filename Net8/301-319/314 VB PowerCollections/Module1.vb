' PowerCollections
'
' 2008-08-21    PV
' 2012-02-25 	PV		VS2010
' 2021-09-20 	PV		VS2022; Net6; Nuget XAct.Wintellect.PowerCollections
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8

Imports System.Console
Imports Wintellect.PowerCollections

Module Module1

    Sub Main()
        TestSet()
        TestPair()
    End Sub

    ' A hashed collection of objects, without duplicates, and without an ordering.
    ' Adding, removing, and testing membership is fast (near constant time).
    ' Similar to a HashTable with no value type, but additionally having set operations
    ' like Union, Intersection, Difference.
    Sub TestSet()
        Dim s1 As New [Set](Of Integer) From {
            1,
            2,
            3,
            4,
            5
        }
        WriteLine("Set ----------")
        Write("s1:")
        For Each i As Integer In s1
            Write(" "c)
            Write(i)
        Next
        WriteLine()

        Dim s2 As New [Set](Of Integer) From {
            2,
            3,
            5,
            7,
            11
        }
        Write("s2:")
        For Each i As Integer In s2
            Write(" "c)
            Write(i)
        Next
        WriteLine()

        Dim s3 As [Set](Of Integer) = s1.Intersection(s2)
        Write("Intersection:")
        For Each i As Integer In s3
            Write(" "c)
            Write(i)
        Next
        WriteLine()

        Dim s4 As [Set](Of Integer) = s1.Union(s2)
        Write("Union:")
        For Each i As Integer In s4
            Write(" "c)
            Write(i)
        Next
        WriteLine()

        Dim s5 As [Set](Of Integer) = s1.Difference(s2)
        Write("Difference (s1.Difference(s2)):")
        For Each i As Integer In s5
            Write(" "c)
            Write(i)
        Next
        WriteLine()

    End Sub

    Sub TestPair()
        Dim C1, C2, C3 As Pair(Of Integer, String)
        C1 = New Pair(Of Integer, String)(1, "bleu")
        C2 = New Pair(Of Integer, String)(2, "blanc")
        C3 = New Pair(Of Integer, String)(3, "rouge")

        Dim d As New Dictionary(Of Pair(Of Integer, String), String) From {
            {C1, "blue"},
            {C2, "white"},
            {C3, "red"}
        }

        'Stop
    End Sub

End Module
