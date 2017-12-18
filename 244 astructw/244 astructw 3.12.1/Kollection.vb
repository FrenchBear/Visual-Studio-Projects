' class Kollection
' A replacement for VB Collection, with a case insensitive string index based on StringComparer.OrdinalIgnoreCase
' With this comparer, grosse<>große, which is not the case with VB Collection
'
' 2017-12-18    Use WindowsFileExplorerComparer to make sure that comparisons are identical to Windows file system

Class Kollection
    Implements IEnumerable

    Private d As Dictionary(Of String, Object) = New Dictionary(Of String, Object)(New WindowsFileExplorerComparer())

    Public Sub Add(ByVal Item As Object, ByVal Key As String)
        d.Add(Key, Item)
    End Sub

    Default Public ReadOnly Property Item(ByVal Key As String) As Object
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

    Public Function Contains(ByVal Key As String) As Boolean
        Return d.ContainsKey(Key)
    End Function

End Class