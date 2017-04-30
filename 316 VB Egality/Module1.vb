' Egality
' Tests of various ways of implementing equality tests
' 2008-08-22    PV
' 2012-02-25	PV  VS2010


Module Module1

    Sub Main()
        Dim e1 As New Entier(5)
        Dim e2 As New Entier(5)
        Dim e3 As New Entier(7)

        Dim b1 As Boolean = e1 = e2         ' Calls Operator =
        Dim b2 As Boolean = e1 Is e2        ' Calls nothing!
        Dim b3 As Boolean = e1.Equals(e2)   ' Calls Public Overloads Function Equals(ByVal obj As Entier)

        Console.WriteLine("b1=" & b1.ToString)
        Console.WriteLine("b2=" & b2.ToString)
        Console.WriteLine("b3=" & b3.ToString)

        Console.WriteLine()
        Console.Write("(Pause)")
        Console.ReadLine()
    End Sub

End Module


Class Entier
    Implements IEquatable(Of Entier)
    Implements IEqualityComparer
    Implements IEqualityComparer(Of Entier)

    Private _n As Integer

    Public Sub New(ByVal n As Integer)
        _n = n
    End Sub


    Public Overrides Function Equals(ByVal obj As Object) As Boolean
        If obj Is Nothing Then Return False
        If obj Is Me Then Return True
        Return Equals(TryCast(obj, Entier))
    End Function


    Public Overloads Function Equals(ByVal obj As Entier) As Boolean
        Return MyBase.Equals(obj)
    End Function



    Public Shared Operator =(ByVal left As Entier, ByVal right As Entier) As Boolean
        Return left._n = right._n
    End Operator

    Public Shared Operator <>(ByVal left As Entier, ByVal right As Entier) As Boolean
        Return left._n <> right._n
    End Operator


    Public Function Equals1(ByVal other As Entier) As Boolean Implements System.IEquatable(Of Entier).Equals
        Return _n = other._n
    End Function

    Public Function Equals2(ByVal x As Object, ByVal y As Object) As Boolean Implements System.Collections.IEqualityComparer.Equals
        Dim o1 As Entier = TryCast(x, Entier)
        If o1 Is Nothing Then Return False
        Dim o2 As Entier = TryCast(y, Entier)
        If o2 Is Nothing Then Return False
        Return o1._n = o2._n
    End Function

    Public Function GetHashCode1(ByVal obj As Object) As Integer Implements System.Collections.IEqualityComparer.GetHashCode
        Return _n.GetHashCode
    End Function

    Public Function Equals3(ByVal x As Entier, ByVal y As Entier) As Boolean Implements System.Collections.Generic.IEqualityComparer(Of Entier).Equals
        Return x._n = y._n
    End Function

    Public Function GetHashCode2(ByVal obj As Entier) As Integer Implements System.Collections.Generic.IEqualityComparer(Of Entier).GetHashCode
        Return _n.GetHashCode
    End Function

End Class
