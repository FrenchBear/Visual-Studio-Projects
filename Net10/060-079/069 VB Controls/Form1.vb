' 069 VB Controls
'
' 2006-10-01 	PV		VS2005
' 2012-02-25	PV		VS2010
' 2021-09-19 	PV		VS2022, Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9
' 2026-01-19	PV		Net10
Imports System.ComponentModel

Public Class Form1
    Inherits Form

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
    Friend WithEvents Label1 As Label

    Friend WithEvents SaisieNum1 As NumericTextBox

    <DebuggerStepThrough()> Private Sub InitializeComponent()
        SaisieNum1 = New NumericTextBox()
        Label1 = New Label()
        SuspendLayout()
        '
        'SaisieNum1
        '
        SaisieNum1.Location = New Point(27, 61)
        SaisieNum1.Name = "SaisieNum1"
        SaisieNum1.Size = New Size(100, 20)
        SaisieNum1.TabIndex = 1
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.Location = New Point(24, 45)
        Label1.Name = "Label1"
        Label1.Size = New Size(137, 13)
        Label1.TabIndex = 2
        Label1.Text = "This box only accepts digits"
        '
        'Form1
        '
        AutoScaleBaseSize = New Size(5, 13)
        ClientSize = New Size(292, 266)
        Controls.Add(Label1)
        Controls.Add(SaisieNum1)
        Name = "Form1"
        Text = "069 VB Controls"
        ResumeLayout(False)
        PerformLayout()

    End Sub

#End Region

End Class

Public Class NumericTextBox
    Inherits TextBox

    Protected Overrides Sub OnKeyPress(e As KeyPressEventArgs)
        e.Handled = Not Char.IsDigit(e.KeyChar)
    End Sub

End Class
