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
        Me.Panel1 = New Panel
        Me.PictureBox1 = New PictureBox
        Me.Button1 = New Button
        Me.Button2 = New Button
        Me.HScrollBar1 = New HScrollBar
        Me.Button3 = New Button
        Me.HScrollBar2 = New HScrollBarNew
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((AnchorStyles.Top Or AnchorStyles.Bottom) _
                    Or AnchorStyles.Left) _
                    Or AnchorStyles.Right), AnchorStyles)
        Me.Panel1.AutoScroll = True
        Me.Panel1.AutoScrollMargin = New Size(3, 3)
        Me.Panel1.BackColor = Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Location = New Point(9, 93)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New Size(372, 252)
        Me.Panel1.TabIndex = 1
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New Point(3, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New Size(243, 167)
        Me.PictureBox1.TabIndex = 1
        Me.PictureBox1.TabStop = False
        '
        'Button1
        '
        Me.Button1.Location = New Point(9, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New Size(75, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "HS"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New Point(216, 12)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New Size(75, 23)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Pic"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'HScrollBar1
        '
        Me.HScrollBar1.Location = New Point(9, 38)
        Me.HScrollBar1.Name = "HScrollBar1"
        Me.HScrollBar1.Size = New Size(372, 17)
        Me.HScrollBar1.TabIndex = 4
        '
        'Button3
        '
        Me.Button3.Location = New Point(90, 12)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New Size(75, 23)
        Me.Button3.TabIndex = 6
        Me.Button3.Text = "HS2"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'HScrollBar2
        '
        Me.HScrollBar2.Location = New Point(9, 64)
        Me.HScrollBar2.Name = "HScrollBar2"
        Me.HScrollBar2.Size = New Size(372, 17)
        Me.HScrollBar2.TabIndex = 5
        Me.HScrollBar2.Maximum = 100
        Me.HScrollBar2.LargeChange = 10
        '
        'Form1
        '
        Me.AutoScaleDimensions = New SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.ClientSize = New Size(390, 357)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.HScrollBar2)
        Me.Controls.Add(Me.HScrollBar1)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.Panel1.ResumeLayout(False)
        CType(Me.PictureBox1, ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents HScrollBar1 As HScrollBar
    Friend WithEvents HScrollBar2 As HScrollBarNew
    Friend WithEvents Button3 As Button

End Class
