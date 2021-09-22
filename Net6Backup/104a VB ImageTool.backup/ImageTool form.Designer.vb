<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmImageTool
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImageTool))
        Me.tsMain = New System.Windows.Forms.ToolStrip()
        Me.tsbSave = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbZoomReduce = New System.Windows.Forms.ToolStripButton()
        Me.tscboZoom = New System.Windows.Forms.ToolStripComboBox()
        Me.tsbZoomEnlarge = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbHandTool = New System.Windows.Forms.ToolStripButton()
        Me.tsbSelectionTool = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbClearSelection = New System.Windows.Forms.ToolStripButton()
        Me.tsbCropSelection = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsbRotate90Left = New System.Windows.Forms.ToolStripButton()
        Me.tsbRotate90Right = New System.Windows.Forms.ToolStripButton()
        Me.paPicPanel = New System.Windows.Forms.Panel()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.sbpFile = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sbpResolution = New System.Windows.Forms.ToolStripStatusLabel()
        Me.sbpScale = New System.Windows.Forms.ToolStripStatusLabel()
        Me.paPicWindow = New System.Windows.Forms.Panel()
        Me.pbDisplayedPic = New System.Windows.Forms.PictureBox()
        Me.hsScrollBar = New System.Windows.Forms.HScrollBar()
        Me.vsScrollBar = New System.Windows.Forms.VScrollBar()
        Me.tsMain.SuspendLayout()
        Me.paPicPanel.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.paPicWindow.SuspendLayout()
        CType(Me.pbDisplayedPic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsMain
        '
        Me.tsMain.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.tsMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbSave, Me.ToolStripSeparator4, Me.tsbZoomReduce, Me.tscboZoom, Me.tsbZoomEnlarge, Me.ToolStripSeparator1, Me.tsbHandTool, Me.tsbSelectionTool, Me.ToolStripSeparator2, Me.tsbClearSelection, Me.tsbCropSelection, Me.ToolStripSeparator3, Me.tsbRotate90Left, Me.tsbRotate90Right})
        Me.tsMain.Location = New System.Drawing.Point(0, 0)
        Me.tsMain.Name = "tsMain"
        Me.tsMain.Padding = New System.Windows.Forms.Padding(0, 0, 4, 0)
        Me.tsMain.Size = New System.Drawing.Size(1200, 50)
        Me.tsMain.TabIndex = 0
        Me.tsMain.Text = "ToolStrip1"
        '
        'tsbSave
        '
        Me.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbSave.Image = CType(resources.GetObject("tsbSave.Image"), System.Drawing.Image)
        Me.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbSave.Name = "tsbSave"
        Me.tsbSave.Size = New System.Drawing.Size(46, 44)
        Me.tsbSave.Text = "Save"
        Me.tsbSave.ToolTipText = "Save Image"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 50)
        '
        'tsbZoomReduce
        '
        Me.tsbZoomReduce.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbZoomReduce.Image = CType(resources.GetObject("tsbZoomReduce.Image"), System.Drawing.Image)
        Me.tsbZoomReduce.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbZoomReduce.Name = "tsbZoomReduce"
        Me.tsbZoomReduce.Size = New System.Drawing.Size(46, 44)
        Me.tsbZoomReduce.Text = "ToolStripButton1"
        Me.tsbZoomReduce.ToolTipText = "Zoom Reduce"
        '
        'tscboZoom
        '
        Me.tscboZoom.Items.AddRange(New Object() {"Auto", "200%", "100%", "50%"})
        Me.tscboZoom.Name = "tscboZoom"
        Me.tscboZoom.Size = New System.Drawing.Size(146, 50)
        '
        'tsbZoomEnlarge
        '
        Me.tsbZoomEnlarge.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbZoomEnlarge.Image = CType(resources.GetObject("tsbZoomEnlarge.Image"), System.Drawing.Image)
        Me.tsbZoomEnlarge.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbZoomEnlarge.Name = "tsbZoomEnlarge"
        Me.tsbZoomEnlarge.Size = New System.Drawing.Size(46, 44)
        Me.tsbZoomEnlarge.Text = "ToolStripButton2"
        Me.tsbZoomEnlarge.ToolTipText = "Zoom Enlarge"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 50)
        '
        'tsbHandTool
        '
        Me.tsbHandTool.CheckOnClick = True
        Me.tsbHandTool.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbHandTool.Image = CType(resources.GetObject("tsbHandTool.Image"), System.Drawing.Image)
        Me.tsbHandTool.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbHandTool.Name = "tsbHandTool"
        Me.tsbHandTool.Size = New System.Drawing.Size(46, 44)
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
        Me.tsbSelectionTool.Size = New System.Drawing.Size(46, 44)
        Me.tsbSelectionTool.Text = "ToolStripButton1"
        Me.tsbSelectionTool.ToolTipText = "Selection Tool"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 50)
        '
        'tsbClearSelection
        '
        Me.tsbClearSelection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbClearSelection.Image = CType(resources.GetObject("tsbClearSelection.Image"), System.Drawing.Image)
        Me.tsbClearSelection.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbClearSelection.Name = "tsbClearSelection"
        Me.tsbClearSelection.Size = New System.Drawing.Size(46, 44)
        Me.tsbClearSelection.Text = "ToolStripButton1"
        Me.tsbClearSelection.ToolTipText = "ClearSelection"
        '
        'tsbCropSelection
        '
        Me.tsbCropSelection.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbCropSelection.Image = CType(resources.GetObject("tsbCropSelection.Image"), System.Drawing.Image)
        Me.tsbCropSelection.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCropSelection.Name = "tsbCropSelection"
        Me.tsbCropSelection.Size = New System.Drawing.Size(46, 44)
        Me.tsbCropSelection.Text = "ToolStripButton1"
        Me.tsbCropSelection.ToolTipText = "Crop image to selected area"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 50)
        '
        'tsbRotate90Left
        '
        Me.tsbRotate90Left.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbRotate90Left.Image = CType(resources.GetObject("tsbRotate90Left.Image"), System.Drawing.Image)
        Me.tsbRotate90Left.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRotate90Left.Name = "tsbRotate90Left"
        Me.tsbRotate90Left.Size = New System.Drawing.Size(46, 44)
        Me.tsbRotate90Left.Text = "ToolStripButton1"
        Me.tsbRotate90Left.ToolTipText = "Rotate image 90° Left (counterclockwise)"
        '
        'tsbRotate90Right
        '
        Me.tsbRotate90Right.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbRotate90Right.Image = CType(resources.GetObject("tsbRotate90Right.Image"), System.Drawing.Image)
        Me.tsbRotate90Right.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRotate90Right.Name = "tsbRotate90Right"
        Me.tsbRotate90Right.Size = New System.Drawing.Size(46, 44)
        Me.tsbRotate90Right.Text = "ToolStripButton1"
        Me.tsbRotate90Right.ToolTipText = "Rotate image 90° Right (clockwise)"
        '
        'paPicPanel
        '
        Me.paPicPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.paPicPanel.Controls.Add(Me.paPicWindow)
        Me.paPicPanel.Controls.Add(Me.hsScrollBar)
        Me.paPicPanel.Controls.Add(Me.vsScrollBar)
        Me.paPicPanel.Cursor = System.Windows.Forms.Cursors.No
        Me.paPicPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.paPicPanel.Location = New System.Drawing.Point(0, 50)
        Me.paPicPanel.Margin = New System.Windows.Forms.Padding(6)
        Me.paPicPanel.Name = "paPicPanel"
        Me.paPicPanel.Size = New System.Drawing.Size(1200, 929)
        Me.paPicPanel.TabIndex = 2
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sbpFile, Me.sbpResolution, Me.sbpScale})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 937)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1200, 42)
        Me.StatusStrip1.TabIndex = 4
        '
        'sbpFile
        '
        Me.sbpFile.Name = "sbpFile"
        Me.sbpFile.Size = New System.Drawing.Size(923, 32)
        Me.sbpFile.Spring = True
        Me.sbpFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'sbpResolution
        '
        Me.sbpResolution.AutoSize = False
        Me.sbpResolution.Name = "sbpResolution"
        Me.sbpResolution.Size = New System.Drawing.Size(250, 32)
        '
        'sbpScale
        '
        Me.sbpScale.AutoSize = False
        Me.sbpScale.Name = "sbpScale"
        Me.sbpScale.Size = New System.Drawing.Size(100, 32)
        '
        'paPicWindow
        '
        Me.paPicWindow.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.paPicWindow.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.paPicWindow.Controls.Add(Me.pbDisplayedPic)
        Me.paPicWindow.Cursor = System.Windows.Forms.Cursors.No
        Me.paPicWindow.Location = New System.Drawing.Point(6, 6)
        Me.paPicWindow.Margin = New System.Windows.Forms.Padding(6)
        Me.paPicWindow.Name = "paPicWindow"
        Me.paPicWindow.Size = New System.Drawing.Size(1154, 842)
        Me.paPicWindow.TabIndex = 3
        '
        'pbDisplayedPic
        '
        Me.pbDisplayedPic.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.pbDisplayedPic.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.pbDisplayedPic.Location = New System.Drawing.Point(52, 69)
        Me.pbDisplayedPic.Margin = New System.Windows.Forms.Padding(6)
        Me.pbDisplayedPic.Name = "pbDisplayedPic"
        Me.pbDisplayedPic.Size = New System.Drawing.Size(200, 96)
        Me.pbDisplayedPic.TabIndex = 0
        Me.pbDisplayedPic.TabStop = False
        '
        'hsScrollBar
        '
        Me.hsScrollBar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.hsScrollBar.Location = New System.Drawing.Point(0, 854)
        Me.hsScrollBar.Name = "hsScrollBar"
        Me.hsScrollBar.Size = New System.Drawing.Size(1166, 17)
        Me.hsScrollBar.TabIndex = 1
        '
        'vsScrollBar
        '
        Me.vsScrollBar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.vsScrollBar.Location = New System.Drawing.Point(1166, 0)
        Me.vsScrollBar.Name = "vsScrollBar"
        Me.vsScrollBar.Size = New System.Drawing.Size(17, 856)
        Me.vsScrollBar.TabIndex = 0
        '
        'frmImageTool
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1200, 979)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.paPicPanel)
        Me.Controls.Add(Me.tsMain)
        Me.Margin = New System.Windows.Forms.Padding(6)
        Me.Name = "frmImageTool"
        Me.Text = "Image Tool"
        Me.tsMain.ResumeLayout(False)
        Me.tsMain.PerformLayout()
        Me.paPicPanel.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.paPicWindow.ResumeLayout(False)
        CType(Me.pbDisplayedPic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsMain As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbZoomReduce As System.Windows.Forms.ToolStripButton
    Friend WithEvents paPicPanel As System.Windows.Forms.Panel
    Friend WithEvents hsScrollBar As System.Windows.Forms.HScrollBar
    Friend WithEvents vsScrollBar As System.Windows.Forms.VScrollBar
    Friend WithEvents paPicWindow As System.Windows.Forms.Panel
    Friend WithEvents pbDisplayedPic As System.Windows.Forms.PictureBox
    Friend WithEvents tscboZoom As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents tsbZoomEnlarge As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbHandTool As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSelectionTool As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbClearSelection As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbCropSelection As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbRotate90Left As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbRotate90Right As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents sbpFile As ToolStripStatusLabel
    Friend WithEvents sbpResolution As ToolStripStatusLabel
    Friend WithEvents sbpScale As ToolStripStatusLabel
End Class
