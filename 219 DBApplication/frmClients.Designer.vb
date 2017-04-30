Public Partial Class frmClients
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmClients))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.ClientsDataConnector = New System.Windows.Forms.DataConnector(Me.components)
        Me.ClientsDataNavigator = New System.Windows.Forms.DataNavigator(Me.components)
        Me.dataNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton
        Me.dataNavigatorCountItem = New System.Windows.Forms.ToolStripLabel
        Me.dataNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton
        Me.dataNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton
        Me.dataNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton
        Me.dataNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator
        Me.dataNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox
        Me.dataNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.dataNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton
        Me.dataNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton
        Me.dataNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.dataNavigatorSaveItem = New System.Windows.Forms.ToolStripButton
        Me.leftToolStripPanel = New System.Windows.Forms.ToolStripPanel
        Me.rightToolStripPanel = New System.Windows.Forms.ToolStripPanel
        Me.topToolStripPanel = New System.Windows.Forms.ToolStripPanel
        Me.bottomToolStripPanel = New System.Windows.Forms.ToolStripPanel
        Me.ClientsDataGridView = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.FK_Commandes_ClientsDataConnector = New System.Windows.Forms.DataConnector(Me.components)
        Me.CommandesDataGridView = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TotoDataSet = New DBApplication.totoDataSet
        Me.ClientsTableAdapter = New DBApplication.ClientsTableAdapter
        Me.CommandesTableAdapter = New DBApplication.CommandesTableAdapter
        CType(Me.ClientsDataConnector, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ClientsDataNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ClientsDataNavigator.SuspendLayout()
        CType(Me.leftToolStripPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rightToolStripPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.topToolStripPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.topToolStripPanel.SuspendLayout()
        CType(Me.bottomToolStripPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ClientsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FK_Commandes_ClientsDataConnector, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CommandesDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TotoDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'dataNavigatorAddNewItem
        '
        Me.dataNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.dataNavigatorAddNewItem.Image = CType(resources.GetObject("dataNavigatorAddNewItem.Image"), System.Drawing.Image)
        Me.dataNavigatorAddNewItem.Name = "dataNavigatorAddNewItem"
        Me.dataNavigatorAddNewItem.SettingsKey = "frmClients.dataNavigatorAddNewItem"
        Me.dataNavigatorAddNewItem.Text = "Add new"
        '
        'dataNavigatorCountItem
        '
        Me.dataNavigatorCountItem.Name = "dataNavigatorCountItem"
        Me.dataNavigatorCountItem.SettingsKey = "frmClients.dataNavigatorCountItem"
        Me.dataNavigatorCountItem.Text = "of 0"
        Me.dataNavigatorCountItem.ToolTipText = "Total number of items"
        '
        'dataNavigatorDeleteItem
        '
        Me.dataNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.dataNavigatorDeleteItem.Image = CType(resources.GetObject("dataNavigatorDeleteItem.Image"), System.Drawing.Image)
        Me.dataNavigatorDeleteItem.Name = "dataNavigatorDeleteItem"
        Me.dataNavigatorDeleteItem.SettingsKey = "frmClients.dataNavigatorDeleteItem"
        Me.dataNavigatorDeleteItem.Text = "Delete"
        '
        'dataNavigatorMoveFirstItem
        '
        Me.dataNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.dataNavigatorMoveFirstItem.Image = CType(resources.GetObject("dataNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.dataNavigatorMoveFirstItem.Name = "dataNavigatorMoveFirstItem"
        Me.dataNavigatorMoveFirstItem.SettingsKey = "frmClients.dataNavigatorMoveFirstItem"
        Me.dataNavigatorMoveFirstItem.Text = "Move first"
        '
        'dataNavigatorMovePreviousItem
        '
        Me.dataNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.dataNavigatorMovePreviousItem.Image = CType(resources.GetObject("dataNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.dataNavigatorMovePreviousItem.Name = "dataNavigatorMovePreviousItem"
        Me.dataNavigatorMovePreviousItem.SettingsKey = "frmClients.dataNavigatorMovePreviousItem"
        Me.dataNavigatorMovePreviousItem.Text = "Move previous"
        '
        'dataNavigatorSeparator
        '
        Me.dataNavigatorSeparator.Name = "dataNavigatorSeparator"
        Me.dataNavigatorSeparator.SettingsKey = "frmClients.dataNavigatorSeparator"
        '
        'dataNavigatorPositionItem
        '
        Me.dataNavigatorPositionItem.Name = "dataNavigatorPositionItem"
        Me.dataNavigatorPositionItem.SettingsKey = "frmClients.dataNavigatorPositionItem"
        Me.dataNavigatorPositionItem.Size = New System.Drawing.Size(50, 25)
        Me.dataNavigatorPositionItem.Text = "0"
        Me.dataNavigatorPositionItem.ToolTipText = "Current position"
        '
        'dataNavigatorSeparator1
        '
        Me.dataNavigatorSeparator1.Name = "dataNavigatorSeparator1"
        Me.dataNavigatorSeparator1.SettingsKey = "frmClients.dataNavigatorSeparator1"
        '
        'dataNavigatorMoveNextItem
        '
        Me.dataNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.dataNavigatorMoveNextItem.Image = CType(resources.GetObject("dataNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.dataNavigatorMoveNextItem.Name = "dataNavigatorMoveNextItem"
        Me.dataNavigatorMoveNextItem.SettingsKey = "frmClients.dataNavigatorMoveNextItem"
        Me.dataNavigatorMoveNextItem.Text = "Move next"
        '
        'dataNavigatorMoveLastItem
        '
        Me.dataNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.dataNavigatorMoveLastItem.Image = CType(resources.GetObject("dataNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.dataNavigatorMoveLastItem.Name = "dataNavigatorMoveLastItem"
        Me.dataNavigatorMoveLastItem.SettingsKey = "frmClients.dataNavigatorMoveLastItem"
        Me.dataNavigatorMoveLastItem.Text = "Move last"
        '
        'dataNavigatorSeparator2
        '
        Me.dataNavigatorSeparator2.Name = "dataNavigatorSeparator2"
        Me.dataNavigatorSeparator2.SettingsKey = "frmClients.dataNavigatorSeparator2"
        '
        'dataNavigatorSaveItem
        '
        Me.dataNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.dataNavigatorSaveItem.Enabled = False
        Me.dataNavigatorSaveItem.Image = CType(resources.GetObject("dataNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.dataNavigatorSaveItem.Name = "dataNavigatorSaveItem"
        Me.dataNavigatorSaveItem.SettingsKey = "frmClients.dataNavigatorSaveItem"
        Me.dataNavigatorSaveItem.Text = "Save Data"
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
        'ClientsDataGridView
        '
        Me.ClientsDataGridView.AllowUserToOrderColumns = True
        Me.ClientsDataGridView.AutoGenerateColumns = False
        Me.ClientsDataGridView.BackgroundColor = System.Drawing.Color.Tan
        Me.ClientsDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Wheat
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.Color.SaddleBrown
        Me.ClientsDataGridView.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.ClientsDataGridView.Columns.Add(Me.DataGridViewTextBoxColumn1)
        Me.ClientsDataGridView.Columns.Add(Me.DataGridViewTextBoxColumn2)
        Me.ClientsDataGridView.Columns.Add(Me.DataGridViewTextBoxColumn3)
        Me.ClientsDataGridView.DataSource = Me.ClientsDataConnector
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.OldLace
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.DarkSlateGray
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ClientsDataGridView.DefaultCellStyle = DataGridViewCellStyle2
        Me.ClientsDataGridView.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!)
        Me.ClientsDataGridView.GridColor = System.Drawing.Color.Tan
        Me.ClientsDataGridView.Location = New System.Drawing.Point(28, 29)
        Me.ClientsDataGridView.Name = "ClientsDataGridView"
        Me.ClientsDataGridView.RowHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.ClientsDataGridView.Size = New System.Drawing.Size(366, 220)
        Me.ClientsDataGridView.TabIndex = 0
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "ClientId"
        Me.DataGridViewTextBoxColumn1.HeaderText = "ClientId"
        Me.DataGridViewTextBoxColumn1.Name = "ClientId"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.ValueType = GetType(Integer)
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "Nom"
        Me.DataGridViewTextBoxColumn2.HeaderText = "Nom"
        Me.DataGridViewTextBoxColumn2.Name = "Nom"
        Me.DataGridViewTextBoxColumn2.ValueType = GetType(String)
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "Ville"
        Me.DataGridViewTextBoxColumn3.HeaderText = "Ville"
        Me.DataGridViewTextBoxColumn3.Name = "Ville"
        Me.DataGridViewTextBoxColumn3.ValueType = GetType(String)
        '
        'FK_Commandes_ClientsDataConnector
        '
        Me.FK_Commandes_ClientsDataConnector.DataMember = "FK_Commandes_Clients"
        Me.FK_Commandes_ClientsDataConnector.DataSource = Me.ClientsDataConnector
        '
        'CommandesDataGridView
        '
        Me.CommandesDataGridView.AutoGenerateColumns = False
        Me.CommandesDataGridView.Columns.Add(Me.DataGridViewTextBoxColumn4)
        Me.CommandesDataGridView.Columns.Add(Me.DataGridViewTextBoxColumn5)
        Me.CommandesDataGridView.Columns.Add(Me.DataGridViewTextBoxColumn6)
        Me.CommandesDataGridView.DataSource = Me.FK_Commandes_ClientsDataConnector
        Me.CommandesDataGridView.Location = New System.Drawing.Point(28, 289)
        Me.CommandesDataGridView.Name = "CommandesDataGridView"
        Me.CommandesDataGridView.Size = New System.Drawing.Size(366, 220)
        Me.CommandesDataGridView.TabIndex = 4
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
        'frmClients
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(424, 558)
        Me.Controls.Add(Me.CommandesDataGridView)
        Me.Controls.Add(Me.ClientsDataGridView)
        Me.Controls.Add(Me.leftToolStripPanel)
        Me.Controls.Add(Me.rightToolStripPanel)
        Me.Controls.Add(Me.topToolStripPanel)
        Me.Controls.Add(Me.bottomToolStripPanel)
        Me.Name = "frmClients"
        Me.Text = "frmClients"
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
        CType(Me.ClientsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FK_Commandes_ClientsDataConnector, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CommandesDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TotoDataSet, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents ClientsDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FK_Commandes_ClientsDataConnector As System.Windows.Forms.DataConnector
    Friend WithEvents TotoDataSet As DBApplication.totoDataSet
    Friend WithEvents CommandesDataGridView As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ClientsTableAdapter As DBApplication.ClientsTableAdapter
    Friend WithEvents CommandesTableAdapter As DBApplication.CommandesTableAdapter
End Class
