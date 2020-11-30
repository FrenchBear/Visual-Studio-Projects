﻿' Module ArithmeticStuff
' Various basic arithmetic functions
' 2012-04-09    PV

Module ArithmeticStuff

    ''' <summary>
    ''' Return Greatest Common Divisor using Euclidean Algorithm
    ''' </summary>
    Public Function Gcd(a As Long, b As Long) As Long
        If a <= 0 Or b <= 0 Then Throw New ArgumentException("Negative or zero argument not supported")
        While b <> 0
            Dim t As Long = b
            b = a Mod b
            a = t
        End While
        Return a
    End Function

    ''' <summary>
    ''' Return Smallest Common Multiple
    ''' </summary>
    Public Function Scm(a As Long, b As Long) As Long
        If a <= 0 Then Throw New ArgumentException("Negative or zero argument not supported", "a")
        If b <= 0 Then Throw New ArgumentException("Negative or zero argument not supported", "b")
        Return a * b / Gcd(a, b)
    End Function

End Module