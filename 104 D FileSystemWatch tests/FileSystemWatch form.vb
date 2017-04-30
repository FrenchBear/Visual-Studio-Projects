' 2012-02-25	PV  VS2010

Option Compare Text
Imports System.IO


Public Class frmFileSystemWatch

    Private Sub FileSystemWatcher1_Changed(ByVal sender As System.Object, ByVal e As System.IO.FileSystemEventArgs) Handles FileSystemWatcher1.Changed
        Trace("Changed", e.ChangeType, e.FullPath, e.Name)

    End Sub

    Private Sub FileSystemWatcher1_Created(ByVal sender As Object, ByVal e As System.IO.FileSystemEventArgs) Handles FileSystemWatcher1.Created
        Trace("Created", e.ChangeType, e.FullPath, e.Name)
    End Sub

    Private Sub FileSystemWatcher1_Deleted(ByVal sender As Object, ByVal e As System.IO.FileSystemEventArgs) Handles FileSystemWatcher1.Deleted
        Trace("Deleted", e.ChangeType, e.FullPath, e.Name)
    End Sub

    Private Sub FileSystemWatcher1_Renamed(ByVal sender As Object, ByVal e As System.IO.RenamedEventArgs) Handles FileSystemWatcher1.Renamed
        Trace("Renamed", e.ChangeType, e.FullPath, e.Name, e.OldFullPath, e.OldName)
    End Sub

    Sub Trace(ByVal sEvent As String, ByVal sChangeType As String, ByVal sFullPath As String, ByVal sName As String, Optional ByVal sOldFullPath As String = "", Optional ByVal sOldName As String = "")
        Dim lvi As ListViewItem
        lvi = lvFS.Items.Add(sEvent)
        lvi.SubItems.Add(sChangeType)
        lvi.SubItems.Add(sFullPath)
        lvi.SubItems.Add(sName)
        lvi.SubItems.Add(sOldFullPath)
        lvi.SubItems.Add(sOldName)

        'If sEvent = "Created" Or sEvent = "Changed" Then
        '    Dim fi As System.IO.FileInfo = Nothing
        '    Dim fs As System.IO.FileStream = Nothing
        '    Try
        '        fi = New System.IO.FileInfo(sFullPath)
        '        fs = fi.OpenWrite
        '        lvi.SubItems.Add("Write Ok")
        '    Catch ex As Exception
        '        lvi.SubItems.Add("Can't write")
        '    Finally
        '        If Not fs Is Nothing Then fs.Close()
        '        fi = Nothing
        '    End Try
        'End If

        ' Set PollTimer at 1s
        timPollTimer.Enabled = False
        timPollTimer.Enabled = True
        ListTrace("timPollTimer set on " & Now.ToString)
    End Sub

    Private Sub frmFileSystemWatch_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        PollWatchedFolders()
    End Sub


    Sub PollWatchedFolders()
        ListTrace("Poll on " & Now.ToString)

        Dim colFiles As Collection
        colFiles = New Collection

        ' Collect filesystem information
        Dim di As New DirectoryInfo("C:\Temp")
        Dim fiFile As FileInfo
        For Each fiFile In di.GetFiles
            colFiles.Add(fiFile, LCase(fiFile.FullName))
        Next

        ' Add new files to the list
        Dim flvi As FileListViewItem
        For Each fiFile In colFiles
            If Not lvNewFiles.Items.ContainsKey(LCase(fiFile.FullName)) Then
                ListTrace("Add " & fiFile.FullName)
                flvi = New FileListViewItem
                flvi.sFullName = fiFile.FullName
                flvi.Name = LCase(fiFile.FullName)
                flvi.Text = fiFile.Name
                flvi.SubItems.Add(fiFile.Length.ToString)
                flvi.SubItems.Add(fiFile.Extension)

                lvNewFiles.Items.Add(flvi)
            End If
        Next

        ' Remove deleted files
        For Each flvi In lvNewFiles.Items
            If Not colFiles.Contains(LCase(flvi.sFullName)) Then
                ListTrace("Remove " & flvi.sFullName)
                lvNewFiles.Items.Remove(flvi)
            End If
        Next
    End Sub

    Sub ListTrace(ByVal sMsg As String)
        lstTrace.Items.Add(sMsg)
        lstTrace.SelectedIndex = lstTrace.Items.Count - 1
    End Sub

    Private Sub btnPoll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPoll.Click
        PollWatchedFolders()
    End Sub

    Private Sub timPollTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timPollTimer.Tick
        timPollTimer.Enabled = False
        PollWatchedFolders()
    End Sub
End Class


Class FileListViewItem
    Inherits ListViewItem

    Public sFullName As String
End Class