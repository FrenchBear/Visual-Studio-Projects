' Cordic algorithm for tan calculations
' Source: http://www.jacques-laporte.org/LeSecretDesAlgorithmes.htm
' 2008-12-28    PV
' 2012-02-25	PV  VS2010

Module CordicCalculation

    ' Precision
    Const n As Integer = 15

    ' Table of atn(1), atn(0.1), atn(0.01), ... (here calculated, but should actually be constants in the code)
    ReadOnly a(n) As Double

    Sub Main()
        CalculateConstants()

        For x As Double = -1 To 7 Step 1.0
            Dim t1 As Double = Math.Tan(x)
            Dim t2 As Double = CordicTanRadian(x)
            Console.WriteLine("x={0}" & vbCrLf & "Math.Tan(x)={1}" & vbCrLf & "CordicTan(x)={2}", x, t1, t2)
        Next
        Console.WriteLine()
        Console.Write("(Pause)")
        Console.ReadLine()
    End Sub

    ' Accept any angle
    Function CordicTanRadian(Θ As Double) As Double
        If Θ = 0 Then Return 0
        Dim s As SByte = Math.Sign(Θ)
        Θ = Math.Abs(Θ)
        Θ -= Math.PI * Math.Floor(Θ / Math.PI)
        If Θ > Math.PI / 2 Then
            s = -s
            Θ = Math.PI - Θ
        End If
        Return s * CordicTanCore(Θ)
    End Function

    ' Cordic algorithm
    ' Only accepts angles between 0 and Pi/2
    Function CordicTanCore(Θ As Double) As Double
        Dim i As Integer
        Dim x, y, k As Double
        x = 1.0
        y = 0.0
        k = 1.0

        For i = 0 To n
            While Θ >= a(i)
                Θ -= a(i)
                Dim tp As Double = x - k * y
                y += k * x
                x = tp
            End While
            k /= 10
        Next

        Return y / x
    End Function

    ' One-time calculation
    Sub CalculateConstants()
        Dim v As Double
        v = 1.0
        For j As Integer = 0 To n
            a(j) = Math.Atan(v)
            Console.WriteLine("{0}: {1}", v, a(j))
            v /= 10.0
        Next
    End Sub

End Module