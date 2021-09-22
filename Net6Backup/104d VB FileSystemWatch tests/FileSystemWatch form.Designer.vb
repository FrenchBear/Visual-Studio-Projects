<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmFileSystemWatch
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.lvFS = New System.Windows.Forms.ListView
        Me.colEvent = New System.Windows.Forms.ColumnHeader
        Me.colChangeType = New System.Windows.Forms.ColumnHeader
        Me.colFullPath = New System.Windows.Forms.ColumnHeader
        Me.colName = New System.Windows.Forms.ColumnHeader
        Me.colOldFullPath = New System.Windows.Forms.ColumnHeader
        Me.colOldName = New System.Windows.Forms.ColumnHeader
        Me.colWriteStatus = New System.Windows.Forms.ColumnHeader
        Me.FileSystemWatcher1 = New System.IO.FileSystemWatcher
        Me.lvNewFiles = New System.Windows.Forms.ListView
        Me.colFilename = New System.Windows.Forms.ColumnHeader
        Me.colSize = New System.Windows.Forms.ColumnHeader
        Me.colType = New System.Windows.Forms.ColumnHeader
        Me.lstTrace = New System.Windows.Forms.ListBox
        Me.btnPoll = New System.Windows.Forms.Button
        Me.timPollTimer = New System.Windows.Forms.Timer(Me.components)
        CType(Me.FileSystemWatcher1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lvFS
        '
        Me.lvFS.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvFS.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colEvent, Me.colChangeType, Me.colFullPath, Me.colName, Me.colOldFullPath, Me.colOldName, Me.colWriteStatus})
        Me.lvFS.FullRowSelect = True
        Me.lvFS.GridLines = True
        Me.lvFS.HideSelection = False
        Me.lvFS.Location = New System.Drawing.Point(12, 12)
        Me.lvFS.Name = "lvFS"
        Me.lvFS.Size = New System.Drawing.Size(766, 274)
        Me.lvFS.TabIndex = 0
        Me.lvFS.UseCompatibleStateImageBehavior = False
        Me.lvFS.View = System.Windows.Forms.View.Details
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
        Me.lvNewFiles.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.colFilename, Me.colSize, Me.colType})
        Me.lvNewFiles.FullRowSelect = True
        Me.lvNewFiles.GridLines = True
        Me.lvNewFiles.HideSelection = False
        Me.lvNewFiles.Location = New System.Drawing.Point(12, 292)
        Me.lvNewFiles.Name = "lvNewFiles"
        Me.lvNewFiles.Size = New System.Drawing.Size(494, 291)
        Me.lvNewFiles.TabIndex = 1
        Me.lvNewFiles.UseCompatibleStateImageBehavior = False
        Me.lvNewFiles.View = System.Windows.Forms.View.Details
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
        Me.lstTrace.Location = New System.Drawing.Point(513, 293)
        Me.lstTrace.Name = "lstTrace"
        Me.lstTrace.Size = New System.Drawing.Size(265, 264)
        Me.lstTrace.TabIndex = 2
        '
        'btnPoll
        '
        Me.btnPoll.Location = New System.Drawing.Point(512, 560)
        Me.btnPoll.Name = "btnPoll"
        Me.btnPoll.Size = New System.Drawing.Size(75, 23)
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
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(790, 591)
        Me.Controls.Add(Me.btnPoll)
        Me.Controls.Add(Me.lstTrace)
        Me.Controls.Add(Me.lvNewFiles)
        Me.Controls.Add(Me.lvFS)
        Me.Name = "frmFileSystemWatch"
        Me.Text = "FileSystemWatch tests"
        CType(Me.FileSystemWatcher1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lvFS As System.Windows.Forms.ListView
    Friend WithEvents FileSystemWatcher1 As System.IO.FileSystemWatcher
    Friend WithEvents colEvent As System.Windows.Forms.ColumnHeader
    Friend WithEvents colChangeType As System.Windows.Forms.ColumnHeader
    Friend WithEvents colFullPath As System.Windows.Forms.ColumnHeader
    Friend WithEvents colName As System.Windows.Forms.ColumnHeader
    Friend WithEvents colOldFullPath As System.Windows.Forms.ColumnHeader
    Friend WithEvents colOldName As System.Windows.Forms.ColumnHeader
    Friend WithEvents colWriteStatus As System.Windows.Forms.ColumnHeader
    Friend WithEvents lstTrace As System.Windows.Forms.ListBox
    Friend WithEvents lvNewFiles As System.Windows.Forms.ListView
    Friend WithEvents colFilename As System.Windows.Forms.ColumnHeader
    Friend WithEvents colSize As System.Windows.Forms.ColumnHeader
    Friend WithEvents colType As System.Windows.Forms.ColumnHeader
    Friend WithEvents btnPoll As System.Windows.Forms.Button
    Friend WithEvents timPollTimer As System.Windows.Forms.Timer

End Class
