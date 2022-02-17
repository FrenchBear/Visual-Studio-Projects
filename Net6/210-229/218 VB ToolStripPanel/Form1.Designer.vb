Imports System.ComponentModel

Partial Public Class Form1
    Inherits Form

    <DebuggerNonUserCode()>
    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

    End Sub

    'Form overrides dispose to clean up the component list.
    <DebuggerNonUserCode()>
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
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
        Dim resources As ComponentResourceManager = New ComponentResourceManager(GetType(Form1))
        Me.MenuStrip1 = New MenuStrip()
        Me.fileToolStripMenuItem = New ToolStripMenuItem()
        Me.newToolStripMenuItem = New ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New ToolStripMenuItem()
        Me.ToolStripMenuItem3 = New ToolStripMenuItem()
        Me.openToolStripMenuItem = New ToolStripMenuItem()
        Me.toolStripSeparator = New ToolStripSeparator()
        Me.saveToolStripMenuItem = New ToolStripMenuItem()
        Me.saveAsToolStripMenuItem = New ToolStripMenuItem()
        Me.toolStripSeparator1 = New ToolStripSeparator()
        Me.printToolStripMenuItem = New ToolStripMenuItem()
        Me.printPreviewToolStripMenuItem = New ToolStripMenuItem()
        Me.toolStripSeparator2 = New ToolStripSeparator()
        Me.exitToolStripMenuItem = New ToolStripMenuItem()
        Me.editToolStripMenuItem = New ToolStripMenuItem()
        Me.undoToolStripMenuItem = New ToolStripMenuItem()
        Me.redoToolStripMenuItem = New ToolStripMenuItem()
        Me.toolStripSeparator3 = New ToolStripSeparator()
        Me.cutToolStripMenuItem = New ToolStripMenuItem()
        Me.copyToolStripMenuItem = New ToolStripMenuItem()
        Me.pasteToolStripMenuItem = New ToolStripMenuItem()
        Me.toolStripSeparator4 = New ToolStripSeparator()
        Me.selectAllToolStripMenuItem = New ToolStripMenuItem()
        Me.toolsToolStripMenuItem = New ToolStripMenuItem()
        Me.customizeToolStripMenuItem = New ToolStripMenuItem()
        Me.optionsToolStripMenuItem = New ToolStripMenuItem()
        Me.helpToolStripMenuItem = New ToolStripMenuItem()
        Me.contentsToolStripMenuItem = New ToolStripMenuItem()
        Me.indexToolStripMenuItem = New ToolStripMenuItem()
        Me.searchToolStripMenuItem = New ToolStripMenuItem()
        Me.toolStripSeparator5 = New ToolStripSeparator()
        Me.aboutToolStripMenuItem = New ToolStripMenuItem()
        Me.Button1 = New Button()
        Me.topToolStripPanel = New ToolStripPanel()
        Me.ToolStrip1 = New ToolStrip()
        Me.B1ToolStripButton = New ToolStripButton()
        Me.B2ToolStripButton = New ToolStripButton()
        Me.LabelToolStripLabel = New ToolStripLabel()
        Me.SBToolStripSplitButton = New ToolStripSplitButton()
        Me.X1ToolStripMenuItem = New ToolStripMenuItem()
        Me.DDBToolStripDropDownButton = New ToolStripDropDownButton()
        Me.X2ToolStripMenuItem = New ToolStripMenuItem()
        Me.ComboToolStripComboBox = New ToolStripComboBox()
        Me.TextBoxToolStripTextBox = New ToolStripTextBox()
        Me.PbToolStripProgressBar = New ToolStripProgressBar()
        Me.bottomToolStripPanel = New ToolStripPanel()
        Me.MenuStrip1.SuspendLayout()
        Me.topToolStripPanel.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Dock = DockStyle.None
        Me.MenuStrip1.GripMargin = New Padding(0)
        Me.MenuStrip1.GripStyle = ToolStripGripStyle.Visible
        Me.MenuStrip1.ImageScalingSize = New Size(32, 32)
        Me.MenuStrip1.Items.AddRange(New ToolStripItem() {Me.fileToolStripMenuItem, Me.editToolStripMenuItem, Me.toolsToolStripMenuItem, Me.helpToolStripMenuItem})
        Me.MenuStrip1.Location = New Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New Padding(1)
        Me.MenuStrip1.RenderMode = ToolStripRenderMode.Professional
        Me.MenuStrip1.ShowItemToolTips = True
        Me.MenuStrip1.Size = New Size(1362, 38)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'fileToolStripMenuItem
        '
        Me.fileToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {Me.newToolStripMenuItem, Me.openToolStripMenuItem, Me.toolStripSeparator, Me.saveToolStripMenuItem, Me.saveAsToolStripMenuItem, Me.toolStripSeparator1, Me.printToolStripMenuItem, Me.printPreviewToolStripMenuItem, Me.toolStripSeparator2, Me.exitToolStripMenuItem})
        Me.fileToolStripMenuItem.Name = "fileToolStripMenuItem"
        Me.fileToolStripMenuItem.Size = New Size(71, 36)
        Me.fileToolStripMenuItem.Text = "&File"
        '
        'newToolStripMenuItem
        '
        Me.newToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {Me.ToolStripMenuItem1, Me.ToolStripMenuItem2, Me.ToolStripMenuItem3})
        Me.newToolStripMenuItem.Image = CType(resources.GetObject("newToolStripMenuItem.Image"), Image)
        Me.newToolStripMenuItem.ImageTransparentColor = Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.newToolStripMenuItem.Name = "newToolStripMenuItem"
        Me.newToolStripMenuItem.ShortcutKeys = CType((Keys.Control Or Keys.N), Keys)
        Me.newToolStripMenuItem.Size = New Size(291, 44)
        Me.newToolStripMenuItem.Text = "&New"
        Me.newToolStripMenuItem.TextImageRelation = TextImageRelation.ImageAboveText
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New Size(364, 44)
        Me.ToolStripMenuItem1.Text = "ToolStripMenuItem1"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New Size(364, 44)
        Me.ToolStripMenuItem2.Text = "ToolStripMenuItem2"
        '
        'ToolStripMenuItem3
        '
        Me.ToolStripMenuItem3.Name = "ToolStripMenuItem3"
        Me.ToolStripMenuItem3.Size = New Size(364, 44)
        Me.ToolStripMenuItem3.Text = "ToolStripMenuItem3"
        '
        'openToolStripMenuItem
        '
        Me.openToolStripMenuItem.Image = CType(resources.GetObject("openToolStripMenuItem.Image"), Image)
        Me.openToolStripMenuItem.ImageTransparentColor = Color.Lavender
        Me.openToolStripMenuItem.Name = "openToolStripMenuItem"
        Me.openToolStripMenuItem.ShortcutKeys = CType((Keys.Control Or Keys.O), Keys)
        Me.openToolStripMenuItem.Size = New Size(291, 44)
        Me.openToolStripMenuItem.Text = "&Open"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        Me.toolStripSeparator.Size = New Size(288, 6)
        '
        'saveToolStripMenuItem
        '
        Me.saveToolStripMenuItem.Image = CType(resources.GetObject("saveToolStripMenuItem.Image"), Image)
        Me.saveToolStripMenuItem.ImageTransparentColor = Color.Lime
        Me.saveToolStripMenuItem.Name = "saveToolStripMenuItem"
        Me.saveToolStripMenuItem.ShortcutKeys = CType((Keys.Control Or Keys.S), Keys)
        Me.saveToolStripMenuItem.Size = New Size(291, 44)
        Me.saveToolStripMenuItem.Text = "&Save"
        '
        'saveAsToolStripMenuItem
        '
        Me.saveAsToolStripMenuItem.Image = CType(resources.GetObject("saveAsToolStripMenuItem.Image"), Image)
        Me.saveAsToolStripMenuItem.ImageTransparentColor = Color.Lime
        Me.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem"
        Me.saveAsToolStripMenuItem.Size = New Size(291, 44)
        Me.saveAsToolStripMenuItem.Text = "Save &As"
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        Me.toolStripSeparator1.Size = New Size(288, 6)
        '
        'printToolStripMenuItem
        '
        Me.printToolStripMenuItem.Image = CType(resources.GetObject("printToolStripMenuItem.Image"), Image)
        Me.printToolStripMenuItem.ImageTransparentColor = Color.Lime
        Me.printToolStripMenuItem.Name = "printToolStripMenuItem"
        Me.printToolStripMenuItem.ShortcutKeys = CType((Keys.Control Or Keys.P), Keys)
        Me.printToolStripMenuItem.Size = New Size(291, 44)
        Me.printToolStripMenuItem.Text = "&Print"
        '
        'printPreviewToolStripMenuItem
        '
        Me.printPreviewToolStripMenuItem.Image = CType(resources.GetObject("printPreviewToolStripMenuItem.Image"), Image)
        Me.printPreviewToolStripMenuItem.ImageTransparentColor = Color.Lime
        Me.printPreviewToolStripMenuItem.Name = "printPreviewToolStripMenuItem"
        Me.printPreviewToolStripMenuItem.Size = New Size(291, 44)
        Me.printPreviewToolStripMenuItem.Text = "Print Pre&view"
        '
        'toolStripSeparator2
        '
        Me.toolStripSeparator2.Name = "toolStripSeparator2"
        Me.toolStripSeparator2.Size = New Size(288, 6)
        '
        'exitToolStripMenuItem
        '
        Me.exitToolStripMenuItem.Name = "exitToolStripMenuItem"
        Me.exitToolStripMenuItem.Size = New Size(291, 44)
        Me.exitToolStripMenuItem.Text = "E&xit"
        '
        'editToolStripMenuItem
        '
        Me.editToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {Me.undoToolStripMenuItem, Me.redoToolStripMenuItem, Me.toolStripSeparator3, Me.cutToolStripMenuItem, Me.copyToolStripMenuItem, Me.pasteToolStripMenuItem, Me.toolStripSeparator4, Me.selectAllToolStripMenuItem})
        Me.editToolStripMenuItem.Name = "editToolStripMenuItem"
        Me.editToolStripMenuItem.Size = New Size(74, 36)
        Me.editToolStripMenuItem.Text = "&Edit"
        '
        'undoToolStripMenuItem
        '
        Me.undoToolStripMenuItem.Name = "undoToolStripMenuItem"
        Me.undoToolStripMenuItem.ShortcutKeys = CType((Keys.Control Or Keys.Z), Keys)
        Me.undoToolStripMenuItem.Size = New Size(286, 44)
        Me.undoToolStripMenuItem.Text = "&Undo"
        '
        'redoToolStripMenuItem
        '
        Me.redoToolStripMenuItem.Name = "redoToolStripMenuItem"
        Me.redoToolStripMenuItem.ShortcutKeys = CType((Keys.Control Or Keys.Y), Keys)
        Me.redoToolStripMenuItem.Size = New Size(286, 44)
        Me.redoToolStripMenuItem.Text = "&Redo"
        '
        'toolStripSeparator3
        '
        Me.toolStripSeparator3.Name = "toolStripSeparator3"
        Me.toolStripSeparator3.Size = New Size(283, 6)
        '
        'cutToolStripMenuItem
        '
        Me.cutToolStripMenuItem.Image = CType(resources.GetObject("cutToolStripMenuItem.Image"), Image)
        Me.cutToolStripMenuItem.ImageTransparentColor = Color.Lime
        Me.cutToolStripMenuItem.Name = "cutToolStripMenuItem"
        Me.cutToolStripMenuItem.ShortcutKeys = CType((Keys.Control Or Keys.X), Keys)
        Me.cutToolStripMenuItem.Size = New Size(286, 44)
        Me.cutToolStripMenuItem.Text = "Cu&t"
        '
        'copyToolStripMenuItem
        '
        Me.copyToolStripMenuItem.Image = CType(resources.GetObject("copyToolStripMenuItem.Image"), Image)
        Me.copyToolStripMenuItem.ImageTransparentColor = Color.Lime
        Me.copyToolStripMenuItem.Name = "copyToolStripMenuItem"
        Me.copyToolStripMenuItem.ShortcutKeys = CType((Keys.Control Or Keys.C), Keys)
        Me.copyToolStripMenuItem.Size = New Size(286, 44)
        Me.copyToolStripMenuItem.Text = "&Copy"
        '
        'pasteToolStripMenuItem
        '
        Me.pasteToolStripMenuItem.Image = CType(resources.GetObject("pasteToolStripMenuItem.Image"), Image)
        Me.pasteToolStripMenuItem.ImageTransparentColor = Color.Lime
        Me.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem"
        Me.pasteToolStripMenuItem.ShortcutKeys = CType((Keys.Control Or Keys.V), Keys)
        Me.pasteToolStripMenuItem.Size = New Size(286, 44)
        Me.pasteToolStripMenuItem.Text = "&Paste"
        '
        'toolStripSeparator4
        '
        Me.toolStripSeparator4.Name = "toolStripSeparator4"
        Me.toolStripSeparator4.Size = New Size(283, 6)
        '
        'selectAllToolStripMenuItem
        '
        Me.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem"
        Me.selectAllToolStripMenuItem.Size = New Size(286, 44)
        Me.selectAllToolStripMenuItem.Text = "Select &All"
        '
        'toolsToolStripMenuItem
        '
        Me.toolsToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {Me.customizeToolStripMenuItem, Me.optionsToolStripMenuItem})
        Me.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem"
        Me.toolsToolStripMenuItem.Size = New Size(89, 36)
        Me.toolsToolStripMenuItem.Text = "&Tools"
        '
        'customizeToolStripMenuItem
        '
        Me.customizeToolStripMenuItem.Name = "customizeToolStripMenuItem"
        Me.customizeToolStripMenuItem.Size = New Size(259, 44)
        Me.customizeToolStripMenuItem.Text = "&Customize"
        '
        'optionsToolStripMenuItem
        '
        Me.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem"
        Me.optionsToolStripMenuItem.Size = New Size(259, 44)
        Me.optionsToolStripMenuItem.Text = "&Options"
        '
        'helpToolStripMenuItem
        '
        Me.helpToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {Me.contentsToolStripMenuItem, Me.indexToolStripMenuItem, Me.searchToolStripMenuItem, Me.toolStripSeparator5, Me.aboutToolStripMenuItem})
        Me.helpToolStripMenuItem.Name = "helpToolStripMenuItem"
        Me.helpToolStripMenuItem.Size = New Size(84, 36)
        Me.helpToolStripMenuItem.Text = "&Help"
        '
        'contentsToolStripMenuItem
        '
        Me.contentsToolStripMenuItem.Name = "contentsToolStripMenuItem"
        Me.contentsToolStripMenuItem.Size = New Size(243, 44)
        Me.contentsToolStripMenuItem.Text = "&Contents"
        '
        'indexToolStripMenuItem
        '
        Me.indexToolStripMenuItem.Name = "indexToolStripMenuItem"
        Me.indexToolStripMenuItem.Size = New Size(243, 44)
        Me.indexToolStripMenuItem.Text = "&Index"
        '
        'searchToolStripMenuItem
        '
        Me.searchToolStripMenuItem.Name = "searchToolStripMenuItem"
        Me.searchToolStripMenuItem.Size = New Size(243, 44)
        Me.searchToolStripMenuItem.Text = "&Search"
        '
        'toolStripSeparator5
        '
        Me.toolStripSeparator5.Name = "toolStripSeparator5"
        Me.toolStripSeparator5.Size = New Size(240, 6)
        '
        'aboutToolStripMenuItem
        '
        Me.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem"
        Me.aboutToolStripMenuItem.Size = New Size(243, 44)
        Me.aboutToolStripMenuItem.Text = "&About..."
        '
        'Button1
        '
        Me.Button1.Location = New Point(216, 364)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New Size(180, 57)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "Button1"
        '
        'topToolStripPanel
        '
        Me.topToolStripPanel.Controls.Add(Me.MenuStrip1)
        Me.topToolStripPanel.Controls.Add(Me.ToolStrip1)
        Me.topToolStripPanel.Dock = DockStyle.Top
        Me.topToolStripPanel.Location = New Point(0, 0)
        Me.topToolStripPanel.Name = "topToolStripPanel"
        Me.topToolStripPanel.Orientation = Orientation.Horizontal
        Me.topToolStripPanel.RenderMode = ToolStripRenderMode.System
        Me.topToolStripPanel.RowMargin = New Padding(6, 0, 0, 0)
        Me.topToolStripPanel.Size = New Size(1362, 80)
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Dock = DockStyle.None
        Me.ToolStrip1.ImageScalingSize = New Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New ToolStripItem() {Me.B1ToolStripButton, Me.B2ToolStripButton, Me.LabelToolStripLabel, Me.SBToolStripSplitButton, Me.DDBToolStripDropDownButton, Me.ComboToolStripComboBox, Me.TextBoxToolStripTextBox, Me.PbToolStripProgressBar})
        Me.ToolStrip1.Location = New Point(6, 38)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New Size(768, 42)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'B1ToolStripButton
        '
        Me.B1ToolStripButton.Name = "B1ToolStripButton"
        Me.B1ToolStripButton.Size = New Size(46, 36)
        Me.B1ToolStripButton.Text = "B1"
        '
        'B2ToolStripButton
        '
        Me.B2ToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image
        Me.B2ToolStripButton.Image = CType(resources.GetObject("B2ToolStripButton.Image"), Image)
        Me.B2ToolStripButton.Name = "B2ToolStripButton"
        Me.B2ToolStripButton.Size = New Size(46, 36)
        Me.B2ToolStripButton.Text = "Calc"
        '
        'LabelToolStripLabel
        '
        Me.LabelToolStripLabel.Name = "LabelToolStripLabel"
        Me.LabelToolStripLabel.Size = New Size(70, 36)
        Me.LabelToolStripLabel.Text = "Label"
        '
        'SBToolStripSplitButton
        '
        Me.SBToolStripSplitButton.DropDownItems.AddRange(New ToolStripItem() {Me.X1ToolStripMenuItem})
        Me.SBToolStripSplitButton.Name = "SBToolStripSplitButton"
        Me.SBToolStripSplitButton.Size = New Size(68, 36)
        Me.SBToolStripSplitButton.Text = "SB"
        '
        'X1ToolStripMenuItem
        '
        Me.X1ToolStripMenuItem.Name = "X1ToolStripMenuItem"
        Me.X1ToolStripMenuItem.Size = New Size(174, 44)
        Me.X1ToolStripMenuItem.Text = "X1"
        '
        'DDBToolStripDropDownButton
        '
        Me.DDBToolStripDropDownButton.DropDownItems.AddRange(New ToolStripItem() {Me.X2ToolStripMenuItem})
        Me.DDBToolStripDropDownButton.Name = "DDBToolStripDropDownButton"
        Me.DDBToolStripDropDownButton.Size = New Size(84, 36)
        Me.DDBToolStripDropDownButton.Text = "DDB"
        '
        'X2ToolStripMenuItem
        '
        Me.X2ToolStripMenuItem.Name = "X2ToolStripMenuItem"
        Me.X2ToolStripMenuItem.Size = New Size(174, 44)
        Me.X2ToolStripMenuItem.Text = "X2"
        '
        'ComboToolStripComboBox
        '
        Me.ComboToolStripComboBox.Items.AddRange(New Object() {"Un", "Deux", "Trois", "Quatre", "Un", "Deux", "Trois", "Quatre"})
        Me.ComboToolStripComboBox.Name = "ComboToolStripComboBox"
        Me.ComboToolStripComboBox.Size = New Size(220, 42)
        Me.ComboToolStripComboBox.Text = "Combo"
        '
        'TextBoxToolStripTextBox
        '
        Me.TextBoxToolStripTextBox.Name = "TextBoxToolStripTextBox"
        Me.TextBoxToolStripTextBox.Size = New Size(100, 42)
        Me.TextBoxToolStripTextBox.Text = "TextBox"
        '
        'PbToolStripProgressBar
        '
        Me.PbToolStripProgressBar.Name = "PbToolStripProgressBar"
        Me.PbToolStripProgressBar.Size = New Size(100, 36)
        Me.PbToolStripProgressBar.Step = 5
        Me.PbToolStripProgressBar.Value = 25
        '
        'bottomToolStripPanel
        '
        Me.bottomToolStripPanel.Dock = DockStyle.Bottom
        Me.bottomToolStripPanel.Location = New Point(0, 634)
        Me.bottomToolStripPanel.Name = "bottomToolStripPanel"
        Me.bottomToolStripPanel.Orientation = Orientation.Horizontal
        Me.bottomToolStripPanel.RowMargin = New Padding(6, 0, 0, 0)
        Me.bottomToolStripPanel.Size = New Size(1362, 0)
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New Size(12, 32)
        Me.ClientSize = New Size(1362, 634)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.topToolStripPanel)
        Me.Controls.Add(Me.bottomToolStripPanel)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.topToolStripPanel.ResumeLayout(False)
        Me.topToolStripPanel.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents fileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents newToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents openToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents toolStripSeparator As ToolStripSeparator
    Friend WithEvents saveToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents saveAsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents toolStripSeparator1 As ToolStripSeparator
    Friend WithEvents printToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents printPreviewToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents toolStripSeparator2 As ToolStripSeparator
    Friend WithEvents exitToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents editToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents undoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents redoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents toolStripSeparator3 As ToolStripSeparator
    Friend WithEvents cutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents copyToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents pasteToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents toolStripSeparator4 As ToolStripSeparator
    Friend WithEvents selectAllToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents toolsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents customizeToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents optionsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents helpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents contentsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents indexToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents searchToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents toolStripSeparator5 As ToolStripSeparator
    Friend WithEvents aboutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Button1 As Button
    Friend WithEvents topToolStripPanel As ToolStripPanel
    Friend WithEvents bottomToolStripPanel As ToolStripPanel
    Friend WithEvents ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem3 As ToolStripMenuItem
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents B1ToolStripButton As ToolStripButton
    Friend WithEvents LabelToolStripLabel As ToolStripLabel
    Friend WithEvents SBToolStripSplitButton As ToolStripSplitButton
    Friend WithEvents X1ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DDBToolStripDropDownButton As ToolStripDropDownButton
    Friend WithEvents X2ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ComboToolStripComboBox As ToolStripComboBox
    Friend WithEvents TextBoxToolStripTextBox As ToolStripTextBox
    Friend WithEvents PbToolStripProgressBar As ToolStripProgressBar
    Friend WithEvents B2ToolStripButton As ToolStripButton

End Class
