Imports System.ComponentModel
Imports System.IO
Imports Microsoft.VisualBasic.CompilerServices

<DesignerGenerated()>
Partial Class FormAncrage
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
        Dim resources As ComponentResourceManager = New ComponentResourceManager(GetType(FormAncrage))
        Me.MenuStrip1 = New MenuStrip()
        Me.MenuItem1 = New ToolStripMenuItem()
        Me.MenuItem2 = New ToolStripMenuItem()
        Me.ToolStripMenuItem1 = New ToolStripSeparator()
        Me.cmdQuitter = New ToolStripMenuItem()
        Me.ToolStrip1 = New ToolStrip()
        Me.ToolStripButton1 = New ToolStripButton()
        Me.ColorDialog1 = New ColorDialog()
        Me.StatusStrip1 = New StatusStrip()
        Me.ToolStripStatusLabel1 = New ToolStripStatusLabel()
        Me.lstTrace = New ListBox()
        Me.TextBox1 = New TextBox()
        Me.btnOk = New Button()
        Me.TextBox2 = New TextBox()
        Me.btnAnnuler = New Button()
        Me.lblTxt2 = New LinkLabel()
        Me.FileSystemWatcher1 = New FileSystemWatcher()
        Me.MenuStrip1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.FileSystemWatcher1, ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New Size(32, 32)
        Me.MenuStrip1.Items.AddRange(New ToolStripItem() {Me.MenuItem1})
        Me.MenuStrip1.Location = New Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New Size(1075, 40)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'MenuItem1
        '
        Me.MenuItem1.DropDownItems.AddRange(New ToolStripItem() {Me.MenuItem2, Me.ToolStripMenuItem1, Me.cmdQuitter})
        Me.MenuItem1.Name = "MenuItem1"
        Me.MenuItem1.Size = New Size(97, 36)
        Me.MenuItem1.Text = "Menu"
        '
        'MenuItem2
        '
        Me.MenuItem2.Name = "MenuItem2"
        Me.MenuItem2.Size = New Size(359, 44)
        Me.MenuItem2.Text = "Commande 1"
        '
        'ToolStripMenuItem1
        '
        Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
        Me.ToolStripMenuItem1.Size = New Size(356, 6)
        '
        'cmdQuitter
        '
        Me.cmdQuitter.Name = "cmdQuitter"
        Me.cmdQuitter.Size = New Size(359, 44)
        Me.cmdQuitter.Text = "Quitter"
        '
        'ToolStrip1
        '
        Me.ToolStrip1.ImageScalingSize = New Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New ToolStripItem() {Me.ToolStripButton1})
        Me.ToolStrip1.Location = New Point(0, 40)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New Size(1075, 42)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), Image)
        Me.ToolStripButton1.ImageTransparentColor = Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New Size(46, 36)
        Me.ToolStripButton1.Text = "ToolStripButton1"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New Size(32, 32)
        Me.StatusStrip1.Items.AddRange(New ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New Point(0, 523)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New Size(1075, 42)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New Size(1060, 32)
        Me.ToolStripStatusLabel1.Spring = True
        Me.ToolStripStatusLabel1.Text = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.TextAlign = ContentAlignment.MiddleLeft
        '
        'lstTrace
        '
        Me.lstTrace.Anchor = CType((((AnchorStyles.Top Or AnchorStyles.Bottom) _
            Or AnchorStyles.Left) _
            Or AnchorStyles.Right), AnchorStyles)
        Me.lstTrace.FormattingEnabled = True
        Me.lstTrace.ItemHeight = 32
        Me.lstTrace.Location = New Point(12, 224)
        Me.lstTrace.Name = "lstTrace"
        Me.lstTrace.Size = New Size(1051, 292)
        Me.lstTrace.TabIndex = 3
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Left) _
            Or AnchorStyles.Right), AnchorStyles)
        Me.TextBox1.Location = New Point(12, 102)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New Size(868, 39)
        Me.TextBox1.TabIndex = 0
        Me.TextBox1.Text = "TextBox1"
        '
        'btnOk
        '
        Me.btnOk.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles)
        Me.btnOk.DialogResult = DialogResult.OK
        Me.btnOk.Location = New Point(913, 98)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New Size(150, 46)
        Me.btnOk.TabIndex = 3
        Me.btnOk.Text = "&Ok"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'TextBox2
        '
        Me.TextBox2.Location = New Point(141, 159)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New Size(739, 39)
        Me.TextBox2.TabIndex = 2
        Me.TextBox2.Text = "TextBox2"
        '
        'btnAnnuler
        '
        Me.btnAnnuler.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles)
        Me.btnAnnuler.DialogResult = DialogResult.Cancel
        Me.btnAnnuler.Location = New Point(913, 159)
        Me.btnAnnuler.Name = "btnAnnuler"
        Me.btnAnnuler.Size = New Size(150, 46)
        Me.btnAnnuler.TabIndex = 4
        Me.btnAnnuler.Text = "Annuler"
        Me.btnAnnuler.UseVisualStyleBackColor = True
        '
        'lblTxt2
        '
        Me.lblTxt2.AutoSize = True
        Me.lblTxt2.Location = New Point(12, 159)
        Me.lblTxt2.Name = "lblTxt2"
        Me.lblTxt2.Size = New Size(102, 32)
        Me.lblTxt2.TabIndex = 1
        Me.lblTxt2.TabStop = True
        Me.lblTxt2.Text = "Texte 2 :"
        '
        'FileSystemWatcher1
        '
        Me.FileSystemWatcher1.EnableRaisingEvents = True
        Me.FileSystemWatcher1.SynchronizingObject = Me
        '
        'FormAncrage
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleDimensions = New SizeF(13.0!, 32.0!)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.CancelButton = Me.btnAnnuler
        Me.ClientSize = New Size(1075, 565)
        Me.Controls.Add(Me.lblTxt2)
        Me.Controls.Add(Me.btnAnnuler)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.lstTrace)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "FormAncrage"
        Me.Text = "Essais d'ancrages - Trace des événements"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.FileSystemWatcher1, ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents MenuItem1 As ToolStripMenuItem
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents ColorDialog1 As ColorDialog
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents lstTrace As ListBox
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents btnOk As Button
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents btnAnnuler As Button
    Friend WithEvents MenuItem2 As ToolStripMenuItem
    Friend WithEvents lblTxt2 As LinkLabel
    Friend WithEvents ToolStripMenuItem1 As ToolStripSeparator
    Friend WithEvents cmdQuitter As ToolStripMenuItem
    Friend WithEvents FileSystemWatcher1 As FileSystemWatcher
End Class
