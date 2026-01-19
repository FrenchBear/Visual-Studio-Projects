' AutoCleaner
' Simple application that removes permanently older files from a directory given as an argument
' until 25% of disk is free.  For my home webcam videomonitoring
'
' 2006-08-04    PV
' 2012-02-25	PV		VS2010
' 2021-09-20 	PV		VS2022; Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9
' 2026-01-19	PV		Net10
Imports System.IO

Friend Module modMain
    Private sDir As String

    Public Class FileAndDate
        Public sFileName As String
        Public LastWriteTime As Date
    End Class

    Public Sub Main()
        If My.Application.CommandLineArgs.Count <> 1 Then
            UsageExit()
        End If
        sDir = My.Application.CommandLineArgs(0)
        If Not My.Computer.FileSystem.DirectoryExists(sDir) Then
            WriteLine("AutoCleaner: Can't find directory """ & sDir & """")
            End
        End If

        'WriteLine("$1")
        sDir = Path.GetFullPath(sDir)
        'WriteLine("$2: {0}", sDir)

        Dim llList As LinkedList(Of FileAndDate)
        Dim fad As FileAndDate

        ' Create a list of files sorted by date
        llList = New LinkedList(Of FileAndDate)
        'WriteLine("$3")
        For Each sFileName As String In My.Computer.FileSystem.GetFiles(sDir)
            'WriteLine("$4: {0}", sFileName)
            fad = New FileAndDate With {
                .sFileName = sFileName,
                .LastWriteTime = My.Computer.FileSystem.GetFileInfo(sFileName).LastWriteTime
            }

            Dim lle As LinkedListNode(Of FileAndDate)
            lle = llList.First
            Do Until lle Is Nothing
                If lle.Value.LastWriteTime >= fad.LastWriteTime Then
                    llList.AddBefore(lle, fad)
                    Exit Do
                End If
                lle = lle.Next
            Loop
            If lle Is Nothing Then llList.AddLast(fad)
        Next

        ' Delete files starting with the older until 25% of the disk is available
        Dim di As DriveInfo
        'WriteLine("$5")
        For Each fad In llList
            di = My.Computer.FileSystem.GetDriveInfo(Left(sDir, 2))
            'WriteLine("$6: {0:G}", di.AvailableFreeSpace / di.TotalSize)
            If di.AvailableFreeSpace / di.TotalSize > 0.25 Then Exit For

            WriteLine("del {0}", fad.sFileName)
            Try
                Kill(fad.sFileName)
            Catch ex As Exception
                WriteLine("*** Failed to delete """ & fad.sFileName & """: " & ex.Message)
            End Try
        Next
        'WriteLine("$8")
    End Sub

    Public Sub UsageExit()
        WriteLine("Usage: AutoCleaner folder" & vbCrLf &
                          "Cleans folder content")
        End
    End Sub

End Module
