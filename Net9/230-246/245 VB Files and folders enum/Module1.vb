' Files and folders enum
' Compared performances
'
' 2006-10-10    PV
' 2012-02-25	PV		VS2010
' 2021-09-20 	PV		VS2022; Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9

Imports System.IO
Imports System.Runtime.InteropServices

#Disable Warning IDE0051 ' Remove unused private members

Friend Module Module1
    Public Sub Main()
        Const sPath As String = "\\LU01ZEPHYR\C$\Windows\winsxs"
        AnalyzeFolder1(sPath)
        'EnumWin32()
    End Sub

    ' 1st method: using DirectoryInfo.GetFiles and DirectoryInfo.GetFolders
    ' $1: 0:00.000s
    ' $2: 0:37.475s
    ' $3: 1:15.261s
    ' $4: 1:15.271s
    ' $5: 1:15.282s
    Private Sub AnalyzeFolder1(sSource As String)
        Dim t1 As Date = Date.Now
        Dim ts As TimeSpan
        Dim dSource As New DirectoryInfo(sSource)
        ts = Date.Now - t1
        WriteLine($"$1: {Int(ts.TotalMinutes) }:{ts.Seconds:D2}.{ts.Milliseconds:D3}s")

        Dim tFilesSource As FileInfo() = dSource.GetFiles
        ts = Date.Now - t1
        WriteLine($"$2: {Int(ts.TotalMinutes) }:{ts.Seconds:D2}.{ts.Milliseconds:D3}s")

        Dim tSubdirectoriesSource As DirectoryInfo() = dSource.GetDirectories
        ts = Date.Now - t1
        WriteLine($"$3: {Int(ts.TotalMinutes) }:{ts.Seconds:D2}.{ts.Milliseconds:D3}s")

        ' Build dictionaries with files/subdirectories infos
        Dim dicFilesSource As New Dictionary(Of String, FileInfo)(tFilesSource.Length, StringComparer.OrdinalIgnoreCase)
        Dim dicSubdirectoriesSource As New Dictionary(Of String, DirectoryInfo)(tSubdirectoriesSource.Length, StringComparer.OrdinalIgnoreCase)

        For Each fiSource As FileInfo In tFilesSource
            dicFilesSource.Add(fiSource.Name, fiSource)
        Next
        ts = Date.Now - t1
        WriteLine($"$4: {Int(ts.TotalMinutes) }:{ts.Seconds:D2}.{ts.Milliseconds:D3}s")

        For Each diSource As DirectoryInfo In tSubdirectoriesSource
            ' Ignore SYSTEM+HIDDEN directories on source
            If (diSource.Attributes And FileAttributes.Hidden) <> FileAttributes.Hidden OrElse (diSource.Attributes And FileAttributes.System) <> FileAttributes.System Then
                If (diSource.Attributes And FileAttributes.ReparsePoint) <> FileAttributes.ReparsePoint Then
                    dicSubdirectoriesSource.Add(diSource.Name, diSource)
                End If
            End If
NextSource:
        Next
        ts = Date.Now - t1
        WriteLine($"$5: {Int(ts.TotalMinutes) }:{ts.Seconds:D2}.{ts.Milliseconds:D3}s")
    End Sub

    ' 2nd method: using DirectoryInfo.getFileSystemInfos
    ' $1: 1:15.802s
    ' 8832 files(s), 9 folder(s)
    ' 1:15 = exactly sum of calling GetFiles and GetFolders
    ' ==> implementation of getFileSystemInfos is simply calling GetFiles and GetFolders, enumerating files twice
    Private Sub AnalyzeFolder2(sSource As String)
        Dim dSource As New DirectoryInfo(sSource)
        Dim t1 As Date = Date.Now
        Dim ts As TimeSpan

        Dim tfsiElements() As FileSystemInfo
        tfsiElements = dSource.GetFileSystemInfos()
        Dim x As FileSystemInfo
        Dim nFiles, nFolders As Integer
        For Each x In tfsiElements
            If TypeOf x Is FileInfo Then
                nFiles += 1
            Else
                nFolders += 1
            End If
        Next

        ts = Date.Now - t1
        WriteLine($"$1: {Int(ts.TotalMinutes) }:{ts.Seconds:D2}.{ts.Milliseconds:D3}s")
        Dim fsi1 As FileSystemInfo = tfsiElements(4)

        WriteLine($"{nFiles } files(s), {nFolders } folder(s)")
    End Sub

    ' 3rd method, using Win32 system calls
    ' $1: 0:36.774s
    ' 8832 files(s), 11 folder(s)
    ' Ok, this is the most efficient method
    ' Note: Returns . and .. folders
    Private Sub AnalyzeFolder3(sSource As String)
        Dim t1 As Date = Date.Now
        Dim ts As TimeSpan

        Dim colFiles As New Collection
        Dim colFolders As New Collection

        Dim hsearch As Long  ' handle to the file search
        Dim findinfo As WIN32_FIND_DATAW
        Dim success As Long  ' will be 1 if successive searches are successful, 0 if not
        Dim retval As Long  ' generic return value

        Dim s = If(sSource.StartsWith("\\"), String.Concat("\\?\UNC", sSource.Substring(1), "*"), "\\?\" & sSource & "*")

        ' Warning BC42108: Variable 'findinfo' is passed by reference before it has been assigned a value. A null reference exception could result at runtime. Make sure the structure or all the reference members are initialized before use
#Disable Warning BC42108
        hsearch = FindFirstFileW(s, findinfo)
        If hsearch = -1 Then  ' no files match the search string
            Exit Sub
        End If

        Do
            If findinfo.dwFileAttributes And FileAttributes.Directory Then
                colFolders.Add("x")
            Else
                colFiles.Add("y")
            End If
            success = FindNextFileW(hsearch, findinfo)
        Loop Until success = 0  ' keep looping until no more matching files are found

        ' Close the file search handle
        retval = FindClose(hsearch)

        ts = Date.Now - t1
        WriteLine($"$1: {Int(ts.TotalMinutes) }:{ts.Seconds:D2}.{ts.Milliseconds:D3}s")

        WriteLine($"{colFiles.Count } files(s), {colFolders.Count } folder(s)")
    End Sub

    ' -----------------------------------------------------------------
    ' Win32 system calls

    'Const MAX_PATH = 260

    Public Structure FILETIME
        Public dwLowDateTime As Integer
        Public dwHighDateTime As Integer
    End Structure

    'Structure WIN32_FIND_DATA
    '    Dim dwFileAttributes As Integer
    '    Dim ftCreationTime As FILETIME
    '    Dim ftLastAccessTime As FILETIME
    '    Dim ftLastWriteTime As FILETIME
    '    Dim nFileSizeHigh As Integer
    '    Dim nFileSizeLow As Integer
    '    Dim dwReserved0 As Integer
    '    Dim dwReserved1 As Integer
    '    <VBFixedString(MAX_PATH), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=MAX_PATH)> Public cFileName As String
    '    <VBFixedString(14), System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst:=14)> Public cAlternate As String
    'End Structure

    'Declare Function FindFirstFile Lib "kernel32" Alias "FindFirstFileA" (ByVal lpFileName As String, ByRef lpFindFileData As WIN32_FIND_DATA) As Integer
    'Declare Function FindNextFile Lib "kernel32" Alias "FindNextFileA" (ByVal hFindFile As Integer, ByRef lpFindFileData As WIN32_FIND_DATA) As Integer
    Declare Function FindClose Lib "kernel32" (hFindFile As Integer) As Integer

    <DllImport("kernel32.dll", EntryPoint:="FindFirstFileW", SetLastError:=True, CharSet:=CharSet.Unicode)>
    Public Function FindFirstFileW(lpFileName As String, ByRef lpFindFileData As WIN32_FIND_DATAW) As Integer
    End Function

    <DllImport("kernel32.dll", EntryPoint:="FindNextFileW", SetLastError:=True, CharSet:=CharSet.Unicode)>
    Public Function FindNextFileW(hFindFile As Integer, ByRef lpFindFileData As WIN32_FIND_DATAW) As Integer
    End Function

    <StructLayout(LayoutKind.Sequential, CharSet:=CharSet.Unicode)>
    Public Structure WIN32_FIND_DATAW
        Public dwFileAttributes As Integer
        Public ftCreationTime As FILETIME
        Public ftLastAccessTime As FILETIME
        Public ftLastWriteTime As FILETIME
        Public nFileSizeHigh As Integer
        Public nFileSizeLow As Integer
        Public dwReserved0 As Integer
        Public dwReserved1 As Integer

        ' TCHAR array 260 (MAX_PATH) entries, 520 bytes in unicode
        <VBFixedString(520), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=520)> Public cFileName As String

        ' TCHAR array 14 TCHAR's alternate filename 28 byes in unicode
        <VBFixedString(28), MarshalAs(UnmanagedType.ByValTStr, SizeConst:=28)> Public cAlternate As String

    End Structure

    Public Sub EnumWin32()
        Dim hsearch As Long  ' handle to the file search
        Dim findinfo As WIN32_FIND_DATAW
        Dim success As Long  ' will be 1 if successive searches are successful, 0 if not
        Dim retval As Long  ' generic return value

        ' Warning BC42108: Variable 'findinfo' is passed by reference before it has been assigned a value. A null reference exception could result at runtime. Make sure the structure or all the reference members are initialized before use
#Disable Warning BC42108
        ' Begin a file search:
        hsearch = FindFirstFileW("C:\*.*", findinfo)
        If hsearch = -1 Then  ' no files match the search string
            Debug.Print("(no files matched search parameter)")
            Exit Sub
        End If

        Do
            WriteLine(findinfo.cFileName)
            success = FindNextFileW(hsearch, findinfo)
        Loop Until success = 0  ' keep looping until no more matching files are found

        ' Close the file search handle
        retval = FindClose(hsearch)
    End Sub

End Module
