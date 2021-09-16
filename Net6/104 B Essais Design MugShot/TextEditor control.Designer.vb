<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TextEditor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TextEditor))
        Me.tsMain = New System.Windows.Forms.ToolStrip
        Me.tsbSave = New System.Windows.Forms.ToolStripButton
        Me.tsbRevertToSaved = New System.Windows.Forms.ToolStripButton
        Me.txtText = New System.Windows.Forms.TextBox
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.tsbPrint = New System.Windows.Forms.ToolStripButton
        Me.tsMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsMain
        '
        Me.tsMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbSave, Me.tsbRevertToSaved, Me.ToolStripSeparator1, Me.tsbPrint})
        Me.tsMain.Location = New System.Drawing.Point(0, 0)
        Me.tsMain.Name = "tsMain"
        Me.tsMain.Size = New System.Drawing.Size(462, 25)
        Me.tsMain.TabIndex = 1
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
        Me.tsbSave.ToolTipText = "Save Text"
        '
        'tsbRevertToSaved
        '
        Me.tsbRevertToSaved.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsbRevertToSaved.Image = CType(resources.GetObject("tsbRevertToSaved.Image"), System.Drawing.Image)
        Me.tsbRevertToSaved.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbRevertToSaved.Name = "tsbRevertToSaved"
        Me.tsbRevertToSaved.Size = New System.Drawing.Size(23, 22)
        Me.tsbRevertToSaved.Text = "Revert"
        Me.tsbRevertToSaved.ToolTipText = "Revert to saved text"
        '
        'txtText
        '
        Me.txtText.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtText.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtText.Location = New System.Drawing.Point(0, 25)
        Me.txtText.Multiline = True
        Me.txtText.Name = "txtText"
        Me.txtText.ScrollBars = System.Windows.Forms.ScrollBars.Both
        Me.txtText.Size = New System.Drawing.Size(462, 419)
        Me.txtText.TabIndex = 2
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
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
        'TextEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.txtText)
        Me.Controls.Add(Me.tsMain)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "TextEditor"
        Me.Size = New System.Drawing.Size(462, 444)
        Me.tsMain.ResumeLayout(False)
        Me.tsMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsMain As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbRevertToSaved As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtText As System.Windows.Forms.TextBox
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsbPrint As System.Windows.Forms.ToolStripButton

End Class
