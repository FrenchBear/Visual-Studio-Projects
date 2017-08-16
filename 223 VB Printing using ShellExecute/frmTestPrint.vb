' Impression via ShellExecute en environnement .Net
' 2006-04-13 FPVI

Imports System
Imports System.Diagnostics
Imports System.ComponentModel


Public Class frmTestPrint
    ' These are the Win32 error code for file not found or access denied.
    Private ERROR_FILE_NOT_FOUND As Integer = 2
    Private ERROR_ACCESS_DENIED As Integer = 5

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim myProcess As New Process()

        Try
            myProcess.StartInfo.FileName = "C:\Users\Pierre\GoogleDrive\Calculators\TI\TI-Nspire\nextprime.txt"
            myProcess.StartInfo.Verb = "Print"
            myProcess.StartInfo.CreateNoWindow = True
            myProcess.Start()

        Catch ex As Win32Exception
            If ex.NativeErrorCode = ERROR_FILE_NOT_FOUND Then
                Console.WriteLine((ex.Message + ". Check the path."))

            Else
                If ex.NativeErrorCode = ERROR_ACCESS_DENIED Then
                    ' Note that if your word processor might generate exceptions
                    ' such as this, which are handled first.
                    Console.WriteLine((ex.Message + ". You do not have permission to print this file."))
                End If
            End If
        End Try

    End Sub

End Class
