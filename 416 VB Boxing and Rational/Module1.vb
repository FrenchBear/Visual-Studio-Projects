' 416 VB Boxing and Rational
' 2012-01-30 PV

Module Module1

    Sub Main()
        Dim i As Integer = A(5, 7)
        Dim s As String = A("bon", "jour")

        Dim o1 As New Entier(3)
        Dim o2 As New Entier(5)
        Dim o As Object = A(o1, o2)

        Dim r1 As New Rational(1, 2)
        Dim r2 As New Rational(3, 2)
        Dim r3 As Rational = A(r1, r2)

        Dim rns As Rational = New Rational(5, 10)
        Dim rs1 As String = String.Format("{0}", rns)
        Dim rs2 As String = String.Format("{0:reduced}", rns)

        Stop
    End Sub

    Function A(ByVal x As Object, ByVal y As Object) As Object
        Return x + y
    End Function

End Module


Class Entier
    Private ReadOnly _n As Integer

    Public Sub New(ByVal i As Integer)
        _n = i
    End Sub

    Public Shared Operator +(ByVal e1 As Entier, ByVal e2 As Entier) As Entier
        Return New Entier(e1._n + e2._n)
    End Operator
End Class


<DebuggerDisplay("{_numerator}/{_denominator}")>
Structure Rational
    Implements IFormattable

    Private ReadOnly _numerator As Integer
    Private ReadOnly _denominator As Integer

    Public Sub New(ByVal n As Integer, ByVal d As Integer)
        _numerator = n
        _denominator = d
    End Sub

    Public ReadOnly Property Numerator As Integer
        Get
            Return _numerator
        End Get
    End Property

    Public ReadOnly Property Denominator As Integer
        Get
            Return _denominator
        End Get
    End Property

    Public Overrides Function ToString() As String
        Return _numerator.ToString & "/" & _denominator.ToString
    End Function

    Public Shared Widening Operator CType(ByVal i As Integer) As Rational
        Return New Rational(i, 1)
    End Operator

    ' Narrowing = explicit in C#
    ' Possible loss of precision and can throw exceptions
    Public Shared Narrowing Operator CType(ByVal r As Rational) As Double
        Return CDbl(r._numerator) / CDbl(r._denominator)
    End Operator

    Public Shared Operator +(ByVal lhs As Rational, ByVal rhs As Rational) As Rational
        Dim g As Integer = gcd(lhs._denominator, rhs._denominator)
        Dim d2 As Integer = lhs._denominator * rhs._denominator / g
        Dim n2 As Integer = lhs._numerator * g / lhs._denominator + rhs._numerator * g / rhs._denominator
        g = gcd(n2, d2)
        Return New Rational(n2 / g, d2 / g)
    End Operator

    Public Function Reduce() As Rational
        Dim g As Integer = gcd(_numerator, _denominator)
        If g = 1 Then
            Return g
        Else
            Return New Rational(_numerator / g, _denominator / g)
        End If
    End Function

    ''' <summary>
    ''' Return Greatest Common Divisor using Euclidean Algorithm
    ''' </summary>
    Private Shared Function gcd(ByVal a As Integer, ByVal b As Integer) As Integer
        While b <> 0
            Dim t As Integer = b
            b = a Mod b
            a = t
        End While
        Return a
    End Function


    Public Shared Operator =(ByVal lhs As Rational, ByVal rhs As Rational) As Boolean
        Dim r1 As Rational = lhs.Reduce
        Dim r2 As Rational = rhs.Reduce
        Return r1._numerator = r2._numerator AndAlso r1._denominator = r2._denominator
    End Operator

    Public Shared Operator <>(ByVal lhs As Rational, ByVal rhs As Rational) As Boolean
        Return Not lhs = rhs
    End Operator


    Public Function ToString1(format As String, formatProvider As System.IFormatProvider) As String Implements System.IFormattable.ToString
        If format = "reduced" Then
            Return Me.Reduce.ToString
        Else
            Return Me.ToString
        End If
    End Function

End Structure