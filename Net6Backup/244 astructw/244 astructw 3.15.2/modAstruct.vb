' module astruct
' Active code of astruct
' 2006-10-03    FPVI    First .Net version (3.0), both interactive and command line
' 2006-10-10    FPVI    Dropped interactive mode, added colExclusions, filtered SYS+HIDDEN, skip hard links
' 2006-10-11    FPVI    3.1 with win32 functions to enumerate files and folders (twice faster than .Net functions)
' 2006-10-19    FPVI    3.2 My.Computer.FileSystem.DeleteDirectory(sDest & sSubfolder, FileIO.DeleteDirectoryOption.DeleteAllContents) does not work if there is r/o file in the folder
'                       Use Win32 CopyFile, DeleteFile... to support paths with more than 260 characters
' 2006-10-20    FPVI    3.2.1 My.Computer.FileSystem.DeleteDirectory(sDest & sSubfolder, FileIO.DeleteDirectoryOption.DeleteAllContents) does not work if there is r/o file in the folder
' 2006-10-21    FPVI    3.3   Options mutlithread, DotNetCalls, NoWidePath
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
' 2010-12-17    FPVI    3.7.2: Repeat FindFirstFileW 4 times during enumerations to fix a bug on Synology DS1010+ on Shark
' 2010-12-17    FPVI    3.7.2: Limit number of errors collected to 1000
' 2017-12-18    FPVI    3.13: Case of Linux subsystem filesystem that is case sensitive on NTFS; Kollection is now generic; No need for synclock in readonly mode
' 2020-11-22    FPVI    3.14 (π edition!): Option /xp for path exclusions, colExclusionsPaths

Option Explicit On
Option Compare Text
Option Infer On


Imports System.IO
Imports System.Runtime.InteropServices

Friend Module modAstruct
    Dim nbFiles As Integer
    Dim nbDirectories As Integer
    Dim nbFilesCopied As Integer
    Dim nbFilesRenamed As Integer
    Dim nbFilesDeleted As Integer
    ReadOnly colErrors As New Collection

    Public bVerbose As Boolean                          ' Shows detailed info for each processed file
    Public bVerboseX As Boolean                         ' Shows exclusions in color
    Public iFolderTraceLevel As Integer                 ' Maximum depth for folder trace, 0=no trace
    Public bDisableTimeCheck As Boolean                 ' For interactive trace
    Public bNoAction As Boolean                         ' Show what should be done but actually does nothing
    Public bAddUpdate As Boolean                        ' Only add or update files, do not delete files/folders on destination
    Public bCopyDirectoryReparsePointContent As Boolean ' Copy what is behind a reparse point (a junction on NTFS volumes)
    Public bMultiThread As Boolean                      ' Enumerates folder contents in separate threads
    Public bDotNetCalls As Boolean                      ' Use .Net and not Win32
    Public bNoWidePaths As Boolean                      ' Do not use wide paths extension (WidePathString function)
    Public bCreateTarget As Boolean                     ' Create destination folder if it does not exist
    Public bOneHourDifferenceAccepted As Boolean        ' Consider files identical if they have 1hr difference (and same size)
    Public bIgnoreDateDifferences As Boolean        ' Only checks presence/absence and size

    Public colExclusionsFolders As New Kollection(Of String)       ' List of patterns to ignore for folders
    Public colExclusionsFiles As New Kollection(Of String)         ' List of patterns to ignore for files
    Public colExclusionsPaths As New Kollection(Of String)         ' List of patterns to ignore for paths

    Public sLogPath As String                           ' If defined, also write output in this file

    Const sNomficTTO As String = "$$--$$--.$-$"         ' Test TimeOffset


    ' Can't create an empty FileInfo, so I have to use my own class...
    Class MyFileInfo
        Public Name As String
        Public FullName As String
        Public Attributes As FileAttributes
        Public FileSize As ULong                    ' 64 bit
        Public LastWriteTime As Long                ' 64 bit (not ULong since subtraction can generate a negative value)
    End Class

    Friend Sub Trace(sMsg As String)
        swOut?.WriteLine(sMsg)
        Console.WriteLine(sMsg)
    End Sub

    Friend Sub TraceColor(color As ConsoleColor, sMsg As String)
        swOut?.WriteLine(sMsg)
        Dim cBak = Console.ForegroundColor
        Console.ForegroundColor = color
        Console.WriteLine(sMsg)
        Console.ForegroundColor = cBak
    End Sub



    Public Sub Astruct(sSource As String, sDest As String)
        ' If we used options, then show them explicitly
        Dim sOptions As String = ""
        If bVerbose Then sOptions &= ", Verbose"
        If bVerboseX Then sOptions &= ", Verbose Exclusions"
        If iFolderTraceLevel Then sOptions &= $", TraceFoldersLevel{CStr(iFolderTraceLevel)}"
        If bDisableTimeCheck Then sOptions &= ", NoTimeCheck"
        If bNoAction Then sOptions &= ", NoAction"
        If bOneHourDifferenceAccepted Then sOptions &= ", OneHourDifference"
        If bIgnoreDateDifferences Then sOptions &= ", IgnoreDateDifference"
        If bAddUpdate Then sOptions &= ", AddUpdate"
        If bCopyDirectoryReparsePointContent Then sOptions &= ", CopyDirectoryReparsePointContent"
        If bMultiThread Then sOptions &= ", MultiThread"
        If bDotNetCalls Then sOptions &= ", DotNetCalls"
        If bNoWidePaths Then sOptions &= ", NoWidePaths"
        If sOptions.Length > 0 Then
            Trace(HelpHeader() & " (" & sOptions.Substring(2) & ")")
        End If

        ' Create target folder if it does not exist and option /c has been specified
        Try
            If Not My.Computer.FileSystem.DirectoryExists(sDest) And bCreateTarget Then
                My.Computer.FileSystem.CreateDirectory(sDest)
            End If
        Catch ex As Exception
            TraceColor(ConsoleColor.Red, "Error creating target folder " & Quote(sDest))
            TraceColor(ConsoleColor.Red, ex.Message)
        End Try

        ' Get backup/restore privileges
        Const SE_BACKUP_NAME As String = "SeBackupPrivilege"
        EnableToken(SE_BACKUP_NAME)

        ' Source and destination must exist at this stage
        Dim bProblem As Boolean = False
        If Not IsFolderOk(sSource, "source") Then bProblem = True
        If Not IsFolderOk(sDest, "destination") Then bProblem = True
        If bProblem Then Exit Sub

        ' Normalize paths
        If Right(sSource, 1) <> "\" Then sSource &= "\"
        If Right(sDest, 1) <> "\" Then sDest &= "\"
        If Not bDisableTimeCheck Then
            If Not TimeCheck(sSource, sDest) Then Exit Sub
        End If

        Dim t1 As Date = Date.Now
        nbFiles = 0
        nbDirectories = 0
        nbFilesCopied = 0
        nbFilesRenamed = 0
        nbFilesDeleted = 0
        Trace("astructw " & Quote(sSource) & " -> " & Quote(sDest))

        DoAstruct(sSource, sDest, 1)
        Dim t2 As Date = Date.Now
        Dim ts As TimeSpan = t2 - t1
        If colErrors.Count > 0 Then
            Trace("")
            Trace(colErrors.Count.ToString & " error" & S(colErrors.Count) & ":")
            For Each s As String In colErrors
                Trace(s.Replace("|", " ==> "))
            Next
        End If
        Trace("")
        Trace(nbDirectories.ToString & " folder" & S(nbDirectories) & " analyzed, " & nbFiles.ToString & " file" & S(nbFiles) & " analyzed")
        Trace(nbFilesCopied.ToString & " file" & S(nbFilesCopied) & " copied, " & nbFilesDeleted.ToString & " file" & S(nbFilesDeleted) & " deleted, " & nbFilesRenamed.ToString & " file" & S(nbFilesRenamed) & " renamed")
        If colErrors.Count > 0 Then Trace(colErrors.Count.ToString & " error" & S(colErrors.Count) & " reported")
        Trace(String.Format("Total time {0}:{1:D2}.{2:D3}s", Int(ts.TotalMinutes), ts.Seconds, ts.Milliseconds))
    End Sub

    Private Function IsFolderOk(sFolder As String, sPosition As String) As Boolean
        Try
            If My.Computer.FileSystem.DirectoryExists(sFolder) Then Return True
            CLShowError("Can't find " & sPosition & " folder " & Quote(sFolder))
        Catch ex As Exception
            Trace("Error accessing " & sPosition & " folder " & Quote(sFolder))
            Trace(ex.Message)
        End Try
        Return False
    End Function

    Private Function S(n As Integer) As String
        If n > 1 Then
            Return "s"
        Else
            Return vbNullString
        End If
    End Function

    Friend Function Quote(s As String)
        If s.Contains(" ") Then
            Return Chr(34) & s & Chr(34)
        Else
            Return s
        End If
    End Function

    ' 3.7.2: Limit number of errors collected to 1000
    Private Sub AddError(sErrMsg As String)
        If colErrors.Count < 1000 Then colErrors.Add(sErrMsg)
    End Sub

    ' For mutlithread option
    Delegate Sub EnumProc(sPath As String, colFoldersSource As Kollection(Of String), colFilesSource As Kollection(Of MyFileInfo))

    Private Sub DoAstruct(sSource As String, sDest As String, iLevel As Integer)
        Dim colFilesSource As New Kollection(Of MyFileInfo)
        Dim colFilesDest As New Kollection(Of MyFileInfo)
        Dim colFoldersSource As New Kollection(Of String)
        Dim colFoldersDest As New Kollection(Of String)

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
            Trace("-- Source folder " & Quote(sSource) & ": " & colFilesSource.Count.ToString & " file" & S(colFilesSource.Count.ToString) & ", " & colFoldersSource.Count.ToString & " folder" & S(colFoldersSource.Count.ToString))
        End If

        Dim sCmd As String
        ' 1. Copy all files that exist on source and do not exist on dest, or files that are different
        For Each fiSource As MyFileInfo In colFilesSource
            nbFiles += 1
            If Not colFilesDest.Contains(fiSource.Name) Then
                sCmd = "copy " & Quote(sSource & fiSource.Name) & " " & Quote(sDest & fiSource.Name)
                If bVerbose Then Trace("-- Source file " & Quote(sSource & fiSource.Name) & " does not exist in dest folder " & Quote(sDest) & " --> Copy")
                Trace(sCmd)
                nbFilesCopied += 1
                If Not bNoAction Then MyCopyFile(sSource & fiSource.Name, sDest & fiSource.Name)
            Else
                ' File exist on dest.  Is it the same?
                Dim fiDest As MyFileInfo = colFilesDest(fiSource.Name)
                Dim bToCopy As Boolean = False
                If fiSource.FileSize <> fiDest.FileSize Then
                    If bVerbose Then
                        Trace("-- Source size " & Quote(sSource & fiSource.Name) & ": " & fiSource.FileSize.ToString)
                        Trace("-- Dest size " & Quote(sDest & fiDest.Name) & ": " & fiDest.FileSize.ToString & " --> Copy")
                    End If
                    bToCopy = True
                ElseIf (Not bIgnoreDateDifferences) AndAlso Math.Abs((fiSource.LastWriteTime - fiDest.LastWriteTime) / 10000000) > 2 Then
                    If bOneHourDifferenceAccepted Then
                        Dim t1, t2 As Long
                        t1 = fiSource.LastWriteTime
                        t2 = fiDest.LastWriteTime
                        If t2 < t1 Then
                            Dim t3 As Long
                            t3 = t1
                            t1 = t2
                            t2 = t3
                        End If
                        Dim delta As Long
                        delta = (t2 - t1) / 10000000
                        If delta >= 3599 And delta <= 3601 Then GoTo Label1
                    End If
                    If bVerbose Then
                        Trace("-- Source LastWrite on " & Date.FromFileTime(fiSource.LastWriteTime).ToString & " " & Quote(sSource & fiSource.Name))
                        Trace("-- Dest   LastWrite on " & Date.FromFileTime(fiDest.LastWriteTime).ToString & " " & Quote(sDest & fiDest.Name) & " --> Copy")
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
                        sCmd &= Quote(sDest & fiDest.Name)
                        Trace(sCmd)
                        If Not bNoAction Then
                            If bDotNetCalls Then
                                Try
                                    File.SetAttributes(sDest & fiDest.Name, fiDest.Attributes And Not (FileAttributes.ReadOnly Or FileAttributes.Hidden))
                                Catch ex As Exception
                                    TraceColor(ConsoleColor.Red, "*** Caused error: " & ex.Message)
                                    AddError(sCmd & "|" & ex.Message)
                                End Try
                            Else
                                Dim bRet As Integer = SetFileAttributes(WidePath(sDest & fiDest.Name), fiDest.Attributes And Not (FileAttributes.ReadOnly Or FileAttributes.Hidden))
                                If bRet = 0 Then TraceWin32Error(sCmd)
                            End If
                        End If
                    End If
                    sCmd = "copy " & Quote(sSource & fiSource.Name) & " " & Quote(sDest & fiSource.Name)
                    Trace(sCmd)
                    nbFilesCopied += 1
                    If Not bNoAction Then MyCopyFile(sSource & fiSource.Name, sDest & fiSource.Name)
                End If

                ' New for 3.11: Check that case is identical, otherwise rename
                If StrComp(fiSource.Name, fiDest.Name, CompareMethod.Binary) Then
                    ' Should rename
                    sCmd = "ren " & Quote(sDest & fiDest.Name) & " " & Quote(fiSource.Name)
                    Trace(sCmd)
                    nbFilesRenamed += 1
                    If Not bNoAction Then MyRenameFile(sDest, fiDest.Name, fiSource.Name)
                End If
            End If
        Next

        ' 2. Delete all files that exist on dest but do not exist on source
        If Not bAddUpdate Then
            For Each fiDest As MyFileInfo In colFilesDest
                If Not colFilesSource.Contains(fiDest.Name) Then
                    ' If dest exists and is readonly, remove attribute first
                    If (Not bNoAction) And ((fiDest.Attributes And FileAttributes.ReadOnly) = FileAttributes.ReadOnly OrElse (fiDest.Attributes And FileAttributes.Hidden) = FileAttributes.Hidden OrElse (fiDest.Attributes And FileAttributes.System) = FileAttributes.System) Then
                        sCmd = "attrib -rhs " & Quote(sDest & fiDest.Name)
                        Trace(sCmd)
                        If bDotNetCalls Then
                            Try
                                'File.SetAttributes(sDest & fiDest.Name, fiDest.Attributes And Not FileAttributes.ReadOnly)
                                File.SetAttributes(sDest & fiDest.Name, FileAttributes.Normal)
                            Catch ex As Exception
                                TraceColor(ConsoleColor.Red, "*** Caused error: " & ex.Message)
                                AddError(sCmd & "|" & ex.Message)
                            End Try
                        Else
                            Dim bRet As Integer = SetFileAttributes(WidePath(sDest & fiDest.Name), FileAttributes.Normal)
                            If bRet = 0 Then TraceWin32Error(sCmd)
                        End If
                    End If
                    sCmd = "del " & Quote(sDest & fiDest.Name)
                    Trace(sCmd)
                    nbFilesDeleted += 1
                    If Not bNoAction Then
                        If bDotNetCalls Then
                            Try
                                My.Computer.FileSystem.DeleteFile(sDest & fiDest.Name)
                            Catch ex As Exception
                                TraceColor(ConsoleColor.Red, "*** Caused error: " & ex.Message)
                                AddError(sCmd & "|" & ex.Message)
                            End Try
                        Else
                            Dim bRet As Boolean = DeleteFile(WidePath(sDest & fiDest.Name))
                            If bRet = 0 Then TraceWin32Error(sCmd)
                        End If
                    End If
                End If
            Next
        End If

        ' 3. Recursively process subdirectories, creating missing subdirectories
        For Each sSubfolder As String In colFoldersSource
            If iLevel <= iFolderTraceLevel Then
                Trace("Processing " & Quote(sSource & sSubfolder))
            End If
            nbDirectories += 1
            If Not colFoldersDest.Contains(sSubfolder) Then
                sCmd = "mkdir " & Quote(sDest & sSubfolder)
                Trace(sCmd)
                If Not bNoAction Then
                    If bDotNetCalls Then
                        Try
                            My.Computer.FileSystem.CreateDirectory(sDest & sSubfolder)
                        Catch ex As Exception
                            TraceColor(ConsoleColor.Red, "*** Caused error: " & ex.Message)
                            AddError(sCmd & "|" & ex.Message)
                            ' In this case, don't attempt to do recurse astruct
                            Continue For
                        End Try
                    Else
                        Dim bRet As Boolean = CreateDirectory(WidePath(sDest & sSubfolder), IntPtr.Zero)
                        If bRet = 0 Then
                            TraceWin32Error(sCmd)
                        End If
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
                        sCmd = "rd /s " & Quote(sDest & sSubfolder)
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
    Private Sub RecurseDeleteDirectory(sPath As String)
        Dim colFiles As New Kollection(Of MyFileInfo)
        Dim colFolders As New Kollection(Of String)

        If Right(sPath, 1) <> "\" Then sPath &= "\"
        Enumerate(sPath, colFolders, colFiles)
        For Each sFolderName As String In colFolders
            RecurseDeleteDirectory(sPath & sFolderName & "\")
        Next
        Dim sCmd As String
        For Each f As MyFileInfo In colFiles
            If (f.Attributes And FileAttributes.ReadOnly) = FileAttributes.ReadOnly OrElse (f.Attributes And FileAttributes.Hidden) = FileAttributes.Hidden OrElse (f.Attributes And FileAttributes.System) = FileAttributes.System Then
                sCmd = "attrib -rhs " & Quote(f.FullName)
                Trace(sCmd)
                ' No need to check bNoAction since if it's False, RecurseDeleteDirectory is not called
                If bDotNetCalls Then
                    Try
                        f.Attributes = f.Attributes And Not FileAttributes.ReadOnly
                    Catch ex As Exception
                        TraceColor(ConsoleColor.Red, "*** Caused error: " & ex.Message)
                        AddError(sCmd & "|" & ex.Message)
                    End Try
                Else
                    Dim bRet As Integer = SetFileAttributes(WidePath(f.FullName), FileAttributes.Normal)
                    If bRet = 0 Then TraceWin32Error(sCmd)
                End If
            End If
            sCmd = "del " & Quote(f.FullName)
            Trace(sCmd)
            If bDotNetCalls Then
                Try
                    My.Computer.FileSystem.DeleteFile(f.FullName)
                Catch ex As Exception
                    TraceColor(ConsoleColor.Red, "*** Caused error: " & ex.Message)
                    AddError(sCmd & "|" & ex.Message)
                End Try
            Else
                Dim bRet As Boolean = DeleteFile(WidePath(f.FullName))
                If bRet = 0 Then TraceWin32Error(sCmd)
            End If
        Next
        sCmd = "rd " & Quote(sPath)
        Trace(sCmd)
        If bDotNetCalls Then
            Try
                My.Computer.FileSystem.DeleteDirectory(sPath, FileIO.DeleteDirectoryOption.DeleteAllContents)
            Catch ex As Exception
                TraceColor(ConsoleColor.Red, "*** Caused error: " & ex.Message)
                AddError(sCmd & "|" & ex.Message)
            End Try
        Else
            Dim bRet As Boolean = RemoveDirectory(WidePath(sPath))
            If bRet = 0 Then TraceWin32Error(sCmd)
        End If
    End Sub

    Private Function TimeCheck(sSource As String, sDest As String) As Boolean
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
            MyCopyFile(sPathSource, sPathDest)
            Dim fiDest As New FileInfo(sPathDest)

            Dim dt As TimeSpan = fiSource.LastWriteTimeUtc - fiDest.LastWriteTimeUtc
            If Math.Abs(dt.TotalSeconds) <= 2 Then
                bReturn = True
            Else
                TraceColor(ConsoleColor.Red, "*** Time offset check detected a difference between source and destination")
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

    Private Sub MyCopyFile(sourcePath As String, destinationPath As String)
        If bDotNetCalls Then
            Try
                My.Computer.FileSystem.CopyFile(sourcePath, destinationPath, True)
            Catch ex As Exception
                TraceColor(ConsoleColor.Red, "*** Caused error: " & ex.Message)
                AddError("CopyFile(""" & sourcePath & """, """ & destinationPath & """)|" & ex.Message)
            End Try
        Else
            Dim cancel As Boolean = False
            Dim bRet As Integer = CopyFileEx(WidePath(sourcePath), WidePath(destinationPath), Nothing, 0, cancel, COPY_FILE_ALLOW_DECRYPTED_DESTINATION)
            If bRet = 0 Then
                TraceWin32Error("CopyFileEx(""" & sourcePath & """, """ & destinationPath & "")
                Exit Sub
            End If
        End If
    End Sub

    ' New for 3.11
    Private Sub MyRenameFile(targetPath As String, oldName As String, newName As String)
        If bDotNetCalls Then
            Dim tempName As String = Guid.NewGuid.ToString
            Try
                My.Computer.FileSystem.RenameFile(targetPath & oldName, tempName)
            Catch ex As Exception
                TraceColor(ConsoleColor.Red, "*** Caused error: " & ex.Message)
                AddError("Rename(""" & targetPath & oldName & """, """ & tempName & """)|" & ex.Message)
            End Try
            Try
                My.Computer.FileSystem.RenameFile(targetPath & tempName, newName)
            Catch ex As Exception
                TraceColor(ConsoleColor.Red, "*** Caused error: " & ex.Message)
                AddError("Rename(""" & targetPath & tempName & """, """ & newName & """)|" & ex.Message)
            End Try
        Else
            Dim bRet As Integer = MoveFile(WidePath(targetPath & oldName), WidePath(targetPath & newName))
            If bRet = 0 Then
                TraceWin32Error("MoveFile(""" & targetPath & oldName & """, """ & targetPath & newName & "")
                Exit Sub
            End If
        End If
    End Sub

    Private Sub TraceWin32Error(sCmd As String)
        Dim sErr As String = $"{Marshal.GetLastWin32Error}: {New ComponentModel.Win32Exception().Message}"
        If InStr(sErr, vbCr) > 0 Then sErr = Replace(sErr, vbCr, " ")
        If InStr(sErr, vbLf) > 0 Then sErr = Replace(sErr, vbLf, " ")
        sErr = Trim(sErr)
        TraceColor(ConsoleColor.Red, "*** Caused error " & sErr)
        AddError(sCmd & "|" & "Error " & sErr)
    End Sub

    ''' <summary>
    ''' Function to use filenames up to 32000 characters.  According to Win32 help:
    ''' The Unicode versions of several functions permit paths that exceed the MAX_PATH length if the path has the "\\?\" prefix.
    ''' The "\\?\" tells the function to turn off path parsing. However, each component in the path cannot be more than MAX_PATH
    ''' characters long. Use the "\\?\" prefix with paths for local storage devices and the "\\?\UNC\" prefix with paths having
    ''' the Universal Naming Convention (UNC) format. The "\\?\" is ignored as part of the path. For example, "\\?\C:\myworld\private"
    ''' is seen as "C:\myworld\private", and "\\?\UNC\bill_g_1\hotstuff\coolapps" is seen as "\\bill_g_1\hotstuff\coolapps".
    ''' </summary>
    Private Function WidePath(sPath As String) As String
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
    Private Sub Enumerate(sPath As String, colFoldersSource As Kollection(Of String), colFilesSource As Kollection(Of MyFileInfo))
        Dim hsearch As IntPtr  ' handle to the file search
        Dim findinfo As WIN32_FIND_DATAW = Nothing
        Dim success As Long  ' will be 1 if successive searches are successful, 0 if not
        Dim retval As Long  ' generic return value

        ' Ignore path exclusions before starting enumeration
        For Each sExcl As String In colExclusionsPaths
            If sPath.IndexOf(sExcl, StringComparison.InvariantCultureIgnoreCase) >= 0 Then
                If bVerboseX Then TraceColor(ConsoleColor.Cyan, "Skip enumaration of folder " & Quote(sPath) & " because of path exclusion match")
                Exit Sub
            End If
        Next

        Dim s As String = WidePath(sPath) & "*"
        hsearch = FindFirstFileW(s, findinfo)
        ' astructw 3.7.2, Try again for Synology DS1010+ on Shark after waiting a bit...
        If hsearch = -1 Then
            For i As Integer = 1 To 10
                Threading.Thread.Sleep(10)
                hsearch = FindFirstFileW(s, findinfo)
                If hsearch <> -1 Then Exit For
            Next
        End If
        If Not hsearch = -1 Then  ' no files match the search string
            Do
                If findinfo.dwFileAttributes And FileAttributes.Directory Then
                    ' Ignore special folders
                    If findinfo.cFileName = "." Or findinfo.cFileName = ".." Then GoTo NextFile
                    ' Ignore folders exclusions
                    For Each sExcl As String In colExclusionsFolders
                        If findinfo.cFileName Like sExcl Then
                            If bVerboseX Then TraceColor(ConsoleColor.Cyan, "Ignored folder " & Quote(sPath & findinfo.cFileName) & " because of folder exclusion match")
                            GoTo NextFile
                        End If
                    Next

                    For Each sExcl As String In colExclusionsPaths
                        If (sPath & findinfo.cFileName & "\").IndexOf(sExcl, StringComparison.InvariantCultureIgnoreCase) >= 0 Then
                            If bVerboseX Then TraceColor(ConsoleColor.Cyan, "Ignored folder " & Quote(sPath & findinfo.cFileName) & " because of path exclusion match")
                            GoTo NextFile
                        End If
                    Next

                    ' Ignore SYSTEM+HIDDEN folders on source
                    If (findinfo.dwFileAttributes And FileAttributes.Hidden) <> FileAttributes.Hidden OrElse (findinfo.dwFileAttributes And FileAttributes.System) <> FileAttributes.System Then
                        If (findinfo.dwFileAttributes And FileAttributes.ReparsePoint) = FileAttributes.ReparsePoint Then
                            ' Special processing for reparse points
                            If bCopyDirectoryReparsePointContent Then
                                ' register for copy
                                colFoldersSource.Add(findinfo.cFileName, findinfo.cFileName)
                            Else
                                If bVerboseX Then TraceColor(ConsoleColor.Cyan, "Ignored reparse point " & Quote(sPath & findinfo.cFileName))
                            End If
                        ElseIf colFoldersSource.Contains(findinfo.cFileName) Then
                            Dim sErr As String = "Source folder " & Quote(sPath) & " contains folders that only differs by case: " + Quote(colFoldersSource(findinfo.cFileName)) + " and " + Quote(findinfo.cFileName) + ", only one gets copied."
                            TraceColor(ConsoleColor.Red, "*** " + sErr)
                            AddError(sErr)
                        Else
                            ' Normal folder, register for copy
                            colFoldersSource.Add(findinfo.cFileName, findinfo.cFileName)
                        End If
                    Else
                        If bVerboseX Then TraceColor(ConsoleColor.Cyan, "Ignored SYSTEM+HIDDEN folder " & Quote(sPath & findinfo.cFileName))
                    End If
                Else
                    ' Ignore files exclusions
                    For Each sExcl As String In colExclusionsFiles
                        If findinfo.cFileName Like sExcl Then
                            If bVerboseX Then TraceColor(ConsoleColor.Cyan, "Ignored file " & Quote(sPath & findinfo.cFileName) & " because of file exclusion match")
                            GoTo NextFile
                        End If
                    Next

                    If colFilesSource.Contains(findinfo.cFileName) Then
                        Dim sErr As String = "Source folder " + Quote(sPath) + " contains files that only differs by case: " + Quote(colFilesSource(findinfo.cFileName).Name) + " and " + Quote(findinfo.cFileName) + ", only one gets copied."
                        TraceColor(ConsoleColor.Red, "*** " + sErr)
                        AddError(sErr)
                    ElseIf findinfo.cFileName <> sNomficTTO Then
                        Dim fi As MyFileInfo
                        fi = New MyFileInfo With {
                            .Name = findinfo.cFileName,
                            .FullName = sPath & findinfo.cFileName,
                            .Attributes = findinfo.dwFileAttributes,
                            .FileSize = findinfo.nFileSizeHigh * 4294967296 + findinfo.nFileSizeLow,
                            .LastWriteTime = findinfo.ftLastWriteTime.dwHighDate * 4294967296 + findinfo.ftLastWriteTime.dwLowDate
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

End Module