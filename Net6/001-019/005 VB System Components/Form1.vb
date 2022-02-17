' 2001 PV
' 2006-10-01    PV  VS2005
' 2012-02-25    PV  VS2010
' 2021-09-17    PV  VS2022/Net6
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

    Private WithEvents btnAperçu As Windows.Forms.Button

    Private WithEvents PrintPreviewDialog1 As Windows.Forms.PrintPreviewDialog

    Private WithEvents NumericUpDown1 As Windows.Forms.NumericUpDown

    Dim WithEvents Form1 As Windows.Forms.Form

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Dim resources As New Resources.ResourceManager(GetType(Form1))
        Me.NumericUpDown1 = New Windows.Forms.NumericUpDown()
        Me.btnAperçu = New Windows.Forms.Button()
        Me.PrintPreviewDialog1 = New Windows.Forms.PrintPreviewDialog()
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'NumericUpDown1
        '
        Me.NumericUpDown1.Location = New Drawing.Point(32, 12)
        Me.NumericUpDown1.Name = "NumericUpDown1"
        Me.NumericUpDown1.TabIndex = 0
        '
        'btnAperçu
        '
        Me.btnAperçu.Location = New Drawing.Point(36, 52)
        Me.btnAperçu.Name = "btnAperçu"
        Me.btnAperçu.TabIndex = 2
        Me.btnAperçu.Text = "Aperçu"
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New Drawing.Size(792, 677)
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), Drawing.Icon)
        Me.PrintPreviewDialog1.Location = New Drawing.Point(117, 7)
        Me.PrintPreviewDialog1.MaximizeBox = False
        Me.PrintPreviewDialog1.MaximumSize = New Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Opacity = 1
        Me.PrintPreviewDialog1.TransparencyKey = Drawing.Color.Empty
        Me.PrintPreviewDialog1.Visible = False
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New Drawing.Size(5, 13)
        Me.ClientSize = New Drawing.Size(292, 273)
        Me.Controls.AddRange(New Windows.Forms.Control() {Me.btnAperçu, Me.NumericUpDown1})
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.NumericUpDown1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnAperçu_Click(sender As Object, e As EventArgs) Handles btnAperçu.Click
        PrintPreviewDialog1.ShowDialog()
    End Sub

End Class