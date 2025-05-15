<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucFloorButtons
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.lblFloorLabel = New System.Windows.Forms.Label
        Me.btnUp = New System.Windows.Forms.Button
        Me.btnDown = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'lblFloorLabel
        '
        Me.lblFloorLabel.AutoSize = True
        Me.lblFloorLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFloorLabel.Location = New System.Drawing.Point(3, 1)
        Me.lblFloorLabel.Name = "lblFloorLabel"
        Me.lblFloorLabel.Size = New System.Drawing.Size(70, 13)
        Me.lblFloorLabel.TabIndex = 0
        Me.lblFloorLabel.Text = "Floor Label"
        '
        'btnUp
        '
        Me.btnUp.BackColor = System.Drawing.SystemColors.Control
        Me.btnUp.Font = New System.Drawing.Font("Wingdings", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.btnUp.Location = New System.Drawing.Point(4, 16)
        Me.btnUp.Name = "btnUp"
        Me.btnUp.Size = New System.Drawing.Size(35, 33)
        Me.btnUp.TabIndex = 1
        Me.btnUp.Text = "é"
        Me.btnUp.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnUp.UseVisualStyleBackColor = False
        '
        'btnDown
        '
        Me.btnDown.BackColor = System.Drawing.SystemColors.Control
        Me.btnDown.Font = New System.Drawing.Font("Wingdings", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.btnDown.Location = New System.Drawing.Point(45, 16)
        Me.btnDown.Name = "btnDown"
        Me.btnDown.Size = New System.Drawing.Size(35, 33)
        Me.btnDown.TabIndex = 2
        Me.btnDown.Text = "ê"
        Me.btnDown.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDown.UseVisualStyleBackColor = False
        '
        'ucFloorButtons
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.btnDown)
        Me.Controls.Add(Me.btnUp)
        Me.Controls.Add(Me.lblFloorLabel)
        Me.Name = "ucFloorButtons"
        Me.Size = New System.Drawing.Size(84, 55)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblFloorLabel As System.Windows.Forms.Label
    Friend WithEvents btnUp As System.Windows.Forms.Button
    Friend WithEvents btnDown As System.Windows.Forms.Button

End Class
