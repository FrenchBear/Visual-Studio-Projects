' 36 VB Interfaces
' Essai de d�finition et d'impl�mentation d'interface en VB
' 2001-02-05    PV
' 2006-10-01    PV  VS2005
' 2012-02-25	PV  VS2010

Public Class MyApp
    Public Shared Sub Main()
        Dim t As New MaClasse()

        t.MaMethodeBruyante1(1)
        CType(t, IMonInterface).MaMethodeBruyante1(2)

        Console.ReadLine()
    End Sub
End Class


Public Delegate Sub GestionnaireDeBip(ByVal sender As Object, ByVal sMsg As String)

Public Interface IMonInterface
    Sub MaMethodeBruyante1(ByVal x As Integer)  ' M�thode
    Property MaPropriete() As Integer           ' Propri�t�
    Event Bip As GestionnaireDeBip              ' Ev�nement
    ReadOnly Property Item(ByVal index As Integer) As String  ' Indexer
    ReadOnly Property Item(ByVal index As String) As String
End Interface


Public Class MaClasse
    Implements IMonInterface

    Private iMembre As Integer

    Private Sub MonInterface_MaMethodeBruyante1(ByVal x As Integer) Implements IMonInterface.MaMethodeBruyante1
        Console.WriteLine("Impl�mentation de MonInterface.MaMethodeBruyante1")
    End Sub

    ' Impl�mentation priv�e de MaMethodeBruyante1
    Sub MaMethodeBruyante1(ByVal x As Integer)
        Console.WriteLine("Impl�mentation priv�e de MaMethodeBruyante1")
    End Sub

    Property MonInterface_MaPropriete() As Integer Implements IMonInterface.MaPropriete
        Get
            Return iMembre
        End Get
        Set(ByVal Value As Integer)
            iMembre = Value
        End Set
    End Property

    Event Bip As GestionnaireDeBip Implements IMonInterface.Bip

    ReadOnly Property Item(ByVal index As Integer) As String Implements IMonInterface.Item
        Get
            Return "Item[" & index & "]"
        End Get
    End Property

    ReadOnly Property Item(ByVal index As String) As String Implements IMonInterface.Item
        Get
            Return "Item[""" & index & """]"
        End Get
    End Property

End Class

