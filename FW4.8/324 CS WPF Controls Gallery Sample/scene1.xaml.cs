﻿#pragma warning disable IDE1006 // Naming Styles

namespace SdkXamlBrowser
{
    using System;
    using System.IO;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Markup;

    public partial class Scene1
    {
        public bool RealTimeUpdate = true;

        public Scene1()
        {
        }

        private void HandleSelectionChanged(object sender, SelectionChangedEventArgs args)
        {
            if (sender == null)
                return;

            Details.DataContext = (sender as ListBox).DataContext;
        }

        protected void HandleTextChanged(object sender, TextChangedEventArgs me)
        {
            if (RealTimeUpdate) ParseCurrentBuffer();
        }

        private void ParseCurrentBuffer()
        {
            try
            {
                var ms = new MemoryStream();
                var sw = new StreamWriter(ms);
                string str = TextBox1.Text;
                sw.Write(str);
                sw.Flush();
                ms.Flush();
                ms.Position = 0;
                try
                {
                    object content = XamlReader.Load(ms);
                    if (content != null)
                    {
                        cc.Children.Clear();
                        cc.Children.Add((UIElement)content);
                    }
                    TextBox1.Foreground = System.Windows.Media.Brushes.Black;
                    ErrorText.Text = "";
                }
                catch (XamlParseException xpe)
                {
                    TextBox1.Foreground = System.Windows.Media.Brushes.Red;
                    TextBox1.TextWrapping = TextWrapping.Wrap;
                    ErrorText.Text = xpe.Message.ToString();
                }
            }
            catch (Exception)
            {
                return;
            }
        }

        protected void onClickParseButton(object sender, RoutedEventArgs args) => ParseCurrentBuffer();

        protected void ShowPreview(object sender, RoutedEventArgs args)
        {
            PreviewRow.Height = new GridLength(1, GridUnitType.Star);
            CodeRow.Height = new GridLength(0);
        }

        protected void ShowCode(object sender, RoutedEventArgs args)
        {
            PreviewRow.Height = new GridLength(0);
            CodeRow.Height = new GridLength(1, GridUnitType.Star);
        }

        protected void ShowSplit(object sender, RoutedEventArgs args)
        {
            PreviewRow.Height = new GridLength(1, GridUnitType.Star);
            CodeRow.Height = new GridLength(1, GridUnitType.Star);
        }
    }
}