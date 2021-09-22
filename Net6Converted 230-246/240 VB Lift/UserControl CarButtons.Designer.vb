<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ucCarButtons
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
        Me.lblCarPositionLabel = New System.Windows.Forms.Label
        Me.lblCarPosition = New System.Windows.Forms.Label
        Me.lblDoorStatus = New System.Windows.Forms.Label
        Me.lblDoorStatusLabel = New System.Windows.Forms.Label
        Me.lblCar = New System.Windows.Forms.Label
        Me.lblCarLabel = New System.Windows.Forms.Label
        Me.lblDirection = New System.Windows.Forms.Label
        Me.lblDirectionLabel = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'lblCarPositionLabel
        '
        Me.lblCarPositionLabel.AutoSize = True
        Me.lblCarPositionLabel.Location = New System.Drawing.Point(3, 13)
        Me.lblCarPositionLabel.Name = "lblCarPositionLabel"
        Me.lblCarPositionLabel.Size = New System.Drawing.Size(63, 13)
        Me.lblCarPositionLabel.TabIndex = 0
        Me.lblCarPositionLabel.Text = "Car Position"
        '
        'lblCarPosition
        '
        Me.lblCarPosition.AutoSize = True
        Me.lblCarPosition.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCarPosition.Location = New System.Drawing.Point(71, 13)
        Me.lblCarPosition.Name = "lblCarPosition"
        Me.lblCarPosition.Size = New System.Drawing.Size(46, 13)
        Me.lblCarPosition.TabIndex = 1
        Me.lblCarPosition.Text = "Floor 1"
        '
        'lblDoorStatus
        '
        Me.lblDoorStatus.AutoSize = True
        Me.lblDoorStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDoorStatus.Location = New System.Drawing.Point(72, 26)
        Me.lblDoorStatus.Name = "lblDoorStatus"
        Me.lblDoorStatus.Size = New System.Drawing.Size(37, 13)
        Me.lblDoorStatus.TabIndex = 3
        Me.lblDoorStatus.Text = "Open"
        '
        'lblDoorStatusLabel
        '
        Me.lblDoorStatusLabel.AutoSize = True
        Me.lblDoorStatusLabel.Location = New System.Drawing.Point(2, 26)
        Me.lblDoorStatusLabel.Name = "lblDoorStatusLabel"
        Me.lblDoorStatusLabel.Size = New System.Drawing.Size(63, 13)
        Me.lblDoorStatusLabel.TabIndex = 2
        Me.lblDoorStatusLabel.Text = "Door Status"
        '
        'lblCar
        '
        Me.lblCar.AutoSize = True
        Me.lblCar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCar.Location = New System.Drawing.Point(71, 0)
        Me.lblCar.Name = "lblCar"
        Me.lblCar.Size = New System.Drawing.Size(37, 13)
        Me.lblCar.TabIndex = 6
        Me.lblCar.Text = "Car 1"
        '
        'lblCarLabel
        '
        Me.lblCarLabel.AutoSize = True
        Me.lblCarLabel.Location = New System.Drawing.Point(3, 0)
        Me.lblCarLabel.Name = "lblCarLabel"
        Me.lblCarLabel.Size = New System.Drawing.Size(23, 13)
        Me.lblCarLabel.TabIndex = 5
        Me.lblCarLabel.Text = "Car"
        '
        'lblDirection
        '
        Me.lblDirection.AutoSize = True
        Me.lblDirection.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDirection.Location = New System.Drawing.Point(73, 39)
        Me.lblDirection.Name = "lblDirection"
        Me.lblDirection.Size = New System.Drawing.Size(11, 13)
        Me.lblDirection.TabIndex = 8
        Me.lblDirection.Text = "-"
        '
        'lblDirectionLabel
        '
        Me.lblDirectionLabel.AutoSize = True
        Me.lblDirectionLabel.Location = New System.Drawing.Point(2, 39)
        Me.lblDirectionLabel.Name = "lblDirectionLabel"
        Me.lblDirectionLabel.Size = New System.Drawing.Size(49, 13)
        Me.lblDirectionLabel.TabIndex = 7
        Me.lblDirectionLabel.Text = "Direction"
        '
        'ucCarButtons
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Controls.Add(Me.lblDirection)
        Me.Controls.Add(Me.lblDirectionLabel)
        Me.Controls.Add(Me.lblCar)
        Me.Controls.Add(Me.lblCarLabel)
        Me.Controls.Add(Me.lblDoorStatus)
        Me.Controls.Add(Me.lblDoorStatusLabel)
        Me.Controls.Add(Me.lblCarPosition)
        Me.Controls.Add(Me.lblCarPositionLabel)
        Me.Name = "ucCarButtons"
        Me.Size = New System.Drawing.Size(129, 341)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents lblCarPositionLabel As System.Windows.Forms.Label
    Private WithEvents lblCarPosition As System.Windows.Forms.Label
    Private WithEvents lblDoorStatus As System.Windows.Forms.Label
    Private WithEvents lblDoorStatusLabel As System.Windows.Forms.Label
    Private WithEvents lblCar As System.Windows.Forms.Label
    Private WithEvents lblCarLabel As System.Windows.Forms.Label
    Private WithEvents lblDirection As System.Windows.Forms.Label
    Private WithEvents lblDirectionLabel As System.Windows.Forms.Label

End Class
