Imports System.ComponentModel
Imports Microsoft.VisualBasic.CompilerServices

<DesignerGenerated()>
Partial Class TextEditor
    Inherits GenericEditor

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As ComponentResourceManager = New ComponentResourceManager(GetType(TextEditor))
        Me.tsMain = New ToolStrip
        Me.tsbSave = New ToolStripButton
        Me.tsbRevertToSaved = New ToolStripButton
        Me.txtText = New TextBox
        Me.ToolStripSeparator1 = New ToolStripSeparator
        Me.tsbPrint = New ToolStripButton
        Me.tsMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsMain
        '
        Me.tsMain.Items.AddRange(New ToolStripItem() {Me.tsbSave, Me.tsbRevertToSaved, Me.ToolStripSeparator1, Me.tsbPrint})
        Me.tsMain.Location = New Point(0, 0)
        Me.tsMain.Name = "tsMain"
        Me.tsMain.Size = New Size(462, 25)
        Me.tsMain.TabIndex = 1
        Me.tsMain.Text = "ToolStrip1"
        '
        'tsbSave
        '
        Me.tsbSave.DisplayStyle = ToolStripItemDisplayStyle.Image
        Me.tsbSave.Image = CType(resources.GetObject("tsbSave.Image"), Image)
        Me.tsbSave.ImageTransparentColor = Color.Magenta
        Me.tsbSave.Name = "tsbSave"
        Me.tsbSave.Size = New Size(23, 22)
        Me.tsbSave.Text = "Save"
        Me.tsbSave.ToolTipText = "Save Text"
        '
        'tsbRevertToSaved
        '
        Me.tsbRevertToSaved.DisplayStyle = ToolStripItemDisplayStyle.Image
        Me.tsbRevertToSaved.Image = CType(resources.GetObject("tsbRevertToSaved.Image"), Image)
        Me.tsbRevertToSaved.ImageTransparentColor = Color.Magenta
        Me.tsbRevertToSaved.Name = "tsbRevertToSaved"
        Me.tsbRevertToSaved.Size = New Size(23, 22)
        Me.tsbRevertToSaved.Text = "Revert"
        Me.tsbRevertToSaved.ToolTipText = "Revert to saved text"
        '
        'txtText
        '
        Me.txtText.Dock = DockStyle.Fill
        Me.txtText.Font = New Font("Tahoma", 9.75!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        Me.txtText.Location = New Point(0, 25)
        Me.txtText.Multiline = True
        Me.txtText.Name = "txtText"
        Me.txtText.ScrollBars = ScrollBars.Both
        Me.txtText.Size = New Size(462, 419)
        Me.txtText.TabIndex = 2
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New Size(6, 25)
        '
        'tsbPrint
        '
        Me.tsbPrint.DisplayStyle = ToolStripItemDisplayStyle.Image
        Me.tsbPrint.Image = CType(resources.GetObject("tsbPrint.Image"), Image)
        Me.tsbPrint.ImageTransparentColor = Color.Magenta
        Me.tsbPrint.Name = "tsbPrint"
        Me.tsbPrint.Size = New Size(23, 22)
        Me.tsbPrint.Text = "Print"
        '
        'TextEditor
        '
        Me.AutoScaleDimensions = New SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.Controls.Add(Me.txtText)
        Me.Controls.Add(Me.tsMain)
        Me.Font = New Font("Tahoma", 8.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "TextEditor"
        Me.Size = New Size(462, 444)
        Me.tsMain.ResumeLayout(False)
        Me.tsMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsMain As ToolStrip
    Friend WithEvents tsbSave As ToolStripButton
    Friend WithEvents tsbRevertToSaved As ToolStripButton
    Friend WithEvents txtText As TextBox
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents tsbPrint As ToolStripButton

End Class
