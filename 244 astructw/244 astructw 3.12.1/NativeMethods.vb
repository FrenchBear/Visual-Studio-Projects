' NativeMethods class
' Regroup P/Invoke declarations, to follow Microsoft code analysis recommendations
'
' 2016-11-12    PV
' 2017-01-04    PV  v3, Visual Basic

Imports System.Runtime.InteropServices

Module NativeMethods

    <DllImport("shlwapi.dll", CharSet:=CharSet.Unicode, ExactSpelling:=True)>
    Public Function StrCmpLogicalW(x As [String], y As [String]) As Integer
    End Function

End Module