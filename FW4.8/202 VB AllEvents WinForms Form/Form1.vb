' 2006-10-01    PV  VS2005
' 2012-02-25	PV  VS2010  Added missing events

Public Class Form1

    Private Sub Button1_Click(sender As System.Object, e As EventArgs) Handles Button1.Click
        Dim c As New Chien

        Dim a As Animal = c
        a.Action(a)
    End Sub

    Class Animal

        Overridable Sub Manger()
            MsgBox("Animal mange")
        End Sub

        Sub Action(a As Animal)
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

    Private Sub Form1_Activated(sender As Object, e As EventArgs) Handles Me.Activated
        Debug.WriteLine("Form1_Activated")
    End Sub

    Private Sub Form1_AutoSizeChanged(sender As Object, e As EventArgs) Handles Me.AutoSizeChanged
        Debug.WriteLine("Form1_AutoSizeChanged")
    End Sub

    Private Sub Form1_AutoValidateChanged(sender As Object, e As EventArgs) Handles Me.AutoValidateChanged
        Debug.WriteLine("Form1_AutoValidateChanged")
    End Sub

    Private Sub Form1_BackColorChanged(sender As Object, e As EventArgs) Handles Me.BackColorChanged
        Debug.WriteLine("Form1_BackColorChanged")
    End Sub

    Private Sub Form1_BackgroundImageChanged(sender As Object, e As EventArgs) Handles Me.BackgroundImageChanged
        Debug.WriteLine("Form1_BackgroundImageChanged")
    End Sub

    Private Sub Form1_BackgroundImageLayoutChanged(sender As Object, e As EventArgs) Handles Me.BackgroundImageLayoutChanged
        Debug.WriteLine("Form1_BackgroundImageLayoutChanged")
    End Sub

    Private Sub Form1_BindingContextChanged(sender As Object, e As EventArgs) Handles Me.BindingContextChanged
        Debug.WriteLine("Form1_BindingContextChanged")
    End Sub

    Private Sub Form1_CausesValidationChanged(sender As Object, e As EventArgs) Handles Me.CausesValidationChanged
        Debug.WriteLine("Form1_CausesValidationChanged")
    End Sub

    Private Sub Form1_ChangeUICues(sender As Object, e As UICuesEventArgs) Handles Me.ChangeUICues
        Debug.WriteLine("Form1_ChangeUICues")
    End Sub

    Private Sub Form1_Click(sender As Object, e As EventArgs) Handles Me.Click
        Debug.WriteLine("Form1_Click")
    End Sub

    Private Sub Form1_ContextMenuChanged(sender As Object, e As EventArgs) Handles Me.ContextMenuChanged
        Debug.WriteLine("Form1_ContextMenuChanged")

    End Sub

    Private Sub Form1_ContextMenuStripChanged(sender As Object, e As EventArgs) Handles Me.ContextMenuStripChanged
        Debug.WriteLine("Form1_ContextMenuStripChanged")

    End Sub

    Private Sub Form1_ControlAdded(sender As Object, e As ControlEventArgs) Handles Me.ControlAdded
        Debug.WriteLine("Form1_ControlAdded")

    End Sub

    Private Sub Form1_ControlRemoved(sender As Object, e As ControlEventArgs) Handles Me.ControlRemoved
        Debug.WriteLine("Form1_ControlRemoved")

    End Sub

    Private Sub Form1_CursorChanged(sender As Object, e As EventArgs) Handles Me.CursorChanged
        Debug.WriteLine("Form1_CursorChanged")

    End Sub

    Private Sub Form1_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate
        Debug.WriteLine("Form1_Deactivate")

    End Sub

    Private Sub Form1_Disposed(sender As Object, e As EventArgs) Handles Me.Disposed
        Debug.WriteLine("Form1_Disposed")

    End Sub

    Private Sub Form1_DockChanged(sender As Object, e As EventArgs) Handles Me.DockChanged
        Debug.WriteLine("Form1_DockChanged")

    End Sub

    Private Sub Form1_DoubleClick(sender As Object, e As EventArgs) Handles Me.DoubleClick
        Debug.WriteLine("Form1_DoubleClick")

    End Sub

    Private Sub Form1_DragDrop(sender As Object, e As DragEventArgs) Handles Me.DragDrop
        Debug.WriteLine("Form1_DragDrop")

    End Sub

    Private Sub Form1_DragEnter(sender As Object, e As DragEventArgs) Handles Me.DragEnter
        Debug.WriteLine("Form1_DragEnter")

    End Sub

    Private Sub Form1_DragLeave(sender As Object, e As EventArgs) Handles Me.DragLeave
        Debug.WriteLine("Form1_DragLeave")

    End Sub

    Private Sub Form1_DragOver(sender As Object, e As DragEventArgs) Handles Me.DragOver
        Debug.WriteLine("Form1_DragOver")

    End Sub

    Private Sub Form1_EnabledChanged(sender As Object, e As EventArgs) Handles Me.EnabledChanged
        Debug.WriteLine("Form1_EnabledChanged")

    End Sub

    Private Sub Form1_Enter(sender As Object, e As EventArgs) Handles Me.Enter
        Debug.WriteLine("Form1_Enter")

    End Sub

    Private Sub Form1_FontChanged(sender As Object, e As EventArgs) Handles Me.FontChanged
        Debug.WriteLine("Form1_FontChanged")

    End Sub

    Private Sub Form1_ForeColorChanged(sender As Object, e As EventArgs) Handles Me.ForeColorChanged
        Debug.WriteLine("Form1_ForeColorChanged")

    End Sub

    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Debug.WriteLine("Form1_FormClosed")

    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Debug.WriteLine("Form1_FormClosing")

    End Sub

    Private Sub Form1_GiveFeedback(sender As Object, e As GiveFeedbackEventArgs) Handles Me.GiveFeedback
        Debug.WriteLine("Form1_GiveFeedback")

    End Sub

    Private Sub Form1_GotFocus(sender As Object, e As EventArgs) Handles Me.GotFocus
        Debug.WriteLine("Form1_GotFocus")

    End Sub

    Private Sub Form1_HandleCreated(sender As Object, e As EventArgs) Handles Me.HandleCreated
        Debug.WriteLine("Form1_HandleCreated")

    End Sub

    Private Sub Form1_HandleDestroyed(sender As Object, e As EventArgs) Handles Me.HandleDestroyed
        Debug.WriteLine("Form1_HandleDestroyed")

    End Sub

    Private Sub Form1_HelpRequested(sender As Object, hlpevent As HelpEventArgs) Handles Me.HelpRequested
        Debug.WriteLine("Form1_HelpRequested")

    End Sub

    Private Sub Form1_ImeModeChanged(sender As Object, e As EventArgs) Handles Me.ImeModeChanged
        Debug.WriteLine("Form1_ImeModeChanged")

    End Sub

    Private Sub Form1_InputLanguageChanged(sender As Object, e As InputLanguageChangedEventArgs) Handles Me.InputLanguageChanged
        Debug.WriteLine("Form1_InputLanguageChanged")

    End Sub

    Private Sub Form1_InputLanguageChanging(sender As Object, e As InputLanguageChangingEventArgs) Handles Me.InputLanguageChanging
        Debug.WriteLine("Form1_InputLanguageChanging")

    End Sub

    Private Sub Form1_Invalidated(sender As Object, e As InvalidateEventArgs) Handles Me.Invalidated
        Debug.WriteLine("Form1_Invalidated")

    End Sub

    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Debug.WriteLine("Form1_KeyDown")

    End Sub

    Private Sub Form1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        Debug.WriteLine("Form1_KeyPress")

    End Sub

    Private Sub Form1_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        Debug.WriteLine("Form1_KeyUp")

    End Sub

    Private Sub Form1_Layout(sender As Object, e As LayoutEventArgs) Handles Me.Layout
        Debug.WriteLine("Form1_Layout")

    End Sub

    Private Sub Form1_Leave(sender As Object, e As EventArgs) Handles Me.Leave
        Debug.WriteLine("Form1_Leave")

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Debug.WriteLine("Form1_Load")

    End Sub

    Private Sub Form1_LocationChanged(sender As Object, e As EventArgs) Handles Me.LocationChanged
        Debug.WriteLine("Form1_LocationChanged")

    End Sub

    Private Sub Form1_LostFocus(sender As Object, e As EventArgs) Handles Me.LostFocus
        Debug.WriteLine("Form1_LostFocus")

    End Sub

    Private Sub Form1_MarginChanged(sender As Object, e As EventArgs) Handles Me.MarginChanged
        Debug.WriteLine("Form1_MarginChanged")

    End Sub

    Private Sub Form1_MaximizedBoundsChanged(sender As Object, e As EventArgs) Handles Me.MaximizedBoundsChanged
        Debug.WriteLine("Form1_MaximizedBoundsChanged")

    End Sub

    Private Sub Form1_MaximumSizeChanged(sender As Object, e As EventArgs) Handles Me.MaximumSizeChanged
        Debug.WriteLine("Form1_MaximumSizeChanged")

    End Sub

    Private Sub Form1_MdiChildActivate(sender As Object, e As EventArgs) Handles Me.MdiChildActivate
        Debug.WriteLine("Form1_MdiChildActivate")

    End Sub

    Private Sub Form1_MenuComplete(sender As Object, e As EventArgs) Handles Me.MenuComplete
        Debug.WriteLine("Form1_MenuComplete")

    End Sub

    Private Sub Form1_MenuStart(sender As Object, e As EventArgs) Handles Me.MenuStart
        Debug.WriteLine("Form1_MenuStart")

    End Sub

    Private Sub Form1_MinimumSizeChanged(sender As Object, e As EventArgs) Handles Me.MinimumSizeChanged
        Debug.WriteLine("Form1_MinimumSizeChanged")

    End Sub

    Private Sub Form1_MouseCaptureChanged(sender As Object, e As EventArgs) Handles Me.MouseCaptureChanged
        Debug.WriteLine("Form1_MouseCaptureChanged")

    End Sub

    Private Sub Form1_MouseClick(sender As Object, e As MouseEventArgs) Handles Me.MouseClick
        Debug.WriteLine("Form1_MouseClick")

    End Sub

    Private Sub Form1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles Me.MouseDoubleClick
        Debug.WriteLine("Form1_MouseDoubleClick")

    End Sub

    Private Sub Form1_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        Debug.WriteLine("Form1_MouseDown")

    End Sub

    Private Sub Form1_MouseEnter(sender As Object, e As EventArgs) Handles Me.MouseEnter
        Debug.WriteLine("Form1_MouseEnter")

    End Sub

    Private Sub Form1_MouseHover(sender As Object, e As EventArgs) Handles Me.MouseHover
        Debug.WriteLine("Form1_MouseHover")

    End Sub

    Private Sub Form1_MouseLeave(sender As Object, e As EventArgs) Handles Me.MouseLeave
        Debug.WriteLine("Form1_MouseLeave")

    End Sub

    Private Sub Form1_MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
        Debug.WriteLine("Form1_MouseMove")

    End Sub

    Private Sub Form1_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
        Debug.WriteLine("Form1_MouseUp")

    End Sub

    Private Sub Form1_MouseWheel(sender As Object, e As MouseEventArgs) Handles Me.MouseWheel
        Debug.WriteLine("Form1_MouseWheel")

    End Sub

    Private Sub Form1_Move(sender As Object, e As EventArgs) Handles Me.Move
        Debug.WriteLine("Form1_Move")

    End Sub

    Private Sub Form1_PaddingChanged(sender As Object, e As EventArgs) Handles Me.PaddingChanged
        Debug.WriteLine("Form1_PaddingChanged")

    End Sub

    Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Debug.WriteLine("Form1_Paint")

    End Sub

    Private Sub Form1_ParentChanged(sender As Object, e As EventArgs) Handles Me.ParentChanged
        Debug.WriteLine("Form1_ParentChanged")

    End Sub

    Private Sub Form1_QueryAccessibilityHelp(sender As Object, e As QueryAccessibilityHelpEventArgs) Handles Me.QueryAccessibilityHelp
        Debug.WriteLine("Form1_QueryAccessibilityHelp")

    End Sub

    Private Sub Form1_QueryContinueDrag(sender As Object, e As QueryContinueDragEventArgs) Handles Me.QueryContinueDrag
        Debug.WriteLine("Form1_QueryContinueDrag")

    End Sub

    Private Sub Form1_RegionChanged(sender As Object, e As EventArgs) Handles Me.RegionChanged
        Debug.WriteLine("Form1_RegionChanged")

    End Sub

    Private Sub Form1_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Debug.WriteLine("Form1_Resize")

    End Sub

    Private Sub Form1_ResizeBegin(sender As Object, e As EventArgs) Handles Me.ResizeBegin
        Debug.WriteLine("Form1_ResizeBegin")

    End Sub

    Private Sub Form1_ResizeEnd(sender As Object, e As EventArgs) Handles Me.ResizeEnd
        Debug.WriteLine("Form1_ResizeEnd")

    End Sub

    Private Sub Form1_RightToLeftChanged(sender As Object, e As EventArgs) Handles Me.RightToLeftChanged
        Debug.WriteLine("Form1_RightToLeftChanged")

    End Sub

    Private Sub Form1_Scroll(sender As Object, e As ScrollEventArgs) Handles Me.Scroll
        Debug.WriteLine("Form1_Scroll")

    End Sub

    Private Sub Form1_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        Debug.WriteLine("Form1_SizeChanged")

    End Sub

    Private Sub Form1_StyleChanged(sender As Object, e As EventArgs) Handles Me.StyleChanged
        Debug.WriteLine("Form1_StyleChanged")

    End Sub

    Private Sub Form1_SystemColorsChanged(sender As Object, e As EventArgs) Handles Me.SystemColorsChanged
        Debug.WriteLine("Form1_SystemColorsChanged")

    End Sub

    Private Sub Form1_TabStopChanged(sender As Object, e As EventArgs) Handles Me.TabStopChanged
        Debug.WriteLine("Form1_TabStopChanged")

    End Sub

    Private Sub Form1_TextChanged(sender As Object, e As EventArgs) Handles Me.TextChanged
        Debug.WriteLine("Form1_TextChanged")

    End Sub

    Private Sub Form1_Validated(sender As Object, e As EventArgs) Handles Me.Validated
        Debug.WriteLine("Form1_Validated")

    End Sub

    Private Sub Form1_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles Me.Validating
        Debug.WriteLine("Form1_Validating")

    End Sub

    Private Sub Form1_VisibleChanged(sender As Object, e As EventArgs) Handles Me.VisibleChanged
        Debug.WriteLine("Form1_VisibleChanged")

    End Sub

    Private Sub Form1_ClientSizeChanged(sender As System.Object, e As EventArgs) Handles MyBase.ClientSizeChanged
        Debug.WriteLine("Form1_ClientSizeChanged")
    End Sub

    Private Sub Form1_HelpButtonClicked(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles MyBase.HelpButtonClicked
        Debug.WriteLine("Form1_HelpButtonClicked")
    End Sub

    Private Sub Form1_PreviewKeyDown(sender As System.Object, e As PreviewKeyDownEventArgs) Handles MyBase.PreviewKeyDown
        Debug.WriteLine("Form1_PreviewKeyDown")
    End Sub

    Private Sub Form1_RightToLeftLayoutChanged(sender As System.Object, e As EventArgs) Handles MyBase.RightToLeftLayoutChanged
        Debug.WriteLine("Form1_RightToLeftLayoutChanged")
    End Sub

    Private Sub Form1_Shown(sender As System.Object, e As EventArgs) Handles MyBase.Shown
        Debug.WriteLine("Form1_Shown")
    End Sub

End Class