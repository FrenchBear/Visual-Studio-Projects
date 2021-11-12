// Classe MsgBox2
// Simple boîte de dialogue pour des essais d'héritage
//
// 2001-01-27   PV
// 2021-09-18   PV  VS2022, Net6

#pragma warning disable IDE1006 // Naming Styles
#pragma warning disable CA1050 // Declare types in namespaces

public class MsgBox2 : System.Windows.Forms.Form
{
    private System.Windows.Forms.Button btnOk;
    private System.Windows.Forms.TextBox txtInfo;
    private System.Windows.Forms.Label lblInfo;

    public MsgBox2() => InitializeComponent();

    private void InitializeComponent()
    {
        this.lblInfo = new System.Windows.Forms.Label();
        this.btnOk = new System.Windows.Forms.Button();
        this.txtInfo = new System.Windows.Forms.TextBox();
        this.SuspendLayout();
        //
        // lblInfo
        //
        this.lblInfo.AutoSize = true;
        this.lblInfo.Location = new System.Drawing.Point(8, 12);
        this.lblInfo.Name = "lblInfo";
        this.lblInfo.Size = new System.Drawing.Size(29, 13);
        this.lblInfo.TabIndex = 0;
        this.lblInfo.Text = "Info :";
        //
        // btnOk
        //
        this.btnOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
        this.btnOk.Location = new System.Drawing.Point(154, 96);
        this.btnOk.Name = "btnOk";
        this.btnOk.Size = new System.Drawing.Size(60, 24);
        this.btnOk.TabIndex = 2;
        this.btnOk.Text = "OK";
        this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
        //
        // txtInfo
        //
        this.txtInfo.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom
          | System.Windows.Forms.AnchorStyles.Left
          | System.Windows.Forms.AnchorStyles.Right;
        this.txtInfo.Location = new System.Drawing.Point(52, 8);
        this.txtInfo.Multiline = true;
        this.txtInfo.Name = "txtInfo";
        this.txtInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        this.txtInfo.Size = new System.Drawing.Size(272, 80);
        this.txtInfo.TabIndex = 1;
        this.txtInfo.Text = "";
        //
        // MsgBox2
        //
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.ClientSize = new System.Drawing.Size(328, 125);
        this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                this.btnOk,
                                                                this.txtInfo,
                                                                this.lblInfo});
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "MsgBox2";
        this.Text = "Information";
        this.ResumeLayout(false);
    }

    protected void btnOk_Click(object sender, System.EventArgs e) => Close();

    public virtual void Info(string sMsg)
    {
        txtInfo.Text = sMsg;
        _ = ShowDialog();
    }
}