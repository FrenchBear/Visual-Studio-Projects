' PowerCollections
' 2008-08-21    PV
' 2012-02-25	PV  VS2010


Imports Wintellect.PowerCollections

Module Module1

    Sub Main()
        TestSet()
        TestPair()

        Console.WriteLine()
        Console.Write("(Pause)")
        Console.ReadLine()
    End Sub


    ' A hashed collection of objects, without duplicates, and without an ordering. 
    ' Adding, removing, and testing membership is fast (near constant time). 
    ' Similar to a HashTable with no value type, but additionally having set operations 
    ' like Union, Intersection, Difference.
    Sub TestSet()
        Dim s1 As New [Set](Of Integer)
        s1.Add(1)
        s1.Add(2)
        s1.Add(3)
        s1.Add(4)
        s1.Add(5)
        Console.WriteLine("Set ----------")
        Console.Write("s1:")
        For Each i As Integer In s1
            Console.Write(" "c)
            Console.Write(i)
        Next
        Console.WriteLine()

        Dim s2 As New [Set](Of Integer)
        s2.Add(2)
        s2.Add(3)
        s2.Add(5)
        s2.Add(7)
        s2.Add(11)
        Console.Write("s2:")
        For Each i As Integer In s2
            Console.Write(" "c)
            Console.Write(i)
        Next
        Console.WriteLine()

        Dim s3 As [Set](Of Integer) = s1.Intersection(s2)
        Console.Write("Intersection:")
        For Each i As Integer In s3
            Console.Write(" "c)
            Console.Write(i)
        Next
        Console.WriteLine()

        Dim s4 As [Set](Of Integer) = s1.Union(s2)
        Console.Write("Union:")
        For Each i As Integer In s4
            Console.Write(" "c)
            Console.Write(i)
        Next
        Console.WriteLine()

        Dim s5 As [Set](Of Integer) = s1.Difference(s2)
        Console.Write("Difference (s1.Difference(s2)):")
        For Each i As Integer In s5
            Console.Write(" "c)
            Console.Write(i)
        Next
        Console.WriteLine()

    End Sub


    Sub TestPair()
        Dim C1, C2, C3 As Pair(Of Integer, String)
        C1 = New Pair(Of Integer, String)(1, "bleu")
        C2 = New Pair(Of Integer, String)(2, "blanc")
        C3 = New Pair(Of Integer, String)(3, "rouge")

        Dim d As New Dictionary(Of Pair(Of Integer, String), String)
        d.Add(C1, "blue")
        d.Add(C2, "white")
        d.Add(C3, "red")

        'Stop
    End Sub
End Module
