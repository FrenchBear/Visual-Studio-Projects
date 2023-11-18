Imports System.ComponentModel

Partial Public Class Form1
    Inherits Form

    <DebuggerNonUserCode()>
    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

    End Sub

    'Form overrides dispose to clean up the component list.
    <DebuggerNonUserCode()>
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
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
        Me.components = New Container
        Dim resources As ComponentResourceManager = New ComponentResourceManager(GetType(Form1))
        Me.NotifyIcon1 = New NotifyIcon(Me.components)
        Me.ContextMenuStrip1 = New ContextMenuStrip(Me.components)
        Me.ImageList1 = New ImageList(Me.components)
        Me.Commande1ToolStripMenuItem = New ToolStripMenuItem
        Me.Commande2ToolStripMenuItem = New ToolStripMenuItem
        Me.Commande3ToolStripMenuItem = New ToolStripMenuItem
        Me.ToolStripSeparator1 = New ToolStripSeparator
        Me.ToolStripComboBox1 = New ToolStripComboBox
        Me.PictureBox1 = New PictureBox
        Me.Label1 = New Label
        Me.ContextMenuStrip1.SuspendLayout()
        CType(Me.PictureBox1, ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), Icon)
        Me.NotifyIcon1.Text = "Ceci est le texte" & ChrW(13) & ChrW(10) & "de mon icone"
        Me.NotifyIcon1.Visible = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.AllowDrop = True
        Me.ContextMenuStrip1.ImageList = Me.ImageList1
        Me.ContextMenuStrip1.Items.AddRange(New ToolStripItem() {Me.Commande1ToolStripMenuItem, Me.Commande2ToolStripMenuItem, Me.Commande3ToolStripMenuItem, Me.ToolStripSeparator1, Me.ToolStripComboBox1})
        Me.ContextMenuStrip1.Location = New Point(23, 61)
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New Size(156, 97)
        '
        'ImageList1
        '
        Me.ImageList1.ImageSize = New Size(16, 16)
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), ImageListStreamer)
        Me.ImageList1.TransparentColor = Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "00038.ico")
        Me.ImageList1.Images.SetKeyName(1, "00039.ico")
        Me.ImageList1.Images.SetKeyName(2, "00040.ico")
        Me.ImageList1.Images.SetKeyName(3, "00041.ico")
        '
        'Commande1ToolStripMenuItem
        '
        Me.Commande1ToolStripMenuItem.ImageIndex = 0
        Me.Commande1ToolStripMenuItem.Name = "Commande1ToolStripMenuItem"
        Me.Commande1ToolStripMenuItem.Text = "Commande 1"
        '
        'Commande2ToolStripMenuItem
        '
        Me.Commande2ToolStripMenuItem.CheckOnClick = True
        Me.Commande2ToolStripMenuItem.ImageIndex = 1
        Me.Commande2ToolStripMenuItem.Name = "Commande2ToolStripMenuItem"
        Me.Commande2ToolStripMenuItem.Text = "Commande 2"
        '
        'Commande3ToolStripMenuItem
        '
        Me.Commande3ToolStripMenuItem.ImageIndex = 2
        Me.Commande3ToolStripMenuItem.Name = "Commande3ToolStripMenuItem"
        Me.Commande3ToolStripMenuItem.Text = "Commande 3"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        '
        'ToolStripComboBox1
        '
        Me.ToolStripComboBox1.ImageIndex = 3
        Me.ToolStripComboBox1.Items.AddRange(New Object() {"Bleu", "Blanc", "Rouge"})
        Me.ToolStripComboBox1.Name = "ToolStripComboBox1"
        Me.ToolStripComboBox1.Size = New Size(100, 21)
        Me.ToolStripComboBox1.ToolTipText = "Choisissez une couleur"
        '
        'PictureBox1
        '
        Me.PictureBox1.Location = New Point(13, 34)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New Size(24, 23)
        Me.PictureBox1.TabIndex = 4
        Me.PictureBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New Size(294, 14)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "L'icône suivant doit s'afficher dans la zone de notification :"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New Size(5, 13)
        Me.ClientSize = New Size(309, 266)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ContextMenuStrip1.ResumeLayout(False)
        CType(Me.PictureBox1, ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents NotifyIcon1 As NotifyIcon
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents Commande1ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Commande2ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Commande3ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripComboBox1 As ToolStripComboBox
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label

End Class
