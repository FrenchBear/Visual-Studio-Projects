Imports System.ComponentModel
Imports Microsoft.VisualBasic.CompilerServices

<DesignerGenerated()>
Partial Class TestForm
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
        Me.GroupBox3 = New GroupBox()
        Me.Button5 = New Button()
        Me.Button6 = New Button()
        Me.Button7 = New Button()
        Me.Button9 = New Button()
        Me.lvNewDocuments = New ListView()
        Me.ColumnHeader1 = New ColumnHeader()
        Me.ColumnHeader2 = New ColumnHeader()
        Me.ColumnHeader3 = New ColumnHeader()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((((AnchorStyles.Top Or AnchorStyles.Bottom) _
            Or AnchorStyles.Left) _
            Or AnchorStyles.Right), AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.Button5)
        Me.GroupBox3.Controls.Add(Me.Button6)
        Me.GroupBox3.Controls.Add(Me.Button7)
        Me.GroupBox3.Controls.Add(Me.Button9)
        Me.GroupBox3.Controls.Add(Me.lvNewDocuments)
        Me.GroupBox3.Location = New Point(26, 29)
        Me.GroupBox3.Margin = New Padding(6, 8, 6, 8)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New Padding(6, 8, 6, 8)
        Me.GroupBox3.Size = New Size(888, 419)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "New Documents"
        '
        'Button5
        '
        Me.Button5.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Right), AnchorStyles)
        Me.Button5.Location = New Point(537, 347)
        Me.Button5.Margin = New Padding(6, 8, 6, 8)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New Size(162, 56)
        Me.Button5.TabIndex = 4
        Me.Button5.Text = "Attach"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Right), AnchorStyles)
        Me.Button6.Location = New Point(713, 347)
        Me.Button6.Margin = New Padding(6, 8, 6, 8)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New Size(162, 56)
        Me.Button6.TabIndex = 3
        Me.Button6.Text = "Delete"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Left), AnchorStyles)
        Me.Button7.Location = New Point(188, 347)
        Me.Button7.Margin = New Padding(6, 8, 6, 8)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New Size(162, 56)
        Me.Button7.TabIndex = 2
        Me.Button7.Text = "Print"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button9
        '
        Me.Button9.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Left), AnchorStyles)
        Me.Button9.Location = New Point(13, 347)
        Me.Button9.Margin = New Padding(6, 8, 6, 8)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New Size(162, 56)
        Me.Button9.TabIndex = 1
        Me.Button9.Text = "Preview"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'lvNewDocuments
        '
        Me.lvNewDocuments.Anchor = CType((((AnchorStyles.Top Or AnchorStyles.Bottom) _
            Or AnchorStyles.Left) _
            Or AnchorStyles.Right), AnchorStyles)
        Me.lvNewDocuments.Columns.AddRange(New ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3})
        Me.lvNewDocuments.FullRowSelect = True
        Me.lvNewDocuments.GridLines = True
        Me.lvNewDocuments.Location = New Point(15, 51)
        Me.lvNewDocuments.Margin = New Padding(6, 8, 6, 8)
        Me.lvNewDocuments.Name = "lvNewDocuments"
        Me.lvNewDocuments.Size = New Size(856, 275)
        Me.lvNewDocuments.TabIndex = 0
        Me.lvNewDocuments.UseCompatibleStateImageBehavior = False
        Me.lvNewDocuments.View = View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Name"
        Me.ColumnHeader1.Width = 250
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Size"
        Me.ColumnHeader2.Width = 200
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Date+Time"
        Me.ColumnHeader3.Width = 250
        '
        'TestForm
        '
        Me.AutoScaleDimensions = New SizeF(13.0!, 32.0!)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.ClientSize = New Size(940, 477)
        Me.Controls.Add(Me.GroupBox3)
        Me.Margin = New Padding(6, 8, 6, 8)
        Me.Name = "TestForm"
        Me.Text = "Test_form"
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents Button5 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents Button9 As Button
    Friend WithEvents lvNewDocuments As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
End Class
