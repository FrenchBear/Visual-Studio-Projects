// 419 CS LSystem
//
// 2012-02-05   PV
// 2012-02-28   PV  Clean databinding (DataBag), support for multiple .l files
// 2021-09-23   PV  VS2022; Net6

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace CS419;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
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

    // Prepare a call to LSystemProcessor
    // Returns false in case of a problem, otherwise returns true and variables drawString and angle are filled
    private bool OkGenerate()
    {
        if (!int.TryParse(LevelTextBox.Text, out int d))
        {
            MessageBox.Show("Invalid depth", "LSystemProcessor", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            return false;
        }
        if (d < 0 || d > 20)
        {
            MessageBox.Show("Depth must be between 0 and 20", "LSystemProcessor", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            return false;
        }

        if (SystemsListBox.SelectedItem is not SourceSystem ss)
        {
            MessageBox.Show("Select a system first", "LSystemProcessor", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            return false;
        }

        angle = ss.Angle;
        if (ss.Angle == 0)
        {
            MessageBox.Show("Can't accept Angle=0", "LSystemProcessor", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            return false;
        }

        Dictionary<char, string> rules = new();
        foreach (string s in ss.Rules.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries))
        {
            char c = s.ToUpperInvariant().Split('=')[0][0];
            string r = s.ToUpperInvariant().Split('=')[1];
            if (rules.ContainsKey(c))
                rules[c] += r;
            else
                rules.Add(c, r);
        }
        drawString = LSystemProcessor.LSystemIterator(d, ss.Axiom, rules);

        // Show the 1st 1000 chars of out string
        int i = 0;
        StringBuilder sb = new();
        foreach (char c in drawString)
        {
            sb.Append(c);
            i++;
            if (i > 1000) break;
        }
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

    private void ExitCommand_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void SourceFileComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
    {
        string file = e.AddedItems[0].ToString();
        b.SelectFile(file);
    }

    private void HelpCommand_Click(object sender, RoutedEventArgs e)
    {
        Window w = new HelpWindow();
        w.Show();
    }
}