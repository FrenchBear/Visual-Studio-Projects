' WindowsFileExplorerComparer Class
' Sorts string in a similar way to Windows File Explorer
' From http://stackoverflow.com/questions/3099581/sorting-an-array-of-folder-names-like-windows-explorer-numerically-and-alphabet
'
' 2016-09-30    PV
' 2016-12-11    PV  Declaration of StrCmpLogicalW moved to NativeMethods static class for compliance with MS code analysis recommendations
' 2017-01-04    PV  v3, Visual Basic
' 2017-12-18    PV  Implements IEqualityComparer to use it with a dictionary index in astructw

Friend Class WindowsFileExplorerComparer
    Implements IComparer(Of String), IEqualityComparer(Of String)

    Public Overloads Function Equals(x As String, y As String) As Boolean Implements IEqualityComparer(Of String).Equals
        Return StrCmpLogicalW(x, y) = 0
    End Function

    Public Overloads Function GetHashCode(name As String) As Integer Implements IEqualityComparer(Of String).GetHashCode
        Return name.GetHashCode()
    End Function

    Private Function Compare(x As String, y As String) As Integer Implements IComparer(Of String).Compare
        Return StrCmpLogicalW(x, y)
    End Function

End Class