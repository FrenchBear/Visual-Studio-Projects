' 2001 PV
'
' 2006-10-01 	PV		VS2005
' 2012-02-25	PV		VS2010
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9
' 2026-01-19	PV		Net10

Public Class Animal
    Private sNom As String

    Public Sub New(s As String)
        MyBase.New()
        sNom = s
    End Sub

    ' Constructeur copie
    Public Sub New(bestiole As Animal)
        MyBase.New()
        sNom = bestiole.sNom
    End Sub

    Public Overridable Sub Cri()
        MsgBox("Cri de base de " & sNom)
    End Sub

    Public Property Nom() As String
        Get
            Nom = sNom
        End Get
        Set(Value As String)
            sNom = Nom
        End Set
    End Property

End Class

Public Class Chat
    Inherits Animal

    Public Overrides Sub Cri()
        MsgBox(Nom & ": Miaou !")
    End Sub

    Public Sub New(s As String)
        MyBase.New(s)
    End Sub

End Class

Friend Class Chien
    Inherits Animal

    Public Overrides Sub Cri()
        MsgBox(Nom & ": Ouah! Ouah!")
    End Sub

    Public Sub New(s As String)
        MyBase.New(s)
    End Sub

End Class

Friend Class Chiot
    Inherits Chien

    Public Overrides Sub Cri()
        MsgBox(Nom & ": Wif ! Wif !")
    End Sub

    Public Sub New(s As String)
        MyBase.New(s)
    End Sub

End Class
