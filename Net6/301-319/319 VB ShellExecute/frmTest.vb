' Utilisation de ShellExecute en environnement .Net
'
' 2008-10-10    PV
' 2009-06-03    PV  Added ExpandEnvironmentVariables
' 2012-02-25    PV  VS2010
' 2021-09-20    PV  VS2022; Net6

Imports System.ComponentModel

#Disable Warning IDE1006 ' Naming Styles

Public Class frmTest

    ' These are the Win32 error code for file not found or access denied.
    Private ReadOnly ERROR_FILE_NOT_FOUND As Integer = 2

    Private ReadOnly ERROR_ACCESS_DENIED As Integer = 5

    Private Sub btnShellExecute_Click(sender As System.Object, e As EventArgs) Handles btnShellExecute.Click
        Dim iRet As Integer = ShellExecute(txtCommand.Text)
        MsgBox("Ret: " & iRet)
    End Sub

    Private Function ShellExecute(sCommand As String) As Integer
        ' Find first blank to split command and arguments
        Dim p As Integer = 0
        Dim bInQuote As Boolean = False
        While p < sCommand.Length
            Select Case sCommand.Chars(p)
                Case """"c
                    bInQuote = Not bInQuote
                Case " "c
                    If Not bInQuote Then Exit While
            End Select
            p += 1
        End While

        Dim myProcess As New Process
        myProcess.StartInfo.FileName = Environment.ExpandEnvironmentVariables(sCommand.Substring(0, p))
        myProcess.StartInfo.Arguments = sCommand.Remove(0, p)

        Try
            myProcess.Start()
        Catch ex As Win32Exception
            If ex.NativeErrorCode = ERROR_FILE_NOT_FOUND Then
                WriteLine((ex.Message + ". Check the path."))
            Else
                If ex.NativeErrorCode = ERROR_ACCESS_DENIED Then
                    ' Note that if your word processor might generate exceptions
                    ' such as this, which are handled first.
                    WriteLine((ex.Message + ". You do not have permission to execute this action."))
                End If
            End If

        End Try

        Try
            myProcess.WaitForExit()
            Return myProcess.ExitCode
        Catch ex As Exception

        End Try

        Return 0
    End Function

End Class