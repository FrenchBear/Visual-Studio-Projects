Imports System.ComponentModel
Imports Microsoft.VisualBasic.CompilerServices

<DesignerGenerated()>
Partial Class Form1
    Inherits Form

    'Form overrides dispose to clean up the component list.
    <DebuggerNonUserCode()>
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
    Private components As IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.StatusStrip1 = New StatusStrip
        Me.StatusStrip2 = New StatusStrip
        Me.StatusStrip3 = New StatusStrip
        Me.StatusStrip4 = New StatusStrip
        Me.SuspendLayout()
        '
        'StatusStrip1
        '
        Me.StatusStrip1.GripStyle = ToolStripGripStyle.Visible
        Me.StatusStrip1.Location = New Point(0, 451)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New Size(689, 22)
        Me.StatusStrip1.TabIndex = 0
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'StatusStrip2
        '
        Me.StatusStrip2.Location = New Point(0, 429)
        Me.StatusStrip2.Name = "StatusStrip2"
        Me.StatusStrip2.Size = New Size(689, 22)
        Me.StatusStrip2.TabIndex = 1
        Me.StatusStrip2.Text = "StatusStrip2"
        '
        'StatusStrip3
        '
        Me.StatusStrip3.Location = New Point(0, 407)
        Me.StatusStrip3.Name = "StatusStrip3"
        Me.StatusStrip3.Size = New Size(689, 22)
        Me.StatusStrip3.TabIndex = 2
        Me.StatusStrip3.Text = "StatusStrip3"
        '
        'StatusStrip4
        '
        Me.StatusStrip4.Location = New Point(0, 385)
        Me.StatusStrip4.Name = "StatusStrip4"
        Me.StatusStrip4.Size = New Size(689, 22)
        Me.StatusStrip4.TabIndex = 3
        Me.StatusStrip4.Text = "StatusStrip4"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.ClientSize = New Size(689, 473)
        Me.Controls.Add(Me.StatusStrip4)
        Me.Controls.Add(Me.StatusStrip3)
        Me.Controls.Add(Me.StatusStrip2)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents StatusStrip2 As StatusStrip
    Friend WithEvents StatusStrip3 As StatusStrip
    Friend WithEvents StatusStrip4 As StatusStrip

End Class
