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
        this.dataGrid1 = new DataGridView();
        this.dataGrid2 = new DataGridView();
        this.label2 = new Label();
        this.label1 = new Label();
        ((System.ComponentModel.ISupportInitialize)this.dataGrid1).BeginInit();
        ((System.ComponentModel.ISupportInitialize)this.dataGrid2).BeginInit();
        this.SuspendLayout();
        //
        // dataGrid1
        //
        this.dataGrid1.DataMember = "";
        //this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
        this.dataGrid1.Location = new System.Drawing.Point(8, 24);
        this.dataGrid1.Name = "dataGrid1";
        this.dataGrid1.Size = new System.Drawing.Size(448, 228);
        this.dataGrid1.TabIndex = 0;
        //
        // dataGrid2
        //
        this.dataGrid2.DataMember = "";
        //this.dataGrid2.HeaderForeColor = System.Drawing.SystemColors.ControlText;
        this.dataGrid2.Location = new System.Drawing.Point(8, 284);
        this.dataGrid2.Name = "dataGrid2";
        this.dataGrid2.Size = new System.Drawing.Size(276, 228);
        this.dataGrid2.TabIndex = 2;
        //
        // label2
        //
        this.label2.AutoSize = true;
        this.label2.Location = new System.Drawing.Point(8, 264);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(155, 16);
        this.label2.TabIndex = 3;
        this.label2.Text = "DataTable créée dans le code";
        //
        // label1
        //
        this.label1.AutoSize = true;
        this.label1.Location = new System.Drawing.Point(8, 8);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(224, 16);
        this.label1.TabIndex = 4;
        this.label1.Text = "DataSet lu dans la base via un DataAdapter";
        //
        // Form1
        //
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.ClientSize = new System.Drawing.Size(744, 530);
        this.Controls.Add(this.label1);
        this.Controls.Add(this.label2);
        this.Controls.Add(this.dataGrid2);
        this.Controls.Add(this.dataGrid1);
        this.Name = "Form1";
        this.Text = "Form1";
        this.Load += new EventHandler(this.Form1_Load);
        ((System.ComponentModel.ISupportInitialize)this.dataGrid1).EndInit();
        ((System.ComponentModel.ISupportInitialize)this.dataGrid2).EndInit();
        this.ResumeLayout(false);
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

        DataColumn col1;
        col1 = myTable.Columns.Add("Nom", System.Type.GetType("System.String"));
        col1.ReadOnly = true;
        DataColumn col2;
        col2 = myTable.Columns.Add("Tel", System.Type.GetType("System.Int32"));

        _ = myTable.Rows.Add(new object[] { "Pierre", 8873 });
        _ = myTable.Rows.Add(new object[] { "Xavier", 8317 });

        DataView myDataView = new(myTable);
        dataGrid2.DataSource = myDataView;
    }
}