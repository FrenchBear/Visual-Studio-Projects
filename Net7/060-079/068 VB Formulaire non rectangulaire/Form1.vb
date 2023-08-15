' 2006-10-01 	PV		VS2005
' 2012-02-25	PV		VS2010
' 2021-09-19 	PV		VS2022, Net6
' 2023-01-10	PV		Net7
Imports System.ComponentModel

#Disable Warning IDE1006 ' Naming Styles


Public Class Form1
    Inherits Form

    Private mouse_offset As Point

#Region " Code généré par le Concepteur Windows Form "

    Public Sub New()
        MyBase.New()

        'Cet appel est requis par le Concepteur Windows Form.
        InitializeComponent()

        'Ajoutez une initialisation quelconque après l'appel InitializeComponent()

    End Sub

    'La méthode substituée Dispose du formulaire pour nettoyer la liste des composants.
    Protected Overloads Overrides Sub Dispose(disposing As Boolean)
        If disposing Then
            components?.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requis par le Concepteur Windows Form
    Private ReadOnly components As IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée en utilisant le Concepteur Windows Form.
    'Ne la modifiez pas en utilisant l'éditeur de code.
    Friend WithEvents btnClose As Button

    <DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources = New ComponentResourceManager(GetType(Form1))
        Me.btnClose = New Button()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Font = New Font("Marlett", 12.0!, FontStyle.Bold, GraphicsUnit.Point)
        Me.btnClose.Location = New Point(634, 192)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New Size(43, 42)
        Me.btnClose.TabIndex = 0
        Me.btnClose.Text = "r"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New Size(9, 24)
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        Me.ClientSize = New Size(648, 512)
        Me.Controls.Add(Me.btnClose)
        Me.FormBorderStyle = FormBorderStyle.None
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.TransparencyKey = Color.White
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub Form1_MouseDown(sender As Object, e As MouseEventArgs) Handles MyBase.MouseDown
        mouse_offset = New Point(-e.X, -e.Y)
    End Sub

    Private Sub Form1_MouseMove(sender As Object, e As MouseEventArgs) Handles MyBase.MouseMove
        If e.Button = MouseButtons.Left Then
            Dim mousePos As Point = MousePosition
            mousePos.Offset(mouse_offset.X, mouse_offset.Y)
            Location = mousePos
        End If
    End Sub

End Class
