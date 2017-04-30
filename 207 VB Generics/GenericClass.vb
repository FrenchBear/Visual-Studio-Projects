' Generic.vb
' Examples of Generic implementations
' 2004-09-25    PV
' 2012-02-25	PV  VS2010

' Generic Class
Class Population(Of aType As EtreVivant)
    Implements IEnumerable

    Protected mCol As Generic.List(Of aType)

    Sub New()
        mCol = New Generic.List(Of aType)
    End Sub
    Overridable Sub Add(ByVal a As aType)
        mCol.Add(a)
    End Sub
    ReadOnly Property Count() As Integer
        Get
            Return mCol.Count
        End Get
    End Property

    Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
        Return CType(mCol.GetEnumerator, IEnumerator)
    End Function
End Class


Class Troupeau : Inherits Population(Of Animal)
End Class

Class MeuteDe(Of anType As Animal) : Inherits Population(Of anType)
    Public Sub RassemblementDeMeute()
    End Sub
    Public ReadOnly Property PremierNé() As anType
        Get
            Return Nothing
        End Get
    End Property
End Class

Interface Meute(Of aType As Chien)
    ReadOnly Property Leader() As aType
End Interface

Class MeuteDeChiens : Inherits MeuteDe(Of Chien) : Implements Meute(Of Chien)
    Public MaleDominant As Chien

    Public ReadOnly Property Leader() As Chien Implements Meute(Of Chien).Leader
        Get
            Return Nothing
        End Get
    End Property
End Class

Class MeuteDeChiots : Inherits MeuteDe(Of Chiot) : Implements Meute(Of Chien)

    Public ReadOnly Property Leader() As Chien Implements Meute(Of Chien).Leader
        Get
            Return Nothing
        End Get
    End Property
End Class

' Cette classe n'a aucune relation d'héritage avec MeuteDe(Chien)
Class PortéeDeChiots : Inherits MeuteDe(Of Chiot)

End Class






Class Klass(Of t1, t2 As New, t3 As IComparable, t4 As {IComparable, IFormattable, New})

End Class

