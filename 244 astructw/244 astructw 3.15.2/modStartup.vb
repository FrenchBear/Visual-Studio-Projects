' Startup module for astructw
' 2006-10-03    FPVI
' 2007-01-04    FPVI    Option /c
' 2009-05-21    FPVI    Option /h renamed /j2; Help for option /c added
' 2009-05-22    FPVI    Option /j2 renamed /r2
' 2010-02-05    FPVI    Option /au (AddUpdate mode)
' 2010-02-14    FPVI    Option /t1 (Trace folders level 1)
' 2010-02-24    FPVI    3.6.1: Option /t1 --> /f
' 2010-04-05    FPVI    3.6.2: /t1:  Tolerance for 1hr difference (summer time issue on Buffalo)
' 2010-12-16    FPVI    3.7.1: /f1../f9 control depth of folder trace, and /f trace all folders
' 2013-02-28    FPVI    3.8.0: /xf to ignore a file (can be repeated)
' 2013-03-20    FPVI    3.9.0: /i to ignore Date differences in comparisons
' 2013-12-30    FPVI    3.9.1: Bug option /x fixed
' 2014-05-02    FPVI    3.10.0: Bug grosse=gro�e for VB Collection but not for filesystem.  Use class Kollection instead
' 2014-05-05    FPVI    3.11.0: Align filename case
' 2014-12-22    FPVI    3.12.0: Exclude by default files thumbs.db and .DS_Store
' 2017-12-18    FPVI    3.13: Case of Linux subsystem filesystem that is case sensitive on NTFS; Kollection is now generic; No need for synclock in readonly mode
' 2020-11-22    FPVI    3.14: Option /xp for path exclusions
' 2020-11-23    FPVI    3.15: Option /vx (verbose exclusions) and color error messages and verbose exclusions.  Generalization of Expander (multiple parts between {} separated by ,) for /x /xf and /vx
' 2020-11-25    FPVI    3.15.1: Transform source and dest in absolute paths to enable long paths support

Option Explicit On
Option Compare Text
Option Infer On


Imports System.IO

Friend Module modStartup
    Public sSourceGlobal As String
    Public sDestGlobal As String
    Public swOut As StreamWriter = Nothing

    Function Main(cmdArgs() As String) As Integer
        Dim returnValue As Integer = 0
        Dim bFinalPause As Boolean = False

        Dim iNonOpt As Integer = 0
        iFolderTraceLevel = 0       ' Default, no trace
        For argNum As Integer = 0 To UBound(cmdArgs, 1)
            Select Case cmdArgs(argNum)
                Case "?", "-?", "/?", "help", "-help", "/help"
                    CLShowHelp()
                    GoTo Sortie

                Case "??", "-??", "/??"
                    CLShowExtendedHelp()
                    GoTo Sortie

                Case "-v", "/v"
                    bVerbose = True

                Case "-vx", "/vx"
                    bVerboseX = True

                Case "-log", "/log"
                    If argNum = UBound(cmdArgs, 1) Then
                        CLShowError("Option " & cmdArgs(argNum) & " requires an argument")
                        returnValue = 1
                        GoTo Sortie
                    End If
                    argNum += 1
                    sLogPath = cmdArgs(argNum)

                Case "-f", "/f"
                    iFolderTraceLevel = 99

                Case "-f1", "/f1", "-f2", "/f2", "-f3", "/f3", "-f4", "/f4", "-f5", "/f5", "-f6", "/f6", "-f7", "/f7", "-f8", "/f8", "-f9", "/f9"
                    iFolderTraceLevel = Val(Mid(cmdArgs(argNum), 3, 1))

                Case "-t", "/t"
                    bDisableTimeCheck = True

                Case "-t1", "/t1"
                    bOneHourDifferenceAccepted = True

                Case "-i", "/i"
                    bIgnoreDateDifferences = True

                Case "-n", "/n"
                    bNoAction = True

                Case "-au", "/au"
                    bAddUpdate = True

                Case "-r2", "/r2"
                    bCopyDirectoryReparsePointContent = True

                Case "-p", "/p"
                    bFinalPause = True

                Case "-m", "/m"
                    bMultiThread = True

                Case "-d", "/d"
                    bDotNetCalls = True

                Case "-c", "/c"
                    bCreateTarget = True

                Case "-w-", "/w-"
                    bNoWidePaths = True

                Case "-x", "/x", "-xf", "/xf", "-xp", "/xp"
                    If argNum = UBound(cmdArgs, 1) Then
                        CLShowError("Option " & cmdArgs(argNum) & " requires an argument")
                        returnValue = 1
                        GoTo Sortie
                    End If
                    argNum += 1
                    For Each sOneExclusion As String In ExpandBracesSection(cmdArgs(argNum))
                        If cmdArgs(argNum - 1) = "-x" Or cmdArgs(argNum - 1) = "/x" Then
                            colExclusionsFolders.Add(sOneExclusion)
                        ElseIf cmdArgs(argNum - 1) = "-xf" Or cmdArgs(argNum - 1) = "/xf" Then
                            colExclusionsFiles.Add(sOneExclusion)
                        Else
                            colExclusionsPaths.Add(sOneExclusion)
                        End If
                    Next

                Case "-_", "/_"
                    colExclusionsFolders.Add("_*")

                Case Else
                    If Left(cmdArgs(argNum), 1) = "-" Or Left(cmdArgs(argNum), 1) = "/" Then
                        CLShowError("Unknown option " & cmdArgs(argNum))
                        returnValue = 1
                        GoTo Sortie
                    End If

                    Select Case iNonOpt
                        Case 0 : sSourceGlobal = cmdArgs(argNum)
                        Case 1 : sDestGlobal = cmdArgs(argNum)
                        Case Else
                            CLShowError("Invalid argument " & cmdArgs(argNum))
                            returnValue = 1
                            GoTo Sortie
                    End Select
                    iNonOpt += 1
            End Select
        Next
        If iNonOpt <> 2 Then
            CLShowError("Source and destination must be specified")
            returnValue = 1
            GoTo Sortie
        End If

        ' 3.15.1: Force source and dest to be absolute paths, because relative parts do nor support long filename model (\\?\...)
        sSourceGlobal = Path.GetFullPath(sSourceGlobal)
        sDestGlobal = Path.GetFullPath(sDestGlobal)

        ' New for 3.12, in absence of explicit exclusions, use this as default
        If colExclusionsFiles.Count = 0 Then
            colExclusionsFiles.Add("thumbs.db")
            colExclusionsFiles.Add(".DS_Store")
        End If

        If Not String.IsNullOrEmpty(sLogPath) Then
            Try
                swOut = New StreamWriter(sLogPath, False, Text.Encoding.UTF8)
            Catch ex As Exception
                CLShowError("Error opening log file: " + ex.Message)
                returnValue = 1
                GoTo Sortie
            End Try
            Using swOut
                Astruct(sSourceGlobal, sDestGlobal)
            End Using
        Else
            Astruct(sSourceGlobal, sDestGlobal)
        End If
Sortie:
        If bFinalPause Then
            Console.Write("(Pause)")
            Console.ReadLine()
        End If

        Return returnValue
    End Function

    'Private Sub TestExpander()
    '    TestExpander1("name", New String() {"name"})
    '    TestExpander1("n{am}e", New String() {"name"})
    '    TestExpander1("n{am}", New String() {"nam"})
    '    TestExpander1("{am}e", New String() {"ame"})
    '    TestExpander1("{am}", New String() {"am"})
    '    TestExpander1("n{a,m}e", New String() {"nae", "nme"})
    '    Stop
    'End Sub

    'Private Sub TestExpander1(s As String, ts As String())
    '    Dim res = New List(Of String)(ExpandBracesSection(s))
    '    Debug.Assert(res.Count = ts.Count)
    '    For Each s1 As String In ts
    '        Debug.Assert(res.Contains(s1))
    '    Next
    '    For Each s1 As String In res
    '        Debug.Assert(ts.Contains(s1))
    '    Next
    'End Sub

    ' Helper, breaks xx{aa,bb,cc}yy into xxaayy, xxbbyy, xxccyy like bash
    Private Iterator Function ExpandBracesSection(s As String) As IEnumerable(Of String)
        Dim p As Integer, q As Integer
        p = s.IndexOf("{"c)
        If p < 0 Then
            Yield s
            Return
        End If

        q = s.IndexOf("}"c, p + 1)
        If q < 0 Then
            CLShowError("No matching } in path exclusion " & Quote(s) & ", ignored")
            Yield s
            Return
        End If

        Dim ts = s.Substring(p + 1, q - p - 1).Split(","c)
        For Each sOne As String In ts
            Yield s.Substring(0, p) & sOne & s.Substring(q + 1)
        Next
    End Function

    Sub CLShowError(sMsg As String)
        TraceColor(ConsoleColor.Red, "atructw: " & sMsg)
    End Sub

    Sub CLShowExtendedHelp()
        Trace(HelpHeader() & vbCrLf & ExtendedHelp())
    End Sub

    Sub CLShowHelp()
        Trace(HelpHeader() & vbCrLf & vbCrLf & Usage())
    End Sub

    Function HelpHeader() As String
        Return "astructw " & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Revision & vbCrLf & My.Application.Info.Description
    End Function

    Function Usage() As String
        Return "Usage: astructw [/?] [/??] [/option ...] source destination" & vbCrLf &
               "Source and destination must be valid and existing folders" & vbCrLf & vbCrLf &
               "Common Options:" & vbCrLf &
               "/v      Verbose mode, detailed output" & vbCrLf &
               "/f[1-9] Folder trace during analysis, max to specified depth. /f=all levels" & vbCrLf &
               "/t      Disable time difference check between source and destination" & vbCrLf &
               "/x dir  Exclude dir from copy (ex: /x ""Temporary Internet Files""), repeatable" & vbCrLf &
               "/xf fil Exclude file (like pattern) from copy, repeatable" & vbCrLf &
               "/xp str Exclude paths containing str (ex: /xp \Windows\servicing\) from copy, repeatable" & vbCrLf &
               "/_      Do not copy files and folders beginning with _ (same as /x _*)" & vbCrLf &
               "/c      Creates target folder if it does not exists instead of causing an error" & vbCrLf &
               "/n      NoAction: Do not actually copy or delete anything on destination" & vbCrLf &
               "/au     AddUpdate mode, only update modified files and add new files"
    End Function

    Function ExtendedHelp() As String
        Return "Copyright " & My.Application.Info.Copyright & vbCrLf & vbCrLf &
               "Advanced Options:" & vbCrLf &
               "/d     Use DotNet calls for filesystem operations instead of Win32 calls" & vbCrLf &
               "/m     Multithreading: Enumerates folder contents in two separate threads" & vbCrLf &
               "/r2    Copy directory reparse point contents instead of ignoring then" & vbCrLf &
               "/t1    Tolerates exactly 1 hour difference between source and target" & vbCrLf &
               "/w-    Do not use wide paths extensions for Win32 calls" & vbCrLf &
               "/i     Ignores Date differences in comparisons" & vbCrLf &
               "/vx    Shows ignored files/folders in color" & vbCrLf &
          vbCrLf & "Note: SYSTEM+HIDDEN folders on source such as are always ignored"
    End Function

End Module