Imports System.ComponentModel
Imports VB218.My.Resources

Partial Public Class Form2
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
        Dim resources As ComponentResourceManager = New ComponentResourceManager(GetType(Form2))
        Me.MenuStrip1 = New MenuStrip
        Me.fileToolStripMenuItem = New ToolStripMenuItem
        Me.newToolStripMenuItem = New ToolStripMenuItem
        Me.openToolStripMenuItem = New ToolStripMenuItem
        Me.toolStripSeparator = New ToolStripSeparator
        Me.saveToolStripMenuItem = New ToolStripMenuItem
        Me.saveAsToolStripMenuItem = New ToolStripMenuItem
        Me.toolStripSeparator1 = New ToolStripSeparator
        Me.printToolStripMenuItem = New ToolStripMenuItem
        Me.printPreviewToolStripMenuItem = New ToolStripMenuItem
        Me.toolStripSeparator2 = New ToolStripSeparator
        Me.exitToolStripMenuItem = New ToolStripMenuItem
        Me.editToolStripMenuItem = New ToolStripMenuItem
        Me.undoToolStripMenuItem = New ToolStripMenuItem
        Me.redoToolStripMenuItem = New ToolStripMenuItem
        Me.toolStripSeparator3 = New ToolStripSeparator
        Me.cutToolStripMenuItem = New ToolStripMenuItem
        Me.copyToolStripMenuItem = New ToolStripMenuItem
        Me.pasteToolStripMenuItem = New ToolStripMenuItem
        Me.toolStripSeparator4 = New ToolStripSeparator
        Me.selectAllToolStripMenuItem = New ToolStripMenuItem
        Me.toolsToolStripMenuItem = New ToolStripMenuItem
        Me.customizeToolStripMenuItem = New ToolStripMenuItem
        Me.optionsToolStripMenuItem = New ToolStripMenuItem
        Me.helpToolStripMenuItem = New ToolStripMenuItem
        Me.contentsToolStripMenuItem = New ToolStripMenuItem
        Me.indexToolStripMenuItem = New ToolStripMenuItem
        Me.searchToolStripMenuItem = New ToolStripMenuItem
        Me.toolStripSeparator5 = New ToolStripSeparator
        Me.aboutToolStripMenuItem = New ToolStripMenuItem
        Me.leftToolStripPanel = New ToolStripPanel
        Me.rightToolStripPanel = New ToolStripPanel
        Me.topToolStripPanel = New ToolStripPanel
        Me.ToolStrip1 = New ToolStrip
        Me.B1ToolStripButton = New ToolStripButton
        Me.B2ToolStripButton = New ToolStripButton
        Me.LabelToolStripLabel = New ToolStripLabel
        Me.SBToolStripSplitButton = New ToolStripSplitButton
        Me.X1ToolStripMenuItem = New ToolStripMenuItem
        Me.DDBToolStripDropDownButton = New ToolStripDropDownButton
        Me.X2ToolStripMenuItem = New ToolStripMenuItem
        Me.ComboToolStripComboBox = New ToolStripComboBox
        Me.TextBoxToolStripTextBox = New ToolStripTextBox
        Me.PbToolStripProgressBar = New ToolStripProgressBar
        Me.bottomToolStripPanel = New ToolStripPanel
        Me.MenuStrip1.SuspendLayout()
        CType(Me.leftToolStripPanel, ISupportInitialize).BeginInit()
        CType(Me.rightToolStripPanel, ISupportInitialize).BeginInit()
        CType(Me.topToolStripPanel, ISupportInitialize).BeginInit()
        Me.topToolStripPanel.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.bottomToolStripPanel, ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New ToolStripItem() {Me.fileToolStripMenuItem, Me.editToolStripMenuItem, Me.toolsToolStripMenuItem, Me.helpToolStripMenuItem})
        Me.MenuStrip1.Location = New Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Padding = New Padding(6, 2, 0, 2)
        Me.MenuStrip1.Dock = DockStyle.Top

        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'fileToolStripMenuItem
        '
        Me.fileToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {Me.newToolStripMenuItem, Me.openToolStripMenuItem, Me.toolStripSeparator, Me.saveToolStripMenuItem, Me.saveAsToolStripMenuItem, Me.toolStripSeparator1, Me.printToolStripMenuItem, Me.printPreviewToolStripMenuItem, Me.toolStripSeparator2, Me.exitToolStripMenuItem})
        Me.fileToolStripMenuItem.Name = "fileToolStripMenuItem"
        Me.fileToolStripMenuItem.Text = "&File"
        '
        'newToolStripMenuItem
        '
        Me.newToolStripMenuItem.Image = CType(resources.GetObject("newToolStripMenuItem.Image"), Image)
        Me.newToolStripMenuItem.ImageTransparentColor = Color.Lime
        Me.newToolStripMenuItem.Name = "newToolStripMenuItem"
        Me.newToolStripMenuItem.Text = "&New"
        '
        'openToolStripMenuItem
        '
        Me.openToolStripMenuItem.Image = CType(resources.GetObject("openToolStripMenuItem.Image"), Image)
        Me.openToolStripMenuItem.ImageTransparentColor = Color.Lime
        Me.openToolStripMenuItem.Name = "openToolStripMenuItem"
        Me.openToolStripMenuItem.Text = "&Open"
        '
        'toolStripSeparator
        '
        Me.toolStripSeparator.Name = "toolStripSeparator"
        '
        'saveToolStripMenuItem
        '
        Me.saveToolStripMenuItem.Image = CType(resources.GetObject("saveToolStripMenuItem.Image"), Image)
        Me.saveToolStripMenuItem.ImageTransparentColor = Color.Lime
        Me.saveToolStripMenuItem.Name = "saveToolStripMenuItem"
        Me.saveToolStripMenuItem.Text = "&Save"
        '
        'saveAsToolStripMenuItem
        '
        Me.saveAsToolStripMenuItem.Image = CType(resources.GetObject("saveAsToolStripMenuItem.Image"), Image)
        Me.saveAsToolStripMenuItem.ImageTransparentColor = Color.Lime
        Me.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem"
        Me.saveAsToolStripMenuItem.Text = "Save &As"
        '
        'toolStripSeparator1
        '
        Me.toolStripSeparator1.Name = "toolStripSeparator1"
        '
        'printToolStripMenuItem
        '
        Me.printToolStripMenuItem.Image = CType(resources.GetObject("printToolStripMenuItem.Image"), Image)
        Me.printToolStripMenuItem.ImageTransparentColor = Color.Lime
        Me.printToolStripMenuItem.Name = "printToolStripMenuItem"
        Me.printToolStripMenuItem.Text = "&Print"
        '
        'printPreviewToolStripMenuItem
        '
        Me.printPreviewToolStripMenuItem.Image = CType(resources.GetObject("printPreviewToolStripMenuItem.Image"), Image)
        Me.printPreviewToolStripMenuItem.ImageTransparentColor = Color.Lime
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
        Me.editToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {Me.undoToolStripMenuItem, Me.redoToolStripMenuItem, Me.toolStripSeparator3, Me.cutToolStripMenuItem, Me.copyToolStripMenuItem, Me.pasteToolStripMenuItem, Me.toolStripSeparator4, Me.selectAllToolStripMenuItem})
        Me.editToolStripMenuItem.Name = "editToolStripMenuItem"
        Me.editToolStripMenuItem.Text = "&Edit"
        '
        'undoToolStripMenuItem
        '
        Me.undoToolStripMenuItem.Name = "undoToolStripMenuItem"
        Me.undoToolStripMenuItem.Text = "&Undo"
        '
        'redoToolStripMenuItem
        '
        Me.redoToolStripMenuItem.Name = "redoToolStripMenuItem"
        Me.redoToolStripMenuItem.Text = "&Redo"
        '
        'toolStripSeparator3
        '
        Me.toolStripSeparator3.Name = "toolStripSeparator3"
        '
        'cutToolStripMenuItem
        '
        Me.cutToolStripMenuItem.Image = CType(resources.GetObject("cutToolStripMenuItem.Image"), Image)
        Me.cutToolStripMenuItem.ImageTransparentColor = Color.Lime
        Me.cutToolStripMenuItem.Name = "cutToolStripMenuItem"
        Me.cutToolStripMenuItem.Text = "Cu&t"
        '
        'copyToolStripMenuItem
        '
        Me.copyToolStripMenuItem.Image = CType(resources.GetObject("copyToolStripMenuItem.Image"), Image)
        Me.copyToolStripMenuItem.ImageTransparentColor = Color.Lime
        Me.copyToolStripMenuItem.Name = "copyToolStripMenuItem"
        Me.copyToolStripMenuItem.Text = "&Copy"
        '
        'pasteToolStripMenuItem
        '
        Me.pasteToolStripMenuItem.Image = CType(resources.GetObject("pasteToolStripMenuItem.Image"), Image)
        Me.pasteToolStripMenuItem.ImageTransparentColor = Color.Lime
        Me.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem"
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
        Me.toolsToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {Me.customizeToolStripMenuItem, Me.optionsToolStripMenuItem})
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
        Me.helpToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {Me.contentsToolStripMenuItem, Me.indexToolStripMenuItem, Me.searchToolStripMenuItem, Me.toolStripSeparator5, Me.aboutToolStripMenuItem})
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
        Me.aboutToolStripMenuItem.Text = "&A propos de..."
        '
        'leftToolStripPanel
        '
        Me.leftToolStripPanel.Dock = DockStyle.Left
        Me.leftToolStripPanel.Name = "leftToolStripPanel"
        '
        'rightToolStripPanel
        '
        Me.rightToolStripPanel.Dock = DockStyle.Right
        Me.rightToolStripPanel.Name = "rightToolStripPanel"
        '
        'topToolStripPanel
        '
        Me.topToolStripPanel.Controls.Add(Me.MenuStrip1)
        Me.topToolStripPanel.Dock = DockStyle.Top
        Me.topToolStripPanel.Name = "topToolStripPanel"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New ToolStripItem() {Me.B1ToolStripButton, Me.B2ToolStripButton, Me.LabelToolStripLabel, Me.SBToolStripSplitButton, Me.DDBToolStripDropDownButton, Me.ComboToolStripComboBox, Me.TextBoxToolStripTextBox, Me.PbToolStripProgressBar})
        Me.ToolStrip1.Location = New Point(-7, 22)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'B1ToolStripButton
        '
        Me.B1ToolStripButton.Image = About
        Me.B1ToolStripButton.Name = "B1ToolStripButton"
        Me.B1ToolStripButton.Text = "B1"
        '
        'B2ToolStripButton
        '
        Me.B2ToolStripButton.DisplayStyle = ToolStripItemDisplayStyle.Image
        Me.B2ToolStripButton.Image = Calc
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
        Me.SBToolStripSplitButton.DropDownItems.AddRange(New ToolStripItem() {Me.X1ToolStripMenuItem})
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
        Me.DDBToolStripDropDownButton.DropDownItems.AddRange(New ToolStripItem() {Me.X2ToolStripMenuItem})
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
        Me.ComboToolStripComboBox.Size = New Size(101, 21)
        Me.ComboToolStripComboBox.Text = "Combo"
        '
        'TextBoxToolStripTextBox
        '
        Me.TextBoxToolStripTextBox.Name = "TextBoxToolStripTextBox"
        Me.TextBoxToolStripTextBox.Size = New Size(100, 19)
        Me.TextBoxToolStripTextBox.Text = "TextBox"
        '
        'PbToolStripProgressBar
        '
        Me.PbToolStripProgressBar.Name = "PbToolStripProgressBar"
        Me.PbToolStripProgressBar.Size = New Size(100, 21)
        Me.PbToolStripProgressBar.Step = 5
        Me.PbToolStripProgressBar.Text = "Pb"
        Me.PbToolStripProgressBar.Value = 25
        '
        'bottomToolStripPanel
        '
        Me.bottomToolStripPanel.Dock = DockStyle.Bottom
        Me.bottomToolStripPanel.Name = "bottomToolStripPanel"
        '
        'Form2
        '
        Me.AutoScaleBaseSize = New Size(5, 13)
        Me.ClientSize = New Size(292, 266)
        Me.Controls.Add(Me.leftToolStripPanel)
        Me.Controls.Add(Me.rightToolStripPanel)
        Me.Controls.Add(Me.topToolStripPanel)
        Me.Controls.Add(Me.bottomToolStripPanel)
        Me.Name = "Form2"
        Me.Text = "Form2"
        Me.MenuStrip1.ResumeLayout(False)
        CType(Me.leftToolStripPanel, ISupportInitialize).EndInit()
        CType(Me.rightToolStripPanel, ISupportInitialize).EndInit()
        CType(Me.topToolStripPanel, ISupportInitialize).EndInit()
        Me.topToolStripPanel.ResumeLayout(False)
        Me.topToolStripPanel.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        CType(Me.bottomToolStripPanel, ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents leftToolStripPanel As ToolStripPanel
    Friend WithEvents rightToolStripPanel As ToolStripPanel
    Friend WithEvents topToolStripPanel As ToolStripPanel
    Friend WithEvents bottomToolStripPanel As ToolStripPanel
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
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents B1ToolStripButton As ToolStripButton
    Friend WithEvents B2ToolStripButton As ToolStripButton
    Friend WithEvents LabelToolStripLabel As ToolStripLabel
    Friend WithEvents SBToolStripSplitButton As ToolStripSplitButton
    Friend WithEvents X1ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents DDBToolStripDropDownButton As ToolStripDropDownButton
    Friend WithEvents X2ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ComboToolStripComboBox As ToolStripComboBox
    Friend WithEvents TextBoxToolStripTextBox As ToolStripTextBox
    Friend WithEvents PbToolStripProgressBar As ToolStripProgressBar
End Class
