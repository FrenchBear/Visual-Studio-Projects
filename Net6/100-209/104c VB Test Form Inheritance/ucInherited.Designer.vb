Imports System.ComponentModel
Imports Microsoft.VisualBasic.CompilerServices

<DesignerGenerated()>
Partial Class InheritedUserControl
    Inherits TemplateUserControl

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
        Dim resources As ComponentResourceManager = New ComponentResourceManager(GetType(InheritedUserControl))
        Me.Panel1 = New Panel
        Me.TextBox3 = New TextBox
        Me.ToolStrip2 = New ToolStrip
        Me.ToolStripButton1b = New ToolStripButton
        Me.ToolStripTextBox1 = New ToolStripTextBox
        Me.ToolStripButton2b = New ToolStripButton
        Me.Panel1.SuspendLayout()
        Me.ToolStrip2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Size = New Size(338, 85)
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((AnchorStyles.Top Or AnchorStyles.Bottom) _
                    Or AnchorStyles.Left) _
                    Or AnchorStyles.Right), AnchorStyles)
        Me.Panel1.Controls.Add(Me.TextBox3)
        Me.Panel1.Controls.Add(Me.ToolStrip2)
        Me.Panel1.Location = New Point(0, 110)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New Size(338, 323)
        Me.Panel1.TabIndex = 4
        '
        'TextBox3
        '
        Me.TextBox3.Dock = DockStyle.Fill
        Me.TextBox3.Location = New Point(0, 25)
        Me.TextBox3.Multiline = True
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New Size(338, 298)
        Me.TextBox3.TabIndex = 6
        '
        'ToolStrip2
        '
        Me.ToolStrip2.Items.AddRange(New ToolStripItem() {Me.ToolStripButton1b, Me.ToolStripTextBox1, Me.ToolStripButton2b})
        Me.ToolStrip2.Location = New Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New Size(338, 25)
        Me.ToolStrip2.TabIndex = 5
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'ToolStripButton1b
        '
        Me.ToolStripButton1b.DisplayStyle = ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1b.Image = CType(resources.GetObject("ToolStripButton1b.Image"), Image)
        Me.ToolStripButton1b.ImageTransparentColor = Color.Magenta
        Me.ToolStripButton1b.Name = "ToolStripButton1b"
        Me.ToolStripButton1b.Size = New Size(23, 22)
        Me.ToolStripButton1b.Text = "ToolStripButton1"
        '
        'ToolStripTextBox1
        '
        Me.ToolStripTextBox1.Name = "ToolStripTextBox1"
        Me.ToolStripTextBox1.Size = New Size(50, 25)
        '
        'ToolStripButton2b
        '
        Me.ToolStripButton2b.DisplayStyle = ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2b.Image = CType(resources.GetObject("ToolStripButton2b.Image"), Image)
        Me.ToolStripButton2b.ImageTransparentColor = Color.Magenta
        Me.ToolStripButton2b.Name = "ToolStripButton2b"
        Me.ToolStripButton2b.Size = New Size(23, 22)
        Me.ToolStripButton2b.Text = "ToolStripButton2"
        '
        'ucInherited
        '
        Me.AutoScaleDimensions = New SizeF(6.0!, 13.0!)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "ucInherited"
        Me.Size = New Size(338, 433)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents ToolStrip2 As ToolStrip
    Friend WithEvents ToolStripButton1b As ToolStripButton
    Friend WithEvents ToolStripTextBox1 As ToolStripTextBox
    Friend WithEvents ToolStripButton2b As ToolStripButton

End Class
