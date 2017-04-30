Public Partial Class frmClients2
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

    End Sub

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmClients2))
        Me.ClientsDataConnector = New System.Windows.Forms.DataConnector(Me.components)
        Me.ClientsDataNavigator = New System.Windows.Forms.DataNavigator(Me.components)
        Me.leftToolStripPanel = New System.Windows.Forms.ToolStripPanel
        Me.rightToolStripPanel = New System.Windows.Forms.ToolStripPanel
        Me.topToolStripPanel = New System.Windows.Forms.ToolStripPanel
        Me.bottomToolStripPanel = New System.Windows.Forms.ToolStripPanel
        Me.dataNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton
        Me.dataNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton
        Me.dataNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.dataNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox
        Me.dataNavigatorCountItem = New System.Windows.Forms.ToolStripLabel
        Me.dataNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.dataNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton
        Me.dataNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton
        Me.dataNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.dataNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton
        Me.dataNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton
        Me.dataNavigatorSaveItem = New System.Windows.Forms.ToolStripButton
        Me.ClientIdLabel = New System.Windows.Forms.Label
        Me.ClientIdTextBox = New System.Windows.Forms.TextBox
        Me.NomLabel = New System.Windows.Forms.Label
        Me.NomTextBox = New System.Windows.Forms.TextBox
        Me.VilleLabel = New System.Windows.Forms.Label
        Me.VilleTextBox = New System.Windows.Forms.TextBox
        Me.FK_Commandes_ClientsDataConnector = New System.Windows.Forms.DataConnector(Me.components)
        Me.CommandesDataGridView = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotoDataSet = New DBApplication.totoDataSet
        Me.ClientsTableAdapter = New DBApplication.ClientsTableAdapter
        Me.CommandesTableAdapter = New DBApplication.CommandesTableAdapter
        Me.LignesDeCommandeDataGridView = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FK_LignesDeCommande_Commandes = New System.Windows.Forms.DataConnector(Me.components)
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.LignesDeCommandeTableAdapter = New DBApplication.LignesDeCommandeTableAdapter
        CType(Me.ClientsDataConnector, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ClientsDataNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ClientsDataNavigator.SuspendLayout()
        CType(Me.leftToolStripPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rightToolStripPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.topToolStripPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.topToolStripPanel.SuspendLayout()
        CType(Me.bottomToolStripPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FK_Commandes_ClientsDataConnector, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CommandesDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TotoDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LignesDeCommandeDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FK_LignesDeCommande_Commandes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ClientsDataConnector
        '
        Me.ClientsDataConnector.DataMember = "Clients"
        Me.ClientsDataConnector.DataSource = Me.TotoDataSet
        '
        'ClientsDataNavigator
        '
        Me.ClientsDataNavigator.AddNewItem = Me.dataNavigatorAddNewItem
        Me.ClientsDataNavigator.CountItem = Me.dataNavigatorCountItem
        Me.ClientsDataNavigator.CountItemFormat = "of {0}"
        Me.ClientsDataNavigator.DataConnector = Me.ClientsDataConnector
        Me.ClientsDataNavigator.DeleteItem = Me.dataNavigatorDeleteItem
        Me.ClientsDataNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.dataNavigatorMoveFirstItem, Me.dataNavigatorMovePreviousItem, Me.dataNavigatorSeparator, Me.dataNavigatorPositionItem, Me.dataNavigatorCountItem, Me.dataNavigatorSeparator1, Me.dataNavigatorMoveNextItem, Me.dataNavigatorMoveLastItem, Me.dataNavigatorSeparator2, Me.dataNavigatorAddNewItem, Me.dataNavigatorDeleteItem, Me.dataNavigatorSaveItem})
        Me.ClientsDataNavigator.Location = New System.Drawing.Point(0, 0)
        Me.ClientsDataNavigator.MoveFirstItem = Me.dataNavigatorMoveFirstItem
        Me.ClientsDataNavigator.MoveLastItem = Me.dataNavigatorMoveLastItem
        Me.ClientsDataNavigator.MoveNextItem = Me.dataNavigatorMoveNextItem
        Me.ClientsDataNavigator.MovePreviousItem = Me.dataNavigatorMovePreviousItem
        Me.ClientsDataNavigator.Name = "ClientsDataNavigator"
        Me.ClientsDataNavigator.PositionItem = Me.dataNavigatorPositionItem
        Me.ClientsDataNavigator.Raft = System.Windows.Forms.RaftingSides.Top
        Me.ClientsDataNavigator.TabIndex = 0
        Me.ClientsDataNavigator.Text = "DataNavigator1"
        '
        'leftToolStripPanel
        '
        Me.leftToolStripPanel.Dock = System.Windows.Forms.DockStyle.Left
        Me.leftToolStripPanel.Name = "leftToolStripPanel"
        '
        'rightToolStripPanel
        '
        Me.rightToolStripPanel.Dock = System.Windows.Forms.DockStyle.Right
        Me.rightToolStripPanel.Name = "rightToolStripPanel"
        '
        'topToolStripPanel
        '
        Me.topToolStripPanel.Controls.Add(Me.ClientsDataNavigator)
        Me.topToolStripPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.topToolStripPanel.Name = "topToolStripPanel"
        '
        'bottomToolStripPanel
        '
        Me.bottomToolStripPanel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.bottomToolStripPanel.Name = "bottomToolStripPanel"
        '
        'dataNavigatorMoveFirstItem
        '
        Me.dataNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.dataNavigatorMoveFirstItem.Image = CType(resources.GetObject("dataNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.dataNavigatorMoveFirstItem.Name = "dataNavigatorMoveFirstItem"
        Me.dataNavigatorMoveFirstItem.SettingsKey = "frmClients2.dataNavigatorMoveFirstItem"
        Me.dataNavigatorMoveFirstItem.Text = "Move first"
        '
        'dataNavigatorMovePreviousItem
        '
        Me.dataNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.dataNavigatorMovePreviousItem.Image = CType(resources.GetObject("dataNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.dataNavigatorMovePreviousItem.Name = "dataNavigatorMovePreviousItem"
        Me.dataNavigatorMovePreviousItem.SettingsKey = "frmClients2.dataNavigatorMovePreviousItem"
        Me.dataNavigatorMovePreviousItem.Text = "Move previous"
        '
        'dataNavigatorSeparator
        '
        Me.dataNavigatorSeparator.Name = "dataNavigatorSeparator"
        Me.dataNavigatorSeparator.SettingsKey = "frmClients2.dataNavigatorSeparator"
        '
        'dataNavigatorPositionItem
        '
        Me.dataNavigatorPositionItem.Name = "dataNavigatorPositionItem"
        Me.dataNavigatorPositionItem.SettingsKey = "frmClients2.dataNavigatorPositionItem"
        Me.dataNavigatorPositionItem.Size = New System.Drawing.Size(50, 25)
        Me.dataNavigatorPositionItem.Text = "0"
        Me.dataNavigatorPositionItem.ToolTipText = "Current position"
        '
        'dataNavigatorCountItem
        '
        Me.dataNavigatorCountItem.Name = "dataNavigatorCountItem"
        Me.dataNavigatorCountItem.SettingsKey = "frmClients2.dataNavigatorCountItem"
        Me.dataNavigatorCountItem.Text = "of 0"
        Me.dataNavigatorCountItem.ToolTipText = "Total number of items"
        '
        'dataNavigatorSeparator1
        '
        Me.dataNavigatorSeparator1.Name = "dataNavigatorSeparator"
        Me.dataNavigatorSeparator1.SettingsKey = "frmClients2.dataNavigatorSeparator1"
        '
        'dataNavigatorMoveNextItem
        '
        Me.dataNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.dataNavigatorMoveNextItem.Image = CType(resources.GetObject("dataNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.dataNavigatorMoveNextItem.Name = "dataNavigatorMoveNextItem"
        Me.dataNavigatorMoveNextItem.SettingsKey = "frmClients2.dataNavigatorMoveNextItem"
        Me.dataNavigatorMoveNextItem.Text = "Move next"
        '
        'dataNavigatorMoveLastItem
        '
        Me.dataNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.dataNavigatorMoveLastItem.Image = CType(resources.GetObject("dataNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.dataNavigatorMoveLastItem.Name = "dataNavigatorMoveLastItem"
        Me.dataNavigatorMoveLastItem.SettingsKey = "frmClients2.dataNavigatorMoveLastItem"
        Me.dataNavigatorMoveLastItem.Text = "Move last"
        '
        'dataNavigatorSeparator2
        '
        Me.dataNavigatorSeparator2.Name = "dataNavigatorSeparator"
        Me.dataNavigatorSeparator2.SettingsKey = "frmClients2.dataNavigatorSeparator2"
        '
        'dataNavigatorAddNewItem
        '
        Me.dataNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.dataNavigatorAddNewItem.Image = CType(resources.GetObject("dataNavigatorAddNewItem.Image"), System.Drawing.Image)
        Me.dataNavigatorAddNewItem.Name = "dataNavigatorAddNewItem"
        Me.dataNavigatorAddNewItem.SettingsKey = "frmClients2.dataNavigatorAddNewItem"
        Me.dataNavigatorAddNewItem.Text = "Add new"
        '
        'dataNavigatorDeleteItem
        '
        Me.dataNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.dataNavigatorDeleteItem.Image = CType(resources.GetObject("dataNavigatorDeleteItem.Image"), System.Drawing.Image)
        Me.dataNavigatorDeleteItem.Name = "dataNavigatorDeleteItem"
        Me.dataNavigatorDeleteItem.SettingsKey = "frmClients2.dataNavigatorDeleteItem"
        Me.dataNavigatorDeleteItem.Text = "Delete"
        '
        'dataNavigatorSaveItem
        '
        Me.dataNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.dataNavigatorSaveItem.Enabled = False
        Me.dataNavigatorSaveItem.Image = CType(resources.GetObject("dataNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.dataNavigatorSaveItem.Name = "dataNavigatorSaveItem"
        Me.dataNavigatorSaveItem.SettingsKey = "frmClients2.dataNavigatorSaveItem"
        Me.dataNavigatorSaveItem.Text = "Save Data"
        '
        'ClientIdLabel
        '
        Me.ClientIdLabel.AutoSize = True
        Me.ClientIdLabel.Location = New System.Drawing.Point(7, 32)
        Me.ClientIdLabel.Name = "ClientIdLabel"
        Me.ClientIdLabel.Size = New System.Drawing.Size(46, 14)
        Me.ClientIdLabel.TabIndex = 0
        Me.ClientIdLabel.Text = "ClientId:"
        '
        'ClientIdTextBox
        '
        Me.ClientIdTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ClientsDataConnector, "ClientId", True))
        Me.ClientIdTextBox.Location = New System.Drawing.Point(60, 29)
        Me.ClientIdTextBox.Name = "ClientIdTextBox"
        Me.ClientIdTextBox.TabIndex = 1
        '
        'NomLabel
        '
        Me.NomLabel.AutoSize = True
        Me.NomLabel.Location = New System.Drawing.Point(7, 59)
        Me.NomLabel.Name = "NomLabel"
        Me.NomLabel.Size = New System.Drawing.Size(31, 14)
        Me.NomLabel.TabIndex = 2
        Me.NomLabel.Text = "Nom:"
        '
        'NomTextBox
        '
        Me.NomTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ClientsDataConnector, "Nom", True))
        Me.NomTextBox.Location = New System.Drawing.Point(60, 56)
        Me.NomTextBox.Name = "NomTextBox"
        Me.NomTextBox.TabIndex = 3
        '
        'VilleLabel
        '
        Me.VilleLabel.AutoSize = True
        Me.VilleLabel.Location = New System.Drawing.Point(7, 86)
        Me.VilleLabel.Name = "VilleLabel"
        Me.VilleLabel.Size = New System.Drawing.Size(29, 14)
        Me.VilleLabel.TabIndex = 4
        Me.VilleLabel.Text = "Ville:"
        '
        'VilleTextBox
        '
        Me.VilleTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ClientsDataConnector, "Ville", True))
        Me.VilleTextBox.Location = New System.Drawing.Point(60, 83)
        Me.VilleTextBox.Name = "VilleTextBox"
        Me.VilleTextBox.TabIndex = 5
        '
        'FK_Commandes_ClientsDataConnector
        '
        Me.FK_Commandes_ClientsDataConnector.DataMember = "FK_Commandes_Clients"
        Me.FK_Commandes_ClientsDataConnector.DataSource = Me.ClientsDataConnector
        '
        'CommandesDataGridView
        '
        Me.CommandesDataGridView.AutoGenerateColumns = False
        Me.CommandesDataGridView.Columns.Add(Me.DataGridViewTextBoxColumn1)
        Me.CommandesDataGridView.Columns.Add(Me.DataGridViewTextBoxColumn2)
        Me.CommandesDataGridView.Columns.Add(Me.DataGridViewTextBoxColumn3)
        Me.CommandesDataGridView.DataSource = Me.FK_Commandes_ClientsDataConnector
        Me.CommandesDataGridView.Location = New System.Drawing.Point(7, 127)
        Me.CommandesDataGridView.Name = "CommandesDataGridView"
        Me.CommandesDataGridView.Size = New System.Drawing.Size(300, 220)
        Me.CommandesDataGridView.TabIndex = 5
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "CommandeId"
        Me.DataGridViewTextBoxColumn1.HeaderText = "CommandeId"
        Me.DataGridViewTextBoxColumn1.Name = "CommandeId"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.ValueType = GetType(Integer)
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "CliendId"
        Me.DataGridViewTextBoxColumn2.HeaderText = "CliendId"
        Me.DataGridViewTextBoxColumn2.Name = "CliendId"
        Me.DataGridViewTextBoxColumn2.ValueType = GetType(Integer)
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "DateCommande"
        Me.DataGridViewTextBoxColumn3.HeaderText = "DateCommande"
        Me.DataGridViewTextBoxColumn3.Name = "DateCommande"
        Me.DataGridViewTextBoxColumn3.ValueType = GetType(Date)
        '
        'TotoDataSet
        '
        Me.TotoDataSet.DataSetName = "totoDataSet"
        Me.TotoDataSet.Locale = New System.Globalization.CultureInfo("fr-FR")
        Me.TotoDataSet.RemotingFormat = System.Data.SerializationFormat.Xml
        '
        'ClientsTableAdapter
        '
        Me.ClientsTableAdapter.ClearBeforeFill = True
        '
        'CommandesTableAdapter
        '
        Me.CommandesTableAdapter.ClearBeforeFill = True
        '
        'LignesDeCommandeDataGridView
        '
        Me.LignesDeCommandeDataGridView.AutoGenerateColumns = False
        Me.LignesDeCommandeDataGridView.Columns.Add(Me.DataGridViewTextBoxColumn7)
        Me.LignesDeCommandeDataGridView.Columns.Add(Me.DataGridViewTextBoxColumn8)
        Me.LignesDeCommandeDataGridView.Columns.Add(Me.DataGridViewTextBoxColumn9)
        Me.LignesDeCommandeDataGridView.Columns.Add(Me.DataGridViewTextBoxColumn10)
        Me.LignesDeCommandeDataGridView.Columns.Add(Me.DataGridViewTextBoxColumn11)
        Me.LignesDeCommandeDataGridView.DataSource = Me.FK_LignesDeCommande_Commandes
        Me.LignesDeCommandeDataGridView.Location = New System.Drawing.Point(7, 368)
        Me.LignesDeCommandeDataGridView.Name = "LignesDeCommandeDataGridView"
        Me.LignesDeCommandeDataGridView.Size = New System.Drawing.Size(300, 220)
        Me.LignesDeCommandeDataGridView.TabIndex = 6
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "CommandeId"
        Me.DataGridViewTextBoxColumn4.HeaderText = "CommandeId"
        Me.DataGridViewTextBoxColumn4.Name = "CommandeId"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.ValueType = GetType(Integer)
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.DataPropertyName = "CliendId"
        Me.DataGridViewTextBoxColumn5.HeaderText = "CliendId"
        Me.DataGridViewTextBoxColumn5.Name = "CliendId"
        Me.DataGridViewTextBoxColumn5.ValueType = GetType(Integer)
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.DataPropertyName = "DateCommande"
        Me.DataGridViewTextBoxColumn6.HeaderText = "DateCommande"
        Me.DataGridViewTextBoxColumn6.Name = "DateCommande"
        Me.DataGridViewTextBoxColumn6.ValueType = GetType(Date)
        '
        'FK_LignesDeCommande_Commandes
        '
        Me.FK_LignesDeCommande_Commandes.DataMember = "FK_LignesDeCommande_Commandes"
        Me.FK_LignesDeCommande_Commandes.DataSource = Me.FK_Commandes_ClientsDataConnector
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "LigneDeCommandeId"
        Me.DataGridViewTextBoxColumn7.HeaderText = "LigneDeCommandeId"
        Me.DataGridViewTextBoxColumn7.Name = "LigneDeCommandeId"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.ValueType = GetType(Integer)
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "CommandeId"
        Me.DataGridViewTextBoxColumn8.HeaderText = "CommandeId"
        Me.DataGridViewTextBoxColumn8.Name = "CommandeId"
        Me.DataGridViewTextBoxColumn8.ValueType = GetType(Integer)
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "ArticleId"
        Me.DataGridViewTextBoxColumn9.HeaderText = "ArticleId"
        Me.DataGridViewTextBoxColumn9.Name = "ArticleId"
        Me.DataGridViewTextBoxColumn9.ValueType = GetType(Integer)
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.DataPropertyName = "Quantité"
        Me.DataGridViewTextBoxColumn10.HeaderText = "Quantité"
        Me.DataGridViewTextBoxColumn10.Name = "Quantité"
        Me.DataGridViewTextBoxColumn10.ValueType = GetType(Integer)
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "PrixUnitaire"
        Me.DataGridViewTextBoxColumn11.HeaderText = "PrixUnitaire"
        Me.DataGridViewTextBoxColumn11.Name = "PrixUnitaire"
        Me.DataGridViewTextBoxColumn11.ValueType = GetType(Decimal)
        '
        'LignesDeCommandeTableAdapter
        '
        Me.LignesDeCommandeTableAdapter.ClearBeforeFill = True
        '
        'frmClients2
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(475, 613)
        Me.Controls.Add(Me.LignesDeCommandeDataGridView)
        Me.Controls.Add(Me.CommandesDataGridView)
        Me.Controls.Add(Me.ClientIdLabel)
        Me.Controls.Add(Me.ClientIdTextBox)
        Me.Controls.Add(Me.NomLabel)
        Me.Controls.Add(Me.NomTextBox)
        Me.Controls.Add(Me.VilleLabel)
        Me.Controls.Add(Me.VilleTextBox)
        Me.Controls.Add(Me.leftToolStripPanel)
        Me.Controls.Add(Me.rightToolStripPanel)
        Me.Controls.Add(Me.topToolStripPanel)
        Me.Controls.Add(Me.bottomToolStripPanel)
        Me.Name = "frmClients2"
        Me.Text = "frmClients2"
        CType(Me.ClientsDataConnector, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ClientsDataNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ClientsDataNavigator.ResumeLayout(False)
        Me.ClientsDataNavigator.PerformLayout()
        CType(Me.leftToolStripPanel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rightToolStripPanel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.topToolStripPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.topToolStripPanel.ResumeLayout(False)
        Me.topToolStripPanel.PerformLayout()
        CType(Me.bottomToolStripPanel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FK_Commandes_ClientsDataConnector, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CommandesDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TotoDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LignesDeCommandeDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FK_LignesDeCommande_Commandes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ClientsDataConnector As System.Windows.Forms.DataConnector
    Friend WithEvents ClientsDataNavigator As System.Windows.Forms.DataNavigator
    Friend WithEvents leftToolStripPanel As System.Windows.Forms.ToolStripPanel
    Friend WithEvents rightToolStripPanel As System.Windows.Forms.ToolStripPanel
    Friend WithEvents topToolStripPanel As System.Windows.Forms.ToolStripPanel
    Friend WithEvents bottomToolStripPanel As System.Windows.Forms.ToolStripPanel
    Friend WithEvents dataNavigatorAddNewItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents dataNavigatorCountItem As System.Windows.Forms.ToolStripLabel
    Friend WithEvents dataNavigatorDeleteItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents dataNavigatorMoveFirstItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents dataNavigatorMovePreviousItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents dataNavigatorSeparator As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents dataNavigatorPositionItem As System.Windows.Forms.ToolStripTextBox
    Friend WithEvents dataNavigatorSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents dataNavigatorMoveNextItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents dataNavigatorMoveLastItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents dataNavigatorSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents dataNavigatorSaveItem As System.Windows.Forms.ToolStripButton
    Friend WithEvents ClientIdLabel As System.Windows.Forms.Label
    Friend WithEvents ClientIdTextBox As System.Windows.Forms.TextBox
    Friend WithEvents NomLabel As System.Windows.Forms.Label
    Friend WithEvents NomTextBox As System.Windows.Forms.TextBox
    Friend WithEvents VilleLabel As System.Windows.Forms.Label
    Friend WithEvents VilleTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TotoDataSet As DBApplication.totoDataSet
    Friend WithEvents ClientsTableAdapter As DBApplication.ClientsTableAdapter
    Friend WithEvents FK_Commandes_ClientsDataConnector As System.Windows.Forms.DataConnector
    Friend WithEvents CommandesTableAdapter As DBApplication.CommandesTableAdapter
    Friend WithEvents CommandesDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LignesDeCommandeDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FK_LignesDeCommande_Commandes As System.Windows.Forms.DataConnector
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LignesDeCommandeTableAdapter As DBApplication.LignesDeCommandeTableAdapter
End Class
