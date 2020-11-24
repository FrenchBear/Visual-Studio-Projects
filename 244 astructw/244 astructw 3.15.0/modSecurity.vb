' Security-related functions
' 2009-05-22    FPVI    First version

Option Explicit On
Option Compare Text

Imports System.Runtime.InteropServices
Imports System.Text

Friend Module Security

    ' Look for "Privilege constants" in help
    Public Sub EnableToken(privilege As String)
        If Not CheckEntryPoint("advapi32.dll", "AdjustTokenPrivileges") Then Return
        Dim tokenHandle As IntPtr = IntPtr.Zero
        Dim privilegeLUID = New LUID()
        Dim newPrivileges = New TOKEN_PRIVILEGES()
        Dim tokenPrivileges As TOKEN_PRIVILEGES
        If OpenProcessToken(Process.GetCurrentProcess().Handle, TOKEN_ADJUST_PRIVILEGES Or TOKEN_QUERY, tokenHandle) = 0 Then Throw New PrivilegeException(FormatError(Marshal.GetLastWin32Error()))
        If LookupPrivilegeValue("", privilege, privilegeLUID) = 0 Then Throw New PrivilegeException(FormatError(Marshal.GetLastWin32Error()))
        tokenPrivileges.PrivilegeCount = 1
        tokenPrivileges.Privileges.Attributes = SE_PRIVILEGE_ENABLED
        tokenPrivileges.Privileges.pLuid = privilegeLUID
        Dim Size As Integer = 4
        If AdjustTokenPrivileges(tokenHandle, 0, tokenPrivileges, 4 + (12 * tokenPrivileges.PrivilegeCount), newPrivileges, Size) = 0 Then Throw New PrivilegeException(FormatError(Marshal.GetLastWin32Error()))
    End Sub

    Private Function CheckEntryPoint(library As String, method As String) As Boolean
        Dim libPtr As IntPtr = LoadLibrary(library)
        If Not libPtr.Equals(IntPtr.Zero) Then
            If Not GetProcAddress(libPtr, method).Equals(IntPtr.Zero) Then
                FreeLibrary(libPtr)
                Return True
            End If
            FreeLibrary(libPtr)
        End If
        Return False
    End Function

    Private Function FormatError(number As Integer) As String
        Dim Buffer = New StringBuilder(255)
        FormatMessage(FORMAT_MESSAGE_FROM_SYSTEM, IntPtr.Zero, number, 0, Buffer, Buffer.Capacity, 0)
        Return Buffer.ToString()
    End Function

End Module


<Serializable>
Public Class PrivilegeException
    Inherits Exception

    Public Sub New()
        MyBase.New()
    End Sub

    Public Sub New(message As String)
        MyBase.New(message)
    End Sub

End Class