Imports System.ComponentModel
Imports System.IO
Imports Microsoft.VisualBasic.CompilerServices

<DesignerGenerated()>
Partial Class frmFileSystemWatch
    Inherits Form

    'Form overrides dispose to clean up the component list.
    <DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New Container
        Me.lvFS = New ListView
        Me.colEvent = New ColumnHeader
        Me.colChangeType = New ColumnHeader
        Me.colFullPath = New ColumnHeader
        Me.colName = New ColumnHeader
        Me.colOldFullPath = New ColumnHeader
        Me.colOldName = New ColumnHeader
        Me.colWriteStatus = New ColumnHeader
        Me.FileSystemWatcher1 = New FileSystemWatcher
        Me.lvNewFiles = New ListView
        Me.colFilename = New ColumnHeader
        Me.colSize = New ColumnHeader
        Me.colType = New ColumnHeader
        Me.lstTrace = New ListBox
        Me.btnPoll = New Button
        Me.timPollTimer = New Timer(Me.components)
        CType(Me.FileSystemWatcher1, ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lvFS
        '
        Me.lvFS.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Left) _
                    Or AnchorStyles.Right), AnchorStyles)
        Me.lvFS.Columns.AddRange(New ColumnHeader() {Me.colEvent, Me.colChangeType, Me.colFullPath, Me.colName, Me.colOldFullPath, Me.colOldName, Me.colWriteStatus})
        Me.lvFS.FullRowSelect = True
        Me.lvFS.GridLines = True
        Me.lvFS.HideSelection = False
        Me.lvFS.Location = New Point(12, 12)
        Me.lvFS.Name = "lvFS"
        Me.lvFS.Size = New Size(766, 274)
        Me.lvFS.TabIndex = 0
        Me.lvFS.UseCompatibleStateImageBehavior = False
        Me.lvFS.View = View.Details
        '
        'colEvent
        '
        Me.colEvent.Text = "Event"
        '
        'colChangeType
        '
        Me.colChangeType.Text = "ChangeType"
        Me.colChangeType.Width = 82
        '
        'colFullPath
        '
        Me.colFullPath.Text = "FullPath"
        Me.colFullPath.Width = 130
        '
        'colName
        '
        Me.colName.Text = "Name"
        Me.colName.Width = 95
        '
        'colOldFullPath
        '
        Me.colOldFullPath.Text = "OldFullPath"
        Me.colOldFullPath.Width = 139
        '
        'colOldName
        '
        Me.colOldName.Text = "OldName"
        Me.colOldName.Width = 98
        '
        'colWriteStatus
        '
        Me.colWriteStatus.Text = "WriteStatus"
        Me.colWriteStatus.Width = 90
        '
        'FileSystemWatcher1
        '
        Me.FileSystemWatcher1.EnableRaisingEvents = True
        Me.FileSystemWatcher1.Path = "c:\Temp"
        Me.FileSystemWatcher1.SynchronizingObject = Me
        '
        'lvNewFiles
        '
        Me.lvNewFiles.Columns.AddRange(New ColumnHeader() {Me.colFilename, Me.colSize, Me.colType})
        Me.lvNewFiles.FullRowSelect = True
        Me.lvNewFiles.GridLines = True
        Me.lvNewFiles.HideSelection = False
        Me.lvNewFiles.Location = New Point(12, 292)
        Me.lvNewFiles.Name = "lvNewFiles"
        Me.lvNewFiles.Size = New Size(494, 291)
        Me.lvNewFiles.TabIndex = 1
        Me.lvNewFiles.UseCompatibleStateImageBehavior = False
        Me.lvNewFiles.View = View.Details
        '
        'colFilename
        '
        Me.colFilename.Text = "Filename"
        Me.colFilename.Width = 156
        '
        'colSize
        '
        Me.colSize.Text = "Size"
        Me.colSize.Width = 87
        '
        'colType
        '
        Me.colType.Text = "Type"
        Me.colType.Width = 173
        '
        'lstTrace
        '
        Me.lstTrace.FormattingEnabled = True
        Me.lstTrace.Location = New Point(513, 293)
        Me.lstTrace.Name = "lstTrace"
        Me.lstTrace.Size = New Size(265, 264)
        Me.lstTrace.TabIndex = 2
        '
        'btnPoll
        '
        Me.btnPoll.Location = New Point(512, 560)
        Me.btnPoll.Name = "btnPoll"
        Me.btnPoll.Size = New Size(75, 23)
        Me.btnPoll.TabIndex = 3
        Me.btnPoll.Text = "Poll"
        Me.btnPoll.UseVisualStyleBackColor = True
        '
        'timPollTimer
        '
        Me.timPollTimer.Interval = 5000
        '
        'frmFileSystemWatch
        '
        Me.AutoScaleDimensions = New SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.ClientSize = New Size(790, 591)
        Me.Controls.Add(Me.btnPoll)
        Me.Controls.Add(Me.lstTrace)
        Me.Controls.Add(Me.lvNewFiles)
        Me.Controls.Add(Me.lvFS)
        Me.Name = "frmFileSystemWatch"
        Me.Text = "FileSystemWatch tests"
        CType(Me.FileSystemWatcher1, ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lvFS As ListView
    Friend WithEvents FileSystemWatcher1 As FileSystemWatcher
    Friend WithEvents colEvent As ColumnHeader
    Friend WithEvents colChangeType As ColumnHeader
    Friend WithEvents colFullPath As ColumnHeader
    Friend WithEvents colName As ColumnHeader
    Friend WithEvents colOldFullPath As ColumnHeader
    Friend WithEvents colOldName As ColumnHeader
    Friend WithEvents colWriteStatus As ColumnHeader
    Friend WithEvents lstTrace As ListBox
    Friend WithEvents lvNewFiles As ListView
    Friend WithEvents colFilename As ColumnHeader
    Friend WithEvents colSize As ColumnHeader
    Friend WithEvents colType As ColumnHeader
    Friend WithEvents btnPoll As Button
    Friend WithEvents timPollTimer As Timer

End Class
