Public Partial Class frmMain
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()> _
    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

    End Sub

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnClients = New System.Windows.Forms.Button
        Me.btnArticles = New System.Windows.Forms.Button
        Me.btnClients2 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'btnClients
        '
        Me.btnClients.Location = New System.Drawing.Point(13, 13)
        Me.btnClients.Name = "btnClients"
        Me.btnClients.TabIndex = 0
        Me.btnClients.Text = "Clients"
        '
        'btnArticles
        '
        Me.btnArticles.Location = New System.Drawing.Point(13, 43)
        Me.btnArticles.Name = "btnArticles"
        Me.btnArticles.TabIndex = 1
        Me.btnArticles.Text = "Articles"
        '
        'btnClients2
        '
        Me.btnClients2.Location = New System.Drawing.Point(95, 13)
        Me.btnClients2.Name = "btnClients2"
        Me.btnClients2.TabIndex = 2
        Me.btnClients2.Text = "Clients2"
        '
        'frmMain
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(292, 266)
        Me.Controls.Add(Me.btnClients2)
        Me.Controls.Add(Me.btnArticles)
        Me.Controls.Add(Me.btnClients)
        Me.Name = "frmMain"
        Me.Text = "frmMain"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnClients As System.Windows.Forms.Button
    Friend WithEvents btnArticles As System.Windows.Forms.Button
    Friend WithEvents btnClients2 As System.Windows.Forms.Button
End Class
