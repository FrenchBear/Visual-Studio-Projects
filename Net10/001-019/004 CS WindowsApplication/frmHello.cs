// 2001 PV
//
// 2006-10-01	PV		VS2005
// 2012-02-25	PV		VS2010
// 2021-09-17	PV		VS2022/Net6
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12
// 2024-11-15	PV		Net9 C#13
// 2026-01-19	PV		Net10 C#14

using System.Windows.Forms;

namespace CS004;

#pragma warning disable IDE0052 // Remove unread private members
#pragma warning disable IDE1006 // Naming Styles

public class frmHello: Form
{
    /// <summary>
    ///    Required designer variable.
    /// </summary>
    private System.ComponentModel.Container components;

    private Button btnHello;

    public frmHello() =>
        // Required for Windows Form Designer support
        InitializeComponent();// TODO: Add any constructor code after InitializeComponent call

    /// <summary>
    ///    Required method for Designer support - do not modify
    ///    the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        btnHello = new Button
        {
            //TrayHeight = 0;
            //TrayLargeIcon = false;
            //TrayAutoArrange = true;
            Location = new System.Drawing.Point(88, 56),
            Size = new System.Drawing.Size(75, 23),
            TabIndex = 0,
            Text = "&Hello"
        };
        btnHello.Click += new System.EventHandler(btnHello_Click);
        btnHello.Click += new System.EventHandler(btnHello_Click_bis);
        Text = "Essais C#";
        AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        Controls.Add(btnHello);
    }

    /// <summary>
    /// Une fonction événement qui affiche une boîte de message 'Hello'
    /// </summary>
    protected void btnHello_Click(object sender, System.EventArgs e) => MessageBox.Show("Hello !", "titre");

    /// <summary>
    /// Une deuxième fonction événement pour l'événement click !
    /// </summary>
    protected void btnHello_Click_bis(object sender, System.EventArgs e) => MessageBox.Show("Hello_bis !", "titre_bis");

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    public static void Main(string[] args) => Application.Run(new frmHello());
}
