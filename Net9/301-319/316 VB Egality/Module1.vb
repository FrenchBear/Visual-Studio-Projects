' Egality
' Tests of various ways of implementing equality tests
'
' 2008-08-22    PV
' 2012-02-25 	PV		VS2010
' 2021-09-20 	PV		VS2022; Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9

Friend Module Module1
    Public Sub Main()
        Dim e1 As New Entier(5)
        Dim e2 As New Entier(5)
        Dim e3 As New Entier(7)

        Dim b1 As Boolean = e1 = e2         ' Calls Operator =
        Dim b2 As Boolean = e1 Is e2        ' Calls nothing!
        Dim b3 As Boolean = e1.Equals(e2)   ' Calls Public Overloads Function Equals(ByVal obj As Entier)

        WriteLine("b1=" & b1.ToString)
        WriteLine("b2=" & b2.ToString)
        WriteLine("b3=" & b3.ToString)

    End Sub

End Module

Friend Class Entier
    Implements IEquatable(Of Entier)
    Implements IEqualityComparer
    Implements IEqualityComparer(Of Entier)

    Private ReadOnly _n As Integer

    Public Sub New(n As Integer)
        _n = n
    End Sub

    Public Overrides Function Equals(obj As Object) As Boolean
        If obj Is Nothing Then Return False
        If obj Is Me Then Return True
        Return Equals(TryCast(obj, Entier))
    End Function

    Public Overloads Function Equals(obj As Entier) As Boolean
        Return MyBase.Equals(obj)
    End Function

    Public Shared Operator =(left As Entier, right As Entier) As Boolean
        Return left._n = right._n
    End Operator

    Public Shared Operator <>(left As Entier, right As Entier) As Boolean
        Return left._n <> right._n
    End Operator

    Public Function Equals1(other As Entier) As Boolean Implements IEquatable(Of Entier).Equals
        Return _n = other._n
    End Function

    Public Function Equals2(x As Object, y As Object) As Boolean Implements IEqualityComparer.Equals
        Dim o1 As Entier = TryCast(x, Entier)
        If o1 Is Nothing Then Return False
        Dim o2 As Entier = TryCast(y, Entier)
        If o2 Is Nothing Then Return False
        Return o1._n = o2._n
    End Function

    Public Function GetHashCode1(obj As Object) As Integer Implements IEqualityComparer.GetHashCode
        Return _n.GetHashCode
    End Function

    Public Function Equals3(x As Entier, y As Entier) As Boolean Implements IEqualityComparer(Of Entier).Equals
        Return x._n = y._n
    End Function

    Public Function GetHashCode2(obj As Entier) As Integer Implements IEqualityComparer(Of Entier).GetHashCode
        Return _n.GetHashCode
    End Function

    Public Overrides Function GetHashCode() As Integer
        Return _n.GetHashCode()
    End Function
End Class
