' 19 VB Forms
' Essai de création manuel d'une feuille par création de MyForm qui hérite de Form
'
' 2001-01-18    PV
' 2001-01-27 	PV		Evénements, trois manières d'enregistrer
' 2001-08-15 	PV		Beta2, fin de la prise en charge d'élénements automatique sur le nom (ex: button1_click)
' 2006-10-01 	PV		VS2005
' 2012-02-25	PV		VS2010
' 2021-09-17 	PV		VS2022/Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9

Imports System.Drawing
Imports System.Windows.Forms

#Disable Warning IDE1006 ' Naming Styles

Public Class MyForm
    Inherits Form

    Private WithEvents button1 As Button
    Private WithEvents button2 As Button

    ' Constructeur de la classe
    Public Sub New()
        MyBase.New()

        Text = "Titre de la fenêtre"
        AutoScaleBaseSize = New Size(5, 13)
        ClientSize = New Size(400, 150)

        button1 = New Button With {
            .Location = New Point(100, 64),
            .Size = New Size(90, 40),
            .TabIndex = 2,
            .Text = "Bouton 1"
        }
        Controls.Add(button1)

        button2 = New Button With {
            .Location = New Point(200, 64),
            .Size = New Size(90, 40),
            .TabIndex = 2,
            .Text = "Bouton 2"
        }
        Controls.Add(button2)
    End Sub

    Private Sub Button1_Click(sender As Object, evArgs As EventArgs) Handles button1.Click
        'Disable button1 - we only want to add one button
        button1.Enabled = False

        'Add the new button and add an event handler using AddHandler
        Dim newButton As New Button()
        newButton = New Button With {
            .Location = New Point(300, 64),
            .Size = New Size(90, 40),
            .TabIndex = 4,
            .Text = "Bouton 3"
        }
        Controls.Add(newButton)

        AddHandler newButton.Click, AddressOf clickNewbutton
    End Sub

    'The event handling method for button2 - registered using Handles
    Private Sub OnButton2Click(sender As Object, evArgs As EventArgs) Handles button2.Click
        MessageBox.Show("Hello de Bouton 2")
    End Sub

    'The event handling method for the new button -  registered using AddHandler
    Private Sub clickNewbutton(sender As Object, evArgs As EventArgs)
        MessageBox.Show("Hello de Bouton 3")
    End Sub

    ' Point d'entrée de l'appli
    Public Shared Sub Main()
        Application.Run(New MyForm())
    End Sub

End Class
