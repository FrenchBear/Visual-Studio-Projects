Imports System.ComponentModel
Imports Microsoft.VisualBasic.CompilerServices

<DesignerGenerated()>
Partial Class frmRotorRouter
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
        Me.btnStart = New Button
        Me.Panel1 = New Panel
        Me.pic = New PictureBox
        Me.txtIterations = New TextBox
        Me.Panel1.SuspendLayout()
        CType(Me.pic, ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnStart
        '
        Me.btnStart.Location = New Point(12, 13)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New Size(75, 23)
        Me.btnStart.TabIndex = 1
        Me.btnStart.Text = "&Start"
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((AnchorStyles.Top Or AnchorStyles.Bottom) _
                    Or AnchorStyles.Left) _
                    Or AnchorStyles.Right), AnchorStyles)
        Me.Panel1.AutoScroll = True
        Me.Panel1.Controls.Add(Me.pic)
        Me.Panel1.Location = New Point(12, 42)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New Size(477, 429)
        Me.Panel1.TabIndex = 2
        '
        'pic
        '
        Me.pic.Location = New Point(3, 3)
        Me.pic.Name = "pic"
        Me.pic.Size = New Size(336, 323)
        Me.pic.TabIndex = 1
        Me.pic.TabStop = False
        '
        'txtIterations
        '
        Me.txtIterations.Location = New Point(104, 13)
        Me.txtIterations.Name = "txtIterations"
        Me.txtIterations.Size = New Size(142, 20)
        Me.txtIterations.TabIndex = 3
        '
        'frmRotorRouter
        '
        Me.AutoScaleDimensions = New SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.ClientSize = New Size(501, 483)
        Me.Controls.Add(Me.txtIterations)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnStart)
        Me.Name = "frmRotorRouter"
        Me.Text = "RotorRouter"
        Me.Panel1.ResumeLayout(False)
        CType(Me.pic, ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnStart As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents pic As PictureBox
    Friend WithEvents txtIterations As TextBox

End Class
