<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SchedulerForm
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
        Me.TraceLabel = New System.Windows.Forms.ListBox
        Me.StartButton = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'lbTrace
        '
        Me.TraceLabel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TraceLabel.FormattingEnabled = True
        Me.TraceLabel.Location = New System.Drawing.Point(12, 41)
        Me.TraceLabel.Name = "lbTrace"
        Me.TraceLabel.Size = New System.Drawing.Size(411, 316)
        Me.TraceLabel.TabIndex = 0
        '
        'btnStart
        '
        Me.StartButton.Location = New System.Drawing.Point(12, 12)
        Me.StartButton.Name = "btnStart"
        Me.StartButton.Size = New System.Drawing.Size(75, 23)
        Me.StartButton.TabIndex = 1
        Me.StartButton.Text = "Start"
        Me.StartButton.UseVisualStyleBackColor = True
        '
        'SchedulerForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(435, 366)
        Me.Controls.Add(Me.StartButton)
        Me.Controls.Add(Me.TraceLabel)
        Me.Name = "SchedulerForm"
        Me.Text = "Scheduler"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TraceLabel As System.Windows.Forms.ListBox
    Friend WithEvents StartButton As System.Windows.Forms.Button

End Class
