// 2001 PV
// 2006-10-01   PV  VS2005
// 2012-02-25   PV  VS2010

#pragma warning disable IDE0052 // Remove unread private members

namespace WindowsApplication2_CSharp
{
    using System.Windows.Forms;

#pragma warning disable IDE1006 // Naming Styles

    public class frmHello : System.Windows.Forms.Form
    {
        /// <summary>
        ///    Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components;

        private System.Windows.Forms.Button btnHello;

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
            btnHello = new System.Windows.Forms.Button();
            //@this.TrayHeight = 0;
            //@this.TrayLargeIcon = false;
            //@this.TrayAutoArrange = true;
            btnHello.Location = new System.Drawing.Point(88, 56);
            btnHello.Size = new System.Drawing.Size(75, 23);
            btnHello.TabIndex = 0;
            btnHello.Text = "&Hello";
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
}