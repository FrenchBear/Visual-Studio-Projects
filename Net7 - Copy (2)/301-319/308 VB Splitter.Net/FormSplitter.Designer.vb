Imports Microsoft.VisualBasic.CompilerServices

<DesignerGenerated()> Partial Class Form1
#Region "Windows Form Designer generated code "
    <System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()
    End Sub
    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
        If Disposing Then
            If Not components Is Nothing Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(Disposing)
    End Sub
    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Public ToolTip1 As System.Windows.Forms.ToolTip
    Public WithEvents imgSplitter As System.Windows.Forms.PictureBox
    Public WithEvents picSplitter As System.Windows.Forms.PictureBox
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Form1))
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(components)
        Me.imgSplitter = New System.Windows.Forms.PictureBox
        Me.picSplitter = New System.Windows.Forms.PictureBox
        Me.SuspendLayout()
        Me.ToolTip1.Active = True
        Me.Text = "Form1"
        Me.ClientSize = New System.Drawing.Size(447, 370)
        Me.Location = New System.Drawing.Point(8, 28)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
        Me.ControlBox = True
        Me.Enabled = True
        Me.KeyPreview = False
        Me.MaximizeBox = True
        Me.MinimizeBox = True
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = True
        Me.HelpButton = False
        Me.WindowState = System.Windows.Forms.FormWindowState.Normal
        Me.Name = "Form1"
        Me.imgSplitter.BackColor = System.Drawing.Color.FromArgb(128, 128, 128)
        Me.imgSplitter.Size = New System.Drawing.Size(267, 4)
        Me.imgSplitter.Location = New System.Drawing.Point(48, 132)
        Me.imgSplitter.Cursor = System.Windows.Forms.Cursors.SizeNS
        Me.imgSplitter.TabIndex = 1
        Me.imgSplitter.Dock = System.Windows.Forms.DockStyle.None
        Me.imgSplitter.CausesValidation = True
        Me.imgSplitter.Enabled = True
        Me.imgSplitter.ForeColor = System.Drawing.SystemColors.ControlText
        Me.imgSplitter.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.imgSplitter.TabStop = True
        Me.imgSplitter.Visible = True
        Me.imgSplitter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
        Me.imgSplitter.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.imgSplitter.Name = "imgSplitter"
        Me.picSplitter.BackColor = System.Drawing.Color.FromArgb(128, 128, 128)
        Me.picSplitter.Size = New System.Drawing.Size(267, 4)
        Me.picSplitter.Location = New System.Drawing.Point(80, 292)
        Me.picSplitter.TabIndex = 0
        Me.picSplitter.Visible = False
        Me.picSplitter.Dock = System.Windows.Forms.DockStyle.None
        Me.picSplitter.CausesValidation = True
        Me.picSplitter.Enabled = True
        Me.picSplitter.ForeColor = System.Drawing.SystemColors.ControlText
        Me.picSplitter.Cursor = System.Windows.Forms.Cursors.Default
        Me.picSplitter.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.picSplitter.TabStop = True
        Me.picSplitter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal
        Me.picSplitter.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.picSplitter.Name = "picSplitter"
        Me.Controls.Add(imgSplitter)
        Me.Controls.Add(picSplitter)
        Me.ResumeLayout(False)
        Me.PerformLayout()
    End Sub
#End Region
End Class