' class Fraction
' Simple implementation of a fraction
'
' 2012-04-09    PV
' 2021-09-23 	PV		VS2022; Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9
' 2026-01-19	PV		Net10

Imports System.Globalization

Public Class Fraction : Implements IFormattable, IEquatable(Of Fraction)

    Public Sub New(Numerator As Long, Denominator As Long)
        If Denominator = 0 Then Throw New DivideByZeroException("A fraction denominator can't be 0")
        If Numerator = 0 Then
            Me.Numerator = 0                                               ' Unique convention for 0
            Me.Denominator = 1
        Else
            Dim pgdc As Long = Gcd(Numerator, Denominator)      ' Only store reduced fractions
            If Denominator < 0 Then
                Numerator = -Numerator                          ' Sign is at Numerator
                Denominator = -Denominator                      ' Denominator is always > 0
            End If
            Me.Numerator = Numerator / pgdc
            Me.Denominator = Denominator / pgdc
        End If
    End Sub

    Public Sub New(n As Long)
        Me.New(n, 1)
    End Sub

    Public ReadOnly Property Numerator As Long

    Public ReadOnly Property Denominator As Long

    Public Overrides Function ToString() As String
        Return ToString("G", CultureInfo.CurrentCulture)
    End Function

    Public Overloads Function ToString(format As String, formatProvider As IFormatProvider) As String Implements IFormattable.ToString
        If String.IsNullOrEmpty(format) Then format = "G"
        If formatProvider Is Nothing Then formatProvider = CultureInfo.CurrentCulture
        Select Case format.ToUpperInvariant()
            Case "F"
                Dim f As Double = Numerator / Denominator
                Return f.ToString(format, formatProvider)
            Case "G"
                If Denominator = 1 Then Return Numerator.ToString
                Return Numerator.ToString & "/" & Denominator.ToString
        End Select
        Return ""
    End Function

    Public Shared Operator +(f1 As Fraction, f2 As Fraction) As Fraction
        Dim pgdc As Long = Gcd(f1.Denominator, f2.Denominator)
        Dim ppmc As Long = f1.Denominator * f2.Denominator / pgdc
        Return New Fraction((f1.Numerator * f2.Denominator / pgdc) + (f2.Numerator * f1.Denominator / pgdc), ppmc)
    End Operator

    Public Shared Operator -(f1 As Fraction, f2 As Fraction) As Fraction
        Dim pgdc As Long = Gcd(f1.Denominator, f2.Denominator)
        Dim ppmc As Long = f1.Denominator * f2.Denominator / pgdc
        Return New Fraction((f1.Numerator * f2.Denominator / pgdc) - (f2.Numerator * f1.Denominator / pgdc), ppmc)
    End Operator

    Public Function Equals1(other As Fraction) As Boolean Implements IEquatable(Of Fraction).Equals
        Return Numerator = other.Numerator AndAlso Denominator = other.Denominator
    End Function

    Public Overrides Function Equals(obj As Object) As Boolean
        If Not (TypeOf obj Is Fraction) Then Return False
        Return Equals1(CType(obj, Fraction))
    End Function

    Public Shared Operator =(f1 As Fraction, f2 As Fraction) As Boolean
        Return f1.Equals1(f2)
    End Operator

    Public Shared Operator <>(f1 As Fraction, f2 As Fraction) As Boolean
        Return Not f1.Equals1(f2)
    End Operator

    Public Overrides Function GetHashCode() As Integer
        Return Numerator.GetHashCode() Xor Denominator.GetHashCode()
    End Function

End Class
