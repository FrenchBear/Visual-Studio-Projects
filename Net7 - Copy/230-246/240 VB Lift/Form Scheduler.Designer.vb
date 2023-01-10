Imports System.ComponentModel
Imports Microsoft.VisualBasic.CompilerServices

<DesignerGenerated()>
Partial Class SchedulerForm
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
        Me.TraceLabel = New ListBox
        Me.StartButton = New Button
        Me.SuspendLayout()
        '
        'lbTrace
        '
        Me.TraceLabel.Anchor = CType((((AnchorStyles.Top Or AnchorStyles.Bottom) _
                    Or AnchorStyles.Left) _
                    Or AnchorStyles.Right), AnchorStyles)
        Me.TraceLabel.FormattingEnabled = True
        Me.TraceLabel.Location = New Point(12, 41)
        Me.TraceLabel.Name = "lbTrace"
        Me.TraceLabel.Size = New Size(411, 316)
        Me.TraceLabel.TabIndex = 0
        '
        'btnStart
        '
        Me.StartButton.Location = New Point(12, 12)
        Me.StartButton.Name = "btnStart"
        Me.StartButton.Size = New Size(75, 23)
        Me.StartButton.TabIndex = 1
        Me.StartButton.Text = "Start"
        Me.StartButton.UseVisualStyleBackColor = True
        '
        'SchedulerForm
        '
        Me.AutoScaleDimensions = New SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.ClientSize = New Size(435, 366)
        Me.Controls.Add(Me.StartButton)
        Me.Controls.Add(Me.TraceLabel)
        Me.Name = "SchedulerForm"
        Me.Text = "Scheduler"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TraceLabel As ListBox
    Friend WithEvents StartButton As Button

End Class
