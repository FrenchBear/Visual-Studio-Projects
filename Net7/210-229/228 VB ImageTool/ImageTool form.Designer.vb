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
        Me.tsbZoomReduce = New ToolStripButton()
        Me.tscboZoom = New ToolStripComboBox()
        Me.tsbZoomEnlarge = New ToolStripButton()
        Me.ToolStripSeparator1 = New ToolStripSeparator()
        Me.tsbHandTool = New ToolStripButton()
        Me.tsbSelectionTool = New ToolStripButton()
        Me.ToolStripSeparator2 = New ToolStripSeparator()
        Me.tsbClearSelection = New ToolStripButton()
        Me.tsbCrop = New ToolStripButton()
        Me.ToolStripSeparator3 = New ToolStripSeparator()
        Me.btnRotate90Left = New ToolStripButton()
        Me.btnRotate90Right = New ToolStripButton()
        Me.paPicPanel = New Panel()
        Me.paPicWindow = New Panel()
        Me.pbDisplayedPic = New PictureBox()
        Me.hsScrollBar = New HScrollBar()
        Me.vsScrollBar = New VScrollBar()
        Me.StatusStrip1 = New StatusStrip()
        Me.sbpFile = New ToolStripStatusLabel()
        Me.sbpResolution = New ToolStripStatusLabel()
        Me.sbpScale = New ToolStripStatusLabel()
        Me.tsMain.SuspendLayout()
        Me.paPicPanel.SuspendLayout()
        Me.paPicWindow.SuspendLayout()
        CType(Me.pbDisplayedPic, ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsMain
        '
        Me.tsMain.ImageScalingSize = New Size(32, 32)
        Me.tsMain.Items.AddRange(New ToolStripItem() {Me.tsbZoomReduce, Me.tscboZoom, Me.tsbZoomEnlarge, Me.ToolStripSeparator1, Me.tsbHandTool, Me.tsbSelectionTool, Me.ToolStripSeparator2, Me.tsbClearSelection, Me.tsbCrop, Me.ToolStripSeparator3, Me.btnRotate90Left, Me.btnRotate90Right})
        Me.tsMain.Location = New Point(0, 0)
        Me.tsMain.Name = "tsMain"
        Me.tsMain.Padding = New Padding(0, 0, 4, 0)
        Me.tsMain.Size = New Size(1300, 42)
        Me.tsMain.TabIndex = 0
        Me.tsMain.Text = "ToolStrip1"
        '
        'tsbZoomReduce
        '
        Me.tsbZoomReduce.DisplayStyle = ToolStripItemDisplayStyle.Image
        Me.tsbZoomReduce.Image = CType(resources.GetObject("tsbZoomReduce.Image"), Image)
        Me.tsbZoomReduce.ImageTransparentColor = Color.Magenta
        Me.tsbZoomReduce.Name = "tsbZoomReduce"
        Me.tsbZoomReduce.Size = New Size(46, 36)
        Me.tsbZoomReduce.Text = "ToolStripButton1"
        Me.tsbZoomReduce.ToolTipText = "Zoom Reduce"
        '
        'tscboZoom
        '
        Me.tscboZoom.Items.AddRange(New Object() {"Auto", "200%", "100%", "50%"})
        Me.tscboZoom.Name = "tscboZoom"
        Me.tscboZoom.Size = New Size(158, 42)
        '
        'tsbZoomEnlarge
        '
        Me.tsbZoomEnlarge.DisplayStyle = ToolStripItemDisplayStyle.Image
        Me.tsbZoomEnlarge.Image = CType(resources.GetObject("tsbZoomEnlarge.Image"), Image)
        Me.tsbZoomEnlarge.ImageTransparentColor = Color.Magenta
        Me.tsbZoomEnlarge.Name = "tsbZoomEnlarge"
        Me.tsbZoomEnlarge.Size = New Size(46, 36)
        Me.tsbZoomEnlarge.Text = "ToolStripButton2"
        Me.tsbZoomEnlarge.ToolTipText = "Zoom Enlarge"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New Size(6, 42)
        '
        'tsbHandTool
        '
        Me.tsbHandTool.CheckOnClick = True
        Me.tsbHandTool.DisplayStyle = ToolStripItemDisplayStyle.Image
        Me.tsbHandTool.Image = CType(resources.GetObject("tsbHandTool.Image"), Image)
        Me.tsbHandTool.ImageTransparentColor = Color.Magenta
        Me.tsbHandTool.Name = "tsbHandTool"
        Me.tsbHandTool.Size = New Size(46, 36)
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
        Me.tsbSelectionTool.Size = New Size(46, 36)
        Me.tsbSelectionTool.Text = "ToolStripButton1"
        Me.tsbSelectionTool.ToolTipText = "Selection Tool"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New Size(6, 42)
        '
        'tsbClearSelection
        '
        Me.tsbClearSelection.DisplayStyle = ToolStripItemDisplayStyle.Image
        Me.tsbClearSelection.Image = CType(resources.GetObject("tsbClearSelection.Image"), Image)
        Me.tsbClearSelection.ImageTransparentColor = Color.Magenta
        Me.tsbClearSelection.Name = "tsbClearSelection"
        Me.tsbClearSelection.Size = New Size(46, 36)
        Me.tsbClearSelection.Text = "ToolStripButton1"
        Me.tsbClearSelection.ToolTipText = "ClearSelection"
        '
        'tsbCrop
        '
        Me.tsbCrop.DisplayStyle = ToolStripItemDisplayStyle.Image
        Me.tsbCrop.Image = CType(resources.GetObject("tsbCrop.Image"), Image)
        Me.tsbCrop.ImageTransparentColor = Color.Magenta
        Me.tsbCrop.Name = "tsbCrop"
        Me.tsbCrop.Size = New Size(46, 36)
        Me.tsbCrop.Text = "ToolStripButton1"
        Me.tsbCrop.ToolTipText = "Crop"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New Size(6, 42)
        '
        'btnRotate90Left
        '
        Me.btnRotate90Left.DisplayStyle = ToolStripItemDisplayStyle.Image
        Me.btnRotate90Left.Image = CType(resources.GetObject("btnRotate90Left.Image"), Image)
        Me.btnRotate90Left.ImageTransparentColor = Color.Magenta
        Me.btnRotate90Left.Name = "btnRotate90Left"
        Me.btnRotate90Left.Size = New Size(46, 36)
        Me.btnRotate90Left.Text = "ToolStripButton1"
        Me.btnRotate90Left.ToolTipText = "Rotate image 90° Left (counterclockwise)"
        '
        'btnRotate90Right
        '
        Me.btnRotate90Right.DisplayStyle = ToolStripItemDisplayStyle.Image
        Me.btnRotate90Right.Image = CType(resources.GetObject("btnRotate90Right.Image"), Image)
        Me.btnRotate90Right.ImageTransparentColor = Color.Magenta
        Me.btnRotate90Right.Name = "btnRotate90Right"
        Me.btnRotate90Right.Size = New Size(46, 36)
        Me.btnRotate90Right.Text = "ToolStripButton1"
        Me.btnRotate90Right.ToolTipText = "Rotate image 90° Right (clockwise)"
        '
        'paPicPanel
        '
        Me.paPicPanel.BackColor = Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.paPicPanel.Controls.Add(Me.paPicWindow)
        Me.paPicPanel.Controls.Add(Me.hsScrollBar)
        Me.paPicPanel.Controls.Add(Me.vsScrollBar)
        Me.paPicPanel.Dock = DockStyle.Fill
        Me.paPicPanel.Location = New Point(0, 42)
        Me.paPicPanel.Margin = New Padding(6, 8, 6, 8)
        Me.paPicPanel.Name = "paPicPanel"
        Me.paPicPanel.Size = New Size(1300, 1211)
        Me.paPicPanel.TabIndex = 2
        '
        'paPicWindow
        '
        Me.paPicWindow.Anchor = CType((((AnchorStyles.Top Or AnchorStyles.Bottom) _
            Or AnchorStyles.Left) _
            Or AnchorStyles.Right), AnchorStyles)
        Me.paPicWindow.BackColor = Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.paPicWindow.Controls.Add(Me.pbDisplayedPic)
        Me.paPicWindow.Location = New Point(6, 8)
        Me.paPicWindow.Margin = New Padding(6, 8, 6, 8)
        Me.paPicWindow.Name = "paPicWindow"
        Me.paPicWindow.Size = New Size(1250, 1110)
        Me.paPicWindow.TabIndex = 3
        '
        'pbDisplayedPic
        '
        Me.pbDisplayedPic.BackColor = Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.pbDisplayedPic.Location = New Point(56, 88)
        Me.pbDisplayedPic.Margin = New Padding(6, 8, 6, 8)
        Me.pbDisplayedPic.Name = "pbDisplayedPic"
        Me.pbDisplayedPic.Size = New Size(217, 123)
        Me.pbDisplayedPic.TabIndex = 0
        Me.pbDisplayedPic.TabStop = False
        '
        'hsScrollBar
        '
        Me.hsScrollBar.Anchor = CType(((AnchorStyles.Bottom Or AnchorStyles.Left) _
            Or AnchorStyles.Right), AnchorStyles)
        Me.hsScrollBar.Location = New Point(0, 1125)
        Me.hsScrollBar.Name = "hsScrollBar"
        Me.hsScrollBar.Size = New Size(1263, 17)
        Me.hsScrollBar.TabIndex = 1
        '
        'vsScrollBar
        '
        Me.vsScrollBar.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Bottom) _
            Or AnchorStyles.Right), AnchorStyles)
        Me.vsScrollBar.Location = New Point(1263, 0)
        Me.vsScrollBar.Name = "vsScrollBar"
        Me.vsScrollBar.Size = New Size(17, 1128)
        Me.vsScrollBar.TabIndex = 0
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New Size(32, 32)
        Me.StatusStrip1.Items.AddRange(New ToolStripItem() {Me.sbpFile, Me.sbpResolution, Me.sbpScale})
        Me.StatusStrip1.Location = New Point(0, 1211)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Padding = New Padding(1, 0, 15, 0)
        Me.StatusStrip1.Size = New Size(1300, 42)
        Me.StatusStrip1.TabIndex = 5
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'sbpFile
        '
        Me.sbpFile.Name = "sbpFile"
        Me.sbpFile.Size = New Size(844, 32)
        Me.sbpFile.Spring = True
        Me.sbpFile.TextAlign = ContentAlignment.MiddleLeft
        '
        'sbpResolution
        '
        Me.sbpResolution.AutoSize = False
        Me.sbpResolution.Name = "sbpResolution"
        Me.sbpResolution.Size = New Size(240, 32)
        '
        'sbpScale
        '
        Me.sbpScale.AutoSize = False
        Me.sbpScale.Name = "sbpScale"
        Me.sbpScale.Size = New Size(200, 32)
        '
        'frmImageTool
        '
        Me.AutoScaleDimensions = New SizeF(13.0!, 32.0!)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.ClientSize = New Size(1300, 1253)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.paPicPanel)
        Me.Controls.Add(Me.tsMain)
        Me.Margin = New Padding(6, 8, 6, 8)
        Me.Name = "frmImageTool"
        Me.Text = "Image Tool"
        Me.tsMain.ResumeLayout(False)
        Me.tsMain.PerformLayout()
        Me.paPicPanel.ResumeLayout(False)
        Me.paPicWindow.ResumeLayout(False)
        CType(Me.pbDisplayedPic, ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
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
    Friend WithEvents tsbCrop As ToolStripButton
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents btnRotate90Left As ToolStripButton
    Friend WithEvents btnRotate90Right As ToolStripButton
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents sbpFile As ToolStripStatusLabel
    Friend WithEvents sbpResolution As ToolStripStatusLabel
    Friend WithEvents sbpScale As ToolStripStatusLabel
End Class
