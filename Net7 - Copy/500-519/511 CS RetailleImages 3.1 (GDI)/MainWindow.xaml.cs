﻿// RI3 - Batch Pics Resize Tool v3
// Version 3.1, uses GDI to resize bitmaps, and preserve EXIF info from original pic
//
// 2013-07-14   PV  First version 3, rewrite in C#, WPF and MVVM, Multitasking
// 2021-09-26   PV      VS2022; Net6

using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;

namespace RI3;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        var m = new Model();
        var vm = new ViewModel(m, this);
        m.SetViewModel(vm);
        DataContext = vm;

        // Initial focus, but better done in Xaml using FocusManager.FocusedElement
        //Loaded += (s, e) =>
        //{
        //    SourceFolderTextBox.Focus();
        //};
        Loaded += (s, e) =>
        {
            // Get the Handle for the Forms System Menu
            var systemMenuHandle = GetSystemMenu(Handle, false);

            // Create our new System Menu items just before the Close menu item
            _ = InsertMenu(systemMenuHandle, 5, MfByposition | MfSeparator, 0, string.Empty); // <-- Add a menu separator
            _ = InsertMenu(systemMenuHandle, 6, MfByposition, SettingsSysMenuId, "&A propos de Retaille Images...");

            // Attach our WindowCommandHandler handler to this Window
            var source = HwndSource.FromHwnd(Handle);
            source.AddHook(WindowCommandHandler);
        };
    }

    #region Win32 API Stuff

    // Define the Win32 API methods we are going to use
    [DllImport("user32.dll")]
    private static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

#pragma warning disable CA2101 // Specify marshaling for P/Invoke string arguments
    [DllImport("user32.dll")]
#pragma warning restore CA2101 // Specify marshaling for P/Invoke string arguments
    private static extern bool InsertMenu(IntPtr hMenu, int wPosition, int wFlags, int wIDNewItem, string lpNewItem);

    /// Define our Constants we will use
    private const int WmSyscommand = 0x112;

    private const int MfSeparator = 0x800;
    private const int MfByposition = 0x400;

    #endregion Win32 API Stuff

    // The constants we'll use to identify our custom system menu items
    private const int SettingsSysMenuId = 1000;

    /// <summary>
    /// This is the Win32 Interop Handle for this Window
    /// </summary>
    public IntPtr Handle => new WindowInteropHelper(this).Handle;

    private IntPtr WindowCommandHandler(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
    {
        // Check if a System Command has been executed
        if (msg == WmSyscommand && wParam.ToInt32() == SettingsSysMenuId)
        {
            var aw = new AboutWindow();
            _ = aw.ShowDialog();

            handled = true;
        }

        return IntPtr.Zero;
    }

    // Quick app exit, bypassing ViewModel
    private void QuitButton_Click(object sender, RoutedEventArgs e) => Application.Current.Shutdown();

    // Make sure selected item is visible
    // Since it can be considered as a view-only issue, it's Ok to have code behind
    // For other methods: http://stackoverflow.com/questions/8827489/scroll-wpf-listbox-to-the-selecteditem-set-in-code-in-a-view-model
    private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (((ListBox)sender).SelectedItem != null)
            ((ListBox)sender).ScrollIntoView(((ListBox)sender).SelectedItem);
    }
}