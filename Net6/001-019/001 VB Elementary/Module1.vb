' 2001 PV
' 2006-10-01    PV  VS2005
' 2010-05-01    PV  VS2010
' 2021-09-17    PV  VS2022/Net6

Module Module1

    Sub Main()
        Dim a As Double
        a = 1.0E-305
        For i As Integer = 27 To 30
            a /= 10
            WriteLine("a={0}", a)
        Next

        Dim b As String
        b = CStr(1234)
        WriteLine("b={0}", b)

        Console.ReadLine()
    End Sub

End Module