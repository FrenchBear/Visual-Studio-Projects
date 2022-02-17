Imports System.ComponentModel
Imports FixWordProperties.My
Imports Microsoft.VisualBasic.CompilerServices

<DesignerGenerated()>
Partial Class Form1
    Inherits Form

    'Form overrides dispose to clean up the component list.
    <DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New Container
        Dim TitleLabel As Label
        Dim SubjectLabel As Label
        Dim AuthorLabel As Label
        Dim ManagerLabel As Label
        Dim CompanyLabel As Label
        Dim CategoryLabel As Label
        Dim KeywordsLabel As Label
        Dim CommentsLabel As Label
        Dim HyperlinkBaseLabel As Label
        Me.MySettingsBindingSource = New BindingSource(Me.components)
        Me.folderButton = New Button
        Me.fbd = New FolderBrowserDialog
        Me.titleTextBox = New TextBox
        Me.subjectTextBox = New TextBox
        Me.authorTextBox = New TextBox
        Me.managerTextBox = New TextBox
        Me.companyTextBox = New TextBox
        Me.categoryTextBox = New TextBox
        Me.keywordsTextBox = New TextBox
        Me.commentsTextBox = New TextBox
        Me.hyperlinkBaseTextBox = New TextBox
        Me.LookInSubfoldersCheckBox = New CheckBox
        Me.useDocNameCheckBox = New CheckBox
        Me.useTitleCheckbox = New CheckBox
        Me.useSubjectCheckBox = New CheckBox
        Me.useAuthorCheckBox = New CheckBox
        Me.useManagerCheckBox = New CheckBox
        Me.useCompanyCheckBox = New CheckBox
        Me.useCategoryCheckBox = New CheckBox
        Me.useKeywordsCheckBox = New CheckBox
        Me.useCommentsCheckBox = New CheckBox
        Me.useHyperlinkBaseCheckBox = New CheckBox
        Me.makeChangesButton = New Button
        Me.folderLabel = New Label
        Me.StatusStrip1 = New StatusStrip
        Me.statusLabel = New ToolStripStatusLabel
        Me.cancelSearchButton = New Button
        Me.bgw = New BackgroundWorker
        TitleLabel = New Label
        SubjectLabel = New Label
        AuthorLabel = New Label
        ManagerLabel = New Label
        CompanyLabel = New Label
        CategoryLabel = New Label
        KeywordsLabel = New Label
        CommentsLabel = New Label
        HyperlinkBaseLabel = New Label
        CType(Me.MySettingsBindingSource, ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TitleLabel
        '
        TitleLabel.Location = New Point(39, 75)
        TitleLabel.Name = "TitleLabel"
        TitleLabel.Size = New Size(72, 16)
        TitleLabel.TabIndex = 4
        TitleLabel.Text = "Title:"
        TitleLabel.TextAlign = ContentAlignment.MiddleLeft
        '
        'SubjectLabel
        '
        SubjectLabel.Location = New Point(39, 103)
        SubjectLabel.Name = "SubjectLabel"
        SubjectLabel.Size = New Size(72, 16)
        SubjectLabel.TabIndex = 8
        SubjectLabel.Text = "Subject:"
        SubjectLabel.TextAlign = ContentAlignment.MiddleLeft
        '
        'AuthorLabel
        '
        AuthorLabel.Location = New Point(39, 131)
        AuthorLabel.Name = "AuthorLabel"
        AuthorLabel.Size = New Size(72, 16)
        AuthorLabel.TabIndex = 11
        AuthorLabel.Text = "Author:"
        AuthorLabel.TextAlign = ContentAlignment.MiddleLeft
        '
        'ManagerLabel
        '
        ManagerLabel.Location = New Point(39, 159)
        ManagerLabel.Name = "ManagerLabel"
        ManagerLabel.Size = New Size(72, 16)
        ManagerLabel.TabIndex = 14
        ManagerLabel.Text = "Manager:"
        ManagerLabel.TextAlign = ContentAlignment.MiddleLeft
        '
        'CompanyLabel
        '
        CompanyLabel.Location = New Point(39, 187)
        CompanyLabel.Name = "CompanyLabel"
        CompanyLabel.Size = New Size(72, 16)
        CompanyLabel.TabIndex = 17
        CompanyLabel.Text = "Company:"
        CompanyLabel.TextAlign = ContentAlignment.MiddleLeft
        '
        'CategoryLabel
        '
        CategoryLabel.Location = New Point(41, 230)
        CategoryLabel.Name = "CategoryLabel"
        CategoryLabel.Size = New Size(72, 16)
        CategoryLabel.TabIndex = 20
        CategoryLabel.Text = "Category:"
        CategoryLabel.TextAlign = ContentAlignment.MiddleLeft
        '
        'KeywordsLabel
        '
        KeywordsLabel.Location = New Point(41, 258)
        KeywordsLabel.Name = "KeywordsLabel"
        KeywordsLabel.Size = New Size(72, 16)
        KeywordsLabel.TabIndex = 23
        KeywordsLabel.Text = "Keywords:"
        KeywordsLabel.TextAlign = ContentAlignment.MiddleLeft
        '
        'CommentsLabel
        '
        CommentsLabel.Location = New Point(41, 286)
        CommentsLabel.Name = "CommentsLabel"
        CommentsLabel.Size = New Size(72, 16)
        CommentsLabel.TabIndex = 26
        CommentsLabel.Text = "Comments:"
        CommentsLabel.TextAlign = ContentAlignment.MiddleLeft
        '
        'HyperlinkBaseLabel
        '
        HyperlinkBaseLabel.Location = New Point(41, 345)
        HyperlinkBaseLabel.Name = "HyperlinkBaseLabel"
        HyperlinkBaseLabel.Size = New Size(72, 34)
        HyperlinkBaseLabel.TabIndex = 29
        HyperlinkBaseLabel.Text = "Hyperlink Base:"
        HyperlinkBaseLabel.TextAlign = ContentAlignment.MiddleLeft
        '
        'MySettingsBindingSource
        '
        Me.MySettingsBindingSource.DataSource = MySettings.Default
        Me.MySettingsBindingSource.Position = 0
        '
        'folderButton
        '
        Me.folderButton.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles)
        Me.folderButton.Location = New Point(375, 7)
        Me.folderButton.Margin = New Padding(3, 4, 3, 4)
        Me.folderButton.Name = "folderButton"
        Me.folderButton.Size = New Size(139, 26)
        Me.folderButton.TabIndex = 1
        Me.folderButton.Text = "Select Input Folder"
        Me.folderButton.UseVisualStyleBackColor = True
        '
        'titleTextBox
        '
        Me.titleTextBox.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Left) _
                    Or AnchorStyles.Right), AnchorStyles)
        Me.titleTextBox.DataBindings.Add(New Binding("Text", Me.MySettingsBindingSource, "Title", True))
        Me.titleTextBox.Location = New Point(119, 72)
        Me.titleTextBox.Name = "titleTextBox"
        Me.titleTextBox.Size = New Size(252, 26)
        Me.titleTextBox.TabIndex = 5
        '
        'subjectTextBox
        '
        Me.subjectTextBox.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Left) _
                    Or AnchorStyles.Right), AnchorStyles)
        Me.subjectTextBox.DataBindings.Add(New Binding("Text", Me.MySettingsBindingSource, "Subject", True, DataSourceUpdateMode.OnPropertyChanged))
        Me.subjectTextBox.Location = New Point(119, 100)
        Me.subjectTextBox.Name = "subjectTextBox"
        Me.subjectTextBox.Size = New Size(252, 26)
        Me.subjectTextBox.TabIndex = 9
        '
        'authorTextBox
        '
        Me.authorTextBox.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Left) _
                    Or AnchorStyles.Right), AnchorStyles)
        Me.authorTextBox.DataBindings.Add(New Binding("Text", Me.MySettingsBindingSource, "Author", True))
        Me.authorTextBox.Location = New Point(119, 128)
        Me.authorTextBox.Name = "authorTextBox"
        Me.authorTextBox.Size = New Size(252, 26)
        Me.authorTextBox.TabIndex = 12
        '
        'managerTextBox
        '
        Me.managerTextBox.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Left) _
                    Or AnchorStyles.Right), AnchorStyles)
        Me.managerTextBox.DataBindings.Add(New Binding("Text", Me.MySettingsBindingSource, "Manager", True))
        Me.managerTextBox.Location = New Point(119, 156)
        Me.managerTextBox.Name = "managerTextBox"
        Me.managerTextBox.Size = New Size(252, 26)
        Me.managerTextBox.TabIndex = 15
        '
        'companyTextBox
        '
        Me.companyTextBox.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Left) _
                    Or AnchorStyles.Right), AnchorStyles)
        Me.companyTextBox.DataBindings.Add(New Binding("Text", Me.MySettingsBindingSource, "Company", True))
        Me.companyTextBox.Location = New Point(119, 184)
        Me.companyTextBox.Name = "companyTextBox"
        Me.companyTextBox.Size = New Size(252, 26)
        Me.companyTextBox.TabIndex = 18
        '
        'categoryTextBox
        '
        Me.categoryTextBox.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Left) _
                    Or AnchorStyles.Right), AnchorStyles)
        Me.categoryTextBox.DataBindings.Add(New Binding("Text", Me.MySettingsBindingSource, "Category", True))
        Me.categoryTextBox.Location = New Point(119, 227)
        Me.categoryTextBox.Name = "categoryTextBox"
        Me.categoryTextBox.Size = New Size(252, 26)
        Me.categoryTextBox.TabIndex = 21
        '
        'keywordsTextBox
        '
        Me.keywordsTextBox.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Left) _
                    Or AnchorStyles.Right), AnchorStyles)
        Me.keywordsTextBox.DataBindings.Add(New Binding("Text", Me.MySettingsBindingSource, "Keywords", True))
        Me.keywordsTextBox.Location = New Point(119, 255)
        Me.keywordsTextBox.Name = "keywordsTextBox"
        Me.keywordsTextBox.Size = New Size(252, 26)
        Me.keywordsTextBox.TabIndex = 24
        '
        'commentsTextBox
        '
        Me.commentsTextBox.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Left) _
                    Or AnchorStyles.Right), AnchorStyles)
        Me.commentsTextBox.DataBindings.Add(New Binding("Text", Me.MySettingsBindingSource, "Comments", True))
        Me.commentsTextBox.Location = New Point(119, 283)
        Me.commentsTextBox.Multiline = True
        Me.commentsTextBox.Name = "commentsTextBox"
        Me.commentsTextBox.Size = New Size(252, 62)
        Me.commentsTextBox.TabIndex = 27
        '
        'hyperlinkBaseTextBox
        '
        Me.hyperlinkBaseTextBox.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Left) _
                    Or AnchorStyles.Right), AnchorStyles)
        Me.hyperlinkBaseTextBox.DataBindings.Add(New Binding("Text", Me.MySettingsBindingSource, "HyperlinkBase", True))
        Me.hyperlinkBaseTextBox.Location = New Point(119, 351)
        Me.hyperlinkBaseTextBox.Name = "hyperlinkBaseTextBox"
        Me.hyperlinkBaseTextBox.Size = New Size(252, 26)
        Me.hyperlinkBaseTextBox.TabIndex = 30
        '
        'LookInSubfoldersCheckBox
        '
        Me.LookInSubfoldersCheckBox.DataBindings.Add(New Binding("CheckState", Me.MySettingsBindingSource, "LookInSubfolders", True))
        Me.LookInSubfoldersCheckBox.Location = New Point(17, 40)
        Me.LookInSubfoldersCheckBox.Name = "LookInSubfoldersCheckBox"
        Me.LookInSubfoldersCheckBox.Size = New Size(165, 24)
        Me.LookInSubfoldersCheckBox.TabIndex = 2
        Me.LookInSubfoldersCheckBox.Text = "Include Subfolders?"
        '
        'useDocNameCheckBox
        '
        Me.useDocNameCheckBox.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles)
        Me.useDocNameCheckBox.DataBindings.Add(New Binding("CheckState", Me.MySettingsBindingSource, "UseDocName", True))
        Me.useDocNameCheckBox.Location = New Point(375, 61)
        Me.useDocNameCheckBox.Name = "useDocNameCheckBox"
        Me.useDocNameCheckBox.Size = New Size(133, 47)
        Me.useDocNameCheckBox.TabIndex = 6
        Me.useDocNameCheckBox.Text = "Use document name?"
        '
        'useTitleCheckbox
        '
        Me.useTitleCheckbox.AutoSize = True
        Me.useTitleCheckbox.DataBindings.Add(New Binding("CheckState", Me.MySettingsBindingSource, "UseTitle", True))
        Me.useTitleCheckbox.Location = New Point(24, 77)
        Me.useTitleCheckbox.Name = "useTitleCheckbox"
        Me.useTitleCheckbox.Size = New Size(18, 17)
        Me.useTitleCheckbox.TabIndex = 3
        '
        'useSubjectCheckBox
        '
        Me.useSubjectCheckBox.AutoSize = True
        Me.useSubjectCheckBox.DataBindings.Add(New Binding("CheckState", Me.MySettingsBindingSource, "UseSubject", True))
        Me.useSubjectCheckBox.Location = New Point(24, 105)
        Me.useSubjectCheckBox.Name = "useSubjectCheckBox"
        Me.useSubjectCheckBox.Size = New Size(18, 17)
        Me.useSubjectCheckBox.TabIndex = 7
        '
        'useAuthorCheckBox
        '
        Me.useAuthorCheckBox.AutoSize = True
        Me.useAuthorCheckBox.DataBindings.Add(New Binding("CheckState", Me.MySettingsBindingSource, "UseAuthor", True))
        Me.useAuthorCheckBox.Location = New Point(24, 133)
        Me.useAuthorCheckBox.Name = "useAuthorCheckBox"
        Me.useAuthorCheckBox.Size = New Size(18, 17)
        Me.useAuthorCheckBox.TabIndex = 10
        '
        'useManagerCheckBox
        '
        Me.useManagerCheckBox.AutoSize = True
        Me.useManagerCheckBox.DataBindings.Add(New Binding("CheckState", Me.MySettingsBindingSource, "UseManager", True))
        Me.useManagerCheckBox.Location = New Point(24, 159)
        Me.useManagerCheckBox.Name = "useManagerCheckBox"
        Me.useManagerCheckBox.Size = New Size(18, 17)
        Me.useManagerCheckBox.TabIndex = 13
        '
        'useCompanyCheckBox
        '
        Me.useCompanyCheckBox.AutoSize = True
        Me.useCompanyCheckBox.DataBindings.Add(New Binding("CheckState", Me.MySettingsBindingSource, "UseCompany", True))
        Me.useCompanyCheckBox.Location = New Point(24, 189)
        Me.useCompanyCheckBox.Name = "useCompanyCheckBox"
        Me.useCompanyCheckBox.Size = New Size(18, 17)
        Me.useCompanyCheckBox.TabIndex = 16
        '
        'useCategoryCheckBox
        '
        Me.useCategoryCheckBox.AutoSize = True
        Me.useCategoryCheckBox.DataBindings.Add(New Binding("CheckState", Me.MySettingsBindingSource, "UseCategory", True))
        Me.useCategoryCheckBox.Location = New Point(24, 232)
        Me.useCategoryCheckBox.Name = "useCategoryCheckBox"
        Me.useCategoryCheckBox.Size = New Size(18, 17)
        Me.useCategoryCheckBox.TabIndex = 19
        '
        'useKeywordsCheckBox
        '
        Me.useKeywordsCheckBox.AutoSize = True
        Me.useKeywordsCheckBox.DataBindings.Add(New Binding("CheckState", Me.MySettingsBindingSource, "UseKeywords", True))
        Me.useKeywordsCheckBox.Location = New Point(24, 260)
        Me.useKeywordsCheckBox.Name = "useKeywordsCheckBox"
        Me.useKeywordsCheckBox.Size = New Size(18, 17)
        Me.useKeywordsCheckBox.TabIndex = 22
        '
        'useCommentsCheckBox
        '
        Me.useCommentsCheckBox.AutoSize = True
        Me.useCommentsCheckBox.DataBindings.Add(New Binding("CheckState", Me.MySettingsBindingSource, "UseComments", True))
        Me.useCommentsCheckBox.Location = New Point(24, 288)
        Me.useCommentsCheckBox.Name = "useCommentsCheckBox"
        Me.useCommentsCheckBox.Size = New Size(18, 17)
        Me.useCommentsCheckBox.TabIndex = 25
        '
        'useHyperlinkBaseCheckBox
        '
        Me.useHyperlinkBaseCheckBox.AutoSize = True
        Me.useHyperlinkBaseCheckBox.DataBindings.Add(New Binding("CheckState", Me.MySettingsBindingSource, "UseHyperlinkBase", True))
        Me.useHyperlinkBaseCheckBox.Location = New Point(24, 356)
        Me.useHyperlinkBaseCheckBox.Name = "useHyperlinkBaseCheckBox"
        Me.useHyperlinkBaseCheckBox.Size = New Size(18, 17)
        Me.useHyperlinkBaseCheckBox.TabIndex = 28
        '
        'makeChangesButton
        '
        Me.makeChangesButton.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Right), AnchorStyles)
        Me.makeChangesButton.Location = New Point(232, 377)
        Me.makeChangesButton.Name = "makeChangesButton"
        Me.makeChangesButton.Size = New Size(139, 26)
        Me.makeChangesButton.TabIndex = 31
        Me.makeChangesButton.Text = "Make Changes"
        Me.makeChangesButton.UseVisualStyleBackColor = True
        '
        'folderLabel
        '
        Me.folderLabel.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Left) _
                    Or AnchorStyles.Right), AnchorStyles)
        Me.folderLabel.BorderStyle = BorderStyle.FixedSingle
        Me.folderLabel.DataBindings.Add(New Binding("Text", Me.MySettingsBindingSource, "Folder", True))
        Me.folderLabel.Location = New Point(12, 7)
        Me.folderLabel.Name = "folderLabel"
        Me.folderLabel.Size = New Size(359, 26)
        Me.folderLabel.TabIndex = 0
        Me.folderLabel.TextAlign = ContentAlignment.MiddleLeft
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New ToolStripItem() {Me.statusLabel})
        Me.StatusStrip1.Location = New Point(0, 399)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New Size(526, 23)
        Me.StatusStrip1.TabIndex = 34
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'statusLabel
        '
        Me.statusLabel.AutoSize = False
        Me.statusLabel.BackColor = Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.statusLabel.DisplayStyle = ToolStripItemDisplayStyle.Text
        Me.statusLabel.Name = "statusLabel"
        Me.statusLabel.Size = New Size(240, 18)
        Me.statusLabel.Spring = True
        Me.statusLabel.TextAlign = ContentAlignment.MiddleLeft
        '
        'cancelSearchButton
        '
        Me.cancelSearchButton.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Right), AnchorStyles)
        Me.cancelSearchButton.Location = New Point(375, 377)
        Me.cancelSearchButton.Name = "cancelSearchButton"
        Me.cancelSearchButton.Size = New Size(139, 26)
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
        Me.AutoScaleDimensions = New SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.ClientSize = New Size(526, 422)
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
        Me.Font = New Font("Microsoft Sans Serif", 9.75!, FontStyle.Regular, GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New Padding(3, 4, 3, 4)
        Me.MaximumSize = New Size(869, 466)
        Me.MinimumSize = New Size(534, 466)
        Me.Name = "Form1"
        Me.Text = "Set Word Document Properties"
        CType(Me.MySettingsBindingSource, ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MySettingsBindingSource As BindingSource
    Friend WithEvents folderButton As Button
    Friend WithEvents fbd As FolderBrowserDialog
    Friend WithEvents titleTextBox As TextBox
    Friend WithEvents subjectTextBox As TextBox
    Friend WithEvents authorTextBox As TextBox
    Friend WithEvents managerTextBox As TextBox
    Friend WithEvents companyTextBox As TextBox
    Friend WithEvents categoryTextBox As TextBox
    Friend WithEvents keywordsTextBox As TextBox
    Friend WithEvents commentsTextBox As TextBox
    Friend WithEvents hyperlinkBaseTextBox As TextBox
    Friend WithEvents LookInSubfoldersCheckBox As CheckBox
    Friend WithEvents useDocNameCheckBox As CheckBox
    Friend WithEvents useTitleCheckbox As CheckBox
    Friend WithEvents useSubjectCheckBox As CheckBox
    Friend WithEvents useAuthorCheckBox As CheckBox
    Friend WithEvents useManagerCheckBox As CheckBox
    Friend WithEvents useCompanyCheckBox As CheckBox
    Friend WithEvents useCategoryCheckBox As CheckBox
    Friend WithEvents useKeywordsCheckBox As CheckBox
    Friend WithEvents useCommentsCheckBox As CheckBox
    Friend WithEvents useHyperlinkBaseCheckBox As CheckBox
    Friend WithEvents makeChangesButton As Button
    Friend WithEvents folderLabel As Label
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents statusLabel As ToolStripStatusLabel
    Friend WithEvents cancelSearchButton As Button
    Friend WithEvents bgw As BackgroundWorker

End Class
