' Startup module for astructw
' 2006-10-03    FPVI
' 2007-01-04    FPVI    Option /c
' 2009-05-21    FPVI    Option /h renamed /j2; Help for option /c added
' 2009-05-22    FPVI    Option /j2 renamed /r2
' 2010-02-05    FPVI    Option /au (AddUpdate mode)
' 2010-02-14    FPVI    Option /t1 (Trace folders level 1)
' 2010-02-24    FPVI    3.6.1: Option /t1 --> /f

Option Compare Text

Module modStartup
    Public sSourceGlobal As String
    Public sDestGlobal As String

    Function Main(ByVal cmdArgs() As String) As Integer
        Dim returnValue As Integer = 0
        Dim bFinalPause As Boolean = False

        Dim iNonOpt As Integer = 0
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

                Case "-f", "/f"
                    bFolderTrace = True

                Case "-t", "/t"
                    bDisableTimeCheck = True

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

                Case "-x", "/x"
                    If argNum = UBound(cmdArgs, 1) Then
                        CLShowError("Option " & cmdArgs(argNum) & " requires an argument")
                        returnValue = 1
                        GoTo Sortie
                    End If
                    argNum += 1
                    colExclusions.Add(cmdArgs(argNum))

                Case "-_", "/_"
                    colExclusions.Add("_*")

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

        astruct(sSourceGlobal, sDestGlobal)
Sortie:
        If bFinalPause Then
            Console.Write("(Pause)")
            Console.ReadLine()
        End If

        Return returnValue
    End Function

    Sub CLShowError(ByVal sMsg As String)
        Console.WriteLine("atructw: " & sMsg)
    End Sub

    Sub CLShowExtendedHelp()
        Console.WriteLine(HelpHeaderString() & vbCrLf & ExtendedHelpString())
    End Sub

    Sub CLShowHelp()
        Console.WriteLine(HelpHeaderString() & vbCrLf & vbCrLf & UsageString())
    End Sub


    Function HelpHeaderString() As String
        Return "astructw " & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Revision & vbCrLf & My.Application.Info.Description
    End Function

    Function UsageString() As String
        Return "Usage: astructw [/?] [/??] [/option ...] source destination" & vbCrLf & _
               "Source and destination must be valid and existing folders" & vbCrLf & vbCrLf & _
               "Common Options:" & vbCrLf & _
               "/v     Verbose mode, detailed output" & vbCrLf & _
               "/f     Folder trace, output level 1 folders during analysis" & vbCrLf & _
               "/t     Disable time difference check between source and destination" & vbCrLf & _
               "/x dir Exclude dir from copy (ie: /x ""Temporary Internet Files"")" & vbCrLf & _
               "/_     Do not copy files and folders beginning with _ (same as /x _*)" & vbCrLf & _
               "/c     Creates target folder if it does not exists instead of causing an error" & vbCrLf & _
               "/n     NoAction: Do not actually copy or delete anything on destination" & vbCrLf & _
               "/au    AddUpdate mode, only update modified files and add new files"
    End Function

    Function ExtendedHelpString() As String
        Return "Copyright " & My.Application.Info.Copyright & vbCrLf & vbCrLf & _
               "Advanced Options:" & vbCrLf & _
               "/d     Use DotNet calls for filesystem operations instead of Win32 calls" & vbCrLf & _
               "/m     Multitreading: Enumerates folder contents in two separate threads" & vbCrLf & _
               "/r2    Copy directory reparse point contents instead of ignoring then" & vbCrLf & _
               "/w-    Do not use wide paths extensions for Win32 calls" & vbCrLf & _
          vbCrLf & "Note: SYSTEM+HIDDEN folders on source such as are always ignored"
    End Function
End Module
