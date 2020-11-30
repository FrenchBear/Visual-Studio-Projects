' 003 VB Anchoring
' Essais divers
' Trace complète des événements de fenêtre
' 2001       PV
' 2003-05-13 PV VS.net 2003
' 2006-10-01 PV VS2005
' 2012-02-25 PV VS2010

#Disable Warning IDE1006 ' Naming Styles

Public Class FormAncrage
    Inherits Windows.Forms.Form

    Public Sub New()
        MyBase.New()

        'This call is required by the Win Form Designer.
        InitializeComponent()

        'TODO: Add any initialization after the InitializeComponent() call
    End Sub

    'Form overrides dispose to clean up the component list.
    Public Overloads Sub Dispose()
        MyBase.Dispose()
        components.Dispose()
    End Sub

    Private components As ComponentModel.IContainer

#Region " Windows Form Designer generated code "

    'Required by the Windows Form Designer
    Private WithEvents ColorDialog1 As Windows.Forms.ColorDialog

    Private ToolBarButton1 As Windows.Forms.ToolBarButton
    Private btnWorld As Windows.Forms.ToolBarButton
    Private WithEvents ImageList1 As Windows.Forms.ImageList
    Private WithEvents ToolBar1 As Windows.Forms.ToolBar

    Private WithEvents StatusBar1 As Windows.Forms.StatusBar

    Private WithEvents lblTxt2 As Windows.Forms.LinkLabel
    Private WithEvents cmdQuitter As Windows.Forms.MenuItem
    Private WithEvents mnuFichier As Windows.Forms.MenuItem
    Private MainMenu1 As Windows.Forms.MainMenu
    Private WithEvents FileSystemWatcher1 As IO.FileSystemWatcher
    Private WithEvents lstTrace As Windows.Forms.ListBox
    Private WithEvents TextBox2 As Windows.Forms.TextBox

    Private WithEvents TextBox1 As Windows.Forms.TextBox
    Private WithEvents btnAnnuler As Windows.Forms.Button
    Private WithEvents btnOk As Windows.Forms.Button
    Friend WithEvents MenuItem1 As Windows.Forms.MenuItem
    Friend WithEvents ToolBarButton2 As Windows.Forms.ToolBarButton
    Friend WithEvents MenuItem2 As Windows.Forms.MenuItem

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Me.components = New ComponentModel.Container()
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(FormAncrage))
        Me.ToolBar1 = New Windows.Forms.ToolBar()
        Me.ToolBarButton2 = New Windows.Forms.ToolBarButton()
        Me.ImageList1 = New Windows.Forms.ImageList(Me.components)
        Me.TextBox2 = New Windows.Forms.TextBox()
        Me.TextBox1 = New Windows.Forms.TextBox()
        Me.lstTrace = New Windows.Forms.ListBox()
        Me.ToolBarButton1 = New Windows.Forms.ToolBarButton()
        Me.mnuFichier = New Windows.Forms.MenuItem()
        Me.MenuItem1 = New Windows.Forms.MenuItem()
        Me.MenuItem2 = New Windows.Forms.MenuItem()
        Me.btnOk = New Windows.Forms.Button()
        Me.StatusBar1 = New Windows.Forms.StatusBar()
        Me.lblTxt2 = New Windows.Forms.LinkLabel()
        Me.MainMenu1 = New Windows.Forms.MainMenu(Me.components)
        Me.cmdQuitter = New Windows.Forms.MenuItem()
        Me.FileSystemWatcher1 = New IO.FileSystemWatcher()
        Me.btnAnnuler = New Windows.Forms.Button()
        Me.ColorDialog1 = New Windows.Forms.ColorDialog()
        Me.btnWorld = New Windows.Forms.ToolBarButton()
        CType(Me.FileSystemWatcher1, ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolBar1
        '
        Me.ToolBar1.Buttons.AddRange(New Windows.Forms.ToolBarButton() {Me.ToolBarButton2})
        Me.ToolBar1.DropDownArrows = True
        Me.ToolBar1.ImageList = Me.ImageList1
        Me.ToolBar1.Location = New Drawing.Point(0, 0)
        Me.ToolBar1.Name = "ToolBar1"
        Me.ToolBar1.ShowToolTips = True
        Me.ToolBar1.Size = New Drawing.Size(400, 28)
        Me.ToolBar1.TabIndex = 7
        '
        'ToolBarButton2
        '
        Me.ToolBarButton2.ImageIndex = 0
        Me.ToolBarButton2.Name = "ToolBarButton2"
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "")
        '
        'TextBox2
        '
        Me.TextBox2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), Windows.Forms.AnchorStyles)
        Me.TextBox2.Location = New Drawing.Point(128, 133)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New Drawing.Size(88, 31)
        Me.TextBox2.TabIndex = 1
        Me.TextBox2.Text = "TextBox2"
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), Windows.Forms.AnchorStyles)
        Me.TextBox1.Location = New Drawing.Point(16, 74)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New Drawing.Size(200, 31)
        Me.TextBox1.TabIndex = 0
        Me.TextBox1.Text = "TextBox1"
        '
        'lstTrace
        '
        Me.lstTrace.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), Windows.Forms.AnchorStyles)
        Me.lstTrace.ItemHeight = 25
        Me.lstTrace.Location = New Drawing.Point(16, 192)
        Me.lstTrace.Name = "lstTrace"
        Me.lstTrace.Size = New Drawing.Size(376, 4)
        Me.lstTrace.TabIndex = 2
        '
        'ToolBarButton1
        '
        Me.ToolBarButton1.ImageIndex = 1
        Me.ToolBarButton1.Name = "ToolBarButton1"
        Me.ToolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton
        '
        'mnuFichier
        '
        Me.mnuFichier.Index = -1
        Me.mnuFichier.Text = "&Fichier"
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 0
        Me.MenuItem1.MenuItems.AddRange(New Windows.Forms.MenuItem() {Me.MenuItem2})
        Me.MenuItem1.Text = "Menu"
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 0
        Me.MenuItem2.Text = "Commande 1"
        '
        'btnOk
        '
        Me.btnOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), Windows.Forms.AnchorStyles)
        Me.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.btnOk.Location = New Drawing.Point(240, 74)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnOk.Size = New Drawing.Size(150, 42)
        Me.btnOk.TabIndex = 3
        Me.btnOk.Text = "&Ok"
        '
        'StatusBar1
        '
        Me.StatusBar1.Location = New Drawing.Point(0, 221)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Size = New Drawing.Size(400, 36)
        Me.StatusBar1.TabIndex = 6
        Me.StatusBar1.Text = "StatusBar1"
        '
        'lblTxt2
        '
        Me.lblTxt2.Location = New Drawing.Point(16, 148)
        Me.lblTxt2.Name = "lblTxt2"
        Me.lblTxt2.Size = New Drawing.Size(96, 29)
        Me.lblTxt2.TabIndex = 5
        Me.lblTxt2.TabStop = True
        Me.lblTxt2.Text = "Texte 2 :"
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.AddRange(New Windows.Forms.MenuItem() {Me.MenuItem1})
        '
        'cmdQuitter
        '
        Me.cmdQuitter.Index = -1
        Me.cmdQuitter.Shortcut = System.Windows.Forms.Shortcut.AltF4
        Me.cmdQuitter.Text = "&Quitter"
        '
        'FileSystemWatcher1
        '
        Me.FileSystemWatcher1.EnableRaisingEvents = True
        Me.FileSystemWatcher1.Path = "c:\"
        Me.FileSystemWatcher1.SynchronizingObject = Me
        '
        'btnAnnuler
        '
        Me.btnAnnuler.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), Windows.Forms.AnchorStyles)
        Me.btnAnnuler.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnAnnuler.Location = New Drawing.Point(240, 133)
        Me.btnAnnuler.Name = "btnAnnuler"
        Me.btnAnnuler.Size = New Drawing.Size(150, 42)
        Me.btnAnnuler.TabIndex = 4
        Me.btnAnnuler.Text = "Annuler"
        '
        'btnWorld
        '
        Me.btnWorld.ImageIndex = 3
        Me.btnWorld.Name = "btnWorld"
        '
        'FormAncrage
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleBaseSize = New Drawing.Size(10, 24)
        Me.CancelButton = Me.btnAnnuler
        Me.ClientSize = New Drawing.Size(400, 257)
        Me.Controls.Add(Me.ToolBar1)
        Me.Controls.Add(Me.StatusBar1)
        Me.Controls.Add(Me.lblTxt2)
        Me.Controls.Add(Me.lstTrace)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.btnAnnuler)
        Me.Controls.Add(Me.btnOk)
        Me.Menu = Me.MainMenu1
        Me.Name = "FormAncrage"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show
        Me.Text = "Essais d'ancrages - Trace des événements"
        CType(Me.FileSystemWatcher1, ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Protected Sub ToolBar1_ButtonClick(sender As Object, e As Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar1.ButtonClick
        ColorDialog1.ShowDialog()
    End Sub

    Protected Sub lblTxt2_LinkClick(sender As Object, e As EventArgs) Handles lblTxt2.Click
        MsgBox("lblTxt2_LinkClick")
    End Sub

    Protected Sub cmdQuitter_Click(sender As Object, e As EventArgs) Handles cmdQuitter.Click
        End
    End Sub

    Protected Sub FileSystemWatcher1_Changed(sender As Object, e As IO.FileSystemEventArgs) Handles FileSystemWatcher1.Changed
        Trace(e.ToString & ": " & e.FullPath)
    End Sub

    Private Sub btnOk_Click(sender As System.Object, e As EventArgs) Handles btnOk.Click
        Trace("btnOk_Click")
    End Sub

    Protected Sub btnAnnuler_Click(sender As Object, e As EventArgs) Handles btnAnnuler.Click
        Trace("btnAnnuler_Click")
        End
    End Sub

    Public Sub TextBox1_GotFocus(sender As Object, e As EventArgs) Handles TextBox1.GotFocus
        Trace("TextBox1_GotFocus")
    End Sub

    Public Sub TextBox2_GotFocus(sender As Object, e As EventArgs) Handles TextBox2.GotFocus
        Trace("TextBox2_GotFocus")
    End Sub

    Public Sub TextBox1_LostFocus(sender As Object, e As EventArgs) Handles TextBox1.LostFocus
        Trace("TextBox1_LostFocus")
    End Sub

    Public Sub TextBox2_LostFocus(sender As Object, e As EventArgs) Handles TextBox2.LostFocus
        Trace("TextBox2_LostFocus")
    End Sub

    Private Sub TextBox1_Validating(sender As Object, e As ComponentModel.CancelEventArgs) Handles TextBox1.Validating
        Trace("TextBox1_Validating")
    End Sub

    Public Sub TextBox1_Validated(sender As Object, e As EventArgs) Handles TextBox1.Validated
        Trace("TextBox1_Validated")
    End Sub

    Private Sub TextBox2_Validating(sender As Object, e As ComponentModel.CancelEventArgs) Handles TextBox2.Validating
        Trace("TextBox2_Validating")
    End Sub

    Public Sub TextBox2_Validated(sender As Object, e As EventArgs) Handles TextBox2.Validated
        Trace("TextBox2_Validated")
    End Sub

    Private Sub MenuItem2_Click(sender As System.Object, e As EventArgs) Handles MenuItem2.Click
        Trace("MenuItem2_Click")
    End Sub

    Public Sub Trace(sMsg As String)
        lstTrace.Items.Add(sMsg)
        lstTrace.SelectedIndex = lstTrace.Items.Count - 1
    End Sub

    Public Sub Form_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Trace("Form_Activated")
    End Sub

    Public Sub Form_ChangeUICues(sender As Object, e As Windows.Forms.UICuesEventArgs) Handles Me.ChangeUICues
        Trace("Form_ChangeUICues")
    End Sub

    Public Sub Form_Click(sender As Object, e As EventArgs) Handles Me.Click
        Trace("Form_Click")
    End Sub

    Public Sub Form_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Trace("Form_Closed")
    End Sub

    Public Sub Form_Closing(sender As Object, e As ComponentModel.CancelEventArgs) Handles Me.Closing
        Trace("Form_Closing")
    End Sub

    Public Sub Form_ControlAdded(sender As Object, e As Windows.Forms.ControlEventArgs) Handles Me.ControlAdded
        Trace("Form_ControlAdded:  " & e.Control.ToString)
    End Sub

    Public Sub Form_ControlRemoved(sender As Object, e As Windows.Forms.ControlEventArgs) Handles Me.ControlRemoved
        Trace("Form_ControlRemoved")
    End Sub

    Public Sub Form_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate
        Trace("Form_Deactivate")
    End Sub

    Public Sub Form_DoubleClick(sender As Object, e As EventArgs) Handles Me.DoubleClick
        Trace("Form_DoubleClick")
    End Sub

    Public Sub Form_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        Trace("Form_Enter")
    End Sub

    Public Sub Form_GiveFeedback(sender As Object, e As Windows.Forms.GiveFeedbackEventArgs) Handles Me.GiveFeedback
        Trace("Form_GiveFeedback")
    End Sub

    Public Sub Form_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        Trace("Form_GotFocus")
    End Sub

    Public Sub Form_HandleCreated(sender As Object, e As EventArgs) Handles Me.HandleCreated
        Trace("Form_HandleCreated")
    End Sub

    Public Sub Form_HandleDestroyed(sender As Object, e As EventArgs) Handles Me.HandleDestroyed
        Trace("Form_HandleDestroyed")
    End Sub

    Public Sub Form_HelpRequested(sender As Object, hlpevent As Windows.Forms.HelpEventArgs) Handles Me.HelpRequested
        Trace("Form_HelpRequested")
    End Sub

    Public Sub Form_Invalidated(sender As Object, e As Windows.Forms.InvalidateEventArgs) Handles Me.Invalidated
        Trace("Form_Invalidated")
    End Sub

    Public Sub Form_KeyDown(sender As Object, e As Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Trace("Form_KeyDown")
    End Sub

    Public Sub Form_KeyPress(sender As Object, e As Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Trace("Form_KeyPress")
    End Sub

    Public Sub Form_KeyUp(sender As Object, e As Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        Trace("Form_KeyUp")
    End Sub

    Public Sub Form_Layout(sender As Object, e As Windows.Forms.LayoutEventArgs) Handles Me.Layout
        Trace("Form_Layout")
    End Sub

    Public Sub Form_Leave(sender As Object, e As EventArgs) Handles Me.Leave
        Trace("Form_Leave")
    End Sub

    Public Sub Form_LostFocus(sender As Object, e As EventArgs) Handles Me.LostFocus
        Trace("Form_LostFocus")
    End Sub

    Public Sub Form_MenuComplete(sender As Object, e As EventArgs) Handles Me.MenuComplete
        Trace("Form_MenuComplete")
    End Sub

    Public Sub Form_MenuStart(sender As Object, e As EventArgs) Handles Me.MenuStart
        Trace("Form_MenuStart")
    End Sub

    Public Sub Form_MouseWheel(sender As Object, e As Windows.Forms.MouseEventArgs) Handles Me.MouseWheel
        Trace("Form_MouseWheel")
    End Sub

    Public Sub Form_Move(sender As Object, e As EventArgs) Handles Me.Move
        Trace("Form_Move")
    End Sub

    Public Sub Form_Paint(sender As Object, e As Windows.Forms.PaintEventArgs) Handles Me.Paint
        Trace("Form_Paint")
    End Sub

    Public Sub Form_QueryAccessibilityHelp(sender As Object, e As Windows.Forms.QueryAccessibilityHelpEventArgs) Handles Me.QueryAccessibilityHelp
        Trace("Form_QueryAccessibilityHelp")
    End Sub

    Public Sub Form_QueryContinueDrag(sender As Object, e As Windows.Forms.QueryContinueDragEventArgs) Handles Me.QueryContinueDrag
        Trace("Form_QueryContinueDrag")
    End Sub

    Public Sub Form_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Trace("Form_Resize")
    End Sub

    Public Sub Form_Validated(sender As Object, e As EventArgs) Handles Me.Validated
        Trace("Form_Validated")
    End Sub

    Public Sub Form_MDIChildActivate(sender As Object, e As EventArgs) Handles Me.MdiChildActivate
        Trace("Form_MDIChildActivate")
    End Sub

    'Public Sub Form_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseEnter
    '  Trace("Form_MouseEnter")
    'End Sub
    'Public Sub Form_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseLeave
    '  Trace("Form_MouseLeave")
    'End Sub
    Public Sub Form_MouseDown(sender As Object, e As Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        Trace("Form_MouseDown")
    End Sub

    Public Sub Form_MouseUp(sender As Object, e As Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        Trace("Form_MouseUp")
    End Sub

    'Public Sub Form_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseHover
    '  trace("Form_MouseHover")
    'End Sub
    '  Public Sub Form_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
    '    trace("Form_MouseMove")
    '  End Sub
    Public Sub Form_DragEnter(sender As Object, e As Windows.Forms.DragEventArgs) Handles Me.DragEnter
        Trace("Form_DragEnter")
    End Sub

    Public Sub Form_DragLeave(sender As Object, e As EventArgs) Handles Me.DragLeave
        Trace("Form_DragLeave")
    End Sub

    Public Sub Form_DragOver(sender As Object, e As Windows.Forms.DragEventArgs) Handles Me.DragOver
        Trace("Form_DragOver")
    End Sub

    Private Sub Form_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        Trace("Form_SizeChanged")
    End Sub

    Private Sub Form_StyleChanged(sender As Object, e As EventArgs) Handles Me.StyleChanged
        Trace("Form_StyleChanged")
    End Sub

    Private Sub Form_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        Trace("Form_VisibleChanged")
    End Sub

    Private Sub Form_Validating(sender As Object, e As ComponentModel.CancelEventArgs) Handles Me.Validating
        Trace("Form_Validating")
    End Sub

    Private Sub Form_TextChanged(sender As Object, e As EventArgs) Handles Me.TextChanged
        Trace("Form_TextChanged")
    End Sub

    Private Sub Form_TabStopChanged(sender As Object, e As EventArgs) Handles Me.TabStopChanged
        Trace("Form_TabStopChanged")
    End Sub

    Private Sub Form_SystemColorsChanged(sender As Object, e As EventArgs) Handles Me.SystemColorsChanged
        Trace("Form_SystemColorsChanged")
    End Sub

    Private Sub Form_RightToLeftChanged(sender As Object, e As EventArgs) Handles Me.RightToLeftChanged
        Trace("Form_RightToLeftChanged")
    End Sub

    Private Sub Form_ParentChanged(sender As Object, e As EventArgs) Handles Me.ParentChanged
        Trace("Form_ParentChanged")
    End Sub

    Private Sub Form_MinimumSizeChanged(sender As Object, e As EventArgs) Handles Me.MinimumSizeChanged
        Trace("Form_MinimumSizeChanged")
    End Sub

    Private Sub Form_MaximumSizeChanged(sender As Object, e As EventArgs) Handles Me.MaximumSizeChanged
        Trace("Form_MaximumSizeChanged")
    End Sub

    Private Sub Form_MaximizedBoundsChanged(sender As Object, e As EventArgs) Handles Me.MaximizedBoundsChanged
        Trace("Form_MaximizedBoundsChanged")
    End Sub

    Private Sub Form_LocationChanged(sender As Object, e As EventArgs) Handles Me.LocationChanged
        Trace("Form_LocationChanged")
    End Sub

    Private Sub Form_Load(sender As Object, e As EventArgs) Handles Me.Load
        Trace("Form_Load")
    End Sub

    Private Sub Form_EnabledChanged(sender As Object, e As EventArgs) Handles Me.EnabledChanged
        Trace("Form_EnabledChanged")
    End Sub

    Private Sub Form_FontChanged(sender As Object, e As EventArgs) Handles Me.FontChanged
        Trace("Form_FontChanged")
    End Sub

    Private Sub Form_ForeColorChanged(sender As Object, e As EventArgs) Handles Me.ForeColorChanged
        Trace("Form_ForeColorChanged")
    End Sub

    Private Sub Form_DockChanged(sender As Object, e As EventArgs) Handles Me.DockChanged
        Trace("Form_DockChanged")
    End Sub

    Private Sub Form_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        Trace("Form_Disposed")
    End Sub

    Private Sub Form_CursorChanged(sender As Object, e As EventArgs) Handles Me.CursorChanged
        Trace("Form_CursorChanged")
    End Sub

    Private Sub Form_ContextMenuChanged(sender As Object, e As EventArgs) Handles Me.ContextMenuChanged
        Trace("Form_ContextMenuChanged")
    End Sub

    Private Sub Form_CausesValidationChanged(sender As Object, e As EventArgs) Handles Me.CausesValidationChanged
        Trace("Form_CausesValidationChanged")
    End Sub

    Private Sub Form_BindingContextChanged(sender As Object, e As EventArgs) Handles Me.BindingContextChanged
        Trace("Form_BindingContextChanged")
    End Sub

    Private Sub Form_BackgroundImageChanged(sender As Object, e As EventArgs) Handles Me.BackgroundImageChanged
        Trace("Form_BackgroundImageChanged")
    End Sub

    Private Sub Form_BackColorChanged(sender As Object, e As EventArgs) Handles Me.BackColorChanged
        Trace("Form_BackColorChanged")
    End Sub

    Private Sub Form_ImeModeChanged(sender As Object, e As EventArgs) Handles Me.ImeModeChanged
        Trace("Form_ImeModeChanged")
    End Sub

    Private Sub Form_InputLanguageChanged(sender As Object, e As Windows.Forms.InputLanguageChangedEventArgs) Handles Me.InputLanguageChanged
        Trace("Form_InputLanguageChanged")
    End Sub

    Private Sub Form_InputLanguageChanging(sender As Object, e As Windows.Forms.InputLanguageChangingEventArgs) Handles Me.InputLanguageChanging
        Trace("Form_InputLanguageChanging")
    End Sub

    Private Sub Form_AutoSizeChanged(sender As System.Object, e As EventArgs) Handles Me.AutoSizeChanged
        Trace("Form_AutoSizeChanged")
    End Sub

    Private Sub Form_FormClosed(sender As System.Object, e As Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        Trace("Form_FormClosed")
    End Sub

    Private Sub Form_FormClosing(sender As System.Object, e As Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Trace("Form_FormClosing")
    End Sub

    Private Sub Form_HelpButtonClicked(sender As System.Object, e As ComponentModel.CancelEventArgs) Handles MyBase.HelpButtonClicked
        Trace("Form_HelpButtonClicked")
    End Sub

    Private Sub Form_AutoValidateChanged(sender As System.Object, e As EventArgs) Handles MyBase.AutoValidateChanged
        Trace("Form_AutoValidateChanged")
    End Sub

    Private Sub Form_BackgroundImageLayoutChanged(sender As System.Object, e As EventArgs) Handles MyBase.BackgroundImageLayoutChanged
        Trace("Form_BackgroundImageLayoutChanged")
    End Sub

    Private Sub Form_ClientSizeChanged(sender As System.Object, e As EventArgs) Handles MyBase.ClientSizeChanged
        Trace("Form_ClientSizeChanged")
    End Sub

    Private Sub Form_ContextMenuStripChanged(sender As System.Object, e As EventArgs) Handles MyBase.ContextMenuStripChanged
        Trace("Form_ContextMenuStripChanged")
    End Sub

    Private Sub Form_DragDrop(sender As System.Object, e As Windows.Forms.DragEventArgs) Handles MyBase.DragDrop
        Trace("Form_DragDrop")
    End Sub

    Private Sub Form_MouseCaptureChanged(sender As System.Object, e As EventArgs) Handles MyBase.MouseCaptureChanged
        Trace("Form_MouseCaptureChanged")
    End Sub

    Private Sub Form_MouseClick(sender As System.Object, e As Windows.Forms.MouseEventArgs) Handles MyBase.MouseClick
        Trace("Form_MouseClick")
    End Sub

    Private Sub Form_MouseDoubleClick(sender As System.Object, e As Windows.Forms.MouseEventArgs) Handles MyBase.MouseDoubleClick
        Trace("Form_MouseDoubleClick")
    End Sub

    Private Sub Form_MouseEnter(sender As System.Object, e As EventArgs) Handles MyBase.MouseEnter
        Trace("Form_MouseEnter")
    End Sub

    Private Sub Form_MouseHover(sender As System.Object, e As EventArgs) Handles MyBase.MouseHover
        Trace("Form_MouseHover")
    End Sub

    Private Sub Form_MouseLeave(sender As System.Object, e As EventArgs) Handles MyBase.MouseLeave
        Trace("Form_MouseLeave")
    End Sub

    Private Sub Form_MouseMove(sender As System.Object, e As Windows.Forms.MouseEventArgs) Handles MyBase.MouseMove
        'Trace("Form_MouseMove")
    End Sub

    Private Sub Form_PaddingChanged(sender As System.Object, e As EventArgs) Handles MyBase.PaddingChanged
        Trace("Form_PaddingChanged")
    End Sub

    Private Sub Form_PreviewKeyDown(sender As System.Object, e As Windows.Forms.PreviewKeyDownEventArgs) Handles MyBase.PreviewKeyDown
        Trace("Form_PreviewKeyDown")
    End Sub

    Private Sub Form_RegionChanged(sender As System.Object, e As EventArgs) Handles MyBase.RegionChanged
        Trace("Form_RegionChanged")
    End Sub

    Private Sub Form_ResizeBegin(sender As System.Object, e As EventArgs) Handles MyBase.ResizeBegin
        Trace("Form_ResizeBegin")
    End Sub

    Private Sub Form_ResizeEnd(sender As System.Object, e As EventArgs) Handles MyBase.ResizeEnd
        Trace("Form_ResizeEnd")
    End Sub

    Private Sub Form_RightToLeftLayoutChanged(sender As System.Object, e As EventArgs) Handles MyBase.RightToLeftLayoutChanged
        Trace("Form_RightToLeftLayoutChanged")
    End Sub

    Private Sub Form_Scroll(sender As System.Object, e As Windows.Forms.ScrollEventArgs) Handles MyBase.Scroll
        Trace("Form_Scroll")
    End Sub

    Private Sub Form_Shown(sender As System.Object, e As EventArgs) Handles MyBase.Shown
        Trace("Form_Shown")
    End Sub

End Class