' AutoCleaner
' Simple application that removes permanently older files from a directory given as an argument
' until 25% of disk is free.  For my home webcam videomonitoring
' 2006-08-04    PV
' 2012-02-25	PV  VS2010

Module modMain
    Dim sDir As String

    Class FileAndDate
        Public sFileName As String
        Public LastWriteTime As Date
    End Class

    Sub Main()
        If My.Application.CommandLineArgs.Count <> 1 Then
            UsageExit()
        End If
        sDir = My.Application.CommandLineArgs(0)
        If Not My.Computer.FileSystem.DirectoryExists(sDir) Then
            Console.WriteLine("AutoCleaner: Can't find directory """ & sDir & """")
            End
        End If

        'Console.WriteLine("$1")
        sDir = System.IO.Path.GetFullPath(sDir)
        'Console.WriteLine("$2: {0}", sDir)

        Dim llList As LinkedList(Of FileAndDate)
        Dim fad As FileAndDate

        ' Create a list of files sorted by date
        llList = New LinkedList(Of FileAndDate)
        'Console.WriteLine("$3")
        For Each sFileName As String In My.Computer.FileSystem.GetFiles(sDir)
            'Console.WriteLine("$4: {0}", sFileName)
            fad = New FileAndDate
            fad.sFileName = sFileName
            fad.LastWriteTime = My.Computer.FileSystem.GetFileInfo(sFileName).LastWriteTime

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
        Dim di As System.IO.DriveInfo
        'Console.WriteLine("$5")
        For Each fad In llList
            di = My.Computer.FileSystem.GetDriveInfo(Left(sDir, 2))
            'Console.WriteLine("$6: {0:G}", di.AvailableFreeSpace / di.TotalSize)
            If di.AvailableFreeSpace / di.TotalSize > 0.25 Then Exit For

            Console.WriteLine("del {0}", fad.sFileName)
            Try
                Kill(fad.sFileName)
            Catch ex As Exception
                Console.WriteLine("*** Failed to delete """ & fad.sFileName & """: " & ex.Message)
            End Try
        Next
        'Console.WriteLine("$8")
    End Sub

    Sub UsageExit()
        Console.WriteLine("Usage: AutoCleaner folder" & vbCrLf &
                          "Cleans folder content")
        End
    End Sub

End Module
