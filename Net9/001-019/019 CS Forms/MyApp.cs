// 19 C# Forms
// Création "manuelle" d'une feuille en dérivant MyForm de la classe Form
// Plus quelques handlers d'événements
//
// 2001-01-27   PV
// 2001-08-15	PV		Beta2
// 2006-10-01	PV		VS2005
// 2012-02-25	PV		VS2010
// 2021-09-17	PV		VS2022/Net6
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12
// 2024-11-15	PV		Net9 C#13

using System;
using System.Drawing;
using System.Windows.Forms;

namespace CS019;

public class MyForm: Form
{
    private readonly Button btnNew;
    private readonly Button button1;
    private readonly Button button2;

    public MyForm()
    {
        Text = "Titre de la fenêtre";
        AutoScaleBaseSize = new Size(5, 13);
        ClientSize = new Size(400, 150);

        btnNew = new Button
        {
            Location = new Point(10, 10),
            Size = new Size(50, 30),
            Text = "New"
        };
        Controls.Add(btnNew);
        btnNew.Click += new EventHandler(OnNewClick);

        button1 = new Button
        {
            Location = new Point(100, 64),
            Size = new Size(90, 40),
            TabIndex = 2,
            Text = "Bouton 1"
        };
        Controls.Add(button1);
        //Register the event handler
        button1.Click += new EventHandler(OnClick);

        button2 = new Button
        {
            Location = new Point(200, 64),
            Size = new Size(90, 40),
            TabIndex = 2,
            Text = "Bouton 2"
        };
        Controls.Add(button2);
        button2.Click += new EventHandler(OnClick);
    }

    // Handler commun à button1 et button2
    private void OnClick(object sender, EventArgs evArgs)
        => _ = sender == button1 ? MessageBox.Show("Hello Button 1") : MessageBox.Show("Hello Button 2");

    private void OnNewClick(object sender, EventArgs evArgs)
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

        MyForm f = new();
        f.Closed += new EventHandler(OnFormClosed);
        //f.ShowDialog();	  // Affichage modal
        f.Show();
    }

    private void OnFormClosed(object sender, EventArgs evArgs)
    {
        _ = MessageBox.Show("onFormClosed");
        ((MyForm)sender).Dispose();
    }

    // Feuille principale
    public static int Main()
    {
        Application.Run(new MyForm());
        return 0;
    }
}
