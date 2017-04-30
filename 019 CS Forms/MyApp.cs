// 19 C# Forms
// Création "manuelle" d'une feuille en dérivant MyForm de la classe Form
// Plus quelques handlers d'événements
// 2001-01-27   PV
// 2001-08-15   PV  Beta2
// 2006-10-01   PV  VS2005
// 2012-02-25   PV  VS2010

using System;
using System.Windows.Forms;
using System.Drawing;


public class MyForm : Form
{
    Button btnNew;
    Button button1;
    Button button2;

    public MyForm()
    {
        Text = "Titre de la fenêtre";
        AutoScaleBaseSize = new Size(5, 13);
        ClientSize = new Size(400, 150);

        btnNew = new Button();
        btnNew.Location = new Point(10, 10);
        btnNew.Size = new Size(50, 30);
        btnNew.Text = "New";
        Controls.Add(btnNew);
        btnNew.Click += new System.EventHandler(onNewClick);


        button1 = new Button();
        button1.Location = new Point(100, 64);
        button1.Size = new Size(90, 40);
        button1.TabIndex = 2;
        button1.Text = "Bouton 1";
        Controls.Add(button1);
        //Register the event handler
        button1.Click += new System.EventHandler(onClick);

        button2 = new Button();
        button2.Location = new Point(200, 64);
        button2.Size = new Size(90, 40);
        button2.TabIndex = 2;
        button2.Text = "Bouton 2";
        this.Controls.Add(button2);
        button2.Click += new System.EventHandler(onClick);
    }

    // Handler commun à button1 et button2
    private void onClick(object sender, EventArgs evArgs)
    {
        if (sender == button1)
            MessageBox.Show("Hello Button 1");
        else
            MessageBox.Show("Hello Button 2");
    }


    private void onNewClick(object sender, EventArgs evArgs)
    {
        // Application.Run(new MyForm());
        // -->
        // System.InvalidOperationException: It is invalid to start a second 
        // message loop on a single thread. Use Application.RunDialog or 
        // Form.ShowDialog instead.

        // ShowDialog(new MyForm());
        // -->
        // System.Exception: Forms that are already visible cannot be 
        // displayed as a modal dialog. Set the form's visible property to 
        // false before calling showDialog.

        MyForm f = new MyForm();
        f.Closed += new System.EventHandler(onFormClosed);
        //f.ShowDialog();	  // Affichage modal
        f.Show();
    }

    private void onFormClosed(object sender, EventArgs evArgs)
    {
        MessageBox.Show("onFormClosed");
        ((MyForm)sender).Dispose();
    }

    // Feuille principale
    public static int Main()
    {
        System.Windows.Forms.Application.Run(new MyForm());
        return 0;
    }
}
