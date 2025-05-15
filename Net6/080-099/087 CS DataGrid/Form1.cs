// 87 CS DataGridView
// Essais de remplissage de DataGridView
//
// 2003-08-08   PV
// 2006-10-01   PV  VS2005
// 2011-12-30   PV  VS2010  Updated connection string

using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

#pragma warning disable CA1050 // Declare types in namespaces

public class Form1 : Form
{
    private DataGridView dataGrid1;
    private DataGridView dataGrid2;
    private Label label2;
    private Label label1;

    /// <summary>
    /// Variable nécessaire au concepteur.
    /// </summary>
    private readonly System.ComponentModel.Container components = null;

    public Form1() => InitializeComponent();

    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            if (components != null)
            {
                components.Dispose();
            }
        }
        base.Dispose(disposing);
    }

    #region Code généré par le Concepteur Windows Form

    /// <summary>
    /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
    /// le contenu de cette méthode avec l'éditeur de code.
    /// </summary>
    private void InitializeComponent()
    {
        dataGrid1 = new DataGridView();
        dataGrid2 = new DataGridView();
        label2 = new Label();
        label1 = new Label();
        ((System.ComponentModel.ISupportInitialize)dataGrid1).BeginInit();
        ((System.ComponentModel.ISupportInitialize)dataGrid2).BeginInit();
        SuspendLayout();
        //
        // dataGrid1
        //
        dataGrid1.DataMember = "";
        //this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
        dataGrid1.Location = new System.Drawing.Point(8, 24);
        dataGrid1.Name = "dataGrid1";
        dataGrid1.Size = new System.Drawing.Size(448, 228);
        dataGrid1.TabIndex = 0;
        //
        // dataGrid2
        //
        dataGrid2.DataMember = "";
        //this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
        dataGrid2.Location = new System.Drawing.Point(8, 284);
        dataGrid2.Name = "dataGrid2";
        dataGrid2.Size = new System.Drawing.Size(276, 228);
        dataGrid2.TabIndex = 2;
        //
        // label2
        //
        label2.AutoSize = true;
        label2.Location = new System.Drawing.Point(8, 264);
        label2.Name = "label2";
        label2.Size = new System.Drawing.Size(155, 16);
        label2.TabIndex = 3;
        label2.Text = "DataTable créée dans le code";
        //
        // label1
        //
        label1.AutoSize = true;
        label1.Location = new System.Drawing.Point(8, 8);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(224, 16);
        label1.TabIndex = 4;
        label1.Text = "DataSet lu dans la base via un DataAdapter";
        //
        // Form1
        //
        AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        ClientSize = new System.Drawing.Size(744, 530);
        Controls.Add(label1);
        Controls.Add(label2);
        Controls.Add(dataGrid2);
        Controls.Add(dataGrid1);
        Name = "Form1";
        Text = "Form1";
        Load += new EventHandler(Form1_Load);
        ((System.ComponentModel.ISupportInitialize)dataGrid1).EndInit();
        ((System.ComponentModel.ISupportInitialize)dataGrid2).EndInit();
        ResumeLayout(false);
    }

    #endregion Code généré par le Concepteur Windows Form

    /// Point d'entrée principal de l'application.
    [STAThread]
    private static void Main() => Application.Run(new Form1());

    private void Form1_Load(object sender, EventArgs e)
    {
        Remplit1();
        Remplit2();
    }

    private void Remplit1()
    {
        SqlConnection nwindConn = new("Persist Security Info=False;Integrated Security=SSPI;database=NorthWind;server='LU01ZEPHYR\\SQL2008';Connect Timeout=30");
        SqlCommand selectCMD = new("SELECT CompanyName, ContactName, City, Country FROM Customers", nwindConn)
        {
            CommandTimeout = 30
        };

        SqlDataAdapter custDA = new()
        {
            SelectCommand = selectCMD
        };

        nwindConn.Open();
        DataSet myDataSet = new();
        _ = custDA.Fill(myDataSet, "Customers");
        nwindConn.Close();

        dataGrid1.DataSource = myDataSet;
        dataGrid1.DataMember = "Customers";

        // On crée un dataview
        //DataView myDataView = new DataView(myDataSet.Tables["Suppliers"], "Country = 'UK'", "CompanyName", DataViewRowState.CurrentRows);
    }

    // DataTable créée dans le code
    private void Remplit2()
    {
        DataTable myTable = new("Suppliers");

        var col1 = myTable.Columns.Add("Nom", Type.GetType("System.String"));
        col1.ReadOnly = true;
        var col2 = myTable.Columns.Add("Tel", Type.GetType("System.Int32"));

        _ = myTable.Rows.Add(new object[] { "Pierre", 8873 });
        _ = myTable.Rows.Add(new object[] { "Xavier", 8317 });

        DataView myDataView = new(myTable);
        dataGrid2.DataSource = myDataView;
    }
}