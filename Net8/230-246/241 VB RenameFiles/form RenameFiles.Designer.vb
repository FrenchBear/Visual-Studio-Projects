Imports System.ComponentModel
Imports Microsoft.VisualBasic.CompilerServices

<DesignerGenerated()>
Partial Class frmRenameFiles
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
        Dim resources As ComponentResourceManager = New ComponentResourceManager(GetType(frmRenameFiles))
        Me.txtFolder = New TextBox
        Me.lblFolder = New Label
        Me.FolderBrowserDialog1 = New FolderBrowserDialog
        Me.btnSelectFolder = New Button
        Me.gbTypeOfRename = New GroupBox
        Me.optRegEx = New RadioButton
        Me.optStringReplace = New RadioButton
        Me.txtSearch = New TextBox
        Me.Label1 = New Label
        Me.txtReplace = New TextBox
        Me.Label2 = New Label
        Me.btnPreview = New Button
        Me.btnRename = New Button
        Me.lvPreview = New ListView
        Me.chBefore = New ColumnHeader
        Me.chAction = New ColumnHeader
        Me.chAfter = New ColumnHeader
        Me.txtLike = New TextBox
        Me.Label3 = New Label
        Me.StatusStrip1 = New StatusStrip
        Me.ToolStripProgressBar1 = New ToolStripProgressBar
        Me.tsslText = New ToolStripStatusLabel
        Me.chkIncludeSubfolders = New CheckBox
        Me.chkCaseSignificant = New CheckBox
        Me.gbTypeOfRename.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtFolder
        '
        Me.txtFolder.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Left) _
                    Or AnchorStyles.Right), AnchorStyles)
        Me.txtFolder.Location = New Point(98, 12)
        Me.txtFolder.Name = "txtFolder"
        Me.txtFolder.Size = New Size(362, 20)
        Me.txtFolder.TabIndex = 1
        '
        'lblFolder
        '
        Me.lblFolder.AutoSize = True
        Me.lblFolder.Location = New Point(9, 15)
        Me.lblFolder.Name = "lblFolder"
        Me.lblFolder.Size = New Size(39, 13)
        Me.lblFolder.TabIndex = 0
        Me.lblFolder.Text = "Fol&der:"
        '
        'btnSelectFolder
        '
        Me.btnSelectFolder.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles)
        Me.btnSelectFolder.Location = New Point(466, 12)
        Me.btnSelectFolder.Name = "btnSelectFolder"
        Me.btnSelectFolder.Size = New Size(27, 21)
        Me.btnSelectFolder.TabIndex = 2
        Me.btnSelectFolder.Text = "..."
        Me.btnSelectFolder.UseVisualStyleBackColor = True
        '
        'gbTypeOfRename
        '
        Me.gbTypeOfRename.Controls.Add(Me.optRegEx)
        Me.gbTypeOfRename.Controls.Add(Me.optStringReplace)
        Me.gbTypeOfRename.Location = New Point(12, 66)
        Me.gbTypeOfRename.Name = "gbTypeOfRename"
        Me.gbTypeOfRename.Size = New Size(200, 57)
        Me.gbTypeOfRename.TabIndex = 5
        Me.gbTypeOfRename.TabStop = False
        Me.gbTypeOfRename.Text = "Type of rename"
        '
        'optRegEx
        '
        Me.optRegEx.AutoSize = True
        Me.optRegEx.Location = New Point(6, 33)
        Me.optRegEx.Name = "optRegEx"
        Me.optRegEx.Size = New Size(115, 17)
        Me.optRegEx.TabIndex = 1
        Me.optRegEx.Text = "Regular e&xpression"
        Me.optRegEx.UseVisualStyleBackColor = True
        '
        'optStringReplace
        '
        Me.optStringReplace.AutoSize = True
        Me.optStringReplace.Checked = True
        Me.optStringReplace.Location = New Point(6, 16)
        Me.optStringReplace.Name = "optStringReplace"
        Me.optStringReplace.Size = New Size(122, 17)
        Me.optStringReplace.TabIndex = 0
        Me.optStringReplace.TabStop = True
        Me.optStringReplace.Text = "Si&mple string replace"
        Me.optStringReplace.UseVisualStyleBackColor = True
        '
        'txtSearch
        '
        Me.txtSearch.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Left) _
                    Or AnchorStyles.Right), AnchorStyles)
        Me.txtSearch.Location = New Point(98, 129)
        Me.txtSearch.Name = "txtSearch"
        Me.txtSearch.Size = New Size(395, 20)
        Me.txtSearch.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New Point(9, 132)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New Size(44, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "&Search:"
        '
        'txtReplace
        '
        Me.txtReplace.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Left) _
                    Or AnchorStyles.Right), AnchorStyles)
        Me.txtReplace.Location = New Point(98, 155)
        Me.txtReplace.Name = "txtReplace"
        Me.txtReplace.Size = New Size(395, 20)
        Me.txtReplace.TabIndex = 11
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New Point(9, 158)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New Size(50, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "&Replace:"
        '
        'btnPreview
        '
        Me.btnPreview.Location = New Point(12, 188)
        Me.btnPreview.Name = "btnPreview"
        Me.btnPreview.Size = New Size(75, 23)
        Me.btnPreview.TabIndex = 12
        Me.btnPreview.Text = "&Preview"
        Me.btnPreview.UseVisualStyleBackColor = True
        '
        'btnRename
        '
        Me.btnRename.Location = New Point(98, 188)
        Me.btnRename.Name = "btnRename"
        Me.btnRename.Size = New Size(75, 23)
        Me.btnRename.TabIndex = 13
        Me.btnRename.Text = "Re&name"
        Me.btnRename.UseVisualStyleBackColor = True
        '
        'lvPreview
        '
        Me.lvPreview.Anchor = CType((((AnchorStyles.Top Or AnchorStyles.Bottom) _
                    Or AnchorStyles.Left) _
                    Or AnchorStyles.Right), AnchorStyles)
        Me.lvPreview.CheckBoxes = True
        Me.lvPreview.Columns.AddRange(New ColumnHeader() {Me.chBefore, Me.chAction, Me.chAfter})
        Me.lvPreview.FullRowSelect = True
        Me.lvPreview.GridLines = True
        Me.lvPreview.HideSelection = False
        Me.lvPreview.Location = New Point(12, 217)
        Me.lvPreview.MultiSelect = False
        Me.lvPreview.Name = "lvPreview"
        Me.lvPreview.Size = New Size(481, 182)
        Me.lvPreview.TabIndex = 14
        Me.lvPreview.UseCompatibleStateImageBehavior = False
        Me.lvPreview.View = View.Details
        '
        'chBefore
        '
        Me.chBefore.Text = "File name"
        Me.chBefore.Width = 175
        '
        'chAction
        '
        Me.chAction.Text = "Action"
        Me.chAction.Width = 69
        '
        'chAfter
        '
        Me.chAfter.Text = "Renamed"
        Me.chAfter.Width = 182
        '
        'txtLike
        '
        Me.txtLike.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Left) _
                    Or AnchorStyles.Right), AnchorStyles)
        Me.txtLike.Location = New Point(98, 38)
        Me.txtLike.Name = "txtLike"
        Me.txtLike.Size = New Size(362, 20)
        Me.txtLike.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New Point(9, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New Size(50, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Files li&ke:"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New ToolStripItem() {Me.ToolStripProgressBar1, Me.tsslText})
        Me.StatusStrip1.Location = New Point(0, 402)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New Size(505, 22)
        Me.StatusStrip1.TabIndex = 15
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripProgressBar1
        '
        Me.ToolStripProgressBar1.Name = "ToolStripProgressBar1"
        Me.ToolStripProgressBar1.Size = New Size(100, 16)
        Me.ToolStripProgressBar1.Style = ProgressBarStyle.Continuous
        Me.ToolStripProgressBar1.Visible = False
        '
        'tsslText
        '
        Me.tsslText.Name = "tsslText"
        Me.tsslText.Size = New Size(0, 17)
        '
        'chkIncludeSubfolders
        '
        Me.chkIncludeSubfolders.AutoSize = True
        Me.chkIncludeSubfolders.Location = New Point(230, 82)
        Me.chkIncludeSubfolders.Name = "chkIncludeSubfolders"
        Me.chkIncludeSubfolders.Size = New Size(112, 17)
        Me.chkIncludeSubfolders.TabIndex = 6
        Me.chkIncludeSubfolders.Text = "&Include subfolders"
        Me.chkIncludeSubfolders.UseVisualStyleBackColor = True
        '
        'chkCaseSignificant
        '
        Me.chkCaseSignificant.AutoSize = True
        Me.chkCaseSignificant.Location = New Point(230, 99)
        Me.chkCaseSignificant.Name = "chkCaseSignificant"
        Me.chkCaseSignificant.Size = New Size(182, 17)
        Me.chkCaseSignificant.TabIndex = 7
        Me.chkCaseSignificant.Text = "&Case significant Search/Replace"
        Me.chkCaseSignificant.UseVisualStyleBackColor = True
        '
        'frmRenameFiles
        '
        Me.AutoScaleDimensions = New SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.ClientSize = New Size(505, 424)
        Me.Controls.Add(Me.chkCaseSignificant)
        Me.Controls.Add(Me.chkIncludeSubfolders)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.txtLike)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.lvPreview)
        Me.Controls.Add(Me.btnRename)
        Me.Controls.Add(Me.btnPreview)
        Me.Controls.Add(Me.txtReplace)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtSearch)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.gbTypeOfRename)
        Me.Controls.Add(Me.btnSelectFolder)
        Me.Controls.Add(Me.txtFolder)
        Me.Controls.Add(Me.lblFolder)
        Me.Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Me.Name = "frmRenameFiles"
        Me.Text = "Rename Files"
        Me.gbTypeOfRename.ResumeLayout(False)
        Me.gbTypeOfRename.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtFolder As TextBox
    Friend WithEvents lblFolder As Label
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents btnSelectFolder As Button
    Friend WithEvents gbTypeOfRename As GroupBox
    Friend WithEvents optRegEx As RadioButton
    Friend WithEvents optStringReplace As RadioButton
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents txtReplace As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnPreview As Button
    Friend WithEvents btnRename As Button
    Friend WithEvents lvPreview As ListView
    Friend WithEvents chBefore As ColumnHeader
    Friend WithEvents chAction As ColumnHeader
    Friend WithEvents chAfter As ColumnHeader
    Friend WithEvents txtLike As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripProgressBar1 As ToolStripProgressBar
    Friend WithEvents chkIncludeSubfolders As CheckBox
    Friend WithEvents chkCaseSignificant As CheckBox
    Friend WithEvents tsslText As ToolStripStatusLabel

End Class
