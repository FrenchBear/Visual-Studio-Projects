' class Kollection
' A replacement for VB Collection, with a case insensitive string index based on StringComparer.OrdinalIgnoreCase
' With this comparer, grosse<>große, which is not the case with VB Collection
'
' 2017-12-18    FPVI    Made it generic and friend for better control
' 2020-11-23    FPVI    Method Add without a key

Friend Class Kollection(Of T)
    Implements IEnumerable(Of T)

    Private ReadOnly d As New Dictionary(Of String, T)(StringComparer.OrdinalIgnoreCase)

    Public Sub Add(Item As T, Key As String)
        d.Add(Key, Item)
    End Sub

    ' Simplified version, use a random key
    Public Sub Add(Item As T)
        d.Add(Rnd.ToString, Item)
    End Sub

    Default Public ReadOnly Property Item(Key As String) As T
        Get
            Return d(Key)
        End Get
    End Property

    Public Function GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
        Return d.Values.GetEnumerator
    End Function

    Public ReadOnly Property Count As Integer
        Get
            Return d.Count
        End Get
    End Property

    Public Function Contains(Key As String) As Boolean
        Return d.ContainsKey(Key)
    End Function

    Private Function IEnumerable_GetEnumerator() As IEnumerator(Of T) Implements IEnumerable(Of T).GetEnumerator
        Return d.Values.GetEnumerator
    End Function
End Class