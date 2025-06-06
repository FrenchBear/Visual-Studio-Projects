<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ImageEditor
    Inherits GenericEditor

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ImageEditor))
        Me.tsbRotate90Right = New System.Windows.Forms.ToolStripButton
        Me.paPicPanel = New System.Windows.Forms.Panel
        Me.sbStatus = New System.Windows.Forms.StatusBar
        Me.sbpFile = New System.Windows.Forms.StatusBarPanel
        Me.sbpResolution = New System.Windows.Forms.StatusBarPanel
        Me.sbpScale = New System.Windows.Forms.StatusBarPanel
        Me.paPicWindow = New System.Windows.Forms.Panel
        Me.pbDisplayedPic = New System.Windows.Forms.PictureBox
        Me.hsScrollBar = New System.Windows.Forms.HScrollBar
        Me.vsScrollBar = New System.Windows.Forms.VScrollBar
        Me.tsbRotate90Left = New System.Windows.Forms.ToolStripButton
        Me.tsbCropSelection = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbRevertToSaved = New System.Windows.Forms.ToolStripButton
        Me.tsbClearSelection = New System.Windows.Forms.ToolStripButton
        Me.tsMain = New System.Windows.Forms.ToolStrip
        Me.tsbSave = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbPrint = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbZoomReduce = New System.Windows.Forms.ToolStripButton
        Me.tscboZoom = New System.Windows.Forms.ToolStripComboBox
        Me.tsbZoomEnlarge = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbHandTool = New System.Windows.Forms.ToolStripButton
        Me.tsbSelectionTool = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbShellOpen = New System.Windows.Forms.ToolStripButton
        Me.paPicPanel.SuspendLayout()
        CType(Me.sbpFile, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sbpResolution, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sbpScale, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.paPicWindow.SuspendLayout()
        CType(Me.pbDisplayedPic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tsMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsbRotate90Right
        '
        Me.tsbRotate90Right.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbRotate90Right.Image = CType(resources.GetObject("tsbRotate90Right.Image"), System.Drawing.Image)
        Me.tsbRotate90Right.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRotate90Right.Name = "tsbRotate90Right"
        Me.tsbRotate90Right.Size = New System.Drawing.Size(23, 22)
        Me.tsbRotate90Right.Text = "ToolStripButton1"
        Me.tsbRotate90Right.ToolTipText = "Rotate image 90° Right (clockwise)"
        '
        'paPicPanel
        '
        Me.paPicPanel.BackColor = System.Drawing.SystemColors.Control
        Me.paPicPanel.Controls.Add(Me.sbStatus)
        Me.paPicPanel.Controls.Add(Me.paPicWindow)
        Me.paPicPanel.Controls.Add(Me.hsScrollBar)
        Me.paPicPanel.Controls.Add(Me.vsScrollBar)
        Me.paPicPanel.Cursor = System.Windows.Forms.Cursors.Default
        Me.paPicPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.paPicPanel.Location = New System.Drawing.Point(0, 25)
        Me.paPicPanel.Name = "paPicPanel"
        Me.paPicPanel.Size = New System.Drawing.Size(656, 577)
        Me.paPicPanel.TabIndex = 4
        '
        'sbStatus
        '
        Me.sbStatus.Location = New System.Drawing.Point(0, 555)
        Me.sbStatus.Name = "sbStatus"
        Me.sbStatus.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.sbpFile, Me.sbpResolution, Me.sbpScale})
        Me.sbStatus.ShowPanels = True
        Me.sbStatus.Size = New System.Drawing.Size(656, 22)
        Me.sbStatus.TabIndex = 4
        '
        'sbpFile
        '
        Me.sbpFile.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.sbpFile.Name = "sbpFile"
        Me.sbpFile.Width = 439
        '
        'sbpResolution
        '
        Me.sbpResolution.Name = "sbpResolution"
        '
        'sbpScale
        '
        Me.sbpScale.Name = "sbpScale"
        '
        'paPicWindow
        '
        Me.paPicWindow.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.paPicWindow.BackColor = System.Drawing.SystemColors.Control
        Me.paPicWindow.Controls.Add(Me.pbDisplayedPic)
        Me.paPicWindow.Cursor = System.Windows.Forms.Cursors.Default
        Me.paPicWindow.Location = New System.Drawing.Point(3, 3)
        Me.paPicWindow.Name = "paPicWindow"
        Me.paPicWindow.Size = New System.Drawing.Size(633, 532)
        Me.paPicWindow.TabIndex = 3
        '
        'pbDisplayedPic
        '
        Me.pbDisplayedPic.BackColor = System.Drawing.SystemColors.Control
        Me.pbDisplayedPic.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.pbDisplayedPic.Location = New System.Drawing.Point(29, 26)
        Me.pbDisplayedPic.Name = "pbDisplayedPic"
        Me.pbDisplayedPic.Size = New System.Drawing.Size(104, 93)
        Me.pbDisplayedPic.TabIndex = 0
        Me.pbDisplayedPic.TabStop = False
        '
        'hsScrollBar
        '
        Me.hsScrollBar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.hsScrollBar.Location = New System.Drawing.Point(0, 538)
        Me.hsScrollBar.Name = "hsScrollBar"
        Me.hsScrollBar.Size = New System.Drawing.Size(639, 17)
        Me.hsScrollBar.TabIndex = 1
        '
        'vsScrollBar
        '
        Me.vsScrollBar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.vsScrollBar.Location = New System.Drawing.Point(639, 0)
        Me.vsScrollBar.Name = "vsScrollBar"
        Me.vsScrollBar.Size = New System.Drawing.Size(17, 539)
        Me.vsScrollBar.TabIndex = 0
        '
        'tsbRotate90Left
        '
        Me.tsbRotate90Left.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbRotate90Left.Image = CType(resources.GetObject("tsbRotate90Left.Image"), System.Drawing.Image)
        Me.tsbRotate90Left.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRotate90Left.Name = "tsbRotate90Left"
        Me.tsbRotate90Left.Size = New System.Drawing.Size(23, 22)
        Me.tsbRotate90Left.Text = "ToolStripButton1"
        Me.tsbRotate90Left.ToolTipText = "Rotate image 90° Left (counterclockwise)"
        '
        'tsbCropSelection
        '
        Me.tsbCropSelection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbCropSelection.Image = CType(resources.GetObject("tsbCropSelection.Image"), System.Drawing.Image)
        Me.tsbCropSelection.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCropSelection.Name = "tsbCropSelection"
        Me.tsbCropSelection.Size = New System.Drawing.Size(23, 22)
        Me.tsbCropSelection.Text = "ToolStripButton1"
        Me.tsbCropSelection.ToolTipText = "Crop image to selected area"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'tsbRevertToSaved
        '
        Me.tsbRevertToSaved.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbRevertToSaved.Image = CType(resources.GetObject("tsbRevertToSaved.Image"), System.Drawing.Image)
        Me.tsbRevertToSaved.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRevertToSaved.Name = "tsbRevertToSaved"
        Me.tsbRevertToSaved.Size = New System.Drawing.Size(23, 22)
        Me.tsbRevertToSaved.Text = "ToolStripButton1"
        Me.tsbRevertToSaved.ToolTipText = "Revert to saved image"
        '
        'tsbClearSelection
        '
        Me.tsbClearSelection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbClearSelection.Image = CType(resources.GetObject("tsbClearSelection.Image"), System.Drawing.Image)
        Me.tsbClearSelection.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbClearSelection.Name = "tsbClearSelection"
        Me.tsbClearSelection.Size = New System.Drawing.Size(23, 22)
        Me.tsbClearSelection.Text = "ToolStripButton1"
        Me.tsbClearSelection.ToolTipText = "ClearSelection"
        '
        'tsMain
        '
        Me.tsMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbSave, Me.tsbRevertToSaved, Me.ToolStripSeparator5, Me.tsbPrint, Me.tsbShellOpen, Me.ToolStripSeparator4, Me.tsbZoomReduce, Me.tscboZoom, Me.tsbZoomEnlarge, Me.ToolStripSeparator1, Me.tsbHandTool, Me.tsbSelectionTool, Me.ToolStripSeparator2, Me.tsbClearSelection, Me.tsbCropSelection, Me.ToolStripSeparator3, Me.tsbRotate90Left, Me.tsbRotate90Right})
        Me.tsMain.Location = New System.Drawing.Point(0, 0)
        Me.tsMain.Name = "tsMain"
        Me.tsMain.Size = New System.Drawing.Size(656, 25)
        Me.tsMain.TabIndex = 3
        Me.tsMain.Text = "ToolStrip1"
        '
        'tsbSave
        '
        Me.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbSave.Image = CType(resources.GetObject("tsbSave.Image"), System.Drawing.Image)
        Me.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSave.Name = "tsbSave"
        Me.tsbSave.Size = New System.Drawing.Size(23, 22)
        Me.tsbSave.Text = "Save"
        Me.tsbSave.ToolTipText = "Save Image"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 25)
        '
        'tsbPrint
        '
        Me.tsbPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbPrint.Image = CType(resources.GetObject("tsbPrint.Image"), System.Drawing.Image)
        Me.tsbPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbPrint.Name = "tsbPrint"
        Me.tsbPrint.Size = New System.Drawing.Size(23, 22)
        Me.tsbPrint.Text = "Print"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 25)
        '
        'tsbZoomReduce
        '
        Me.tsbZoomReduce.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbZoomReduce.Image = CType(resources.GetObject("tsbZoomReduce.Image"), System.Drawing.Image)
        Me.tsbZoomReduce.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbZoomReduce.Name = "tsbZoomReduce"
        Me.tsbZoomReduce.Size = New System.Drawing.Size(23, 22)
        Me.tsbZoomReduce.Text = "ToolStripButton1"
        Me.tsbZoomReduce.ToolTipText = "Zoom Reduce"
        '
        'tscboZoom
        '
        Me.tscboZoom.Items.AddRange(New Object() {"Auto", "200%", "100%", "50%"})
        Me.tscboZoom.Name = "tscboZoom"
        Me.tscboZoom.Size = New System.Drawing.Size(75, 25)
        '
        'tsbZoomEnlarge
        '
        Me.tsbZoomEnlarge.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbZoomEnlarge.Image = CType(resources.GetObject("tsbZoomEnlarge.Image"), System.Drawing.Image)
        Me.tsbZoomEnlarge.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbZoomEnlarge.Name = "tsbZoomEnlarge"
        Me.tsbZoomEnlarge.Size = New System.Drawing.Size(23, 22)
        Me.tsbZoomEnlarge.Text = "ToolStripButton2"
        Me.tsbZoomEnlarge.ToolTipText = "Zoom Enlarge"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'tsbHandTool
        '
        Me.tsbHandTool.CheckOnClick = True
        Me.tsbHandTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbHandTool.Image = CType(resources.GetObject("tsbHandTool.Image"), System.Drawing.Image)
        Me.tsbHandTool.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbHandTool.Name = "tsbHandTool"
        Me.tsbHandTool.Size = New System.Drawing.Size(23, 22)
        Me.tsbHandTool.Text = "ToolStripButton1"
        Me.tsbHandTool.ToolTipText = "Hand Tool"
        '
        'tsbSelectionTool
        '
        Me.tsbSelectionTool.CheckOnClick = True
        Me.tsbSelectionTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbSelectionTool.Image = CType(resources.GetObject("tsbSelectionTool.Image"), System.Drawing.Image)
        Me.tsbSelectionTool.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSelectionTool.Name = "tsbSelectionTool"
        Me.tsbSelectionTool.Size = New System.Drawing.Size(23, 22)
        Me.tsbSelectionTool.Text = "ToolStripButton1"
        Me.tsbSelectionTool.ToolTipText = "Selection Tool"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'tsbShellOpen
        '
        Me.tsbShellOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbShellOpen.Image = CType(resources.GetObject("tsbShellOpen.Image"), System.Drawing.Image)
        Me.tsbShellOpen.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbShellOpen.Name = "tsbShellOpen"
        Me.tsbShellOpen.Size = New System.Drawing.Size(23, 22)
        Me.tsbShellOpen.Text = "ShellOpen"
        Me.tsbShellOpen.ToolTipText = "Open document with default application"
        '
        'ImageEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.paPicPanel)
        Me.Controls.Add(Me.tsMain)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "ImageEditor"
        Me.Size = New System.Drawing.Size(656, 602)
        Me.paPicPanel.ResumeLayout(False)
        CType(Me.sbpFile, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sbpResolution, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sbpScale, System.ComponentModel.ISupportInitialize).EndInit()
        Me.paPicWindow.ResumeLayout(False)
        CType(Me.pbDisplayedPic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tsMain.ResumeLayout(False)
        Me.tsMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsbRotate90Right As System.Windows.Forms.ToolStripButton
    Friend WithEvents paPicPanel As System.Windows.Forms.Panel
    Friend WithEvents sbStatus As System.Windows.Forms.StatusBar
    Friend WithEvents sbpFile As System.Windows.Forms.StatusBarPanel
    Friend WithEvents sbpResolution As System.Windows.Forms.StatusBarPanel
    Friend WithEvents sbpScale As System.Windows.Forms.StatusBarPanel
    Friend WithEvents paPicWindow As System.Windows.Forms.Panel
    Friend WithEvents pbDisplayedPic As System.Windows.Forms.PictureBox
    Friend WithEvents hsScrollBar As System.Windows.Forms.HScrollBar
    Friend WithEvents vsScrollBar As System.Windows.Forms.VScrollBar
    Friend WithEvents tsbRotate90Left As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbCropSelection As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbRevertToSaved As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbClearSelection As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsMain As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbZoomReduce As System.Windows.Forms.ToolStripButton
    Friend WithEvents tscboZoom As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents tsbZoomEnlarge As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbHandTool As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSelectionTool As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbPrint As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbShellOpen As System.Windows.Forms.ToolStripButton

End Class
