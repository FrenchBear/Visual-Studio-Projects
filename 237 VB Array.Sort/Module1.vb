' 237 VB Array.Sort
' 2012-02-25	PV  VS2010

Module Module1

    Sub Main()
        Dim tc() As Colonne = New Colonne() {New Colonne(1, "PK"), New Colonne(3, "CreatedOn"), New Colonne(2, "Nom"), New Colonne(2, "Age")}

        Dim tc2() As Colonne = tc.Clone
        Array.Sort(tc2, New myColumnComparer)
        For Each c As Colonne In tc2
            Console.WriteLine("{0}: {1}", c.rang, c.nom)
        Next
        Console.ReadLine()
    End Sub

    Class myColumnComparer
        Implements System.Collections.IComparer

        Public Function Compare(ByVal x As Object, ByVal y As Object) As Integer Implements System.Collections.IComparer.Compare
            Return CType(x, Colonne).rang - CType(y, Colonne).rang
        End Function
    End Class

End Module

Class Colonne
    Public rang As Integer
    Public nom As String

    Public Sub New(ByVal rang As Integer, ByVal nom As String)
        Me.rang = rang
        Me.nom = nom
    End Sub
End Class