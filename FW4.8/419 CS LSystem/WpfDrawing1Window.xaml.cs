// Drawing of a LSystem result using WPF (1st version)
// Draws directly on the DrawingContext of a DrawingVisual added on the form at run-time
// Note the overrides of VisualChildrenCount and GetVisualChild needed in this case
//
// 2012-02-05   PV  First version.  Problem, ActualWidth/Height does not seems to be what I think it is...

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using Brushes = System.Windows.Media.Brushes;

namespace CS419
{
    /// <summary>
    /// Interaction logic for WpfDrawing1Window.xaml
    /// </summary>
    public partial class WpfDrawing1Window : Window
    {
        private IEnumerable<char> _s;
        private int _angle;

        public WpfDrawing1Window()
        {
            InitializeComponent();
        }

        public void DrawString(string title, ref IEnumerable<char> s, int angle)
        {
            _s = s;
            _angle = angle;
            Title = title + " - WpfDrawing1Window (Using a DrawingVisual)";
            Show();
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            myDrawingVisual.AddDrawing(myGrid.ActualWidth, myGrid.ActualHeight, _s, _angle);
        }

        protected override void OnKeyDown(System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == System.Windows.Input.Key.Escape) Close();
            base.OnKeyDown(e);
        }
    }

    public class MyVisualHost : FrameworkElement
    {
        private readonly VisualCollection _children;

        public MyVisualHost()
        {
            _children = new VisualCollection(this);
        }

        public void AddDrawing(double aw, double ah, IEnumerable<char> s, int angle)
        {
            _children.Clear();
            // In case area is too small
            if (aw <= 1 || ah <= 1) return;

            DrawingVisual drawingVisual = new DrawingVisual();
            // Retrieve the DrawingContext in order to create new drawing content.
            using (DrawingContext dc = drawingVisual.RenderOpen())
            {
                Wpf1LSystemRenderer wr = new Wpf1LSystemRenderer(s, angle);
                wr.Rend(dc, aw, ah);
            }
            _children.Add(drawingVisual);
        }

        // Provide a required override for the VisualChildrenCount property.
        protected override int VisualChildrenCount
        {
            get { return _children.Count; }
        }

        // Provide a required override for the GetVisualChild method.
        protected override Visual GetVisualChild(int index)
        {
            if (index < 0 || index >= _children.Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            return _children[index];
        }

        // Implementation of renderer for WFP1
        private class Wpf1LSystemRenderer : LSystemRenderer
        {
            private DrawingContext _dc;
            private readonly Pen blackPen = new Pen(Brushes.Black, 2);

            public Wpf1LSystemRenderer(IEnumerable<char> s, int angle) : base(s, angle)
            {
            }

            public void Rend(DrawingContext dc, double rendingWidth, double rendingHeight)
            {
                _dc = dc;
                Rend(rendingWidth, rendingHeight);
            }

            protected override void RendLine(double x1, double y1, double x2, double y2, bool isStroke)
            {
                if (isStroke)
                    _dc.DrawLine(blackPen, new Point(x1, y1), new Point(x2, y2));
            }
        }
    }
}