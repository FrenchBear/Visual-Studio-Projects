' 2001 PV
' 2006-10-01    PV  VS2005
' 2012-02-25	PV  VS2010

Public Class MDIMain
    Inherits Form

    Public g As New DonneesGlobales()

    Public Sub New()
        MyBase.New()

        MDIMain = Me

        'This call is required by the Win Form Designer.
        InitializeComponent()

        g.sNom = "Pierre"
    End Sub

#Region " Windows Form Designer generated code "

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container

    Private WithEvents MenuItem4 As MenuItem
    Private WithEvents MenuItem3 As MenuItem
    Private WithEvents MenuItem2 As MenuItem
    Private WithEvents MenuItem1 As MenuItem
    Private MainMenu1 As MainMenu

    Dim WithEvents MDIMain As Form

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Me.components = New ComponentModel.Container()
        Me.MenuItem1 = New MenuItem()
        Me.MenuItem2 = New MenuItem()
        Me.MainMenu1 = New MainMenu()
        Me.MenuItem4 = New MenuItem()
        Me.MenuItem3 = New MenuItem()

        '@design Me.TrayHeight = 90
        '@design Me.TrayLargeIcon = False
        '@design Me.TrayAutoArrange = True
        MenuItem1.Text = "F1"
        MenuItem1.Index = 0

        MenuItem2.Text = "F2"
        MenuItem2.Index = 1

        MainMenu1.MenuItems.Add(MenuItem1)
        MainMenu1.MenuItems.Add(MenuItem2)
        MainMenu1.MenuItems.Add(MenuItem3)
        MainMenu1.MenuItems.Add(MenuItem4)

        MenuItem4.Text = "Quitter"
        MenuItem4.Index = 3

        MenuItem3.Text = "F3"
        MenuItem3.Index = 2
        Me.Text = "Form1"
        Me.AutoScaleBaseSize = New Size(5, 13)
        Me.IsMdiContainer = True
        Me.Menu = MainMenu1
        Me.ClientSize = New Size(332, 333)

    End Sub

#End Region

    Protected Sub MenuItem1_Click(sender As Object, e As EventArgs) Handles MenuItem1.Click
        Dim f As New F1 With {
            .MdiParent = Me
        }
        f.Show()
    End Sub

    Protected Sub MenuItem2_Click(sender As Object, e As EventArgs) Handles MenuItem2.Click
        Dim f As New F2 With {
            .MdiParent = Me
        }
        f.Init(g)
        f.Show()
    End Sub

    Protected Sub MenuItem3_Click(sender As Object, e As EventArgs) Handles MenuItem3.Click
        Dim tabo As Object()
        ReDim tabo(0)

        Dim x As Object
        x = My.Application.Info.DirectoryPath

        Dim a As Reflection.Assembly
        a = System.Reflection.Assembly.Load("F3")
        Dim t As Type
        t = a.GetType("F3")

        ' 1/10/2006: Can't make InvokeMember work, but direct call is working, so...
        Dim o As Object
        o = Activator.CreateInstance(t)
        o.MdiParent = Me
        o.Montre()

        'Dim c As ConstructorInfo
        'Dim types() As Type
        'ReDim types(0)
        'c = t.GetConstructor(types)
        'o = c.Invoke(tabo)

        'Dim taba As Object()
        'ReDim taba(1)
        'taba(0) = Me
        ''  BindingFlags.Default Or BindingFlags.SetField Or BindingFlags.SetProperty
        't.InvokeMember("MdiParent", BindingFlags.Public Or BindingFlags.IgnoreCase Or BindingFlags.SetProperty, Nothing, o, taba)

        't.InvokeMember("Montre", BindingFlags.Default Or BindingFlags.InvokeMethod, Nothing, o, tabo)
        't.InvokeMember("Montre", BindingFlags.DeclaredOnly Or BindingFlags.Public Or BindingFlags.NonPublic Or BindingFlags.Instance Or BindingFlags.InvokeMethod Or BindingFlags.IgnoreCase, Nothing, o, New [Object]() {0})

    End Sub

    Protected Sub MenuItem4_Click(sender As Object, e As EventArgs) Handles MenuItem4.Click
        Close()
    End Sub

    Public Sub MDIHello()
        ' Quelques essais de UInt non pris en charge par le VB...
        Dim ui1, ui2 As UInt32
        ui1 = 32000
        ui2 = 10 * ui1

        MessageBox.Show("Coucou de MDIMain.MDIHello " & ui2.ToString())
    End Sub

End Class