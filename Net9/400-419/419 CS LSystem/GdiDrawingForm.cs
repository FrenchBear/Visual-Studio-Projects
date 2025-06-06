﻿// Drawing of a LSystem result using GDI
// Simply draws on the Graphics of a PictureBox placed on the form
//
// 2012-02-05   PV      First version
// 2021-09-23   PV      VS2022; Net6
// 2021-12-11   PV      Support for color
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12
// 2024-11-15	PV		Net9 C#13

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

#pragma warning disable IDE0059 // Unnecessary assignment of a value

namespace CS419;

public partial class GdiDrawingForm: Form
{
    private IEnumerable<char> _s;
    private int _angle;

    public GdiDrawingForm()
    {
        InitializeComponent();

        // Fill printers list
        foreach (string printer in PrinterSettings.InstalledPrinters)
            PrintersList.Items.Add(printer.ToString());
        if (PrintersList.Items.Count > 0)
            PrintersList.SelectedIndex = 0;
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
        if (picOut.Size.Width <= 1 || picOut.Size.Height <= 1)
            return;  // Too small pic area
        Bitmap bmpOut = new(picOut.Size.Width, picOut.Size.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
        picOut.Image = bmpOut;
        var graOut = Graphics.FromImage(bmpOut);
        graOut.Clear(Color.White);
        GraphicsDraw(graOut, picOut.Size.Width, picOut.Size.Height);
    }

    private void GraphicsDraw(Graphics graOut, int width, int height)
    {
        GdiLSystemRenderer gr = new(_s, _angle);
        gr.Rend(ref graOut, width, height);
    }

    // Implementation of rendered for GDI
    private class GdiLSystemRenderer(IEnumerable<char> s, int angle): LSystemRenderer(s, angle)
    {
        private Graphics _graOut;

        public void Rend(ref Graphics graOut, double rendingWidth, double rendingHeight)
        {
            _graOut = graOut;
            _ = Rend(rendingWidth, rendingHeight);
        }

        private readonly Color[] ColorsTable =
        [
            Color.Black,
            Color.Blue,
            Color.Red,
            Color.Yellow,
            Color.Green,
            Color.Orange,
            Color.Purple,
            Color.Gray,
            Color.LightPink,
            Color.SkyBlue,
            Color.Brown,
        ];

        protected override void RendLine(double x1, double y1, double x2, double y2, bool isStroke, int color)
        {
            if (isStroke)
            {
                var p = new Pen(ColorsTable[color % ColorsTable.Length], 0.1f);
                _graOut.DrawLine(p, Convert.ToInt32(x1), Convert.ToInt32(y1), Convert.ToInt32(x2), Convert.ToInt32(y2));
            }
        }
    }

    private void GdiDrawingForm_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Escape)
            Close();
    }

    private void PrintButton_Click(object sender, EventArgs e)
    {
        if (PrintersList.SelectedItem == null)
        {
            MessageBox.Show("Select a printer first!");
            return;
        }

        var pd = new PrintDocument();
        pd.PrinterSettings.PrinterName = PrintersList.SelectedItem.ToString();

        // Select A4 paper
        for (var i = 0; i < pd.PrinterSettings.PaperSizes.Count; i++)
        {
            var pkSize = pd.PrinterSettings.PaperSizes[i];
            if (pkSize.PaperName.Contains("A4"))
                pd.DefaultPageSettings.PaperSize = pkSize;
        }

        foreach (PrinterResolution pr in pd.PrinterSettings.PrinterResolutions)
        {
            if (pr.Kind == PrinterResolutionKind.Custom)
            {
                pd.DefaultPageSettings.PrinterResolution = pr;
                break;
            }
        }

        pd.PrintPage += new PrintPageEventHandler(Pd_PrintPage);
        pd.Print();
    }

    private void Pd_PrintPage(object sender, PrintPageEventArgs ev)
    {
        var g = ev.Graphics;
        var pr = ev.PageSettings.PrinterResolution;

        g.DrawLine(new Pen(Color.Black), 10, 10, ev.PageBounds.Width - 20, ev.PageBounds.Height - 20);
        g.DrawEllipse(new Pen(Color.Black), 10, 10, ev.PageBounds.Width - 20, ev.PageBounds.Height - 20);

        GraphicsDraw(g, ev.PageBounds.Width, ev.PageBounds.Height);
    }

}   // class GdiDrawingForm
