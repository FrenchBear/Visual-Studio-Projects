// Drawing of a LSystem result using WPF (1st version)
// Draws directly on the DrawingContext of a DrawingVisual added on the form at run-time
// Note the overrides of VisualChildrenCount and GetVisualChild needed in this case
//
// 2012-02-05	PV		First version.  Problem, ActualWidth/Height does not seems to be what I think it is...
// 2021-09-23	PV		VS2022; Net6
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using Brushes = System.Windows.Media.Brushes;

namespace CS419;

public partial class WpfDrawing1Window: Window
{
    private IEnumerable<char> _s;
    private int _angle;

    public WpfDrawing1Window() => InitializeComponent();

    public void DrawString(string title, ref IEnumerable<char> s, int angle)
    {
        _s = s;
        _angle = angle;
        Title = title + " - WpfDrawing1Window (Using a DrawingVisual)";
        Show();
    }

    private void Window_SizeChanged(object sender, SizeChangedEventArgs e) => myDrawingVisual.AddDrawing(myGrid.ActualWidth, myGrid.ActualHeight, _s, _angle);

    protected override void OnKeyDown(System.Windows.Input.KeyEventArgs e)
    {
        if (e.Key == System.Windows.Input.Key.Escape)
            Close();
        base.OnKeyDown(e);
    }
}

public class MyVisualHost: FrameworkElement
{
    private readonly VisualCollection _children;

    public MyVisualHost() => _children = new VisualCollection(this);

    public void AddDrawing(double aw, double ah, IEnumerable<char> s, int angle)
    {
        _children.Clear();
        // In case area is too small
        if (aw <= 1 || ah <= 1)
            return;

        DrawingVisual drawingVisual = new();
        // Retrieve the DrawingContext in order to create new drawing content.
        using (var dc = drawingVisual.RenderOpen())
        {
            Wpf1LSystemRenderer wr = new(s, angle);
            wr.Rend(dc, aw, ah);
        }
        _ = _children.Add(drawingVisual);
    }

    // Provide a required override for the VisualChildrenCount property.
    protected override int VisualChildrenCount => _children.Count;

    // Provide a required override for the GetVisualChild method.
    protected override Visual GetVisualChild(int index) => index < 0 || index >= _children.Count ? throw new ArgumentOutOfRangeException(nameof(index)) : _children[index];

    // Implementation of renderer for WFP1
    private class Wpf1LSystemRenderer(IEnumerable<char> s, int angle): LSystemRenderer(s, angle)
    {
        private DrawingContext _dc;
        private readonly Pen blackPen = new(Brushes.Black, 2);

        public void Rend(DrawingContext dc, double rendingWidth, double rendingHeight)
        {
            _dc = dc;
            _ = Rend(rendingWidth, rendingHeight);
        }

        protected override void RendLine(double x1, double y1, double x2, double y2, bool isStroke, int color)
        {
            if (isStroke)
                _dc.DrawLine(blackPen, new Point(x1, y1), new Point(x2, y2));
        }
    }
}
