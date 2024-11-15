// Drawing of a LSystemProcessor result using WPF (3rd version)
// Uses a StreamGeometry
//
// 2012-02-26	PV		First version
// 2021-09-23	PV		VS2022; Net6
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12
// 2024-11-15	PV		Net9 C#13

using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;

namespace CS419;

public partial class WpfDrawing3Window: Window
{
    public WpfDrawing3Window() => InitializeComponent();

    protected override void OnKeyDown(System.Windows.Input.KeyEventArgs e)
    {
        if (e.Key == System.Windows.Input.Key.Escape)
            Close();
        base.OnKeyDown(e);
    }

    public WpfDrawing3Window(string title, IEnumerable<char> s, int angle)
        : this()
    {
        Title = title + " - WpfDrawing3Window (Using StreamGeometry)";
        Wpf3LSystemRenderer wr = new(s, angle);
        wr.Rend(0, 0, out var g, out var r);
        var maxExtent = Math.Max(r.Width, r.Height);
        myGeometryDrawing.Pen = new Pen(Brushes.Black, Math.Sqrt(maxExtent) / 10.0);
        myGeometryDrawing.Geometry = g;
    }

    // Implementation of renderer for WFP3
    private class Wpf3LSystemRenderer(IEnumerable<char> s, int angle): LSystemRenderer(s, angle)
    {
        private StreamGeometryContext _context;

        public void Rend(double rendingWidth, double rendingHeight, out StreamGeometry g, out Rect r)
        {
            g = new StreamGeometry();
            using var context = g.Open();
            _context = context;
            context.BeginFigure(new Point(0, 0), false, false);
            r = Rend(rendingWidth, rendingHeight);
            _context = null;
        }

        protected override void RendLine(double x1, double y1, double x2, double y2, bool isStroked, int color)
            => _context.LineTo(new Point(x2, y2), isStroked, true);
    }
}
