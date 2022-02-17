Imports System.ComponentModel
Imports Microsoft.VisualBasic.CompilerServices

<DesignerGenerated()>
Partial Class PartitionForm
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
        Me.ContainerPanel = New Panel
        Me.pic = New PictureBox
        Me.StartButton = New Button
        Me.ContainerPanel.SuspendLayout()
        CType(Me.pic, ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ContainerPanel
        '
        Me.ContainerPanel.Anchor = CType((((AnchorStyles.Top Or AnchorStyles.Bottom) _
                    Or AnchorStyles.Left) _
                    Or AnchorStyles.Right), AnchorStyles)
        Me.ContainerPanel.AutoScroll = True
        Me.ContainerPanel.Controls.Add(Me.pic)
        Me.ContainerPanel.Location = New Point(12, 50)
        Me.ContainerPanel.Name = "ContainerPanel"
        Me.ContainerPanel.Size = New Size(528, 486)
        Me.ContainerPanel.TabIndex = 3
        '
        'pic
        '
        Me.pic.Location = New Point(3, 3)
        Me.pic.Name = "pic"
        Me.pic.Size = New Size(336, 323)
        Me.pic.TabIndex = 1
        Me.pic.TabStop = False
        '
        'StartButton
        '
        Me.StartButton.Location = New Point(22, 12)
        Me.StartButton.Name = "StartButton"
        Me.StartButton.Size = New Size(75, 23)
        Me.StartButton.TabIndex = 4
        Me.StartButton.Text = "Start"
        Me.StartButton.UseVisualStyleBackColor = True
        '
        'PartitionForm
        '
        Me.AutoScaleDimensions = New SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.ClientSize = New Size(552, 548)
        Me.Controls.Add(Me.StartButton)
        Me.Controls.Add(Me.ContainerPanel)
        Me.Name = "PartitionForm"
        Me.Text = "Form1"
        Me.ContainerPanel.ResumeLayout(False)
        CType(Me.pic, ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ContainerPanel As Panel
    Friend WithEvents pic As PictureBox
    Friend WithEvents StartButton As Button

End Class
