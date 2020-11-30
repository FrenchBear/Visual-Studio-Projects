' 211 Operators (Fraction)
' 2012-02-25	PV  VS2010

Module Module1
    Sub Main()
        Dim f1 As New Fraction(1, 2)
        Dim f2 As New Fraction(2, 3)
        Dim f3 As New Fraction(2, 4)
        Dim f4 As New Fraction(1, 2)

        'If f1 = f3 Then Beep()

        Dim c As New Hashtable
        c.Add(f1, "aze")
        c.Add(f2, "qsd")
        c.Add(f3, "wxc")

        MsgBox("f1.equals(f4): " & f1.Equals(f4))
        MsgBox("f1.equals(f3): " & f1.Equals(f3))
        ' Uses Equals virtual function to find
        MsgBox("c(1/2): " & c(f4))

        ' Dim s As New Generic.SortedDictionary(Of Fraction, String)
        ' Uses System.IComparable.CompareTo
        Dim s As New SortedList
        s.Add(f1, "string1")
        s.Add(f2, "string2")
    End Sub

End Module


Structure Fraction
    Implements IComparable(Of Fraction)
    Implements IComparable

    Private ReadOnly n As Long       ' = 0
    Private ReadOnly d As Long       ' = 1

    Sub New(ByVal nn As Long, ByVal dd As Long)
        n = nn
        d = dd
    End Sub

    Sub New(ByVal nn As Long)
        n = nn
        d = 1
    End Sub

    Public Shared Operator IsTrue(ByVal f As Fraction) As Boolean
        Return f.n <> 0
    End Operator

    Public Shared Operator IsFalse(ByVal f As Fraction) As Boolean
        Return f.n = 0
    End Operator

    Public Shared Operator =(ByVal f1 As Fraction, ByVal f2 As Fraction) As Boolean
        Return f1.n / f1.d = f2.n / f2.d
    End Operator

    Public Shared Operator <>(ByVal f1 As Fraction, ByVal f2 As Fraction) As Boolean
        Return f1.n / f1.d <> f2.n / f2.d
    End Operator

    Public Shared Operator >(ByVal f1 As Fraction, ByVal f2 As Fraction) As Boolean
        Return f1.n / f1.d > f2.n / f2.d
    End Operator

    Public Shared Operator <(ByVal f1 As Fraction, ByVal f2 As Fraction) As Boolean
        Return f1.n / f1.d < f2.n / f2.d
    End Operator

    Public Shared Operator >=(ByVal f1 As Fraction, ByVal f2 As Fraction) As Boolean
        Return f1.n / f1.d >= f2.n / f2.d
    End Operator

    Public Shared Operator <=(ByVal f1 As Fraction, ByVal f2 As Fraction) As Boolean
        Return f1.n / f1.d <= f2.n / f2.d
    End Operator

    Public Function CompareTo(ByVal other As Fraction) As Integer Implements System.IComparable(Of Fraction).CompareTo
        Return Math.Sign(n / d - other.n / other.d)
    End Function

    'Public Function EqualsIcomparable(ByVal other As Fraction) As Boolean Implements System.IComparable(Of Fraction).Equals
    '    Return Me = other
    'End Function

    Public Function CompareTo1(ByVal obj As Object) As Integer Implements System.IComparable.CompareTo
        Dim f As Fraction = CType(obj, Fraction)
        Return Me.CompareTo(f)
    End Function

    Overrides Function Equals(ByVal obj As Object) As Boolean
        Dim f As Fraction = CType(obj, Fraction)
        Return Me = f
    End Function
End Structure