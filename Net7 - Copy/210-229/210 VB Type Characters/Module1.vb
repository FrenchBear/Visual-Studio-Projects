' 210 VB Type Characters
'
' 2012-02-25	PV  VS2010
' 2021-09-19    PV  VS2022; Net6

Option Strict On

Module Module1

    Sub Main()
        Dim ch As Char
        If ch = Chr(0) Then Beep()

        ' VB 10 spec:
        ' There are no type characters for Byte, SByte, UShort, Short, UInteger or ULong, due to a lack of suitable characters.
        Dim a$, b!, c#, d@, e%, f&
        a = "hello"
        b = 3.14
        c = 1.23456789012345#
        d = 1234.5678@
        e = 100000%
        f = 123456789012345678&

        Dim I As Short, J As Integer, K As Long, X As Decimal, Y As Single
        Dim Z As Double, L As UShort, M As UInteger, N As ULong, Q As Char
        I = 347S    ' Short
        J = 347I    ' Integer
        K = 347L    ' Long
        X = 347D    ' Decimal
        Y = 347.0F  ' Single
        Z = 347.0R  ' Double
        L = 347US   ' UShort
        M = 347UI   ' UInteger
        N = 347UL   ' ULong
        Q = "."c    ' Char

        Dim da As Date
        da = #2/26/1965 8:20:00 AM#

        Dim t() As MaClasse = {New MaClasse, New MaClasse(2), New MaClasse("abc")}
        t(1).v = 0
        t(1)(1) = 0

        Erase t

        Dim xx As Object
        xx = t
        xx = t(1)
        xx = t(1)(1)

        'Dim x As New MaClasse
        'Dim o As Object = x
        'o.v = 3
    End Sub

End Module

Class MaClasse
    Friend v As Integer

    Sub New()

    End Sub

    Sub New(sv0 As String)
        v = sv0.Length
    End Sub

    Sub New(v0 As Integer)
        v = v0
    End Sub

    Default Property p(i As Integer) As Integer
        Get
            Return 0
        End Get
        Set(value As Integer)
        End Set
    End Property

End Class