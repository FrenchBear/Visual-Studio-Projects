// Application TuneTown
// D'après MSDN Février 2001
//
// 2001-02-03   PV
// 2001-08-19   PV	Beta2
// 2006-10-01	PV		VS2005
// 2012-02-25	PV		VS2010
// 2021-09-18	PV		VS2022, Net6
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12
// 2024-11-15	PV		Net9 C#13
// 2026-01-19	PV		Net10 C#14

using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace CS032;

public class MainForm: Form
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
        TuneView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom
                                 | AnchorStyles.Left
                                | AnchorStyles.Right;
        TuneView.Columns.AddRange([
            TitleHeader,
            ArtistHeader,
            CommentHeader]);
        TuneView.ForeColor = System.Drawing.SystemColors.WindowText;
        TuneView.FullRowSelect = true;
        TuneView.GridLines = true;
        TuneView.HideSelection = false;
        TuneView.Location = new System.Drawing.Point(8, 8);
        TuneView.MultiSelect = false;
        TuneView.Name = "TuneView";
        TuneView.Size = new System.Drawing.Size(416, 248);
        TuneView.Sorting = SortOrder.Ascending;
        TuneView.TabIndex = 0;
        TuneView.View = View.Details;
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
        AddButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        AddButton.Location = new System.Drawing.Point(432, 8);
        AddButton.Name = "AddButton";
        AddButton.TabIndex = 1;
        AddButton.Text = "&Add";
        AddButton.Click += new EventHandler(OnAddButtonClicked);
        //
        // RemoveButton
        //
        RemoveButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
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
        Controls.AddRange([
            RemoveButton,
            EditButton,
            AddButton,
            TuneView]);
        Name = "MainForm";
        Text = "TuneTown";
        ResumeLayout(false);
    }

    private void OnAddButtonClicked(object sender, EventArgs e)
    {
        AddEditForm dlg = new();

        if (dlg.ShowDialog() == DialogResult.OK)
        {
            ListViewItem item = new([dlg.Title, dlg.Artist, dlg.Comment]);
            _ = TuneView.Items.Add(item);
            item.Focused = true;
        }
    }

    private void OnEditButtonClicked(object sender, EventArgs e)
    {
        if (TuneView.Items.Count != 0)
        {
            var item = TuneView.FocusedItem;
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
            var item = TuneView.FocusedItem;
            item?.Remove();
        }
    }

    private void OnItemDoubleClicked(object sender, EventArgs e) => OnEditButtonClicked(sender, e);

    [Obsolete("Warning in Net10")]
    protected override void OnClosing(CancelEventArgs e)
    {
        try
        {
            var writer = File.CreateText(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\TuneTownData.ttd");
            try
            {
                for (var i = 0; i < TuneView.Items.Count; i++)
                {
                    var s1 = TuneView.Items[i].Text;
                    var s2 = TuneView.Items[i].SubItems[1].Text;
                    var s3 = TuneView.Items[i].SubItems[2].Text;
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
            var reader = File.OpenText(
                Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + @"\TuneTownData.ttd");

            try
            {
                string s1;
                do
                {
                    s1 = reader.ReadLine();
                    if (s1 != null)
                    {
                        var s2 = reader.ReadLine();
                        var s3 = reader.ReadLine();
                        ListViewItem item = new([s1, s2, s3]);
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
