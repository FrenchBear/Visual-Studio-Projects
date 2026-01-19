// RI3 - Batch Pics Resize Tool v3.0 (WPF)
// Version 3.0, uses WPF to resize bitmaps, but don't support EXIF properties
//
// 2013-07-14   PV      First version 3, rewrite in C#, WPF and MVVM
// 2021-09-26   PV      VS2022; Net6
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12
// 2024-11-15	PV		Net9 C#13
// 2026-01-19	PV		Net10 C#14

using System.Windows;
using System.Windows.Controls;

namespace CS511;

public partial class MainWindow: Window
{
    public MainWindow()
    {
        InitializeComponent();

        var m = new Model();
        var vm = new ViewModel(m, this);
        m.SetViewModel(vm);
        DataContext = vm;
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

    /*
    public void AddTrace(string s)
    {
        string s1 = s + "  " + DateTime.Now.ToString("HH:mm:ss.fff");
        Dispatcher.BeginInvoke(new Action(delegate
        {
            TracesListBox.Items.Add(s1);
            TracesListBox.ScrollIntoView(TracesListBox.Items[TracesListBox.Items.Count - 1]);
        }
        ));
    }
    */
}
