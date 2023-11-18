Imports System.ComponentModel
Imports Microsoft.VisualBasic.CompilerServices

<DesignerGenerated()>
Partial Class CarButtonsUserControl
    Inherits UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.lblCarPositionLabel = New Label
        Me.lblCarPosition = New Label
        Me.lblDoorStatus = New Label
        Me.lblDoorStatusLabel = New Label
        Me.lblCar = New Label
        Me.lblCarLabel = New Label
        Me.lblDirection = New Label
        Me.lblDirectionLabel = New Label
        Me.SuspendLayout()
        '
        'lblCarPositionLabel
        '
        Me.lblCarPositionLabel.AutoSize = True
        Me.lblCarPositionLabel.Location = New Point(3, 13)
        Me.lblCarPositionLabel.Name = "lblCarPositionLabel"
        Me.lblCarPositionLabel.Size = New Size(63, 13)
        Me.lblCarPositionLabel.TabIndex = 0
        Me.lblCarPositionLabel.Text = "Car Position"
        '
        'lblCarPosition
        '
        Me.lblCarPosition.AutoSize = True
        Me.lblCarPosition.Font = New Font("Microsoft Sans Serif", 8.25!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
        Me.lblCarPosition.Location = New Point(71, 13)
        Me.lblCarPosition.Name = "lblCarPosition"
        Me.lblCarPosition.Size = New Size(46, 13)
        Me.lblCarPosition.TabIndex = 1
        Me.lblCarPosition.Text = "Floor 1"
        '
        'lblDoorStatus
        '
        Me.lblDoorStatus.AutoSize = True
        Me.lblDoorStatus.Font = New Font("Microsoft Sans Serif", 8.25!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
        Me.lblDoorStatus.Location = New Point(72, 26)
        Me.lblDoorStatus.Name = "lblDoorStatus"
        Me.lblDoorStatus.Size = New Size(37, 13)
        Me.lblDoorStatus.TabIndex = 3
        Me.lblDoorStatus.Text = "Open"
        '
        'lblDoorStatusLabel
        '
        Me.lblDoorStatusLabel.AutoSize = True
        Me.lblDoorStatusLabel.Location = New Point(2, 26)
        Me.lblDoorStatusLabel.Name = "lblDoorStatusLabel"
        Me.lblDoorStatusLabel.Size = New Size(63, 13)
        Me.lblDoorStatusLabel.TabIndex = 2
        Me.lblDoorStatusLabel.Text = "Door Status"
        '
        'lblCar
        '
        Me.lblCar.AutoSize = True
        Me.lblCar.Font = New Font("Microsoft Sans Serif", 8.25!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
        Me.lblCar.Location = New Point(71, 0)
        Me.lblCar.Name = "lblCar"
        Me.lblCar.Size = New Size(37, 13)
        Me.lblCar.TabIndex = 6
        Me.lblCar.Text = "Car 1"
        '
        'lblCarLabel
        '
        Me.lblCarLabel.AutoSize = True
        Me.lblCarLabel.Location = New Point(3, 0)
        Me.lblCarLabel.Name = "lblCarLabel"
        Me.lblCarLabel.Size = New Size(23, 13)
        Me.lblCarLabel.TabIndex = 5
        Me.lblCarLabel.Text = "Car"
        '
        'lblDirection
        '
        Me.lblDirection.AutoSize = True
        Me.lblDirection.Font = New Font("Microsoft Sans Serif", 8.25!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
        Me.lblDirection.Location = New Point(73, 39)
        Me.lblDirection.Name = "lblDirection"
        Me.lblDirection.Size = New Size(11, 13)
        Me.lblDirection.TabIndex = 8
        Me.lblDirection.Text = "-"
        '
        'lblDirectionLabel
        '
        Me.lblDirectionLabel.AutoSize = True
        Me.lblDirectionLabel.Location = New Point(2, 39)
        Me.lblDirectionLabel.Name = "lblDirectionLabel"
        Me.lblDirectionLabel.Size = New Size(49, 13)
        Me.lblDirectionLabel.TabIndex = 7
        Me.lblDirectionLabel.Text = "Direction"
        '
        'ucCarButtons
        '
        Me.AutoScaleDimensions = New SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.BorderStyle = BorderStyle.FixedSingle
        Me.Controls.Add(Me.lblDirection)
        Me.Controls.Add(Me.lblDirectionLabel)
        Me.Controls.Add(Me.lblCar)
        Me.Controls.Add(Me.lblCarLabel)
        Me.Controls.Add(Me.lblDoorStatus)
        Me.Controls.Add(Me.lblDoorStatusLabel)
        Me.Controls.Add(Me.lblCarPosition)
        Me.Controls.Add(Me.lblCarPositionLabel)
        Me.Name = "ucCarButtons"
        Me.Size = New Size(129, 341)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents lblCarPositionLabel As Label
    Private WithEvents lblCarPosition As Label
    Private WithEvents lblDoorStatus As Label
    Private WithEvents lblDoorStatusLabel As Label
    Private WithEvents lblCar As Label
    Private WithEvents lblCarLabel As Label
    Private WithEvents lblDirection As Label
    Private WithEvents lblDirectionLabel As Label

End Class
