﻿// ED850
// Simple editor for MS-Dos files
// 2014-03-11   PV
// 2014-03-13   PV  First release version

using System;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Ed850
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static RoutedUICommand About = new RoutedUICommand("À propos de...", "About", typeof(MainWindow), new InputGestureCollection() { new KeyGesture(Key.I, ModifierKeys.Control) });

        private bool IsDirty;
        private readonly DataBag b;

        public MainWindow()
        {
            InitializeComponent();

            b = new DataBag();
            DataContext = b;

            CommandBindings.Add(new CommandBinding(About, AboutExecuted));
        }

        private void NewExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var z = CanContinue();
            if (!z) return;

            MyTextBox.Text = "";
            IsDirty = false;
            b.FileName = null;
        }

        private void OpenExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var z = CanContinue();
            if (!z) return;

            // Configure open file dialog box
            var dlg = new Microsoft.Win32.OpenFileDialog
            {
                FileName = "", // Default file name
                DefaultExt = ".bat", // Default file extension
                Filter = "Commandes (.bat,*.cmd)|*.bat;*.cmd|Tous les fichiers (*.*)|*.*"
            };

            // Show open file dialog box
            bool? result = dlg.ShowDialog();

            // Process open file dialog box results
            if (result == true)
            {
                try
                {
                    using (var sr = new StreamReader(dlg.FileName, Encoding.GetEncoding(850)))
                    {
                        MyTextBox.Text = sr.ReadToEnd();
                        IsDirty = false;
                        b.FileName = dlg.FileName;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Une erreur est survenue lors de l'ouverture du fichier " + dlg.FileName + ": " + ex.Message, "ED850", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
        }

        private void AboutExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            var aw = new AboutWindow();
            aw.ShowDialog();
        }

        private void CloseCanExecute(object sender, CanExecuteRoutedEventArgs e) => e.CanExecute = true;

        private void CloseExecuted(object sender, ExecutedRoutedEventArgs e) => Close();

        private void AnyTextBox_TextChanged(object sender, TextChangedEventArgs e) => IsDirty = true;

        private void SaveExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (b.FileName == null)
                SaveAsExecuted(sender, e);
            else
            {
                try
                {
                    using (var sw = new StreamWriter(b.FileName, false, Encoding.GetEncoding(850)))
                    {
                        sw.Write(MyTextBox.Text);
                        IsDirty = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Une erreur est survenue lors de l'écriture du fichier " + b.FileName + ": " + ex.Message, "ED850", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
            }
        }

        private void SaveAsExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            // Configure save file dialog box
            var dlg = new Microsoft.Win32.SaveFileDialog
            {
                FileName = "", // Default file name
                DefaultExt = ".bat", // Default file extension
                Filter = "Commandes (.bat,*.cmd)|*.bat;*.cmd|Tous les fichiers (*.*)|*.*"  // Filter files by extension
            };

            // Show save file dialog box
            bool? result = dlg.ShowDialog();

            // Process save file dialog box results
            if (result == true)
            {
                // Save document
                b.FileName = dlg.FileName;
                SaveExecuted(sender, e);
            }
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (IsDirty)
                e.Cancel = !CanContinue();
            else
                base.OnClosing(e);
        }

        private bool CanContinue()
        {
            if (IsDirty)
            {
                var r = MessageBox.Show("Le texte a été modifié mais pas enregistré.\r\nVoulez-vous conserver ces changements?", "ED850", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.Yes, MessageBoxOptions.None);
                return MessageBoxResult.No == r;
            }
            else
                return true;
        }
    }

    public class DataBag : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private string _FileName;

        public string FileName
        {
            get => _FileName;
            set
            {
                if (_FileName != value)
                {
                    _FileName = value;
                    NotifyPropertyChanged("FileName");
                    NotifyPropertyChanged("WindowCaption");
                }
            }
        }

        public string WindowCaption
        {
            get
            {
                if (_FileName == null)
                    return "ED850 - (Nouveau)";
                else
                    return "ED850 - " + _FileName;
            }
        }
    }
}