<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.PageSetupDialog1 = New System.Windows.Forms.PageSetupDialog
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog
        Me.btnPreview = New System.Windows.Forms.Button
        Me.btnPageSetup = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'PrintDocument1
        '
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = False
        '
        'btnPreview
        '
        Me.btnPreview.Location = New System.Drawing.Point(205, 55)
        Me.btnPreview.Name = "btnPreview"
        Me.btnPreview.Size = New System.Drawing.Size(75, 23)
        Me.btnPreview.TabIndex = 0
        Me.btnPreview.Text = "Preview"
        Me.btnPreview.UseVisualStyleBackColor = True
        '
        'btnPageSetup
        '
        Me.btnPageSetup.Location = New System.Drawing.Point(205, 12)
        Me.btnPageSetup.Name = "btnPageSetup"
        Me.btnPageSetup.Size = New System.Drawing.Size(75, 23)
        Me.btnPageSetup.TabIndex = 1
        Me.btnPageSetup.Text = "Page Setup"
        Me.btnPageSetup.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.btnPageSetup)
        Me.Controls.Add(Me.btnPreview)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PageSetupDialog1 As System.Windows.Forms.PageSetupDialog
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents PrintPreviewDialog1 As System.Windows.Forms.PrintPreviewDialog
    Friend WithEvents btnPreview As System.Windows.Forms.Button
    Friend WithEvents btnPageSetup As System.Windows.Forms.Button

End Class
