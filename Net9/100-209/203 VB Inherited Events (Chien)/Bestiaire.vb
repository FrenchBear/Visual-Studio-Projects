﻿' 2021-09-19 	PV		VS2022; Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9

#Disable Warning CA1822 ' Mark members as static
#Disable Warning CA1859 ' Use concrete types when possible for improved performance

Friend Module MainModule
    Private WithEvents Rex As Chien

    Public Sub Main()
        Rex = New Chien("Médor")
        Rex.Exciter()
        Rex.Enerver()
        Rex = Nothing

        Dim mChiens As New Meute(Of Chien)(New Chien("Athos"))
        mChiens.Add(New Chien("Pollux"))
        mChiens.Add(New Chien("Titus"))
        mChiens.Add(New Chiot("Pif"))
        mChiens.Enerver()

        Dim a1, a2 As Animal
        a1 = New Chien("Athos")
        a2 = New Chiot("Pif")

        a1.Crier()
        a2.Crier()

        a1.Jouer()
        a2.Jouer()

        a1.Lécher()
        a2.Lécher()
    End Sub

    Private Sub Rex_Aboyer() Handles Rex.Aboyer
        WriteLine("Rex aboie")
    End Sub

    Private Sub Rex_Meurt() Handles Rex.Meurt
        WriteLine("Rex est mort")
    End Sub

    Private Sub Rex_Mordre() Handles Rex.Mordre
        WriteLine("Rex a mordu")
    End Sub

    Private Sub Rex_Nait() Handles Rex.Nait
        WriteLine("Rex est né le " & Rex.NéLe)
    End Sub

End Module

Public MustInherit Class EtreVivant
    Public NéLe As Date

    Public Event Nait()

    Public Event Meurt()

    Protected Sub New()
        NéLe = Now
        RaiseEvent Nait()
    End Sub

    Protected Overrides Sub Finalize()
        RaiseEvent Meurt()
    End Sub

    Private Sub EtreVivant_Meurt() Handles Me.Meurt
        WriteLine("Un être vivant est mort")
    End Sub

    Private Sub EtreVivant_Nait() Handles Me.Nait
        WriteLine("Un être vivant est né")
    End Sub

End Class

Public Class Animal : Inherits EtreVivant
    Public Race As String

    Public Event Mordre()

    Public Sub New(sRace As String)
        MyBase.New()
        Race = sRace
    End Sub

    Public Sub Enerver()
        RaiseEvent Mordre()
    End Sub

    Public Overridable Sub Crier()
        WriteLine("Un animal de race " & Race & " crie.")
    End Sub

    Public Overridable Sub Lécher()
        WriteLine("Un animal de race " & Race & " lèche.")
    End Sub

    Public Sub Jouer()
        WriteLine("Un animal de race " & Race & " joue.")
    End Sub

    Private Sub Animal_Meurt() Handles Me.Meurt
        WriteLine("Un animal de race " & Race & " est mort")
    End Sub

    Private Sub Animal_Mordre() Handles Me.Mordre
        WriteLine("Un animal de race " & Race & " a mordu")
    End Sub

    Private Sub Animal_Nait() Handles Me.Nait
        WriteLine("Un animal de race " & Race & " est né")
    End Sub

End Class

Public Class Chien : Inherits Animal

    Public Sub New(sNom As String)
        MyBase.New("Canis")
        Nom = sNom
    End Sub

    Protected Nom As String

    Public Event Aboyer()

    Public Sub Exciter()
        RaiseEvent Aboyer()
    End Sub

    Public Overrides Sub Crier()
        WriteLine(Nom & ": Wouaf !")
    End Sub

    Public NotOverridable Overrides Sub Lécher()
        WriteLine("Le chien " & Nom & " lèche")
    End Sub

    Public Overloads Sub Jouer()
        WriteLine("Le chien " & Nom & " joue.")
    End Sub

    Private Sub Chien_Aboyer() Handles Me.Aboyer
        WriteLine("Le chien " & Nom & " a aboyé")
    End Sub

    Private Sub Chien_Meurt() Handles Me.Meurt
        WriteLine("Le chien " & Nom & " est mort")
    End Sub

    Private Sub Chien_Mordre() Handles Me.Mordre
        WriteLine("Le chien " & Nom & " a mordu")
    End Sub

    Private Sub Chien_Nait() Handles Me.Nait
        WriteLine("Le chien " & Nom & " est né")
    End Sub

End Class

Friend Class Chiot : Inherits Chien

    Public Sub New(sNom As String)
        MyBase.New(sNom)
    End Sub

    Public Overrides Sub Crier()
        WriteLine(Nom & ": Wif !  Wif !")
    End Sub

    'Overrides Sub Lécher()
    '    WriteLine("Le chiot " & nom & " lèche")
    'End Sub

    Public Overloads Sub Jouer()
        WriteLine("Le chiot " & Nom & " joue.")
    End Sub

End Class

Friend Class Loup : Inherits Animal

    Public Sub New()
        MyBase.New("Lupus")
    End Sub

End Class
