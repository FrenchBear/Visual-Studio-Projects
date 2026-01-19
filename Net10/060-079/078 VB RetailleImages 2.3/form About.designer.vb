Imports System.ComponentModel
Imports Microsoft.VisualBasic.CompilerServices

<DesignerGenerated()>
Partial Class AboutForm
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
        Dim resources As ComponentResourceManager = New ComponentResourceManager(GetType(AboutForm))
        Me.BuildLabel = New Label
        Me.CopyrightLabel = New Label
        Me.TitleLabel = New Label
        Me.PictureBox1 = New PictureBox
        Me.btnOk = New Button
        CType(Me.PictureBox1, ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblBuild
        '
        Me.BuildLabel.AutoSize = True
        Me.BuildLabel.BackColor = SystemColors.Control
        Me.BuildLabel.Cursor = Cursors.Default
        Me.BuildLabel.Font = New Font("Tahoma", 8.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        Me.BuildLabel.ForeColor = SystemColors.ControlText
        Me.BuildLabel.Location = New Point(62, 69)
        Me.BuildLabel.Name = "lblBuild"
        Me.BuildLabel.RightToLeft = RightToLeft.No
        Me.BuildLabel.Size = New Size(29, 13)
        Me.BuildLabel.TabIndex = 6
        Me.BuildLabel.Text = "Build"
        '
        'lblCopyright
        '
        Me.CopyrightLabel.AutoSize = True
        Me.CopyrightLabel.BackColor = SystemColors.Control
        Me.CopyrightLabel.Cursor = Cursors.Default
        Me.CopyrightLabel.Font = New Font("Tahoma", 8.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        Me.CopyrightLabel.ForeColor = SystemColors.ControlText
        Me.CopyrightLabel.Location = New Point(62, 46)
        Me.CopyrightLabel.Name = "lblCopyright"
        Me.CopyrightLabel.RightToLeft = RightToLeft.No
        Me.CopyrightLabel.Size = New Size(54, 13)
        Me.CopyrightLabel.TabIndex = 5
        Me.CopyrightLabel.Text = "Copyright"
        '
        'lblTitle
        '
        Me.TitleLabel.BackColor = SystemColors.Control
        Me.TitleLabel.Cursor = Cursors.Default
        Me.TitleLabel.Font = New Font("Tahoma", 8.25!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
        Me.TitleLabel.ForeColor = SystemColors.ControlText
        Me.TitleLabel.Location = New Point(62, 12)
        Me.TitleLabel.Name = "lblTitle"
        Me.TitleLabel.RightToLeft = RightToLeft.No
        Me.TitleLabel.Size = New Size(354, 32)
        Me.TitleLabel.TabIndex = 4
        Me.TitleLabel.Text = "Title"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        Me.PictureBox1.Location = New Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New Size(32, 32)
        Me.PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 7
        Me.PictureBox1.TabStop = False
        '
        'btnOk
        '
        Me.btnOk.DialogResult = DialogResult.OK
        Me.btnOk.Font = New Font("Tahoma", 8.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.Location = New Point(176, 98)
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
        Me.ClientSize = New Size(428, 130)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.BuildLabel)
        Me.Controls.Add(Me.CopyrightLabel)
        Me.Controls.Add(Me.TitleLabel)
        Me.Font = New Font("Tahoma", 8.25!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAbout"
        Me.ShowIcon = False
        Me.Text = "A propos de RetailleImages..."
        CType(Me.PictureBox1, ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents BuildLabel As Label
    Public WithEvents CopyrightLabel As Label
    Public WithEvents TitleLabel As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents btnOk As Button
End Class
