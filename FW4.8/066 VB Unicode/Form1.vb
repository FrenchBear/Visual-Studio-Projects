' 2006-10-01    PV  VS2005
' 2012-02-25	PV  VS2010

#Disable Warning IDE1006 ' Naming Styles

Public Class Form1
    Inherits Form

    Declare Unicode Sub toto Lib "mylib" Alias "toto" (s As String)

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
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents MainMenu1 As MainMenu
    Friend WithEvents mnuFichier As MenuItem
    Friend WithEvents cmdQuitter As MenuItem

    'Required by the Windows Form Designer
    Private ReadOnly components As System.ComponentModel.Container

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Button1 = New Button()
        Me.TextBox1 = New TextBox()
        Me.MainMenu1 = New MainMenu()
        Me.mnuFichier = New MenuItem()
        Me.cmdQuitter = New MenuItem()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New Point(168, 64)
        Me.Button1.Name = "Button1"
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Button1"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New Point(80, 160)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.TabIndex = 1
        Me.TextBox1.Text = "TextBox1"
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.AddRange(New MenuItem() {Me.mnuFichier})
        '
        'mnuFichier
        '
        Me.mnuFichier.Index = 0
        Me.mnuFichier.MenuItems.AddRange(New MenuItem() {Me.cmdQuitter})
        Me.mnuFichier.Text = "&Fichier"
        '
        'cmdQuitter
        '
        Me.cmdQuitter.Index = 0
        Me.cmdQuitter.Text = "&Quitter"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New Size(5, 13)
        Me.ClientSize = New Size(292, 266)
        Me.Controls.AddRange(New Control() {Me.TextBox1, Me.Button1})
        Me.Menu = Me.MainMenu1
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Button1_Click(sender As System.Object, e As EventArgs) Handles Button1.Click
        Dim buf As String
        buf = "Hel" & ChrW(&H142S) & "o " & ChrW(&H3B1S) & ChrW(&H3B2S) & ChrW(&H3B3S) & ChrW(&H3B4S)

        TextBox1.Text = buf

        mnuFichier.Text = buf

    End Sub

End Class