// RI3 - Batch Pics Resize Tool v3.0 (WPF)
// Version 3.0, uses WPF to resize bitmaps, but don't support EXIF properties
//
// 2013-07-14   PV  First version 3, rewrite in C#, WPF anv MVVM

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RI3
{

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
        }

        // Quick app exit, bypassing ViewModel
        private void QuitButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

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
}
