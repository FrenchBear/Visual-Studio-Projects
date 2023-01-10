// Classe GradientButton
// Essais de dérivation d'un contrôle système
//
// 2001-01-29   PV
// 2006-10-01   PV  VS2005
// 2012-02-25   PV  VS2010
// 2021-09-18   PV  VS2022, Net6
// 2023-01-10	PV		Net7

using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

#pragma warning disable CA1050 // Declare types in namespaces
#pragma warning disable CA1822 // Mark members as static

public class GradientButton : Button
{
    internal void InitializeComponent()
    {
    }

    private Color startColor;
    private Color endColor;

    private static readonly StringFormat format = new();

    public GradientButton()
        : base()
    {
        startColor = SystemColors.InactiveCaption;
        endColor = SystemColors.ActiveCaption;
        format.Alignment = StringAlignment.Center;
        format.LineAlignment = StringAlignment.Center;
    }

    public Color EndColor
    {
        get => endColor;

        set
        {
            endColor = value;
            if (IsHandleCreated && Visible)
                Invalidate();
        }
    }

    public Color StartColor
    {
        get => startColor;

        set
        {
            startColor = value;
            if (IsHandleCreated && Visible)
                Invalidate();
        }
    }

    protected override void OnPaint(PaintEventArgs pe)
    {
        base.OnPaint(pe);

        var g = pe.Graphics;
        var clientRect = ClientRectangle;

        // On n'écrase pas les bords
        clientRect.Inflate(-1, -1);

        Brush backgroundBrush = new LinearGradientBrush(
          new Point(clientRect.X, clientRect.Y),
          new Point(clientRect.Width, clientRect.Height),
          startColor,
          endColor);

        g.FillRectangle(backgroundBrush, clientRect);
        g.DrawString(Text, Font, new SolidBrush(ForeColor),
          clientRect, format);
    }
}
