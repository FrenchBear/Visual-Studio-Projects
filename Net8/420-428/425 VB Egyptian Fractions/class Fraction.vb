' class Fraction
' Simple implementation of a fraction
'
' 2012-04-09    PV
' 2021-09-23 	PV		VS2022; Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8

Imports System.Globalization

Public Class Fraction : Implements IFormattable, IEquatable(Of Fraction)
    Private ReadOnly n As Long
    Private ReadOnly d As Long

    Public Sub New(Numerator As Long, Denominator As Long)
        If Denominator = 0 Then Throw New DivideByZeroException("A fraction denominator can't be 0")
        If Numerator = 0 Then
            n = 0                                               ' Unique convention for 0
            d = 1
        Else
            Dim pgdc As Long = Gcd(Numerator, Denominator)      ' Only store reduced fractions
            If Denominator < 0 Then
                Numerator = -Numerator                          ' Sign is at Numerator
                Denominator = -Denominator                      ' Denominator is always > 0
            End If
            n = Numerator / pgdc
            d = Denominator / pgdc
        End If
    End Sub

    Public Sub New(n As Long)
        Me.New(n, 1)
    End Sub

    Public ReadOnly Property Numerator As Long
        Get
            Return n
        End Get
    End Property

    Public ReadOnly Property Denominator As Long
        Get
            Return d
        End Get
    End Property

    Public Overrides Function ToString() As String
        Return ToString("G", CultureInfo.CurrentCulture)
    End Function

    Public Overloads Function ToString(fmt As String, provider As IFormatProvider) As String Implements IFormattable.ToString
        If String.IsNullOrEmpty(fmt) Then fmt = "G"
        If provider Is Nothing Then provider = CultureInfo.CurrentCulture
        Select Case fmt.ToUpperInvariant()
            Case "F"
                Dim f As Double = CDbl(n) / CDbl(d)
                Return f.ToString(fmt, provider)
            Case "G"
                Return n.ToString & "/" & d.ToString
        End Select
        Return ""
    End Function

    Shared Operator +(f1 As Fraction, f2 As Fraction) As Fraction
        Dim pgdc As Long = Gcd(f1.d, f2.d)
        Dim ppmc As Long = f1.d * f2.d / pgdc
        Return New Fraction(f1.n * f2.d / pgdc + f2.n * f1.d / pgdc, ppmc)
    End Operator

    Shared Operator -(f1 As Fraction, f2 As Fraction) As Fraction
        Dim pgdc As Long = Gcd(f1.d, f2.d)
        Dim ppmc As Long = f1.d * f2.d / pgdc
        Return New Fraction(f1.n * f2.d / pgdc - f2.n * f1.d / pgdc, ppmc)
    End Operator

    Public Function Equals1(other As Fraction) As Boolean Implements IEquatable(Of Fraction).Equals
        Return n = other.n AndAlso d = other.d
    End Function

    Public Overrides Function Equals(obj As Object) As Boolean
        If Not (TypeOf obj Is Fraction) Then Return False
        Return Equals1(CType(obj, Fraction))
    End Function

    Shared Operator =(f1 As Fraction, f2 As Fraction) As Boolean
        Return f1.Equals1(f2)
    End Operator

    Shared Operator <>(f1 As Fraction, f2 As Fraction) As Boolean
        Return Not f1.Equals1(f2)
    End Operator

    Public Overrides Function GetHashCode() As Integer
        Return n.GetHashCode() Xor d.GetHashCode()
    End Function

End Class
