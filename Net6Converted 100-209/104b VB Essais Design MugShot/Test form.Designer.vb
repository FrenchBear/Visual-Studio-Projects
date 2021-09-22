<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmTest
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
        Me.components = New System.ComponentModel.Container()
        Me.gbNewDocuments = New System.Windows.Forms.GroupBox()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.btnAttach = New System.Windows.Forms.Button()
        Me.btnDelete = New System.Windows.Forms.Button()
        Me.lvNewDocuments = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = New System.Windows.Forms.ColumnHeader()
        Me.ColumnHeader2 = New System.Windows.Forms.ColumnHeader()
        Me.ColumnHeader3 = New System.Windows.Forms.ColumnHeader()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.tlpLeft = New System.Windows.Forms.TableLayoutPanel()
        Me.gbELIMSSelection = New System.Windows.Forms.GroupBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.scMain = New System.Windows.Forms.SplitContainer()
        Me.myPDFEditor = New MugShot.PDFEditor()
        Me.myTextEditor = New MugShot.TextEditor()
        Me.myImageEditor = New MugShot.ImageEditor()
        Me.gbNewDocuments.SuspendLayout()
        Me.tlpLeft.SuspendLayout()
        CType(Me.scMain, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.scMain.Panel1.SuspendLayout()
        Me.scMain.Panel2.SuspendLayout()
        Me.scMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbNewDocuments
        '
        Me.gbNewDocuments.Controls.Add(Me.btnAdd)
        Me.gbNewDocuments.Controls.Add(Me.btnAttach)
        Me.gbNewDocuments.Controls.Add(Me.btnDelete)
        Me.gbNewDocuments.Controls.Add(Me.lvNewDocuments)
        Me.gbNewDocuments.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbNewDocuments.Location = New System.Drawing.Point(3, 407)
        Me.gbNewDocuments.Name = "gbNewDocuments"
        Me.gbNewDocuments.Size = New System.Drawing.Size(286, 199)
        Me.gbNewDocuments.TabIndex = 5
        Me.gbNewDocuments.TabStop = False
        Me.gbNewDocuments.Text = "New Documents"
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.Location = New System.Drawing.Point(6, 170)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 23)
        Me.btnAdd.TabIndex = 5
        Me.btnAdd.Text = "Add"
        Me.ToolTip1.SetToolTip(Me.btnAdd, "Adds manually an existing document to this list")
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnAttach
        '
        Me.btnAttach.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAttach.Location = New System.Drawing.Point(124, 170)
        Me.btnAttach.Name = "btnAttach"
        Me.btnAttach.Size = New System.Drawing.Size(75, 23)
        Me.btnAttach.TabIndex = 4
        Me.btnAttach.Text = "Attach"
        Me.btnAttach.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDelete.Location = New System.Drawing.Point(205, 170)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 23)
        Me.btnDelete.TabIndex = 3
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'lvNewDocuments
        '
        Me.lvNewDocuments.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lvNewDocuments.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.lvNewDocuments.FullRowSelect = True
        Me.lvNewDocuments.GridLines = True
        Me.lvNewDocuments.Location = New System.Drawing.Point(7, 21)
        Me.lvNewDocuments.Name = "lvNewDocuments"
        Me.lvNewDocuments.Size = New System.Drawing.Size(273, 138)
        Me.lvNewDocuments.TabIndex = 0
        Me.lvNewDocuments.UseCompatibleStateImageBehavior = False
        Me.lvNewDocuments.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Name"
        Me.ColumnHeader1.Width = 135
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Size"
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Date"
        Me.ColumnHeader3.Width = 120
        '
        'tlpLeft
        '
        Me.tlpLeft.ColumnCount = 1
        Me.tlpLeft.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpLeft.Controls.Add(Me.gbELIMSSelection, 0, 0)
        Me.tlpLeft.Controls.Add(Me.gbNewDocuments, 0, 2)
        Me.tlpLeft.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpLeft.Location = New System.Drawing.Point(0, 0)
        Me.tlpLeft.Name = "tlpLeft"
        Me.tlpLeft.RowCount = 3
        Me.tlpLeft.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tlpLeft.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tlpLeft.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333!))
        Me.tlpLeft.Size = New System.Drawing.Size(292, 609)
        Me.tlpLeft.TabIndex = 8
        '
        'gbELIMSSelection
        '
        Me.gbELIMSSelection.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gbELIMSSelection.Location = New System.Drawing.Point(3, 3)
        Me.gbELIMSSelection.Name = "gbELIMSSelection"
        Me.gbELIMSSelection.Size = New System.Drawing.Size(286, 196)
        Me.gbELIMSSelection.TabIndex = 9
        Me.gbELIMSSelection.TabStop = False
        Me.gbELIMSSelection.Text = "Current eLIMS Selection"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'scMain
        '
        Me.scMain.BackColor = System.Drawing.Color.DarkGray
        Me.scMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.scMain.ForeColor = System.Drawing.SystemColors.ControlText
        Me.scMain.Location = New System.Drawing.Point(0, 0)
        Me.scMain.Name = "scMain"
        '
        'scMain.Panel1
        '
        Me.scMain.Panel1.BackColor = System.Drawing.SystemColors.Control
        Me.scMain.Panel1.Controls.Add(Me.tlpLeft)
        '
        'scMain.Panel2
        '
        Me.scMain.Panel2.BackColor = System.Drawing.SystemColors.Control
        Me.scMain.Panel2.Controls.Add(Me.myPDFEditor)
        Me.scMain.Panel2.Controls.Add(Me.myTextEditor)
        Me.scMain.Panel2.Controls.Add(Me.myImageEditor)
        Me.scMain.Size = New System.Drawing.Size(861, 609)
        Me.scMain.SplitterDistance = 292
        Me.scMain.TabIndex = 9
        '
        'myPDFEditor
        '
        Me.myPDFEditor.BackColor = System.Drawing.SystemColors.Control
        Me.myPDFEditor.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.myPDFEditor.Location = New System.Drawing.Point(180, 320)
        Me.myPDFEditor.Name = "myPDFEditor"
        Me.myPDFEditor.Size = New System.Drawing.Size(232, 170)
        Me.myPDFEditor.TabIndex = 0
        Me.myPDFEditor.Visible = False
        '
        'myTextEditor
        '
        Me.myTextEditor.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.myTextEditor.Location = New System.Drawing.Point(31, 204)
        Me.myTextEditor.Name = "myTextEditor"
        Me.myTextEditor.Size = New System.Drawing.Size(220, 171)
        Me.myTextEditor.TabIndex = 0
        Me.myTextEditor.Visible = False
        '
        'myImageEditor
        '
        Me.myImageEditor.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.myImageEditor.Location = New System.Drawing.Point(108, 12)
        Me.myImageEditor.Name = "myImageEditor"
        Me.myImageEditor.Size = New System.Drawing.Size(193, 135)
        Me.myImageEditor.TabIndex = 0
        Me.myImageEditor.Visible = False
        '
        'frmTest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 27.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(861, 609)
        Me.Controls.Add(Me.scMain)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point)
        Me.Name = "frmTest"
        Me.Text = "MugShot Design Test"
        Me.gbNewDocuments.ResumeLayout(False)
        Me.tlpLeft.ResumeLayout(False)
        Me.scMain.Panel1.ResumeLayout(False)
        Me.scMain.Panel2.ResumeLayout(False)
        CType(Me.scMain, System.ComponentModel.ISupportInitialize).EndInit()
        Me.scMain.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbNewDocuments As System.Windows.Forms.GroupBox
    Friend WithEvents btnAttach As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents lvNewDocuments As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents myImageEditor As ImageEditor
    Friend WithEvents myTextEditor As TextEditor
    Friend WithEvents myPDFEditor As PDFEditor
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents tlpLeft As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents gbELIMSSelection As System.Windows.Forms.GroupBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents scMain As System.Windows.Forms.SplitContainer
End Class
