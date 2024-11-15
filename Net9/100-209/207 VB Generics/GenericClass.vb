' Generic.vb
' Examples of Generic implementations
'
' 2004-09-25    PV
' 2012-02-25	PV      VS2010
' 2021-09-19    PV      VS2022; Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9

' Generic Class
Friend Class Population(Of aType As EtreVivant)
    Implements IEnumerable

    Protected mCol As List(Of aType)

    Public Sub New()
        mCol = New List(Of aType)
    End Sub

    Public Overridable Sub Add(a As aType)
        mCol.Add(a)
    End Sub

    Public ReadOnly Property Count() As Integer
        Get
            Return mCol.Count
        End Get
    End Property

    Public Function GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
        Return mCol.GetEnumerator
    End Function

End Class

Friend Class Troupeau : Inherits Population(Of Animal)
End Class

Friend Class MeuteDe(Of anType As Animal) : Inherits Population(Of anType)

    Public Shared Sub RassemblementDeMeute()
    End Sub

    Public Shared ReadOnly Property PremierNé() As anType
        Get
            Return Nothing
        End Get
    End Property

End Class

Friend Interface IMeute(Of aType As Chien)
    ReadOnly Property Leader() As aType
End Interface

Friend Class MeuteDeChiens : Inherits MeuteDe(Of Chien) : Implements IMeute(Of Chien)
    Public MaleDominant As Chien

    Public ReadOnly Property Leader() As Chien Implements IMeute(Of Chien).Leader
        Get
            Return Nothing
        End Get
    End Property

End Class

Friend Class MeuteDeChiots : Inherits MeuteDe(Of Chiot) : Implements IMeute(Of Chien)

    Public ReadOnly Property Leader() As Chien Implements IMeute(Of Chien).Leader
        Get
            Return Nothing
        End Get
    End Property

End Class

' Cette classe n'a aucune relation d'héritage avec MeuteDe(Chien)
Friend Class PortéeDeChiots : Inherits MeuteDe(Of Chiot)

End Class

Friend Class Klass(Of t1, t2 As New, t3 As IComparable, t4 As {IComparable, IFormattable, New})

End Class
