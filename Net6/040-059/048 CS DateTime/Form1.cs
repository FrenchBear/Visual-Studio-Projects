// Essais sur la classe DateTime (chronom�trage)
// Comparaison des performances SortedList et Hashtable
// R�cup du nom de la fonction point�e par un delegate
//
// 2001-02-25   PV
// 2006-10-01   PV  VS2005
// 2012-02-25   PV  VS2010
// 2021-09-18   PV  VS2022, Net6

using System;
using System.Collections;
using System.Windows.Forms;

#pragma warning disable IDE0052 // Remove unread private members

namespace CS048;

public class Form1 : Form
{
    private System.ComponentModel.Container components;
    private ListBox listBox1;
    private readonly Random r;
    private readonly SortedList s;
    private SortedList sh;
    private readonly Hashtable h;

    public delegate void sub();

    public Form1()
    {
        InitializeComponent();
        r = new Random(123456);
        s = new SortedList();
        h = new Hashtable();

        Chrono(new sub(TestSortedList));
        Chrono(new sub(TestHashtable));
        Chrono(new sub(TriHashtable));
    }

    public void Chrono(sub s)
    {
        string sNomFonction = s.GetInvocationList()[0].Method.Name;
        Trace("Debut " + sNomFonction);
        DateTime t1 = DateTime.Now;
        s();
        DateTime t2 = DateTime.Now;
        Trace("Fin " + sNomFonction);
        TimeSpan ts = t2 - t1;
        Trace("Dur�e: " + ts);
        Trace();
    }

    public void TestSortedList() => TestInterne(s);

    public void TestHashtable() => TestInterne(h);

    // Trie en une fois ha Hashtable
    public void TriHashtable() => sh = new SortedList(h);

    private void TestInterne(IDictionary d)
    {
        for (int i = 1; i < 20000; i++)
        {
            d.Add(r.Next(), null);
        }
    }

    public void Trace(string sMsg) => listBox1.Items.Add(sMsg);

    public void Trace() => Trace("");

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        listBox1 = new ListBox();
        listBox1.Location = new System.Drawing.Point(4, 4);
        listBox1.Size = new System.Drawing.Size(360, 329);
        listBox1.TabIndex = 0;
        listBox1.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
        Text = "Tests de performances";
        AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        ClientSize = new System.Drawing.Size(368, 337);
        Controls.Add(listBox1);
    }

    public static void Main(string[] args) => Application.Run(new Form1());
}