' 003 VB Anchoring
' Essais divers
' Trace complète des événements de fenêtre
' 2001          PV
' 2003-05-13    PV      VS.net 2003
' 2006-10-01    PV      VS2005
' 2012-02-25    PV      VS2010
' 2021-09-16    PV      VS2021/Net6 - Complete rewrite, since original controls are not support anymore in .Net Core
Imports System.ComponentModel
Imports System.IO

#Disable Warning IDE1006 ' Naming Styles

Public Class FormAncrage
    Public Sub Trace(sMsg As String)
        lstTrace.Items.Add(sMsg)
        lstTrace.SelectedIndex = lstTrace.Items.Count - 1
    End Sub

    Private Sub Commande1ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MenuItem2.Click
        ColorDialog1.ShowDialog()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        ColorDialog1.ShowDialog()
    End Sub


    Protected Sub lblTxt2_LinkClick(sender As Object, e As EventArgs) Handles lblTxt2.Click
        MsgBox("lblTxt2_LinkClick")
    End Sub

    Protected Sub cmdQuitter_Click(sender As Object, e As EventArgs) Handles cmdQuitter.Click
        End
    End Sub

    Protected Sub FileSystemWatcher1_Changed(sender As Object, e As FileSystemEventArgs) Handles FileSystemWatcher1.Changed
        Trace(e.ToString & ": " & e.FullPath)
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
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

    Private Sub TextBox1_Validating(sender As Object, e As CancelEventArgs) Handles TextBox1.Validating
        Trace("TextBox1_Validating")
    End Sub

    Public Sub TextBox1_Validated(sender As Object, e As EventArgs) Handles TextBox1.Validated
        Trace("TextBox1_Validated")
    End Sub

    Private Sub TextBox2_Validating(sender As Object, e As CancelEventArgs) Handles TextBox2.Validating
        Trace("TextBox2_Validating")
    End Sub

    Public Sub TextBox2_Validated(sender As Object, e As EventArgs) Handles TextBox2.Validated
        Trace("TextBox2_Validated")
    End Sub

    Private Sub MenuItem2_Click(sender As Object, e As EventArgs) Handles MenuItem2.Click
        Trace("MenuItem2_Click")
    End Sub

    Public Sub Form_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Trace("Form_Activated")
    End Sub

    Public Sub Form_ChangeUICues(sender As Object, e As UICuesEventArgs) Handles Me.ChangeUICues
        Trace("Form_ChangeUICues")
    End Sub

    Public Sub Form_Click(sender As Object, e As EventArgs) Handles Me.Click
        Trace("Form_Click")
    End Sub

    Public Sub Form_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Trace("Form_Closed")
    End Sub

    Public Sub Form_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Trace("Form_Closing")
    End Sub

    Public Sub Form_ControlAdded(sender As Object, e As ControlEventArgs) Handles Me.ControlAdded
        Trace("Form_ControlAdded:  " & e.Control.ToString)
    End Sub

    Public Sub Form_ControlRemoved(sender As Object, e As ControlEventArgs) Handles Me.ControlRemoved
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

    Public Sub Form_GiveFeedback(sender As Object, e As GiveFeedbackEventArgs) Handles Me.GiveFeedback
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

    Public Sub Form_HelpRequested(sender As Object, hlpevent As HelpEventArgs) Handles Me.HelpRequested
        Trace("Form_HelpRequested")
    End Sub

    Public Sub Form_Invalidated(sender As Object, e As InvalidateEventArgs) Handles Me.Invalidated
        Trace("Form_Invalidated")
    End Sub

    Public Sub Form_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Trace("Form_KeyDown")
    End Sub

    Public Sub Form_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        Trace("Form_KeyPress")
    End Sub

    Public Sub Form_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        Trace("Form_KeyUp")
    End Sub

    Public Sub Form_Layout(sender As Object, e As LayoutEventArgs) Handles Me.Layout
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

    Public Sub Form_MouseWheel(sender As Object, e As MouseEventArgs) Handles Me.MouseWheel
        Trace("Form_MouseWheel")
    End Sub

    Public Sub Form_Move(sender As Object, e As EventArgs) Handles Me.Move
        Trace("Form_Move")
    End Sub

    Public Sub Form_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Trace("Form_Paint")
    End Sub

    Public Sub Form_QueryAccessibilityHelp(sender As Object, e As QueryAccessibilityHelpEventArgs) Handles Me.QueryAccessibilityHelp
        Trace("Form_QueryAccessibilityHelp")
    End Sub

    Public Sub Form_QueryContinueDrag(sender As Object, e As QueryContinueDragEventArgs) Handles Me.QueryContinueDrag
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
    Public Sub Form_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        Trace("Form_MouseDown")
    End Sub

    Public Sub Form_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
        Trace("Form_MouseUp")
    End Sub

    'Public Sub Form_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseHover
    '  trace("Form_MouseHover")
    'End Sub
    '  Public Sub Form_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
    '    trace("Form_MouseMove")
    '  End Sub
    Public Sub Form_DragEnter(sender As Object, e As DragEventArgs) Handles Me.DragEnter
        Trace("Form_DragEnter")
    End Sub

    Public Sub Form_DragLeave(sender As Object, e As EventArgs) Handles Me.DragLeave
        Trace("Form_DragLeave")
    End Sub

    Public Sub Form_DragOver(sender As Object, e As DragEventArgs) Handles Me.DragOver
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

    Private Sub Form_Validating(sender As Object, e As CancelEventArgs) Handles Me.Validating
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

    'Private Sub Form_ContextMenuChanged(sender As Object, e As EventArgs) Handles Me.ContextMenuChanged
    '    Trace("Form_ContextMenuChanged")
    'End Sub

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

    Private Sub Form_InputLanguageChanged(sender As Object, e As InputLanguageChangedEventArgs) Handles Me.InputLanguageChanged
        Trace("Form_InputLanguageChanged")
    End Sub

    Private Sub Form_InputLanguageChanging(sender As Object, e As InputLanguageChangingEventArgs) Handles Me.InputLanguageChanging
        Trace("Form_InputLanguageChanging")
    End Sub

    Private Sub Form_AutoSizeChanged(sender As Object, e As EventArgs) Handles Me.AutoSizeChanged
        Trace("Form_AutoSizeChanged")
    End Sub

    Private Sub Form_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Trace("Form_FormClosed")
    End Sub

    Private Sub Form_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Trace("Form_FormClosing")
    End Sub

    Private Sub Form_HelpButtonClicked(sender As Object, e As CancelEventArgs) Handles MyBase.HelpButtonClicked
        Trace("Form_HelpButtonClicked")
    End Sub

    Private Sub Form_AutoValidateChanged(sender As Object, e As EventArgs) Handles MyBase.AutoValidateChanged
        Trace("Form_AutoValidateChanged")
    End Sub

    Private Sub Form_BackgroundImageLayoutChanged(sender As Object, e As EventArgs) Handles MyBase.BackgroundImageLayoutChanged
        Trace("Form_BackgroundImageLayoutChanged")
    End Sub

    Private Sub Form_ClientSizeChanged(sender As Object, e As EventArgs) Handles MyBase.ClientSizeChanged
        Trace("Form_ClientSizeChanged")
    End Sub

    Private Sub Form_ContextMenuStripChanged(sender As Object, e As EventArgs) Handles MyBase.ContextMenuStripChanged
        Trace("Form_ContextMenuStripChanged")
    End Sub

    Private Sub Form_DragDrop(sender As Object, e As DragEventArgs) Handles MyBase.DragDrop
        Trace("Form_DragDrop")
    End Sub

    Private Sub Form_MouseCaptureChanged(sender As Object, e As EventArgs) Handles MyBase.MouseCaptureChanged
        Trace("Form_MouseCaptureChanged")
    End Sub

    Private Sub Form_MouseClick(sender As Object, e As MouseEventArgs) Handles MyBase.MouseClick
        Trace("Form_MouseClick")
    End Sub

    Private Sub Form_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDoubleClick
        Trace("Form_MouseDoubleClick")
    End Sub

    Private Sub Form_MouseEnter(sender As Object, e As EventArgs) Handles MyBase.MouseEnter
        Trace("Form_MouseEnter")
    End Sub

    Private Sub Form_MouseHover(sender As Object, e As EventArgs) Handles MyBase.MouseHover
        Trace("Form_MouseHover")
    End Sub

    Private Sub Form_MouseLeave(sender As Object, e As EventArgs) Handles MyBase.MouseLeave
        Trace("Form_MouseLeave")
    End Sub

    Private Sub Form_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
        'Trace("Form_MouseMove")
    End Sub

    Private Sub Form_PaddingChanged(sender As Object, e As EventArgs) Handles MyBase.PaddingChanged
        Trace("Form_PaddingChanged")
    End Sub

    Private Sub Form_PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles MyBase.PreviewKeyDown
        Trace("Form_PreviewKeyDown")
    End Sub

    Private Sub Form_RegionChanged(sender As Object, e As EventArgs) Handles MyBase.RegionChanged
        Trace("Form_RegionChanged")
    End Sub

    Private Sub Form_ResizeBegin(sender As Object, e As EventArgs) Handles MyBase.ResizeBegin
        Trace("Form_ResizeBegin")
    End Sub

    Private Sub Form_ResizeEnd(sender As Object, e As EventArgs) Handles MyBase.ResizeEnd
        Trace("Form_ResizeEnd")
    End Sub

    Private Sub Form_RightToLeftLayoutChanged(sender As Object, e As EventArgs) Handles MyBase.RightToLeftLayoutChanged
        Trace("Form_RightToLeftLayoutChanged")
    End Sub

    Private Sub Form_Scroll(sender As Object, e As ScrollEventArgs) Handles MyBase.Scroll
        Trace("Form_Scroll")
    End Sub

    Private Sub Form_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        Trace("Form_Shown")
    End Sub

End Class
