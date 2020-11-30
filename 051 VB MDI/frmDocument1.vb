' 2001 PV
' 2006-10-01    PV  VS2005
' 2012-02-25	PV  VS2010


Imports System.Drawing
Imports System.Windows.Forms


Imports System.ComponentModel


Public Class frmDocument1
    Inherits System.Windows.Forms.Form

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
    Private ReadOnly components As System.ComponentModel.Container

    Private WithEvents txtDoc As System.Windows.Forms.TextBox

    Dim WithEvents frmDocument As System.Windows.Forms.Form

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents cmdTimes As System.Windows.Forms.MenuItem
    Friend WithEvents cmdArial As System.Windows.Forms.MenuItem

    Private Sub InitializeComponent()
        Me.txtDoc = New System.Windows.Forms.TextBox
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.cmdTimes = New System.Windows.Forms.MenuItem
        Me.cmdArial = New System.Windows.Forms.MenuItem
        Me.SuspendLayout()
        '
        'txtDoc
        '
        Me.txtDoc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.txtDoc.Location = New System.Drawing.Point(0, 0)
        Me.txtDoc.Multiline = True
        Me.txtDoc.Name = "txtDoc"
        Me.txtDoc.Size = New System.Drawing.Size(292, 266)
        Me.txtDoc.TabIndex = 0
        Me.txtDoc.Text = ""
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1})
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 0
        Me.MenuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.cmdTimes, Me.cmdArial})
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
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.txtDoc)
        Me.Menu = Me.MainMenu1
        Me.Name = "frmDocument1"
        Me.Text = "Document"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Sub SetFont(ByVal sFontName As String)
        txtDoc.Font = New Font(sFontName, 10)
    End Sub

    Protected Sub cmdTimes_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdTimes.Click
        SetFont("Times New Roman")
    End Sub

    Protected Sub cmdArial_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdArial.Click
        SetFont("Arial")
    End Sub

End Class
