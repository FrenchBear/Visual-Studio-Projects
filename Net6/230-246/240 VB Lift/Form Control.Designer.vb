Imports System.ComponentModel
Imports Microsoft.VisualBasic.CompilerServices

<DesignerGenerated()>
Partial Class frmControl
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
        Me.paFloorButtons = New Panel
        Me.Label1 = New Label
        Me.Label2 = New Label
        Me.paCarButtons = New Panel
        Me.SuspendLayout()
        '
        'paFloorButtons
        '
        Me.paFloorButtons.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Bottom) _
                    Or AnchorStyles.Left), AnchorStyles)
        Me.paFloorButtons.AutoScroll = True
        Me.paFloorButtons.BackColor = Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.paFloorButtons.Location = New Point(12, 35)
        Me.paFloorButtons.Name = "paFloorButtons"
        Me.paFloorButtons.Size = New Size(172, 606)
        Me.paFloorButtons.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New Point(12, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New Size(71, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Floor Controls"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New Point(190, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New Size(28, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Cars"
        '
        'paCarButtons
        '
        Me.paCarButtons.Anchor = CType((((AnchorStyles.Top Or AnchorStyles.Bottom) _
                    Or AnchorStyles.Left) _
                    Or AnchorStyles.Right), AnchorStyles)
        Me.paCarButtons.AutoScroll = True
        Me.paCarButtons.BackColor = Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.paCarButtons.Location = New Point(190, 35)
        Me.paCarButtons.Name = "paCarButtons"
        Me.paCarButtons.Size = New Size(332, 606)
        Me.paCarButtons.TabIndex = 2
        '
        'frmControl
        '
        Me.AutoScaleDimensions = New SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.ClientSize = New Size(531, 653)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.paCarButtons)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.paFloorButtons)
        Me.Name = "frmControl"
        Me.Text = "Floor and Car Controls"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents paFloorButtons As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents paCarButtons As Panel
End Class
