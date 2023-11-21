// LSystemRendering class
// Abstract implementation of a LSystem renderer, independent from rending technology (WPF, GDI, ...)
//
// 2012-02-05	PV		First version
// 2021-09-23	PV		VS2022; Net6
// 2021-12-07	PV		Centered rendering
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using System.Windows;

namespace CS419;

public abstract class LSystemRenderer
{
    private readonly IEnumerable<char> _s;
    private readonly int _angle;

    protected LSystemRenderer(IEnumerable<char> s, int angle)
    {
        _s = s;
        _angle = angle;
    }

    private struct AngleAndPosition
    {
        public double Px;                       // Current X
        public double Py;                       // Current Y
        public double Angle;                    // Angle in radians controlled by + and -
        public double DirectAngle;              // Angle in radians controlled by / and \
        public double SegmentLength;            // Stroke length
        public int color;                       // 0=black, the rest in undefined
    }

    // Rend LSystem using dimensions indicated (scale drawing accordingly)
    // If rendingWidth == rendingHeight == 0 then there is no scaling pass
    public Rect Rend(double rendingWidth, double rendingHeight)
    {
        var pass = 0;                           // pass=0: measure, pass=1: drawing

        var r = 0.0;                         // Final scale factor; declare here to avoid compiler complaining about a variable used before its assignment

        var x0 = 0.0;                        // xmin for pass2
        var y0 = 0.0;                        // ymin for pass2

        if (rendingHeight == 0 && rendingWidth == 0)
        {
            pass = 1;
            r = 1.0;
        }

        var sb = new StringBuilder();
        foreach (var c in _s)
            sb.Append(c);
        var ss = sb.ToString();

        for (; ; pass++)
        {
            AngleAndPosition ap = new()
            {
                SegmentLength = 10.0
            };     // All fields start at 0.0

            Stack<AngleAndPosition> apStack = new();

            double nx;                          // New X position
            double ny;                          // New Y position

            var angleIncrement = 2 * Math.PI / _angle;

            var generalOrientation = 1;         // General orientation, changed to -1 by !
            var escapeChar = '\0';             // Different than \0 when processing @ or \ or / escape sequence
            var escapeOptions = "";          // Accumulated I and or Q for @ sequence
            var argumentNum = "";            // Buffer to accumulate @, \ and / numeric argument

            double rx;                          // Scale factor on x axis
            double ry;                          // Scale factor on y axis

            var xmax = 0.0;                  // Extent measured during pass 0 to calculate scale factors, or pass 1 to return final extent
            var xmin = 0.0;
            var ymax = 0.0;
            var ymin = 0.0;

            if (pass == 0)
                r = 0;

            var sw = Stopwatch.StartNew();

            // Step 1, calculate the extent (pass==0) or draw (pass==1)
            for (var i = 0; i < ss.Length; i++)
            {
                var c = ss[i];

                // General timeout at 2s for measuring or rendering
                if (sw.ElapsedMilliseconds > 2000)
                    break;

                if (escapeChar != '\0')
                {
                    if (c is >= '0' and <= '9' || c == '.')
                    {
                        argumentNum += c;
                        continue;
                    }
                    switch (escapeChar)
                    {
                        case '/':
                            ap.DirectAngle -= generalOrientation * double.Parse(argumentNum, CultureInfo.InvariantCulture) * Math.PI / 180;
                            escapeChar = '\0';
                            break;

                        case '\\':
                            ap.DirectAngle += generalOrientation * double.Parse(argumentNum, CultureInfo.InvariantCulture) * Math.PI / 180;
                            escapeChar = '\0';
                            break;

                        case '@':
                            if (c == 'I' || c == 'Q')
                            {
                                escapeOptions += c;
                                continue;
                            }
                            var f = double.Parse(argumentNum, CultureInfo.InvariantCulture);
                            if (escapeOptions == "IQ")
                                f = 1.0 / Math.Sqrt(f);
                            else if (escapeOptions == "QI")
                                f = Math.Sqrt(1.0 / f);
                            else if (escapeOptions == "I")
                                f = 1.0 / f;
                            else if (escapeOptions == "Q")
                                f = Math.Sqrt(f);
                            ap.SegmentLength *= f;
                            escapeChar = '\0';
                            break;

                        case 'C':
                            ap.color = int.Parse(argumentNum, CultureInfo.InvariantCulture);
                            escapeChar = '\0';
                            break;
                    }
                }

                switch (c)
                {
                    case '+':
                        ap.Angle += generalOrientation * angleIncrement;
                        break;

                    case '-':
                        ap.Angle -= generalOrientation * angleIncrement;
                        break;

                    case '|':
                        if (_angle % 2 == 0)
                            ap.Angle += Math.PI;
                        else
                            ap.Angle += generalOrientation * (int)(_angle / 2) * angleIncrement;
                        break;

                    case '!':
                        generalOrientation = -generalOrientation;
                        break;

                    case '\\':
                        escapeChar = c;
                        argumentNum = "";
                        break;

                    case '/':
                        escapeChar = c;
                        argumentNum = "";
                        break;

                    case 'C':
                        escapeChar = c;
                        argumentNum = "";
                        break;

                    case '@':
                        escapeChar = c;
                        argumentNum = "";
                        escapeOptions = "";
                        break;

                    case '[':
                        apStack.Push(ap);
                        break;

                    case ']':
                        if (apStack.Count > 0)
                        {
                            ap = apStack.Pop();
                            // Draw a fake unstroked segment to restore correctly current position for rendering subsystems
                            // that memorize current position
                            if (pass == 1)
                                RendLine(0, 0, (ap.Px - x0) * r, (ap.Py - y0) * r, false, ap.color);
                        }
                        break;

                    case 'F':
                    case 'G':
                        nx = ap.Px + ap.SegmentLength * Math.Cos(ap.Angle);
                        ny = ap.Py + ap.SegmentLength * Math.Sin(ap.Angle);
                        xmax = Math.Max(xmax, nx);
                        ymax = Math.Max(ymax, ny);
                        xmin = Math.Min(xmin, nx);
                        ymin = Math.Min(ymin, ny);
                        if (pass == 1)
                            RendLine((ap.Px - x0) * r, (ap.Py - y0) * r, (nx - x0) * r, (ny - y0) * r, c == 'F', ap.color);
                        ap.Px = nx;
                        ap.Py = ny;
                        break;

                    case 'D':
                    case 'M':
                        nx = ap.Px + ap.SegmentLength * Math.Cos(ap.DirectAngle);
                        ny = ap.Py + ap.SegmentLength * Math.Sin(ap.DirectAngle);
                        xmax = Math.Max(xmax, nx);
                        ymax = Math.Max(ymax, ny);
                        xmin = Math.Min(xmin, nx);
                        ymin = Math.Min(ymin, ny);
                        if (pass == 1)
                            RendLine((ap.Px - x0) * r, (ap.Py - y0) * r, (nx - x0) * r, (ny - y0) * r, c == 'D', ap.color);
                        ap.Px = nx;
                        ap.Py = ny;
                        break;
                }
            }

            // Pass 1 is finished here
            if (pass == 1)
                return new Rect(xmin, ymin, xmax - xmin, ymax - ymin);

            // Pass 0 is continuing, caclulate scale factor
            if (Math.Abs(xmax - xmin) < 1e-8)
            {
                rx = 100000;
            }
            else
            {
                rx = rendingWidth / (1.1 * (xmax - xmin));
            }
            if (Math.Abs(ymax - ymin) < 1e-8)
            {
                ry = 100000;
            }
            else
            {
                ry = rendingHeight / (1.1 * (ymax - ymin));
            }
            r = Math.Min(rx, ry);
            x0 = xmin + (xmax - xmin - rendingWidth / r) / 2;
            y0 = ymin + (ymax - ymin - rendingHeight / r) / 2;
        }
    }

    // Must be overriden in derived classes, depending on technology
    protected abstract void RendLine(double x1, double y1, double x2, double y2, bool isStroke, int color);
}
