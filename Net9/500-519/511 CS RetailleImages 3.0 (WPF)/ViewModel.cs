﻿// RI3 - Batch Pics Resize Tool v3
//
// 2013-07-14   PV      First version 3, rewrite in C#, WPF and MVVM
// 2021-09-26   PV      VS2022; Net6
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12
// 2024-11-15	PV		Net9 C#13

using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace CS511;

public class ViewModel: INotifyPropertyChanged, IDataErrorInfo, IDisposable
{
    // INotifyPropertyChanged interface
    public event PropertyChangedEventHandler PropertyChanged;

    public void NotifyPropertyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

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
    private readonly Model model;

    private readonly MainWindow window;

    //private bool isGenerateInProgress = false;

    // Interface strings
    private const string GenerateActionCaption = "Générer";

    private const string StopActionCaption = "Stop";

    // Commands private implementation
    private CancellationTokenSource cts;

    private void GenerateExecute(object parameter)
    {
        if (GenerateButtonCaption == GenerateActionCaption)
        {
            GenerateButtonCaption = StopActionCaption;
            GenerateProgressValue = 0.0;
            //isGenerateInProgress = true;
            cts = new CancellationTokenSource();
            IProgress<ProgressInfo> progress = new Progress<ProgressInfo>(UpdateGenerateProgressValue); // d => UpdateGenerateProgressValue(d)
            model.DoGenerate(cts.Token, progress);
            Debug.WriteLine("$$$$$$$$$$$$$$$$$ End of GenerateExecute");
        }
        else
        {
            GenerateButtonCaption = GenerateActionCaption;
            cts.Cancel();
            //isGenerateInProgress = false;
        }
    }

    private bool CanGenerate(object parameter) => SourceFolder != null && SourceFolder != "" && TargetFolder != null && TargetFolder != "" &&
               SourceFolder != TargetFolder && IsValid(window);

    // Validate all dependency objects in a window, from http://msdn.microsoft.com/en-us/library/aa969773.aspx
    private static bool IsValid(DependencyObject node)
    {
        // Check if dependency object was passed
        if (node != null)
        {
            // Check if dependency object is valid.
            // NOTE: Validation.GetHasError works for controls that have validation rules attached
            var isValid = !Validation.GetHasError(node);
            if (!isValid)
                // If the dependency object is invalid, and it can receive the focus,
                // set the focus
                // No: prevent moving to another field!!
                //if (node is IInputElement) Keyboard.Focus((IInputElement)node);
                return false;
        }

        // If this dependency object is valid, check all child dependency objects
        foreach (var subnode in LogicalTreeHelper.GetChildren(node))
            if (subnode is DependencyObject obj)
                // If a child dependency object is invalid, return false immediately, otherwise keep checking
                if (!IsValid(obj))
                    return false;

        // All dependency objects are valid
        return true;
    }

    private void UpdateGenerateProgressValue(ProgressInfo t)
    {
        GenerateProgressValue = 100.0 * t.Index / t.Total;
        GenerateProgressText = $"{t.Index} / {t.Total}";
        if (t.FileName != null)
            AddTrace(t.FileName);

        if (t.Index == t.Total && GenerateButtonCaption != GenerateActionCaption)
        {
            GenerateButtonCaption = GenerateActionCaption;
            //isGenerateInProgress = false;
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
        var dialog = new System.Windows.Forms.FolderBrowserDialog
        {
            SelectedPath = SourceFolder
        };
        var result = dialog.ShowDialog();
        if (result == System.Windows.Forms.DialogResult.OK)
            SourceFolder = dialog.SelectedPath;
    }

    private void SelectTargetFolderExecute(object parameter)
    {
        var dialog = new System.Windows.Forms.FolderBrowserDialog
        {
            SelectedPath = TargetFolder != null && TargetFolder != "" && Directory.Exists(TargetFolder) ? TargetFolder : SourceFolder
        };
        var result = dialog.ShowDialog();
        if (result == System.Windows.Forms.DialogResult.OK)
            TargetFolder = dialog.SelectedPath;
    }

    // IDispose
    public void Dispose()
    {
        ((IDisposable)cts).Dispose();
        GC.SuppressFinalize(this);
    }

    // Properties for view binding
    private string generateButtonCaption = "";

    public string GenerateButtonCaption
    {
        get => generateButtonCaption;
        set
        {
            if (value != generateButtonCaption)
            {
                generateButtonCaption = value;
                NotifyPropertyChanged(nameof(GenerateButtonCaption));
            }
        }
    }

    public string SourceFolder
    {
        get => model.SourceFolder;
        set
        {
            if (value != model.SourceFolder)
            {
                model.SourceFolder = value;
                NotifyPropertyChanged(nameof(SourceFolder));
            }
        }
    }

    public string TargetFolder
    {
        get => model.TargetFolder;
        set
        {
            if (value != model.TargetFolder)
            {
                model.TargetFolder = value;
                NotifyPropertyChanged(nameof(TargetFolder));
            }
        }
    }

    public int LargeSideSize
    {
        get => model.LargeSideSize;
        set
        {
            if (value != model.LargeSideSize)
            {
                model.LargeSideSize = value;
                NotifyPropertyChanged(nameof(LargeSideSize));
            }
        }
    }

    public int JpegQuality
    {
        get => model.JpegQuality;
        set
        {
            if (value != model.JpegQuality)
            {
                model.JpegQuality = value;
                NotifyPropertyChanged(nameof(JpegQuality));
            }
        }
    }

    private double generateProgressValue;

    public double GenerateProgressValue
    {
        get => generateProgressValue;
        set
        {
            if (value != generateProgressValue)
            {
                generateProgressValue = value;
                NotifyPropertyChanged(nameof(GenerateProgressValue));
            }
        }
    }

    private string generateProgressText;

    public string GenerateProgressText
    {
        get => generateProgressText;
        set
        {
            if (value != generateProgressText)
            {
                generateProgressText = value;
                NotifyPropertyChanged(nameof(GenerateProgressText));
            }
        }
    }

    public ObservableCollection<string> TracesList { get; } = [];

    private int traceSelectedIndex;

    public int TraceSelectedIndex
    {
        get => traceSelectedIndex;
        set
        {
            if (value != traceSelectedIndex)
            {
                traceSelectedIndex = value;
                NotifyPropertyChanged(nameof(TraceSelectedIndex));
            }
        }
    }

    // IDataErrorInfo
    // Gets an error message indicating what is wrong with this object.
    public string Error => this["SourceFolder"] + this["TargetFolder"] + this["LargeSideSize"] + this["JpegQuality"];

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
                    if (LargeSideSize is < 50 or > 3000)
                        return "Taille du grand coté invalide (doit être comprise entre 50 et 3000)";
                    break;

                case "JpegQuality":
                    if (JpegQuality is < 0 or > 100)
                        return "Qualité Jpeg invalide (doit être comprise entre 0 et 100)";
                    break;
            }
            return string.Empty;
        }
    }
}

public static class ExtensionMethods
{
    private static readonly Action EmptyDelegate = delegate () { };

    // Extension method to force the refresh of a UIElement
    public static void Refresh(this UIElement uiElement) =>
        // By calling Dispatcher.Invoke, the code essentially asks the system to execute all operations that are Render or higher priority,
        // thus the control will then render itself (drawing the new content).  Afterwards, it will then execute the provided delegate,
        // which is our empty method.
        uiElement.Dispatcher.Invoke(DispatcherPriority.Render, EmptyDelegate);
}
