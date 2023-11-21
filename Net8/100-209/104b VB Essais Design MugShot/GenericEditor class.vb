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
                WriteLine((ex.Message + ". Check the path."))
            Else
                If ex.NativeErrorCode = ERROR_ACCESS_DENIED Then
                    ' Note that if your word processor might generate exceptions
                    ' such as this, which are handled first.
                    WriteLine((ex.Message + ". You do not have permission to print this file."))
                End If
            End If
        End Try
    End Sub

    Private Sub InitializeComponent()
        Dim resources = New ComponentResourceManager(GetType(GenericEditor))
        Me.tsGeneric = New ToolStrip()
        Me.tsbGenericSave = New ToolStripButton()
        Me.tsbGenericRevertToSaved = New ToolStripButton()
        Me.tssGeneric1 = New ToolStripSeparator()
        Me.tsbGenericPrint = New ToolStripButton()
        Me.gbDocumentProperties = New GroupBox()
        Me.txtComments = New TextBox()
        Me.txtTitle = New TextBox()
        Me.lblComments = New Label()
        Me.lblTitle = New Label()
        Me.tsGeneric.SuspendLayout()
        Me.gbDocumentProperties.SuspendLayout()
        Me.SuspendLayout()
        '
        'tsGeneric
        '
        Me.tsGeneric.ImageScalingSize = New Size(24, 24)
        Me.tsGeneric.Items.AddRange(New ToolStripItem() {Me.tsbGenericSave, Me.tsbGenericRevertToSaved, Me.tssGeneric1, Me.tsbGenericPrint})
        Me.tsGeneric.Location = New Point(0, 0)
        Me.tsGeneric.Name = "tsGeneric"
        Me.tsGeneric.Size = New Size(769, 33)
        Me.tsGeneric.TabIndex = 2
        Me.tsGeneric.Text = "ToolStrip1"
        '
        'tsbGenericSave
        '
        Me.tsbGenericSave.DisplayStyle = ToolStripItemDisplayStyle.Image
        Me.tsbGenericSave.Image = CType(resources.GetObject("tsbGenericSave.Image"), Image)
        Me.tsbGenericSave.ImageTransparentColor = Color.Magenta
        Me.tsbGenericSave.Name = "tsbGenericSave"
        Me.tsbGenericSave.Size = New Size(34, 28)
        Me.tsbGenericSave.Text = "Save"
        Me.tsbGenericSave.ToolTipText = "Save Text"
        '
        'tsbGenericRevertToSaved
        '
        Me.tsbGenericRevertToSaved.DisplayStyle = ToolStripItemDisplayStyle.Image
        Me.tsbGenericRevertToSaved.Image = CType(resources.GetObject("tsbGenericRevertToSaved.Image"), Image)
        Me.tsbGenericRevertToSaved.ImageTransparentColor = Color.Magenta
        Me.tsbGenericRevertToSaved.Name = "tsbGenericRevertToSaved"
        Me.tsbGenericRevertToSaved.Size = New Size(34, 28)
        Me.tsbGenericRevertToSaved.Text = "Revert"
        Me.tsbGenericRevertToSaved.ToolTipText = "Revert to saved text"
        '
        'tssGeneric1
        '
        Me.tssGeneric1.Name = "tssGeneric1"
        Me.tssGeneric1.Size = New Size(6, 33)
        '
        'tsbGenericPrint
        '
        Me.tsbGenericPrint.DisplayStyle = ToolStripItemDisplayStyle.Image
        Me.tsbGenericPrint.Image = CType(resources.GetObject("tsbGenericPrint.Image"), Image)
        Me.tsbGenericPrint.ImageTransparentColor = Color.Magenta
        Me.tsbGenericPrint.Name = "tsbGenericPrint"
        Me.tsbGenericPrint.Size = New Size(34, 28)
        Me.tsbGenericPrint.Text = "Print"
        '
        'gbDocumentProperties
        '
        Me.gbDocumentProperties.Controls.Add(Me.txtComments)
        Me.gbDocumentProperties.Controls.Add(Me.txtTitle)
        Me.gbDocumentProperties.Controls.Add(Me.lblComments)
        Me.gbDocumentProperties.Controls.Add(Me.lblTitle)
        Me.gbDocumentProperties.Dock = DockStyle.Top
        Me.gbDocumentProperties.Location = New Point(0, 33)
        Me.gbDocumentProperties.Name = "gbDocumentProperties"
        Me.gbDocumentProperties.Size = New Size(769, 96)
        Me.gbDocumentProperties.TabIndex = 3
        Me.gbDocumentProperties.TabStop = False
        Me.gbDocumentProperties.Text = "Document Properties"
        '
        'txtComments
        '
        Me.txtComments.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Left) _
            Or AnchorStyles.Right), AnchorStyles)
        Me.txtComments.Location = New Point(66, 42)
        Me.txtComments.Multiline = True
        Me.txtComments.Name = "txtComments"
        Me.txtComments.Size = New Size(700, 48)
        Me.txtComments.TabIndex = 3
        '
        'txtTitle
        '
        Me.txtTitle.Anchor = CType(((AnchorStyles.Top Or AnchorStyles.Left) _
            Or AnchorStyles.Right), AnchorStyles)
        Me.txtTitle.Location = New Point(66, 16)
        Me.txtTitle.Name = "txtTitle"
        Me.txtTitle.Size = New Size(700, 27)
        Me.txtTitle.TabIndex = 2
        '
        'lblComments
        '
        Me.lblComments.AutoSize = True
        Me.lblComments.Location = New Point(3, 45)
        Me.lblComments.Name = "lblComments"
        Me.lblComments.Size = New Size(89, 21)
        Me.lblComments.TabIndex = 1
        Me.lblComments.Text = "Comments"
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Location = New Point(3, 19)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New Size(43, 21)
        Me.lblTitle.TabIndex = 0
        Me.lblTitle.Text = "Title"
        '
        'GenericEditor
        '
        Me.Controls.Add(Me.gbDocumentProperties)
        Me.Controls.Add(Me.tsGeneric)
        Me.Font = New Font("Tahoma", 8.25!, FontStyle.Regular, GraphicsUnit.Point)
        Me.Name = "GenericEditor"
        Me.Size = New Size(769, 571)
        Me.tsGeneric.ResumeLayout(False)
        Me.tsGeneric.PerformLayout()
        Me.gbDocumentProperties.ResumeLayout(False)
        Me.gbDocumentProperties.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

End Class
