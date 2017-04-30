' 2001 PV
' 2006-10-01    PV  VS2005
' 2012-02-25	PV  VS2010

Imports System.Drawing
Imports System.Windows.Forms
'Imports System.ComponentModel

Public Class F3
    Inherits Form

    Public Sub New()
        MyBase.New()

        F3 = Me

        'This call is required by the Win Form Designer.
        InitializeComponent()

        'TODO: Add any initialization after the InitializeComponent() call
    End Sub


#Region " Windows Form Designer generated code "

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container
    Private WithEvents Button1 As Button

    Dim WithEvents F3 As Form

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Button1 = New Button()

        '@design Me.TrayHeight = 0
        '@design Me.TrayLargeIcon = False
        '@design Me.TrayAutoArrange = True
        Button1.Location = New System.Drawing.Point(52, 24)
        Button1.Size = New System.Drawing.Size(75, 23)
        Button1.TabIndex = 0
        Button1.Text = "Button1"
        Me.Text = "F3"
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(220, 197)

        Me.Controls.Add(Button1)
    End Sub

#End Region

    Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        Dim p As MDIMain
        p = CType(MdiParent, MDIMain)
        p.MDIHello()
    End Sub

    Public Sub Montre()
        Show()
    End Sub

    Public Overloads Property MdiParent() As Form
        Set(ByVal parent As Form)
            MyBase.MdiParent = parent
        End Set
        Get
            Return MyBase.MdiParent
        End Get
    End Property
End Class
