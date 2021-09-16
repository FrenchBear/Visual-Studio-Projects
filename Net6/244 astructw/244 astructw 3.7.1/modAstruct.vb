' module astruct
' Active code of astruct
' 2006-10-03    FPVI    First .Net version (3.0), both interactive and command line
' 2006-10-10    FPVI    Dropped interactive mode, added colExclusions, filtered SYS+HIDDEN, skip hard links
' 2006-10-11    FPVI    3.1 with win32 functions to enumerate files and folders (twice faster than .Net functions)
' 2006-10-19    FPVI    3.2 My.Computer.FileSystem.DeleteDirectory(sDest & sSubfolder, FileIO.DeleteDirectoryOption.DeleteAllContents) does not work if there is r/o file in the folder
'                       Use Win32 CopyFile, DeleteFile... to support paths with more than 260 characters
' 2006-10-20    FPVI    3.2.1 My.Computer.FileSystem.DeleteDirectory(sDest & sSubfolder, FileIO.DeleteDirectoryOption.DeleteAllContents) does not work if there is r/o file in the folder
' 2006-10-21    FPVI    3.3   Options Mutlithread, DotNetCalls, NoWidePath
' 2007-01-04    FPVI    3.3.1 Option /c to create target folder
' 2009-05-21    FPVI    3.3.2 Manage correctly copy a file to a hidden file
' 2009-05-22    FPVI    3.4 VS 2008, backup/restore privilege
' 2010-02-05    FPVI    3.5   bAddUpdate
' 2010-02-07    FPVI    3.5.1 Shows formatted date+time in debug mode
' 2010-02-09    FPVI    3.5.3 Check and set LastWriteTime after a copy
' 2010-02-14    FPVI    3.6 IntPtr and SafeFileHandle for 64-bit; Do not copy file sNomficTTO; Option /t1 to show a trace of level 1 folders
' 2010-04-05    FPVI    3.6.2: bOneHourDifferenceAccepted
' 2010-04-18    FPVI    3.7: Use Win32 CopyFileEx to copy encrypted files
' 2010-12-16    FPVI    3.7.1: iFolderTraceLevel to control folder trace depth

' SafeFileHandle from http://www.pinvoke.net/default.aspx/kernel32/CreateFile.html

Option Explicit On
Option Compare Text

Imports System.IO
Imports VB = Microsoft.VisualBasic
Imports System.Runtime.InteropServices
Imports System.Diagnostics
Imports Microsoft.Win32.SafeHandles

Module modAstruct
    Dim nbFiles As Integer
    Dim nbDirectories As Integer
    Dim nbFilesCopied As Integer
    Dim nbFilesDeleted As Integer
    ReadOnly colErrors As New Collection

    Public bVerbose As Boolean
    Public iFolderTraceLevel As Integer                 ' Maximum depth for folder trace, 0=no trace
    Public bDisableTimeCheck As Boolean                 ' For interactive trace
    Public bNoAction As Boolean                         ' Show what should be done but actually does nothing
    Public bAddUpdate As Boolean                        ' Only add or update files, do not delete files/folders on destination
    Public bCopyDirectoryReparsePointContent As Boolean ' Copy what is behind a reparse point (a junction on NTFS volumes)
    Public bMultiThread As Boolean                      ' Enumerates folder contents in separate threads
    Public bDotNetCalls As Boolean                      ' Use .Net and not Win32
    Public bNoWidePaths As Boolean                      ' Do not use wide paths extension (WidePathString function)
    Public bCreateTarget As Boolean                     ' Create destination folder if if does not exist
    Public bOneHourDifferenceAccepted As Boolean        ' Consider files identical if they have 1hr difference (and same size)

    Public colExclusions As New Collection              ' List of patterns to ignore

    Public m_ListBox As ListBox

    Const sNomficTTO As String = "$$--$$--.$-$"         ' Test TimeOffset


#Region "Interface with Win32 enumeration functions"
    <StructLayout(LayoutKind.Sequential)> _
    Structure FILETIME
        Dim dwLowDateTime As UInteger
        Dim dwHighDateTime As UInteger
    End Structure

    '<StructLayout(LayoutKind.Explicit)> _
    'Public Structure FILETIME2
    '<FieldOffset(0)> Public LongDateTime As ULong
    '<FieldOffset(0)> Public dwLowDateTime As UInteger
    '<FieldOffset(4)> Public dwHighDateTime As UInteger
    'End Structure

    <StructLayout(LayoutKind.Sequential)> _
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

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Unicode)> _
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
        <VBFixedString(520), MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=520)> Public cFileName As String
        ' TCHAR array 14 TCHAR's alternate filename 28 byes in unicode  
        <VBFixedString(28), MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=28)> Public cAlternate As String
    End Structure

    '<StructLayout(LayoutKind.Sequential)> _
    'Public Structure SECURITY_ATTRIBUTES
    'Public nLength As Integer
    'Public lpSecurityDescriptor As Integer
    'Public bInheritHandle As Integer
    'End Structure

    <DllImport("kernel32.dll", EntryPoint:="FindFirstFileW", SetLastError:=True, CharSet:=CharSet.Unicode)> _
    Public Function FindFirstFileW(ByVal lpFileName As String, ByRef lpFindFileData As WIN32_FIND_DATAW) As IntPtr
    End Function

    <DllImport("kernel32.dll", EntryPoint:="FindNextFileW", SetLastError:=True, CharSet:=CharSet.Unicode)> _
    Public Function FindNextFileW(ByVal hFindFile As IntPtr, ByRef lpFindFileData As WIN32_FIND_DATAW) As Boolean
    End Function

    Declare Function FindClose Lib "kernel32" (ByVal hFindFile As IntPtr) As Integer

    'Declare Function FileTimeToLocalFileTime Lib "kernel32" (ByRef lpFileTime As FILETIME, ByRef lpLocalFileTime As FILETIME) As Integer
    'Declare Function FileTimeToSystemTime Lib "kernel32" (ByRef lpFileTime As FILETIME, ByRef lpSystemTime As SYSTEMTIME) As Integer

    <DllImport("kernel32.dll", EntryPoint:="CopyFileW", SetLastError:=True, CharSet:=CharSet.Unicode)> _
    Function CopyFile(ByVal lpSource As String, ByVal lpDest As String, ByVal bFailIfExists As Integer) As Integer
    End Function

    <DllImport("kernel32.dll", EntryPoint:="CopyFileExW", SetLastError:=True, CharSet:=CharSet.Unicode)> _
    Function CopyFileEx(ByVal lpExistingFileName As String, ByVal lpNewFileName As String, ByVal lpProgressRoutine As CPCallback, ByRef lpData As Long, ByRef pbCancel As Boolean, ByVal dwCopyFlags As Integer) As Integer
    End Function

    Const COPY_FILE_ALLOW_DECRYPTED_DESTINATION As Integer = 8

    Public Delegate Function CPCallback( _
        ByVal TotalFileSize As Long, _
        ByVal TotalBytesTransfered As Long, _
        ByVal StreamSize As Long, _
        ByVal StreamBytesTransfered As Long, _
        ByVal StreamNumber As Integer, _
        ByVal dwCallbackReason As Integer, _
        ByVal hSourceFile As IntPtr, _
        ByVal hDestFile As IntPtr, _
        ByRef lpData As Long) As Integer

    <DllImport("kernel32.dll", EntryPoint:="DeleteFileW", SetLastError:=True, CharSet:=CharSet.Unicode)> _
    Function DeleteFile(ByVal lpFileName As String) As Integer
    End Function

    <DllImport("kernel32.dll", EntryPoint:="SetFileAttributesW", SetLastError:=True, CharSet:=CharSet.Unicode)> _
    Function SetFileAttributes(ByVal lpFileName As String, ByVal dwFileAttributes As FileAttribute) As Integer
    End Function

    <DllImport("kernel32.dll", EntryPoint:="RemoveDirectoryW", SetLastError:=True, CharSet:=CharSet.Unicode)> _
    Function RemoveDirectory(ByVal lpFileName As String) As Integer
    End Function

    <DllImport("kernel32.dll", EntryPoint:="CreateDirectoryW", SetLastError:=True, CharSet:=CharSet.Unicode)> _
    Function CreateDirectory(ByVal lpFileName As String, ByVal lpSecurityAttributes As IntPtr) As Integer
    End Function

    <DllImport("kernel32.dll", EntryPoint:="GetFileTime", SetLastError:=True)> _
    Function GetFileTime(ByVal hFile As SafeFileHandle, ByRef lpCreationTime As FILETIME, ByRef lpLastAccessTime As FILETIME, ByRef lpLastWriteTime As FILETIME) As Integer
    End Function

    <DllImport("kernel32.dll", EntryPoint:="SetFileTime", SetLastError:=True)> _
    Function SetFileTime(ByVal hFile As SafeFileHandle, ByRef lpCreationTime As FILETIME, ByRef lpLastAccessTime As FILETIME, ByRef lpLastWriteTime As FILETIME) As Integer
    End Function

    '<DllImport("kernel32.dll", EntryPoint:="CreateFileW", SetLastError:=True, CharSet:=CharSet.Unicode)> _
    'Function CreateFile(ByVal lpFileName As String, ByVal dwDesiredAccess As Integer, ByVal dwShareMode As Integer, ByRef lpSecurityAttributes As SECURITY_ATTRIBUTES, ByVal dwCreationDisposition As Integer, ByVal dwFlagsAndAttributes As Integer, ByVal hTemplateFile As Integer) As IntPtr
    'End Function

    <DllImport("kernel32.dll", EntryPoint:="CloseHandle", SetLastError:=True)> _
    Function CloseHandle(ByVal hObject As SafeFileHandle) As Integer
    End Function



    <DllImport("kernel32.dll", EntryPoint:="CreateFileW", SetLastError:=True, CharSet:=System.Runtime.InteropServices.CharSet.Unicode)> _
   Friend Function CreateFile(ByVal lpFileName As String, _
   ByVal dwDesiredAccess As EFileAccess, _
   ByVal dwShareMode As EFileShare, _
   ByVal lpSecurityAttributes As IntPtr, _
   ByVal dwCreationDisposition As ECreationDisposition, _
   ByVal dwFlagsAndAttributes As EFileAttributes, _
   ByVal hTemplateFile As IntPtr) As SafeFileHandle
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

    ' Can't create an empty FileInfo, so I have to use my own class...
    Class MyFileInfo
        Public Name As String
        Public FullName As String
        Public Attributes As FileAttributes
        Public FileSize As ULong                    ' 64 bit
        Public LastWriteTime As Long                ' 64 bit (not ULong since subtraction can generate a negative value)
    End Class


    Public Sub Astruct(ByVal sSource As String, ByVal sDest As String)
        ' If we used options, then show them explicitly
        Dim sOptions As String = ""
        If bVerbose Then sOptions &= ", Verbose"
        If iFolderTraceLevel Then sOptions = sOptions & ", TraceFoldersLevel" & CStr(iFolderTraceLevel)
        If bDisableTimeCheck Then sOptions &= ", NoTimeCheck"
        If bNoAction Then sOptions &= ", NoAction"
        If bOneHourDifferenceAccepted Then sOptions &= ", OneHourDifference"
        If bAddUpdate Then sOptions &= ", AddUpdate"
        If bCopyDirectoryReparsePointContent Then sOptions &= ", CopyDirectoryReparsePointContent"
        If bMultiThread Then sOptions &= ", MultiThread"
        If bDotNetCalls Then sOptions &= ", DotNetCalls"
        If bNoWidePaths Then sOptions &= ", NoWidePaths"
        If sOptions.Length > 0 Then
            Console.WriteLine(HelpHeaderString() & " (" & sOptions.Substring(2) & ")")
        End If

        ' Create target folder if it does not exist and option /c has been specified
        Try
            If Not My.Computer.FileSystem.DirectoryExists(sDest) And bCreateTarget Then
                My.Computer.FileSystem.CreateDirectory(sDest)
            End If
        Catch ex As Exception
            Trace("Error creating target folder " & QuoteString(sDest))
            Trace(ex.Message)
        End Try

        ' Get backup/restore privileges
        Const SE_BACKUP_NAME As String = "SeBackupPrivilege"
        EnableToken(SE_BACKUP_NAME)

        ' Source and destination must exist at this stage
        Dim bProblem As Boolean = False
        If Not IsCheckFolder(sSource, "source") Then bProblem = True
        If Not IsCheckFolder(sDest, "destination") Then bProblem = True
        If bProblem Then Exit Sub

        ' Normalize paths
        If VB.Right(sSource, 1) <> "\" Then sSource &= "\"
        If VB.Right(sDest, 1) <> "\" Then sDest &= "\"
        If Not bDisableTimeCheck Then
            If Not IsTimeCheck(sSource, sDest) Then Exit Sub
        End If

        Dim t1 As DateTime = DateTime.Now
        nbFiles = 0
        nbDirectories = 0
        nbFilesCopied = 0
        nbFilesDeleted = 0
        Trace("astructw " & QuoteString(sSource) & " -> " & QuoteString(sDest))

        DoAstruct(sSource, sDest, 1)
        Dim t2 As DateTime = DateTime.Now
        Dim ts As TimeSpan = t2 - t1
        Trace("")
        Trace(nbDirectories.ToString & " folder" & s(nbDirectories) & " analyzed, " & nbFiles.ToString & " file" & s(nbFiles) & " analyzed")
        Trace(nbFilesCopied.ToString & " file" & s(nbFilesCopied) & " copied, " & nbFilesDeleted.ToString & " file" & s(nbFilesDeleted) & " deleted")
        Trace(String.Format("Total time {0}:{1:D2}.{2:D3}s", Int(ts.TotalMinutes), ts.Seconds, ts.Milliseconds))
        If colErrors.Count > 0 Then
            Trace("")
            Trace(colErrors.Count.ToString & " error" & s(colErrors.Count) & ":")
            For Each s As String In colErrors
                Trace(s.Replace("|", " ==> "))
            Next
        End If
    End Sub


    Private Function IsCheckFolder(ByVal sFolder As String, ByVal sPosition As String) As Boolean
        Try
            If My.Computer.FileSystem.DirectoryExists(sFolder) Then Return True
            CLShowError("Can't find " & sPosition & " folder " & QuoteString(sFolder))
        Catch ex As Exception
            Trace("Error accessing " & sPosition & " folder " & QuoteString(sFolder))
            Trace(ex.Message)
        End Try
        Return False
    End Function

    Private Sub Trace(ByVal sMsg As String)
        If m_ListBox IsNot Nothing Then
            With m_ListBox
                For Each s As String In sMsg.Replace(vbLf, "").Split(vbCr)
                    .Items.Add(s)
                    .SelectedIndex = .Items.Count - 1
                    .Refresh()
                Next
            End With
        Else
            Console.WriteLine(sMsg)
        End If
    End Sub

    Private Function S(ByVal n As Integer) As String
        If n > 1 Then
            Return "s"
        Else
            Return vbNullString
        End If
    End Function


    Private Function QuoteString(ByVal s As String)
        If s.Contains(" ") Then
            Return Chr(34) & s & Chr(34)
        Else
            Return s
        End If
    End Function

    ' For Multithread option
    Delegate Sub EnumProc(ByVal sPath As String, ByVal colFoldersSource As Collection, ByVal colFilesSource As Collection)

    Private Sub DoAstruct(ByVal sSource As String, ByVal sDest As String, ByVal iLevel As Integer)
        Dim colFilesSource As New Collection
        Dim colFilesDest As New Collection
        Dim colFoldersSource As New Collection
        Dim colFoldersDest As New Collection

        ' Enumerate source and destination
        If bMultiThread Then
            Dim p1 As EnumProc = AddressOf Enumerate
            Dim p2 As New EnumProc(AddressOf Enumerate)
            Dim ar1 As IAsyncResult = p1.BeginInvoke(sSource, colFoldersSource, colFilesSource, Nothing, Nothing)
            Dim ar2 As IAsyncResult = p2.BeginInvoke(sDest, colFoldersDest, colFilesDest, Nothing, Nothing)
            p1.EndInvoke(ar1)
            p2.EndInvoke(ar2)
        Else
            Enumerate(sSource, colFoldersSource, colFilesSource)
            Enumerate(sDest, colFoldersDest, colFilesDest)
        End If

        If bVerbose Then
            Trace("-- Source folder " & QuoteString(sSource) & ": " & colFilesSource.Count.ToString & " file" & s(colFilesSource.Count.ToString) & ", " & colFoldersSource.Count.ToString & " folder" & s(colFoldersSource.Count.ToString))
        End If

        Dim sCmd As String
        ' 1. Copy all files that exist on source and do not exist on dest, or files that are different
        For Each fiSource As MyFileInfo In colFilesSource
            nbFiles += 1
            If Not colFilesDest.Contains(fiSource.Name) Then
                sCmd = "copy " & QuoteString(sSource & fiSource.Name) & " " & QuoteString(sDest & fiSource.Name)
                If bVerbose Then Trace("-- Source file " & QuoteString(sSource & fiSource.Name) & " does not exist in dest folder " & QuoteString(sDest) & " --> Copy")
                Trace(sCmd)
                nbFilesCopied += 1
                If Not bNoAction Then
                    'If bDotNetCalls Then
                    '    Try
                    '        My.Computer.FileSystem.CopyFile(sSource & fiSource.Name, sDest & fiSource.Name)
                    '    Catch ex As Exception
                    '        Trace("*** Caused error: " & ex.Message)
                    '        colErrors.Add(sCmd & "|" & ex.Message)
                    '    End Try
                    'Else
                    MyCopyFile(WidePathString(sSource & fiSource.Name), WidePathString(sDest & fiSource.Name))
                    'End If
                End If
            Else
                ' File exist on dest.  Is it the same?
                Dim fiDest As MyFileInfo = colFilesDest(fiSource.Name)
                Dim bToCopy As Boolean = False
                If fiSource.FileSize <> fiDest.FileSize Then
                    If bVerbose Then
                        Trace("-- Source size " & QuoteString(sSource & fiSource.Name) & ": " & fiSource.FileSize.ToString)
                        Trace("-- Dest size " & QuoteString(sDest & fiDest.Name) & ": " & fiDest.FileSize.ToString & " --> Copy")
                    End If
                    bToCopy = True
                ElseIf Math.Abs((fiSource.LastWriteTime - fiDest.LastWriteTime) / 10000000) > 2 Then
                    If bOneHourDifferenceAccepted Then
                        Dim t1, t2 As Int64
                        t1 = fiSource.LastWriteTime
                        t2 = fiDest.LastWriteTime
                        If t2 < t1 Then
                            Dim t3 As Int64
                            t3 = t1
                            t1 = t2
                            t2 = t3
                        End If
                        Dim delta As Int64
                        delta = (t2 - t1) / 10000000
                        If delta >= 3599 And delta <= 3601 Then GoTo Label1
                    End If
                    If bVerbose Then
                        Trace("-- Source LastWrite on " & DateTime.FromFileTime(fiSource.LastWriteTime).ToString & " " & QuoteString(sSource & fiSource.Name))
                        Trace("-- Destin LastWrite on " & DateTime.FromFileTime(fiDest.LastWriteTime).ToString & " " & QuoteString(sDest & fiDest.Name) & " --> Copy")
                    End If
                    bToCopy = True
                End If
Label1:
                If bToCopy Then
                    ' If dest exists and is readonly or hidden, remove these attributes first
                    If (fiDest.Attributes And FileAttributes.ReadOnly) = FileAttributes.ReadOnly Or (fiDest.Attributes And FileAttributes.Hidden) = FileAttributes.Hidden Then
                        sCmd = "attrib "
                        If (fiDest.Attributes And FileAttributes.ReadOnly) = FileAttributes.ReadOnly Then sCmd &= "-r "
                        If (fiDest.Attributes And FileAttributes.Hidden) = FileAttributes.Hidden Then sCmd &= "-h "
                        sCmd &= QuoteString(sDest & fiDest.Name)
                        Trace(sCmd)
                        If Not bNoAction Then
                            If bDotNetCalls Then
                                Try
                                    System.IO.File.SetAttributes(sDest & fiDest.Name, fiDest.Attributes And Not (FileAttributes.ReadOnly Or FileAttributes.Hidden))
                                Catch ex As Exception
                                    Trace("*** Caused error: " & ex.Message)
                                    colErrors.Add(sCmd & "|" & ex.Message)
                                End Try
                            Else
                                Dim bRet As Integer = SetFileAttributes(WidePathString(sDest & fiDest.Name), fiDest.Attributes And Not (FileAttributes.ReadOnly Or FileAttributes.Hidden))
                                If bRet = 0 Then TraceWin32Error(sCmd)
                            End If
                        End If
                    End If
                    sCmd = "copy " & QuoteString(sSource & fiSource.Name) & " " & QuoteString(sDest & fiSource.Name)
                    Trace(sCmd)
                    nbFilesCopied += 1
                    If Not bNoAction Then
                        'If bDotNetCalls Then
                        '    Try
                        '        My.Computer.FileSystem.CopyFile(sSource & fiSource.Name, sDest & fiSource.Name, True)
                        '    Catch ex As Exception
                        '        Trace("*** Caused error: " & ex.Message)
                        '        colErrors.Add(sCmd & "|" & ex.Message)
                        '    End Try
                        'Else
                        MyCopyFile(WidePathString(sSource & fiSource.Name), WidePathString(sDest & fiSource.Name))
                        'End If
                    End If
                End If
            End If
        Next

        ' 2. Delete all files that exist on dest but do not exist on source
        If Not bAddUpdate Then
            For Each fiDest As MyFileInfo In colFilesDest
                If Not colFilesSource.Contains(fiDest.Name) Then
                    ' If dest exists and is readonly, remove attribute first
                    If (Not bNoAction) And ((fiDest.Attributes And FileAttributes.ReadOnly) = FileAttributes.ReadOnly OrElse (fiDest.Attributes And FileAttributes.Hidden) = FileAttributes.Hidden OrElse (fiDest.Attributes And FileAttributes.System) = FileAttributes.System) Then
                        sCmd = "attrib -rhs " & QuoteString(sDest & fiDest.Name)
                        Trace(sCmd)
                        If bDotNetCalls Then
                            Try
                                'System.IO.File.SetAttributes(sDest & fiDest.Name, fiDest.Attributes And Not FileAttributes.ReadOnly)
                                System.IO.File.SetAttributes(sDest & fiDest.Name, FileAttributes.Normal)
                            Catch ex As Exception
                                Trace("*** Caused error: " & ex.Message)
                                colErrors.Add(sCmd & "|" & ex.Message)
                            End Try
                        Else
                            Dim bRet As Integer = SetFileAttributes(WidePathString(sDest & fiDest.Name), FileAttributes.Normal)
                            If bRet = 0 Then TraceWin32Error(sCmd)
                        End If
                    End If
                    sCmd = "del " & QuoteString(sDest & fiDest.Name)
                    Trace(sCmd)
                    nbFilesDeleted += 1
                    If Not bNoAction Then
                        If bDotNetCalls Then
                            Try
                                My.Computer.FileSystem.DeleteFile(sDest & fiDest.Name)
                            Catch ex As Exception
                                Trace("*** Caused error: " & ex.Message)
                                colErrors.Add(sCmd & "|" & ex.Message)
                            End Try
                        Else
                            Dim bRet As Boolean = DeleteFile(WidePathString(sDest & fiDest.Name))
                            If bRet = 0 Then TraceWin32Error(sCmd)
                        End If
                    End If
                End If
            Next
        End If

        ' 3. Recursively process subdirectories, creating missing subdirectories
        For Each sSubfolder As String In colFoldersSource
            If iLevel <= iFolderTraceLevel Then
                Trace("Processing " & QuoteString(sSource & sSubfolder))
            End If
            nbDirectories += 1
            If Not colFoldersDest.Contains(sSubfolder) Then
                sCmd = "mkdir " & QuoteString(sDest & sSubfolder)
                Trace(sCmd)
                If Not bNoAction Then
                    If bDotNetCalls Then
                        Try
                            My.Computer.FileSystem.CreateDirectory(sDest & sSubfolder)
                        Catch ex As Exception
                            Trace("*** Caused error: " & ex.Message)
                            colErrors.Add(sCmd & "|" & ex.Message)
                            ' In this case, don't attempt to do recurse astruct
                            Continue For
                        End Try
                    Else
                        Dim bRet As Boolean = CreateDirectory(WidePathString(sDest & sSubfolder), IntPtr.Zero)
                        If bRet = 0 Then TraceWin32Error(sCmd)
                    End If
                End If
            End If
            DoAstruct(sSource & sSubfolder & "\", sDest & sSubfolder & "\", iLevel + 1)
        Next

        ' 4. Remove extra subdirectories on dest
        If Not bAddUpdate Then
            For Each sSubfolder As String In colFoldersDest
                If Not colFoldersSource.Contains(sSubfolder) Then
                    If bNoAction Then
                        sCmd = "rd /s " & QuoteString(sDest & sSubfolder)
                        Trace(sCmd)
                    Else
                        RecurseDeleteDirectory(sDest & sSubfolder)
                    End If
                End If
            Next
        End If
    End Sub

    ' Manual implementation since My.Computer.FileSystem.DeleteDirectory(sDest & sSubfolder, FileIO.DeleteDirectoryOption.DeleteAllContents) 
    ' does not work if there is r/o file in the folder
    Private Sub RecurseDeleteDirectory(ByVal sPath As String)
        Dim colFiles As New Collection
        Dim colFolders As New Collection

        If Right(sPath, 1) <> "\" Then sPath &= "\"
        Enumerate(sPath, colFolders, colFiles)
        For Each sFolderName As String In colFolders
            RecurseDeleteDirectory(sPath & sFolderName & "\")
        Next
        Dim sCmd As String
        For Each f As MyFileInfo In colFiles
            If (f.Attributes And FileAttributes.ReadOnly) = FileAttributes.ReadOnly OrElse (f.Attributes And FileAttributes.Hidden) = FileAttributes.Hidden OrElse (f.Attributes And FileAttributes.System) = FileAttributes.System Then
                sCmd = "attrib -rhs " & QuoteString(f.FullName)
                Trace(sCmd)
                ' No need to check bNoAction since if it's False, RecurseDeleteDirectory is not called
                If bDotNetCalls Then
                    Try
                        f.Attributes = f.Attributes And Not FileAttributes.ReadOnly
                    Catch ex As Exception
                        Trace("*** Caused error: " & ex.Message)
                        colErrors.Add(sCmd & "|" & ex.Message)
                    End Try
                Else
                    Dim bRet As Integer = SetFileAttributes(WidePathString(f.FullName), FileAttributes.Normal)
                    If bRet = 0 Then TraceWin32Error(sCmd)
                End If
            End If
            sCmd = "del " & QuoteString(f.FullName)
            Trace(sCmd)
            If bDotNetCalls Then
                Try
                    My.Computer.FileSystem.DeleteFile(f.FullName)
                Catch ex As Exception
                    Trace("*** Caused error: " & ex.Message)
                    colErrors.Add(sCmd & "|" & ex.Message)
                End Try
            Else
                Dim bRet As Boolean = DeleteFile(WidePathString(f.FullName))
                If bRet = 0 Then TraceWin32Error(sCmd)
            End If
        Next
        sCmd = "rd " & QuoteString(sPath)
        Trace(sCmd)
        If bDotNetCalls Then
            Try
                My.Computer.FileSystem.DeleteDirectory(sPath, FileIO.DeleteDirectoryOption.DeleteAllContents)
            Catch ex As Exception
                Trace("*** Caused error: " & ex.Message)
                colErrors.Add(sCmd & "|" & ex.Message)
            End Try
        Else
            Dim bRet As Boolean = RemoveDirectory(WidePathString(sPath))
            If bRet = 0 Then TraceWin32Error(sCmd)
        End If
    End Sub

    Private Function IsTimeCheck(ByVal sSource As String, ByVal sDest As String) As Boolean
        Dim sPathSource As String = sSource & sNomficTTO
        Dim sPathDest As String = sDest & sNomficTTO

        Dim bReturn As Boolean
        Try

            Try
                My.Computer.FileSystem.WriteAllText(sPathSource, "", False)
            Catch ex As Exception
                Trace("Creation of test file <" & sPathSource & "> for time offset check failed: " & ex.Message & vbCrLf & "Use option /t to disable this check.")
                Return False
            End Try

            Dim fiSource As New FileInfo(sPathSource)
            'My.Computer.FileSystem.CopyFile(sPathSource, sPathDest)
            myCopyFile(sPathSource, sPathDest)
            Dim fiDest As New FileInfo(sPathDest)

            Dim dt As TimeSpan = fiSource.LastWriteTimeUtc - fiDest.LastWriteTimeUtc
            If Math.Abs(dt.TotalSeconds) <= 2 Then
                bReturn = True
            Else
                Trace("*** Time offset check detected a difference between source and destination")
                Trace("Time source: " & fiSource.LastWriteTimeUtc.ToLongTimeString)
                Trace("Time dest:   " & fiDest.LastWriteTimeUtc.ToLongTimeString)
                Trace("Use option /t to disable this check.")
                bReturn = False
            End If

            My.Computer.FileSystem.DeleteFile(sPathSource)
            My.Computer.FileSystem.DeleteFile(sPathDest)

        Catch ex As Exception
            Trace("Unexpected error in IsTimeCheck: " & ex.Message & vbCrLf & "Use option /t to disable this check.")
            Return False

        End Try

        Return bReturn
    End Function

    Private Sub MyCopyFile(ByVal sourcePath As String, ByVal destinationPath As String)
        Dim cancel As Boolean = False
        Dim bRet As Integer = CopyFileEx(sourcePath, destinationPath, Nothing, 0, cancel, COPY_FILE_ALLOW_DECRYPTED_DESTINATION)
        If bRet = 0 Then
            TraceWin32Error("CopyFileEx(""" & sourcePath & """, """ & destinationPath & "")
            Exit Sub
        End If
    End Sub

    Private Sub TraceWin32Error(ByVal sCmd As String)
        Dim sErr As String = Marshal.GetLastWin32Error.ToString & ": " & (New ComponentModel.Win32Exception().Message)
        If InStr(sErr, vbCr) > 0 Then sErr = Replace(sErr, vbCr, " ")
        If InStr(sErr, vbLf) > 0 Then sErr = Replace(sErr, vbLf, " ")
        sErr = Trim(sErr)
        Trace("*** Caused error " & sErr)
        colErrors.Add(sCmd & "|" & "Error " & sErr)
    End Sub

    ''' <summary>
    ''' Function to use filenames up to 32000 characters.  According to Win32 help:
    ''' The Unicode versions of several functions permit paths that exceed the MAX_PATH length if the path has the "\\?\" prefix.
    ''' The "\\?\" tells the function to turn off path parsing. However, each component in the path cannot be more than MAX_PATH
    ''' characters long. Use the "\\?\" prefix with paths for local storage devices and the "\\?\UNC\" prefix with paths having 
    ''' the Universal Naming Convention (UNC) format. The "\\?\" is ignored as part of the path. For example, "\\?\C:\myworld\private"
    ''' is seen as "C:\myworld\private", and "\\?\UNC\bill_g_1\hotstuff\coolapps" is seen as "\\bill_g_1\hotstuff\coolapps". 
    ''' </summary>
    Private Function WidePathString(ByVal sPath As String) As String
        If bNoWidePaths Then        ' Option to deactivate this mechanism
            Return sPath
        ElseIf sPath.Length > 1 AndAlso sPath(1) = ":"c Then
            Return "\\?\" & sPath
        ElseIf sPath.StartsWith("\\") Then
            Return "\\?\UNC" & sPath.Substring(1)
        Else
            Return sPath            ' For local relative/no drive names, keep name as is
        End If
    End Function


    ' Enumeration of files and folders using Win32 functions
    Private Sub Enumerate(ByVal sPath As String, ByVal colFoldersSource As Collection, ByVal colFilesSource As Collection)
        Dim hsearch As IntPtr  ' handle to the file search
        Dim findinfo As WIN32_FIND_DATAW = Nothing
        Dim success As Long  ' will be 1 if successive searches are successful, 0 if not
        Dim retval As Long  ' generic return value

        Dim s As String = WidePathString(sPath) & "*"
        hsearch = FindFirstFileW(s, findinfo)
        If Not hsearch = -1 Then  ' no files match the search string
            Do
                If findinfo.dwFileAttributes And FileAttributes.Directory Then
                    ' Ignore special folders
                    If findinfo.cFileName = "." Or findinfo.cFileName = ".." Then GoTo NextFile
                    ' Ignore exclusions
                    SyncLock colExclusions
                        For Each sExcl As String In colExclusions
                            If findinfo.cFileName Like sExcl Then GoTo NextFile
                        Next
                    End SyncLock

                    ' Ignore SYSTEM+HIDDEN folders on source
                    If (findinfo.dwFileAttributes And FileAttributes.Hidden) <> FileAttributes.Hidden OrElse (findinfo.dwFileAttributes And FileAttributes.System) <> FileAttributes.System Then
                        If (findinfo.dwFileAttributes And FileAttributes.ReparsePoint) = FileAttributes.ReparsePoint Then
                            ' Special processing for reparse points
                            If bCopyDirectoryReparsePointContent Then
                                ' register for copy
                                colFoldersSource.Add(findinfo.cFileName, findinfo.cFileName)
                            End If
                        Else
                            ' Normal folder, register for copy
                            colFoldersSource.Add(findinfo.cFileName, findinfo.cFileName)
                        End If
                    End If
                Else
                    If findinfo.cFileName <> sNomficTTO Then
                        Dim fi As MyFileInfo
                        fi = New MyFileInfo With {
                            .Name = findinfo.cFileName,
                            .FullName = sPath & findinfo.cFileName,
                            .Attributes = findinfo.dwFileAttributes,
                            .FileSize = findinfo.nFileSizeHigh * 4294967296 + findinfo.nFileSizeLow,
                            .LastWriteTime = findinfo.ftLastWriteTime.dwHighDateTime * 4294967296 + findinfo.ftLastWriteTime.dwLowDateTime
                        }
                        colFilesSource.Add(fi, fi.Name)
                    End If
                End If
NextFile:
                success = FindNextFileW(hsearch, findinfo)
            Loop Until success = 0  ' keep looping until no more matching files are found

            ' Close the file search handle
            retval = FindClose(hsearch)
        End If
    End Sub

    '    Private Sub CopyOneFileWin32(ByVal sSource As String, ByVal sDest As String, ByVal sCmd As String, ByVal SourceLastWriteTime As Long)
    '        Dim bRet As Integer = CopyFile(sSource, sDest, False)
    '        If bRet = 0 Then
    '            TraceWin32Error(sCmd)
    '            Exit Sub
    '        End If

    '        Exit Sub

    '        'Const GENERIC_ALL = &H10000000
    '        Const GENERIC_READ = &H80000000
    '        Const FILE_WRITE_ATTRIBUTES = &H100
    '        Const FILE_SHARE_READ = &H1
    '        'Const FILE_SHARE_WRITE = &H2
    '        Const OPEN_EXISTING = 3

    '        'hFile = CreateFile(sDest, GENERIC_ALL, FILE_SHARE_READ Or FILE_SHARE_WRITE, Nothing, OPEN_EXISTING, 0, 0)
    '        Dim hFile As SafeFileHandle, LastWriteTime As FILETIME
    '        hFile = CreateFile(sDest, GENERIC_READ Or FILE_WRITE_ATTRIBUTES, FILE_SHARE_READ, Nothing, OPEN_EXISTING, 0, 0)

    '        If hFile.IsInvalid Then TraceWin32Error("CreateFile " & sDest) : Exit Sub
    '        If GetFileTime(hFile, Nothing, Nothing, LastWriteTime) = 0 Then TraceWin32Error("GetFileTime " & sDest) : GoTo Sortie

    '        If Math.Abs((SourceLastWriteTime - LastWriteTime.dwHighDateTime * 4294967296 - LastWriteTime.dwLowDateTime) / 10000000) > 2 Then
    '            LastWriteTime.dwHighDateTime = SourceLastWriteTime \ 4294967296
    '            LastWriteTime.dwLowDateTime = SourceLastWriteTime Mod 4294967296
    '            If SetFileTime(hFile, Nothing, Nothing, LastWriteTime) = 0 Then TraceWin32Error("SetFileTime " & sDest)
    '        End If

    'Sortie:
    '        CloseHandle(hFile)
    '    End Sub

End Module
