' 243 VB DragDropExample
' 2012-02-25	PV  VS2010

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
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private ReadOnly components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    Friend WithEvents pb As PictureBox

    <DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.pb = New PictureBox
        CType(Me.pb, ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pb
        '
        Me.pb.BackColor = System.Drawing.Color.Turquoise
        Me.pb.Location = New Point(42, 22)
        Me.pb.Name = "pb"
        Me.pb.Size = New Size(210, 201)
        Me.pb.TabIndex = 0
        Me.pb.TabStop = False
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New Size(5, 13)
        Me.ClientSize = New Size(292, 266)
        Me.Controls.Add(Me.pb)
        Me.Name = "Form1"
        Me.Text = "Form1"
        CType(Me.pb, ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Form1_Load(sender As System.Object, e As EventArgs) Handles MyBase.Load
        pb.AllowDrop = True
    End Sub

    Private Sub pb_DragDrop(sender As Object, e As DragEventArgs) Handles pb.DragDrop
        Try
            pb.Image = Image.FromFile(CType(e.Data.GetData(DataFormats.FileDrop), Array).GetValue(0).ToString)
        Catch ex As Exception
            MessageBox.Show("Error Doing Drag/Drop")
        End Try
    End Sub

    Private Sub pb_DragEnter(sender As Object, e As DragEventArgs) Handles pb.DragEnter
        If (e.Data.GetDataPresent(DataFormats.FileDrop)) Then
            e.Effect = DragDropEffects.Move
        End If
    End Sub

    Private Sub pb_Click(sender As System.Object, e As EventArgs) Handles pb.Click

    End Sub

End Class