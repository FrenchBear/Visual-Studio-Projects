' 217 VB Layout Forms
'
' 2012-02-25	PV		VS2010
' 2021-09-19 	PV		VS2022; Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9
Imports System.ComponentModel

#Disable Warning IDE1006 ' Naming Styles

' This form demonstrates how to build a form layout that adjusts well
' when the user resizes the form. It also demonstrates a layout that
' responds well to localization.
Friend Class BasicDataEntryForm
    Inherits Form

    Public Sub New()
        InitializeComponent()
    End Sub

    Private ReadOnly components As IContainer = Nothing

    Protected Overrides Sub Dispose(disposing As Boolean)
        If disposing AndAlso Not components Is Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    Public Overrides Function ToString() As String
        Return "Basic Data Entry Form"
    End Function

    Private Sub okBtn_Click(sender As Object, e As EventArgs) Handles okBtn.Click
        Close()
    End Sub

    Private Sub cancelBtn_Click(sender As Object, e As EventArgs) Handles cancelBtn.Click
        Close()
    End Sub

    Private Sub InitializeComponent()
        tableLayoutPanel1 = New TableLayoutPanel
        label1 = New Label
        label2 = New Label
        label3 = New Label
        label4 = New Label
        label5 = New Label
        label6 = New Label
        label9 = New Label
        textBox2 = New TextBox
        textBox3 = New TextBox
        textBox4 = New TextBox
        textBox5 = New TextBox
        maskedTextBox1 = New MaskedTextBox
        maskedTextBox2 = New MaskedTextBox
        comboBox1 = New ComboBox
        textBox1 = New TextBox
        label7 = New Label
        label8 = New Label
        richTextBox1 = New RichTextBox
        cancelBtn = New Button
        okBtn = New Button
        tableLayoutPanel1.SuspendLayout()
        SuspendLayout()
        '
        'tableLayoutPanel1
        '
        tableLayoutPanel1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom _
                    Or AnchorStyles.Left _
                    Or AnchorStyles.Right
        tableLayoutPanel1.ColumnCount = 4
        tableLayoutPanel1.ColumnStyles.Add(New ColumnStyle)
        tableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50.0!))
        tableLayoutPanel1.ColumnStyles.Add(New ColumnStyle)
        tableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 50.0!))
        tableLayoutPanel1.Controls.Add(label1, 0, 0)
        tableLayoutPanel1.Controls.Add(label2, 2, 0)
        tableLayoutPanel1.Controls.Add(label3, 0, 1)
        tableLayoutPanel1.Controls.Add(label4, 0, 2)
        tableLayoutPanel1.Controls.Add(label5, 0, 3)
        tableLayoutPanel1.Controls.Add(label6, 2, 3)
        tableLayoutPanel1.Controls.Add(label9, 2, 4)
        tableLayoutPanel1.Controls.Add(textBox2, 1, 1)
        tableLayoutPanel1.Controls.Add(textBox3, 1, 2)
        tableLayoutPanel1.Controls.Add(textBox4, 1, 3)
        tableLayoutPanel1.Controls.Add(textBox5, 3, 0)
        tableLayoutPanel1.Controls.Add(maskedTextBox1, 1, 4)
        tableLayoutPanel1.Controls.Add(maskedTextBox2, 3, 4)
        tableLayoutPanel1.Controls.Add(comboBox1, 3, 3)
        tableLayoutPanel1.Controls.Add(textBox1, 1, 0)
        tableLayoutPanel1.Controls.Add(label7, 0, 5)
        tableLayoutPanel1.Controls.Add(label8, 0, 4)
        tableLayoutPanel1.Controls.Add(richTextBox1, 1, 5)
        tableLayoutPanel1.Location = New Point(13, 13)
        tableLayoutPanel1.Name = "tableLayoutPanel1"
        tableLayoutPanel1.RowCount = 6
        tableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 28.0!))
        tableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 28.0!))
        tableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 28.0!))
        tableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 28.0!))
        tableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 28.0!))
        tableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 80.0!))
        tableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Absolute, 20.0!))
        tableLayoutPanel1.Size = New Size(631, 308)
        tableLayoutPanel1.TabIndex = 0
        '
        'label1
        '
        label1.Anchor = AnchorStyles.Right
        label1.AutoSize = True
        label1.Location = New Point(3, 7)
        label1.Name = "label1"
        label1.Size = New Size(59, 14)
        label1.TabIndex = 20
        label1.Text = "First Name"
        '
        'label2
        '
        label2.Anchor = AnchorStyles.Right
        label2.AutoSize = True
        label2.Location = New Point(326, 7)
        label2.Name = "label2"
        label2.Size = New Size(59, 14)
        label2.TabIndex = 21
        label2.Text = "Last Name"
        '
        'label3
        '
        label3.Anchor = AnchorStyles.Right
        label3.AutoSize = True
        label3.Location = New Point(10, 35)
        label3.Name = "label3"
        label3.Size = New Size(52, 14)
        label3.TabIndex = 22
        label3.Text = "Address1"
        '
        'label4
        '
        label4.Anchor = AnchorStyles.Right
        label4.AutoSize = True
        label4.Location = New Point(7, 63)
        label4.Name = "label4"
        label4.Size = New Size(55, 14)
        label4.TabIndex = 23
        label4.Text = "Address 2"
        '
        'label5
        '
        label5.Anchor = AnchorStyles.Right
        label5.AutoSize = True
        label5.Location = New Point(38, 91)
        label5.Name = "label5"
        label5.Size = New Size(24, 14)
        label5.TabIndex = 24
        label5.Text = "City"
        '
        'label6
        '
        label6.Anchor = AnchorStyles.Right
        label6.AutoSize = True
        label6.Location = New Point(354, 91)
        label6.Name = "label6"
        label6.Size = New Size(31, 14)
        label6.TabIndex = 25
        label6.Text = "State"
        '
        'label9
        '
        label9.Anchor = AnchorStyles.Right
        label9.AutoSize = True
        label9.Location = New Point(329, 119)
        label9.Name = "label9"
        label9.Size = New Size(56, 14)
        label9.TabIndex = 33
        label9.Text = "Phone (H)"
        '
        'textBox2
        '
        textBox2.Anchor = AnchorStyles.Left Or AnchorStyles.Right
        tableLayoutPanel1.SetColumnSpan(textBox2, 3)
        textBox2.Location = New Point(68, 32)
        textBox2.Name = "textBox2"
        textBox2.Size = New Size(560, 20)
        textBox2.TabIndex = 2
        '
        'textBox3
        '
        textBox3.Anchor = AnchorStyles.Left Or AnchorStyles.Right
        tableLayoutPanel1.SetColumnSpan(textBox3, 3)
        textBox3.Location = New Point(68, 60)
        textBox3.Name = "textBox3"
        textBox3.Size = New Size(560, 20)
        textBox3.TabIndex = 3
        '
        'textBox4
        '
        textBox4.Anchor = AnchorStyles.Left Or AnchorStyles.Right
        textBox4.Location = New Point(68, 88)
        textBox4.Name = "textBox4"
        textBox4.Size = New Size(252, 20)
        textBox4.TabIndex = 4
        '
        'textBox5
        '
        textBox5.Anchor = AnchorStyles.Left Or AnchorStyles.Right
        textBox5.Location = New Point(391, 4)
        textBox5.Name = "textBox5"
        textBox5.Size = New Size(237, 20)
        textBox5.TabIndex = 1
        '
        'maskedTextBox1
        '
        maskedTextBox1.Anchor = AnchorStyles.Left
        maskedTextBox1.Location = New Point(68, 116)
        maskedTextBox1.Mask = "(999)000-0000"
        maskedTextBox1.Name = "maskedTextBox1"
        maskedTextBox1.TabIndex = 6
        '
        'maskedTextBox2
        '
        maskedTextBox2.Anchor = AnchorStyles.Left
        maskedTextBox2.Location = New Point(391, 116)
        maskedTextBox2.Mask = "(999)000-0000"
        maskedTextBox2.Name = "maskedTextBox2"
        maskedTextBox2.TabIndex = 7
        '
        'comboBox1
        '
        comboBox1.Anchor = AnchorStyles.Left
        comboBox1.FormattingEnabled = True
        comboBox1.Items.AddRange(New Object() {"AK - Alaska", "WA - Washington"})
        comboBox1.Location = New Point(391, 87)
        comboBox1.Name = "comboBox1"
        comboBox1.Size = New Size(100, 21)
        comboBox1.TabIndex = 5
        '
        'textBox1
        '
        textBox1.Anchor = AnchorStyles.Left Or AnchorStyles.Right
        textBox1.Location = New Point(68, 4)
        textBox1.Name = "textBox1"
        textBox1.Size = New Size(252, 20)
        textBox1.TabIndex = 0
        '
        'label7
        '
        label7.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        label7.AutoSize = True
        label7.Location = New Point(28, 143)
        label7.Name = "label7"
        label7.Size = New Size(34, 14)
        label7.TabIndex = 26
        label7.Text = "Notes"
        '
        'label8
        '
        label8.Anchor = AnchorStyles.Right
        label8.AutoSize = True
        label8.Location = New Point(4, 119)
        label8.Name = "label8"
        label8.Size = New Size(58, 14)
        label8.TabIndex = 32
        label8.Text = "Phone (W)"
        '
        'richTextBox1
        '
        richTextBox1.BorderStyle = BorderStyle.None
        tableLayoutPanel1.SetColumnSpan(richTextBox1, 3)
        richTextBox1.Dock = DockStyle.Fill
        richTextBox1.Location = New Point(68, 143)
        richTextBox1.Name = "richTextBox1"
        richTextBox1.Size = New Size(560, 162)
        richTextBox1.TabIndex = 8
        richTextBox1.Text = ""
        '
        'cancelBtn
        '
        cancelBtn.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        cancelBtn.DialogResult = DialogResult.Cancel
        cancelBtn.Location = New Point(566, 328)
        cancelBtn.Name = "cancelBtn"
        cancelBtn.TabIndex = 1
        cancelBtn.Text = "Cancel"
        '
        'okBtn
        '
        okBtn.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        okBtn.DialogResult = DialogResult.OK
        okBtn.Location = New Point(484, 328)
        okBtn.Name = "okBtn"
        okBtn.TabIndex = 0
        okBtn.Text = "OK"
        '
        'BasicDataEntryForm
        '
        AutoScaleBaseSize = New Size(5, 13)
        ClientSize = New Size(650, 360)
        Controls.Add(okBtn)
        Controls.Add(cancelBtn)
        Controls.Add(tableLayoutPanel1)
        Name = "BasicDataEntryForm"
        Padding = New Padding(9)
        StartPosition = FormStartPosition.Manual
        Text = "Basic Data Entry"
        tableLayoutPanel1.ResumeLayout(False)
        tableLayoutPanel1.PerformLayout()
        ResumeLayout(False)

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
