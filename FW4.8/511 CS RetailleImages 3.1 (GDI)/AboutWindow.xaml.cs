﻿// Standard About Window for Retaille Images
//
// 2013-07-21   PV  First version

using System;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media.Imaging;

namespace RI3
{
    /// <summary>
    /// Interaction logic for AboutWindow.xaml
    /// </summary>
    public partial class AboutWindow : Window
    {
        public AboutWindow()
        {
            InitializeComponent();

            var myAssembly = System.Reflection.Assembly.GetExecutingAssembly();
            var aTitleAttr = (AssemblyTitleAttribute)AssemblyTitleAttribute.GetCustomAttribute(myAssembly, typeof(AssemblyTitleAttribute));
            var aDescAttr = (AssemblyDescriptionAttribute)AssemblyDescriptionAttribute.GetCustomAttribute(myAssembly, typeof(AssemblyDescriptionAttribute));
            string sAssemblyVersion = myAssembly.GetName().Version.ToString();
            var aCopyrightAttr = (AssemblyCopyrightAttribute)AssemblyTitleAttribute.GetCustomAttribute(myAssembly, typeof(AssemblyCopyrightAttribute));

            AssemblyTitle.Text = aTitleAttr.Title;
            AssemblyDescription.Text = aDescAttr.Description;
            AssemblyVersion.Text = "Version " + sAssemblyVersion;
            AssemblyCopyright.Text = aCopyrightAttr.Copyright;
        }

        private void OKButton_Click(object sender, RoutedEventArgs e) => Close();
    }

    /// <summary>
    /// Simple extension for ico, let you choose icon with specific size.
    /// Usage sample: Image Stretch="None" Source="{common:Icon /ControlsTester;component/icons/custom-reports.ico, 16}"
    /// Or: Image Source="{common:Icon Source={Binding IconResource},Size=16} "
    /// </summary>
    public class IconExtension : MarkupExtension
    {
        private string source;

        public string Source
        {
            get => source;

            set =>
                // Have to make full pack URI from short form, so System.Uri can regognize it.
                source = "pack://application:,,," + value;
        }

        public int Size { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var decoder = BitmapDecoder.Create(new Uri(Source), BitmapCreateOptions.DelayCreation, BitmapCacheOption.OnDemand);

            var result = decoder.Frames.SingleOrDefault(f => f.Width == Size);
            if (result == default(BitmapFrame))
                result = decoder.Frames.OrderBy(f => f.Width).First();
            return result;
        }

        public IconExtension(string source, int size)
        {
            Source = source;
            Size = size;
        }

        public IconExtension()
        {
        }
    }
}