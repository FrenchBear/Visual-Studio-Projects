' 232 VB String ShallowCopy
'
' 2012-02-25	PV  VS2010
' 2021-09-20    PV  VS2022; Net6

Module Module1

    Sub Main()
        Dim t1 As String() = {"A", "B", "C"}
        Dim t2 As String() = t1.Clone
        t2(0) = "Z"
        Console.WriteLine(t1(0))
    End Sub

End Module