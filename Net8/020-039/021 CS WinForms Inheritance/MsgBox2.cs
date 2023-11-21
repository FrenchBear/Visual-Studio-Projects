// Classe MsgBox2
// Simple boîte de dialogue pour des essais d'héritage
//
// 2001-01-27   PV
// 2021-09-18	PV		VS2022, Net6
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12

#pragma warning disable IDE1006 // Naming Styles
#pragma warning disable CA1050 // Declare types in namespaces

public class MsgBox2: System.Windows.Forms.Form
{
    private System.Windows.Forms.Button btnOk;
    private System.Windows.Forms.TextBox txtInfo;
    private System.Windows.Forms.Label lblInfo;

    public MsgBox2() => InitializeComponent();

    private void InitializeComponent()
    {
        lblInfo = new System.Windows.Forms.Label();
        btnOk = new System.Windows.Forms.Button();
        txtInfo = new System.Windows.Forms.TextBox();
        SuspendLayout();
        //
        // lblInfo
        //
        lblInfo.AutoSize = true;
        lblInfo.Location = new System.Drawing.Point(8, 12);
        lblInfo.Name = "lblInfo";
        lblInfo.Size = new System.Drawing.Size(29, 13);
        lblInfo.TabIndex = 0;
        lblInfo.Text = "Info :";
        //
        // btnOk
        //
        btnOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
        btnOk.Location = new System.Drawing.Point(154, 96);
        btnOk.Name = "btnOk";
        btnOk.Size = new System.Drawing.Size(60, 24);
        btnOk.TabIndex = 2;
        btnOk.Text = "OK";
        btnOk.Click += new System.EventHandler(btnOk_Click);
        //
        // txtInfo
        //
        txtInfo.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom
          | System.Windows.Forms.AnchorStyles.Left
          | System.Windows.Forms.AnchorStyles.Right;
        txtInfo.Location = new System.Drawing.Point(52, 8);
        txtInfo.Multiline = true;
        txtInfo.Name = "txtInfo";
        txtInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        txtInfo.Size = new System.Drawing.Size(272, 80);
        txtInfo.TabIndex = 1;
        txtInfo.Text = "";
        //
        // MsgBox2
        //
        AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        ClientSize = new System.Drawing.Size(328, 125);
        Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                btnOk,
                                                                txtInfo,
                                                                lblInfo});
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "MsgBox2";
        Text = "Information";
        ResumeLayout(false);
    }

    protected void btnOk_Click(object sender, System.EventArgs e) => Close();

    public virtual void Info(string sMsg)
    {
        txtInfo.Text = sMsg;
        _ = ShowDialog();
    }
}
