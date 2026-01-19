' Essais d'effacement d'image pendant qu'elle est affichée
'
' 2001-08-19    PV
' 2006-10-01 	PV		VS2005
' 2012-02-25	PV		VS2010  Updated paths
' 2021-09-19 	PV		VS2022, Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9
' 2026-01-19	PV		Net10

#Disable Warning IDE1006 ' Naming Styles

Public Class Form1
    Inherits Form

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
            components?.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents btnLoad As Button
    Friend WithEvents btnKill As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents btnGC As Button

    'Required by the Windows Form Designer
    Private ReadOnly components As System.ComponentModel.Container

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <DebuggerStepThrough()> Private Sub InitializeComponent()
        btnLoad = New Button()
        PictureBox1 = New PictureBox()
        btnKill = New Button()
        btnClear = New Button()
        btnGC = New Button()
        SuspendLayout()
        '
        'btnLoad
        '
        btnLoad.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnLoad.Location = New Point(284, 12)
        btnLoad.Name = "btnLoad"
        btnLoad.TabIndex = 1
        btnLoad.Text = "Load"
        '
        'PictureBox1
        '
        PictureBox1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom _
                    Or AnchorStyles.Left _
                    Or AnchorStyles.Right
        PictureBox1.BorderStyle = BorderStyle.FixedSingle
        PictureBox1.Location = New Point(8, 12)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(264, 246)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 0
        PictureBox1.TabStop = False
        '
        'btnKill
        '
        btnKill.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnKill.Location = New Point(284, 108)
        btnKill.Name = "btnKill"
        btnKill.TabIndex = 1
        btnKill.Text = "Kill"
        '
        'btnClear
        '
        btnClear.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnClear.Location = New Point(284, 44)
        btnClear.Name = "btnClear"
        btnClear.TabIndex = 1
        btnClear.Text = "Clear"
        '
        'btnGC
        '
        btnGC.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnGC.Location = New Point(284, 76)
        btnGC.Name = "btnGC"
        btnGC.TabIndex = 1
        btnGC.Text = "Collect"
        '
        'Form1
        '
        AutoScaleBaseSize = New Size(5, 13)
        ClientSize = New Size(368, 265)
        Controls.AddRange(New Control() {btnGC, btnClear, btnKill, btnLoad, PictureBox1})
        Name = "Form1"
        Text = "Form1"
        ResumeLayout(False)

    End Sub

#End Region

    Private Const sSoucePath As String = "C:\Pictures\Escher\BondOfUnion.jpg"
    Private Const sCopyPath As String = "C:\Temp\BondOfUnion.jpg"

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        Try
            FileCopy(sSoucePath, sCopyPath)
        Catch er As Exception
            MsgBox("Échec au FileCopy: " & er.Message & vbCrLf & er.StackTrace)
            Exit Sub
        End Try

        PictureBox1.Image = Image.FromFile(sCopyPath)
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        PictureBox1.Image = Nothing
    End Sub

    Private Sub btnGC_Click(sender As Object, e As EventArgs) Handles btnGC.Click
        GC.Collect()
    End Sub

    Private Sub btnKill_Click(sender As Object, e As EventArgs) Handles btnKill.Click
        Try
            Kill(sCopyPath)
        Catch er As Exception
            MsgBox("Échec au Kill: " & er.Message & vbCrLf & er.StackTrace)
            Exit Sub
        End Try
    End Sub

End Class
