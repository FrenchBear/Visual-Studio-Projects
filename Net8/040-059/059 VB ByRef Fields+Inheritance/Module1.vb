' 059 VB ByRef Fields+Inheritance
'
' 2001-08-17 	PV		Essai de transmission de champ et de propriété par référence (ne marche pas en VB6) + essais méthodes/classes abstraites, scellées, virtuelles...
' 2006-10-01 	PV		VS2005
' 2012-02-25	PV		VS2010
' 2021-09-18 	PV		VS2022, Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8

#Disable Warning CA1822 ' Mark members as static
#Disable Warning CA2211 ' Non-constant fields should not be visible

Imports System.Console


Public MustInherit Class Zap

    Public Sub New()
        WriteLine("Zap.New()")
    End Sub

    Public Sub MH()
        WriteLine("Zap.MH()")
    End Sub

    Public Overridable Sub OV1()
        WriteLine("Zap.OV1()")
    End Sub

    Public Overridable Sub OV2()
        WriteLine("Zap.OV2()")
    End Sub

    Public MustOverride Sub MO1()

    Public MustOverride Sub MO2()

End Class

Public Class Couleur : Inherits Zap

    ' Si la variable n'est pas shared, ça provoque un débordement de pile
    ' Non détecté par le compilo VB !
    Protected Shared Bleu As New Couleur(0, 0, 255)

    Public R, G, B As Integer
    Private m_A As Integer

    Public Sub New()
        Me.New(0, 0, 0)
        WriteLine("Couleur.New()")
    End Sub

    Public Sub New(rr As Integer, gg As Integer, bb As Integer)
        WriteLine("Couleur.New({0},{1},{2})", rr, gg, bb)
        R = rr
        G = gg
        B = bb
        m_A = 0
    End Sub

    Public Overrides Function ToString() As String
        Return "{" & m_A.ToString & ", " & R.ToString & ", " & G.ToString & ", " & B.ToString & "}"
    End Function

    Public Property A() As Integer
        Get
            Return m_A
        End Get
        Set(Value As Integer)
            m_A = Value
        End Set
    End Property

    Public Overridable Sub S1()
        WriteLine("Couleur.S1()")
    End Sub

    Public NotOverridable Overrides Sub MO1()
        WriteLine("Couleur.MO1()")
    End Sub

    Public Overrides Sub MO2()
        WriteLine("Couleur.MO2()")
    End Sub

    Public NotOverridable Overrides Sub OV1()
        WriteLine("Couleur.OV1()")
    End Sub

End Class

Public NotInheritable Class CouleurClaire : Inherits Couleur

    Public Sub New()
        WriteLine("CouleurClaire.New()")
    End Sub

    Public Shadows Sub S1()
        WriteLine("CouleurClaire.S1()")
    End Sub

    Public Overrides Sub MO2()
        WriteLine("CouleurClaire.MO2()")
    End Sub

    Public Shadows Sub OV1()
        WriteLine("CouleurClaire.OV1()")
    End Sub

End Class

Public Module Module1

    Sub Main()
        WriteLine("Module1.Main()")

        Dim c As New Couleur(128, 80, 200)
        WriteLine("c = {0}", c)
        Complément255(c.G)
        WriteLine("c = {0}", c)
        Complément255(c.A)
        WriteLine("c = {0}", c)
        WriteLine()

        Dim cc As New CouleurClaire()
        WriteLine()

        Dim zc As Zap = c
        WriteLine("Appels avec un objet Couleur et une variable Zap")
        zc.MH()
        zc.MO1()
        zc.MO2()
        zc.OV1()
        zc.OV2()
        WriteLine()

        Dim zcc As Zap = cc
        WriteLine("Appels avec un objet CouleurClaire et une variable Zap")
        zcc.MH()
        zcc.MO1()
        zcc.MO2()
        zcc.OV1()
        zcc.OV2()
        WriteLine()

        Dim c2 As Couleur = cc
        WriteLine("Appels avec un objet CouleurClaire et une variable Couleur")
        c2.MH()
        c2.MO1()
        c2.MO2()
        c2.OV1()
        c2.OV2()
        c2.S1()
        WriteLine()

        WriteLine("Appels avec un objet CouleurClaire et une variable CouleurClaire")
        cc.MH()
        cc.MO1()
        cc.MO2()
        cc.OV1()
        cc.OV2()
        cc.S1()

        'Console.ReadLine()
    End Sub

    Sub Complément255(ByRef x As Integer)
        x = 255 - x
    End Sub

End Module
