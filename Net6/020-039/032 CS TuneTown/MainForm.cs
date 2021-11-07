// Application TuneTown
// D'après MSDN Février 2001
//
// 2001-02-03   PV
// 2001-08-19   PV	Beta2
// 2006-10-01   PV  VS2005
// 2012-02-25   PV  VS2010
// 2021-09-18   PV  VS2022, Net6

using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace TuneTownNS;

public class MainForm : System.Windows.Forms.Form
{
    private System.Windows.Forms.Button RemoveButton;
    private System.Windows.Forms.Button EditButton;
    private System.Windows.Forms.Button AddButton;
    private System.Windows.Forms.ColumnHeader TitleHeader;
    private System.Windows.Forms.ColumnHeader ArtistHeader;
    private System.Windows.Forms.ColumnHeader CommentHeader;
    private System.Windows.Forms.ListView TuneView;

    public MainForm()
    {
        InitializeComponent();
        InitializeListView();
    }

    private void InitializeComponent()
    {
        this.EditButton = new System.Windows.Forms.Button();
        this.TitleHeader = new System.Windows.Forms.ColumnHeader();
        this.TuneView = new System.Windows.Forms.ListView();
        this.ArtistHeader = new System.Windows.Forms.ColumnHeader();
        this.CommentHeader = new System.Windows.Forms.ColumnHeader();
        this.AddButton = new System.Windows.Forms.Button();
        this.RemoveButton = new System.Windows.Forms.Button();
        this.SuspendLayout();
        //
        // EditButton
        //
        this.EditButton.Location = new System.Drawing.Point(432, 56);
        this.EditButton.Name = "EditButton";
        this.EditButton.TabIndex = 2;
        this.EditButton.Text = "&Edit";
        this.EditButton.Click += new System.EventHandler(this.OnEditButtonClicked);
        //
        // TitleHeader
        //
        this.TitleHeader.Text = "Title";
        this.TitleHeader.Width = 100;
        //
        // TuneView
        //
        this.TuneView.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                                 | System.Windows.Forms.AnchorStyles.Left)
                                | System.Windows.Forms.AnchorStyles.Right);
        this.TuneView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.TitleHeader,
            this.ArtistHeader,
            this.CommentHeader});
        this.TuneView.ForeColor = System.Drawing.SystemColors.WindowText;
        this.TuneView.FullRowSelect = true;
        this.TuneView.GridLines = true;
        this.TuneView.HideSelection = false;
        this.TuneView.Location = new System.Drawing.Point(8, 8);
        this.TuneView.MultiSelect = false;
        this.TuneView.Name = "TuneView";
        this.TuneView.Size = new System.Drawing.Size(416, 248);
        this.TuneView.Sorting = System.Windows.Forms.SortOrder.Ascending;
        this.TuneView.TabIndex = 0;
        this.TuneView.View = System.Windows.Forms.View.Details;
        this.TuneView.DoubleClick += new System.EventHandler(this.OnItemDoubleClicked);
        //
        // ArtistHeader
        //
        this.ArtistHeader.Text = "Artist";
        this.ArtistHeader.Width = 100;
        //
        // CommentHeader
        //
        this.CommentHeader.Text = "Comment";
        this.CommentHeader.Width = 200;
        //
        // AddButton
        //
        this.AddButton.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
        this.AddButton.Location = new System.Drawing.Point(432, 8);
        this.AddButton.Name = "AddButton";
        this.AddButton.TabIndex = 1;
        this.AddButton.Text = "&Add";
        this.AddButton.Click += new System.EventHandler(this.OnAddButtonClicked);
        //
        // RemoveButton
        //
        this.RemoveButton.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
        this.RemoveButton.Location = new System.Drawing.Point(432, 104);
        this.RemoveButton.Name = "RemoveButton";
        this.RemoveButton.TabIndex = 3;
        this.RemoveButton.Text = "&Remove";
        this.RemoveButton.Click += new System.EventHandler(this.OnRemoveButtonClicked);
        //
        // MainForm
        //
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.ClientSize = new System.Drawing.Size(512, 261);
        this.Controls.AddRange(new System.Windows.Forms.Control[] {
            this.RemoveButton,
            this.EditButton,
            this.AddButton,
            this.TuneView});
        this.Name = "MainForm";
        this.Text = "TuneTown";
        this.ResumeLayout(false);
    }

    private void OnAddButtonClicked(object sender, EventArgs e)
    {
        AddEditForm dlg = new();

        if (dlg.ShowDialog() == DialogResult.OK)
        {
            ListViewItem item = new(new string[] { dlg.Title, dlg.Artist, dlg.Comment });
            TuneView.Items.Add(item);
            item.Focused = true;
        }
    }

    private void OnEditButtonClicked(object sender, EventArgs e)
    {
        if (TuneView.Items.Count != 0)
        {
            ListViewItem item = TuneView.FocusedItem;
            if (item != null)
            {
                AddEditForm dlg = new()
                {
                    Title = item.Text,
                    Artist = item.SubItems[1].Text,
                    Comment = item.SubItems[2].Text
                };

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    item.Text = dlg.Title;
                    item.SubItems[1].Text = dlg.Artist;
                    item.SubItems[2].Text = dlg.Comment;
                }
            }
        }
    }

    private void OnRemoveButtonClicked(object sender, EventArgs e)
    {
        if (TuneView.Items.Count != 0)
        {
            ListViewItem item = TuneView.FocusedItem;
            if (item != null)
                item.Remove();
        }
    }

    private void OnItemDoubleClicked(object sender, EventArgs e)
    {
        OnEditButtonClicked(sender, e);
    }

    protected override void OnClosing(CancelEventArgs e)
    {
        try
        {
            StreamWriter writer = File.CreateText(
                System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData) + @"\TuneTownData.ttd");
            try
            {
                for (int i = 0; i < TuneView.Items.Count; i++)
                {
                    string s1 = TuneView.Items[i].Text;
                    string s2 = TuneView.Items[i].SubItems[1].Text;
                    string s3 = TuneView.Items[i].SubItems[2].Text;
                    writer.WriteLine(s1);
                    writer.WriteLine(s2);
                    writer.WriteLine(s3);
                }
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message);
            }
            finally
            {
                writer.Close();
            }
        }
        catch (Exception ex1)
        {
            MessageBox.Show(ex1.Message);
        }
    }

    protected void InitializeListView()
    {
        try
        {
            StreamReader reader = File.OpenText(
                System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData) + @"\TuneTownData.ttd");

            try
            {
                string s1;
                do
                {
                    s1 = reader.ReadLine();
                    if (s1 != null)
                    {
                        string s2 = reader.ReadLine();
                        string s3 = reader.ReadLine();
                        ListViewItem item = new(new String[] { s1, s2, s3 });
                        TuneView.Items.Add(item);
                        item.Focused = true;
                    }
                } while (s1 != null);
            }
            catch (Exception ex2)
            {
                MessageBox.Show(ex2.Message);
            }
            finally
            {
                reader.Close();
            }
        }
        catch
        {
            // On ne fait rien, le fichier n'existe pas
        }
    }

    public static void Main(string[] args)
    {
        Application.Run(new MainForm());
    }
}