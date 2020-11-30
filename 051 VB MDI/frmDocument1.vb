' 2001 PV
' 2006-10-01    PV  VS2005
' 2012-02-25	PV  VS2010

Imports System.Drawing

#Disable Warning IDE1006 ' Naming Styles
#Disable Warning IDE0052 ' Remove unread private members
#Disable Warning IDE0051 ' Remove unused private members

Public Class frmDocument1
    Inherits Windows.Forms.Form

    Shared iSerial As Integer

    Public Sub New()
        MyBase.New()

        frmDocument = Me

        'This call is required by the Win Form Designer.
        InitializeComponent()

        iSerial += 1
        Me.Text &= iSerial
    End Sub

    'Form overrides dispose to clean up the component list.
    'Public Overrides Sub Dispose()
    '  MyBase.Dispose()
    '  components.Dispose()
    'End Sub

#Region " Windows Form Designer generated code "

    'Required by the Windows Form Designer
    Private ReadOnly components As ComponentModel.Container

    Private WithEvents txtDoc As Windows.Forms.TextBox

    Dim WithEvents frmDocument As Windows.Forms.Form

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    Friend WithEvents MainMenu1 As Windows.Forms.MainMenu

    Friend WithEvents MenuItem1 As Windows.Forms.MenuItem
    Friend WithEvents cmdTimes As Windows.Forms.MenuItem
    Friend WithEvents cmdArial As Windows.Forms.MenuItem

    Private Sub InitializeComponent()
        Me.txtDoc = New Windows.Forms.TextBox
        Me.MainMenu1 = New Windows.Forms.MainMenu
        Me.MenuItem1 = New Windows.Forms.MenuItem
        Me.cmdTimes = New Windows.Forms.MenuItem
        Me.cmdArial = New Windows.Forms.MenuItem
        Me.SuspendLayout()
        '
        'txtDoc
        '
        Me.txtDoc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDoc.Location = New Point(0, 0)
        Me.txtDoc.Multiline = True
        Me.txtDoc.Name = "txtDoc"
        Me.txtDoc.Size = New Size(292, 266)
        Me.txtDoc.TabIndex = 0
        Me.txtDoc.Text = ""
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.AddRange(New Windows.Forms.MenuItem() {Me.MenuItem1})
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 0
        Me.MenuItem1.MenuItems.AddRange(New Windows.Forms.MenuItem() {Me.cmdTimes, Me.cmdArial})
        Me.MenuItem1.Text = "&Document"
        '
        'cmdTimes
        '
        Me.cmdTimes.Index = 0
        Me.cmdTimes.Text = "&Times"
        '
        'cmdArial
        '
        Me.cmdArial.Index = 1
        Me.cmdArial.Text = "&Arial"
        '
        'frmDocument1
        '
        Me.AutoScaleBaseSize = New Size(5, 13)
        Me.ClientSize = New Size(292, 266)
        Me.Controls.Add(Me.txtDoc)
        Me.Menu = Me.MainMenu1
        Me.Name = "frmDocument1"
        Me.Text = "Document"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Sub SetFont(sFontName As String)
        txtDoc.Font = New Font(sFontName, 10)
    End Sub

    Protected Sub cmdTimes_Click(sender As Object, e As EventArgs) Handles cmdTimes.Click
        SetFont("Times New Roman")
    End Sub

    Protected Sub cmdArial_Click(sender As Object, e As EventArgs) Handles cmdArial.Click
        SetFont("Arial")
    End Sub

End Class