// 2001 PV
//
// 2006-10-01	PV		VS2005  Added class Startup with [STAThread] attribute on Main()
// 2012-02-25	PV		VS2010
// 2021-09-18	PV		VS2022, Net6
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12

using System;
using System.Drawing;
using System.Windows.Forms;

namespace ImageView;

public class StartUp
{
    [STAThread]
    private static void Main() => Application.Run(new MyForm());
}

public class MyForm: Form
{
    protected ToolStripMenuItem _itemNativeSize;
    protected ToolStripMenuItem _itemFitToWindow;
    protected bool _NativeSize = true;
    protected int _FilterIndex = -1;
    protected Bitmap _MyBitmap;

    public MyForm()
    {
        Text = "Image Viewver";
        ClientSize = new Size(640, 480);

        MenuStrip ms = new();
        ToolStripMenuItem optionsMenu = new("&Options");

        //To update
        //optionsMenu.Popup += new EventHandler(OnPopupOptionsMenu);

        _ = optionsMenu.DropDownItems.Add(new ToolStripMenuItem("&Open...", null, new EventHandler(OnOpenImage), Keys.Control | Keys.O));
        _ = optionsMenu.DropDownItems.Add("-");
        _ = optionsMenu.DropDownItems.Add(_itemFitToWindow = new ToolStripMenuItem("Size image to &fit window", null, new EventHandler(OnFitToWindow)));
        _ = optionsMenu.DropDownItems.Add(_itemNativeSize = new ToolStripMenuItem("Show image in &native size", null, new EventHandler(OnNativeSize)));
        _ = optionsMenu.DropDownItems.Add("-");
        _ = optionsMenu.DropDownItems.Add(new ToolStripMenuItem("&Exit", null, new EventHandler(OnExit)));

        _ = ms.Items.Add(optionsMenu);

        MainMenuStrip = ms;
        Controls.Add(ms);
    }

    private void OnPopupOptionsMenu(object sender, EventArgs e)
    {
        _itemNativeSize.Checked = _NativeSize;
        _itemFitToWindow.Checked = !_NativeSize;
    }

    private void OnOpenImage(object sender, EventArgs e)
    {
        OpenFileDialog ofd = new()
        {
            Filter = "Images Files (JPEG, GIF, BMP, etc.)|*.jpg;*.jpeg;*.gif;*.tif;*.tiff;*.png|" +
                     "JPEG Files (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                     "GIF Files (*.gif)|*.gif|" +
                     "BMP Files (*.bmp)|*.bmp|" +
                     "TIFF Files (*.tif;*.tiff)|*.tif;*.tiff|" +
                     "PNG Files (*.png)|*.png|" +
                     "All files (*.*)|*.*"
        };

        if (_FilterIndex != -1)
            ofd.FilterIndex = _FilterIndex;

        // If Main doesn't have [STAThread] attribute, dev env shows following error:
        // Current thread must be set to single thread apartment (STA) mode before OLE calls can be made. Ensure that your Main function has STAThreadAttribute marked on it. This exception is only raised if a debugger is attached to the process.

        if (ofd.ShowDialog() == DialogResult.OK)
        {
            var fileName = ofd.FileName;
            if (fileName.Length != 0)
            {
                _FilterIndex = ofd.FilterIndex;
                try
                {
                    _MyBitmap = new Bitmap(fileName);
                    Text = "Image Viewver - " + fileName;
                    AutoScroll = true;
                    AutoScrollMinSize = _MyBitmap.Size;
                    Invalidate();
                }
                catch
                {
                    _ = MessageBox.Show($"{fileName} is not a valid image file",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

    private void OnFitToWindow(object sender, EventArgs e)
    {
        _NativeSize = false;
        SetStyle(ControlStyles.ResizeRedraw, true);
        if (_MyBitmap != null)
        {
            AutoScroll = false;
            Invalidate();
        }
    }

    private void OnNativeSize(object sender, EventArgs e)
    {
        _NativeSize = true;
        SetStyle(ControlStyles.ResizeRedraw, false);
        if (_MyBitmap != null)
        {
            AutoScroll = true;
            AutoScrollMinSize = _MyBitmap.Size;
            Invalidate();
        }
    }

    private void OnExit(object sender, EventArgs e) => Close();

    protected override void OnPaint(PaintEventArgs e)
    {
        if (_MyBitmap != null)
        {
            var g = e.Graphics;
            if (_NativeSize)
                g.DrawImage(_MyBitmap, AutoScrollPosition.X, AutoScrollPosition.Y, _MyBitmap.Width, _MyBitmap.Height);
            else
                g.DrawImage(_MyBitmap, ClientRectangle);
        }
    }

    [STAThread]
    public static void Main() => Application.Run(new MyForm());
}
