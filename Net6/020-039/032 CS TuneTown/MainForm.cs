// Application TuneTown
// D'apr�s MSDN F�vrier 2001
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

public class MainForm : Form
{
    private Button RemoveButton;
    private Button EditButton;
    private Button AddButton;
    private ColumnHeader TitleHeader;
    private ColumnHeader ArtistHeader;
    private ColumnHeader CommentHeader;
    private ListView TuneView;

    public MainForm()
    {
        InitializeComponent();
        InitializeListView();
    }

    private void InitializeComponent()
    {
        EditButton = new Button();
        TitleHeader = new ColumnHeader();
        TuneView = new ListView();
        ArtistHeader = new ColumnHeader();
        CommentHeader = new ColumnHeader();
        AddButton = new Button();
        RemoveButton = new Button();
        SuspendLayout();
        //
        // EditButton
        //
        EditButton.Location = new System.Drawing.Point(432, 56);
        EditButton.Name = "EditButton";
        EditButton.TabIndex = 2;
        EditButton.Text = "&Edit";
        EditButton.Click += new EventHandler(OnEditButtonClicked);
        //
        // TitleHeader
        //
        TitleHeader.Text = "Title";
        TitleHeader.Width = 100;
        //
        // TuneView
        //
        TuneView.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom
                                 | System.Windows.Forms.AnchorStyles.Left
                                | System.Windows.Forms.AnchorStyles.Right;
        TuneView.Columns.AddRange(new ColumnHeader[] {
            TitleHeader,
            ArtistHeader,
            CommentHeader});
        TuneView.ForeColor = System.Drawing.SystemColors.WindowText;
        TuneView.FullRowSelect = true;
        TuneView.GridLines = true;
        TuneView.HideSelection = false;
        TuneView.Location = new System.Drawing.Point(8, 8);
        TuneView.MultiSelect = false;
        TuneView.Name = "TuneView";
        TuneView.Size = new System.Drawing.Size(416, 248);
        TuneView.Sorting = System.Windows.Forms.SortOrder.Ascending;
        TuneView.TabIndex = 0;
        TuneView.View = System.Windows.Forms.View.Details;
        TuneView.DoubleClick += new EventHandler(OnItemDoubleClicked);
        //
        // ArtistHeader
        //
        ArtistHeader.Text = "Artist";
        ArtistHeader.Width = 100;
        //
        // CommentHeader
        //
        CommentHeader.Text = "Comment";
        CommentHeader.Width = 200;
        //
        // AddButton
        //
        AddButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
        AddButton.Location = new System.Drawing.Point(432, 8);
        AddButton.Name = "AddButton";
        AddButton.TabIndex = 1;
        AddButton.Text = "&Add";
        AddButton.Click += new EventHandler(OnAddButtonClicked);
        //
        // RemoveButton
        //
        RemoveButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
        RemoveButton.Location = new System.Drawing.Point(432, 104);
        RemoveButton.Name = "RemoveButton";
        RemoveButton.TabIndex = 3;
        RemoveButton.Text = "&Remove";
        RemoveButton.Click += new EventHandler(OnRemoveButtonClicked);
        //
        // MainForm
        //
        AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        ClientSize = new System.Drawing.Size(512, 261);
        Controls.AddRange(new Control[] {
            RemoveButton,
            EditButton,
            AddButton,
            TuneView});
        Name = "MainForm";
        Text = "TuneTown";
        ResumeLayout(false);
    }

    private void OnAddButtonClicked(object sender, EventArgs e)
    {
        AddEditForm dlg = new();

        if (dlg.ShowDialog() == DialogResult.OK)
        {
            ListViewItem item = new(new string[] { dlg.Title, dlg.Artist, dlg.Comment });
            _ = TuneView.Items.Add(item);
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

    private void OnItemDoubleClicked(object sender, EventArgs e) => OnEditButtonClicked(sender, e);

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
                _ = MessageBox.Show(ex2.Message);
            }
            finally
            {
                writer.Close();
            }
        }
        catch (Exception ex1)
        {
            _ = MessageBox.Show(ex1.Message);
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
                        _ = TuneView.Items.Add(item);
                        item.Focused = true;
                    }
                } while (s1 != null);
            }
            catch (Exception ex2)
            {
                _ = MessageBox.Show(ex2.Message);
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

    public static void Main(string[] args) => Application.Run(new MainForm());
}