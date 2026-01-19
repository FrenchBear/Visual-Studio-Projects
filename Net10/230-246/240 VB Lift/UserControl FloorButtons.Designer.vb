Imports System.ComponentModel
Imports Microsoft.VisualBasic.CompilerServices

<DesignerGenerated()>
Partial Class FloorButtonsUserControl
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
        Me.lblFloorLabel = New Label
        Me.UpButton = New Button
        Me.DownButton = New Button
        Me.SuspendLayout()
        '
        'lblFloorLabel
        '
        Me.lblFloorLabel.AutoSize = True
        Me.lblFloorLabel.Font = New Font("Microsoft Sans Serif", 8.25!, FontStyle.Bold, GraphicsUnit.Point, CType(0, Byte))
        Me.lblFloorLabel.Location = New Point(3, 1)
        Me.lblFloorLabel.Name = "lblFloorLabel"
        Me.lblFloorLabel.Size = New Size(70, 13)
        Me.lblFloorLabel.TabIndex = 0
        Me.lblFloorLabel.Text = "Floor Label"
        '
        'btnUp
        '
        Me.UpButton.BackColor = SystemColors.Control
        Me.UpButton.Font = New Font("Wingdings", 14.25!, FontStyle.Regular, GraphicsUnit.Point, CType(2, Byte))
        Me.UpButton.Location = New Point(4, 16)
        Me.UpButton.Name = "btnUp"
        Me.UpButton.Size = New Size(35, 33)
        Me.UpButton.TabIndex = 1
        Me.UpButton.Text = "é"
        Me.UpButton.TextAlign = ContentAlignment.TopCenter
        Me.UpButton.UseVisualStyleBackColor = False
        '
        'btnDown
        '
        Me.DownButton.BackColor = SystemColors.Control
        Me.DownButton.Font = New Font("Wingdings", 14.25!, FontStyle.Regular, GraphicsUnit.Point, CType(2, Byte))
        Me.DownButton.Location = New Point(45, 16)
        Me.DownButton.Name = "btnDown"
        Me.DownButton.Size = New Size(35, 33)
        Me.DownButton.TabIndex = 2
        Me.DownButton.Text = "ê"
        Me.DownButton.TextAlign = ContentAlignment.BottomCenter
        Me.DownButton.UseVisualStyleBackColor = False
        '
        'ucFloorButtons
        '
        Me.AutoScaleDimensions = New SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.BorderStyle = BorderStyle.FixedSingle
        Me.Controls.Add(Me.DownButton)
        Me.Controls.Add(Me.UpButton)
        Me.Controls.Add(Me.lblFloorLabel)
        Me.Name = "ucFloorButtons"
        Me.Size = New Size(84, 55)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblFloorLabel As Label
    Friend WithEvents UpButton As Button
    Friend WithEvents DownButton As Button

End Class
