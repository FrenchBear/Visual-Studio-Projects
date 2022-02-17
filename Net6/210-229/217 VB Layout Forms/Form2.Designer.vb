Imports System.ComponentModel

Partial Public Class Form2
    Inherits Form

    <DebuggerNonUserCode()>
    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

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
        Me.Panel1 = New Panel
        Me.GroupBox1 = New GroupBox
        Me.FlowLayoutPanel1 = New FlowLayoutPanel
        Me.Button1 = New Button
        Me.Button2 = New Button
        Me.Button3 = New Button
        Me.Button4 = New Button
        Me.Button5 = New Button
        Me.Button6 = New Button
        Me.Button7 = New Button
        Me.Button8 = New Button
        Me.Button9 = New Button
        Me.Button10 = New Button
        Me.Button11 = New Button
        Me.Button12 = New Button
        Me.Button13 = New Button
        Me.Button14 = New Button
        Me.Button15 = New Button
        Me.Button16 = New Button
        Me.Button17 = New Button
        Me.Button18 = New Button
        Me.Button19 = New Button
        Me.Button20 = New Button
        Me.TextBox1 = New TextBox
        Me.TableLayoutPanel1 = New TableLayoutPanel
        Me.TableLayoutPanel2 = New TableLayoutPanel
        Me.TableLayoutPanel3 = New TableLayoutPanel
        Me.Button21 = New Button
        Me.Button22 = New Button
        Me.Button23 = New Button
        Me.Button24 = New Button
        Me.Button25 = New Button
        Me.Button26 = New Button
        Me.Button27 = New Button
        Me.Button28 = New Button
        Me.Button29 = New Button
        Me.Button30 = New Button
        Me.Panel1.SuspendLayout()
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Location = New Point(13, 13)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New Size(181, 97)
        Me.Panel1.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = Color.Salmon
        Me.GroupBox1.Location = New Point(19, 22)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New Size(141, 97)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "GroupBox1"
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Anchor = CType((((AnchorStyles.Top Or AnchorStyles.Bottom) _
                    Or AnchorStyles.Left) _
                    Or AnchorStyles.Right), AnchorStyles)
        Me.FlowLayoutPanel1.Controls.Add(Me.Button20)
        Me.FlowLayoutPanel1.Controls.Add(Me.Button19)
        Me.FlowLayoutPanel1.Controls.Add(Me.Button18)
        Me.FlowLayoutPanel1.Controls.Add(Me.Button17)
        Me.FlowLayoutPanel1.Controls.Add(Me.Button16)
        Me.FlowLayoutPanel1.Controls.Add(Me.Button15)
        Me.FlowLayoutPanel1.Controls.Add(Me.Button14)
        Me.FlowLayoutPanel1.Controls.Add(Me.Button13)
        Me.FlowLayoutPanel1.Controls.Add(Me.Button12)
        Me.FlowLayoutPanel1.Controls.Add(Me.Button11)
        Me.FlowLayoutPanel1.Controls.Add(Me.Button10)
        Me.FlowLayoutPanel1.Controls.Add(Me.Button9)
        Me.FlowLayoutPanel1.Controls.Add(Me.Button8)
        Me.FlowLayoutPanel1.Controls.Add(Me.Button7)
        Me.FlowLayoutPanel1.Controls.Add(Me.Button6)
        Me.FlowLayoutPanel1.Controls.Add(Me.Button5)
        Me.FlowLayoutPanel1.Controls.Add(Me.Button4)
        Me.FlowLayoutPanel1.Controls.Add(Me.Button3)
        Me.FlowLayoutPanel1.Controls.Add(Me.Button2)
        Me.FlowLayoutPanel1.Controls.Add(Me.Button1)
        Me.FlowLayoutPanel1.Controls.Add(Me.TextBox1)
        Me.FlowLayoutPanel1.Location = New Point(13, 117)
        Me.FlowLayoutPanel1.Margin = New Padding(0)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New Size(355, 137)
        Me.FlowLayoutPanel1.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Location = New Point(59, 75)
        Me.Button1.Margin = New Padding(0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New Size(59, 25)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Button1"
        '
        'Button2
        '
        Me.Button2.Location = New Point(0, 75)
        Me.Button2.Margin = New Padding(0)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New Size(59, 25)
        Me.Button2.TabIndex = 1
        Me.Button2.Text = "Button2"
        '
        'Button3
        '
        Me.Button3.Location = New Point(295, 50)
        Me.Button3.Margin = New Padding(0)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New Size(59, 25)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "Button3"
        '
        'Button4
        '
        Me.Button4.Location = New Point(236, 50)
        Me.Button4.Margin = New Padding(0)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New Size(59, 25)
        Me.Button4.TabIndex = 3
        Me.Button4.Text = "Button4"
        '
        'Button5
        '
        Me.Button5.Location = New Point(177, 50)
        Me.Button5.Margin = New Padding(0)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New Size(59, 25)
        Me.Button5.TabIndex = 4
        Me.Button5.Text = "Button5"
        '
        'Button6
        '
        Me.Button6.Location = New Point(118, 50)
        Me.Button6.Margin = New Padding(0)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New Size(59, 25)
        Me.Button6.TabIndex = 5
        Me.Button6.Text = "Button6"
        '
        'Button7
        '
        Me.Button7.Location = New Point(59, 50)
        Me.Button7.Margin = New Padding(0)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New Size(59, 25)
        Me.Button7.TabIndex = 6
        Me.Button7.Text = "Button7"
        '
        'Button8
        '
        Me.Button8.Location = New Point(0, 50)
        Me.Button8.Margin = New Padding(0)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New Size(59, 25)
        Me.Button8.TabIndex = 7
        Me.Button8.Text = "Button8"
        '
        'Button9
        '
        Me.Button9.Location = New Point(295, 25)
        Me.Button9.Margin = New Padding(0)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New Size(59, 25)
        Me.Button9.TabIndex = 8
        Me.Button9.Text = "Button9"
        '
        'Button10
        '
        Me.Button10.Location = New Point(236, 25)
        Me.Button10.Margin = New Padding(0)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New Size(59, 25)
        Me.Button10.TabIndex = 9
        Me.Button10.Text = "Button10"
        '
        'Button11
        '
        Me.Button11.Location = New Point(177, 25)
        Me.Button11.Margin = New Padding(0)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New Size(59, 25)
        Me.Button11.TabIndex = 10
        Me.Button11.Text = "Button11"
        '
        'Button12
        '
        Me.Button12.Location = New Point(118, 25)
        Me.Button12.Margin = New Padding(0)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New Size(59, 25)
        Me.Button12.TabIndex = 11
        Me.Button12.Text = "Button12"
        '
        'Button13
        '
        Me.Button13.Location = New Point(59, 25)
        Me.Button13.Margin = New Padding(0)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New Size(59, 25)
        Me.Button13.TabIndex = 12
        Me.Button13.Text = "Button13"
        '
        'Button14
        '
        Me.Button14.Location = New Point(0, 25)
        Me.Button14.Margin = New Padding(0)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New Size(59, 25)
        Me.Button14.TabIndex = 13
        Me.Button14.Text = "Button14"
        '
        'Button15
        '
        Me.Button15.Location = New Point(295, 0)
        Me.Button15.Margin = New Padding(0)
        Me.Button15.Name = "Button15"
        Me.Button15.Size = New Size(59, 25)
        Me.Button15.TabIndex = 14
        Me.Button15.Text = "Button15"
        '
        'Button16
        '
        Me.Button16.Location = New Point(236, 0)
        Me.Button16.Margin = New Padding(0)
        Me.Button16.Name = "Button16"
        Me.Button16.Size = New Size(59, 25)
        Me.Button16.TabIndex = 15
        Me.Button16.Text = "Button16"
        '
        'Button17
        '
        Me.Button17.Location = New Point(177, 0)
        Me.Button17.Margin = New Padding(0)
        Me.Button17.Name = "Button17"
        Me.Button17.Size = New Size(59, 25)
        Me.Button17.TabIndex = 16
        Me.Button17.Text = "Button17"
        '
        'Button18
        '
        Me.Button18.Location = New Point(118, 0)
        Me.Button18.Margin = New Padding(0)
        Me.Button18.Name = "Button18"
        Me.Button18.Size = New Size(59, 25)
        Me.Button18.TabIndex = 17
        Me.Button18.Text = "Button18"
        '
        'Button19
        '
        Me.Button19.Location = New Point(59, 0)
        Me.Button19.Margin = New Padding(0)
        Me.Button19.Name = "Button19"
        Me.Button19.Size = New Size(59, 25)
        Me.Button19.TabIndex = 18
        Me.Button19.Text = "Button19"
        '
        'Button20
        '
        Me.Button20.Location = New Point(0, 0)
        Me.Button20.Margin = New Padding(0)
        Me.Button20.Name = "Button20"
        Me.Button20.Size = New Size(59, 25)
        Me.Button20.TabIndex = 19
        Me.Button20.Text = "Button20"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New Point(121, 78)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New Size(56, 20)
        Me.TextBox1.TabIndex = 20
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType(((AnchorStyles.Bottom Or AnchorStyles.Left) _
                    Or AnchorStyles.Right), AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Button30, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Button29, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Button28, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.TableLayoutPanel2, 1, 0)
        Me.TableLayoutPanel1.Location = New Point(13, 269)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New Size(355, 210)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 2
        Me.TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.Button27, 1, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.Button26, 1, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.Button25, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.TableLayoutPanel3, 0, 1)
        Me.TableLayoutPanel2.Dock = DockStyle.Fill
        Me.TableLayoutPanel2.Location = New Point(177, 0)
        Me.TableLayoutPanel2.Margin = New Padding(0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 2
        Me.TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New RowStyle(SizeType.Percent, 50.0!))
        Me.TableLayoutPanel2.Size = New Size(178, 105)
        Me.TableLayoutPanel2.TabIndex = 4
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 2
        Me.TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 41.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.Button24, 1, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Button23, 0, 1)
        Me.TableLayoutPanel3.Controls.Add(Me.Button22, 1, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.Button21, 0, 0)
        Me.TableLayoutPanel3.Dock = DockStyle.Fill
        Me.TableLayoutPanel3.Location = New Point(0, 52)
        Me.TableLayoutPanel3.Margin = New Padding(0)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 2
        Me.TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New RowStyle(SizeType.Percent, 50.0!))
        Me.TableLayoutPanel3.Size = New Size(89, 53)
        Me.TableLayoutPanel3.TabIndex = 4
        '
        'Button21
        '
        Me.Button21.Dock = DockStyle.Fill
        Me.Button21.Location = New Point(0, 0)
        Me.Button21.Margin = New Padding(0)
        Me.Button21.Name = "Button21"
        Me.Button21.Size = New Size(44, 26)
        Me.Button21.TabIndex = 4
        Me.Button21.Text = "Button21"
        '
        'Button22
        '
        Me.Button22.Dock = DockStyle.Fill
        Me.Button22.Location = New Point(44, 0)
        Me.Button22.Margin = New Padding(0)
        Me.Button22.Name = "Button22"
        Me.Button22.Size = New Size(45, 26)
        Me.Button22.TabIndex = 5
        Me.Button22.Text = "Button22"
        '
        'Button23
        '
        Me.Button23.Dock = DockStyle.Fill
        Me.Button23.Location = New Point(0, 26)
        Me.Button23.Margin = New Padding(0)
        Me.Button23.Name = "Button23"
        Me.Button23.Size = New Size(44, 27)
        Me.Button23.TabIndex = 6
        Me.Button23.Text = "Button23"
        '
        'Button24
        '
        Me.Button24.Dock = DockStyle.Fill
        Me.Button24.Location = New Point(44, 26)
        Me.Button24.Margin = New Padding(0)
        Me.Button24.Name = "Button24"
        Me.Button24.Size = New Size(45, 27)
        Me.Button24.TabIndex = 7
        Me.Button24.Text = "Button24"
        '
        'Button25
        '
        Me.Button25.Dock = DockStyle.Fill
        Me.Button25.Location = New Point(0, 0)
        Me.Button25.Margin = New Padding(0)
        Me.Button25.Name = "Button25"
        Me.Button25.Size = New Size(89, 52)
        Me.Button25.TabIndex = 5
        Me.Button25.Text = "Button25"
        '
        'Button26
        '
        Me.Button26.Dock = DockStyle.Fill
        Me.Button26.Location = New Point(89, 0)
        Me.Button26.Margin = New Padding(0)
        Me.Button26.Name = "Button26"
        Me.Button26.Size = New Size(89, 52)
        Me.Button26.TabIndex = 6
        Me.Button26.Text = "Button26"
        '
        'Button27
        '
        Me.Button27.Dock = DockStyle.Fill
        Me.Button27.Location = New Point(89, 52)
        Me.Button27.Margin = New Padding(0)
        Me.Button27.Name = "Button27"
        Me.Button27.Size = New Size(89, 53)
        Me.Button27.TabIndex = 7
        Me.Button27.Text = "Button27"
        '
        'Button28
        '
        Me.Button28.Dock = DockStyle.Fill
        Me.Button28.Location = New Point(0, 0)
        Me.Button28.Margin = New Padding(0)
        Me.Button28.Name = "Button28"
        Me.Button28.Size = New Size(177, 105)
        Me.Button28.TabIndex = 5
        Me.Button28.Text = "Button28"
        '
        'Button29
        '
        Me.Button29.Dock = DockStyle.Fill
        Me.Button29.Location = New Point(0, 105)
        Me.Button29.Margin = New Padding(0)
        Me.Button29.Name = "Button29"
        Me.Button29.Size = New Size(177, 105)
        Me.Button29.TabIndex = 6
        Me.Button29.Text = "Button29"
        '
        'Button30
        '
        Me.Button30.Dock = DockStyle.Fill
        Me.Button30.Location = New Point(177, 105)
        Me.Button30.Margin = New Padding(0)
        Me.Button30.Name = "Button30"
        Me.Button30.Size = New Size(178, 105)
        Me.Button30.TabIndex = 7
        Me.Button30.Text = "Button30"
        '
        'Form2
        '
        Me.AutoScaleBaseSize = New Size(5, 13)
        Me.ClientSize = New Size(382, 502)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.FlowLayoutPanel1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Form2"
        Me.Text = "Form2"
        Me.Panel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.FlowLayoutPanel1.PerformLayout()
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents Button20 As Button
    Friend WithEvents Button19 As Button
    Friend WithEvents Button18 As Button
    Friend WithEvents Button17 As Button
    Friend WithEvents Button16 As Button
    Friend WithEvents Button15 As Button
    Friend WithEvents Button14 As Button
    Friend WithEvents Button13 As Button
    Friend WithEvents Button12 As Button
    Friend WithEvents Button11 As Button
    Friend WithEvents Button10 As Button
    Friend WithEvents Button9 As Button
    Friend WithEvents Button8 As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Button5 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents Button21 As Button
    Friend WithEvents Button30 As Button
    Friend WithEvents Button29 As Button
    Friend WithEvents Button28 As Button
    Friend WithEvents Button27 As Button
    Friend WithEvents Button26 As Button
    Friend WithEvents Button25 As Button
    Friend WithEvents Button24 As Button
    Friend WithEvents Button23 As Button
    Friend WithEvents Button22 As Button
End Class
