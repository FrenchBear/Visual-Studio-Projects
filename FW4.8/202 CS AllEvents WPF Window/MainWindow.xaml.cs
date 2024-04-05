// 202 CS AllEvents WPF Window
// 2012-02-28   PV  Stylus and Touch events ignored

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace CS202
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow() => InitializeComponent();

        private void Trace(string s, object sender, object e) => Debug.WriteLine(s);

        private void Window_Activated(object sender, EventArgs e) => Trace("Window_Activated", sender, e);

        private void Window_Deactivated(object sender, EventArgs e) => Trace("Window_Deactivated", sender, e);

        private void Window_ContentRendered(object sender, EventArgs e) => Trace("Window_ContentRendered", sender, e);

        private void Window_Closed(object sender, EventArgs e) => Trace("Window_Closed", sender, e);

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) => Trace("Window_Closing", sender, e);

        private void Window_GotFocus(object sender, RoutedEventArgs e) => Trace("Window_GotFocus", sender, e);

        private void Window_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e) => Trace("Window_GotKeyboardFocus", sender, e);

        private void Window_Initialized(object sender, EventArgs e) => Trace("Window_Initialized", sender, e);

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e) => Trace("Window_IsVisibleChanged", sender, e);

        private void Window_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e) => Trace("Window_IsEnabledChanged", sender, e);

        private void Window_LayoutUpdated(object sender, EventArgs e) => Trace("Window_LayoutUpdated", sender, e);

        private void Window_LocationChanged(object sender, EventArgs e) => Trace("Window_LocationChanged", sender, e);

        private void Window_LostFocus(object sender, RoutedEventArgs e) => Trace("Window_LostFocus", sender, e);

        private void Window_LostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e) => Trace("Window_LostKeyboardFocus", sender, e);

        private void Window_MouseWheel(object sender, MouseWheelEventArgs e) => Trace("Window_MouseWheel", sender, e);

        private void Window_RequestBringIntoView(object sender, RequestBringIntoViewEventArgs e) => Trace("Window_RequestBringIntoView", sender, e);

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e) => Trace("Window_SizeChanged", sender, e);

        private void Window_SourceInitialized(object sender, EventArgs e) => Trace("Window_SourceInitialized", sender, e);

        private void Window_SourceUpdated(object sender, DataTransferEventArgs e) => Trace("Window_SourceUpdated", sender, e);

        private void Window_StateChanged(object sender, EventArgs e) => Trace("Window_StateChanged", sender, e);

        private void Window_TargetUpdated(object sender, DataTransferEventArgs e) => Trace("Window_TargetUpdated", sender, e);

        private void Window_TextInput(object sender, TextCompositionEventArgs e) => Trace("Window_TextInput", sender, e);

        private void Window_Unloaded(object sender, RoutedEventArgs e) => Trace("Window_Unloaded", sender, e);

        private void Window_Loaded(object sender, RoutedEventArgs e) => Trace("Window_Loaded", sender, e);

        private void Window_MouseUp(object sender, MouseButtonEventArgs e) => Trace("Window_MouseUp", sender, e);

        private void Window_MouseRightButtonUp(object sender, MouseButtonEventArgs e) => Trace("Window_MouseRightButtonUp", sender, e);

        private void Window_MouseRightButtonDown(object sender, MouseButtonEventArgs e) => Trace("Window_MouseRightButtonDown", sender, e);

        private void Window_MouseMove(object sender, MouseEventArgs e) => Trace("Window_MouseMove", sender, e);

        private void Window_MouseLeftButtonUp(object sender, MouseButtonEventArgs e) => Trace("Window_MouseLeftButtonUp", sender, e);

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) => Trace("Window_MouseLeftButtonDown", sender, e);

        private void Window_MouseLeave(object sender, MouseEventArgs e) => Trace("Window_MouseLeave", sender, e);

        private void Window_MouseEnter(object sender, MouseEventArgs e) => Trace("Window_MouseEnter", sender, e);

        private void Window_MouseDown(object sender, MouseButtonEventArgs e) => Trace("Window_MouseDown", sender, e);

        private void Window_MouseDoubleClick(object sender, MouseButtonEventArgs e) => Trace("Window_MouseDoubleClick", sender, e);

        private void Window_KeyDown(object sender, KeyEventArgs e) => Trace("Window_KeyDown", sender, e);

        private void Window_KeyUp(object sender, KeyEventArgs e) => Trace("Window_KeyUp", sender, e);

        private void Window_IsHitTestVisibleChanged(object sender, DependencyPropertyChangedEventArgs e) => Trace("Window_IsHitTestVisibleChanged", sender, e);

        private void Window_IsKeyboardFocusedChanged(object sender, DependencyPropertyChangedEventArgs e) => Trace("Window_IsKeyboardFocusedChanged", sender, e);

        private void Window_IsKeyboardFocusWithinChanged(object sender, DependencyPropertyChangedEventArgs e) => Trace("Window_IsKeyboardFocusWithinChanged", sender, e);

        private void Window_IsMouseCapturedChanged(object sender, DependencyPropertyChangedEventArgs e) => Trace("Window_IsMouseCapturedChanged", sender, e);

        private void Window_IsMouseCaptureWithinChanged(object sender, DependencyPropertyChangedEventArgs e) => Trace("Window_IsMouseCaptureWithinChanged", sender, e);

        private void Window_IsMouseDirectlyOverChanged(object sender, DependencyPropertyChangedEventArgs e) => Trace("Window_IsMouseDirectlyOverChanged", sender, e);

        private void Window_GiveFeedback(object sender, GiveFeedbackEventArgs e) => Trace("Window_GiveFeedback", sender, e);

        private void Window_FocusableChanged(object sender, DependencyPropertyChangedEventArgs e) => Trace("Window_FocusableChanged", sender, e);

        private void Window_ContextMenuClosing(object sender, ContextMenuEventArgs e) => Trace("Window_ContextMenuClosing", sender, e);

        private void Window_ContextMenuOpening(object sender, ContextMenuEventArgs e) => Trace("Window_ContextMenuOpening", sender, e);

        private void Window_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e) => Trace("Window_DataContextChanged", sender, e);

        private void Window_PreviewGiveFeedback(object sender, GiveFeedbackEventArgs e) => Trace("Window_PreviewGiveFeedback", sender, e);

        private void Window_PreviewGotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e) => Trace("Window_PreviewGotKeyboardFocus", sender, e);

        private void Window_PreviewKeyDown(object sender, KeyEventArgs e) => Trace("Window_PreviewKeyDown", sender, e);

        private void Window_PreviewKeyUp(object sender, KeyEventArgs e) => Trace("Window_PreviewKeyUp", sender, e);

        private void Window_PreviewLostKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e) => Trace("Window_PreviewLostKeyboardFocus", sender, e);

        private void Window_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e) => Trace("Window_PreviewMouseDoubleClick", sender, e);

        private void Window_PreviewMouseDown(object sender, MouseButtonEventArgs e) => Trace("Window_PreviewMouseDown", sender, e);

        private void Window_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e) => Trace("Window_PreviewMouseLeftButtonDown", sender, e);

        private void Window_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e) => Trace("Window_PreviewMouseLeftButtonUp", sender, e);

        private void Window_PreviewMouseMove(object sender, MouseEventArgs e) => Trace("Window_PreviewMouseMove", sender, e);

        private void Window_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e) => Trace("Window_PreviewMouseRightButtonDown", sender, e);

        private void Window_PreviewMouseRightButtonUp(object sender, MouseButtonEventArgs e) => Trace("Window_PreviewMouseRightButtonUp", sender, e);

        private void Window_PreviewMouseUp(object sender, MouseButtonEventArgs e) => Trace("Window_PreviewMouseUp", sender, e);

        private void Window_PreviewMouseWheel(object sender, MouseWheelEventArgs e) => Trace("Window_PreviewMouseWheel", sender, e);

        private void Window_PreviewQueryContinueDrag(object sender, QueryContinueDragEventArgs e) => Trace("Window_PreviewQueryContinueDrag", sender, e);

        private void Window_PreviewTextInput(object sender, TextCompositionEventArgs e) => Trace("Window_PreviewTextInput", sender, e);

        private void Window_ToolTipClosing(object sender, ToolTipEventArgs e) => Trace("Window_ToolTipClosing", sender, e);

        private void Window_ToolTipOpening(object sender, ToolTipEventArgs e) => Trace("Window_ToolTipOpening", sender, e);
    }
}