Imports System.ComponentModel

Partial Public Class LaunchpadForm
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
        Dim resources As ComponentResourceManager = New ComponentResourceManager(GetType(LaunchpadForm))
        Me.FichierToolStripMenuItem = New ToolStripMenuItem()
        Me.QuitterToolStripMenuItem = New ToolStripMenuItem()
        Me.ListBox1 = New ListBox()
        Me.MenuStrip1 = New MenuStrip()
        Me.mnuFile = New ToolStripMenuItem()
        Me.cmdLogin = New ToolStripMenuItem()
        Me.cmdChangePassword = New ToolStripMenuItem()
        Me.ToolStripSeparator5 = New ToolStripSeparator()
        Me.cmdConnectedUsers = New ToolStripMenuItem()
        Me.ToolStripSeparator4 = New ToolStripSeparator()
        Me.cmdNewMessage = New ToolStripMenuItem()
        Me.cmdReceivedMessages = New ToolStripMenuItem()
        Me.cmdSentMessages = New ToolStripMenuItem()
        Me.ToolStripSeparator3 = New ToolStripSeparator()
        Me.cmdPrinterSetup = New ToolStripMenuItem()
        Me.ToolStripSeparator2 = New ToolStripSeparator()
        Me.cmdPrintActiveForm = New ToolStripMenuItem()
        Me.cmdMailActiveForm = New ToolStripMenuItem()
        Me.ToolStripSeparator1 = New ToolStripSeparator()
        Me.cmdExit = New ToolStripMenuItem()
        Me.mnuManagement = New ToolStripMenuItem()
        Me.OptionsToolStripMenuItem = New ToolStripMenuItem()
        Me.ToolStripSeparator6 = New ToolStripSeparator()
        Me.MenuEditorToolStripMenuItem = New ToolStripMenuItem()
        Me.ReloadMenusToolStripMenuItem = New ToolStripMenuItem()
        Me.tsMain = New ToolStrip()
        Me.btnLogin = New ToolStripButton()
        Me.btnPrinterSetup = New ToolStripButton()
        Me.btnNewMessage = New ToolStripButton()
        Me.btnConnectedUsers = New ToolStripButton()
        Me.ToolStripSeparator7 = New ToolStripSeparator()
        Me.btnOptions = New ToolStripButton()
        Me.btnMenuEditor = New ToolStripButton()
        Me.StatusStrip1 = New StatusStrip()
        Me.sbMain = New ToolStripStatusLabel()
        Me.MenuStrip1.SuspendLayout()
        Me.tsMain.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'FichierToolStripMenuItem
        '
        Me.FichierToolStripMenuItem.DropDownItems.AddRange(New ToolStripItem() {Me.QuitterToolStripMenuItem})
        Me.FichierToolStripMenuItem.Name = "FichierToolStripMenuItem"
        Me.FichierToolStripMenuItem.Size = New Size(32, 19)
        Me.FichierToolStripMenuItem.Text = "Fichier"
        '
        'QuitterToolStripMenuItem
        '
        Me.QuitterToolStripMenuItem.Name = "QuitterToolStripMenuItem"
        Me.QuitterToolStripMenuItem.Size = New Size(222, 44)
        Me.QuitterToolStripMenuItem.Text = "Quitter"
        '
        'ListBox1
        '
        Me.ListBox1.Anchor = CType((((AnchorStyles.Top Or AnchorStyles.Bottom) _
            Or AnchorStyles.Left) _
            Or AnchorStyles.Right), AnchorStyles)
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 32
        Me.ListBox1.Location = New Point(31, 158)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New Size(1053, 324)
        Me.ListBox1.TabIndex = 9
        '
        'MenuStrip1
        '
        Me.MenuStrip1.ImageScalingSize = New Size(32, 32)
        Me.MenuStrip1.Items.AddRange(New ToolStripItem() {Me.mnuFile, Me.mnuManagement})
        Me.MenuStrip1.Location = New Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New Size(1113, 40)
        Me.MenuStrip1.TabIndex = 10
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'mnuFile
        '
        Me.mnuFile.DropDownItems.AddRange(New ToolStripItem() {Me.cmdLogin, Me.cmdChangePassword, Me.ToolStripSeparator5, Me.cmdConnectedUsers, Me.ToolStripSeparator4, Me.cmdNewMessage, Me.cmdReceivedMessages, Me.cmdSentMessages, Me.ToolStripSeparator3, Me.cmdPrinterSetup, Me.ToolStripSeparator2, Me.cmdPrintActiveForm, Me.cmdMailActiveForm, Me.ToolStripSeparator1, Me.cmdExit})
        Me.mnuFile.Name = "mnuFile"
        Me.mnuFile.Size = New Size(71, 36)
        Me.mnuFile.Text = "&File"
        '
        'cmdLogin
        '
        Me.cmdLogin.Image = CType(resources.GetObject("cmdLogin.Image"), Image)
        Me.cmdLogin.Name = "cmdLogin"
        Me.cmdLogin.Size = New Size(353, 44)
        Me.cmdLogin.Text = "Login/Logout"
        '
        'cmdChangePassword
        '
        Me.cmdChangePassword.Name = "cmdChangePassword"
        Me.cmdChangePassword.Size = New Size(353, 44)
        Me.cmdChangePassword.Text = "Change Password"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New Size(350, 6)
        '
        'cmdConnectedUsers
        '
        Me.cmdConnectedUsers.Image = CType(resources.GetObject("cmdConnectedUsers.Image"), Image)
        Me.cmdConnectedUsers.Name = "cmdConnectedUsers"
        Me.cmdConnectedUsers.Size = New Size(353, 44)
        Me.cmdConnectedUsers.Text = "Connected Users"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New Size(350, 6)
        '
        'cmdNewMessage
        '
        Me.cmdNewMessage.Image = CType(resources.GetObject("cmdNewMessage.Image"), Image)
        Me.cmdNewMessage.Name = "cmdNewMessage"
        Me.cmdNewMessage.Size = New Size(353, 44)
        Me.cmdNewMessage.Text = "New Message"
        '
        'cmdReceivedMessages
        '
        Me.cmdReceivedMessages.Name = "cmdReceivedMessages"
        Me.cmdReceivedMessages.Size = New Size(353, 44)
        Me.cmdReceivedMessages.Text = "Received Messages"
        '
        'cmdSentMessages
        '
        Me.cmdSentMessages.Name = "cmdSentMessages"
        Me.cmdSentMessages.Size = New Size(353, 44)
        Me.cmdSentMessages.Text = "Sent Messages"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New Size(350, 6)
        '
        'cmdPrinterSetup
        '
        Me.cmdPrinterSetup.Image = CType(resources.GetObject("cmdPrinterSetup.Image"), Image)
        Me.cmdPrinterSetup.Name = "cmdPrinterSetup"
        Me.cmdPrinterSetup.Size = New Size(353, 44)
        Me.cmdPrinterSetup.Text = "Printer Setup"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New Size(350, 6)
        '
        'cmdPrintActiveForm
        '
        Me.cmdPrintActiveForm.Name = "cmdPrintActiveForm"
        Me.cmdPrintActiveForm.Size = New Size(353, 44)
        Me.cmdPrintActiveForm.Text = "Print Active Form"
        '
        'cmdMailActiveForm
        '
        Me.cmdMailActiveForm.Name = "cmdMailActiveForm"
        Me.cmdMailActiveForm.Size = New Size(353, 44)
        Me.cmdMailActiveForm.Text = "Mail Active Form"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New Size(350, 6)
        '
        'cmdExit
        '
        Me.cmdExit.Name = "cmdExit"
        Me.cmdExit.Size = New Size(353, 44)
        Me.cmdExit.Text = "Exit"
        '
        'mnuManagement
        '
        Me.mnuManagement.DropDownItems.AddRange(New ToolStripItem() {Me.OptionsToolStripMenuItem, Me.ToolStripSeparator6, Me.MenuEditorToolStripMenuItem, Me.ReloadMenusToolStripMenuItem})
        Me.mnuManagement.Name = "mnuManagement"
        Me.mnuManagement.Size = New Size(177, 36)
        Me.mnuManagement.Text = "&Management"
        '
        'OptionsToolStripMenuItem
        '
        Me.OptionsToolStripMenuItem.Image = CType(resources.GetObject("OptionsToolStripMenuItem.Image"), Image)
        Me.OptionsToolStripMenuItem.Name = "OptionsToolStripMenuItem"
        Me.OptionsToolStripMenuItem.Size = New Size(299, 44)
        Me.OptionsToolStripMenuItem.Text = "Options"
        '
        'ToolStripSeparator6
        '
        Me.ToolStripSeparator6.Name = "ToolStripSeparator6"
        Me.ToolStripSeparator6.Size = New Size(296, 6)
        '
        'MenuEditorToolStripMenuItem
        '
        Me.MenuEditorToolStripMenuItem.Image = CType(resources.GetObject("MenuEditorToolStripMenuItem.Image"), Image)
        Me.MenuEditorToolStripMenuItem.Name = "MenuEditorToolStripMenuItem"
        Me.MenuEditorToolStripMenuItem.Size = New Size(299, 44)
        Me.MenuEditorToolStripMenuItem.Text = "Menu Editor"
        '
        'ReloadMenusToolStripMenuItem
        '
        Me.ReloadMenusToolStripMenuItem.Name = "ReloadMenusToolStripMenuItem"
        Me.ReloadMenusToolStripMenuItem.Size = New Size(299, 44)
        Me.ReloadMenusToolStripMenuItem.Text = "Reload Menus"
        '
        'tsMain
        '
        Me.tsMain.ImageScalingSize = New Size(32, 32)
        Me.tsMain.Items.AddRange(New ToolStripItem() {Me.btnLogin, Me.btnPrinterSetup, Me.btnNewMessage, Me.btnConnectedUsers, Me.ToolStripSeparator7, Me.btnOptions, Me.btnMenuEditor})
        Me.tsMain.Location = New Point(0, 40)
        Me.tsMain.Name = "tsMain"
        Me.tsMain.Size = New Size(1113, 42)
        Me.tsMain.TabIndex = 11
        Me.tsMain.Text = "ToolStrip1"
        '
        'btnLogin
        '
        Me.btnLogin.DisplayStyle = ToolStripItemDisplayStyle.Image
        Me.btnLogin.Image = CType(resources.GetObject("btnLogin.Image"), Image)
        Me.btnLogin.ImageTransparentColor = Color.Magenta
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New Size(46, 36)
        Me.btnLogin.Text = "Login"
        '
        'btnPrinterSetup
        '
        Me.btnPrinterSetup.DisplayStyle = ToolStripItemDisplayStyle.Image
        Me.btnPrinterSetup.Image = CType(resources.GetObject("btnPrinterSetup.Image"), Image)
        Me.btnPrinterSetup.ImageTransparentColor = Color.Magenta
        Me.btnPrinterSetup.Name = "btnPrinterSetup"
        Me.btnPrinterSetup.Size = New Size(46, 36)
        Me.btnPrinterSetup.Text = "Printer Setup"
        '
        'btnNewMessage
        '
        Me.btnNewMessage.DisplayStyle = ToolStripItemDisplayStyle.Image
        Me.btnNewMessage.Image = CType(resources.GetObject("btnNewMessage.Image"), Image)
        Me.btnNewMessage.ImageTransparentColor = Color.Magenta
        Me.btnNewMessage.Name = "btnNewMessage"
        Me.btnNewMessage.Size = New Size(46, 36)
        Me.btnNewMessage.Text = "New Message"
        '
        'btnConnectedUsers
        '
        Me.btnConnectedUsers.DisplayStyle = ToolStripItemDisplayStyle.Image
        Me.btnConnectedUsers.Image = CType(resources.GetObject("btnConnectedUsers.Image"), Image)
        Me.btnConnectedUsers.ImageTransparentColor = Color.Magenta
        Me.btnConnectedUsers.Name = "btnConnectedUsers"
        Me.btnConnectedUsers.Size = New Size(46, 36)
        Me.btnConnectedUsers.Text = "Connected Users"
        '
        'ToolStripSeparator7
        '
        Me.ToolStripSeparator7.Name = "ToolStripSeparator7"
        Me.ToolStripSeparator7.Size = New Size(6, 42)
        '
        'btnOptions
        '
        Me.btnOptions.DisplayStyle = ToolStripItemDisplayStyle.Image
        Me.btnOptions.Image = CType(resources.GetObject("btnOptions.Image"), Image)
        Me.btnOptions.ImageTransparentColor = Color.Magenta
        Me.btnOptions.Name = "btnOptions"
        Me.btnOptions.Size = New Size(46, 36)
        Me.btnOptions.Text = "Options"
        '
        'btnMenuEditor
        '
        Me.btnMenuEditor.DisplayStyle = ToolStripItemDisplayStyle.Image
        Me.btnMenuEditor.Image = CType(resources.GetObject("btnMenuEditor.Image"), Image)
        Me.btnMenuEditor.ImageTransparentColor = Color.Magenta
        Me.btnMenuEditor.Name = "btnMenuEditor"
        Me.btnMenuEditor.Size = New Size(46, 36)
        Me.btnMenuEditor.Text = "Menu Editor"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.ImageScalingSize = New Size(32, 32)
        Me.StatusStrip1.Items.AddRange(New ToolStripItem() {Me.sbMain})
        Me.StatusStrip1.Location = New Point(0, 614)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New Size(1113, 38)
        Me.StatusStrip1.TabIndex = 12
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'sbMain
        '
        Me.sbMain.Name = "sbMain"
        Me.sbMain.Size = New Size(1036, 28)
        Me.sbMain.Spring = True
        Me.sbMain.TextAlign = ContentAlignment.MiddleLeft
        '
        'LaunchpadForm
        '
        Me.AutoScaleBaseSize = New Size(12, 32)
        Me.ClientSize = New Size(1113, 652)
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
    Friend WithEvents FichierToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents QuitterToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents mnuFile As ToolStripMenuItem
    Friend WithEvents cmdLogin As ToolStripMenuItem
    Friend WithEvents cmdChangePassword As ToolStripMenuItem
    Friend WithEvents tsMain As ToolStrip
    Friend WithEvents ToolStripSeparator5 As ToolStripSeparator
    Friend WithEvents cmdConnectedUsers As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As ToolStripSeparator
    Friend WithEvents cmdNewMessage As ToolStripMenuItem
    Friend WithEvents cmdReceivedMessages As ToolStripMenuItem
    Friend WithEvents cmdSentMessages As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents cmdPrinterSetup As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents cmdPrintActiveForm As ToolStripMenuItem
    Friend WithEvents cmdMailActiveForm As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents cmdExit As ToolStripMenuItem
    Friend WithEvents mnuManagement As ToolStripMenuItem
    Friend WithEvents OptionsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator6 As ToolStripSeparator
    Friend WithEvents MenuEditorToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ReloadMenusToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents btnLogin As ToolStripButton
    Friend WithEvents btnPrinterSetup As ToolStripButton
    Friend WithEvents btnNewMessage As ToolStripButton
    Friend WithEvents btnConnectedUsers As ToolStripButton
    Friend WithEvents ToolStripSeparator7 As ToolStripSeparator
    Friend WithEvents btnOptions As ToolStripButton
    Friend WithEvents btnMenuEditor As ToolStripButton
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents sbMain As ToolStripStatusLabel
End Class
