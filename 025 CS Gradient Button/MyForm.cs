// Essais d'un contrôle GradientButton
// Dérivation d'un contrôle système
// 2001-01-29   PV
// 2001-08-15   PV	Beta2: le miracle ne marche plus !!!
// 2006-10-01   PV  VS2005
// 2012-02-25   PV  VS2010

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

#pragma warning disable IDE1006 // Naming Styles


public class MyForm : System.Windows.Forms.Form
{
    private System.Windows.Forms.Button button1;
    private GradientButton button2;
    private readonly System.ComponentModel.Container components = null;

    public MyForm()
    {
        InitializeComponent();
    }

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
        this.button1 = new System.Windows.Forms.Button();
        this.button2 = new GradientButton();
        this.SuspendLayout();
        // 
        // button1
        // 
        this.button1.Location = new System.Drawing.Point(56, 24);
        this.button1.Name = "button1";
        this.button1.Size = new System.Drawing.Size(120, 56);
        this.button1.TabIndex = 0;
        this.button1.Text = "button1";
        this.button1.Click += new System.EventHandler(this.button1_Click_1);
        // 
        // button2
        // 
        this.button2.Location = new System.Drawing.Point(56, 104);
        this.button2.Name = "button2";
        this.button2.Size = new System.Drawing.Size(120, 56);
        this.button2.TabIndex = 0;
        this.button2.Text = "button2";
        this.button2.StartColor = Color.AntiqueWhite;
        this.button2.EndColor = Color.RosyBrown;
        this.button2.Click += new System.EventHandler(this.button2_Click);
        // 
        // MyForm
        // 
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.ClientSize = new System.Drawing.Size(292, 273);
        this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                this.button2,
                                                                this.button1});
        this.Name = "MyForm";
        this.Text = "Form";
        this.Load += new System.EventHandler(this.MyForm_Load);
        this.ResumeLayout(false);

    }
    #endregion

    [STAThread]
    static void Main()
    {
        Application.Run(new MyForm());
    }


    private void MyForm_Load(object sender, System.EventArgs e)
    {

    }

    private void button1_Click_1(object sender, System.EventArgs e)
    {
        MessageBox.Show("Clic 1 !");
    }

    private void button2_Click(object sender, System.EventArgs e)
    {
        MessageBox.Show("Clic 2 !");
    }
}
