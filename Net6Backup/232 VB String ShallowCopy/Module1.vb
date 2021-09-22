' 232 VB String ShallowCopy
' 2012-02-25	PV  VS2010

Module Module1

    Sub Main()
        Dim t1 As String() = {"A", "B", "C"}
        Dim t2 As String() = t1.Clone
        t2(0) = "Z"
        Console.WriteLine(t1(0))

        Console.WriteLine()
        Console.Write("(Pause)")
        Console.ReadLine()
    End Sub

End Module