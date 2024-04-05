// 010 CS Simple Forms
// Essais élémentaires du designer en C#
// PV janvier 2001
// 2006-10-01   PV  V2005
// 2012-02-25   PV  VS2010

using System.Windows.Forms;

#pragma warning disable IDE0052 // Remove unread private members

public class Form1 : System.Windows.Forms.Form
{
    private System.ComponentModel.Container components;

    public Form1() => InitializeComponent();

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        Text = "010 CS Simple Forms";
        AutoScaleBaseSize = new System.Drawing.Size(5, 13);
    }

    public static void Main(string[] args) => Application.Run(new Form1());
}