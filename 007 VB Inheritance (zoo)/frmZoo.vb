' 2001 PV
' 2006-10-01    PV VS2005
' 2012-02-25	PV VS2010

Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms


Public Class frmZoo
    Inherits System.Windows.Forms.Form

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
    Private components As System.ComponentModel.Container
    Private WithEvents TextBox1 As System.Windows.Forms.TextBox
    Private WithEvents btnTypeName As System.Windows.Forms.Button
    Private WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Private WithEvents TabPage2 As System.Windows.Forms.TabPage
    Private WithEvents TabPage1 As System.Windows.Forms.TabPage
    Private WithEvents TabControl1 As System.Windows.Forms.TabControl

    Private WithEvents lblChat As System.Windows.Forms.Label
    Private WithEvents lblChien As System.Windows.Forms.Label
    Private WithEvents txtChat As System.Windows.Forms.TextBox
    Private WithEvents txtChien As System.Windows.Forms.TextBox
    Private WithEvents Button1 As System.Windows.Forms.Button

    Dim WithEvents Form1 As System.Windows.Forms.Form

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Me.lblChat = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.btnTypeName = New System.Windows.Forms.Button()
        Me.lblChien = New System.Windows.Forms.Label()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.txtChat = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtChien = New System.Windows.Forms.TextBox()
        Me.TabPage2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblChat
        '
        Me.lblChat.AutoSize = True
        Me.lblChat.Location = New System.Drawing.Point(40, 56)
        Me.lblChat.Name = "lblChat"
        Me.lblChat.Size = New System.Drawing.Size(38, 13)
        Me.lblChat.TabIndex = 4
        Me.lblChat.Text = "Label2"
        Me.lblChat.Visible = False
        '
        'TabPage2
        '
        Me.TabPage2.Controls.AddRange(New System.Windows.Forms.Control() {Me.TextBox1, Me.btnTypeName})
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Size = New System.Drawing.Size(276, 122)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "TabPage2"
        '
        'TextBox1
        '
        Me.TextBox1.Anchor = ((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.TextBox1.Location = New System.Drawing.Point(8, 20)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(152, 20)
        Me.TextBox1.TabIndex = 1
        Me.TextBox1.Text = "TextBox1"
        '
        'btnTypeName
        '
        Me.btnTypeName.Anchor = (System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right)
        Me.btnTypeName.Location = New System.Drawing.Point(168, 16)
        Me.btnTypeName.Name = "btnTypeName"
        Me.btnTypeName.Size = New System.Drawing.Size(92, 24)
        Me.btnTypeName.TabIndex = 0
        Me.btnTypeName.Text = "TypeName"
        '
        'lblChien
        '
        Me.lblChien.AutoSize = True
        Me.lblChien.Location = New System.Drawing.Point(40, 24)
        Me.lblChien.Name = "lblChien"
        Me.lblChien.Size = New System.Drawing.Size(40, 13)
        Me.lblChien.TabIndex = 3
        Me.lblChien.Text = "Chien :"
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = (((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right)
        Me.TabControl1.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabPage1, Me.TabPage2})
        Me.TabControl1.Location = New System.Drawing.Point(4, 120)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(284, 148)
        Me.TabControl1.TabIndex = 5
        '
        'TabPage1
        '
        Me.TabPage1.Controls.AddRange(New System.Windows.Forms.Control() {Me.CheckBox1})
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Size = New System.Drawing.Size(276, 122)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "TabPage1"
        '
        'CheckBox1
        '
        Me.CheckBox1.Location = New System.Drawing.Point(12, 12)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(132, 20)
        Me.CheckBox1.TabIndex = 0
        Me.CheckBox1.Text = "CheckBox1"
        '
        'txtChat
        '
        Me.txtChat.Location = New System.Drawing.Point(88, 48)
        Me.txtChat.Name = "txtChat"
        Me.txtChat.TabIndex = 2
        Me.txtChat.Text = "Félix"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(92, 84)
        Me.Button1.Name = "Button1"
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Excite"
        '
        'txtChien
        '
        Me.txtChien.Location = New System.Drawing.Point(88, 16)
        Me.txtChien.Name = "txtChien"
        Me.txtChien.TabIndex = 1
        Me.txtChien.Text = "Rex"
        '
        'frmZoo
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(292, 273)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.TabControl1, Me.lblChat, Me.lblChien, Me.txtChat, Me.txtChien, Me.Button1})
        Me.Name = "frmZoo"
        Me.Text = "Zoo"
        Me.TabPage2.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnTypeName_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTypeName.Click
        Dim i As Integer
        MsgBox("TypeName: " & TypeName(i))
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim Rex As New Chien(CStr(txtChien.Text))
        Dim Fluffy As New Chiot("Fluffy")
        Dim Félix As New Chat(CStr(txtChat.Text))
        Dim Pollux As Chien = Nothing

        TestClasse(Rex)
        TestClasse(Fluffy)
        TestClasse(Félix)
        TestClasse(Pollux)
    End Sub

    Private Sub TestClasse(ByVal a As Animal)
        If IsNothing(a) Then
            MsgBox("TestClasse: pas une référence valide !")
        Else
            a.Cri()
        End If
    End Sub

End Class
