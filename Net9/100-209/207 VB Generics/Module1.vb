﻿' Essais de Generics
' Attention, Option Strict On au niveau du projet
'
' 2004-09-25    PV
' 2012-02-25	PV		VS2010
' 2021-09-19 	PV		VS2022; Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9

#Disable Warning IDE0059 ' Unnecessary assignment of a value
#Disable Warning IDE0060 ' Remove unused parameter
#Disable Warning CA1822 ' Mark members as static

Friend Module Module1
    Public Sub Main()
        'Dim a1, a2 As Animal
        'a1 = New Chien
        'a2 = New Chiot

        'a1.Crier()
        'a2.Crier()

        'Action(a1)

        'Dim c1, c2 As Couple(Of Double)
        'c1.x = 3
        'c1.y = 2.5
        'c2 = c1

        'Dim d1 As Couple(Of Date)
        'd1.x = #2/26/1965#
        'd1.y = #1/1/1900#

        'Dim cc As Couple(Of Chien)
        'cc.x = New Chien
        'cc.y = New Chien

        Dim rex As New Chien, pif As New Chiot
        'CaresserChiot(rex)      ' Refusé avec option strict: normal !
        CaresserChien(pif)      ' Dans ce sens, toujours accepté

        Dim m1 As New MeuteDeChiens With {
            .MaleDominant = Nothing
        }
        m1.Add(New Chiot)
        Dim m2 As New MeuteDeChiots From {
            New Chiot
        }

        ' Couple d'interface paramétrées
        Dim cmc As Couple(Of IMeute(Of Chien))
        cmc.x = m1
        cmc.y = m2

        Dim chienLeader As Chien = cmc.x.Leader
        Dim chiotLeader As Chien = cmc.y.Leader     ' Et pas  As Chiot...

        Dim chienPremierNé As Chien = MeuteDe(Of Chien).PremierNé
        Dim chiotPremierNé As Chiot = MeuteDe(Of Chiot).PremierNé

        Dim a As MeuteDeChiens = Nothing
        Dim b As MeuteDe(Of Chien)
        'a = b           ' Refusé avec option strict: normal !
        b = a           ' Ok

        ' MS Version
        Dim j As Integer?
        j = 2

        ' my version
        Dim k As NullableType(Of Integer)
        k = 2
        Dim ks As NullableType(Of Short)
        ks = 1

        Dim aa, bb, mi, ma As Integer
        aa = 1
        bb = 2
        mi = Min(Of Integer)(aa, bb)
        ma = Max(Of Integer)(aa, bb)

        Dim dMin As New MinOuMax(Of Date)(AddressOf Min)
        Dim dMax As New MinOuMax(Of Date)(AddressOf Max)
        Dim d1, d2, dinf, dsup As Date
        d1 = #2/26/1965#
        d2 = #1/1/2004#
        dinf = dMin(d1, d2)
        dsup = dMax(d1, d2)

        Dim v As Klass(Of Microbe, PortéeDeChiots, NullableType(Of Date), Integer)
        v = Nothing

        Dim ti() As Integer = {1, 2, 3, 4}

        WriteLine("Done.")
    End Sub

    Public Sub CaresserChien(c As Chien)
    End Sub

    Public Sub CaresserChiot(c As Chiot)
    End Sub

    Public Sub Action(v As IVivant)
        v.Respirer()
    End Sub

End Module

Friend Interface IVivant

    Sub Respirer()

End Interface

Friend MustInherit Class EtreVivant : Implements IVivant

    Protected MustOverride Sub Naitre()

    Public Sub Mourir()
    End Sub

    Private Sub Respirer() Implements IVivant.Respirer
        MsgBox("Un être vivant respire")
    End Sub

End Class

Friend Class Microbe : Inherits EtreVivant

    Protected Overrides Sub Naitre()

    End Sub

End Class

Friend Class Animal : Inherits EtreVivant

    Public Overridable Sub Crier()
        MsgBox("un animal crie")
    End Sub

    Protected Overrides Sub Naitre()

    End Sub

End Class

Friend Class Chien : Inherits Animal

    Public Overrides Sub Crier()
        MsgBox("Ouah !")
    End Sub

End Class

Friend NotInheritable Class Chiot : Inherits Chien

    Public Overrides Sub Crier()
        Japper()
    End Sub

    Public Sub Japper()
        MsgBox("Wif! Wif!")
    End Sub

End Class
