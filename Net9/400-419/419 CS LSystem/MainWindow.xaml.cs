﻿// 419 CS LSystem
//
// 2012-02-05   PV
// 2012-02-28	PV		Clean databinding (DataBag), support for multiple .l files
// 2021-09-23	PV		VS2022; Net6
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12
// 2024-11-15	PV		Net9 C#13

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace CS419;

public partial class MainWindow: Window
{
    private IEnumerable<char> drawString;
    private int angle;
    private string title;
    private readonly DataBag b;

    public MainWindow()
    {
        InitializeComponent();

        b = new DataBag();
        myGrid.DataContext = b;

        // Dragon curve
        //angle = 8;
        //const string axiom = "FX";
        //IDictionary<char, string> rules = new Dictionary<char, string> { { 'F', "" }, { 'Y', "+FX--FY+" }, { 'X', "-FX++FY-" } };
        //drawString = LSystemProcessor.LSystemString(10, axiom, rules);

        // Hilbert curve
        //angle = 4;
        //const string axiom = "X";
        //IDictionary<char, string> rules = new Dictionary<char, string> { { 'X', "-YF+XFX+FY-" }, { 'Y', "+XF-YFY-FX+" } };
        //drawString = LSystemProcessor.LSystemIterator(4, axiom, rules);
    }

    private static readonly char[] CRandLF = ['\r', '\n'];

    // Prepare a call to LSystemProcessor
    // Returns false in case of a problem, otherwise returns true and variables drawString and angle are filled
    private bool OkGenerate()
    {
        if (!int.TryParse(LevelTextBox.Text, out var d))
        {
            _ = MessageBox.Show("Invalid depth", "LSystemProcessor", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            return false;
        }
        if (d is < 0 or > 20)
        {
            _ = MessageBox.Show("Depth must be between 0 and 20", "LSystemProcessor", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            return false;
        }

        if (SystemsListBox.SelectedItem is not SourceSystem ss)
        {
            _ = MessageBox.Show("Select a system first", "LSystemProcessor", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            return false;
        }

        angle = ss.Angle;
        if (ss.Angle == 0)
        {
            _ = MessageBox.Show("Can't accept Angle=0", "LSystemProcessor", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            return false;
        }

        Dictionary<char, string> rules = [];
        foreach (var s in ss.Rules.Split(CRandLF, StringSplitOptions.RemoveEmptyEntries))
        {
            var c = s.ToUpperInvariant().Split('=')[0][0];
            var r = s.ToUpperInvariant().Split('=')[1];
            if (!rules.TryAdd(c, r))
                rules[c] += r;
        }
        drawString = LSystemProcessor.LSystemIterator(d, ss.Axiom, rules);

        // Show the 1st 1000 chars of out string
        StringBuilder sb = new();
        //foreach (char c in drawString)
        for (var i = 0; i < sb.Length && i < 1000; i++)
            sb.Append(sb[i]);
        OutStringTextBox.Text = sb.ToString();

        // For rendering window title
        title = ss.Name + " Level " + LevelTextBox.Text;

        return true;
    }

    private void GDIDrawingButton_Click(object sender, RoutedEventArgs e)
    {
        if (OkGenerate())
        {
            GdiDrawingForm f = new();
            f.DrawString(title, ref drawString, angle);
        }
    }

    private void WPFDrawing1Button_Click(object sender, RoutedEventArgs e)
    {
        if (OkGenerate())
        {
            WpfDrawing1Window w = new();
            w.DrawString(title, ref drawString, angle);
        }
    }

    private void WPFDrawing2Button_Click(object sender, RoutedEventArgs e)
    {
        if (OkGenerate())
        {
            WpfDrawing2Window w = new(title, drawString, angle);
            w.Show();
        }
    }

    private void WPFDrawing3Button_Click(object sender, RoutedEventArgs e)
    {
        if (OkGenerate())
        {
            WpfDrawing3Window w = new(title, drawString, angle);
            w.Show();
        }
    }

    private void ExitCommand_Click(object sender, RoutedEventArgs e) => Close();

    private void SourceFileComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
    {
        var file = e.AddedItems[0].ToString();
        b.SelectFile(file);
    }

    private void HelpCommand_Click(object sender, RoutedEventArgs e)
    {
        Window w = new HelpWindow();
        w.Show();
    }
}
