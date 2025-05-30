﻿// AboutWindow
// Standard About form for ED850
//
// 2014-03-13   PV
// 2021-09-26   PV      VS2022; Net6
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12
// 2024-11-15	PV		Net9 C#13

using System.Reflection;
using System.Windows;

namespace Ed850;

public partial class AboutWindow: Window
{
    public AboutWindow()
    {
        InitializeComponent();

        var myAssembly = Assembly.GetExecutingAssembly();
        var aTitleAttr = (AssemblyTitleAttribute)System.Attribute.GetCustomAttribute(myAssembly, typeof(AssemblyTitleAttribute));
        var aDescAttr = (AssemblyDescriptionAttribute)System.Attribute.GetCustomAttribute(myAssembly, typeof(AssemblyDescriptionAttribute));
        var sAssemblyVersion = myAssembly.GetName().Version.ToString();
        var aCopyrightAttr = (AssemblyCopyrightAttribute)System.Attribute.GetCustomAttribute(myAssembly, typeof(AssemblyCopyrightAttribute));

        AssemblyTitle.Text = aTitleAttr.Title;
        AssemblyDescription.Text = aDescAttr.Description;
        AssemblyVersion.Text = "Version " + sAssemblyVersion;
        AssemblyCopyright.Text = aCopyrightAttr.Copyright;
    }

    private void OKButton_Click(object sender, RoutedEventArgs e) => Close();
}
