﻿// Drawing of a LSystemProcessor result using WPF (2nd version)
// Creates a PathFigure, and places it on an existing PathGeometry on the interface
// Very simple, since it does stretching and centering automatically.
// 2012-02-05   PV  First version

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace CS419
{
    /// <summary>
    /// Interaction logic for WpfDrawing2Window.xaml
    /// </summary>
    public partial class WpfDrawing2Window : Window
    {
        public WpfDrawing2Window() => InitializeComponent();

        protected override void OnKeyDown(System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Escape) Close();
            base.OnKeyDown(e);
        }

        public WpfDrawing2Window(string title, IEnumerable<char> s, int angle)
            : this()
        {
            Title = title + " - WpfDrawing2Window (Using PathGeometry and PathFigure)";
            var wr = new Wpf2LSystemRenderer(s, angle);
            wr.Rend(0, 0, out PathFigure pf, out Rect r);
            double maxExtent = Math.Max(r.Width, r.Height);
            myGeometryDrawing.Pen = new Pen(Brushes.Black, Math.Sqrt(maxExtent) / 10.0);
            myPathGeometry.Figures.Add(pf);      // Generate PathFigure and add it to screen control
        }

        // Implementation of renderer for WFP2
        private class Wpf2LSystemRenderer : LSystemRenderer
        {
            private PathFigure _pf;

            public Wpf2LSystemRenderer(IEnumerable<char> s, int angle) : base(s, angle)
            {
            }

            public void Rend(double rendingWidth, double rendingHeight, out PathFigure pf, out Rect r)
            {
                pf = new PathFigure();
                _pf = pf;
                r = base.Rend(rendingWidth, rendingHeight);
            }

            protected override void RendLine(double x1, double y1, double x2, double y2, bool isStroke)
            {
                var ls = new LineSegment(new Point(x2, y2), isStroke)
                {
                    IsSmoothJoin = true
                };
                _pf.Segments.Add(ls);
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e) => myGeometryDrawing.Brush = Brushes.Orange;

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e) => myGeometryDrawing.Brush = Brushes.Transparent;
    }
}