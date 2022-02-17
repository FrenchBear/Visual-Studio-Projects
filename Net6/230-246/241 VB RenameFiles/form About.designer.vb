Imports System.ComponentModel
Imports Microsoft.VisualBasic.CompilerServices

<DesignerGenerated()>
Partial Class frmAbout
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
        Dim resources As ComponentResourceManager = New ComponentResourceManager(GetType(frmAbout))
        Me.lblBuild = New Label
        Me.lblCopyright = New Label
        Me.lblTitle = New Label
        Me.PictureBox1 = New PictureBox
        Me.btnOk = New Button
        CType(Me.PictureBox1, ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblBuild
        '
        Me.lblBuild.AutoSize = True
        Me.lblBuild.BackColor = SystemColors.Control
        Me.lblBuild.Cursor = Cursors.Default
        Me.lblBuild.Font = New Font("Tahoma", 8.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        Me.lblBuild.ForeColor = SystemColors.ControlText
        Me.lblBuild.Location = New Point(62, 54)
        Me.lblBuild.Name = "lblBuild"
        Me.lblBuild.RightToLeft = RightToLeft.No
        Me.lblBuild.Size = New Size(29, 13)
        Me.lblBuild.TabIndex = 6
        Me.lblBuild.Text = "Build"
        '
        'lblCopyright
        '
        Me.lblCopyright.AutoSize = True
        Me.lblCopyright.BackColor = SystemColors.Control
        Me.lblCopyright.Cursor = Cursors.Default
        Me.lblCopyright.Font = New Font("Tahoma", 8.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        Me.lblCopyright.ForeColor = SystemColors.ControlText
        Me.lblCopyright.Location = New Point(62, 31)
        Me.lblCopyright.Name = "lblCopyright"
        Me.lblCopyright.RightToLeft = RightToLeft.No
        Me.lblCopyright.Size = New Size(54, 13)
        Me.lblCopyright.TabIndex = 5
        Me.lblCopyright.Text = "Copyright"
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.BackColor = SystemColors.Control
        Me.lblTitle.Cursor = Cursors.Default
        Me.lblTitle.Font = New Font("Tahoma", 8.25!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = SystemColors.ControlText
        Me.lblTitle.Location = New Point(62, 12)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.RightToLeft = RightToLeft.No
        Me.lblTitle.Size = New Size(32, 13)
        Me.lblTitle.TabIndex = 4
        Me.lblTitle.Text = "Title"
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = BorderStyle.FixedSingle
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        Me.PictureBox1.Location = New Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New Size(34, 34)
        Me.PictureBox1.SizeMode = PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 7
        Me.PictureBox1.TabStop = False
        '
        'btnOk
        '
        Me.btnOk.DialogResult = DialogResult.OK
        Me.btnOk.Font = New Font("Tahoma", 8.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.Location = New Point(187, 83)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New Size(75, 23)
        Me.btnOk.TabIndex = 8
        Me.btnOk.Text = "Ok"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'frmAbout
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleDimensions = New SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.CancelButton = Me.btnOk
        Me.ClientSize = New Size(467, 118)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.lblBuild)
        Me.Controls.Add(Me.lblCopyright)
        Me.Controls.Add(Me.lblTitle)
        Me.Font = New Font("Tahoma", 8.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAbout"
        Me.ShowIcon = False
        Me.Text = "About RenameFiles"
        CType(Me.PictureBox1, ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents lblBuild As Label
    Public WithEvents lblCopyright As Label
    Public WithEvents lblTitle As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents btnOk As Button
End Class
