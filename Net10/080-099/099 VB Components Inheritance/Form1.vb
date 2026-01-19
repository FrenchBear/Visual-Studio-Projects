' 099 VB Components Inheritance
'
' 2006-10-01 	PV		VS2005
' 2012-02-25	PV		VS2010
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9
' 2026-01-19	PV		Net10

#Disable Warning IDE0052 ' Remove unread private members

Public Class Form1
    Inherits Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(disposing As Boolean)
        If disposing Then
            components?.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private ReadOnly components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    Friend WithEvents ListBox1 As ListBox

    Friend WithEvents Label1 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents TreeView1 As TreeView

    <DebuggerStepThrough()> Private Sub InitializeComponent()
        ListBox1 = New ListBox
        Label1 = New Label
        Button1 = New Button
        TreeView1 = New TreeView
        Label2 = New Label
        SuspendLayout()
        '
        'ListBox1
        '
        ListBox1.Location = New Point(8, 40)
        ListBox1.Name = "ListBox1"
        ListBox1.Size = New Size(216, 199)
        ListBox1.TabIndex = 0
        '
        'Label1
        '
        Label1.Location = New Point(8, 8)
        Label1.Name = "Label1"
        Label1.Size = New Size(192, 32)
        Label1.TabIndex = 1
        Label1.Text = "Listbox standard dans laquelle on ajoute des ListItemPerso"
        '
        'Button1
        '
        Button1.Location = New Point(528, 24)
        Button1.Name = "Button1"
        Button1.Size = New Size(75, 23)
        Button1.TabIndex = 2
        Button1.Text = "Button1"
        '
        'TreeView1
        '
        TreeView1.Location = New Point(232, 40)
        TreeView1.Name = "TreeView1"
        TreeView1.Size = New Size(184, 200)
        TreeView1.TabIndex = 3
        '
        'Label2
        '
        Label2.Location = New Point(229, 5)
        Label2.Name = "Label2"
        Label2.Size = New Size(192, 32)
        Label2.TabIndex = 4
        Label2.Text = "TreeView standard dans laquelle on ajoute des ArticleTreeNode"
        '
        'Form1
        '
        AutoScaleBaseSize = New Size(5, 13)
        ClientSize = New Size(624, 266)
        Controls.Add(Label2)
        Controls.Add(TreeView1)
        Controls.Add(Button1)
        Controls.Add(Label1)
        Controls.Add(ListBox1)
        Name = "Form1"
        Text = "Form1"
        ResumeLayout(False)

    End Sub

#End Region

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim a1 As New ArticleTreeNode("pomme", 1.3)
        Dim a2 As New ArticleTreeNode("poire", 1.5)
        TreeView1.Nodes.Add(a1)
        TreeView1.Nodes.Add(a2)

        Dim l1 As New ListIemPerso("ananas")
        ListBox1.Items.Add(l1)
    End Sub

End Class

' Note: does not inherit from ListItem...
Friend Class ListIemPerso
    Private ReadOnly m_sName As String

    Public Sub New(sName As String)
        m_sName = sName
    End Sub

    Public Overrides Function ToString() As String
        Return m_sName
    End Function

End Class

Friend Class ArticleTreeNode
    Inherits TreeNode

    Private ReadOnly sNom As String
    Private ReadOnly fPrix As Single

    Public Sub New(sNewNom As String, fNewPrix As Single)
        fPrix = fNewPrix
        sNom = sNewNom
        Text = sNewNom
    End Sub

End Class
