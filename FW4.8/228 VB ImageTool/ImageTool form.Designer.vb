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
        Me.tsMain = New System.Windows.Forms.ToolStrip
        Me.tsbZoomReduce = New System.Windows.Forms.ToolStripButton
        Me.tscboZoom = New System.Windows.Forms.ToolStripComboBox
        Me.tsbZoomEnlarge = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbHandTool = New System.Windows.Forms.ToolStripButton
        Me.tsbSelectionTool = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbClearSelection = New System.Windows.Forms.ToolStripButton
        Me.tsbCrop = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.btnRotate90Left = New System.Windows.Forms.ToolStripButton
        Me.btnRotate90Right = New System.Windows.Forms.ToolStripButton
        Me.paPicPanel = New System.Windows.Forms.Panel
        Me.sbStatus = New System.Windows.Forms.StatusBar
        Me.sbpFile = New System.Windows.Forms.StatusBarPanel
        Me.sbpResolution = New System.Windows.Forms.StatusBarPanel
        Me.sbpScale = New System.Windows.Forms.StatusBarPanel
        Me.paPicWindow = New System.Windows.Forms.Panel
        Me.pbDisplayedPic = New System.Windows.Forms.PictureBox
        Me.hsScrollBar = New System.Windows.Forms.HScrollBar
        Me.vsScrollBar = New System.Windows.Forms.VScrollBar
        Me.tsMain.SuspendLayout()
        Me.paPicPanel.SuspendLayout()
        CType(Me.sbpFile, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sbpResolution, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.sbpScale, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.paPicWindow.SuspendLayout()
        CType(Me.pbDisplayedPic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tsMain
        '
        Me.tsMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbZoomReduce, Me.tscboZoom, Me.tsbZoomEnlarge, Me.ToolStripSeparator1, Me.tsbHandTool, Me.tsbSelectionTool, Me.ToolStripSeparator2, Me.tsbClearSelection, Me.tsbCrop, Me.ToolStripSeparator3, Me.btnRotate90Left, Me.btnRotate90Right})
        Me.tsMain.Location = New System.Drawing.Point(0, 0)
        Me.tsMain.Name = "tsMain"
        Me.tsMain.Size = New System.Drawing.Size(600, 25)
        Me.tsMain.TabIndex = 0
        Me.tsMain.Text = "ToolStrip1"
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
        'tsbCrop
        '
        Me.tsbCrop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbCrop.Image = CType(resources.GetObject("tsbCrop.Image"), System.Drawing.Image)
        Me.tsbCrop.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCrop.Name = "tsbCrop"
        Me.tsbCrop.Size = New System.Drawing.Size(23, 22)
        Me.tsbCrop.Text = "ToolStripButton1"
        Me.tsbCrop.ToolTipText = "Crop"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 25)
        '
        'btnRotate90Left
        '
        Me.btnRotate90Left.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnRotate90Left.Image = CType(resources.GetObject("btnRotate90Left.Image"), System.Drawing.Image)
        Me.btnRotate90Left.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnRotate90Left.Name = "btnRotate90Left"
        Me.btnRotate90Left.Size = New System.Drawing.Size(23, 22)
        Me.btnRotate90Left.Text = "ToolStripButton1"
        Me.btnRotate90Left.ToolTipText = "Rotate image 90° Left (counterclockwise)"
        '
        'btnRotate90Right
        '
        Me.btnRotate90Right.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnRotate90Right.Image = CType(resources.GetObject("btnRotate90Right.Image"), System.Drawing.Image)
        Me.btnRotate90Right.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnRotate90Right.Name = "btnRotate90Right"
        Me.btnRotate90Right.Size = New System.Drawing.Size(23, 22)
        Me.btnRotate90Right.Text = "ToolStripButton1"
        Me.btnRotate90Right.ToolTipText = "Rotate image 90° Right (clockwise)"
        '
        'paPicPanel
        '
        Me.paPicPanel.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.paPicPanel.Controls.Add(Me.sbStatus)
        Me.paPicPanel.Controls.Add(Me.paPicWindow)
        Me.paPicPanel.Controls.Add(Me.hsScrollBar)
        Me.paPicPanel.Controls.Add(Me.vsScrollBar)
        Me.paPicPanel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.paPicPanel.Location = New System.Drawing.Point(0, 25)
        Me.paPicPanel.Name = "paPicPanel"
        Me.paPicPanel.Size = New System.Drawing.Size(600, 484)
        Me.paPicPanel.TabIndex = 2
        '
        'sbStatus
        '
        Me.sbStatus.Location = New System.Drawing.Point(0, 462)
        Me.sbStatus.Name = "sbStatus"
        Me.sbStatus.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.sbpFile, Me.sbpResolution, Me.sbpScale})
        Me.sbStatus.ShowPanels = True
        Me.sbStatus.Size = New System.Drawing.Size(600, 22)
        Me.sbStatus.TabIndex = 4
        '
        'sbpFile
        '
        Me.sbpFile.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.sbpFile.Name = "sbpFile"
        Me.sbpFile.Width = 383
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
        Me.paPicWindow.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.paPicWindow.Controls.Add(Me.pbDisplayedPic)
        Me.paPicWindow.Location = New System.Drawing.Point(3, 3)
        Me.paPicWindow.Name = "paPicWindow"
        Me.paPicWindow.Size = New System.Drawing.Size(577, 439)
        Me.paPicWindow.TabIndex = 3
        '
        'pbDisplayedPic
        '
        Me.pbDisplayedPic.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.pbDisplayedPic.Location = New System.Drawing.Point(26, 36)
        Me.pbDisplayedPic.Name = "pbDisplayedPic"
        Me.pbDisplayedPic.Size = New System.Drawing.Size(100, 50)
        Me.pbDisplayedPic.TabIndex = 0
        Me.pbDisplayedPic.TabStop = False
        '
        'hsScrollBar
        '
        Me.hsScrollBar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.hsScrollBar.Location = New System.Drawing.Point(0, 445)
        Me.hsScrollBar.Name = "hsScrollBar"
        Me.hsScrollBar.Size = New System.Drawing.Size(583, 17)
        Me.hsScrollBar.TabIndex = 1
        '
        'vsScrollBar
        '
        Me.vsScrollBar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.vsScrollBar.Location = New System.Drawing.Point(583, 0)
        Me.vsScrollBar.Name = "vsScrollBar"
        Me.vsScrollBar.Size = New System.Drawing.Size(17, 446)
        Me.vsScrollBar.TabIndex = 0
        '
        'frmImageTool
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(600, 509)
        Me.Controls.Add(Me.paPicPanel)
        Me.Controls.Add(Me.tsMain)
        Me.Name = "frmImageTool"
        Me.Text = "Image Tool"
        Me.tsMain.ResumeLayout(False)
        Me.tsMain.PerformLayout()
        Me.paPicPanel.ResumeLayout(False)
        CType(Me.sbpFile, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sbpResolution, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.sbpScale, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents sbStatus As System.Windows.Forms.StatusBar
    Friend WithEvents sbpFile As System.Windows.Forms.StatusBarPanel
    Friend WithEvents sbpResolution As System.Windows.Forms.StatusBarPanel
    Friend WithEvents sbpScale As System.Windows.Forms.StatusBarPanel
    Friend WithEvents tscboZoom As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents tsbZoomEnlarge As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbHandTool As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbSelectionTool As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbClearSelection As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbCrop As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnRotate90Left As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnRotate90Right As System.Windows.Forms.ToolStripButton

End Class
