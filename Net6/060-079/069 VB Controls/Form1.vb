' 069 VB Controls
' 2006-10-01    PV  VS2005
' 2012-02-25	PV  VS2010
' 2021-09-19    PV  VS2022, Net6
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
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
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
        Me.SaisieNum1 = New NumericTextBox()
        Me.Label1 = New Label()
        Me.SuspendLayout()
        '
        'SaisieNum1
        '
        Me.SaisieNum1.Location = New Point(27, 61)
        Me.SaisieNum1.Name = "SaisieNum1"
        Me.SaisieNum1.Size = New Size(100, 20)
        Me.SaisieNum1.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New Point(24, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New Size(137, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "This box only accepts digits"
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New Size(5, 13)
        Me.ClientSize = New Size(292, 266)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.SaisieNum1)
        Me.Name = "Form1"
        Me.Text = "069 VB Controls"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

End Class

Public Class NumericTextBox
    Inherits TextBox

    Protected Overrides Sub OnKeyPress(e As KeyPressEventArgs)
        If Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        Else
            e.Handled = False
        End If
    End Sub

End Class