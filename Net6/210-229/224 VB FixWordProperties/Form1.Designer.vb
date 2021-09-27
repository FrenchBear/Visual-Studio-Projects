<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim TitleLabel As System.Windows.Forms.Label
        Dim SubjectLabel As System.Windows.Forms.Label
        Dim AuthorLabel As System.Windows.Forms.Label
        Dim ManagerLabel As System.Windows.Forms.Label
        Dim CompanyLabel As System.Windows.Forms.Label
        Dim CategoryLabel As System.Windows.Forms.Label
        Dim KeywordsLabel As System.Windows.Forms.Label
        Dim CommentsLabel As System.Windows.Forms.Label
        Dim HyperlinkBaseLabel As System.Windows.Forms.Label
        Me.MySettingsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.folderButton = New System.Windows.Forms.Button
        Me.fbd = New System.Windows.Forms.FolderBrowserDialog
        Me.titleTextBox = New System.Windows.Forms.TextBox
        Me.subjectTextBox = New System.Windows.Forms.TextBox
        Me.authorTextBox = New System.Windows.Forms.TextBox
        Me.managerTextBox = New System.Windows.Forms.TextBox
        Me.companyTextBox = New System.Windows.Forms.TextBox
        Me.categoryTextBox = New System.Windows.Forms.TextBox
        Me.keywordsTextBox = New System.Windows.Forms.TextBox
        Me.commentsTextBox = New System.Windows.Forms.TextBox
        Me.hyperlinkBaseTextBox = New System.Windows.Forms.TextBox
        Me.LookInSubfoldersCheckBox = New System.Windows.Forms.CheckBox
        Me.useDocNameCheckBox = New System.Windows.Forms.CheckBox
        Me.useTitleCheckbox = New System.Windows.Forms.CheckBox
        Me.useSubjectCheckBox = New System.Windows.Forms.CheckBox
        Me.useAuthorCheckBox = New System.Windows.Forms.CheckBox
        Me.useManagerCheckBox = New System.Windows.Forms.CheckBox
        Me.useCompanyCheckBox = New System.Windows.Forms.CheckBox
        Me.useCategoryCheckBox = New System.Windows.Forms.CheckBox
        Me.useKeywordsCheckBox = New System.Windows.Forms.CheckBox
        Me.useCommentsCheckBox = New System.Windows.Forms.CheckBox
        Me.useHyperlinkBaseCheckBox = New System.Windows.Forms.CheckBox
        Me.makeChangesButton = New System.Windows.Forms.Button
        Me.folderLabel = New System.Windows.Forms.Label
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.statusLabel = New System.Windows.Forms.ToolStripStatusLabel
        Me.cancelSearchButton = New System.Windows.Forms.Button
        Me.bgw = New System.ComponentModel.BackgroundWorker
        TitleLabel = New System.Windows.Forms.Label
        SubjectLabel = New System.Windows.Forms.Label
        AuthorLabel = New System.Windows.Forms.Label
        ManagerLabel = New System.Windows.Forms.Label
        CompanyLabel = New System.Windows.Forms.Label
        CategoryLabel = New System.Windows.Forms.Label
        KeywordsLabel = New System.Windows.Forms.Label
        CommentsLabel = New System.Windows.Forms.Label
        HyperlinkBaseLabel = New System.Windows.Forms.Label
        CType(Me.MySettingsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TitleLabel
        '
        TitleLabel.Location = New System.Drawing.Point(39, 75)
        TitleLabel.Name = "TitleLabel"
        TitleLabel.Size = New System.Drawing.Size(72, 16)
        TitleLabel.TabIndex = 4
        TitleLabel.Text = "Title:"
        TitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'SubjectLabel
        '
        SubjectLabel.Location = New System.Drawing.Point(39, 103)
        SubjectLabel.Name = "SubjectLabel"
        SubjectLabel.Size = New System.Drawing.Size(72, 16)
        SubjectLabel.TabIndex = 8
        SubjectLabel.Text = "Subject:"
        SubjectLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'AuthorLabel
        '
        AuthorLabel.Location = New System.Drawing.Point(39, 131)
        AuthorLabel.Name = "AuthorLabel"
        AuthorLabel.Size = New System.Drawing.Size(72, 16)
        AuthorLabel.TabIndex = 11
        AuthorLabel.Text = "Author:"
        AuthorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ManagerLabel
        '
        ManagerLabel.Location = New System.Drawing.Point(39, 159)
        ManagerLabel.Name = "ManagerLabel"
        ManagerLabel.Size = New System.Drawing.Size(72, 16)
        ManagerLabel.TabIndex = 14
        ManagerLabel.Text = "Manager:"
        ManagerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CompanyLabel
        '
        CompanyLabel.Location = New System.Drawing.Point(39, 187)
        CompanyLabel.Name = "CompanyLabel"
        CompanyLabel.Size = New System.Drawing.Size(72, 16)
        CompanyLabel.TabIndex = 17
        CompanyLabel.Text = "Company:"
        CompanyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CategoryLabel
        '
        CategoryLabel.Location = New System.Drawing.Point(41, 230)
        CategoryLabel.Name = "CategoryLabel"
        CategoryLabel.Size = New System.Drawing.Size(72, 16)
        CategoryLabel.TabIndex = 20
        CategoryLabel.Text = "Category:"
        CategoryLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'KeywordsLabel
        '
        KeywordsLabel.Location = New System.Drawing.Point(41, 258)
        KeywordsLabel.Name = "KeywordsLabel"
        KeywordsLabel.Size = New System.Drawing.Size(72, 16)
        KeywordsLabel.TabIndex = 23
        KeywordsLabel.Text = "Keywords:"
        KeywordsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CommentsLabel
        '
        CommentsLabel.Location = New System.Drawing.Point(41, 286)
        CommentsLabel.Name = "CommentsLabel"
        CommentsLabel.Size = New System.Drawing.Size(72, 16)
        CommentsLabel.TabIndex = 26
        CommentsLabel.Text = "Comments:"
        CommentsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'HyperlinkBaseLabel
        '
        HyperlinkBaseLabel.Location = New System.Drawing.Point(41, 345)
        HyperlinkBaseLabel.Name = "HyperlinkBaseLabel"
        HyperlinkBaseLabel.Size = New System.Drawing.Size(72, 34)
        HyperlinkBaseLabel.TabIndex = 29
        HyperlinkBaseLabel.Text = "Hyperlink Base:"
        HyperlinkBaseLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MySettingsBindingSource
        '
        Me.MySettingsBindingSource.DataSource = Global.FixWordProperties.My.MySettings.Default
        Me.MySettingsBindingSource.Position = 0
        '
        'folderButton
        '
        Me.folderButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.folderButton.Location = New System.Drawing.Point(375, 7)
        Me.folderButton.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.folderButton.Name = "folderButton"
        Me.folderButton.Size = New System.Drawing.Size(139, 26)
        Me.folderButton.TabIndex = 1
        Me.folderButton.Text = "Select Input Folder"
        Me.folderButton.UseVisualStyleBackColor = True
        '
        'titleTextBox
        '
        Me.titleTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.titleTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MySettingsBindingSource, "Title", True))
        Me.titleTextBox.Location = New System.Drawing.Point(119, 72)
        Me.titleTextBox.Name = "titleTextBox"
        Me.titleTextBox.Size = New System.Drawing.Size(252, 26)
        Me.titleTextBox.TabIndex = 5
        '
        'subjectTextBox
        '
        Me.subjectTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.subjectTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MySettingsBindingSource, "Subject", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.subjectTextBox.Location = New System.Drawing.Point(119, 100)
        Me.subjectTextBox.Name = "subjectTextBox"
        Me.subjectTextBox.Size = New System.Drawing.Size(252, 26)
        Me.subjectTextBox.TabIndex = 9
        '
        'authorTextBox
        '
        Me.authorTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.authorTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MySettingsBindingSource, "Author", True))
        Me.authorTextBox.Location = New System.Drawing.Point(119, 128)
        Me.authorTextBox.Name = "authorTextBox"
        Me.authorTextBox.Size = New System.Drawing.Size(252, 26)
        Me.authorTextBox.TabIndex = 12
        '
        'managerTextBox
        '
        Me.managerTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.managerTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MySettingsBindingSource, "Manager", True))
        Me.managerTextBox.Location = New System.Drawing.Point(119, 156)
        Me.managerTextBox.Name = "managerTextBox"
        Me.managerTextBox.Size = New System.Drawing.Size(252, 26)
        Me.managerTextBox.TabIndex = 15
        '
        'companyTextBox
        '
        Me.companyTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.companyTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MySettingsBindingSource, "Company", True))
        Me.companyTextBox.Location = New System.Drawing.Point(119, 184)
        Me.companyTextBox.Name = "companyTextBox"
        Me.companyTextBox.Size = New System.Drawing.Size(252, 26)
        Me.companyTextBox.TabIndex = 18
        '
        'categoryTextBox
        '
        Me.categoryTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.categoryTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MySettingsBindingSource, "Category", True))
        Me.categoryTextBox.Location = New System.Drawing.Point(119, 227)
        Me.categoryTextBox.Name = "categoryTextBox"
        Me.categoryTextBox.Size = New System.Drawing.Size(252, 26)
        Me.categoryTextBox.TabIndex = 21
        '
        'keywordsTextBox
        '
        Me.keywordsTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.keywordsTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MySettingsBindingSource, "Keywords", True))
        Me.keywordsTextBox.Location = New System.Drawing.Point(119, 255)
        Me.keywordsTextBox.Name = "keywordsTextBox"
        Me.keywordsTextBox.Size = New System.Drawing.Size(252, 26)
        Me.keywordsTextBox.TabIndex = 24
        '
        'commentsTextBox
        '
        Me.commentsTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.commentsTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MySettingsBindingSource, "Comments", True))
        Me.commentsTextBox.Location = New System.Drawing.Point(119, 283)
        Me.commentsTextBox.Multiline = True
        Me.commentsTextBox.Name = "commentsTextBox"
        Me.commentsTextBox.Size = New System.Drawing.Size(252, 62)
        Me.commentsTextBox.TabIndex = 27
        '
        'hyperlinkBaseTextBox
        '
        Me.hyperlinkBaseTextBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.hyperlinkBaseTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MySettingsBindingSource, "HyperlinkBase", True))
        Me.hyperlinkBaseTextBox.Location = New System.Drawing.Point(119, 351)
        Me.hyperlinkBaseTextBox.Name = "hyperlinkBaseTextBox"
        Me.hyperlinkBaseTextBox.Size = New System.Drawing.Size(252, 26)
        Me.hyperlinkBaseTextBox.TabIndex = 30
        '
        'LookInSubfoldersCheckBox
        '
        Me.LookInSubfoldersCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.MySettingsBindingSource, "LookInSubfolders", True))
        Me.LookInSubfoldersCheckBox.Location = New System.Drawing.Point(17, 40)
        Me.LookInSubfoldersCheckBox.Name = "LookInSubfoldersCheckBox"
        Me.LookInSubfoldersCheckBox.Size = New System.Drawing.Size(165, 24)
        Me.LookInSubfoldersCheckBox.TabIndex = 2
        Me.LookInSubfoldersCheckBox.Text = "Include Subfolders?"
        '
        'useDocNameCheckBox
        '
        Me.useDocNameCheckBox.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.useDocNameCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.MySettingsBindingSource, "UseDocName", True))
        Me.useDocNameCheckBox.Location = New System.Drawing.Point(375, 61)
        Me.useDocNameCheckBox.Name = "useDocNameCheckBox"
        Me.useDocNameCheckBox.Size = New System.Drawing.Size(133, 47)
        Me.useDocNameCheckBox.TabIndex = 6
        Me.useDocNameCheckBox.Text = "Use document name?"
        '
        'useTitleCheckbox
        '
        Me.useTitleCheckbox.AutoSize = True
        Me.useTitleCheckbox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.MySettingsBindingSource, "UseTitle", True))
        Me.useTitleCheckbox.Location = New System.Drawing.Point(24, 77)
        Me.useTitleCheckbox.Name = "useTitleCheckbox"
        Me.useTitleCheckbox.Size = New System.Drawing.Size(18, 17)
        Me.useTitleCheckbox.TabIndex = 3
        '
        'useSubjectCheckBox
        '
        Me.useSubjectCheckBox.AutoSize = True
        Me.useSubjectCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.MySettingsBindingSource, "UseSubject", True))
        Me.useSubjectCheckBox.Location = New System.Drawing.Point(24, 105)
        Me.useSubjectCheckBox.Name = "useSubjectCheckBox"
        Me.useSubjectCheckBox.Size = New System.Drawing.Size(18, 17)
        Me.useSubjectCheckBox.TabIndex = 7
        '
        'useAuthorCheckBox
        '
        Me.useAuthorCheckBox.AutoSize = True
        Me.useAuthorCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.MySettingsBindingSource, "UseAuthor", True))
        Me.useAuthorCheckBox.Location = New System.Drawing.Point(24, 133)
        Me.useAuthorCheckBox.Name = "useAuthorCheckBox"
        Me.useAuthorCheckBox.Size = New System.Drawing.Size(18, 17)
        Me.useAuthorCheckBox.TabIndex = 10
        '
        'useManagerCheckBox
        '
        Me.useManagerCheckBox.AutoSize = True
        Me.useManagerCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.MySettingsBindingSource, "UseManager", True))
        Me.useManagerCheckBox.Location = New System.Drawing.Point(24, 159)
        Me.useManagerCheckBox.Name = "useManagerCheckBox"
        Me.useManagerCheckBox.Size = New System.Drawing.Size(18, 17)
        Me.useManagerCheckBox.TabIndex = 13
        '
        'useCompanyCheckBox
        '
        Me.useCompanyCheckBox.AutoSize = True
        Me.useCompanyCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.MySettingsBindingSource, "UseCompany", True))
        Me.useCompanyCheckBox.Location = New System.Drawing.Point(24, 189)
        Me.useCompanyCheckBox.Name = "useCompanyCheckBox"
        Me.useCompanyCheckBox.Size = New System.Drawing.Size(18, 17)
        Me.useCompanyCheckBox.TabIndex = 16
        '
        'useCategoryCheckBox
        '
        Me.useCategoryCheckBox.AutoSize = True
        Me.useCategoryCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.MySettingsBindingSource, "UseCategory", True))
        Me.useCategoryCheckBox.Location = New System.Drawing.Point(24, 232)
        Me.useCategoryCheckBox.Name = "useCategoryCheckBox"
        Me.useCategoryCheckBox.Size = New System.Drawing.Size(18, 17)
        Me.useCategoryCheckBox.TabIndex = 19
        '
        'useKeywordsCheckBox
        '
        Me.useKeywordsCheckBox.AutoSize = True
        Me.useKeywordsCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.MySettingsBindingSource, "UseKeywords", True))
        Me.useKeywordsCheckBox.Location = New System.Drawing.Point(24, 260)
        Me.useKeywordsCheckBox.Name = "useKeywordsCheckBox"
        Me.useKeywordsCheckBox.Size = New System.Drawing.Size(18, 17)
        Me.useKeywordsCheckBox.TabIndex = 22
        '
        'useCommentsCheckBox
        '
        Me.useCommentsCheckBox.AutoSize = True
        Me.useCommentsCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.MySettingsBindingSource, "UseComments", True))
        Me.useCommentsCheckBox.Location = New System.Drawing.Point(24, 288)
        Me.useCommentsCheckBox.Name = "useCommentsCheckBox"
        Me.useCommentsCheckBox.Size = New System.Drawing.Size(18, 17)
        Me.useCommentsCheckBox.TabIndex = 25
        '
        'useHyperlinkBaseCheckBox
        '
        Me.useHyperlinkBaseCheckBox.AutoSize = True
        Me.useHyperlinkBaseCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.MySettingsBindingSource, "UseHyperlinkBase", True))
        Me.useHyperlinkBaseCheckBox.Location = New System.Drawing.Point(24, 356)
        Me.useHyperlinkBaseCheckBox.Name = "useHyperlinkBaseCheckBox"
        Me.useHyperlinkBaseCheckBox.Size = New System.Drawing.Size(18, 17)
        Me.useHyperlinkBaseCheckBox.TabIndex = 28
        '
        'makeChangesButton
        '
        Me.makeChangesButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.makeChangesButton.Location = New System.Drawing.Point(232, 377)
        Me.makeChangesButton.Name = "makeChangesButton"
        Me.makeChangesButton.Size = New System.Drawing.Size(139, 26)
        Me.makeChangesButton.TabIndex = 31
        Me.makeChangesButton.Text = "Make Changes"
        Me.makeChangesButton.UseVisualStyleBackColor = True
        '
        'folderLabel
        '
        Me.folderLabel.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.folderLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.folderLabel.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.MySettingsBindingSource, "Folder", True))
        Me.folderLabel.Location = New System.Drawing.Point(12, 7)
        Me.folderLabel.Name = "folderLabel"
        Me.folderLabel.Size = New System.Drawing.Size(359, 26)
        Me.folderLabel.TabIndex = 0
        Me.folderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.statusLabel})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 399)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(526, 23)
        Me.StatusStrip1.TabIndex = 34
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'statusLabel
        '
        Me.statusLabel.AutoSize = False
        Me.statusLabel.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.statusLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.statusLabel.Name = "statusLabel"
        Me.statusLabel.Size = New System.Drawing.Size(240, 18)
        Me.statusLabel.Spring = True
        Me.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cancelSearchButton
        '
        Me.cancelSearchButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cancelSearchButton.Location = New System.Drawing.Point(375, 377)
        Me.cancelSearchButton.Name = "cancelSearchButton"
        Me.cancelSearchButton.Size = New System.Drawing.Size(139, 26)
        Me.cancelSearchButton.TabIndex = 32
        Me.cancelSearchButton.Text = "Cancel"
        Me.cancelSearchButton.UseVisualStyleBackColor = True
        '
        'bgw
        '
        Me.bgw.WorkerReportsProgress = True
        Me.bgw.WorkerSupportsCancellation = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(526, 422)
        Me.Controls.Add(Me.cancelSearchButton)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.folderLabel)
        Me.Controls.Add(Me.makeChangesButton)
        Me.Controls.Add(Me.useHyperlinkBaseCheckBox)
        Me.Controls.Add(Me.useCommentsCheckBox)
        Me.Controls.Add(Me.useKeywordsCheckBox)
        Me.Controls.Add(Me.useCategoryCheckBox)
        Me.Controls.Add(Me.useCompanyCheckBox)
        Me.Controls.Add(Me.useManagerCheckBox)
        Me.Controls.Add(Me.useAuthorCheckBox)
        Me.Controls.Add(Me.useSubjectCheckBox)
        Me.Controls.Add(Me.useTitleCheckbox)
        Me.Controls.Add(Me.useDocNameCheckBox)
        Me.Controls.Add(Me.LookInSubfoldersCheckBox)
        Me.Controls.Add(HyperlinkBaseLabel)
        Me.Controls.Add(Me.hyperlinkBaseTextBox)
        Me.Controls.Add(CommentsLabel)
        Me.Controls.Add(Me.commentsTextBox)
        Me.Controls.Add(KeywordsLabel)
        Me.Controls.Add(Me.keywordsTextBox)
        Me.Controls.Add(CategoryLabel)
        Me.Controls.Add(Me.categoryTextBox)
        Me.Controls.Add(CompanyLabel)
        Me.Controls.Add(Me.companyTextBox)
        Me.Controls.Add(ManagerLabel)
        Me.Controls.Add(Me.managerTextBox)
        Me.Controls.Add(AuthorLabel)
        Me.Controls.Add(Me.authorTextBox)
        Me.Controls.Add(SubjectLabel)
        Me.Controls.Add(Me.subjectTextBox)
        Me.Controls.Add(TitleLabel)
        Me.Controls.Add(Me.titleTextBox)
        Me.Controls.Add(Me.folderButton)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximumSize = New System.Drawing.Size(869, 466)
        Me.MinimumSize = New System.Drawing.Size(534, 466)
        Me.Name = "Form1"
        Me.Text = "Set Word Document Properties"
        CType(Me.MySettingsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MySettingsBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents folderButton As System.Windows.Forms.Button
    Friend WithEvents fbd As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents titleTextBox As System.Windows.Forms.TextBox
    Friend WithEvents subjectTextBox As System.Windows.Forms.TextBox
    Friend WithEvents authorTextBox As System.Windows.Forms.TextBox
    Friend WithEvents managerTextBox As System.Windows.Forms.TextBox
    Friend WithEvents companyTextBox As System.Windows.Forms.TextBox
    Friend WithEvents categoryTextBox As System.Windows.Forms.TextBox
    Friend WithEvents keywordsTextBox As System.Windows.Forms.TextBox
    Friend WithEvents commentsTextBox As System.Windows.Forms.TextBox
    Friend WithEvents hyperlinkBaseTextBox As System.Windows.Forms.TextBox
    Friend WithEvents LookInSubfoldersCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents useDocNameCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents useTitleCheckbox As System.Windows.Forms.CheckBox
    Friend WithEvents useSubjectCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents useAuthorCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents useManagerCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents useCompanyCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents useCategoryCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents useKeywordsCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents useCommentsCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents useHyperlinkBaseCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents makeChangesButton As System.Windows.Forms.Button
    Friend WithEvents folderLabel As System.Windows.Forms.Label
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents statusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents cancelSearchButton As System.Windows.Forms.Button
    Friend WithEvents bgw As System.ComponentModel.BackgroundWorker

End Class
