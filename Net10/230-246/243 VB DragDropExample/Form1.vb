' 243 VB DragDropExample
'
' 2012-02-25	PV		VS2010
' 2021-09-20 	PV		VS2022; Net6
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

    'Required by the Windows Form Designer
    Private ReadOnly components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    Friend WithEvents pb As PictureBox

    <DebuggerStepThrough()> Private Sub InitializeComponent()
        pb = New PictureBox
        CType(pb, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        '
        'pb
        '
        pb.BackColor = Color.Turquoise
        pb.Location = New Point(42, 22)
        pb.Name = "pb"
        pb.Size = New Size(210, 201)
        pb.TabIndex = 0
        pb.TabStop = False
        '
        'Form1
        '
        AutoScaleBaseSize = New Size(5, 13)
        ClientSize = New Size(292, 266)
        Controls.Add(pb)
        Name = "Form1"
        Text = "Form1"
        CType(pb, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)

    End Sub

#End Region

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Move
        End If
    End Sub

    Private Sub pb_Click(sender As Object, e As EventArgs) Handles pb.Click

    End Sub

End Class
