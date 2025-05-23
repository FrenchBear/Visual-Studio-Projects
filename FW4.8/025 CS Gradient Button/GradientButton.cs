// Classe GradientButton
// Essais de dérivation d'un contrôle système
// 2001-01-29   PV
// 2006-10-01   PV  VS2005
// 2012-02-25   PV  VS2010

using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class GradientButton : Button
{
    internal void InitializeComponent()
    {
    }

    private Color startColor;
    private Color endColor;

    private static readonly StringFormat format = new StringFormat();

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

        Graphics g = pe.Graphics;
        Rectangle clientRect = ClientRectangle;

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