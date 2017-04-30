' Essais d'effacement d'image pendant qu'elle est affich�e
' 2001-08-19    PV
' 2006-10-01    PV  VS2005
' 2012-02-25	PV  VS2010  Updated paths

Public Class Form1
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents btnKill As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnGC As System.Windows.Forms.Button

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.Container

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.btnKill = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnGC = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnLoad
        '
        Me.btnLoad.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnLoad.Location = New System.Drawing.Point(284, 12)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.TabIndex = 1
        Me.btnLoad.Text = "Load"
        '
        'PictureBox1
        '
        Me.PictureBox1.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(8, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(264, 246)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'btnKill
        '
        Me.btnKill.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnKill.Location = New System.Drawing.Point(284, 108)
        Me.btnKill.Name = "btnKill"
        Me.btnKill.TabIndex = 1
        Me.btnKill.Text = "Kill"
        '
        'btnClear
        '
        Me.btnClear.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnClear.Location = New System.Drawing.Point(284, 44)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.TabIndex = 1
        Me.btnClear.Text = "Clear"
        '
        'btnGC
        '
        Me.btnGC.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnGC.Location = New System.Drawing.Point(284, 76)
        Me.btnGC.Name = "btnGC"
        Me.btnGC.TabIndex = 1
        Me.btnGC.Text = "Collect"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(368, 265)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnGC, Me.btnClear, Me.btnKill, Me.btnLoad, Me.PictureBox1})
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Const sSoucePath As String = "C:\Pictures\Escher\BondOfUnion.jpg"
    Private Const sCopyPath As String = "C:\Temp\BondOfUnion.jpg"

    Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click
        Try
            FileCopy(sSoucePath, sCopyPath)
        Catch er As Exception
            MsgBox("�chec au FileCopy: " & er.Message & vbCrLf & er.StackTrace)
            Exit Sub
        End Try

        PictureBox1.Image = System.Drawing.Image.FromFile(sCopyPath)
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        PictureBox1.Image = Nothing
    End Sub

    Private Sub btnGC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGC.Click
        System.GC.Collect()
    End Sub

    Private Sub btnKill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKill.Click
        Try
            Kill(sCopyPath)
        Catch er As Exception
            MsgBox("�chec au Kill: " & er.Message & vbCrLf & er.StackTrace)
            Exit Sub
        End Try
    End Sub

End Class