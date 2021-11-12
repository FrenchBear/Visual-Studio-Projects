﻿// AboutWindow
// Standard About form for ED850
//
// 2014-03-13   PV
// 2021-09-26   PV      VS2022; Net6

using System.Reflection;
using System.Windows;

namespace Ed850;

/// <summary>
/// Interaction logic for AboutWindow.xaml
/// </summary>
public partial class AboutWindow : Window
{
    public AboutWindow()
    {
        InitializeComponent();

        Assembly myAssembly = Assembly.GetExecutingAssembly();
        AssemblyTitleAttribute aTitleAttr = (AssemblyTitleAttribute)System.Attribute.GetCustomAttribute(myAssembly, typeof(AssemblyTitleAttribute));
        AssemblyDescriptionAttribute aDescAttr = (AssemblyDescriptionAttribute)System.Attribute.GetCustomAttribute(myAssembly, typeof(AssemblyDescriptionAttribute));
        string sAssemblyVersion = myAssembly.GetName().Version.ToString();
        AssemblyCopyrightAttribute aCopyrightAttr = (AssemblyCopyrightAttribute)System.Attribute.GetCustomAttribute(myAssembly, typeof(AssemblyCopyrightAttribute));

        AssemblyTitle.Text = aTitleAttr.Title;
        AssemblyDescription.Text = aDescAttr.Description;
        AssemblyVersion.Text = "Version " + sAssemblyVersion;
        AssemblyCopyright.Text = aCopyrightAttr.Copyright;
    }

    private void OKButton_Click(object sender, RoutedEventArgs e) => Close();
}