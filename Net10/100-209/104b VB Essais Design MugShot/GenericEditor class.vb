' Mother class for all Editor UserControls
' Inherits itself UserControl since usercontrols must inherit from this class, and only one
' base class is possible (Ok, cound have been implemented using an interface, but it's more
' original with this approach !)
'
' 2006-04-13    PV
' 2012-02-25	PV		VS2010
' 2021-09-19 	PV		VS2022; Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9
' 2026-01-19	PV		Net10
Imports System.ComponentModel

#Disable Warning IDE1006 ' Naming Styles
#Disable Warning IDE0051 ' Remove unused private members

Public Class GenericEditor
    Inherits UserControl

    Protected m_doc As EditDoc
    Friend WithEvents tsGeneric As ToolStrip
    Friend WithEvents tsbGenericSave As ToolStripButton
    Friend WithEvents tsbGenericRevertToSaved As ToolStripButton
    Friend WithEvents tssGeneric1 As ToolStripSeparator
    Friend WithEvents tsbGenericPrint As ToolStripButton
    Friend WithEvents gbDocumentProperties As GroupBox
    Friend WithEvents lblComments As Label
    Friend WithEvents lblTitle As Label
    Friend WithEvents txtComments As TextBox
    Friend WithEvents txtTitle As TextBox
    Private p_bDirty As Boolean

    Public Event DirtyChanged()

    Public Property m_bDirty() As Boolean
        Get
            m_bDirty = p_bDirty
        End Get
        Protected Set(value As Boolean)
            If p_bDirty <> value Then
                p_bDirty = value
                RaiseEvent DirtyChanged()
            End If
        End Set
    End Property

    Public Overridable Sub DoEdit(ed As EditDoc)
        m_doc = ed
    End Sub

    Protected Sub ShellPrint()
        ShellAction("Print")
    End Sub

    Protected Sub ShellOpen()
        ShellAction("Print")
    End Sub

    Private Sub ShellAction(sAction As String)
        ' These are the Win32 error code for file not found or access denied.
        Const ERROR_FILE_NOT_FOUND As Integer = 2
        Const ERROR_ACCESS_DENIED As Integer = 5

        Dim myProcess As New Process()

        Try
            myProcess.StartInfo.FileName = m_doc.sPathName
            myProcess.StartInfo.Verb = sAction
            myProcess.StartInfo.CreateNoWindow = True
            myProcess.Start()
        Catch ex As Win32Exception
            If ex.NativeErrorCode = ERROR_FILE_NOT_FOUND Then
                WriteLine(ex.Message + ". Check the path.")
            Else
                If ex.NativeErrorCode = ERROR_ACCESS_DENIED Then
                    ' Note that if your word processor might generate exceptions
                    ' such as this, which are handled first.
                    WriteLine(ex.Message + ". You do not have permission to print this file.")
                End If
            End If
        End Try
    End Sub

    Private Sub InitializeComponent()
        Dim resources = New ComponentResourceManager(GetType(GenericEditor))
        tsGeneric = New ToolStrip()
        tsbGenericSave = New ToolStripButton()
        tsbGenericRevertToSaved = New ToolStripButton()
        tssGeneric1 = New ToolStripSeparator()
        tsbGenericPrint = New ToolStripButton()
        gbDocumentProperties = New GroupBox()
        txtComments = New TextBox()
        txtTitle = New TextBox()
        lblComments = New Label()
        lblTitle = New Label()
        tsGeneric.SuspendLayout()
        gbDocumentProperties.SuspendLayout()
        SuspendLayout()
        '
        'tsGeneric
        '
        tsGeneric.ImageScalingSize = New Size(24, 24)
        tsGeneric.Items.AddRange(New ToolStripItem() {tsbGenericSave, tsbGenericRevertToSaved, tssGeneric1, tsbGenericPrint})
        tsGeneric.Location = New Point(0, 0)
        tsGeneric.Name = "tsGeneric"
        tsGeneric.Size = New Size(769, 33)
        tsGeneric.TabIndex = 2
        tsGeneric.Text = "ToolStrip1"
        '
        'tsbGenericSave
        '
        tsbGenericSave.DisplayStyle = ToolStripItemDisplayStyle.Image
        tsbGenericSave.Image = CType(resources.GetObject("tsbGenericSave.Image"), Image)
        tsbGenericSave.ImageTransparentColor = Color.Magenta
        tsbGenericSave.Name = "tsbGenericSave"
        tsbGenericSave.Size = New Size(34, 28)
        tsbGenericSave.Text = "Save"
        tsbGenericSave.ToolTipText = "Save Text"
        '
        'tsbGenericRevertToSaved
        '
        tsbGenericRevertToSaved.DisplayStyle = ToolStripItemDisplayStyle.Image
        tsbGenericRevertToSaved.Image = CType(resources.GetObject("tsbGenericRevertToSaved.Image"), Image)
        tsbGenericRevertToSaved.ImageTransparentColor = Color.Magenta
        tsbGenericRevertToSaved.Name = "tsbGenericRevertToSaved"
        tsbGenericRevertToSaved.Size = New Size(34, 28)
        tsbGenericRevertToSaved.Text = "Revert"
        tsbGenericRevertToSaved.ToolTipText = "Revert to saved text"
        '
        'tssGeneric1
        '
        tssGeneric1.Name = "tssGeneric1"
        tssGeneric1.Size = New Size(6, 33)
        '
        'tsbGenericPrint
        '
        tsbGenericPrint.DisplayStyle = ToolStripItemDisplayStyle.Image
        tsbGenericPrint.Image = CType(resources.GetObject("tsbGenericPrint.Image"), Image)
        tsbGenericPrint.ImageTransparentColor = Color.Magenta
        tsbGenericPrint.Name = "tsbGenericPrint"
        tsbGenericPrint.Size = New Size(34, 28)
        tsbGenericPrint.Text = "Print"
        '
        'gbDocumentProperties
        '
        gbDocumentProperties.Controls.Add(txtComments)
        gbDocumentProperties.Controls.Add(txtTitle)
        gbDocumentProperties.Controls.Add(lblComments)
        gbDocumentProperties.Controls.Add(lblTitle)
        gbDocumentProperties.Dock = DockStyle.Top
        gbDocumentProperties.Location = New Point(0, 33)
        gbDocumentProperties.Name = "gbDocumentProperties"
        gbDocumentProperties.Size = New Size(769, 96)
        gbDocumentProperties.TabIndex = 3
        gbDocumentProperties.TabStop = False
        gbDocumentProperties.Text = "Document Properties"
        '
        'txtComments
        '
        txtComments.Anchor = AnchorStyles.Top Or AnchorStyles.Left _
            Or AnchorStyles.Right
        txtComments.Location = New Point(66, 42)
        txtComments.Multiline = True
        txtComments.Name = "txtComments"
        txtComments.Size = New Size(700, 48)
        txtComments.TabIndex = 3
        '
        'txtTitle
        '
        txtTitle.Anchor = AnchorStyles.Top Or AnchorStyles.Left _
            Or AnchorStyles.Right
        txtTitle.Location = New Point(66, 16)
        txtTitle.Name = "txtTitle"
        txtTitle.Size = New Size(700, 27)
        txtTitle.TabIndex = 2
        '
        'lblComments
        '
        lblComments.AutoSize = True
        lblComments.Location = New Point(3, 45)
        lblComments.Name = "lblComments"
        lblComments.Size = New Size(89, 21)
        lblComments.TabIndex = 1
        lblComments.Text = "Comments"
        '
        'lblTitle
        '
        lblTitle.AutoSize = True
        lblTitle.Location = New Point(3, 19)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(43, 21)
        lblTitle.TabIndex = 0
        lblTitle.Text = "Title"
        '
        'GenericEditor
        '
        Controls.Add(gbDocumentProperties)
        Controls.Add(tsGeneric)
        Font = New Font("Tahoma", 8.25!, FontStyle.Regular, GraphicsUnit.Point)
        Name = "GenericEditor"
        Size = New Size(769, 571)
        tsGeneric.ResumeLayout(False)
        tsGeneric.PerformLayout()
        gbDocumentProperties.ResumeLayout(False)
        gbDocumentProperties.PerformLayout()
        ResumeLayout(False)
        PerformLayout()

    End Sub

End Class
