' 094 VB DataGrid
' Essais ADO.Net
' 2004-04       PV
' 2006-10-01    PV  VS2005
' 2012-02-25	PV  VS2010

#Disable Warning IDE1006 ' Naming Styles

Public Class frmDataGrid
    Inherits Form

#Region " Code généré par le Concepteur Windows Form "

    Public Sub New()
        MyBase.New()

        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        'Ajoutez une initialisation quelconque après l'appel InitializeComponent()

    End Sub

    'La méthode substituée Dispose du formulaire pour nettoyer la liste des composants.
    Protected Overloads Overrides Sub Dispose(disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requis par le Concepteur Windows Form
    Private ReadOnly components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée en utilisant le Concepteur Windows Form.
    'Ne la modifiez pas en utilisant l'éditeur de code.
    Friend WithEvents SqlSelectCommand1 As SqlClient.SqlCommand

    Friend WithEvents SqlInsertCommand1 As SqlClient.SqlCommand
    Friend WithEvents SqlUpdateCommand1 As SqlClient.SqlCommand
    Friend WithEvents SqlDeleteCommand1 As SqlClient.SqlCommand
    Friend WithEvents SqlConnection1 As SqlClient.SqlConnection
    Friend WithEvents SqlDACustomers As SqlClient.SqlDataAdapter
    Friend WithEvents SqlSelectCommand2 As SqlClient.SqlCommand
    Friend WithEvents SqlInsertCommand2 As SqlClient.SqlCommand
    Friend WithEvents SqlUpdateCommand2 As SqlClient.SqlCommand
    Friend WithEvents SqlDeleteCommand2 As SqlClient.SqlCommand
    Friend WithEvents SqlDAOrders As SqlClient.SqlDataAdapter
    Friend WithEvents DGCustomers As DataGrid
    Friend WithEvents DGOrders As DataGrid
    Friend WithEvents btnLire As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents btnEffacer As Button
    Friend WithEvents myDS_NorthWind As DS_NorthWind

    <DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(frmDataGrid))
        Me.SqlSelectCommand1 = New SqlClient.SqlCommand()
        Me.SqlConnection1 = New SqlClient.SqlConnection()
        Me.SqlInsertCommand1 = New SqlClient.SqlCommand()
        Me.SqlUpdateCommand1 = New SqlClient.SqlCommand()
        Me.SqlDeleteCommand1 = New SqlClient.SqlCommand()
        Me.SqlDACustomers = New SqlClient.SqlDataAdapter()
        Me.myDS_NorthWind = New DS_NorthWind()
        Me.SqlSelectCommand2 = New SqlClient.SqlCommand()
        Me.SqlInsertCommand2 = New SqlClient.SqlCommand()
        Me.SqlUpdateCommand2 = New SqlClient.SqlCommand()
        Me.SqlDeleteCommand2 = New SqlClient.SqlCommand()
        Me.SqlDAOrders = New SqlClient.SqlDataAdapter()
        Me.DGCustomers = New DataGrid()
        Me.DGOrders = New DataGrid()
        Me.btnLire = New Button()
        Me.btnUpdate = New Button()
        Me.btnCancel = New Button()
        Me.btnEffacer = New Button()
        CType(Me.myDS_NorthWind, ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGCustomers, ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGOrders, ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SqlSelectCommand1
        '
        Me.SqlSelectCommand1.CommandText = "SELECT CustomerID, CompanyName, ContactName, ContactTitle, Address, City, Region," &
    " PostalCode, Country, Phone, Fax FROM Customers"
        Me.SqlSelectCommand1.Connection = Me.SqlConnection1
        '
        'SqlConnection1
        '
        Me.SqlConnection1.ConnectionString = "Data Source=LU01ZEPHYR\SQL2008;Initial Catalog=NorthWind;Integrated Security=True" &
    ""
        Me.SqlConnection1.FireInfoMessageEventOnUserErrors = False
        '
        'SqlInsertCommand1
        '
        Me.SqlInsertCommand1.CommandText = resources.GetString("SqlInsertCommand1.CommandText")
        Me.SqlInsertCommand1.Connection = Me.SqlConnection1
        Me.SqlInsertCommand1.Parameters.AddRange(New SqlClient.SqlParameter() {New SqlClient.SqlParameter("@CustomerID", System.Data.SqlDbType.NVarChar, 5, "CustomerID"), New SqlClient.SqlParameter("@CompanyName", System.Data.SqlDbType.NVarChar, 40, "CompanyName"), New SqlClient.SqlParameter("@ContactName", System.Data.SqlDbType.NVarChar, 30, "ContactName"), New SqlClient.SqlParameter("@ContactTitle", System.Data.SqlDbType.NVarChar, 30, "ContactTitle"), New SqlClient.SqlParameter("@Address", System.Data.SqlDbType.NVarChar, 60, "Address"), New SqlClient.SqlParameter("@City", System.Data.SqlDbType.NVarChar, 15, "City"), New SqlClient.SqlParameter("@Region", System.Data.SqlDbType.NVarChar, 15, "Region"), New SqlClient.SqlParameter("@PostalCode", System.Data.SqlDbType.NVarChar, 10, "PostalCode"), New SqlClient.SqlParameter("@Country", System.Data.SqlDbType.NVarChar, 15, "Country"), New SqlClient.SqlParameter("@Phone", System.Data.SqlDbType.NVarChar, 24, "Phone"), New SqlClient.SqlParameter("@Fax", System.Data.SqlDbType.NVarChar, 24, "Fax")})
        '
        'SqlUpdateCommand1
        '
        Me.SqlUpdateCommand1.CommandText = resources.GetString("SqlUpdateCommand1.CommandText")
        Me.SqlUpdateCommand1.Connection = Me.SqlConnection1
        Me.SqlUpdateCommand1.Parameters.AddRange(New SqlClient.SqlParameter() {New SqlClient.SqlParameter("@CustomerID", System.Data.SqlDbType.NVarChar, 5, "CustomerID"), New SqlClient.SqlParameter("@CompanyName", System.Data.SqlDbType.NVarChar, 40, "CompanyName"), New SqlClient.SqlParameter("@ContactName", System.Data.SqlDbType.NVarChar, 30, "ContactName"), New SqlClient.SqlParameter("@ContactTitle", System.Data.SqlDbType.NVarChar, 30, "ContactTitle"), New SqlClient.SqlParameter("@Address", System.Data.SqlDbType.NVarChar, 60, "Address"), New SqlClient.SqlParameter("@City", System.Data.SqlDbType.NVarChar, 15, "City"), New SqlClient.SqlParameter("@Region", System.Data.SqlDbType.NVarChar, 15, "Region"), New SqlClient.SqlParameter("@PostalCode", System.Data.SqlDbType.NVarChar, 10, "PostalCode"), New SqlClient.SqlParameter("@Country", System.Data.SqlDbType.NVarChar, 15, "Country"), New SqlClient.SqlParameter("@Phone", System.Data.SqlDbType.NVarChar, 24, "Phone"), New SqlClient.SqlParameter("@Fax", System.Data.SqlDbType.NVarChar, 24, "Fax"), New SqlClient.SqlParameter("@Original_CustomerID", System.Data.SqlDbType.NVarChar, 5, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CustomerID", System.Data.DataRowVersion.Original, Nothing), New SqlClient.SqlParameter("@Original_Address", System.Data.SqlDbType.NVarChar, 60, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Address", System.Data.DataRowVersion.Original, Nothing), New SqlClient.SqlParameter("@Original_City", System.Data.SqlDbType.NVarChar, 15, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "City", System.Data.DataRowVersion.Original, Nothing), New SqlClient.SqlParameter("@Original_CompanyName", System.Data.SqlDbType.NVarChar, 40, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CompanyName", System.Data.DataRowVersion.Original, Nothing), New SqlClient.SqlParameter("@Original_ContactName", System.Data.SqlDbType.NVarChar, 30, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ContactName", System.Data.DataRowVersion.Original, Nothing), New SqlClient.SqlParameter("@Original_ContactTitle", System.Data.SqlDbType.NVarChar, 30, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ContactTitle", System.Data.DataRowVersion.Original, Nothing), New SqlClient.SqlParameter("@Original_Country", System.Data.SqlDbType.NVarChar, 15, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Country", System.Data.DataRowVersion.Original, Nothing), New SqlClient.SqlParameter("@Original_Fax", System.Data.SqlDbType.NVarChar, 24, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Fax", System.Data.DataRowVersion.Original, Nothing), New SqlClient.SqlParameter("@Original_Phone", System.Data.SqlDbType.NVarChar, 24, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Phone", System.Data.DataRowVersion.Original, Nothing), New SqlClient.SqlParameter("@Original_PostalCode", System.Data.SqlDbType.NVarChar, 10, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "PostalCode", System.Data.DataRowVersion.Original, Nothing), New SqlClient.SqlParameter("@Original_Region", System.Data.SqlDbType.NVarChar, 15, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Region", System.Data.DataRowVersion.Original, Nothing)})
        '
        'SqlDeleteCommand1
        '
        Me.SqlDeleteCommand1.CommandText = resources.GetString("SqlDeleteCommand1.CommandText")
        Me.SqlDeleteCommand1.Connection = Me.SqlConnection1
        Me.SqlDeleteCommand1.Parameters.AddRange(New SqlClient.SqlParameter() {New SqlClient.SqlParameter("@Original_CustomerID", System.Data.SqlDbType.NVarChar, 5, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CustomerID", System.Data.DataRowVersion.Original, Nothing), New SqlClient.SqlParameter("@Original_Address", System.Data.SqlDbType.NVarChar, 60, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Address", System.Data.DataRowVersion.Original, Nothing), New SqlClient.SqlParameter("@Original_City", System.Data.SqlDbType.NVarChar, 15, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "City", System.Data.DataRowVersion.Original, Nothing), New SqlClient.SqlParameter("@Original_CompanyName", System.Data.SqlDbType.NVarChar, 40, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CompanyName", System.Data.DataRowVersion.Original, Nothing), New SqlClient.SqlParameter("@Original_ContactName", System.Data.SqlDbType.NVarChar, 30, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ContactName", System.Data.DataRowVersion.Original, Nothing), New SqlClient.SqlParameter("@Original_ContactTitle", System.Data.SqlDbType.NVarChar, 30, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ContactTitle", System.Data.DataRowVersion.Original, Nothing), New SqlClient.SqlParameter("@Original_Country", System.Data.SqlDbType.NVarChar, 15, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Country", System.Data.DataRowVersion.Original, Nothing), New SqlClient.SqlParameter("@Original_Fax", System.Data.SqlDbType.NVarChar, 24, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Fax", System.Data.DataRowVersion.Original, Nothing), New SqlClient.SqlParameter("@Original_Phone", System.Data.SqlDbType.NVarChar, 24, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Phone", System.Data.DataRowVersion.Original, Nothing), New SqlClient.SqlParameter("@Original_PostalCode", System.Data.SqlDbType.NVarChar, 10, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "PostalCode", System.Data.DataRowVersion.Original, Nothing), New SqlClient.SqlParameter("@Original_Region", System.Data.SqlDbType.NVarChar, 15, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Region", System.Data.DataRowVersion.Original, Nothing)})
        '
        'SqlDACustomers
        '
        Me.SqlDACustomers.DeleteCommand = Me.SqlDeleteCommand1
        Me.SqlDACustomers.InsertCommand = Me.SqlInsertCommand1
        Me.SqlDACustomers.SelectCommand = Me.SqlSelectCommand1
        Me.SqlDACustomers.TableMappings.AddRange(New Common.DataTableMapping() {New Common.DataTableMapping("Table", "Customers", New Common.DataColumnMapping() {New Common.DataColumnMapping("CustomerID", "CustomerID"), New Common.DataColumnMapping("CompanyName", "CompanyName"), New Common.DataColumnMapping("ContactName", "ContactName"), New Common.DataColumnMapping("ContactTitle", "ContactTitle"), New Common.DataColumnMapping("Address", "Address"), New Common.DataColumnMapping("City", "City"), New Common.DataColumnMapping("Region", "Region"), New Common.DataColumnMapping("PostalCode", "PostalCode"), New Common.DataColumnMapping("Country", "Country"), New Common.DataColumnMapping("Phone", "Phone"), New Common.DataColumnMapping("Fax", "Fax")})})
        Me.SqlDACustomers.UpdateCommand = Me.SqlUpdateCommand1
        '
        'myDS_NorthWind
        '
        Me.myDS_NorthWind.DataSetName = "DS_NorthWind"
        Me.myDS_NorthWind.Locale = New Globalization.CultureInfo("fr-FR")
        Me.myDS_NorthWind.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'SqlSelectCommand2
        '
        Me.SqlSelectCommand2.CommandText = "SELECT OrderID, CustomerID, EmployeeID, OrderDate, RequiredDate, ShippedDate, Shi" &
    "pVia, Freight, ShipName, ShipAddress, ShipCity, ShipRegion, ShipPostalCode, Ship" &
    "Country FROM Orders"
        Me.SqlSelectCommand2.Connection = Me.SqlConnection1
        '
        'SqlInsertCommand2
        '
        Me.SqlInsertCommand2.CommandText = resources.GetString("SqlInsertCommand2.CommandText")
        Me.SqlInsertCommand2.Connection = Me.SqlConnection1
        Me.SqlInsertCommand2.Parameters.AddRange(New SqlClient.SqlParameter() {New SqlClient.SqlParameter("@CustomerID", System.Data.SqlDbType.NVarChar, 5, "CustomerID"), New SqlClient.SqlParameter("@EmployeeID", System.Data.SqlDbType.Int, 4, "EmployeeID"), New SqlClient.SqlParameter("@OrderDate", System.Data.SqlDbType.DateTime, 8, "OrderDate"), New SqlClient.SqlParameter("@RequiredDate", System.Data.SqlDbType.DateTime, 8, "RequiredDate"), New SqlClient.SqlParameter("@ShippedDate", System.Data.SqlDbType.DateTime, 8, "ShippedDate"), New SqlClient.SqlParameter("@ShipVia", System.Data.SqlDbType.Int, 4, "ShipVia"), New SqlClient.SqlParameter("@Freight", System.Data.SqlDbType.Money, 8, "Freight"), New SqlClient.SqlParameter("@ShipName", System.Data.SqlDbType.NVarChar, 40, "ShipName"), New SqlClient.SqlParameter("@ShipAddress", System.Data.SqlDbType.NVarChar, 60, "ShipAddress"), New SqlClient.SqlParameter("@ShipCity", System.Data.SqlDbType.NVarChar, 15, "ShipCity"), New SqlClient.SqlParameter("@ShipRegion", System.Data.SqlDbType.NVarChar, 15, "ShipRegion"), New SqlClient.SqlParameter("@ShipPostalCode", System.Data.SqlDbType.NVarChar, 10, "ShipPostalCode"), New SqlClient.SqlParameter("@ShipCountry", System.Data.SqlDbType.NVarChar, 15, "ShipCountry")})
        '
        'SqlUpdateCommand2
        '
        Me.SqlUpdateCommand2.CommandText = resources.GetString("SqlUpdateCommand2.CommandText")
        Me.SqlUpdateCommand2.Connection = Me.SqlConnection1
        Me.SqlUpdateCommand2.Parameters.AddRange(New SqlClient.SqlParameter() {New SqlClient.SqlParameter("@CustomerID", System.Data.SqlDbType.NVarChar, 5, "CustomerID"), New SqlClient.SqlParameter("@EmployeeID", System.Data.SqlDbType.Int, 4, "EmployeeID"), New SqlClient.SqlParameter("@OrderDate", System.Data.SqlDbType.DateTime, 8, "OrderDate"), New SqlClient.SqlParameter("@RequiredDate", System.Data.SqlDbType.DateTime, 8, "RequiredDate"), New SqlClient.SqlParameter("@ShippedDate", System.Data.SqlDbType.DateTime, 8, "ShippedDate"), New SqlClient.SqlParameter("@ShipVia", System.Data.SqlDbType.Int, 4, "ShipVia"), New SqlClient.SqlParameter("@Freight", System.Data.SqlDbType.Money, 8, "Freight"), New SqlClient.SqlParameter("@ShipName", System.Data.SqlDbType.NVarChar, 40, "ShipName"), New SqlClient.SqlParameter("@ShipAddress", System.Data.SqlDbType.NVarChar, 60, "ShipAddress"), New SqlClient.SqlParameter("@ShipCity", System.Data.SqlDbType.NVarChar, 15, "ShipCity"), New SqlClient.SqlParameter("@ShipRegion", System.Data.SqlDbType.NVarChar, 15, "ShipRegion"), New SqlClient.SqlParameter("@ShipPostalCode", System.Data.SqlDbType.NVarChar, 10, "ShipPostalCode"), New SqlClient.SqlParameter("@ShipCountry", System.Data.SqlDbType.NVarChar, 15, "ShipCountry"), New SqlClient.SqlParameter("@Original_OrderID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "OrderID", System.Data.DataRowVersion.Original, Nothing), New SqlClient.SqlParameter("@Original_CustomerID", System.Data.SqlDbType.NVarChar, 5, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CustomerID", System.Data.DataRowVersion.Original, Nothing), New SqlClient.SqlParameter("@Original_EmployeeID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "EmployeeID", System.Data.DataRowVersion.Original, Nothing), New SqlClient.SqlParameter("@Original_Freight", System.Data.SqlDbType.Money, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Freight", System.Data.DataRowVersion.Original, Nothing), New SqlClient.SqlParameter("@Original_OrderDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "OrderDate", System.Data.DataRowVersion.Original, Nothing), New SqlClient.SqlParameter("@Original_RequiredDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "RequiredDate", System.Data.DataRowVersion.Original, Nothing), New SqlClient.SqlParameter("@Original_ShipAddress", System.Data.SqlDbType.NVarChar, 60, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ShipAddress", System.Data.DataRowVersion.Original, Nothing), New SqlClient.SqlParameter("@Original_ShipCity", System.Data.SqlDbType.NVarChar, 15, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ShipCity", System.Data.DataRowVersion.Original, Nothing), New SqlClient.SqlParameter("@Original_ShipCountry", System.Data.SqlDbType.NVarChar, 15, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ShipCountry", System.Data.DataRowVersion.Original, Nothing), New SqlClient.SqlParameter("@Original_ShipName", System.Data.SqlDbType.NVarChar, 40, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ShipName", System.Data.DataRowVersion.Original, Nothing), New SqlClient.SqlParameter("@Original_ShipPostalCode", System.Data.SqlDbType.NVarChar, 10, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ShipPostalCode", System.Data.DataRowVersion.Original, Nothing), New SqlClient.SqlParameter("@Original_ShipRegion", System.Data.SqlDbType.NVarChar, 15, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ShipRegion", System.Data.DataRowVersion.Original, Nothing), New SqlClient.SqlParameter("@Original_ShipVia", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ShipVia", System.Data.DataRowVersion.Original, Nothing), New SqlClient.SqlParameter("@Original_ShippedDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ShippedDate", System.Data.DataRowVersion.Original, Nothing), New SqlClient.SqlParameter("@OrderID", System.Data.SqlDbType.Int, 4, "OrderID")})
        '
        'SqlDeleteCommand2
        '
        Me.SqlDeleteCommand2.CommandText = resources.GetString("SqlDeleteCommand2.CommandText")
        Me.SqlDeleteCommand2.Connection = Me.SqlConnection1
        Me.SqlDeleteCommand2.Parameters.AddRange(New SqlClient.SqlParameter() {New SqlClient.SqlParameter("@Original_OrderID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "OrderID", System.Data.DataRowVersion.Original, Nothing), New SqlClient.SqlParameter("@Original_CustomerID", System.Data.SqlDbType.NVarChar, 5, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "CustomerID", System.Data.DataRowVersion.Original, Nothing), New SqlClient.SqlParameter("@Original_EmployeeID", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "EmployeeID", System.Data.DataRowVersion.Original, Nothing), New SqlClient.SqlParameter("@Original_Freight", System.Data.SqlDbType.Money, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "Freight", System.Data.DataRowVersion.Original, Nothing), New SqlClient.SqlParameter("@Original_OrderDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "OrderDate", System.Data.DataRowVersion.Original, Nothing), New SqlClient.SqlParameter("@Original_RequiredDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "RequiredDate", System.Data.DataRowVersion.Original, Nothing), New SqlClient.SqlParameter("@Original_ShipAddress", System.Data.SqlDbType.NVarChar, 60, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ShipAddress", System.Data.DataRowVersion.Original, Nothing), New SqlClient.SqlParameter("@Original_ShipCity", System.Data.SqlDbType.NVarChar, 15, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ShipCity", System.Data.DataRowVersion.Original, Nothing), New SqlClient.SqlParameter("@Original_ShipCountry", System.Data.SqlDbType.NVarChar, 15, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ShipCountry", System.Data.DataRowVersion.Original, Nothing), New SqlClient.SqlParameter("@Original_ShipName", System.Data.SqlDbType.NVarChar, 40, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ShipName", System.Data.DataRowVersion.Original, Nothing), New SqlClient.SqlParameter("@Original_ShipPostalCode", System.Data.SqlDbType.NVarChar, 10, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ShipPostalCode", System.Data.DataRowVersion.Original, Nothing), New SqlClient.SqlParameter("@Original_ShipRegion", System.Data.SqlDbType.NVarChar, 15, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ShipRegion", System.Data.DataRowVersion.Original, Nothing), New SqlClient.SqlParameter("@Original_ShipVia", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ShipVia", System.Data.DataRowVersion.Original, Nothing), New SqlClient.SqlParameter("@Original_ShippedDate", System.Data.SqlDbType.DateTime, 8, System.Data.ParameterDirection.Input, False, CType(0, Byte), CType(0, Byte), "ShippedDate", System.Data.DataRowVersion.Original, Nothing)})
        '
        'SqlDAOrders
        '
        Me.SqlDAOrders.DeleteCommand = Me.SqlDeleteCommand2
        Me.SqlDAOrders.InsertCommand = Me.SqlInsertCommand2
        Me.SqlDAOrders.SelectCommand = Me.SqlSelectCommand2
        Me.SqlDAOrders.TableMappings.AddRange(New Common.DataTableMapping() {New Common.DataTableMapping("Table", "Orders", New Common.DataColumnMapping() {New Common.DataColumnMapping("OrderID", "OrderID"), New Common.DataColumnMapping("CustomerID", "CustomerID"), New Common.DataColumnMapping("EmployeeID", "EmployeeID"), New Common.DataColumnMapping("OrderDate", "OrderDate"), New Common.DataColumnMapping("RequiredDate", "RequiredDate"), New Common.DataColumnMapping("ShippedDate", "ShippedDate"), New Common.DataColumnMapping("ShipVia", "ShipVia"), New Common.DataColumnMapping("Freight", "Freight"), New Common.DataColumnMapping("ShipName", "ShipName"), New Common.DataColumnMapping("ShipAddress", "ShipAddress"), New Common.DataColumnMapping("ShipCity", "ShipCity"), New Common.DataColumnMapping("ShipRegion", "ShipRegion"), New Common.DataColumnMapping("ShipPostalCode", "ShipPostalCode"), New Common.DataColumnMapping("ShipCountry", "ShipCountry")})})
        Me.SqlDAOrders.UpdateCommand = Me.SqlUpdateCommand2
        '
        'DGCustomers
        '
        Me.DGCustomers.DataMember = "Customers"
        Me.DGCustomers.DataSource = Me.myDS_NorthWind
        Me.DGCustomers.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DGCustomers.Location = New Point(8, 8)
        Me.DGCustomers.Name = "DGCustomers"
        Me.DGCustomers.Size = New Size(744, 216)
        Me.DGCustomers.TabIndex = 0
        '
        'DGOrders
        '
        Me.DGOrders.DataMember = "Customers.CustomersOrders"
        Me.DGOrders.DataSource = Me.myDS_NorthWind
        Me.DGOrders.HeaderForeColor = System.Drawing.SystemColors.ControlText
        Me.DGOrders.Location = New Point(8, 232)
        Me.DGOrders.Name = "DGOrders"
        Me.DGOrders.Size = New Size(744, 200)
        Me.DGOrders.TabIndex = 1
        '
        'btnLire
        '
        Me.btnLire.Location = New Point(8, 448)
        Me.btnLire.Name = "btnLire"
        Me.btnLire.Size = New Size(75, 23)
        Me.btnLire.TabIndex = 2
        Me.btnLire.Text = "Lire"
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New Point(96, 448)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New Size(75, 23)
        Me.btnUpdate.TabIndex = 3
        Me.btnUpdate.Text = "Update"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New Point(184, 448)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New Size(75, 23)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "Cancel"
        '
        'btnEffacer
        '
        Me.btnEffacer.Location = New Point(272, 448)
        Me.btnEffacer.Name = "btnEffacer"
        Me.btnEffacer.Size = New Size(75, 23)
        Me.btnEffacer.TabIndex = 5
        Me.btnEffacer.Text = "Clear"
        '
        'frmDataGrid
        '
        Me.AutoScaleBaseSize = New Size(5, 13)
        Me.ClientSize = New Size(760, 558)
        Me.Controls.Add(Me.btnEffacer)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.btnLire)
        Me.Controls.Add(Me.DGOrders)
        Me.Controls.Add(Me.DGCustomers)
        Me.Name = "frmDataGrid"
        Me.Text = "Form1"
        CType(Me.myDS_NorthWind, ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGCustomers, ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGOrders, ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnLire_Click(sender As System.Object, e As EventArgs) Handles btnLire.Click
        SqlDACustomers.Fill(myDS_NorthWind)
        SqlDAOrders.Fill(myDS_NorthWind)
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As EventArgs) Handles btnCancel.Click
        myDS_NorthWind.RejectChanges()
    End Sub

    Private Sub btnUpdate_Click(sender As System.Object, e As EventArgs) Handles btnUpdate.Click
        ' Mise à jour des clients et des commandes
        SqlDACustomers.Update(myDS_NorthWind)
        SqlDAOrders.Update(myDS_NorthWind)
    End Sub

    Private Sub btnEffacer_Click(sender As System.Object, e As EventArgs) Handles btnEffacer.Click
        myDS_NorthWind.Clear()
    End Sub

End Class