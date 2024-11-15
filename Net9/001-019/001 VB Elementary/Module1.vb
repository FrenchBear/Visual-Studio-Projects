' 2001 PV
'
' 2006-10-01 	PV		VS2005
' 2010-05-01 	PV		VS2010
' 2021-09-17 	PV		VS2022/Net6
' 2023-01-10 	PV		Net7
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9

Friend Module Module1
    Public Sub Main()
        Dim a As Double
        a = 1.0E-305
        For i As Integer = 27 To 30
            a /= 10
            WriteLine("a={0}", a)
        Next

        Dim b As String
        b = 1234
        WriteLine("b={0}", b)

        Console.ReadLine()
    End Sub

End Module
