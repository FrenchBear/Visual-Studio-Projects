' 36 VB Interfaces
' Essai de définition et d'implémentation d'interface en VB
'
' 2001-02-05    PV
' 2006-10-01    PV  VS2005
' 2012-02-25	PV  VS2010
' 2021-09-18    PV  VS2022, Net6

Imports System.Console

#Disable Warning CA1822 ' Mark members as static

Public Class MyApp

    Public Shared Sub Main()
        Dim t As New MaClasse()

        t.MaMethodeBruyante1(1)
        CType(t, IMonInterface).MaMethodeBruyante1(2)

        ReadLine()
    End Sub

End Class

Public Delegate Sub GestionnaireDeBip(sender As Object, sMsg As String)

Public Interface IMonInterface

    Sub MaMethodeBruyante1(x As Integer)  ' Méthode

    Property MaPropriete() As Integer           ' Propriété

    Event Bip As GestionnaireDeBip              ' Evénement

    ReadOnly Property Item(index As Integer) As String  ' Indexer
    ReadOnly Property Item(index As String) As String
End Interface

Public Class MaClasse
    Implements IMonInterface

    Private iMembre As Integer

    Private Sub MonInterface_MaMethodeBruyante1(x As Integer) Implements IMonInterface.MaMethodeBruyante1
        WriteLine("Implémentation de MonInterface.MaMethodeBruyante1")
    End Sub

    ' Implémentation privée de MaMethodeBruyante1
    Sub MaMethodeBruyante1(x As Integer)
        WriteLine("Implémentation privée de MaMethodeBruyante1")
    End Sub

    Property MonInterface_MaPropriete() As Integer Implements IMonInterface.MaPropriete
        Get
            Return iMembre
        End Get
        Set(Value As Integer)
            iMembre = Value
        End Set
    End Property

    Event Bip As GestionnaireDeBip Implements IMonInterface.Bip

    ReadOnly Property Item(index As Integer) As String Implements IMonInterface.Item
        Get
            Return "Item[" & index & "]"
        End Get
    End Property

    ReadOnly Property Item(index As String) As String Implements IMonInterface.Item
        Get
            Return "Item[""" & index & """]"
        End Get
    End Property

End Class