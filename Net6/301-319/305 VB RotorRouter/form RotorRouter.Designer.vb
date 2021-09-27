<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmRotorRouter
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.btnStart = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.pic = New System.Windows.Forms.PictureBox
        Me.txtIterations = New System.Windows.Forms.TextBox
        Me.Panel1.SuspendLayout()
        CType(Me.pic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(12, 13)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(75, 23)
        Me.btnStart.TabIndex = 1
        Me.btnStart.Text = "&Start"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.AutoScroll = True
        Me.Panel1.Controls.Add(Me.pic)
        Me.Panel1.Location = New System.Drawing.Point(12, 42)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(477, 429)
        Me.Panel1.TabIndex = 2
        '
        'pic
        '
        Me.pic.Location = New System.Drawing.Point(3, 3)
        Me.pic.Name = "pic"
        Me.pic.Size = New System.Drawing.Size(336, 323)
        Me.pic.TabIndex = 1
        Me.pic.TabStop = False
        '
        'txtIterations
        '
        Me.txtIterations.Location = New System.Drawing.Point(104, 13)
        Me.txtIterations.Name = "txtIterations"
        Me.txtIterations.Size = New System.Drawing.Size(142, 20)
        Me.txtIterations.TabIndex = 3
        '
        'frmRotorRouter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(501, 483)
        Me.Controls.Add(Me.txtIterations)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnStart)
        Me.Name = "frmRotorRouter"
        Me.Text = "RotorRouter"
        Me.Panel1.ResumeLayout(False)
        CType(Me.pic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnStart As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pic As System.Windows.Forms.PictureBox
    Friend WithEvents txtIterations As System.Windows.Forms.TextBox

End Class
