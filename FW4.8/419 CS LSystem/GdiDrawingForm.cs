// Drawing of a LSystem result using GDI
// Simply draws on the Graphics of a PictureBox placed on the form
// 2012-02-05   PV  First version

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace CS419
{
    public partial class GdiDrawingForm : Form
    {
        private IEnumerable<char> _s;
        private int _angle;

        public GdiDrawingForm()
        {
            InitializeComponent();
        }

        public void DrawString(string title, ref IEnumerable<char> s, int angle)
        {
            _s = s;
            _angle = angle;
            Text = title + " - GDIDrawingForm";
            Show();
        }

        private void GdiDrawingForm_Load(object sender, EventArgs e)
        {
            if (_s != null)
                GdiDraw();
        }

        private void GdiDrawingForm_Resize(object sender, EventArgs e)
        {
            if (_s != null)
                GdiDraw();
        }

        private void GdiDraw()
        {
            if (picOut.Size.Width <= 1 || picOut.Size.Height <= 1) return;  // Too small pic area
            Bitmap bmpOut = new Bitmap(picOut.Size.Width, picOut.Size.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            Graphics graOut = Graphics.FromImage(bmpOut);
            graOut.Clear(Color.White);
            picOut.Image = bmpOut;

            GdiLSystemRenderer gr = new GdiLSystemRenderer(_s, _angle);
            gr.Rend(ref graOut, picOut.Size.Width, picOut.Size.Height);
        }

        // Implementation of rendered for GDI
        private class GdiLSystemRenderer : LSystemRenderer
        {
            private Graphics _graOut;

            public GdiLSystemRenderer(IEnumerable<char> s, int angle) : base(s, angle)
            {
            }

            public void Rend(ref Graphics graOut, double rendingWidth, double rendingHeight)
            {
                _graOut = graOut;
                Rend(rendingWidth, rendingHeight);
            }

            protected override void RendLine(double x1, double y1, double x2, double y2, bool isStroke)
            {
                if (isStroke)
                {
                    _graOut.DrawLine(Pens.Black, Convert.ToInt32(x1), Convert.ToInt32(y1), Convert.ToInt32(x2), Convert.ToInt32(y2));
                }
            }
        }

        private void GdiDrawingForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Close();
        }
    }   // class GdiDrawingForm
}