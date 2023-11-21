' Impression via ShellExecute en environnement .Net
'
' 2006-04-13    FPVI
' 2021-09-19 	PV		VS2022; Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8

Imports System.ComponentModel

Public Class TestPrintForm

    ' These are the Win32 error code for file not found or access denied.
    Private ReadOnly ERROR_FILE_NOT_FOUND As Integer = 2

    Private ReadOnly ERROR_ACCESS_DENIED As Integer = 5

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim myProcess As New Process()

        Try
            myProcess.StartInfo.FileName = "C:\Users\Pierre\GoogleDrive\Calculators\TI\TI-Nspire\nextprime.txt"
            myProcess.StartInfo.Verb = "Print"
            myProcess.StartInfo.CreateNoWindow = True
            myProcess.Start()
        Catch ex As Win32Exception
            If ex.NativeErrorCode = ERROR_FILE_NOT_FOUND Then
                WriteLine((ex.Message + ". Check the path."))
            Else
                If ex.NativeErrorCode = ERROR_ACCESS_DENIED Then
                    ' Note that if your word processor might generate exceptions
                    ' such as this, which are handled first.
                    WriteLine((ex.Message + ". You do not have permission to print this file."))
                End If
            End If
        End Try

    End Sub

End Class
