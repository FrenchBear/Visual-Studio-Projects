' Startup module for astructw
' 2006-10-03    FPVI

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

                Case "-t", "/t"
                    bDisableTimeCheck = True

                Case "-n", "/n"
                    bNoAction = True

                Case "-h", "/h"
                    bFollowLinks = True

                Case "-p", "/p"
                    bFinalPause = True

                Case "-x", "/x"
                    If argNum = UBound(cmdArgs, 1) Then
                        CLShowError("Option -x requires an argument")
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

        Astruct(sSourceGlobal, sDestGlobal)
        If bFinalPause Then
            Console.Write("(Pause)")
            Console.ReadLine()
        End If

Sortie:
        Return returnValue
    End Function

    Sub CLShowError(ByVal sMsg As String)
        Console.WriteLine("atructw: " & sMsg)
    End Sub

    Sub CLShowExtendedHelp()
        Console.WriteLine(HelpHeaderString() & vbCrLf & vbCrLf & ExtendedHelpString())
    End Sub

    Sub CLShowHelp()
        Console.WriteLine(HelpHeaderString() & vbCrLf & vbCrLf & UsageString())
    End Sub


    Function HelpHeaderString() As String
        Return "astructw " & My.Application.Info.Version.Major & "." & My.Application.Info.Version.Minor & "." & My.Application.Info.Version.Revision & vbCrLf & My.Application.Info.Description
    End Function

    Function UsageString() As String
        Return "Usage: astructw [/?] [/option ...] source destination" & vbCrLf & _
               "Source and destination must be valid and existing folders" & vbCrLf & _
               "Options: /v     Verbose mode, detailed output" & vbCrLf & _
               "         /h     Copy junctions contents (follow hard links)" & vbCrLf & _
               "         /t     Disable time difference check betzeen source and destination" & vbCrLf & _
               "         /x dir Exclude dir from copy (ie: /x ""Temporary Internet Files"")" & vbCrLf & _
               "         /_     Do not copy files and folders beginning with _ (same as /x _*)"
    End Function

    Function ExtendedHelpString() As String
        Return "Copyright " & My.Application.Info.Copyright
    End Function
End Module
