Imports System.ComponentModel
Imports Microsoft.VisualBasic.CompilerServices

<DesignerGenerated()>
Partial Class Form1
    Inherits Form

    'Form overrides dispose to clean up the component list.
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
        Me.btnLoad = New Button
        Me.pbPic = New PictureBox
        Me.btnF1 = New Button
        Me.btnF2 = New Button
        Me.btnF3 = New Button
        CType(Me.pbPic, ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnLoad
        '
        Me.btnLoad.Location = New Point(12, 12)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New Size(75, 23)
        Me.btnLoad.TabIndex = 0
        Me.btnLoad.Text = "Load"
        Me.btnLoad.UseVisualStyleBackColor = True
        '
        'pbPic
        '
        Me.pbPic.Location = New Point(12, 41)
        Me.pbPic.Name = "pbPic"
        Me.pbPic.Size = New Size(590, 516)
        Me.pbPic.TabIndex = 1
        Me.pbPic.TabStop = False
        '
        'btnF1
        '
        Me.btnF1.Location = New Point(93, 11)
        Me.btnF1.Name = "btnF1"
        Me.btnF1.Size = New Size(75, 23)
        Me.btnF1.TabIndex = 2
        Me.btnF1.Text = "F1"
        Me.btnF1.UseVisualStyleBackColor = True
        '
        'btnF2
        '
        Me.btnF2.Location = New Point(174, 12)
        Me.btnF2.Name = "btnF2"
        Me.btnF2.Size = New Size(75, 23)
        Me.btnF2.TabIndex = 3
        Me.btnF2.Text = "F2"
        Me.btnF2.UseVisualStyleBackColor = True
        '
        'btnF3
        '
        Me.btnF3.Location = New Point(255, 12)
        Me.btnF3.Name = "btnF3"
        Me.btnF3.Size = New Size(75, 23)
        Me.btnF3.TabIndex = 4
        Me.btnF3.Text = "F3"
        Me.btnF3.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.ClientSize = New Size(614, 569)
        Me.Controls.Add(Me.btnF3)
        Me.Controls.Add(Me.btnF2)
        Me.Controls.Add(Me.btnF1)
        Me.Controls.Add(Me.pbPic)
        Me.Controls.Add(Me.btnLoad)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.pbPic, ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnLoad As Button
    Friend WithEvents pbPic As PictureBox
    Friend WithEvents btnF1 As Button
    Friend WithEvents btnF2 As Button
    Friend WithEvents btnF3 As Button

End Class
