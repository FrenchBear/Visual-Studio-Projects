' 2001 PV
' 2006-10-01    PV  VS2005
' 2012-02-25	PV  VS2010

#Disable Warning IDE1006 ' Naming Styles
#Disable Warning IDE0052 ' Remove unread private members
#Disable Warning IDE0051 ' Remove unused private members

Public Class frmDocument2
    Inherits Windows.Forms.Form

    Public Sub New()
        MyBase.New()

        frmDocument2 = Me

        'This call is required by the Win Form Designer.
        InitializeComponent()

        'TODO: Add any initialization after the InitializeComponent() call
    End Sub

#Region " Windows Form Designer generated code "

    'Required by the Windows Form Designer
    Private ReadOnly components As ComponentModel.Container

    Private WithEvents MonthCalendar1 As Windows.Forms.MonthCalendar

    Dim WithEvents frmDocument2 As Windows.Forms.Form

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Me.MonthCalendar1 = New Windows.Forms.MonthCalendar
        Me.SuspendLayout()
        '
        'MonthCalendar1
        '
        Me.MonthCalendar1.Location = New Drawing.Point(0, 0)
        Me.MonthCalendar1.Name = "MonthCalendar1"
        Me.MonthCalendar1.TabIndex = 0
        '
        'frmDocument2
        '
        Me.AutoScaleBaseSize = New Drawing.Size(5, 13)
        Me.ClientSize = New Drawing.Size(200, 158)
        Me.Controls.Add(Me.MonthCalendar1)
        Me.MaximizeBox = False
        Me.Name = "frmDocument2"
        Me.Text = "Calendrier"
        Me.ResumeLayout(False)

    End Sub

#End Region

End Class