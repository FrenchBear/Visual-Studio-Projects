// Essais d'un contrôle GradientButton
// Dérivation d'un contrôle système
//
// 2001-01-29   PV
// 2001-08-15   PV	Beta2: le miracle ne marche plus !!!
// 2006-10-01	PV		VS2005
// 2012-02-25	PV		VS2010
// 2021-09-18	PV		VS2022, Net6
// 2023-01-10	PV		Net7

using System;
using System.Drawing;
using System.Windows.Forms;

#pragma warning disable IDE1006 // Naming Styles
#pragma warning disable CA1050 // Declare types in namespaces

public class MyForm: Form
{
    private Button button1;
    private GradientButton button2;
    private readonly System.ComponentModel.Container components = null;

    public MyForm() => InitializeComponent();

    protected override void Dispose(bool disposing)
    {
        if (disposing)
            components?.Dispose();
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        button1 = new Button();
        button2 = new GradientButton();
        SuspendLayout();
        //
        // button1
        //
        button1.Location = new Point(56, 24);
        button1.Name = "button1";
        button1.Size = new Size(120, 56);
        button1.TabIndex = 0;
        button1.Text = "button1";
        button1.Click += new EventHandler(button1_Click_1);
        //
        // button2
        //
        button2.Location = new Point(56, 104);
        button2.Name = "button2";
        button2.Size = new Size(120, 56);
        button2.TabIndex = 0;
        button2.Text = "button2";
        button2.StartColor = Color.AntiqueWhite;
        button2.EndColor = Color.RosyBrown;
        button2.Click += new EventHandler(button2_Click);
        //
        // MyForm
        //
        AutoScaleBaseSize = new Size(5, 13);
        ClientSize = new Size(292, 273);
        Controls.AddRange(new Control[] {
                                                                button2,
                                                                button1});
        Name = "MyForm";
        Text = "Form";
        Load += new EventHandler(MyForm_Load);
        ResumeLayout(false);
    }

    #endregion Windows Form Designer generated code

    [STAThread]
    private static void Main() => Application.Run(new MyForm());

    private void MyForm_Load(object sender, EventArgs e)
    {
    }

    private void button1_Click_1(object sender, EventArgs e) => MessageBox.Show("Clic 1 !");

    private void button2_Click(object sender, EventArgs e) => MessageBox.Show("Clic 2 !");
}
