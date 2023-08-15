// 2001 PV
// 2006-10-01	PV		VS2005
// 2012-02-25	PV		VS2010
// 2021-09-17	PV		VS2022/Net6
// 2023-01-10	PV		Net7

using System.Drawing;
using System.Windows.Forms;

internal class Hello2
{
    public static void Main()
    {
        Form form1 = new();

        Button button1 = new();
        Button button2 = new();

        button1.Text = "OK";
        button1.Location = new Point(10, 10);
        button2.Text = "Cancel";
        button1.Location = new Point(button1.Left, button1.Height + button1.Top + 10);

        form1.Text = "Hello 2";
        form1.HelpButton = true;

        form1.FormBorderStyle = FormBorderStyle.FixedDialog;
        form1.MaximizeBox = false;
        form1.MinimizeBox = false;

        form1.AcceptButton = button1;
        form1.CancelButton = button2;

        form1.StartPosition = FormStartPosition.CenterScreen;

        form1.Controls.Add(button1);
        form1.Controls.Add(button2);

        // Display the form as a modal dialog box.
        _ = form1.ShowDialog();
    }
}
