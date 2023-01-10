Imports System.ComponentModel
Imports System.Drawing.Printing
Imports Microsoft.VisualBasic.CompilerServices

<DesignerGenerated()>
Partial Class Form1
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
        Dim resources As ComponentResourceManager = New ComponentResourceManager(GetType(Form1))
        Me.PageSetupDialog1 = New PageSetupDialog
        Me.PrintDocument1 = New PrintDocument
        Me.PrintPreviewDialog1 = New PrintPreviewDialog
        Me.btnPreview = New Button
        Me.btnPageSetup = New Button
        Me.SuspendLayout()
        '
        'PrintDocument1
        '
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New Size(400, 300)
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = False
        '
        'btnPreview
        '
        Me.btnPreview.Location = New Point(205, 55)
        Me.btnPreview.Name = "btnPreview"
        Me.btnPreview.Size = New Size(75, 23)
        Me.btnPreview.TabIndex = 0
        Me.btnPreview.Text = "Preview"
        Me.btnPreview.UseVisualStyleBackColor = True
        '
        'btnPageSetup
        '
        Me.btnPageSetup.Location = New Point(205, 12)
        Me.btnPageSetup.Name = "btnPageSetup"
        Me.btnPageSetup.Size = New Size(75, 23)
        Me.btnPageSetup.TabIndex = 1
        Me.btnPageSetup.Text = "Page Setup"
        Me.btnPageSetup.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.ClientSize = New Size(292, 266)
        Me.Controls.Add(Me.btnPageSetup)
        Me.Controls.Add(Me.btnPreview)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PageSetupDialog1 As PageSetupDialog
    Friend WithEvents PrintDocument1 As PrintDocument
    Friend WithEvents PrintPreviewDialog1 As PrintPreviewDialog
    Friend WithEvents btnPreview As Button
    Friend WithEvents btnPageSetup As Button

End Class
