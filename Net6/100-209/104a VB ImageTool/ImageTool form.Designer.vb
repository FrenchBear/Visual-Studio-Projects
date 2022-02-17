Imports System.ComponentModel
Imports Microsoft.VisualBasic.CompilerServices

<DesignerGenerated()>
Partial Class frmImageTool
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
        Dim resources As ComponentResourceManager = New ComponentResourceManager(GetType(frmImageTool))
        Me.tsMain = New ToolStrip()
        Me.tsbSave = New ToolStripButton()
        Me.ToolStripSeparator4 = New ToolStripSeparator()
        Me.tsbZoomReduce = New ToolStripButton()
        Me.tscboZoom = New ToolStripComboBox()
        Me.tsbZoomEnlarge = New ToolStripButton()
        Me.ToolStripSeparator1 = New ToolStripSeparator()
        Me.tsbHandTool = New ToolStripButton()
        Me.tsbSelectionTool = New ToolStripButton()
        Me.ToolStripSeparator2 = New ToolStripSeparator()
        Me.tsbClearSelection = New ToolStripButton()
        Me.tsbCropSelection = New ToolStripButton()
        Me.ToolStripSeparator3 = New ToolStripSeparator()
        Me.tsbRotate90Left = New ToolStripButton()
        Me.tsbRotate90Right = New ToolStripButton()
        Me.paPicPanel = New Panel()
        Me.StatusStrip1 = New StatusStrip()
        Me.sbpFile = New ToolStripStatusLabel()
        Me.sbpResolution = New ToolStripStatusLabel()
        Me.sbpScale = New ToolStripStatusLabel()
        Me.paPicWindow = New Panel()
        Me.pbDisplayedPic = New PictureBox()
        Me.hsScrollBar = New HScrollBar()
        Me.vsScrollBar = New VScrollBar()
        Me.tsMain.SuspendLayout()
        Me.paPicPanel.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.paPicWindow.SuspendLayout()
        CType(Me.pbDisplayedPic, ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsMain
        '
        Me.tsMain.ImageScalingSize = New Size(32, 32)
        Me.tsMain.Items.AddRange(New ToolStripItem() {Me.tsbSave, Me.ToolStripSeparator4, Me.tsbZoomReduce, Me.tscboZoom, Me.tsbZoomEnlarge, Me.ToolStripSeparator1, Me.tsbHandTool, Me.tsbSelectionTool, Me.ToolStripSeparator2, Me.tsbClearSelection, Me.tsbCropSelection, Me.ToolStripSeparator3, Me.tsbRotate90Left, Me.tsbRotate90Right})
        Me.tsMain.Location = New Point(0, 0)
        Me.tsMain.Name = "tsMain"
        Me.tsMain.Padding = New Padding(0, 0, 4, 0)
        Me.tsMain.Size = New Size(1200, 50)
        Me.tsMain.TabIndex = 0
        Me.tsMain.Text = "ToolStrip1"
        '
        'tsbSave
        '
        Me.tsbSave.DisplayStyle = ToolStripItemDisplayStyle.Image
        Me.tsbSave.Image = CType(resources.GetObject("tsbSave.Image"), Image)
        Me.tsbSave.ImageTransparentColor = Color.Magenta
        Me.tsbSave.Name = "tsbSave"
        Me.tsbSave.Size = New Size(46, 44)
        Me.tsbSave.Text = "Save"
        Me.tsbSave.ToolTipText = "Save Image"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New Size(6, 50)
        '
        'tsbZoomReduce
        '
        Me.tsbZoomReduce.DisplayStyle = ToolStripItemDisplayStyle.Image
        Me.tsbZoomReduce.Image = CType(resources.GetObject("tsbZoomReduce.Image"), Image)
        Me.tsbZoomReduce.ImageTransparentColor = Color.Magenta
        Me.tsbZoomReduce.Name = "tsbZoomReduce"
        Me.tsbZoomReduce.Size = New Size(46, 44)
        Me.tsbZoomReduce.Text = "ToolStripButton1"
        Me.tsbZoomReduce.ToolTipText = "Zoom Reduce"
        '
        'tscboZoom
        '
        Me.tscboZoom.Items.AddRange(New Object() {"Auto", "200%", "100%", "50%"})
        Me.tscboZoom.Name = "tscboZoom"
        Me.tscboZoom.Size = New Size(146, 50)
        '
        'tsbZoomEnlarge
        '
        Me.tsbZoomEnlarge.DisplayStyle = ToolStripItemDisplayStyle.Image
        Me.tsbZoomEnlarge.Image = CType(resources.GetObject("tsbZoomEnlarge.Image"), Image)
        Me.tsbZoomEnlarge.ImageTransparentColor = Color.Magenta
        Me.tsbZoomEnlarge.Name = "tsbZoomEnlarge"
        Me.tsbZoomEnlarge.Size = New Size(46, 44)
        Me.tsbZoomEnlarge.Text = "ToolStripButton2"
        Me.tsbZoomEnlarge.ToolTipText = "Zoom Enlarge"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New Size(6, 50)
        '
        'tsbHandTool
        '
        Me.tsbHandTool.CheckOnClick = True
        Me.tsbHandTool.DisplayStyle = ToolStripItemDisplayStyle.Image
        Me.tsbHandTool.Image = CType(resources.GetObject("tsbHandTool.Image"), Image)
        Me.tsbHandTool.ImageTransparentColor = Color.Magenta
        Me.tsbHandTool.Name = "tsbHandTool"
        Me.tsbHandTool.Size = New Size(46, 44)
        Me.tsbHandTool.Text = "ToolStripButton1"
        Me.tsbHandTool.ToolTipText = "Hand Tool"
        '
        'tsbSelectionTool
        '
        Me.tsbSelectionTool.CheckOnClick = True
        Me.tsbSelectionTool.DisplayStyle = ToolStripItemDisplayStyle.Image
        Me.tsbSelectionTool.Image = CType(resources.GetObject("tsbSelectionTool.Image"), Image)
        Me.tsbSelectionTool.ImageTransparentColor = Color.Magenta
        Me.tsbSelectionTool.Name = "tsbSelectionTool"
        Me.tsbSelectionTool.Size = New Size(46, 44)
        Me.tsbSelectionTool.Text = "ToolStripButton1"
        Me.tsbSelectionTool.ToolTipText = "Selection Tool"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New Size(6, 50)
        '
        'tsbClearSelection
        '
        Me.tsbClearSelection.DisplayStyle = ToolStripItemDisplayStyle.Image
        Me.tsbClearSelection.Image = CType(resources.GetObject("tsbClearSelection.Image"), Image)
        Me.tsbClearSelection.ImageTransparentColor = Color.Magenta
        Me.tsbClearSelection.Name = "tsbClearSelection"
        Me.tsbClearSelection.Size = New Size(46, 44)
        Me.tsbClearSelection.Text = "ToolStripButton1"
        Me.tsbClearSelection.ToolTipText = "ClearSelection"
        '
        'tsbCropSelection
        '
        Me.tsbCropSelection.DisplayStyle = ToolStripItemDisplayStyle.Image
        Me.tsbCropSelection.Image = CType(resources.GetObject("tsbCropSelection.Image"), Image)
        Me.tsbCropSelection.ImageTransparentColor = Color.Magenta
        Me.tsbCropSelection.Name = "tsbCropSelection"
        Me.tsbCropSelection.Size = New Size(46, 44)
        Me.tsbCropSelection.Text = "ToolStripButton1"
        Me.tsbCropSelection.ToolTipText = "Crop image to selected area"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New Size(6, 50)
        '
        'tsbRotate90Left
        '
        Me.tsbRotate90Left.DisplayStyle = ToolStripItemDisplayStyle.Image
        Me.tsbRotate90Left.Image = CType(resources.GetObject("tsbRotate90Left.Image"), Image)
        Me.tsbRotate90Left.ImageTransparentColor = Color.Magenta
        Me.tsbRotate90Left.Name = "tsbRotate90Left"
        Me.tsbRotate90Left.Size = New Size(46, 44)
        Me.tsbRotate90Left.Text = "ToolStripButton1"
        Me.tsbRotate90Left.ToolTipText = "Rotate image 90° Left (counterclockwise)"
        '
        'tsbRotate90Right
        '
        Me.tsbRotate90Right.DisplayStyle = ToolStripItemDisplayStyle.Image
        Me.tsbRotate90Right.Image = CType(resources.GetObject("tsbRotate90Right.Image"), Image)
        Me.tsbRotate90Right.ImageTransparentColor = Color.Magenta
        Me.tsbRotate90Right.Name = "tsbRotate90Right"
        Me.tsbRotate90Right.Size = New Size(46, 44)
        Me.tsbRotate90Right.Text = "ToolStripButton1"
        Me.tsbRotate90Right.ToolTipText = "Rotate image 90° Right (clockwise)"
        '
        'paPicPanel
        '
        Me.paPicPanel.BackColor = Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.paPicPanel.Controls.Add(Me.paPicWindow)
        Me.paPicPanel.Controls.Add(Me.hsScrollBar)
        Me.paPicPanel.Controls.Add(Me.vsScrollBar)
        Me.paPicPanel.Cursor = Cursors.No
        Me.paPicPanel.Dock = DockStyle.Fill
        Me.paPicPanel.Location = New Point(0, 50)
        Me.paPicPanel.Margin = New Padding(6)
        Me.paPicPanel.Name = "paPicPanel"
        Me.paPicPanel.Size = New Size(1200, 929)
        Me.paPicPanel.TabIndex = 2
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New Size(32, 32)
        Me.StatusStrip1.Items.AddRange(New ToolStripItem() {Me.sbpFile, Me.sbpResolution, Me.sbpScale})
        Me.StatusStrip1.Location = New Point(0, 937)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New Size(1200, 42)
        Me.StatusStrip1.TabIndex = 4
        '
        'sbpFile
        '
        Me.sbpFile.Name = "sbpFile"
        Me.sbpFile.Size = New Size(923, 32)
        Me.sbpFile.Spring = True
        Me.sbpFile.TextAlign = ContentAlignment.MiddleLeft
        '
        'sbpResolution
        '
        Me.sbpResolution.AutoSize = False
        Me.sbpResolution.Name = "sbpResolution"
        Me.sbpResolution.Size = New Size(250, 32)
        '
        'sbpScale
        '
        Me.sbpScale.AutoSize = False
        Me.sbpScale.Name = "sbpScale"
        Me.sbpScale.Size = New Size(100, 32)
        '
        'paPicWindow
        '
        Me.paPicWindow.Anchor = CType((((AnchorStyles.Top Or AnchorStyles.Bottom) _
            Or AnchorStyles.Left) _
            Or AnchorStyles.Right), AnchorStyles)
        Me.paPicWindow.BackColor = Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.paPicWindow.Controls.Add(Me.pbDisplayedPic)
        Me.paPicWindow.Cursor = Cursors.No
        Me.paPicWindow.Location = New Point(6, 6)
        Me.paPicWindow.Margin = New Padding(6)
        Me.paPicWindow.Name = "paPicWindow"
        Me.paPicWindow.Size = New Size(1154, 842)
        Me.paPicWindow.TabIndex = 3
        '
        'pbDisplayedPic
        '
        Me.pbDisplayedPic.BackColor = Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.pbDisplayedPic.Cursor = Cursors.Arrow
        Me.pbDisplayedPic.Location = New Point(52, 69)
        Me.pbDisplayedPic.Margin = New Padding(6)
        Me.pbDisplayedPic.Name = "pbDisplayedPic"
        Me.pbDisplayedPic.Size = New Size(200, 96)
        Me.pbDisplayedPic.TabIndex = 0
        Me.pbDisplayedPic.TabStop = False
        '
        'hsScrollBar
        '
        Me.hsScrollBar.Anchor = CType(((AnchorStyles.Bottom Or AnchorStyles.Left) _
            Or AnchorStyles.Right), AnchorStyles)
        Me.hsScrollBar.Location = New Point(0, 854)
        Me.hsScrollBar.Name = "hsScrollBar"
        Me.hsScrollBar.Size = New Size(1166, 17)
        Me.hsScrollBar.TabIndex = 1
        '
        'vsScrollBar
        '
        Me.vsScrollBar.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Bottom) _
            Or AnchorStyles.Right), AnchorStyles)
        Me.vsScrollBar.Location = New Point(1166, 0)
        Me.vsScrollBar.Name = "vsScrollBar"
        Me.vsScrollBar.Size = New Size(17, 856)
        Me.vsScrollBar.TabIndex = 0
        '
        'frmImageTool
        '
        Me.AutoScaleDimensions = New SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.ClientSize = New Size(1200, 979)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.paPicPanel)
        Me.Controls.Add(Me.tsMain)
        Me.Margin = New Padding(6)
        Me.Name = "frmImageTool"
        Me.Text = "Image Tool"
        Me.tsMain.ResumeLayout(False)
        Me.tsMain.PerformLayout()
        Me.paPicPanel.ResumeLayout(False)
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.paPicWindow.ResumeLayout(False)
        CType(Me.pbDisplayedPic, ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsMain As ToolStrip
    Friend WithEvents tsbZoomReduce As ToolStripButton
    Friend WithEvents paPicPanel As Panel
    Friend WithEvents hsScrollBar As HScrollBar
    Friend WithEvents vsScrollBar As VScrollBar
    Friend WithEvents paPicWindow As Panel
    Friend WithEvents pbDisplayedPic As PictureBox
    Friend WithEvents tscboZoom As ToolStripComboBox
    Friend WithEvents tsbZoomEnlarge As ToolStripButton
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents tsbHandTool As ToolStripButton
    Friend WithEvents tsbSelectionTool As ToolStripButton
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents tsbClearSelection As ToolStripButton
    Friend WithEvents tsbCropSelection As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents tsbRotate90Left As ToolStripButton
    Friend WithEvents tsbRotate90Right As ToolStripButton
    Friend WithEvents tsbSave As ToolStripButton
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents sbpFile As ToolStripStatusLabel
    Friend WithEvents sbpResolution As ToolStripStatusLabel
    Friend WithEvents sbpScale As ToolStripStatusLabel
End Class
