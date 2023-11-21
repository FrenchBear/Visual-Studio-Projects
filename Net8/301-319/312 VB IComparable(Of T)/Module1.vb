' IComparable(Of T)
'
' 2008-08-20    PV
' 2012-02-25	PV		VS2010
' 2021-09-20 	PV		VS2022; Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8

Module Module1

    Sub Main()
        Dim i As Integer = Min(5, 7)
        Dim s1 As Short = 3, b1 As Byte = 5, j As Long = Min(s1, b1)
        Dim s As String = Min("t", "u")
        Dim c As CO = Min(New CO(4), New CO(2))

        'Dim ti(10) As Integer
        'Dim co1 As IComparer = Comparer(Of Integer).Default
        'Dim co2 As IComparer(Of Integer) = Comparer(Of Integer).Default
        'Array.Sort(ti, co1)
        'Array.Sort(ti, co2)

        '' Conversion Comparer --> Comparison
        'Dim co3 As Comparison(Of Integer)
        'co3 = AddressOf Comparer(Of Integer).Default.Compare

        Stop
    End Sub

    Class CO
        Implements IComparable(Of CO)

        Private ReadOnly _n As Integer

        Public Sub New(n As Integer)
            _n = n
        End Sub

        Public Function CompareTo(other As CO) As Integer Implements IComparable(Of CO).CompareTo
            Return _n - other._n
        End Function

    End Class

    Function Min(Of T As IComparable(Of T))(a As T, b As T) As T
        If a.CompareTo(b) < 0 Then
            Return a
        Else
            Return b
        End If
    End Function

End Module
