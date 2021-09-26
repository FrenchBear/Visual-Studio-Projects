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
        Me.UpButton = New System.Windows.Forms.Button
        Me.DownButton = New System.Windows.Forms.Button
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
        Me.UpButton.BackColor = System.Drawing.SystemColors.Control
        Me.UpButton.Font = New System.Drawing.Font("Wingdings", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.UpButton.Location = New System.Drawing.Point(4, 16)
        Me.UpButton.Name = "btnUp"
        Me.UpButton.Size = New System.Drawing.Size(35, 33)
        Me.UpButton.TabIndex = 1
        Me.UpButton.Text = "é"
        Me.UpButton.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.UpButton.UseVisualStyleBackColor = False
        '
        'btnDown
        '
        Me.DownButton.BackColor = System.Drawing.SystemColors.Control
        Me.DownButton.Font = New System.Drawing.Font("Wingdings", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(2, Byte))
        Me.DownButton.Location = New System.Drawing.Point(45, 16)
        Me.DownButton.Name = "btnDown"
        Me.DownButton.Size = New System.Drawing.Size(35, 33)
        Me.DownButton.TabIndex = 2
        Me.DownButton.Text = "ê"
        Me.DownButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.DownButton.UseVisualStyleBackColor = False
        '
        'ucFloorButtons
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.DownButton)
        Me.Controls.Add(Me.UpButton)
        Me.Controls.Add(Me.lblFloorLabel)
        Me.Name = "ucFloorButtons"
        Me.Size = New System.Drawing.Size(84, 55)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblFloorLabel As System.Windows.Forms.Label
    Friend WithEvents UpButton As System.Windows.Forms.Button
    Friend WithEvents DownButton As System.Windows.Forms.Button

End Class
