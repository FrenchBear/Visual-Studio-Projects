' Security-related functions
' 2009-05-22    FPVI    First version

Imports System.Text
Imports System.Runtime.InteropServices


Module Security
    Private Structure LUID
        Dim LowPart As Integer
        Dim HighPart As Integer
    End Structure
    Private Structure LUID_AND_ATTRIBUTES
        Dim pLuid As LUID
        Dim Attributes As Integer
    End Structure
    Private Structure TOKEN_PRIVILEGES
        Dim PrivilegeCount As Integer
        Dim Privileges As LUID_AND_ATTRIBUTES
    End Structure

    Private Const TOKEN_ADJUST_PRIVILEGES = &H20
    Private Const TOKEN_QUERY = &H8
    Private Const SE_PRIVILEGE_ENABLED = &H2
    Private Const FORMAT_MESSAGE_FROM_SYSTEM = &H1000

    Private Declare Function LoadLibrary Lib "kernel32" Alias "LoadLibraryA" (ByVal lpLibFileName As String) As IntPtr
    Private Declare Function FreeLibrary Lib "kernel32" (ByVal hLibModule As IntPtr) As Integer
    Private Declare Function GetProcAddress Lib "kernel32" (ByVal hModule As IntPtr, ByVal lpProcName As String) As IntPtr
    Private Declare Function OpenProcessToken Lib "advapi32.dll" (ByVal ProcessHandle As IntPtr, ByVal DesiredAccess As Integer, ByRef TokenHandle As IntPtr) As Integer
    Private Declare Function LookupPrivilegeValue Lib "advapi32.dll" Alias "LookupPrivilegeValueA" (ByVal lpSystemName As String, ByVal lpName As String, ByRef lpLuid As LUID) As Integer
    Private Declare Function AdjustTokenPrivileges Lib "advapi32.dll" (ByVal TokenHandle As IntPtr, ByVal DisableAllPrivileges As Integer, ByRef NewState As TOKEN_PRIVILEGES, ByVal BufferLength As Integer, ByRef PreviousState As TOKEN_PRIVILEGES, ByRef ReturnLength As Integer) As Integer
    Private Declare Function FormatMessage Lib "kernel32" Alias "FormatMessageA" (ByVal dwFlags As Integer, ByVal lpSource As IntPtr, ByVal dwMessageId As Integer, ByVal dwLanguageId As Integer, ByVal lpBuffer As StringBuilder, ByVal nSize As Integer, ByVal Arguments As Integer) As Integer

    ' Look for "Privilege constants" in help
    Public Sub EnableToken(ByVal privilege As String)
        If Not CheckEntryPoint("advapi32.dll", "AdjustTokenPrivileges") Then Return
        Dim tokenHandle As IntPtr = IntPtr.Zero
        Dim privilegeLUID = New LUID()
        Dim newPrivileges = New TOKEN_PRIVILEGES()
        Dim tokenPrivileges As TOKEN_PRIVILEGES
        If (OpenProcessToken(Process.GetCurrentProcess().Handle, TOKEN_ADJUST_PRIVILEGES Or TOKEN_QUERY, tokenHandle)) = 0 Then Throw New PrivilegeException(FormatError(Marshal.GetLastWin32Error()))
        If (LookupPrivilegeValue("", privilege, privilegeLUID)) = 0 Then Throw New PrivilegeException(FormatError(Marshal.GetLastWin32Error()))
        tokenPrivileges.PrivilegeCount = 1
        tokenPrivileges.Privileges.Attributes = SE_PRIVILEGE_ENABLED
        tokenPrivileges.Privileges.pLuid = privilegeLUID
        Dim Size As Integer = 4
        If (AdjustTokenPrivileges(tokenHandle, 0, tokenPrivileges, 4 + (12 * tokenPrivileges.PrivilegeCount), newPrivileges, Size)) = 0 Then Throw New PrivilegeException(FormatError(Marshal.GetLastWin32Error()))
    End Sub

    Private Function CheckEntryPoint(ByVal library As String, ByVal method As String) As Boolean
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

    Private Function FormatError(ByVal number As Integer) As String
        Dim Buffer = New StringBuilder(255)
        FormatMessage(FORMAT_MESSAGE_FROM_SYSTEM, IntPtr.Zero, number, 0, Buffer, Buffer.Capacity, 0)
        Return Buffer.ToString()
    End Function
End Module

Public Class PrivilegeException
    Inherits Exception
    Public Sub New()
        MyBase.New()
    End Sub
    Public Sub New(ByVal message As String)
        MyBase.New(message)
    End Sub
End Class
