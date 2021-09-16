<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmControl
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
        Me.paFloorButtons = New System.Windows.Forms.Panel
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.paCarButtons = New System.Windows.Forms.Panel
        Me.SuspendLayout()
        '
        'paFloorButtons
        '
        Me.paFloorButtons.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.paFloorButtons.AutoScroll = True
        Me.paFloorButtons.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.paFloorButtons.Location = New System.Drawing.Point(12, 35)
        Me.paFloorButtons.Name = "paFloorButtons"
        Me.paFloorButtons.Size = New System.Drawing.Size(172, 606)
        Me.paFloorButtons.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Floor Controls"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(190, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(28, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Cars"
        '
        'paCarButtons
        '
        Me.paCarButtons.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.paCarButtons.AutoScroll = True
        Me.paCarButtons.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.paCarButtons.Location = New System.Drawing.Point(190, 35)
        Me.paCarButtons.Name = "paCarButtons"
        Me.paCarButtons.Size = New System.Drawing.Size(332, 606)
        Me.paCarButtons.TabIndex = 2
        '
        'frmControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(531, 653)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.paCarButtons)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.paFloorButtons)
        Me.Name = "frmControl"
        Me.Text = "Floor and Car Controls"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents paFloorButtons As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents paCarButtons As System.Windows.Forms.Panel
End Class
