' NativeMethods class
' Regroup P/Invoke declarations, to follow Microsoft code analysis recommendations
' SafeFileHandle from http://www.pinvoke.net/default.aspx/kernel32/CreateFile.html
'
' 2017-12-18    FPVI    For astructw 2.13

Imports System.Runtime.InteropServices
Imports System.Text
Imports Microsoft.Win32.SafeHandles


Friend Module NativeMethods

#Region "Security"
    Structure LUID
        Dim LowPart As Integer
        Dim HighPart As Integer
    End Structure

    Structure LUID_AND_ATTRIBUTES
        Dim pLuid As LUID
        Dim Attributes As Integer
    End Structure

    Structure TOKEN_PRIVILEGES
        Dim PrivilegeCount As Integer
        Dim Privileges As LUID_AND_ATTRIBUTES
    End Structure

    Friend Const TOKEN_ADJUST_PRIVILEGES = &H20
    Friend Const TOKEN_QUERY = &H8
    Friend Const SE_PRIVILEGE_ENABLED = &H2
    Friend Const FORMAT_MESSAGE_FROM_SYSTEM = &H1000

    Declare Function LoadLibrary Lib "kernel32" Alias "LoadLibraryA" (lpLibFileName As String) As IntPtr
    Declare Function FreeLibrary Lib "kernel32" (hLibModule As IntPtr) As Integer
    Declare Function GetProcAddress Lib "kernel32" (hModule As IntPtr, lpProcName As String) As IntPtr
    Declare Function OpenProcessToken Lib "advapi32.dll" (ProcessHandle As IntPtr, DesiredAccess As Integer, ByRef TokenHandle As IntPtr) As Integer
    Declare Function LookupPrivilegeValue Lib "advapi32.dll" Alias "LookupPrivilegeValueA" (lpSystemName As String, lpName As String, ByRef lpLuid As LUID) As Integer
    Declare Function AdjustTokenPrivileges Lib "advapi32.dll" (TokenHandle As IntPtr, DisableAllPrivileges As Integer, ByRef NewState As TOKEN_PRIVILEGES, BufferLength As Integer, ByRef PreviousState As TOKEN_PRIVILEGES, ByRef ReturnLength As Integer) As Integer

    <DllImportAttribute("kernel32.dll", EntryPoint:="FormatMessageA", SetLastError:=True, CharSet:=CharSet.Ansi, BestFitMapping:=False, ThrowOnUnmappableChar:=True)>
    Function FormatMessage(dwFlags As Integer, lpSource As IntPtr, dwMessageId As Integer, dwLanguageId As Integer, lpBuffer As StringBuilder, nSize As Integer, Arguments As Integer) As Integer
    End Function

#End Region

#Region "FileSystem"
    <StructLayout(LayoutKind.Sequential)>
    Structure FILETIME
        Dim dwLowDate As UInteger
        Dim dwHighDate As UInteger
    End Structure

    '<StructLayout(LayoutKind.Explicit)> _
    'Public Structure FILETIME2
    '<FieldOffset(0)> Public LongDate As ULong
    '<FieldOffset(0)> Public dwLowDate As UInteger
    '<FieldOffset(4)> Public dwHighDate As UInteger
    'End Structure

    <StructLayout(LayoutKind.Sequential)>
    Structure SYSTEMTIME
        Public wYear As Short
        Public wMonth As Short
        Public wDayOfWeek As Short
        Public wDay As Short
        Public wHour As Short
        Public wMinute As Short
        Public wSecond As Short
        Public wMilliseconds As Short
    End Structure

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Unicode)>
    Structure WIN32_FIND_DATAW
        Dim dwFileAttributes As Integer
        Dim ftCreationTime As FILETIME
        Dim ftLastAccessTime As FILETIME
        Dim ftLastWriteTime As FILETIME
        Dim nFileSizeHigh As UInteger
        Dim nFileSizeLow As UInteger
        Dim dwReserved0 As Integer
        Dim dwReserved1 As Integer

        ' TCHAR array 260 (MAX_PATH) entries, 520 bytes in unicode
        <VBFixedString(520), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=520)> Public cFileName As String

        ' TCHAR array 14 TCHAR's alternate filename 28 byes in unicode
        <VBFixedString(28), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=28)> Public cAlternate As String

    End Structure

    '<StructLayout(LayoutKind.Sequential)> _
    'Public Structure SECURITY_ATTRIBUTES
    'Public nLength As Integer
    'Public lpSecurityDescriptor As Integer
    'Public bInheritHandle As Integer
    'End Structure

    <DllImportAttribute("kernel32.dll", EntryPoint:="FindFirstFileW", SetLastError:=True, CharSet:=CharSet.Unicode)>
    Public Function FindFirstFileW(lpFileName As String, ByRef lpFindFileData As WIN32_FIND_DATAW) As IntPtr
    End Function

    <DllImport("kernel32.dll", EntryPoint:="FindNextFileW", SetLastError:=True, CharSet:=CharSet.Unicode)>
    Public Function FindNextFileW(hFindFile As IntPtr, ByRef lpFindFileData As WIN32_FIND_DATAW) As Boolean
    End Function

    Declare Function FindClose Lib "kernel32" (hFindFile As IntPtr) As Integer

    'Declare Function FileTimeToLocalFileTime Lib "kernel32" (ByRef lpFileTime As FILETIME, ByRef lpLocalFileTime As FILETIME) As Integer
    'Declare Function FileTimeToSystemTime Lib "kernel32" (ByRef lpFileTime As FILETIME, ByRef lpSystemTime As SYSTEMTIME) As Integer

    <DllImport("kernel32.dll", EntryPoint:="CopyFileW", SetLastError:=True, CharSet:=CharSet.Unicode)>
    Function CopyFile(lpSource As String, lpDest As String, bFailIfExists As Integer) As Integer
    End Function

    <DllImport("kernel32.dll", EntryPoint:="CopyFileExW", SetLastError:=True, CharSet:=CharSet.Unicode)>
    Function CopyFileEx(lpExistingFileName As String, lpNewFileName As String, lpProgressRoutine As CPCallback, ByRef lpData As Long, ByRef pbCancel As Boolean, dwCopyFlags As Integer) As Integer
    End Function

    <DllImport("kernel32.dll", EntryPoint:="MoveFileW", SetLastError:=True, CharSet:=CharSet.Unicode)>
    Function MoveFile(lpExistingFileName As String, lpNewFileName As String) As Integer
    End Function

    Public Const COPY_FILE_ALLOW_DECRYPTED_DESTINATION As Integer = 8

    Public Delegate Function CPCallback(
        TotalFileSize As Long,
        TotalBytesTransfered As Long,
        StreamSize As Long,
        StreamBytesTransfered As Long,
        StreamNumber As Integer,
        dwCallbackReason As Integer,
        hSourceFile As IntPtr,
        hDestFile As IntPtr,
        ByRef lpData As Long) As Integer

    <DllImport("kernel32.dll", EntryPoint:="DeleteFileW", SetLastError:=True, CharSet:=CharSet.Unicode)>
    Function DeleteFile(lpFileName As String) As Integer
    End Function

    <DllImport("kernel32.dll", EntryPoint:="SetFileAttributesW", SetLastError:=True, CharSet:=CharSet.Unicode)>
    Function SetFileAttributes(lpFileName As String, dwFileAttributes As FileAttribute) As Integer
    End Function

    <DllImport("kernel32.dll", EntryPoint:="RemoveDirectoryW", SetLastError:=True, CharSet:=CharSet.Unicode)>
    Function RemoveDirectory(lpFileName As String) As Integer
    End Function

    <DllImport("kernel32.dll", EntryPoint:="CreateDirectoryW", SetLastError:=True, CharSet:=CharSet.Unicode)>
    Function CreateDirectory(lpFileName As String, lpSecurityAttributes As IntPtr) As Integer
    End Function

    <DllImport("kernel32.dll", EntryPoint:="GetFileTime", SetLastError:=True)>
    Function GetFileTime(hFile As SafeFileHandle, ByRef lpCreationTime As FILETIME, ByRef lpLastAccessTime As FILETIME, ByRef lpLastWriteTime As FILETIME) As Integer
    End Function

    <DllImport("kernel32.dll", EntryPoint:="SetFileTime", SetLastError:=True)>
    Function SetFileTime(hFile As SafeFileHandle, ByRef lpCreationTime As FILETIME, ByRef lpLastAccessTime As FILETIME, ByRef lpLastWriteTime As FILETIME) As Integer
    End Function

    '<DllImport("kernel32.dll", EntryPoint:="CreateFileW", SetLastError:=True, CharSet:=CharSet.Unicode)> _
    'Function CreateFile(lpFileName As String, dwDesiredAccess As Integer, dwShareMode As Integer, ByRef lpSecurityAttributes As SECURITY_ATTRIBUTES, dwCreationDisposition As Integer, dwFlagsAndAttributes As Integer, hTemplateFile As Integer) As IntPtr
    'End Function

    <DllImport("kernel32.dll", EntryPoint:="CloseHandle", SetLastError:=True)>
    Function CloseHandle(hObject As SafeFileHandle) As Integer
    End Function

    <System.Runtime.InteropServices.DllImport("kernel32.dll", EntryPoint:="CreateFileW", SetLastError:=True, CharSet:=System.Runtime.InteropServices.CharSet.Unicode)>
    Friend Function CreateFile(lpFileName As String,
   dwDesiredAccess As EFileAccess,
   dwShareMode As EFileShare,
   lpSecurityAttributes As IntPtr,
   dwCreationDisposition As ECreationDisposition,
   dwFlagsAndAttributes As EFileAttributes,
   hTemplateFile As IntPtr) As Microsoft.Win32.SafeHandles.SafeFileHandle
    End Function

    Friend Structure STORAGE_DEVICE_NUMBER
        Friend DeviceType As Integer
        Friend DeviceNumber As Integer
        Friend PartitionNumber As Integer
    End Structure

    Friend Enum EFileAccess As System.Int32
        ''
        ''  The following are masks for the predefined standard access types
        ''

        DELETE = &H10000
        READ_CONTROL = &H20000
        WRITE_DAC = &H40000
        WRITE_OWNER = &H80000
        SYNCHRONIZE = &H100000

        STANDARD_RIGHTS_REQUIRED = &HF0000
        STANDARD_RIGHTS_READ = READ_CONTROL
        STANDARD_RIGHTS_WRITE = READ_CONTROL
        STANDARD_RIGHTS_EXECUTE = READ_CONTROL
        STANDARD_RIGHTS_ALL = &H1F0000
        SPECIFIC_RIGHTS_ALL = &HFFFF

        ''
        '' AccessSystemAcl access type
        ''

        ACCESS_SYSTEM_SECURITY = &H1000000

        ''
        '' MaximumAllowed access type
        ''

        MAXIMUM_ALLOWED = &H2000000

        ''
        ''  These are the generic rights.
        ''

        GENERIC_READ = &H80000000
        GENERIC_WRITE = &H40000000
        GENERIC_EXECUTE = &H20000000
        GENERIC_ALL = &H10000000
    End Enum

    Friend Enum EFileShare
        FILE_SHARE_NONE = &H0
        FILE_SHARE_READ = &H1
        FILE_SHARE_WRITE = &H2
        FILE_SHARE_DELETE = &H4
    End Enum

    Friend Enum ECreationDisposition

        ''' <summary>
        ''' Creates a new file, only if it does not already exist.
        ''' If the specified file exists, the function fails and the last-error code is set to ERROR_FILE_EXISTS (80).
        ''' If the specified file does not exist and is a valid path to a writable location, a new file is created.
        ''' </summary>
        CREATE_NEW = 1

        ''' <summary>
        ''' Creates a new file, always.
        ''' If the specified file exists and is writable, the function overwrites the file, the function succeeds, and last-error code is set to ERROR_ALREADY_EXISTS (183).
        ''' If the specified file does not exist and is a valid path, a new file is created, the function succeeds, and the last-error code is set to zero.
        ''' For more information, see the Remarks section of this topic.
        ''' </summary>
        CREATE_ALWAYS = 2

        ''' <summary>
        ''' Opens a file or device, only if it exists.
        ''' If the specified file or device does not exist, the function fails and the last-error code is set to ERROR_FILE_NOT_FOUND (2).
        ''' For more information about devices, see the Remarks section.
        ''' </summary>
        OPEN_EXISTING = 3

        ''' <summary>
        ''' Opens a file, always.
        ''' If the specified file exists, the function succeeds and the last-error code is set to ERROR_ALREADY_EXISTS (183).
        ''' If the specified file does not exist and is a valid path to a writable location, the function creates a file and the last-error code is set to zero.
        ''' </summary>
        OPEN_ALWAYS = 4

        ''' <summary>
        ''' Opens a file and truncates it so that its size is zero bytes, only if it exists.
        ''' If the specified file does not exist, the function fails and the last-error code is set to ERROR_FILE_NOT_FOUND (2).
        ''' The calling process must open the file with the GENERIC_WRITE bit set as part of the dwDesiredAccess parameter.
        ''' </summary>
        TRUNCATE_EXISTING = 5

    End Enum

    Friend Enum EFileAttributes
        FILE_ATTRIBUTE_READONLY = &H1
        FILE_ATTRIBUTE_HIDDEN = &H2
        FILE_ATTRIBUTE_SYSTEM = &H4
        FILE_ATTRIBUTE_DIRECTORY = &H10
        FILE_ATTRIBUTE_ARCHIVE = &H20
        FILE_ATTRIBUTE_DEVICE = &H40
        FILE_ATTRIBUTE_NORMAL = &H80
        FILE_ATTRIBUTE_TEMPORARY = &H100
        FILE_ATTRIBUTE_SPARSE_FILE = &H200
        FILE_ATTRIBUTE_REPARSE_POINT = &H400
        FILE_ATTRIBUTE_COMPRESSED = &H800
        FILE_ATTRIBUTE_OFFLINE = &H1000
        FILE_ATTRIBUTE_NOT_CONTENT_INDEXED = &H2000
        FILE_ATTRIBUTE_ENCRYPTED = &H4000
        FILE_ATTRIBUTE_VIRTUAL = &H10000
    End Enum

#End Region

End Module
