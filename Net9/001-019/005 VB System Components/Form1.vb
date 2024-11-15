' 2001 PV
'
' 2006-10-01 	PV		VS2005
' 2012-02-25 	PV		VS2010
' 2021-09-17 	PV		VS2022/Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9

Imports System.Windows.Forms

#Disable Warning IDE1006 ' Naming Styles
#Disable Warning IDE0052 ' Remove unread private members

Public Class Form1
    Inherits Form

    Public Sub New()
        MyBase.New()

        Form1 = Me

        'This call is required by the Win Form Designer.
        InitializeComponent()

        'TODO: Add any initialization after the InitializeComponent() call
    End Sub

    ' Form overrides dispose to clean up the component list.
    Public Overloads Sub Dispose()
        MyBase.Dispose()
        components.Dispose()
    End Sub

#Region " Windows Form Designer generated code "

    'Required by the Windows Form Designer
    Private ReadOnly components As System.ComponentModel.Container

    Private WithEvents btnAperçu As Button

    Private WithEvents PrintPreviewDialog1 As PrintPreviewDialog

    Private WithEvents NumericUpDown1 As NumericUpDown

    Public WithEvents Form1 As Form

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Dim resources As New Resources.ResourceManager(GetType(Form1))
        NumericUpDown1 = New NumericUpDown()
        btnAperçu = New Button()
        PrintPreviewDialog1 = New PrintPreviewDialog()
        CType(NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        '
        'NumericUpDown1
        '
        NumericUpDown1.Location = New Drawing.Point(32, 12)
        NumericUpDown1.Name = "NumericUpDown1"
        NumericUpDown1.TabIndex = 0
        '
        'btnAperçu
        '
        btnAperçu.Location = New Drawing.Point(36, 52)
        btnAperçu.Name = "btnAperçu"
        btnAperçu.TabIndex = 2
        btnAperçu.Text = "Aperçu"
        '
        'PrintPreviewDialog1
        '
        PrintPreviewDialog1.AutoScrollMargin = New Drawing.Size(0, 0)
        PrintPreviewDialog1.AutoScrollMinSize = New Drawing.Size(0, 0)
        PrintPreviewDialog1.ClientSize = New Drawing.Size(792, 677)
        PrintPreviewDialog1.Enabled = True
        PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), Drawing.Icon)
        PrintPreviewDialog1.Location = New Drawing.Point(117, 7)
        PrintPreviewDialog1.MaximizeBox = False
        PrintPreviewDialog1.MaximumSize = New Drawing.Size(0, 0)
        PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        PrintPreviewDialog1.Opacity = 1
        PrintPreviewDialog1.TransparencyKey = Drawing.Color.Empty
        PrintPreviewDialog1.Visible = False
        '
        'Form1
        '
        AutoScaleBaseSize = New Drawing.Size(5, 13)
        ClientSize = New Drawing.Size(292, 273)
        Controls.AddRange(New Control() {btnAperçu, NumericUpDown1})
        Name = "Form1"
        Text = "Form1"
        CType(NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnAperçu_Click(sender As Object, e As EventArgs) Handles btnAperçu.Click
        PrintPreviewDialog1.ShowDialog()
    End Sub

End Class
