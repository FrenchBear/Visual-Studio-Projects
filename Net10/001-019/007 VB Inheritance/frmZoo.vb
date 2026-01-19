' 2001 PV
'
' 2006-10-01    PV VS2005
' 2012-02-25	PV VS2010
' 2021-09-17 	PV		VS2022/Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9
' 2026-01-19	PV		Net10
Imports System.Windows.Forms

#Disable Warning IDE1006 ' Naming Styles
#Disable Warning IDE0052 ' Remove unread private members

Public Class frmZoo
    Inherits Form

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
    Private ReadOnly components As System.ComponentModel.Container

    Private WithEvents TextBox1 As TextBox
    Private WithEvents BtnTypeName As Button
    Private WithEvents CheckBox1 As CheckBox
    Private WithEvents TabPage2 As TabPage
    Private WithEvents TabPage1 As TabPage
    Private WithEvents TabControl1 As TabControl

    Private WithEvents LblChat As Label
    Private WithEvents LblChien As Label
    Private WithEvents TxtChat As TextBox
    Private WithEvents TxtChien As TextBox
    Private WithEvents Button1 As Button

    Public WithEvents Form1 As Form

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        LblChat = New Label()
        TabPage2 = New TabPage()
        TextBox1 = New TextBox()
        BtnTypeName = New Button()
        LblChien = New Label()
        TabControl1 = New TabControl()
        TabPage1 = New TabPage()
        CheckBox1 = New CheckBox()
        TxtChat = New TextBox()
        Button1 = New Button()
        TxtChien = New TextBox()
        TabPage2.SuspendLayout()
        TabControl1.SuspendLayout()
        TabPage1.SuspendLayout()
        SuspendLayout()
        '
        'lblChat
        '
        LblChat.AutoSize = True
        LblChat.Location = New Drawing.Point(40, 56)
        LblChat.Name = "lblChat"
        LblChat.Size = New Drawing.Size(38, 13)
        LblChat.TabIndex = 4
        LblChat.Text = "Label2"
        LblChat.Visible = False
        '
        'TabPage2
        '
        TabPage2.Controls.AddRange(New Control() {TextBox1, BtnTypeName})
        TabPage2.Location = New Drawing.Point(4, 22)
        TabPage2.Name = "TabPage2"
        TabPage2.Size = New Drawing.Size(276, 122)
        TabPage2.TabIndex = 1
        TabPage2.Text = "TabPage2"
        '
        'TextBox1
        '
        TextBox1.Anchor = AnchorStyles.Top Or AnchorStyles.Left _
                    Or AnchorStyles.Right
        TextBox1.Location = New Drawing.Point(8, 20)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Drawing.Size(152, 20)
        TextBox1.TabIndex = 1
        TextBox1.Text = "TextBox1"
        '
        'btnTypeName
        '
        BtnTypeName.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        BtnTypeName.Location = New Drawing.Point(168, 16)
        BtnTypeName.Name = "btnTypeName"
        BtnTypeName.Size = New Drawing.Size(92, 24)
        BtnTypeName.TabIndex = 0
        BtnTypeName.Text = "TypeName"
        '
        'lblChien
        '
        LblChien.AutoSize = True
        LblChien.Location = New Drawing.Point(40, 24)
        LblChien.Name = "lblChien"
        LblChien.Size = New Drawing.Size(40, 13)
        LblChien.TabIndex = 3
        LblChien.Text = "Chien :"
        '
        'TabControl1
        '
        TabControl1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom _
                    Or AnchorStyles.Left _
                    Or AnchorStyles.Right
        TabControl1.Controls.AddRange(New Control() {TabPage1, TabPage2})
        TabControl1.Location = New Drawing.Point(4, 120)
        TabControl1.Name = "TabControl1"
        TabControl1.SelectedIndex = 0
        TabControl1.Size = New Drawing.Size(284, 148)
        TabControl1.TabIndex = 5
        '
        'TabPage1
        '
        TabPage1.Controls.AddRange(New Control() {CheckBox1})
        TabPage1.Location = New Drawing.Point(4, 22)
        TabPage1.Name = "TabPage1"
        TabPage1.Size = New Drawing.Size(276, 122)
        TabPage1.TabIndex = 0
        TabPage1.Text = "TabPage1"
        '
        'CheckBox1
        '
        CheckBox1.Location = New Drawing.Point(12, 12)
        CheckBox1.Name = "CheckBox1"
        CheckBox1.Size = New Drawing.Size(132, 20)
        CheckBox1.TabIndex = 0
        CheckBox1.Text = "CheckBox1"
        '
        'txtChat
        '
        TxtChat.Location = New Drawing.Point(88, 48)
        TxtChat.Name = "txtChat"
        TxtChat.TabIndex = 2
        TxtChat.Text = "Félix"
        '
        'Button1
        '
        Button1.Location = New Drawing.Point(92, 84)
        Button1.Name = "Button1"
        Button1.TabIndex = 0
        Button1.Text = "Excite"
        '
        'txtChien
        '
        TxtChien.Location = New Drawing.Point(88, 16)
        TxtChien.Name = "txtChien"
        TxtChien.TabIndex = 1
        TxtChien.Text = "Rex"
        '
        'frmZoo
        '
        AutoScaleBaseSize = New Drawing.Size(5, 13)
        ClientSize = New Drawing.Size(292, 273)
        Controls.AddRange(New Control() {TabControl1, LblChat, LblChien, TxtChat, TxtChien, Button1})
        Name = "frmZoo"
        Text = "Zoo"
        TabPage2.ResumeLayout(False)
        TabControl1.ResumeLayout(False)
        TabPage1.ResumeLayout(False)
        ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnTypeName_Click_1(sender As Object, e As EventArgs) Handles BtnTypeName.Click
        Dim i As Integer
        MsgBox("TypeName: " & TypeName(i))
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Dim Rex As New Chien(TxtChien.Text)
        Dim Fluffy As New Chiot("Fluffy")
        Dim Félix As New Chat(TxtChat.Text)
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
