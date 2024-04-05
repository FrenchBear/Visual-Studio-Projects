// 01/10/2006 PV VS 2005

#pragma warning disable IDE0052 // Remove unread private members

public class AddEditForm : System.Windows.Forms.Form
{
    public string Title
    {
        get => TitleBox.Text;
        set => TitleBox.Text = value;
    }

    public string Artist
    {
        get => ArtistBox.Text;
        set => ArtistBox.Text = value;
    }

    public string Comment
    {
        get => CommentBox.Text;
        set => CommentBox.Text = value;
    }

    private System.ComponentModel.Container components;
    private System.Windows.Forms.Button NotOKButton;
    private System.Windows.Forms.Button OKButton;
    private System.Windows.Forms.TextBox CommentBox;
    private System.Windows.Forms.TextBox ArtistBox;
    private System.Windows.Forms.TextBox TitleBox;
    private System.Windows.Forms.Label CommentLabel;
    private System.Windows.Forms.Label ArtistLabel;
    private System.Windows.Forms.Label TitleLabel;

    public AddEditForm() => InitializeComponent();

    /// <summary>
    ///    Required method for Designer support - do not modify
    ///    the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        ArtistLabel = new System.Windows.Forms.Label();
        OKButton = new System.Windows.Forms.Button();
        NotOKButton = new System.Windows.Forms.Button();
        ArtistBox = new System.Windows.Forms.TextBox();
        TitleLabel = new System.Windows.Forms.Label();
        CommentLabel = new System.Windows.Forms.Label();
        TitleBox = new System.Windows.Forms.TextBox();
        CommentBox = new System.Windows.Forms.TextBox();
        //@this.TrayHeight = 0;
        //@this.TrayLargeIcon = false;
        //@this.TrayAutoArrange = true;
        ArtistLabel.Location = new System.Drawing.Point(4, 52);
        ArtistLabel.Text = "&Artist";
        ArtistLabel.Size = new System.Drawing.Size(29, 13);
        ArtistLabel.AutoSize = true;
        ArtistLabel.TabIndex = 2;
        OKButton.Location = new System.Drawing.Point(64, 204);
        OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
        OKButton.Size = new System.Drawing.Size(88, 32);
        OKButton.TabIndex = 6;
        OKButton.Text = "OK";
        NotOKButton.Location = new System.Drawing.Point(184, 204);
        NotOKButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        NotOKButton.Size = new System.Drawing.Size(88, 32);
        NotOKButton.TabIndex = 7;
        NotOKButton.Text = "Cancel";
        ArtistBox.Location = new System.Drawing.Point(64, 52);
        ArtistBox.TabIndex = 3;
        ArtistBox.Size = new System.Drawing.Size(208, 20);
        TitleLabel.Location = new System.Drawing.Point(4, 8);
        TitleLabel.Text = "&Title";
        TitleLabel.Size = new System.Drawing.Size(25, 13);
        TitleLabel.AutoSize = true;
        TitleLabel.TabIndex = 0;
        CommentLabel.Location = new System.Drawing.Point(4, 100);
        CommentLabel.Text = "&Comment";
        CommentLabel.Size = new System.Drawing.Size(52, 13);
        CommentLabel.AutoSize = true;
        CommentLabel.TabIndex = 4;
        TitleBox.Location = new System.Drawing.Point(64, 8);
        TitleBox.TabIndex = 1;
        TitleBox.Size = new System.Drawing.Size(208, 20);
        CommentBox.Location = new System.Drawing.Point(64, 100);
        CommentBox.Multiline = true;
        CommentBox.TabIndex = 5;
        CommentBox.Size = new System.Drawing.Size(208, 80);
        Text = "AddEditForm";
        MaximizeBox = false;
        AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        CancelButton = NotOKButton;
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        ShowInTaskbar = false;
        AcceptButton = OKButton;
        MinimizeBox = false;
        ClientSize = new System.Drawing.Size(282, 247);
        Controls.Add(NotOKButton);
        Controls.Add(OKButton);
        Controls.Add(CommentBox);
        Controls.Add(ArtistBox);
        Controls.Add(TitleBox);
        Controls.Add(CommentLabel);
        Controls.Add(ArtistLabel);
        Controls.Add(TitleLabel);
    }
}