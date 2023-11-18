' 416 VB Boxing and Rational
'
' 2012-01-30    PV
' 2021-09-23 	PV		VS2022; Net6
' 2023-01-10	PV		Net7

Imports System.Diagnostics.CodeAnalysis

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

        Dim rns As New Rational(5, 10)
        Dim rs1 As String = String.Format("{0}", rns)
        Dim rs2 As String = String.Format("{0:reduced}", rns)

        Stop
    End Sub

    Function A(x As Object, y As Object) As Object
        Return x + y
    End Function

End Module

Class Entier
    Private ReadOnly _n As Integer

    Public Sub New(i As Integer)
        _n = i
    End Sub

    Public Shared Operator +(e1 As Entier, e2 As Entier) As Entier
        Return New Entier(e1._n + e2._n)
    End Operator

End Class

<DebuggerDisplay("{_numerator}/{_denominator}")>
Structure Rational
    Implements IFormattable

    Private ReadOnly _numerator As Integer
    Private ReadOnly _denominator As Integer

    Public Sub New(n As Integer, d As Integer)
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

    Public Shared Widening Operator CType(i As Integer) As Rational
        Return New Rational(i, 1)
    End Operator

    ' Narrowing = explicit in C#
    ' Possible loss of precision and can throw exceptions
    Public Shared Narrowing Operator CType(r As Rational) As Double
        Return CDbl(r._numerator) / CDbl(r._denominator)
    End Operator

    Public Shared Operator +(lhs As Rational, rhs As Rational) As Rational
        Dim g As Integer = Gcd(lhs._denominator, rhs._denominator)
        Dim d2 As Integer = lhs._denominator * rhs._denominator / g
        Dim n2 As Integer = lhs._numerator * g / lhs._denominator + rhs._numerator * g / rhs._denominator
        g = Gcd(n2, d2)
        Return New Rational(n2 / g, d2 / g)
    End Operator

    Public Function Reduce() As Rational
        Dim g As Integer = Gcd(_numerator, _denominator)
        If g = 1 Then
            Return g
        Else
            Return New Rational(_numerator / g, _denominator / g)
        End If
    End Function

    ''' <summary>
    ''' Return Greatest Common Divisor using Euclidean Algorithm
    ''' </summary>
    Private Shared Function Gcd(a As Integer, b As Integer) As Integer
        While b <> 0
            Dim t As Integer = b
            b = a Mod b
            a = t
        End While
        Return a
    End Function

    Public Shared Operator =(lhs As Rational, rhs As Rational) As Boolean
        Dim r1 As Rational = lhs.Reduce
        Dim r2 As Rational = rhs.Reduce
        Return r1._numerator = r2._numerator AndAlso r1._denominator = r2._denominator
    End Operator

    Public Shared Operator <>(lhs As Rational, rhs As Rational) As Boolean
        Return Not lhs = rhs
    End Operator

    Public Function ToString1(format As String, formatProvider As IFormatProvider) As String Implements IFormattable.ToString
        If format = "reduced" Then
            Return Me.Reduce.ToString
        Else
            Return Me.ToString
        End If
    End Function

    Public Overrides Function Equals(<NotNullWhen(True)> obj As Object) As Boolean
        ' Check for null And compare run-time types.
        If obj Is Nothing OrElse Not Me.GetType().Equals(obj.GetType) Then Return False
        Return Me = CType(obj, Rational)
    End Function

    Public Overrides Function GetHashCode() As Integer
        Return _numerator.GetHashCode() Xor _denominator.GetHashCode()
    End Function

End Structure
