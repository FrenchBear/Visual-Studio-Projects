Public Partial Class frmArticles
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmArticles))
        Me.ArticlesDataConnector = New System.Windows.Forms.DataConnector(Me.components)
        Me.ArticlesDataNavigator = New System.Windows.Forms.DataNavigator(Me.components)
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
        Me.ArticleIdLabel = New System.Windows.Forms.Label
        Me.ArticleIdTextBox = New System.Windows.Forms.TextBox
        Me.DescriptionLabel = New System.Windows.Forms.Label
        Me.DescriptionTextBox = New System.Windows.Forms.TextBox
        Me.PrixLabel = New System.Windows.Forms.Label
        Me.PrixTextBox = New System.Windows.Forms.TextBox
        Me.TotoDataSet = New DBApplication.totoDataSet
        Me.ArticlesTableAdapter = New DBApplication.ArticlesTableAdapter
        CType(Me.ArticlesDataConnector, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ArticlesDataNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ArticlesDataNavigator.SuspendLayout()
        CType(Me.leftToolStripPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.rightToolStripPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.topToolStripPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.topToolStripPanel.SuspendLayout()
        CType(Me.bottomToolStripPanel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TotoDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ArticlesDataConnector
        '
        Me.ArticlesDataConnector.DataMember = "Articles"
        Me.ArticlesDataConnector.DataSource = Me.TotoDataSet
        '
        'ArticlesDataNavigator
        '
        Me.ArticlesDataNavigator.AddNewItem = Me.dataNavigatorAddNewItem
        Me.ArticlesDataNavigator.CountItem = Me.dataNavigatorCountItem
        Me.ArticlesDataNavigator.CountItemFormat = "/ {0}"
        Me.ArticlesDataNavigator.DataConnector = Me.ArticlesDataConnector
        Me.ArticlesDataNavigator.DeleteItem = Me.dataNavigatorDeleteItem
        Me.ArticlesDataNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.dataNavigatorMoveFirstItem, Me.dataNavigatorMovePreviousItem, Me.dataNavigatorSeparator, Me.dataNavigatorPositionItem, Me.dataNavigatorCountItem, Me.dataNavigatorSeparator1, Me.dataNavigatorMoveNextItem, Me.dataNavigatorMoveLastItem, Me.dataNavigatorSeparator2, Me.dataNavigatorAddNewItem, Me.dataNavigatorDeleteItem, Me.dataNavigatorSaveItem})
        Me.ArticlesDataNavigator.Location = New System.Drawing.Point(0, 0)
        Me.ArticlesDataNavigator.MoveFirstItem = Me.dataNavigatorMoveFirstItem
        Me.ArticlesDataNavigator.MoveLastItem = Me.dataNavigatorMoveLastItem
        Me.ArticlesDataNavigator.MoveNextItem = Me.dataNavigatorMoveNextItem
        Me.ArticlesDataNavigator.MovePreviousItem = Me.dataNavigatorMovePreviousItem
        Me.ArticlesDataNavigator.Name = "ArticlesDataNavigator"
        Me.ArticlesDataNavigator.PositionItem = Me.dataNavigatorPositionItem
        Me.ArticlesDataNavigator.Raft = System.Windows.Forms.RaftingSides.Top
        Me.ArticlesDataNavigator.TabIndex = 0
        Me.ArticlesDataNavigator.Text = "DataNavigator1"
        '
        'dataNavigatorAddNewItem
        '
        Me.dataNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.dataNavigatorAddNewItem.Image = CType(resources.GetObject("dataNavigatorAddNewItem.Image"), System.Drawing.Image)
        Me.dataNavigatorAddNewItem.Name = "dataNavigatorAddNewItem"
        Me.dataNavigatorAddNewItem.SettingsKey = "frmArticles.dataNavigatorAddNewItem"
        Me.dataNavigatorAddNewItem.Text = "Add new"
        '
        'dataNavigatorCountItem
        '
        Me.dataNavigatorCountItem.Name = "dataNavigatorCountItem"
        Me.dataNavigatorCountItem.SettingsKey = "frmArticles.dataNavigatorCountItem"
        Me.dataNavigatorCountItem.Text = "/ 0"
        Me.dataNavigatorCountItem.ToolTipText = "Total number of items"
        '
        'dataNavigatorDeleteItem
        '
        Me.dataNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.dataNavigatorDeleteItem.Image = CType(resources.GetObject("dataNavigatorDeleteItem.Image"), System.Drawing.Image)
        Me.dataNavigatorDeleteItem.Name = "dataNavigatorDeleteItem"
        Me.dataNavigatorDeleteItem.SettingsKey = "frmArticles.dataNavigatorDeleteItem"
        Me.dataNavigatorDeleteItem.Text = "Delete"
        '
        'dataNavigatorMoveFirstItem
        '
        Me.dataNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.dataNavigatorMoveFirstItem.Image = CType(resources.GetObject("dataNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.dataNavigatorMoveFirstItem.Name = "dataNavigatorMoveFirstItem"
        Me.dataNavigatorMoveFirstItem.SettingsKey = "frmArticles.dataNavigatorMoveFirstItem"
        Me.dataNavigatorMoveFirstItem.Text = "Move first"
        '
        'dataNavigatorMovePreviousItem
        '
        Me.dataNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.dataNavigatorMovePreviousItem.Image = CType(resources.GetObject("dataNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.dataNavigatorMovePreviousItem.Name = "dataNavigatorMovePreviousItem"
        Me.dataNavigatorMovePreviousItem.SettingsKey = "frmArticles.dataNavigatorMovePreviousItem"
        Me.dataNavigatorMovePreviousItem.Text = "Move previous"
        '
        'dataNavigatorSeparator
        '
        Me.dataNavigatorSeparator.Name = "dataNavigatorSeparator"
        Me.dataNavigatorSeparator.SettingsKey = "frmArticles.dataNavigatorSeparator"
        '
        'dataNavigatorPositionItem
        '
        Me.dataNavigatorPositionItem.Name = "dataNavigatorPositionItem"
        Me.dataNavigatorPositionItem.SettingsKey = "frmArticles.dataNavigatorPositionItem"
        Me.dataNavigatorPositionItem.Size = New System.Drawing.Size(50, 25)
        Me.dataNavigatorPositionItem.Text = "0"
        Me.dataNavigatorPositionItem.ToolTipText = "Current position"
        '
        'dataNavigatorSeparator1
        '
        Me.dataNavigatorSeparator1.Name = "dataNavigatorSeparator1"
        Me.dataNavigatorSeparator1.SettingsKey = "frmArticles.dataNavigatorSeparator1"
        '
        'dataNavigatorMoveNextItem
        '
        Me.dataNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.dataNavigatorMoveNextItem.Image = CType(resources.GetObject("dataNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.dataNavigatorMoveNextItem.Name = "dataNavigatorMoveNextItem"
        Me.dataNavigatorMoveNextItem.SettingsKey = "frmArticles.dataNavigatorMoveNextItem"
        Me.dataNavigatorMoveNextItem.Text = "Move next"
        '
        'dataNavigatorMoveLastItem
        '
        Me.dataNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.dataNavigatorMoveLastItem.Image = CType(resources.GetObject("dataNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.dataNavigatorMoveLastItem.Name = "dataNavigatorMoveLastItem"
        Me.dataNavigatorMoveLastItem.SettingsKey = "frmArticles.dataNavigatorMoveLastItem"
        Me.dataNavigatorMoveLastItem.Text = "Move last"
        '
        'dataNavigatorSeparator2
        '
        Me.dataNavigatorSeparator2.Name = "dataNavigatorSeparator2"
        Me.dataNavigatorSeparator2.SettingsKey = "frmArticles.dataNavigatorSeparator2"
        '
        'dataNavigatorSaveItem
        '
        Me.dataNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.dataNavigatorSaveItem.Enabled = False
        Me.dataNavigatorSaveItem.Image = CType(resources.GetObject("dataNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.dataNavigatorSaveItem.Name = "dataNavigatorSaveItem"
        Me.dataNavigatorSaveItem.SettingsKey = "frmArticles.dataNavigatorSaveItem"
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
        Me.topToolStripPanel.Controls.Add(Me.ArticlesDataNavigator)
        Me.topToolStripPanel.Dock = System.Windows.Forms.DockStyle.Top
        Me.topToolStripPanel.Name = "topToolStripPanel"
        '
        'bottomToolStripPanel
        '
        Me.bottomToolStripPanel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.bottomToolStripPanel.Name = "bottomToolStripPanel"
        '
        'ArticleIdLabel
        '
        Me.ArticleIdLabel.AutoSize = True
        Me.ArticleIdLabel.Location = New System.Drawing.Point(6, 32)
        Me.ArticleIdLabel.Name = "ArticleIdLabel"
        Me.ArticleIdLabel.Size = New System.Drawing.Size(48, 14)
        Me.ArticleIdLabel.TabIndex = 0
        Me.ArticleIdLabel.Text = "ArticleId:"
        '
        'ArticleIdTextBox
        '
        Me.ArticleIdTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ArticlesDataConnector, "ArticleId", True))
        Me.ArticleIdTextBox.Location = New System.Drawing.Point(77, 29)
        Me.ArticleIdTextBox.Name = "ArticleIdTextBox"
        Me.ArticleIdTextBox.TabIndex = 1
        '
        'DescriptionLabel
        '
        Me.DescriptionLabel.AutoSize = True
        Me.DescriptionLabel.Location = New System.Drawing.Point(6, 59)
        Me.DescriptionLabel.Name = "DescriptionLabel"
        Me.DescriptionLabel.Size = New System.Drawing.Size(64, 14)
        Me.DescriptionLabel.TabIndex = 2
        Me.DescriptionLabel.Text = "Description:"
        '
        'DescriptionTextBox
        '
        Me.DescriptionTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ArticlesDataConnector, "Description", True))
        Me.DescriptionTextBox.Location = New System.Drawing.Point(77, 56)
        Me.DescriptionTextBox.Name = "DescriptionTextBox"
        Me.DescriptionTextBox.TabIndex = 3
        '
        'PrixLabel
        '
        Me.PrixLabel.AutoSize = True
        Me.PrixLabel.Location = New System.Drawing.Point(6, 86)
        Me.PrixLabel.Name = "PrixLabel"
        Me.PrixLabel.Size = New System.Drawing.Size(27, 14)
        Me.PrixLabel.TabIndex = 4
        Me.PrixLabel.Text = "Prix:"
        '
        'PrixTextBox
        '
        Me.PrixTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.ArticlesDataConnector, "Prix", True))
        Me.PrixTextBox.Location = New System.Drawing.Point(77, 83)
        Me.PrixTextBox.Name = "PrixTextBox"
        Me.PrixTextBox.TabIndex = 5
        '
        'TotoDataSet
        '
        Me.TotoDataSet.DataSetName = "totoDataSet"
        Me.TotoDataSet.Locale = New System.Globalization.CultureInfo("fr-FR")
        Me.TotoDataSet.RemotingFormat = System.Data.SerializationFormat.Xml
        '
        'ArticlesTableAdapter
        '
        Me.ArticlesTableAdapter.ClearBeforeFill = True
        '
        'frmArticles
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(317, 266)
        Me.Controls.Add(Me.ArticleIdLabel)
        Me.Controls.Add(Me.ArticleIdTextBox)
        Me.Controls.Add(Me.DescriptionLabel)
        Me.Controls.Add(Me.DescriptionTextBox)
        Me.Controls.Add(Me.PrixLabel)
        Me.Controls.Add(Me.PrixTextBox)
        Me.Controls.Add(Me.leftToolStripPanel)
        Me.Controls.Add(Me.rightToolStripPanel)
        Me.Controls.Add(Me.topToolStripPanel)
        Me.Controls.Add(Me.bottomToolStripPanel)
        Me.Name = "frmArticles"
        Me.Text = "frmArticles"
        CType(Me.ArticlesDataConnector, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ArticlesDataNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ArticlesDataNavigator.ResumeLayout(False)
        Me.ArticlesDataNavigator.PerformLayout()
        CType(Me.leftToolStripPanel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.rightToolStripPanel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.topToolStripPanel, System.ComponentModel.ISupportInitialize).EndInit()
        Me.topToolStripPanel.ResumeLayout(False)
        Me.topToolStripPanel.PerformLayout()
        CType(Me.bottomToolStripPanel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TotoDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ArticlesDataConnector As System.Windows.Forms.DataConnector
    Friend WithEvents ArticlesDataNavigator As System.Windows.Forms.DataNavigator
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
    Friend WithEvents ArticleIdLabel As System.Windows.Forms.Label
    Friend WithEvents ArticleIdTextBox As System.Windows.Forms.TextBox
    Friend WithEvents DescriptionLabel As System.Windows.Forms.Label
    Friend WithEvents DescriptionTextBox As System.Windows.Forms.TextBox
    Friend WithEvents PrixLabel As System.Windows.Forms.Label
    Friend WithEvents PrixTextBox As System.Windows.Forms.TextBox
    Friend WithEvents TotoDataSet As DBApplication.totoDataSet
    Friend WithEvents ArticlesTableAdapter As DBApplication.ArticlesTableAdapter
End Class
