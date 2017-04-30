// RI3 - Batch Pics Resize Tool v3
//
// 2013-07-14   PV  First version 3, rewrite in C#, WPF anv MVVM, Multitasking

using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace RI3
{
    public class ViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        // INotifyPropertyChanged interface
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        // Commands public interface
        public ICommand GenerateCommand { get; private set; }
        public ICommand SelectSourceFolderCommand { get; private set; }
        public ICommand SelectTargetFolderCommand { get; private set; }

        // Constructor
        public ViewModel(Model m, MainWindow w)
        {
            model = m;
            window = w;

            // Binding commands with behavior
            GenerateCommand = new RelayCommand<object>(GenerateExecute, CanGenerate);
            SelectSourceFolderCommand = new RelayCommand<object>(SelectSourceFolderExecute);
            SelectTargetFolderCommand = new RelayCommand<object>(SelectTargetFolderExecute);

            // Button caption
            GenerateButtonCaption = GenerateActionCaption;
        }


        // Access to Model and window
        private Model model;
        private MainWindow window;


        // Interface strings
        const string GenerateActionCaption = "_Générer";
        const string StopActionCaption = "St_op";


        // Commands private implementation
        private CancellationTokenSource cts;
        private void GenerateExecute(object parameter)
        {
            if (GenerateButtonCaption == GenerateActionCaption)
            {
                tracesList.Clear();
                GenerateButtonCaption = StopActionCaption;
                GenerateProgressValue = 0.0;
                cts = new CancellationTokenSource();
                IProgress<ProgressInfo> progress = new Progress<ProgressInfo>(d => UpdateGenerateProgressValue(d));
                model.DoGenerate(cts.Token, progress);
            }
            else
            {
                GenerateButtonCaption = GenerateActionCaption;
                cts.Cancel();
                AddTrace("Génération interrompue");
            }
        }

        private bool CanGenerate(object parameter)
        {
            return SourceFolder != null && SourceFolder != "" && TargetFolder != null && TargetFolder != "" &&
                   SourceFolder != TargetFolder && IsValid(window);
        }

        // Validate all dependency objects in a window, from http://msdn.microsoft.com/en-us/library/aa969773.aspx
        private bool IsValid(DependencyObject node)
        {
            // Check if dependency object was passed
            if (node != null)
            {
                // Check if dependency object is valid.
                // NOTE: Validation.GetHasError works for controls that have validation rules attached 
                bool isValid = !Validation.GetHasError(node);
                if (!isValid)
                {
                    // If the dependency object is invalid, and it can receive the focus,
                    // set the focus
                    // No: prevent moving to another field!!
                    //if (node is IInputElement) Keyboard.Focus((IInputElement)node);
                    return false;
                }
            }

            // If this dependency object is valid, check all child dependency objects
            foreach (object subnode in LogicalTreeHelper.GetChildren(node))
                if (subnode is DependencyObject)
                    // If a child dependency object is invalid, return false immediately, otherwise keep checking
                    if (!IsValid((DependencyObject)subnode)) return false;

            // All dependency objects are valid
            return true;
        }

        private void UpdateGenerateProgressValue(ProgressInfo t)
        {
            GenerateProgressValue = (100.0 * t.Index) / t.Total;
            GenerateProgressText = string.Format("{0} / {1}", t.Index, t.Total);
            if (t.FileName != null)
            {
                AddTrace(t.FileName);
            }

            if (t.Index == t.Total && GenerateButtonCaption != GenerateActionCaption)
            {
                GenerateButtonCaption = GenerateActionCaption;
                AddTrace("Fin de la génération");
            }
        }

        private void AddTrace(string s)
        {
            TracesList.Add(s);
            TraceSelectedIndex = TracesList.Count - 1;
            // Event SelectionChanged in code behind view will make sure selected item is visible
        }


        private void SelectSourceFolderExecute(object parameter)
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            dialog.SelectedPath = SourceFolder;
            System.Windows.Forms.DialogResult result = dialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
                SourceFolder = dialog.SelectedPath;
        }


        private void SelectTargetFolderExecute(object parameter)
        {
            var dialog = new System.Windows.Forms.FolderBrowserDialog();
            if (TargetFolder != null && TargetFolder != "" && Directory.Exists(TargetFolder))
                dialog.SelectedPath = TargetFolder;
            else
                dialog.SelectedPath = SourceFolder;
            System.Windows.Forms.DialogResult result = dialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
                TargetFolder = dialog.SelectedPath;
        }


        // Properties for view binding
        private string generateButtonCaption = "";
        public string GenerateButtonCaption
        {
            get { return generateButtonCaption; }
            set
            {
                if (value != generateButtonCaption)
                {
                    generateButtonCaption = value;
                    NotifyPropertyChanged("GenerateButtonCaption");
                }
            }
        }

        public string SourceFolder
        {
            get { return model.SourceFolder; }
            set
            {
                if (value != model.SourceFolder)
                {
                    model.SourceFolder = value;
                    NotifyPropertyChanged("SourceFolder");
                }
            }
        }

        public string TargetFolder
        {
            get { return model.TargetFolder; }
            set
            {
                if (value != model.TargetFolder)
                {
                    model.TargetFolder = value;
                    NotifyPropertyChanged("TargetFolder");
                }
            }
        }

        public bool IncludeSubFolders
        {
            get { return model.IncludeSubFolders; }
            set
            {
                if (value != model.IncludeSubFolders)
                {
                    model.IncludeSubFolders = value;
                    NotifyPropertyChanged("IncludeSubFolders");
                }
            }
        }

        public int LargeSideSize
        {
            get { return model.LargeSideSize; }
            set
            {
                if (value != model.LargeSideSize)
                {
                    model.LargeSideSize = value;
                    NotifyPropertyChanged("LargeSideSize");
                }
            }
        }

        public int JpegQuality
        {
            get { return model.JpegQuality; }
            set
            {
                if (value != model.JpegQuality)
                {
                    model.JpegQuality = value;
                    NotifyPropertyChanged("JpegQuality");
                }
            }
        }

        private double generateProgressValue;
        public double GenerateProgressValue
        {
            get { return generateProgressValue; }
            set
            {
                if (value != generateProgressValue)
                {
                    generateProgressValue = value;
                    NotifyPropertyChanged("GenerateProgressValue");
                }
            }
        }

        private string generateProgressText;
        public string GenerateProgressText
        {
            get { return generateProgressText; }
            set
            {
                if (value != generateProgressText)
                {
                    generateProgressText = value;
                    NotifyPropertyChanged("GenerateProgressText");
                }
            }
        }

        private ObservableCollection<string> tracesList = new ObservableCollection<string>();
        public ObservableCollection<string> TracesList
        {
            get
            {
                return tracesList;
            }
        }

        private int traceSelectedIndex;
        public int TraceSelectedIndex
        {
            get
            {
                return traceSelectedIndex;
            }
            set
            {
                if (value != traceSelectedIndex)
                {
                    traceSelectedIndex = value;
                    NotifyPropertyChanged("TraceSelectedIndex");
                }
            }
        }


        // IDataErrorInfo
        // Gets an error message indicating what is wrong with this object.
        public string Error
        {
            get
            {
                return this["SourceFolder"] + this["TargetFolder"] + this["LargeSideSize"] + this["JpegQuality"];
            }
        }

        // Gets the error (if any) with the specified column name.
        public string this[string columnName]
        {
            get
            {
                switch (columnName)
                {
                    case "SourceFolder":
                        if (SourceFolder != null && SourceFolder != "" && !Directory.Exists(SourceFolder))
                            return "Le répertoire source n'existe pas ou est inaccessible";
                        break;

                    case "TargetFolder":
                        if (TargetFolder != null && TargetFolder != "" && !Directory.Exists(TargetFolder))
                            return "Le répertoire destination n'existe pas ou est inaccessible";
                        break;

                    case "LargeSideSize":
                        if (LargeSideSize < 50 || LargeSideSize > 3000)
                            return "Taille du grand coté invalide (doit être comprise entre 50 et 3000)";
                        break;

                    case "JpegQuality":
                        if (JpegQuality < 0 || JpegQuality > 100)
                            return "Qualité Jpeg invalide (doit être comprise entre 0 et 100)";
                        break;
                }
                return string.Empty;
            }
        }

    }

    public static class ExtensionMethods
    {
        private static Action EmptyDelegate = delegate () { };

        // Extension method to force the refresh of a UIElement
        public static void Refresh(this UIElement uiElement)
        {
            // By calling Dispatcher.Invoke, the code essentially asks the system to execute all operations that are Render or higher priority, 
            // thus the control will then render itself (drawing the new content).  Afterwards, it will then execute the provided delegate,
            // which is our empty method.
            uiElement.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
        }
    }
}
