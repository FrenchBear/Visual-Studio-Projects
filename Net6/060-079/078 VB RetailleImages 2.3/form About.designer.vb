<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AboutForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AboutForm))
        Me.BuildLabel = New System.Windows.Forms.Label
        Me.CopyrightLabel = New System.Windows.Forms.Label
        Me.TitleLabel = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.btnOk = New System.Windows.Forms.Button
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblBuild
        '
        Me.BuildLabel.AutoSize = True
        Me.BuildLabel.BackColor = System.Drawing.SystemColors.Control
        Me.BuildLabel.Cursor = System.Windows.Forms.Cursors.Default
        Me.BuildLabel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BuildLabel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.BuildLabel.Location = New System.Drawing.Point(62, 69)
        Me.BuildLabel.Name = "lblBuild"
        Me.BuildLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.BuildLabel.Size = New System.Drawing.Size(29, 13)
        Me.BuildLabel.TabIndex = 6
        Me.BuildLabel.Text = "Build"
        '
        'lblCopyright
        '
        Me.CopyrightLabel.AutoSize = True
        Me.CopyrightLabel.BackColor = System.Drawing.SystemColors.Control
        Me.CopyrightLabel.Cursor = System.Windows.Forms.Cursors.Default
        Me.CopyrightLabel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CopyrightLabel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CopyrightLabel.Location = New System.Drawing.Point(62, 46)
        Me.CopyrightLabel.Name = "lblCopyright"
        Me.CopyrightLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CopyrightLabel.Size = New System.Drawing.Size(54, 13)
        Me.CopyrightLabel.TabIndex = 5
        Me.CopyrightLabel.Text = "Copyright"
        '
        'lblTitle
        '
        Me.TitleLabel.BackColor = System.Drawing.SystemColors.Control
        Me.TitleLabel.Cursor = System.Windows.Forms.Cursors.Default
        Me.TitleLabel.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TitleLabel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.TitleLabel.Location = New System.Drawing.Point(62, 12)
        Me.TitleLabel.Name = "lblTitle"
        Me.TitleLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TitleLabel.Size = New System.Drawing.Size(354, 32)
        Me.TitleLabel.TabIndex = 4
        Me.TitleLabel.Text = "Title"
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(12, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 7
        Me.PictureBox1.TabStop = False
        '
        'btnOk
        '
        Me.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOk.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOk.Location = New System.Drawing.Point(176, 98)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(75, 23)
        Me.btnOk.TabIndex = 8
        Me.btnOk.Text = "Ok"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'frmAbout
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnOk
        Me.ClientSize = New System.Drawing.Size(428, 130)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.BuildLabel)
        Me.Controls.Add(Me.CopyrightLabel)
        Me.Controls.Add(Me.TitleLabel)
        Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAbout"
        Me.ShowIcon = False
        Me.Text = "A propos de RetailleImages..."
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents BuildLabel As System.Windows.Forms.Label
    Public WithEvents CopyrightLabel As System.Windows.Forms.Label
    Public WithEvents TitleLabel As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btnOk As System.Windows.Forms.Button
End Class
