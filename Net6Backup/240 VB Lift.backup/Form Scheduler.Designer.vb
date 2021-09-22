<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmScheduler
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
        Me.lbTrace = New System.Windows.Forms.ListBox
        Me.btnStart = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'lbTrace
        '
        Me.lbTrace.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbTrace.FormattingEnabled = True
        Me.lbTrace.Location = New System.Drawing.Point(12, 41)
        Me.lbTrace.Name = "lbTrace"
        Me.lbTrace.Size = New System.Drawing.Size(411, 316)
        Me.lbTrace.TabIndex = 0
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(12, 12)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(75, 23)
        Me.btnStart.TabIndex = 1
        Me.btnStart.Text = "Start"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'frmScheduler
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(435, 366)
        Me.Controls.Add(Me.btnStart)
        Me.Controls.Add(Me.lbTrace)
        Me.Name = "frmScheduler"
        Me.Text = "Scheduler"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lbTrace As System.Windows.Forms.ListBox
    Friend WithEvents btnStart As System.Windows.Forms.Button

End Class
