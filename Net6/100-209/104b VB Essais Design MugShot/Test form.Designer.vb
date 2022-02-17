Imports System.ComponentModel
Imports Microsoft.VisualBasic.CompilerServices

<DesignerGenerated()>
Partial Class frmTest
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
        Me.components = New Container()
        Me.gbNewDocuments = New GroupBox()
        Me.btnAdd = New Button()
        Me.btnAttach = New Button()
        Me.btnDelete = New Button()
        Me.lvNewDocuments = New ListView()
        Me.ColumnHeader1 = New ColumnHeader()
        Me.ColumnHeader2 = New ColumnHeader()
        Me.ColumnHeader3 = New ColumnHeader()
        Me.ToolTip1 = New ToolTip(Me.components)
        Me.tlpLeft = New TableLayoutPanel()
        Me.gbELIMSSelection = New GroupBox()
        Me.OpenFileDialog1 = New OpenFileDialog()
        Me.scMain = New SplitContainer()
        Me.myPDFEditor = New PDFEditor()
        Me.myTextEditor = New TextEditor()
        Me.myImageEditor = New ImageEditor()
        Me.gbNewDocuments.SuspendLayout()
        Me.tlpLeft.SuspendLayout()
        CType(Me.scMain, ISupportInitialize).BeginInit()
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
        Me.gbNewDocuments.Dock = DockStyle.Fill
        Me.gbNewDocuments.Location = New Point(3, 407)
        Me.gbNewDocuments.Name = "gbNewDocuments"
        Me.gbNewDocuments.Size = New Size(286, 199)
        Me.gbNewDocuments.TabIndex = 5
        Me.gbNewDocuments.TabStop = False
        Me.gbNewDocuments.Text = "New Documents"
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Left), AnchorStyles)
        Me.btnAdd.Location = New Point(6, 170)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New Size(75, 23)
        Me.btnAdd.TabIndex = 5
        Me.btnAdd.Text = "Add"
        Me.ToolTip1.SetToolTip(Me.btnAdd, "Adds manually an existing document to this list")
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnAttach
        '
        Me.btnAttach.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Right), AnchorStyles)
        Me.btnAttach.Location = New Point(124, 170)
        Me.btnAttach.Name = "btnAttach"
        Me.btnAttach.Size = New Size(75, 23)
        Me.btnAttach.TabIndex = 4
        Me.btnAttach.Text = "Attach"
        Me.btnAttach.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Right), AnchorStyles)
        Me.btnDelete.Location = New Point(205, 170)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New Size(75, 23)
        Me.btnDelete.TabIndex = 3
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'lvNewDocuments
        '
        Me.lvNewDocuments.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Left) _
            Or AnchorStyles.Right), AnchorStyles)
        Me.lvNewDocuments.Columns.AddRange(New ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.lvNewDocuments.FullRowSelect = True
        Me.lvNewDocuments.GridLines = True
        Me.lvNewDocuments.Location = New Point(7, 21)
        Me.lvNewDocuments.Name = "lvNewDocuments"
        Me.lvNewDocuments.Size = New Size(273, 138)
        Me.lvNewDocuments.TabIndex = 0
        Me.lvNewDocuments.UseCompatibleStateImageBehavior = False
        Me.lvNewDocuments.View = View.Details
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
        Me.tlpLeft.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 100.0!))
        Me.tlpLeft.Controls.Add(Me.gbELIMSSelection, 0, 0)
        Me.tlpLeft.Controls.Add(Me.gbNewDocuments, 0, 2)
        Me.tlpLeft.Dock = DockStyle.Fill
        Me.tlpLeft.Location = New Point(0, 0)
        Me.tlpLeft.Name = "tlpLeft"
        Me.tlpLeft.RowCount = 3
        Me.tlpLeft.RowStyles.Add(New RowStyle(SizeType.Percent, 33.33333!))
        Me.tlpLeft.RowStyles.Add(New RowStyle(SizeType.Percent, 33.33333!))
        Me.tlpLeft.RowStyles.Add(New RowStyle(SizeType.Percent, 33.33333!))
        Me.tlpLeft.Size = New Size(292, 609)
        Me.tlpLeft.TabIndex = 8
        '
        'gbELIMSSelection
        '
        Me.gbELIMSSelection.Dock = DockStyle.Fill
        Me.gbELIMSSelection.Location = New Point(3, 3)
        Me.gbELIMSSelection.Name = "gbELIMSSelection"
        Me.gbELIMSSelection.Size = New Size(286, 196)
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
        Me.scMain.BackColor = Color.DarkGray
        Me.scMain.Dock = DockStyle.Fill
        Me.scMain.ForeColor = SystemColors.ControlText
        Me.scMain.Location = New Point(0, 0)
        Me.scMain.Name = "scMain"
        '
        'scMain.Panel1
        '
        Me.scMain.Panel1.BackColor = SystemColors.Control
        Me.scMain.Panel1.Controls.Add(Me.tlpLeft)
        '
        'scMain.Panel2
        '
        Me.scMain.Panel2.BackColor = SystemColors.Control
        Me.scMain.Panel2.Controls.Add(Me.myPDFEditor)
        Me.scMain.Panel2.Controls.Add(Me.myTextEditor)
        Me.scMain.Panel2.Controls.Add(Me.myImageEditor)
        Me.scMain.Size = New Size(861, 609)
        Me.scMain.SplitterDistance = 292
        Me.scMain.TabIndex = 9
        '
        'myPDFEditor
        '
        Me.myPDFEditor.BackColor = SystemColors.Control
        Me.myPDFEditor.Font = New Font("Tahoma", 8.25!, FontStyle.Regular, GraphicsUnit.Point)
        Me.myPDFEditor.Location = New Point(180, 320)
        Me.myPDFEditor.Name = "myPDFEditor"
        Me.myPDFEditor.Size = New Size(232, 170)
        Me.myPDFEditor.TabIndex = 0
        Me.myPDFEditor.Visible = False
        '
        'myTextEditor
        '
        Me.myTextEditor.Font = New Font("Tahoma", 8.25!, FontStyle.Regular, GraphicsUnit.Point)
        Me.myTextEditor.Location = New Point(31, 204)
        Me.myTextEditor.Name = "myTextEditor"
        Me.myTextEditor.Size = New Size(220, 171)
        Me.myTextEditor.TabIndex = 0
        Me.myTextEditor.Visible = False
        '
        'myImageEditor
        '
        Me.myImageEditor.Font = New Font("Tahoma", 8.25!, FontStyle.Regular, GraphicsUnit.Point)
        Me.myImageEditor.Location = New Point(108, 12)
        Me.myImageEditor.Name = "myImageEditor"
        Me.myImageEditor.Size = New Size(193, 135)
        Me.myImageEditor.TabIndex = 0
        Me.myImageEditor.Visible = False
        '
        'frmTest
        '
        Me.AutoScaleDimensions = New SizeF(12.0!, 27.0!)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.ClientSize = New Size(861, 609)
        Me.Controls.Add(Me.scMain)
        Me.Font = New Font("Tahoma", 8.25!, FontStyle.Regular, GraphicsUnit.Point)
        Me.Name = "frmTest"
        Me.Text = "MugShot Design Test"
        Me.gbNewDocuments.ResumeLayout(False)
        Me.tlpLeft.ResumeLayout(False)
        Me.scMain.Panel1.ResumeLayout(False)
        Me.scMain.Panel2.ResumeLayout(False)
        CType(Me.scMain, ISupportInitialize).EndInit()
        Me.scMain.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gbNewDocuments As GroupBox
    Friend WithEvents btnAttach As Button
    Friend WithEvents btnDelete As Button
    Friend WithEvents lvNewDocuments As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents myImageEditor As ImageEditor
    Friend WithEvents myTextEditor As TextEditor
    Friend WithEvents myPDFEditor As PDFEditor
    Friend WithEvents btnAdd As Button
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents tlpLeft As TableLayoutPanel
    Friend WithEvents gbELIMSSelection As GroupBox
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents scMain As SplitContainer
End Class
