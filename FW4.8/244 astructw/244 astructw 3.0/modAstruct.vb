' module astruct
' Active code of astruct
' 2006-10-03    FPVI    First version, both interactive and command line
' 2006-10-10    FPVI    Dropped interactive mode, added colExclusions, filtered SYS+HIDDEN, skip hard links

Imports System.IO
Imports VB = Microsoft.VisualBasic


Module modAstruct
    Dim nbFiles As Integer
    Dim nbDirectories As Integer
    Dim nbFilesCopied As Integer
    Dim nbFilesDeleted As Integer
    ReadOnly colErrors As New Collection

    Public bVerbose As Boolean
    Public bDisableTimeCheck As Boolean     ' For interactive trace
    Public bNoAction As Boolean
    Public bFollowLinks As Boolean          ' Copy what is behind a reparse point (a junction/HTFS link)
    Public colExclusions As New Collection  ' List of patterns to ignore

    Public m_ListBox As ListBox

    Const sNomficTTO As String = "$$--$$--.$-$"  ' Test TimeOffset


    Public Sub Astruct(ByVal sSource As String, ByVal sDest As String)
        If bNoAction Then Console.WriteLine(HelpHeaderString() & " (noaction)")
        Dim bProblem As Boolean = False
        If Not IsCheckFolder(sSource, "source") Then bProblem = True
        If Not IsCheckFolder(sDest, "destination") Then bProblem = True
        If bProblem Then Exit Sub

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
        DoAstructDictionary(sSource, sDest)
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

    Sub Trace(ByVal sMsg As String)
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

    Function S(ByVal n As Integer) As String
        If n > 1 Then
            Return "s"
        Else
            Return vbNullString
        End If
    End Function


    Function QuoteString(ByVal s As String)
        If s.Contains(" ") Then
            Return Chr(34) & s & Chr(34)
        Else
            Return s
        End If
    End Function



    ' Implementation with dictionaries 
    Private Sub DoAstructDictionary(ByVal sSource As String, ByVal sDest As String)
        Dim dSource As New DirectoryInfo(sSource)
        Dim dDest As New DirectoryInfo(sDest)

        Dim tFilesSource As FileInfo() = dSource.GetFiles
        Dim tFilesDest As FileInfo() = dDest.GetFiles
        Dim tSubdirectoriesSource As DirectoryInfo() = dSource.GetDirectories
        Dim tSubDirectoriesDest As DirectoryInfo() = dDest.GetDirectories

        ' Build dictionaries with files/subdirectories infos
        Dim dicFilesSource As New Dictionary(Of String, FileInfo)(tFilesSource.Length, StringComparer.OrdinalIgnoreCase)
        Dim dicFilesDest As New Dictionary(Of String, FileInfo)(tFilesDest.Length, StringComparer.OrdinalIgnoreCase)
        Dim dicSubdirectoriesSource As New Dictionary(Of String, DirectoryInfo)(tSubdirectoriesSource.Length, StringComparer.OrdinalIgnoreCase)
        Dim dicSubdirectoriesDest As New Dictionary(Of String, DirectoryInfo)(tSubDirectoriesDest.Length, StringComparer.OrdinalIgnoreCase)

        For Each fiSource As FileInfo In tFilesSource
            dicFilesSource.Add(fiSource.Name, fiSource)
        Next
        For Each fiDest As FileInfo In tFilesDest
            dicFilesDest.Add(fiDest.Name, fiDest)
        Next
        For Each diSource As DirectoryInfo In tSubdirectoriesSource
            ' Ignore SYSTEM+HIDDEN directories on source
            If (diSource.Attributes And FileAttributes.Hidden) <> FileAttributes.Hidden OrElse (diSource.Attributes And FileAttributes.System) <> FileAttributes.System Then
                If bFollowLinks Or (diSource.Attributes And FileAttributes.ReparsePoint) <> FileAttributes.ReparsePoint Then
                    ' Ignore exclusions
                    For Each s As String In colExclusions
                        If diSource.Name Like s Then GoTo NextSource
                    Next
                    dicSubdirectoriesSource.Add(diSource.Name, diSource)
                End If
            End If
NextSource:
        Next
        For Each diDest As DirectoryInfo In tSubDirectoriesDest
            ' Ignore SYSTEM+HIDDEN directories on destination
            If (diDest.Attributes And FileAttributes.Hidden) <> FileAttributes.Hidden OrElse (diDest.Attributes And FileAttributes.System) <> FileAttributes.System Then
                ' Ignore exclusions
                For Each s As String In colExclusions
                    If diDest.Name Like s Then GoTo NextDest
                Next
                dicSubdirectoriesDest.Add(diDest.Name, diDest)
            End If
NextDest:
        Next

        If bVerbose Then
            Trace("-- Source folder " & QuoteString(sSource) & ": " & dicFilesSource.Count.ToString & " file" & s(dicFilesSource.Count.ToString) & ", " & dicSubdirectoriesSource.Count.ToString & " folder" & s(dicSubdirectoriesSource.Count.ToString))
        End If

        Dim sCmd As String
        ' 1. Copy all files that exist on source and do not exist on dest, or files that are different
        For Each fiSource As FileInfo In tFilesSource
            nbFiles += 1
            If Not dicFilesDest.ContainsKey(fiSource.Name) Then
                sCmd = "copy " & QuoteString(sSource & fiSource.Name) & " " & QuoteString(sDest & fiSource.Name)
                If bVerbose Then Trace("-- Source file " & QuoteString(sSource & fiSource.Name) & " does not exist in dest folder " & QuoteString(sDest) & " --> Copy")
                Trace(sCmd)
                nbFilesCopied += 1
                If Not bNoAction Then
                    Try
                        My.Computer.FileSystem.CopyFile(sSource & fiSource.Name, sDest & fiSource.Name)
                    Catch ex As Exception
                        Trace("*** Caused error: " & ex.Message)
                        colErrors.Add(sCmd & "|" & ex.Message)
                    End Try
                End If
            Else
                ' File exist on dest.  Is it the same?
                Dim fiDest As FileInfo = dicFilesDest(fiSource.Name)
                Dim bToCopy As Boolean = False
                If fiSource.Length <> fiDest.Length Then
                    If bVerbose Then
                        Trace("-- Source size " & QuoteString(sSource & fiSource.Name) & ": " & fiSource.Length.ToString)
                        Trace("-- Dest size " & QuoteString(sDest & fiDest.Name) & ": " & fiDest.Length.ToString & " --> Copy")
                    End If
                    bToCopy = True
                ElseIf Math.Abs(CType(fiSource.LastWriteTimeUtc - fiDest.LastWriteTimeUtc, TimeSpan).TotalSeconds) > 2 Then
                    If bVerbose Then
                        Trace("-- Source timestamp " & QuoteString(sSource & fiSource.Name) & ": " & fiSource.LastWriteTimeUtc)
                        Trace("-- Dest timestamp " & QuoteString(sDest & fiDest.Name) & ": " & fiDest.LastWriteTimeUtc & " --> Copy")
                    End If
                    bToCopy = True
                End If
                If bToCopy AndAlso Not bNoAction Then
                    ' If dest exists and is readonly, remove attribute first
                    If (fiDest.Attributes And FileAttributes.ReadOnly) = FileAttributes.ReadOnly Then
                        sCmd = "attrib -h " & QuoteString(sDest & fiDest.Name)
                        Trace(sCmd)
                        Try
                            System.IO.File.SetAttributes(sDest & fiDest.Name, fiDest.Attributes And Not FileAttributes.ReadOnly)
                        Catch ex As Exception
                            Trace("*** Caused error: " & ex.Message)
                            colErrors.Add(sCmd & "|" & ex.Message)
                        End Try
                    End If
                    sCmd = "copy " & QuoteString(sSource & fiSource.Name) & " " & QuoteString(sDest & fiSource.Name)
                    Trace(sCmd)
                    nbFilesCopied += 1
                    Try
                        My.Computer.FileSystem.CopyFile(sSource & fiSource.Name, sDest & fiSource.Name, True)
                    Catch ex As Exception
                        Trace("*** Caused error: " & ex.Message)
                        colErrors.Add(sCmd & "|" & ex.Message)
                    End Try
                End If
            End If
        Next

        ' 2. Delete all files that exist on dest but do not exist on source
        For Each fiDest As FileInfo In tFilesDest
            If Not dicFilesSource.ContainsKey(fiDest.Name) Then
                ' If dest exists and is readonly, remove attribute first
                If (Not bNoAction) And (fiDest.Attributes And FileAttributes.ReadOnly) = FileAttributes.ReadOnly Then
                    sCmd = "attrib -h " & QuoteString(sDest & fiDest.Name)
                    Trace(sCmd)
                    Try
                        System.IO.File.SetAttributes(sDest & fiDest.Name, fiDest.Attributes And Not FileAttributes.ReadOnly)
                    Catch ex As Exception
                        Trace("*** Caused error: " & ex.Message)
                        colErrors.Add(sCmd & "|" & ex.Message)
                    End Try
                End If
                sCmd = "del " & QuoteString(sDest & fiDest.Name)
                Trace(sCmd)
                nbFilesDeleted += 1
                If Not bNoAction Then
                    Try
                        My.Computer.FileSystem.DeleteFile(sDest & fiDest.Name)
                    Catch ex As Exception
                        Trace("*** Caused error: " & ex.Message)
                        colErrors.Add(sCmd & "|" & ex.Message)
                    End Try
                End If
            End If
        Next

        ' 3. Recursively process subdirectories, creating missing subdirectories
        For Each diSource As DirectoryInfo In tSubdirectoriesSource
            nbDirectories += 1
            If Not dicSubdirectoriesDest.ContainsKey(diSource.Name) Then
                sCmd = "mkdir " & QuoteString(sDest & diSource.Name)
                Trace(sCmd)
                If Not bNoAction Then
                    Try
                        My.Computer.FileSystem.CreateDirectory(sDest & diSource.Name)
                    Catch ex As Exception
                        Trace("*** Caused error: " & ex.Message)
                        colErrors.Add(sCmd & "|" & ex.Message)
                        ' In this case, don't attempt to do recurse astruct
                        Continue For
                    End Try
                End If
            End If
            DoAstructDictionary(sSource & diSource.Name & "\", sDest & diSource.Name & "\")
        Next

        ' 4. Remove extra subdirectories on dest
        For Each diDest As DirectoryInfo In tSubDirectoriesDest
            If Not dicSubdirectoriesSource.ContainsKey(diDest.Name) Then
                sCmd = "rd /s " & QuoteString(sDest & diDest.Name)
                Trace(sCmd)
                If Not bNoAction Then
                    Try
                        My.Computer.FileSystem.DeleteDirectory(sDest & diDest.Name, FileIO.DeleteDirectoryOption.DeleteAllContents)
                    Catch ex As Exception
                        Trace("*** Caused error: " & ex.Message)
                        colErrors.Add(sCmd & "|" & ex.Message)
                    End Try
                End If
            End If
        Next
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
            My.Computer.FileSystem.CopyFile(sPathSource, sPathDest)
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

End Module
