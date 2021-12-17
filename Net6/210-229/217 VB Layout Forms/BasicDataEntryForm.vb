' 217 VB Layout Forms
'
' 2012-02-25	PV  VS2010
' 2021-09-19    PV  VS2022; Net6

#Disable Warning IDE1006 ' Naming Styles

' This form demonstrates how to build a form layout that adjusts well
' when the user resizes the form. It also demonstrates a layout that
' responds well to localization.
Class BasicDataEntryForm
    Inherits Form

    Public Sub New()
        InitializeComponent()
    End Sub

    Private ReadOnly components As System.ComponentModel.IContainer = Nothing

    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing AndAlso Not (components Is Nothing) Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    Public Overrides Function ToString() As String
        Return "Basic Data Entry Form"
    End Function

    Private Sub okBtn_Click(sender As Object, e As EventArgs) Handles okBtn.Click
        Me.Close()
    End Sub

    Private Sub cancelBtn_Click(sender As Object, e As EventArgs) Handles cancelBtn.Click
        Me.Close()
    End Sub

    Private Sub InitializeComponent()
        Me.tableLayoutPanel1 = New TableLayoutPanel
        Me.label1 = New Label
        Me.label2 = New Label
        Me.label3 = New Label
        Me.label4 = New Label
        Me.label5 = New Label
        Me.label6 = New Label
        Me.label9 = New Label
        Me.textBox2 = New TextBox
        Me.textBox3 = New TextBox
        Me.textBox4 = New TextBox
        Me.textBox5 = New TextBox
        Me.maskedTextBox1 = New MaskedTextBox
        Me.maskedTextBox2 = New MaskedTextBox
        Me.comboBox1 = New ComboBox
        Me.textBox1 = New TextBox
        Me.label7 = New Label
        Me.label8 = New Label
        Me.richTextBox1 = New RichTextBox
        Me.cancelBtn = New Button
        Me.okBtn = New Button
        Me.tableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tableLayoutPanel1
        '
        Me.tableLayoutPanel1.Anchor = CType((((AnchorStyles.Top Or AnchorStyles.Bottom) _
                    Or AnchorStyles.Left) _
                    Or AnchorStyles.Right), AnchorStyles)
        Me.tableLayoutPanel1.ColumnCount = 4
        Me.tableLayoutPanel1.ColumnStyles.Add(New ColumnStyle)
        Me.tableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50.0!))
        Me.tableLayoutPanel1.ColumnStyles.Add(New ColumnStyle)
        Me.tableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50.0!))
        Me.tableLayoutPanel1.Controls.Add(Me.label1, 0, 0)
        Me.tableLayoutPanel1.Controls.Add(Me.label2, 2, 0)
        Me.tableLayoutPanel1.Controls.Add(Me.label3, 0, 1)
        Me.tableLayoutPanel1.Controls.Add(Me.label4, 0, 2)
        Me.tableLayoutPanel1.Controls.Add(Me.label5, 0, 3)
        Me.tableLayoutPanel1.Controls.Add(Me.label6, 2, 3)
        Me.tableLayoutPanel1.Controls.Add(Me.label9, 2, 4)
        Me.tableLayoutPanel1.Controls.Add(Me.textBox2, 1, 1)
        Me.tableLayoutPanel1.Controls.Add(Me.textBox3, 1, 2)
        Me.tableLayoutPanel1.Controls.Add(Me.textBox4, 1, 3)
        Me.tableLayoutPanel1.Controls.Add(Me.textBox5, 3, 0)
        Me.tableLayoutPanel1.Controls.Add(Me.maskedTextBox1, 1, 4)
        Me.tableLayoutPanel1.Controls.Add(Me.maskedTextBox2, 3, 4)
        Me.tableLayoutPanel1.Controls.Add(Me.comboBox1, 3, 3)
        Me.tableLayoutPanel1.Controls.Add(Me.textBox1, 1, 0)
        Me.tableLayoutPanel1.Controls.Add(Me.label7, 0, 5)
        Me.tableLayoutPanel1.Controls.Add(Me.label8, 0, 4)
        Me.tableLayoutPanel1.Controls.Add(Me.richTextBox1, 1, 5)
        Me.tableLayoutPanel1.Location = New Point(13, 13)
        Me.tableLayoutPanel1.Name = "tableLayoutPanel1"
        Me.tableLayoutPanel1.RowCount = 6
        Me.tableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 28.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 28.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 28.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 28.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 28.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 80.0!))
        Me.tableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 20.0!))
        Me.tableLayoutPanel1.Size = New Size(631, 308)
        Me.tableLayoutPanel1.TabIndex = 0
        '
        'label1
        '
        Me.label1.Anchor = AnchorStyles.Right
        Me.label1.AutoSize = True
        Me.label1.Location = New Point(3, 7)
        Me.label1.Name = "label1"
        Me.label1.Size = New Size(59, 14)
        Me.label1.TabIndex = 20
        Me.label1.Text = "First Name"
        '
        'label2
        '
        Me.label2.Anchor = AnchorStyles.Right
        Me.label2.AutoSize = True
        Me.label2.Location = New Point(326, 7)
        Me.label2.Name = "label2"
        Me.label2.Size = New Size(59, 14)
        Me.label2.TabIndex = 21
        Me.label2.Text = "Last Name"
        '
        'label3
        '
        Me.label3.Anchor = AnchorStyles.Right
        Me.label3.AutoSize = True
        Me.label3.Location = New Point(10, 35)
        Me.label3.Name = "label3"
        Me.label3.Size = New Size(52, 14)
        Me.label3.TabIndex = 22
        Me.label3.Text = "Address1"
        '
        'label4
        '
        Me.label4.Anchor = AnchorStyles.Right
        Me.label4.AutoSize = True
        Me.label4.Location = New Point(7, 63)
        Me.label4.Name = "label4"
        Me.label4.Size = New Size(55, 14)
        Me.label4.TabIndex = 23
        Me.label4.Text = "Address 2"
        '
        'label5
        '
        Me.label5.Anchor = AnchorStyles.Right
        Me.label5.AutoSize = True
        Me.label5.Location = New Point(38, 91)
        Me.label5.Name = "label5"
        Me.label5.Size = New Size(24, 14)
        Me.label5.TabIndex = 24
        Me.label5.Text = "City"
        '
        'label6
        '
        Me.label6.Anchor = AnchorStyles.Right
        Me.label6.AutoSize = True
        Me.label6.Location = New Point(354, 91)
        Me.label6.Name = "label6"
        Me.label6.Size = New Size(31, 14)
        Me.label6.TabIndex = 25
        Me.label6.Text = "State"
        '
        'label9
        '
        Me.label9.Anchor = AnchorStyles.Right
        Me.label9.AutoSize = True
        Me.label9.Location = New Point(329, 119)
        Me.label9.Name = "label9"
        Me.label9.Size = New Size(56, 14)
        Me.label9.TabIndex = 33
        Me.label9.Text = "Phone (H)"
        '
        'textBox2
        '
        Me.textBox2.Anchor = CType((AnchorStyles.Left Or AnchorStyles.Right), AnchorStyles)
        Me.tableLayoutPanel1.SetColumnSpan(Me.textBox2, 3)
        Me.textBox2.Location = New Point(68, 32)
        Me.textBox2.Name = "textBox2"
        Me.textBox2.Size = New Size(560, 20)
        Me.textBox2.TabIndex = 2
        '
        'textBox3
        '
        Me.textBox3.Anchor = CType((AnchorStyles.Left Or AnchorStyles.Right), AnchorStyles)
        Me.tableLayoutPanel1.SetColumnSpan(Me.textBox3, 3)
        Me.textBox3.Location = New Point(68, 60)
        Me.textBox3.Name = "textBox3"
        Me.textBox3.Size = New Size(560, 20)
        Me.textBox3.TabIndex = 3
        '
        'textBox4
        '
        Me.textBox4.Anchor = CType((AnchorStyles.Left Or AnchorStyles.Right), AnchorStyles)
        Me.textBox4.Location = New Point(68, 88)
        Me.textBox4.Name = "textBox4"
        Me.textBox4.Size = New Size(252, 20)
        Me.textBox4.TabIndex = 4
        '
        'textBox5
        '
        Me.textBox5.Anchor = CType((AnchorStyles.Left Or AnchorStyles.Right), AnchorStyles)
        Me.textBox5.Location = New Point(391, 4)
        Me.textBox5.Name = "textBox5"
        Me.textBox5.Size = New Size(237, 20)
        Me.textBox5.TabIndex = 1
        '
        'maskedTextBox1
        '
        Me.maskedTextBox1.Anchor = AnchorStyles.Left
        Me.maskedTextBox1.Location = New Point(68, 116)
        Me.maskedTextBox1.Mask = "(999)000-0000"
        Me.maskedTextBox1.Name = "maskedTextBox1"
        Me.maskedTextBox1.TabIndex = 6
        '
        'maskedTextBox2
        '
        Me.maskedTextBox2.Anchor = AnchorStyles.Left
        Me.maskedTextBox2.Location = New Point(391, 116)
        Me.maskedTextBox2.Mask = "(999)000-0000"
        Me.maskedTextBox2.Name = "maskedTextBox2"
        Me.maskedTextBox2.TabIndex = 7
        '
        'comboBox1
        '
        Me.comboBox1.Anchor = AnchorStyles.Left
        Me.comboBox1.FormattingEnabled = True
        Me.comboBox1.Items.AddRange(New Object() {"AK - Alaska", "WA - Washington"})
        Me.comboBox1.Location = New Point(391, 87)
        Me.comboBox1.Name = "comboBox1"
        Me.comboBox1.Size = New Size(100, 21)
        Me.comboBox1.TabIndex = 5
        '
        'textBox1
        '
        Me.textBox1.Anchor = CType((AnchorStyles.Left Or AnchorStyles.Right), AnchorStyles)
        Me.textBox1.Location = New Point(68, 4)
        Me.textBox1.Name = "textBox1"
        Me.textBox1.Size = New Size(252, 20)
        Me.textBox1.TabIndex = 0
        '
        'label7
        '
        Me.label7.Anchor = CType((AnchorStyles.Top Or AnchorStyles.Right), AnchorStyles)
        Me.label7.AutoSize = True
        Me.label7.Location = New Point(28, 143)
        Me.label7.Name = "label7"
        Me.label7.Size = New Size(34, 14)
        Me.label7.TabIndex = 26
        Me.label7.Text = "Notes"
        '
        'label8
        '
        Me.label8.Anchor = AnchorStyles.Right
        Me.label8.AutoSize = True
        Me.label8.Location = New Point(4, 119)
        Me.label8.Name = "label8"
        Me.label8.Size = New Size(58, 14)
        Me.label8.TabIndex = 32
        Me.label8.Text = "Phone (W)"
        '
        'richTextBox1
        '
        Me.richTextBox1.BorderStyle = BorderStyle.None
        Me.tableLayoutPanel1.SetColumnSpan(Me.richTextBox1, 3)
        Me.richTextBox1.Dock = DockStyle.Fill
        Me.richTextBox1.Location = New Point(68, 143)
        Me.richTextBox1.Name = "richTextBox1"
        Me.richTextBox1.Size = New Size(560, 162)
        Me.richTextBox1.TabIndex = 8
        Me.richTextBox1.Text = ""
        '
        'cancelBtn
        '
        Me.cancelBtn.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Right), AnchorStyles)
        Me.cancelBtn.DialogResult = DialogResult.Cancel
        Me.cancelBtn.Location = New Point(566, 328)
        Me.cancelBtn.Name = "cancelBtn"
        Me.cancelBtn.TabIndex = 1
        Me.cancelBtn.Text = "Cancel"
        '
        'okBtn
        '
        Me.okBtn.Anchor = CType((AnchorStyles.Bottom Or AnchorStyles.Right), AnchorStyles)
        Me.okBtn.DialogResult = DialogResult.OK
        Me.okBtn.Location = New Point(484, 328)
        Me.okBtn.Name = "okBtn"
        Me.okBtn.TabIndex = 0
        Me.okBtn.Text = "OK"
        '
        'BasicDataEntryForm
        '
        Me.AutoScaleBaseSize = New Size(5, 13)
        Me.ClientSize = New Size(650, 360)
        Me.Controls.Add(Me.okBtn)
        Me.Controls.Add(Me.cancelBtn)
        Me.Controls.Add(Me.tableLayoutPanel1)
        Me.Name = "BasicDataEntryForm"
        Me.Padding = New Padding(9)
        Me.StartPosition = FormStartPosition.Manual
        Me.Text = "Basic Data Entry"
        Me.tableLayoutPanel1.ResumeLayout(False)
        Me.tableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents tableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents label1 As Label
    Friend WithEvents label2 As Label
    Friend WithEvents label3 As Label
    Friend WithEvents label4 As Label
    Friend WithEvents label5 As Label
    Friend WithEvents label6 As Label
    Friend WithEvents label7 As Label
    Friend WithEvents label8 As Label
    Friend WithEvents label9 As Label
    Friend WithEvents cancelBtn As Button
    Friend WithEvents okBtn As Button
    Friend WithEvents textBox1 As TextBox
    Friend WithEvents textBox2 As TextBox
    Friend WithEvents textBox3 As TextBox
    Friend WithEvents textBox4 As TextBox
    Friend WithEvents textBox5 As TextBox
    Friend WithEvents maskedTextBox1 As MaskedTextBox
    Friend WithEvents maskedTextBox2 As MaskedTextBox
    Friend WithEvents comboBox1 As ComboBox
    Friend WithEvents richTextBox1 As RichTextBox
End Class