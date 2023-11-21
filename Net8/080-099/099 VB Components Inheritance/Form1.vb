' 099 VB Components Inheritance
'
' 2006-10-01 	PV		VS2005
' 2012-02-25	PV		VS2010
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8

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
        Me.ListBox1 = New ListBox
        Me.Label1 = New Label
        Me.Button1 = New Button
        Me.TreeView1 = New TreeView
        Me.Label2 = New Label
        Me.SuspendLayout()
        '
        'ListBox1
        '
        Me.ListBox1.Location = New Point(8, 40)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New Size(216, 199)
        Me.ListBox1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.Location = New Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New Size(192, 32)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Listbox standard dans laquelle on ajoute des ListItemPerso"
        '
        'Button1
        '
        Me.Button1.Location = New Point(528, 24)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New Size(75, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Button1"
        '
        'TreeView1
        '
        Me.TreeView1.Location = New Point(232, 40)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.Size = New Size(184, 200)
        Me.TreeView1.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.Location = New Point(229, 5)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New Size(192, 32)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "TreeView standard dans laquelle on ajoute des ArticleTreeNode"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New Size(5, 13)
        Me.ClientSize = New Size(624, 266)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TreeView1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ListBox1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

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
