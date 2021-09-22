' 2001 PV
' 2006-10-01    PV VS2005
' 2012-02-25	PV VS2010
' 2021-09-17    PV  VS2022/Net6

#Disable Warning IDE1006 ' Naming Styles
#Disable Warning IDE0052 ' Remove unread private members

Public Class frmZoo
    Inherits Windows.Forms.Form

    Public Const vbCrLf As String = Chr(13) & Chr(10)

    Public Sub New()
        MyBase.New()
        Form1 = Me
        InitializeComponent()     'This call is required by the Win Form Designer.
    End Sub

    'Form overrides dispose to clean up the component list.
    Public Overloads Sub Dispose()
        MyBase.Dispose()
        components.Dispose()
    End Sub

#Region " Windows Form Designer generated code "

    'Required by the Windows Form Designer
    Private ReadOnly components As ComponentModel.Container

    Private WithEvents TextBox1 As Windows.Forms.TextBox
    Private WithEvents BtnTypeName As Windows.Forms.Button
    Private WithEvents CheckBox1 As Windows.Forms.CheckBox
    Private WithEvents TabPage2 As Windows.Forms.TabPage
    Private WithEvents TabPage1 As Windows.Forms.TabPage
    Private WithEvents TabControl1 As Windows.Forms.TabControl

    Private WithEvents LblChat As Windows.Forms.Label
    Private WithEvents LblChien As Windows.Forms.Label
    Private WithEvents TxtChat As Windows.Forms.TextBox
    Private WithEvents TxtChien As Windows.Forms.TextBox
    Private WithEvents Button1 As Windows.Forms.Button

    Dim WithEvents Form1 As Windows.Forms.Form

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Me.LblChat = New Windows.Forms.Label()
        Me.TabPage2 = New Windows.Forms.TabPage()
        Me.TextBox1 = New Windows.Forms.TextBox()
        Me.BtnTypeName = New Windows.Forms.Button()
        Me.LblChien = New Windows.Forms.Label()
        Me.TabControl1 = New Windows.Forms.TabControl()
        Me.TabPage1 = New Windows.Forms.TabPage()
        Me.CheckBox1 = New Windows.Forms.CheckBox()
        Me.TxtChat = New Windows.Forms.TextBox()
        Me.Button1 = New Windows.Forms.Button()
        Me.TxtChien = New Windows.Forms.TextBox()
        Me.TabPage2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblChat
        '
        Me.LblChat.AutoSize = True
        Me.LblChat.Location = New Drawing.Point(40, 56)
        Me.LblChat.Name = "lblChat"
        Me.LblChat.Size = New Drawing.Size(38, 13)
        Me.LblChat.TabIndex = 4
        Me.LblChat.Text = "Label2"
        Me.LblChat.Visible = False
        '
        'TabPage2
        '
        Me.TabPage2.Controls.AddRange(New Windows.Forms.Control() {Me.TextBox1, Me.BtnTypeName})
        Me.TabPage2.Location = New Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New Drawing.Size(276, 122)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "TabPage2"
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.TextBox1.Location = New Drawing.Point(8, 20)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New Drawing.Size(152, 20)
        Me.TextBox1.TabIndex = 1
        Me.TextBox1.Text = "TextBox1"
        '
        'btnTypeName
        '
        Me.BtnTypeName.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.BtnTypeName.Location = New Drawing.Point(168, 16)
        Me.BtnTypeName.Name = "btnTypeName"
        Me.BtnTypeName.Size = New Drawing.Size(92, 24)
        Me.BtnTypeName.TabIndex = 0
        Me.BtnTypeName.Text = "TypeName"
        '
        'lblChien
        '
        Me.LblChien.AutoSize = True
        Me.LblChien.Location = New Drawing.Point(40, 24)
        Me.LblChien.Name = "lblChien"
        Me.LblChien.Size = New Drawing.Size(40, 13)
        Me.LblChien.TabIndex = 3
        Me.LblChien.Text = "Chien :"
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.TabControl1.Controls.AddRange(New Windows.Forms.Control() {Me.TabPage1, Me.TabPage2})
        Me.TabControl1.Location = New Drawing.Point(4, 120)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New Drawing.Size(284, 148)
        Me.TabControl1.TabIndex = 5
        '
        'TabPage1
        '
        Me.TabPage1.Controls.AddRange(New Windows.Forms.Control() {Me.CheckBox1})
        Me.TabPage1.Location = New Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New Drawing.Size(276, 122)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "TabPage1"
        '
        'CheckBox1
        '
        Me.CheckBox1.Location = New Drawing.Point(12, 12)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New Drawing.Size(132, 20)
        Me.CheckBox1.TabIndex = 0
        Me.CheckBox1.Text = "CheckBox1"
        '
        'txtChat
        '
        Me.TxtChat.Location = New Drawing.Point(88, 48)
        Me.TxtChat.Name = "txtChat"
        Me.TxtChat.TabIndex = 2
        Me.TxtChat.Text = "Félix"
        '
        'Button1
        '
        Me.Button1.Location = New Drawing.Point(92, 84)
        Me.Button1.Name = "Button1"
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Excite"
        '
        'txtChien
        '
        Me.TxtChien.Location = New Drawing.Point(88, 16)
        Me.TxtChien.Name = "txtChien"
        Me.TxtChien.TabIndex = 1
        Me.TxtChien.Text = "Rex"
        '
        'frmZoo
        '
        Me.AutoScaleBaseSize = New Drawing.Size(5, 13)
        Me.ClientSize = New Drawing.Size(292, 273)
        Me.Controls.AddRange(New Windows.Forms.Control() {Me.TabControl1, Me.LblChat, Me.LblChien, Me.TxtChat, Me.TxtChien, Me.Button1})
        Me.Name = "frmZoo"
        Me.Text = "Zoo"
        Me.TabPage2.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnTypeName_Click_1(sender As System.Object, e As EventArgs) Handles BtnTypeName.Click
        Dim i As Integer
        MsgBox("TypeName: " & TypeName(i))
    End Sub

    Private Sub Button1_Click_1(sender As System.Object, e As EventArgs) Handles Button1.Click
        Dim Rex As New Chien(CStr(TxtChien.Text))
        Dim Fluffy As New Chiot("Fluffy")
        Dim Félix As New Chat(CStr(TxtChat.Text))
        Dim Pollux As Chien = Nothing

        TestClasse(Rex)
        TestClasse(Fluffy)
        TestClasse(Félix)
        TestClasse(Pollux)
    End Sub

    Private Shared Sub TestClasse(a As Animal)
        If IsNothing(a) Then
            MsgBox("TestClasse: pas une référence valide !")
        Else
            a.Cri()
        End If
    End Sub

End Class