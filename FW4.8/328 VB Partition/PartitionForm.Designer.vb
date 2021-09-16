<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class PartitionForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.ContainerPanel = New System.Windows.Forms.Panel
        Me.pic = New System.Windows.Forms.PictureBox
        Me.StartButton = New System.Windows.Forms.Button
        Me.ContainerPanel.SuspendLayout()
        CType(Me.pic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ContainerPanel
        '
        Me.ContainerPanel.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ContainerPanel.AutoScroll = True
        Me.ContainerPanel.Controls.Add(Me.pic)
        Me.ContainerPanel.Location = New System.Drawing.Point(12, 50)
        Me.ContainerPanel.Name = "ContainerPanel"
        Me.ContainerPanel.Size = New System.Drawing.Size(528, 486)
        Me.ContainerPanel.TabIndex = 3
        '
        'pic
        '
        Me.pic.Location = New System.Drawing.Point(3, 3)
        Me.pic.Name = "pic"
        Me.pic.Size = New System.Drawing.Size(336, 323)
        Me.pic.TabIndex = 1
        Me.pic.TabStop = False
        '
        'StartButton
        '
        Me.StartButton.Location = New System.Drawing.Point(22, 12)
        Me.StartButton.Name = "StartButton"
        Me.StartButton.Size = New System.Drawing.Size(75, 23)
        Me.StartButton.TabIndex = 4
        Me.StartButton.Text = "Start"
        Me.StartButton.UseVisualStyleBackColor = True
        '
        'PartitionForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(552, 548)
        Me.Controls.Add(Me.StartButton)
        Me.Controls.Add(Me.ContainerPanel)
        Me.Name = "PartitionForm"
        Me.Text = "Form1"
        Me.ContainerPanel.ResumeLayout(False)
        CType(Me.pic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ContainerPanel As System.Windows.Forms.Panel
    Friend WithEvents pic As System.Windows.Forms.PictureBox
    Friend WithEvents StartButton As System.Windows.Forms.Button

End Class
