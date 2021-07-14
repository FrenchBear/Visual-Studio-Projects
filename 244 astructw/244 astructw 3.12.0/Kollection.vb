' class Kollection
' A replacement for VB Collection, with a case insensitive string index based on StringComparer.OrdinalIgnoreCase
' With this comparer, grosse<>große, which is not the case with VB Collection

Class Kollection
    Implements IEnumerable

    Private ReadOnly d As New Dictionary(Of String, Object)(StringComparer.OrdinalIgnoreCase)

    Public Sub Add(ByVal Item As Object, ByVal Key As String)
        d.Add(Key, Item)
    End Sub

    Default Public ReadOnly Property Item(ByVal Key As String) As Object
        Get
            Return d(Key)
        End Get
    End Property

    ' Not available, we target .Net Framework 3.5 here
    'Public Iterator Function GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
    '    For Each o As Object In d.Values
    '        Yield o
    '    Next
    'End Function

    Public Function GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
        Return d.Values.GetEnumerator
    End Function

    Public ReadOnly Property Count As Integer
        Get
            Return d.Count
        End Get
    End Property

    Public Function Contains(ByVal Key As String) As Boolean
        Return d.ContainsKey(Key)
    End Function

End Class
