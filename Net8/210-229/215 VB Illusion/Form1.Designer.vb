Imports System.ComponentModel

Partial Public Class Form1
    Inherits Form

    <DebuggerNonUserCode()>
    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        tbk1.Value = 100 * k1
        tbk2.Value = 100 * k2
    End Sub

    'Form overrides dispose to clean up the component list.
    <DebuggerNonUserCode()>
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.Pic = New PictureBox()
        Me.lblk2 = New Label()
        Me.TableLayoutPanel1 = New TableLayoutPanel()
        Me.lblk1 = New Label()
        Me.tbk2 = New TrackBar()
        Me.tbk1 = New TrackBar()
        CType(Me.Pic, ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.tbk2, ISupportInitialize).BeginInit()
        CType(Me.tbk1, ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Pic
        '
        Me.Pic.Anchor = CType((((AnchorStyles.Top Or AnchorStyles.Bottom) _
            Or AnchorStyles.Left) _
            Or AnchorStyles.Right), AnchorStyles)
        Me.Pic.BackgroundImageLayout = ImageLayout.None
        Me.Pic.Location = New Point(0, 83)
        Me.Pic.Margin = New Padding(3, 2, 3, 3)
        Me.Pic.Name = "Pic"
        Me.Pic.Size = New Size(468, 340)
        Me.Pic.TabIndex = 0
        Me.Pic.TabStop = False
        '
        'lblk2
        '
        Me.lblk2.AutoSize = True
        Me.lblk2.Location = New Point(237, 0)
        Me.lblk2.Name = "lblk2"
        Me.lblk2.Size = New Size(19, 13)
        Me.lblk2.TabIndex = 4
        Me.lblk2.Text = "k2"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.lblk1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.lblk2, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.tbk2, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.tbk1, 0, 1)
        Me.TableLayoutPanel1.Dock = DockStyle.Top
        Me.TableLayoutPanel1.Location = New Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New Size(468, 78)
        Me.TableLayoutPanel1.TabIndex = 5
        '
        'lblk1
        '
        Me.lblk1.AutoSize = True
        Me.lblk1.Location = New Point(3, 0)
        Me.lblk1.Name = "lblk1"
        Me.lblk1.Size = New Size(19, 13)
        Me.lblk1.TabIndex = 6
        Me.lblk1.Text = "k1"
        '
        'tbk2
        '
        Me.tbk2.Anchor = CType((AnchorStyles.Left Or AnchorStyles.Right), AnchorStyles)
        Me.tbk2.Location = New Point(234, 26)
        Me.tbk2.Margin = New Padding(0)
        Me.tbk2.Maximum = 100
        Me.tbk2.Name = "tbk2"
        Me.tbk2.Size = New Size(234, 45)
        Me.tbk2.TabIndex = 6
        '
        'tbk1
        '
        Me.tbk1.Anchor = CType((AnchorStyles.Left Or AnchorStyles.Right), AnchorStyles)
        Me.tbk1.Location = New Point(0, 26)
        Me.tbk1.Margin = New Padding(0, 0, 0, 1)
        Me.tbk1.Maximum = 100
        Me.tbk1.Name = "tbk1"
        Me.tbk1.Size = New Size(234, 45)
        Me.tbk1.TabIndex = 5
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New Size(5, 13)
        Me.ClientSize = New Size(468, 423)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.Pic)
        Me.Name = "Form1"
        Me.Text = "Illusion"
        CType(Me.Pic, ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        CType(Me.tbk2, ISupportInitialize).EndInit()
        CType(Me.tbk1, ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Pic As PictureBox
    Friend WithEvents lblk2 As Label
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents tbk1 As TrackBar
    Friend WithEvents tbk2 As TrackBar
    Friend WithEvents lblk1 As Label

End Class
