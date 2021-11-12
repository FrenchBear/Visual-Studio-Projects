// Essais d'un contrôle GradientButton
// Dérivation d'un contrôle système
//
// 2001-01-29   PV
// 2001-08-15   PV	Beta2: le miracle ne marche plus !!!
// 2006-10-01   PV  VS2005
// 2012-02-25   PV  VS2010
// 2021-09-18   PV  VS2022, Net6

using System;
using System.Drawing;
using System.Windows.Forms;

#pragma warning disable IDE1006 // Naming Styles
#pragma warning disable CA1050 // Declare types in namespaces

public class MyForm : Form
{
    private Button button1;
    private GradientButton button2;
    private readonly System.ComponentModel.Container components = null;

    public MyForm() => InitializeComponent();

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            if (components != null)
            {
                components.Dispose();
            }
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        this.button1 = new Button();
        this.button2 = new GradientButton();
        this.SuspendLayout();
        //
        // button1
        //
        this.button1.Location = new Point(56, 24);
        this.button1.Name = "button1";
        this.button1.Size = new Size(120, 56);
        this.button1.TabIndex = 0;
        this.button1.Text = "button1";
        this.button1.Click += new EventHandler(this.button1_Click_1);
        //
        // button2
        //
        this.button2.Location = new Point(56, 104);
        this.button2.Name = "button2";
        this.button2.Size = new Size(120, 56);
        this.button2.TabIndex = 0;
        this.button2.Text = "button2";
        this.button2.StartColor = Color.AntiqueWhite;
        this.button2.EndColor = Color.RosyBrown;
        this.button2.Click += new EventHandler(this.button2_Click);
        //
        // MyForm
        //
        this.AutoScaleBaseSize = new Size(5, 13);
        this.ClientSize = new Size(292, 273);
        this.Controls.AddRange(new Control[] {
                                                                this.button2,
                                                                this.button1});
        this.Name = "MyForm";
        this.Text = "Form";
        this.Load += new EventHandler(this.MyForm_Load);
        this.ResumeLayout(false);
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