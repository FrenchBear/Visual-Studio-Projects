﻿Partial Public Class Form1
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

    End Sub

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
        Me.fileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.newToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem
        Me.ToolStripMenuItem3 = New System.Windows.Forms.ToolStripMenuItem
        Me.openToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.toolStripSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.saveToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.saveAsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.toolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.printToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.printPreviewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.toolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.exitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.editToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.undoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.redoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.toolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.cutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.copyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.pasteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.toolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.selectAllToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.toolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.customizeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.optionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.helpToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.contentsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.indexToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.searchToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.toolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.aboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.Button1 = New System.Windows.Forms.Button
        Me.topToolStripPanel = New System.Windows.Forms.ToolStripPanel
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.B1ToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.B2ToolStripButton = New System.Windows.Forms.ToolStripButton
        Me.LabelToolStripLabel = New System.Windows.Forms.ToolStripLabel
        Me.SBToolStripSplitButton = New System.Windows.Forms.ToolStripSplitButton
        Me.X1ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DDBToolStripDropDownButton = New System.Windows.Forms.ToolStripDropDownButton
        Me.X2ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ComboToolStripComboBox = New System.Windows.Forms.ToolStripComboBox
        Me.TextBoxToolStripTextBox = New System.Windows.Forms.ToolStripTextBox
        Me.PbToolStripProgressBar = New System.Windows.Forms.ToolStripProgressBar
        Me.bottomToolStripPanel = New System.Windows.Forms.ToolStripPanel
        Me.MenuStrip1.SuspendLayout()
        CType(Me.topToolStripPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.topToolStripPanel.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.bottomToolStripPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.GripMargin = New System.Windows.Forms.Padding(0)
        Me.MenuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.fileToolStripMenuItem, Me.editToolStripMenuItem, Me.toolsToolStripMenuItem, Me.helpToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New System.Windows.Forms.Padding(1)
        Me.MenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.MenuStrip1.ShowItemToolTips = True
        Me.MenuStrip1.Size = New System.Drawing.Size(567, 22)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'fileToolStripMenuItem
        '
        Me.fileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.newToolStripMenuItem, Me.openToolStripMenuItem, Me.toolStripSeparator, Me.saveToolStripMenuItem, Me.saveAsToolStripMenuItem, Me.toolStripSeparator1, Me.printToolStripMenuItem, Me.printPreviewToolStripMenuItem, Me.toolStripSeparator2, Me.exitToolStripMenuItem})
        Me.fileToolStripMenuItem.Name = "fileToolStripMenuItem"
        Me.fileToolStripMenuItem.Text = "&File"
        '
        'newToolStripMenuItem
        '
        Me.newToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripMenuItem2, Me.ToolStripMenuItem3})
        Me.newToolStripMenuItem.Image = CType(resources.GetObject("newToolStripMenuItem.Image"), System.Drawing.Image)
        Me.newToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.newToolStripMenuItem.Name = "newToolStripMenuItem"
        Me.newToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.N), System.Windows.Forms.Keys)
        Me.newToolStripMenuItem.Text = "&New"
        Me.newToolStripMenuItem.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Text = "ToolStripMenuItem1"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Text = "ToolStripMenuItem2"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Text = "ToolStripMenuItem3"
        '
        'openToolStripMenuItem
        '
        Me.openToolStripMenuItem.Image = CType(resources.GetObject("openToolStripMenuItem.Image"), System.Drawing.Image)
        Me.openToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Lavender
        Me.openToolStripMenuItem.Name = "openToolStripMenuItem"
        Me.openToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
        Me.openToolStripMenuItem.Text = "&Open"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        '
        'saveToolStripMenuItem
        '
        Me.saveToolStripMenuItem.Image = CType(resources.GetObject("saveToolStripMenuItem.Image"), System.Drawing.Image)
        Me.saveToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Lime
        Me.saveToolStripMenuItem.Name = "saveToolStripMenuItem"
        Me.saveToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
        Me.saveToolStripMenuItem.Text = "&Save"
        '
        'saveAsToolStripMenuItem
        '
        Me.saveAsToolStripMenuItem.Image = CType(resources.GetObject("saveAsToolStripMenuItem.Image"), System.Drawing.Image)
        Me.saveAsToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Lime
        Me.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem"
        Me.saveAsToolStripMenuItem.Text = "Save &As"
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        '
        'printToolStripMenuItem
        '
        Me.printToolStripMenuItem.Image = CType(resources.GetObject("printToolStripMenuItem.Image"), System.Drawing.Image)
        Me.printToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Lime
        Me.printToolStripMenuItem.Name = "printToolStripMenuItem"
        Me.printToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.P), System.Windows.Forms.Keys)
        Me.printToolStripMenuItem.Text = "&Print"
        '
        'printPreviewToolStripMenuItem
        '
        Me.printPreviewToolStripMenuItem.Image = CType(resources.GetObject("printPreviewToolStripMenuItem.Image"), System.Drawing.Image)
        Me.printPreviewToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Lime
        Me.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem"
        Me.printPreviewToolStripMenuItem.Text = "Print Pre&view"
        '
        'toolStripSeparator2
        '
        Me.toolStripSeparator2.Name = "toolStripSeparator2"
        '
        'exitToolStripMenuItem
        '
        Me.exitToolStripMenuItem.Name = "exitToolStripMenuItem"
        Me.exitToolStripMenuItem.Text = "E&xit"
        '
        'editToolStripMenuItem
        '
        Me.editToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.undoToolStripMenuItem, Me.redoToolStripMenuItem, Me.toolStripSeparator3, Me.cutToolStripMenuItem, Me.copyToolStripMenuItem, Me.pasteToolStripMenuItem, Me.toolStripSeparator4, Me.selectAllToolStripMenuItem})
        Me.editToolStripMenuItem.Name = "editToolStripMenuItem"
        Me.editToolStripMenuItem.Text = "&Edit"
        '
        'undoToolStripMenuItem
        '
        Me.undoToolStripMenuItem.Name = "undoToolStripMenuItem"
        Me.undoToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Z), System.Windows.Forms.Keys)
        Me.undoToolStripMenuItem.Text = "&Undo"
        '
        'redoToolStripMenuItem
        '
        Me.redoToolStripMenuItem.Name = "redoToolStripMenuItem"
        Me.redoToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Y), System.Windows.Forms.Keys)
        Me.redoToolStripMenuItem.Text = "&Redo"
        '
        'toolStripSeparator3
        '
        Me.toolStripSeparator3.Name = "toolStripSeparator3"
        '
        'cutToolStripMenuItem
        '
        Me.cutToolStripMenuItem.Image = CType(resources.GetObject("cutToolStripMenuItem.Image"), System.Drawing.Image)
        Me.cutToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Lime
        Me.cutToolStripMenuItem.Name = "cutToolStripMenuItem"
        Me.cutToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.cutToolStripMenuItem.Text = "Cu&t"
        '
        'copyToolStripMenuItem
        '
        Me.copyToolStripMenuItem.Image = CType(resources.GetObject("copyToolStripMenuItem.Image"), System.Drawing.Image)
        Me.copyToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Lime
        Me.copyToolStripMenuItem.Name = "copyToolStripMenuItem"
        Me.copyToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.copyToolStripMenuItem.Text = "&Copy"
        '
        'pasteToolStripMenuItem
        '
        Me.pasteToolStripMenuItem.Image = CType(resources.GetObject("pasteToolStripMenuItem.Image"), System.Drawing.Image)
        Me.pasteToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Lime
        Me.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem"
        Me.pasteToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys)
        Me.pasteToolStripMenuItem.Text = "&Paste"
        '
        'toolStripSeparator4
        '
        Me.toolStripSeparator4.Name = "toolStripSeparator4"
        '
        'selectAllToolStripMenuItem
        '
        Me.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem"
        Me.selectAllToolStripMenuItem.Text = "Select &All"
        '
        'toolsToolStripMenuItem
        '
        Me.toolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.customizeToolStripMenuItem, Me.optionsToolStripMenuItem})
        Me.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem"
        Me.toolsToolStripMenuItem.Text = "&Tools"
        '
        'customizeToolStripMenuItem
        '
        Me.customizeToolStripMenuItem.Name = "customizeToolStripMenuItem"
        Me.customizeToolStripMenuItem.Text = "&Customize"
        '
        'optionsToolStripMenuItem
        '
        Me.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem"
        Me.optionsToolStripMenuItem.Text = "&Options"
        '
        'helpToolStripMenuItem
        '
        Me.helpToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.contentsToolStripMenuItem, Me.indexToolStripMenuItem, Me.searchToolStripMenuItem, Me.toolStripSeparator5, Me.aboutToolStripMenuItem})
        Me.helpToolStripMenuItem.Name = "helpToolStripMenuItem"
        Me.helpToolStripMenuItem.Text = "&Help"
        '
        'contentsToolStripMenuItem
        '
        Me.contentsToolStripMenuItem.Name = "contentsToolStripMenuItem"
        Me.contentsToolStripMenuItem.Text = "&Contents"
        '
        'indexToolStripMenuItem
        '
        Me.indexToolStripMenuItem.Name = "indexToolStripMenuItem"
        Me.indexToolStripMenuItem.Text = "&Index"
        '
        'searchToolStripMenuItem
        '
        Me.searchToolStripMenuItem.Name = "searchToolStripMenuItem"
        Me.searchToolStripMenuItem.Text = "&Search"
        '
        'toolStripSeparator5
        '
        Me.toolStripSeparator5.Name = "toolStripSeparator5"
        '
        'aboutToolStripMenuItem
        '
        Me.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem"
        Me.aboutToolStripMenuItem.Text = "&About..."
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(90, 148)
        Me.Button1.Name = "Button1"
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Button1"
        '
        'topToolStripPanel
        '
        '
        'ToolStrip1
        '
        '
        'B1ToolStripButton
        '
        Me.B1ToolStripButton.Image = My.Resources.MyResources.About
        Me.B1ToolStripButton.Name = "B1ToolStripButton"
        Me.B1ToolStripButton.Text = "B1"
        '
        'B2ToolStripButton
        '
        Me.B2ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.B2ToolStripButton.Image = My.Resources.MyResources.Calc
        Me.B2ToolStripButton.Name = "B2ToolStripButton"
        Me.B2ToolStripButton.Text = "Calc"
        '
        'LabelToolStripLabel
        '
        Me.LabelToolStripLabel.Name = "LabelToolStripLabel"
        Me.LabelToolStripLabel.Text = "Label"
        '
        'SBToolStripSplitButton
        '
        '
        'X1ToolStripMenuItem
        '
        Me.X1ToolStripMenuItem.Name = "X1ToolStripMenuItem"
        Me.X1ToolStripMenuItem.Text = "X1"
        Me.SBToolStripSplitButton.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.X1ToolStripMenuItem})
        Me.SBToolStripSplitButton.Name = "SBToolStripSplitButton"
        Me.SBToolStripSplitButton.Text = "SB"
        '
        'DDBToolStripDropDownButton
        '
        '
        'X2ToolStripMenuItem
        '
        Me.X2ToolStripMenuItem.Name = "X2ToolStripMenuItem"
        Me.X2ToolStripMenuItem.Text = "X2"
        Me.DDBToolStripDropDownButton.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.X2ToolStripMenuItem})
        Me.DDBToolStripDropDownButton.Name = "DDBToolStripDropDownButton"
        Me.DDBToolStripDropDownButton.Text = "DDB"
        '
        'ComboToolStripComboBox
        '
        Me.ComboToolStripComboBox.Items.AddRange(New Object() {"Un", "Deux", "Trois", "Quatre"})
        Me.ComboToolStripComboBox.Name = "ComboToolStripComboBox"
        Me.ComboToolStripComboBox.Size = New System.Drawing.Size(101, 21)
        Me.ComboToolStripComboBox.Text = "Combo"
        '
        'TextBoxToolStripTextBox
        '
        Me.TextBoxToolStripTextBox.Name = "TextBoxToolStripTextBox"
        Me.TextBoxToolStripTextBox.Size = New System.Drawing.Size(100, 19)
        Me.TextBoxToolStripTextBox.Text = "TextBox"
        '
        'PbToolStripProgressBar
        '
        Me.PbToolStripProgressBar.Name = "PbToolStripProgressBar"
        Me.PbToolStripProgressBar.Size = New System.Drawing.Size(100, 21)
        Me.PbToolStripProgressBar.Step = 5
        Me.PbToolStripProgressBar.Text = "Pb"
        Me.PbToolStripProgressBar.Value = 25
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.B1ToolStripButton, Me.B2ToolStripButton, Me.LabelToolStripLabel, Me.SBToolStripSplitButton, Me.DDBToolStripDropDownButton, Me.ComboToolStripComboBox, Me.TextBoxToolStripTextBox, Me.PbToolStripProgressBar})
        Me.ToolStrip1.Location = New System.Drawing.Point(-7, 22)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        Me.topToolStripPanel.Controls.Add(Me.MenuStrip1)
        Me.topToolStripPanel.Controls.Add(Me.ToolStrip1)
        Me.topToolStripPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.topToolStripPanel.Name = "topToolStripPanel"
        Me.topToolStripPanel.RenderMode = System.Windows.Forms.ToolStripRenderMode.System
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.B1ToolStripButton, Me.B2ToolStripButton, Me.LabelToolStripLabel, Me.SBToolStripSplitButton, Me.DDBToolStripDropDownButton, Me.ComboToolStripComboBox, Me.TextBoxToolStripTextBox, Me.PbToolStripProgressBar})
        Me.ToolStrip1.Location = New System.Drawing.Point(36, 21)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'B1ToolStripButton
        '
        Me.B1ToolStripButton.Image = My.Resources.MyResources.About
        Me.B1ToolStripButton.Name = "B1ToolStripButton"
        Me.B1ToolStripButton.Text = "B1"
        '
        'B2ToolStripButton
        '
        Me.B2ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.B2ToolStripButton.Image = My.Resources.MyResources.Calc
        Me.B2ToolStripButton.Name = "B2ToolStripButton"
        Me.B2ToolStripButton.Text = "Calc"
        '
        'LabelToolStripLabel
        '
        Me.LabelToolStripLabel.Name = "LabelToolStripLabel"
        Me.LabelToolStripLabel.Text = "Label"
        '
        'SBToolStripSplitButton
        '
        Me.SBToolStripSplitButton.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.X1ToolStripMenuItem})
        Me.SBToolStripSplitButton.Name = "SBToolStripSplitButton"
        Me.SBToolStripSplitButton.Text = "SB"
        '
        'X1ToolStripMenuItem
        '
        Me.X1ToolStripMenuItem.Name = "X1ToolStripMenuItem"
        Me.X1ToolStripMenuItem.Text = "X1"
        '
        'DDBToolStripDropDownButton
        '
        Me.DDBToolStripDropDownButton.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.X2ToolStripMenuItem})
        Me.DDBToolStripDropDownButton.Name = "DDBToolStripDropDownButton"
        Me.DDBToolStripDropDownButton.Text = "DDB"
        '
        'X2ToolStripMenuItem
        '
        Me.X2ToolStripMenuItem.Name = "X2ToolStripMenuItem"
        Me.X2ToolStripMenuItem.Text = "X2"
        '
        'ComboToolStripComboBox
        '
        Me.ComboToolStripComboBox.Items.AddRange(New Object() {"Un", "Deux", "Trois", "Quatre"})
        Me.ComboToolStripComboBox.Name = "ComboToolStripComboBox"
        Me.ComboToolStripComboBox.Size = New System.Drawing.Size(92, 21)
        Me.ComboToolStripComboBox.Text = "Combo"
        '
        'TextBoxToolStripTextBox
        '
        Me.TextBoxToolStripTextBox.Name = "TextBoxToolStripTextBox"
        Me.TextBoxToolStripTextBox.Size = New System.Drawing.Size(100, 19)
        Me.TextBoxToolStripTextBox.Text = "TextBox"
        '
        'PbToolStripProgressBar
        '
        Me.PbToolStripProgressBar.Name = "PbToolStripProgressBar"
        Me.PbToolStripProgressBar.Size = New System.Drawing.Size(100, 21)
        Me.PbToolStripProgressBar.Step = 5
        Me.PbToolStripProgressBar.Text = "Pb"
        Me.PbToolStripProgressBar.Value = 25
        '
        'bottomToolStripPanel
        '
        Me.bottomToolStripPanel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.bottomToolStripPanel.Name = "bottomToolStripPanel"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(567, 266)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.topToolStripPanel)
        Me.Controls.Add(Me.bottomToolStripPanel)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.MenuStrip1.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        CType(Me.topToolStripPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.topToolStripPanel.ResumeLayout(False)
        Me.topToolStripPanel.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        CType(Me.bottomToolStripPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents fileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents newToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents openToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents saveToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents saveAsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents printToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents printPreviewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents exitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents editToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents undoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents redoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents copyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pasteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents selectAllToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents customizeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents optionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents helpToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents contentsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents indexToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents searchToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents toolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents aboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents topToolStripPanel As System.Windows.Forms.ToolStripPanel
    Friend WithEvents bottomToolStripPanel As System.Windows.Forms.ToolStripPanel
    Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents B1ToolStripButton As System.Windows.Forms.ToolStripButton
    Friend WithEvents LabelToolStripLabel As System.Windows.Forms.ToolStripLabel
    Friend WithEvents SBToolStripSplitButton As System.Windows.Forms.ToolStripSplitButton
    Friend WithEvents X1ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DDBToolStripDropDownButton As System.Windows.Forms.ToolStripDropDownButton
    Friend WithEvents X2ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ComboToolStripComboBox As System.Windows.Forms.ToolStripComboBox
    Friend WithEvents TextBoxToolStripTextBox As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents PbToolStripProgressBar As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents B2ToolStripButton As System.Windows.Forms.ToolStripButton

End Class
