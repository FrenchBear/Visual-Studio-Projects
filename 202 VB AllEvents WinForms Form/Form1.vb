' 2006-10-01    PV  VS2005
' 2012-02-25	PV  VS2010  Added missing events

Public Class Form1
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim c As Chien = New Chien

        Dim a As Animal = c
        a.Action(a)
    End Sub

    Class Animal
        Overridable Sub Manger()
            MsgBox("Animal mange")
        End Sub

        Sub Action(ByVal a As Animal)
            a.Manger()
            MyClass.Manger()
        End Sub
    End Class

    Class Chien : Inherits Animal
        Overrides Sub Manger()
            MsgBox("Chien mange")
        End Sub
    End Class

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
        MsgBox("Form1.Finalize")
    End Sub

    Private Sub Form1_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Debug.WriteLine("Form1_Activated")
    End Sub

    Private Sub Form1_AutoSizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.AutoSizeChanged
        Debug.WriteLine("Form1_AutoSizeChanged")
    End Sub

    Private Sub Form1_AutoValidateChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.AutoValidateChanged
        Debug.WriteLine("Form1_AutoValidateChanged")
    End Sub

    Private Sub Form1_BackColorChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.BackColorChanged
        Debug.WriteLine("Form1_BackColorChanged")
    End Sub

    Private Sub Form1_BackgroundImageChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.BackgroundImageChanged
        Debug.WriteLine("Form1_BackgroundImageChanged")
    End Sub

    Private Sub Form1_BackgroundImageLayoutChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.BackgroundImageLayoutChanged
        Debug.WriteLine("Form1_BackgroundImageLayoutChanged")
    End Sub

    Private Sub Form1_BindingContextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.BindingContextChanged
        Debug.WriteLine("Form1_BindingContextChanged")
    End Sub

    Private Sub Form1_CausesValidationChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.CausesValidationChanged
        Debug.WriteLine("Form1_CausesValidationChanged")
    End Sub

    Private Sub Form1_ChangeUICues(ByVal sender As Object, ByVal e As System.Windows.Forms.UICuesEventArgs) Handles Me.ChangeUICues
        Debug.WriteLine("Form1_ChangeUICues")
    End Sub

    Private Sub Form1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Click
        Debug.WriteLine("Form1_Click")
    End Sub

    Private Sub Form1_ContextMenuChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ContextMenuChanged
        Debug.WriteLine("Form1_ContextMenuChanged")

    End Sub

    Private Sub Form1_ContextMenuStripChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ContextMenuStripChanged
        Debug.WriteLine("Form1_ContextMenuStripChanged")

    End Sub

    Private Sub Form1_ControlAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.ControlEventArgs) Handles Me.ControlAdded
        Debug.WriteLine("Form1_ControlAdded")

    End Sub

    Private Sub Form1_ControlRemoved(ByVal sender As Object, ByVal e As System.Windows.Forms.ControlEventArgs) Handles Me.ControlRemoved
        Debug.WriteLine("Form1_ControlRemoved")

    End Sub

    Private Sub Form1_CursorChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.CursorChanged
        Debug.WriteLine("Form1_CursorChanged")

    End Sub

    Private Sub Form1_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
        Debug.WriteLine("Form1_Deactivate")

    End Sub

    Private Sub Form1_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Debug.WriteLine("Form1_Disposed")

    End Sub

    Private Sub Form1_DockChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DockChanged
        Debug.WriteLine("Form1_DockChanged")

    End Sub

    Private Sub Form1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DoubleClick
        Debug.WriteLine("Form1_DoubleClick")

    End Sub

    Private Sub Form1_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Me.DragDrop
        Debug.WriteLine("Form1_DragDrop")

    End Sub

    Private Sub Form1_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Me.DragEnter
        Debug.WriteLine("Form1_DragEnter")

    End Sub

    Private Sub Form1_DragLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DragLeave
        Debug.WriteLine("Form1_DragLeave")

    End Sub

    Private Sub Form1_DragOver(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles Me.DragOver
        Debug.WriteLine("Form1_DragOver")

    End Sub

    Private Sub Form1_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.EnabledChanged
        Debug.WriteLine("Form1_EnabledChanged")

    End Sub

    Private Sub Form1_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Enter
        Debug.WriteLine("Form1_Enter")

    End Sub

    Private Sub Form1_FontChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.FontChanged
        Debug.WriteLine("Form1_FontChanged")

    End Sub

    Private Sub Form1_ForeColorChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ForeColorChanged
        Debug.WriteLine("Form1_ForeColorChanged")

    End Sub

    Private Sub Form1_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Debug.WriteLine("Form1_FormClosed")

    End Sub

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Debug.WriteLine("Form1_FormClosing")

    End Sub

    Private Sub Form1_GiveFeedback(ByVal sender As Object, ByVal e As System.Windows.Forms.GiveFeedbackEventArgs) Handles Me.GiveFeedback
        Debug.WriteLine("Form1_GiveFeedback")

    End Sub

    Private Sub Form1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        Debug.WriteLine("Form1_GotFocus")

    End Sub

    Private Sub Form1_HandleCreated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.HandleCreated
        Debug.WriteLine("Form1_HandleCreated")

    End Sub

    Private Sub Form1_HandleDestroyed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.HandleDestroyed
        Debug.WriteLine("Form1_HandleDestroyed")

    End Sub

    Private Sub Form1_HelpRequested(ByVal sender As Object, ByVal hlpevent As System.Windows.Forms.HelpEventArgs) Handles Me.HelpRequested
        Debug.WriteLine("Form1_HelpRequested")

    End Sub

    Private Sub Form1_ImeModeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ImeModeChanged
        Debug.WriteLine("Form1_ImeModeChanged")

    End Sub

    Private Sub Form1_InputLanguageChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.InputLanguageChangedEventArgs) Handles Me.InputLanguageChanged
        Debug.WriteLine("Form1_InputLanguageChanged")

    End Sub

    Private Sub Form1_InputLanguageChanging(ByVal sender As Object, ByVal e As System.Windows.Forms.InputLanguageChangingEventArgs) Handles Me.InputLanguageChanging
        Debug.WriteLine("Form1_InputLanguageChanging")

    End Sub

    Private Sub Form1_Invalidated(ByVal sender As Object, ByVal e As System.Windows.Forms.InvalidateEventArgs) Handles Me.Invalidated
        Debug.WriteLine("Form1_Invalidated")

    End Sub

    Private Sub Form1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Debug.WriteLine("Form1_KeyDown")

    End Sub

    Private Sub Form1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Debug.WriteLine("Form1_KeyPress")

    End Sub

    Private Sub Form1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        Debug.WriteLine("Form1_KeyUp")

    End Sub

    Private Sub Form1_Layout(ByVal sender As Object, ByVal e As System.Windows.Forms.LayoutEventArgs) Handles Me.Layout
        Debug.WriteLine("Form1_Layout")

    End Sub

    Private Sub Form1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Leave
        Debug.WriteLine("Form1_Leave")

    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Debug.WriteLine("Form1_Load")

    End Sub

    Private Sub Form1_LocationChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LocationChanged
        Debug.WriteLine("Form1_LocationChanged")

    End Sub

    Private Sub Form1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LostFocus
        Debug.WriteLine("Form1_LostFocus")

    End Sub

    Private Sub Form1_MarginChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MarginChanged
        Debug.WriteLine("Form1_MarginChanged")

    End Sub

    Private Sub Form1_MaximizedBoundsChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MaximizedBoundsChanged
        Debug.WriteLine("Form1_MaximizedBoundsChanged")

    End Sub

    Private Sub Form1_MaximumSizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MaximumSizeChanged
        Debug.WriteLine("Form1_MaximumSizeChanged")

    End Sub

    Private Sub Form1_MdiChildActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MdiChildActivate
        Debug.WriteLine("Form1_MdiChildActivate")

    End Sub

    Private Sub Form1_MenuComplete(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MenuComplete
        Debug.WriteLine("Form1_MenuComplete")

    End Sub

    Private Sub Form1_MenuStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MenuStart
        Debug.WriteLine("Form1_MenuStart")

    End Sub

    Private Sub Form1_MinimumSizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MinimumSizeChanged
        Debug.WriteLine("Form1_MinimumSizeChanged")

    End Sub

    Private Sub Form1_MouseCaptureChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseCaptureChanged
        Debug.WriteLine("Form1_MouseCaptureChanged")

    End Sub

    Private Sub Form1_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseClick
        Debug.WriteLine("Form1_MouseClick")

    End Sub

    Private Sub Form1_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDoubleClick
        Debug.WriteLine("Form1_MouseDoubleClick")

    End Sub

    Private Sub Form1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        Debug.WriteLine("Form1_MouseDown")

    End Sub

    Private Sub Form1_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseEnter
        Debug.WriteLine("Form1_MouseEnter")

    End Sub

    Private Sub Form1_MouseHover(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseHover
        Debug.WriteLine("Form1_MouseHover")

    End Sub

    Private Sub Form1_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.MouseLeave
        Debug.WriteLine("Form1_MouseLeave")

    End Sub

    Private Sub Form1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        Debug.WriteLine("Form1_MouseMove")

    End Sub

    Private Sub Form1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        Debug.WriteLine("Form1_MouseUp")

    End Sub

    Private Sub Form1_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseWheel
        Debug.WriteLine("Form1_MouseWheel")

    End Sub

    Private Sub Form1_Move(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Move
        Debug.WriteLine("Form1_Move")

    End Sub

    Private Sub Form1_PaddingChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PaddingChanged
        Debug.WriteLine("Form1_PaddingChanged")

    End Sub

    Private Sub Form1_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Debug.WriteLine("Form1_Paint")

    End Sub

    Private Sub Form1_ParentChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ParentChanged
        Debug.WriteLine("Form1_ParentChanged")

    End Sub

    Private Sub Form1_QueryAccessibilityHelp(ByVal sender As Object, ByVal e As System.Windows.Forms.QueryAccessibilityHelpEventArgs) Handles Me.QueryAccessibilityHelp
        Debug.WriteLine("Form1_QueryAccessibilityHelp")

    End Sub

    Private Sub Form1_QueryContinueDrag(ByVal sender As Object, ByVal e As System.Windows.Forms.QueryContinueDragEventArgs) Handles Me.QueryContinueDrag
        Debug.WriteLine("Form1_QueryContinueDrag")

    End Sub

    Private Sub Form1_RegionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.RegionChanged
        Debug.WriteLine("Form1_RegionChanged")

    End Sub

    Private Sub Form1_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        Debug.WriteLine("Form1_Resize")

    End Sub

    Private Sub Form1_ResizeBegin(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ResizeBegin
        Debug.WriteLine("Form1_ResizeBegin")

    End Sub

    Private Sub Form1_ResizeEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ResizeEnd
        Debug.WriteLine("Form1_ResizeEnd")

    End Sub

    Private Sub Form1_RightToLeftChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.RightToLeftChanged
        Debug.WriteLine("Form1_RightToLeftChanged")

    End Sub

    Private Sub Form1_Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles Me.Scroll
        Debug.WriteLine("Form1_Scroll")

    End Sub

    Private Sub Form1_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        Debug.WriteLine("Form1_SizeChanged")

    End Sub

    Private Sub Form1_StyleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.StyleChanged
        Debug.WriteLine("Form1_StyleChanged")

    End Sub

    Private Sub Form1_SystemColorsChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SystemColorsChanged
        Debug.WriteLine("Form1_SystemColorsChanged")

    End Sub

    Private Sub Form1_TabStopChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.TabStopChanged
        Debug.WriteLine("Form1_TabStopChanged")

    End Sub

    Private Sub Form1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.TextChanged
        Debug.WriteLine("Form1_TextChanged")

    End Sub

    Private Sub Form1_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Validated
        Debug.WriteLine("Form1_Validated")

    End Sub

    Private Sub Form1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles Me.Validating
        Debug.WriteLine("Form1_Validating")

    End Sub

    Private Sub Form1_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged
        Debug.WriteLine("Form1_VisibleChanged")

    End Sub

    Private Sub Form1_ClientSizeChanged(sender As System.Object, e As System.EventArgs) Handles MyBase.ClientSizeChanged
        Debug.WriteLine("Form1_ClientSizeChanged")
    End Sub

    Private Sub Form1_HelpButtonClicked(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.HelpButtonClicked
        Debug.WriteLine("Form1_HelpButtonClicked")
    End Sub

    Private Sub Form1_PreviewKeyDown(sender As System.Object, e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles MyBase.PreviewKeyDown
        Debug.WriteLine("Form1_PreviewKeyDown")
    End Sub

    Private Sub Form1_RightToLeftLayoutChanged(sender As System.Object, e As System.EventArgs) Handles MyBase.RightToLeftLayoutChanged
        Debug.WriteLine("Form1_RightToLeftLayoutChanged")
    End Sub

    Private Sub Form1_Shown(sender As System.Object, e As System.EventArgs) Handles MyBase.Shown
        Debug.WriteLine("Form1_Shown")
    End Sub
End Class
