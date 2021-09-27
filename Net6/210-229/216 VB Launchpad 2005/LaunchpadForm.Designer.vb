Partial Public Class LaunchpadForm
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

    End Sub

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LaunchpadForm))
        Me.FichierToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.QuitterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.mnuFile = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmdLogin = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmdChangePassword = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmdConnectedUsers = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmdNewMessage = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmdReceivedMessages = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmdSentMessages = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmdPrinterSetup = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmdPrintActiveForm = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmdMailActiveForm = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.cmdExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuManagement = New System.Windows.Forms.ToolStripMenuItem()
        Me.OptionsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator6 = New System.Windows.Forms.ToolStripSeparator()
        Me.MenuEditorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReloadMenusToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsMain = New System.Windows.Forms.ToolStrip()
        Me.btnLogin = New System.Windows.Forms.ToolStripButton()
        Me.btnPrinterSetup = New System.Windows.Forms.ToolStripButton()
        Me.btnNewMessage = New System.Windows.Forms.ToolStripButton()
        Me.btnConnectedUsers = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator7 = New System.Windows.Forms.ToolStripSeparator()
        Me.btnOptions = New System.Windows.Forms.ToolStripButton()
        Me.btnMenuEditor = New System.Windows.Forms.ToolStripButton()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.sbMain = New System.Windows.Forms.ToolStripStatusLabel()
        Me.MenuStrip1.SuspendLayout()
        Me.tsMain.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'FichierToolStripMenuItem
        '
        Me.FichierToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.QuitterToolStripMenuItem})
        Me.FichierToolStripMenuItem.Name = "FichierToolStripMenuItem"
        Me.FichierToolStripMenuItem.Size = New System.Drawing.Size(32, 19)
        Me.FichierToolStripMenuItem.Text = "Fichier"
        '
        'QuitterToolStripMenuItem
        '
        Me.QuitterToolStripMenuItem.Name = "QuitterToolStripMenuItem"
        Me.QuitterToolStripMenuItem.Size = New System.Drawing.Size(222, 44)
        Me.QuitterToolStripMenuItem.Text = "Quitter"
        '
        'ListBox1
        '
        Me.ListBox1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 32
        Me.ListBox1.Location = New System.Drawing.Point(31, 158)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(1053, 324)
        Me.ListBox1.TabIndex = 9
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuFile, Me.mnuManagement})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1113, 40)
        Me.MenuStrip1.TabIndex = 10
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'mnuFile
        '
        Me.mnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.cmdLogin, Me.cmdChangePassword, Me.ToolStripSeparator5, Me.cmdConnectedUsers, Me.ToolStripSeparator4, Me.cmdNewMessage, Me.cmdReceivedMessages, Me.cmdSentMessages, Me.ToolStripSeparator3, Me.cmdPrinterSetup, Me.ToolStripSeparator2, Me.cmdPrintActiveForm, Me.cmdMailActiveForm, Me.ToolStripSeparator1, Me.cmdExit})
        Me.mnuFile.Name = "mnuFile"
        Me.mnuFile.Size = New System.Drawing.Size(71, 36)
        Me.mnuFile.Text = "&File"
        '
        'cmdLogin
        '
        Me.cmdLogin.Image = CType(resources.GetObject("cmdLogin.Image"), System.Drawing.Image)
        Me.cmdLogin.Name = "cmdLogin"
        Me.cmdLogin.Size = New System.Drawing.Size(353, 44)
        Me.cmdLogin.Text = "Login/Logout"
        '
        'cmdChangePassword
        '
        Me.cmdChangePassword.Name = "cmdChangePassword"
        Me.cmdChangePassword.Size = New System.Drawing.Size(353, 44)
        Me.cmdChangePassword.Text = "Change Password"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(350, 6)
        '
        'cmdConnectedUsers
        '
        Me.cmdConnectedUsers.Image = CType(resources.GetObject("cmdConnectedUsers.Image"), System.Drawing.Image)
        Me.cmdConnectedUsers.Name = "cmdConnectedUsers"
        Me.cmdConnectedUsers.Size = New System.Drawing.Size(353, 44)
        Me.cmdConnectedUsers.Text = "Connected Users"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(350, 6)
        '
        'cmdNewMessage
        '
        Me.cmdNewMessage.Image = CType(resources.GetObject("cmdNewMessage.Image"), System.Drawing.Image)
        Me.cmdNewMessage.Name = "cmdNewMessage"
        Me.cmdNewMessage.Size = New System.Drawing.Size(353, 44)
        Me.cmdNewMessage.Text = "New Message"
        '
        'cmdReceivedMessages
        '
        Me.cmdReceivedMessages.Name = "cmdReceivedMessages"
        Me.cmdReceivedMessages.Size = New System.Drawing.Size(353, 44)
        Me.cmdReceivedMessages.Text = "Received Messages"
        '
        'cmdSentMessages
        '
        Me.cmdSentMessages.Name = "cmdSentMessages"
        Me.cmdSentMessages.Size = New System.Drawing.Size(353, 44)
        Me.cmdSentMessages.Text = "Sent Messages"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(350, 6)
        '
        'cmdPrinterSetup
        '
        Me.cmdPrinterSetup.Image = CType(resources.GetObject("cmdPrinterSetup.Image"), System.Drawing.Image)
        Me.cmdPrinterSetup.Name = "cmdPrinterSetup"
        Me.cmdPrinterSetup.Size = New System.Drawing.Size(353, 44)
        Me.cmdPrinterSetup.Text = "Printer Setup"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(350, 6)
        '
        'cmdPrintActiveForm
        '
        Me.cmdPrintActiveForm.Name = "cmdPrintActiveForm"
        Me.cmdPrintActiveForm.Size = New System.Drawing.Size(353, 44)
        Me.cmdPrintActiveForm.Text = "Print Active Form"
        '
        'cmdMailActiveForm
        '
        Me.cmdMailActiveForm.Name = "cmdMailActiveForm"
        Me.cmdMailActiveForm.Size = New System.Drawing.Size(353, 44)
        Me.cmdMailActiveForm.Text = "Mail Active Form"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(350, 6)
        '
        'cmdExit
        '
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New System.Drawing.Size(353, 44)
        Me.cmdExit.Text = "Exit"
        '
        'mnuManagement
        '
        Me.mnuManagement.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.OptionsToolStripMenuItem, Me.ToolStripSeparator6, Me.MenuEditorToolStripMenuItem, Me.ReloadMenusToolStripMenuItem})
        Me.mnuManagement.Name = "mnuManagement"
        Me.mnuManagement.Size = New System.Drawing.Size(177, 36)
        Me.mnuManagement.Text = "&Management"
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.Image = CType(resources.GetObject("OptionsToolStripMenuItem.Image"), System.Drawing.Image)
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.Size = New System.Drawing.Size(299, 44)
        Me.OptionsToolStripMenuItem.Text = "Options"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New System.Drawing.Size(296, 6)
        '
        'MenuEditorToolStripMenuItem
        '
        Me.MenuEditorToolStripMenuItem.Image = CType(resources.GetObject("MenuEditorToolStripMenuItem.Image"), System.Drawing.Image)
        Me.MenuEditorToolStripMenuItem.Name = "MenuEditorToolStripMenuItem"
        Me.MenuEditorToolStripMenuItem.Size = New System.Drawing.Size(299, 44)
        Me.MenuEditorToolStripMenuItem.Text = "Menu Editor"
        '
        'ReloadMenusToolStripMenuItem
        '
        Me.ReloadMenusToolStripMenuItem.Name = "ReloadMenusToolStripMenuItem"
        Me.ReloadMenusToolStripMenuItem.Size = New System.Drawing.Size(299, 44)
        Me.ReloadMenusToolStripMenuItem.Text = "Reload Menus"
        '
        'tsMain
        '
        Me.tsMain.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.tsMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnLogin, Me.btnPrinterSetup, Me.btnNewMessage, Me.btnConnectedUsers, Me.ToolStripSeparator7, Me.btnOptions, Me.btnMenuEditor})
        Me.tsMain.Location = New System.Drawing.Point(0, 40)
        Me.tsMain.Name = "tsMain"
        Me.tsMain.Size = New System.Drawing.Size(1113, 42)
        Me.tsMain.TabIndex = 11
        Me.tsMain.Text = "ToolStrip1"
        '
        'btnLogin
        '
        Me.btnLogin.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnLogin.Image = CType(resources.GetObject("btnLogin.Image"), System.Drawing.Image)
        Me.btnLogin.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(46, 36)
        Me.btnLogin.Text = "Login"
        '
        'btnPrinterSetup
        '
        Me.btnPrinterSetup.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnPrinterSetup.Image = CType(resources.GetObject("btnPrinterSetup.Image"), System.Drawing.Image)
        Me.btnPrinterSetup.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnPrinterSetup.Name = "btnPrinterSetup"
        Me.btnPrinterSetup.Size = New System.Drawing.Size(46, 36)
        Me.btnPrinterSetup.Text = "Printer Setup"
        '
        'btnNewMessage
        '
        Me.btnNewMessage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnNewMessage.Image = CType(resources.GetObject("btnNewMessage.Image"), System.Drawing.Image)
        Me.btnNewMessage.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnNewMessage.Name = "btnNewMessage"
        Me.btnNewMessage.Size = New System.Drawing.Size(46, 36)
        Me.btnNewMessage.Text = "New Message"
        '
        'btnConnectedUsers
        '
        Me.btnConnectedUsers.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnConnectedUsers.Image = CType(resources.GetObject("btnConnectedUsers.Image"), System.Drawing.Image)
        Me.btnConnectedUsers.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnConnectedUsers.Name = "btnConnectedUsers"
        Me.btnConnectedUsers.Size = New System.Drawing.Size(46, 36)
        Me.btnConnectedUsers.Text = "Connected Users"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New System.Drawing.Size(6, 42)
        '
        'btnOptions
        '
        Me.btnOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnOptions.Image = CType(resources.GetObject("btnOptions.Image"), System.Drawing.Image)
        Me.btnOptions.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnOptions.Name = "btnOptions"
        Me.btnOptions.Size = New System.Drawing.Size(46, 36)
        Me.btnOptions.Text = "Options"
        '
        'btnMenuEditor
        '
        Me.btnMenuEditor.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnMenuEditor.Image = CType(resources.GetObject("btnMenuEditor.Image"), System.Drawing.Image)
        Me.btnMenuEditor.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnMenuEditor.Name = "btnMenuEditor"
        Me.btnMenuEditor.Size = New System.Drawing.Size(46, 36)
        Me.btnMenuEditor.Text = "Menu Editor"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.sbMain})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 614)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1113, 38)
        Me.StatusStrip1.TabIndex = 12
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'sbMain
        '
        Me.sbMain.Name = "sbMain"
        Me.sbMain.Size = New System.Drawing.Size(1036, 28)
        Me.sbMain.Spring = True
        Me.sbMain.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LaunchpadForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(12, 32)
        Me.ClientSize = New System.Drawing.Size(1113, 652)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.tsMain)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Name = "LaunchpadForm"
        Me.Text = "Launchpad 2005"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.tsMain.ResumeLayout(False)
        Me.tsMain.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FichierToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents QuitterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents mnuFile As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdLogin As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdChangePassword As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsMain As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmdConnectedUsers As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmdNewMessage As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdReceivedMessages As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdSentMessages As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmdPrinterSetup As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmdPrintActiveForm As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents cmdMailActiveForm As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents cmdExit As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuManagement As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OptionsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MenuEditorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ReloadMenusToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnLogin As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnPrinterSetup As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnNewMessage As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnConnectedUsers As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnOptions As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnMenuEditor As System.Windows.Forms.ToolStripButton
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents sbMain As ToolStripStatusLabel
End Class
