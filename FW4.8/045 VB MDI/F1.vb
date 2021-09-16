' 2001 PV
' 2006-10-01    PV  VS2005
' 2012-02-25	PV  VS2010

#Disable Warning IDE0052 ' Remove unread private members

Public Class F1
    Inherits Form

    Public Sub New()
        MyBase.New

        F1 = Me

        'This call is required by the Win Form Designer.
        InitializeComponent()

        'TODO: Add any initialization after the InitializeComponent() call
    End Sub

#Region " Windows Form Designer generated code "

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container

    Dim WithEvents F1 As Form

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Me.components = New ComponentModel.Container()
        '@design Me.TrayHeight = 0
        '@design Me.TrayLargeIcon = False
        '@design Me.TrayAutoArrange = True
        Me.Text = "F1"
        Me.AutoScaleBaseSize = New Size(5, 13)
        Me.ClientSize = New Size(228, 209)

    End Sub

#End Region

End Class