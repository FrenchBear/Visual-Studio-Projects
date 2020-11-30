Module Module1
    Sub Main()
        Dim array() As Object = New String(10) {}
        array(0) = "Hello"
        array(1) = 12

        Dim Rex As New Chien

        Dim maMeuteCanine As New TroupeauDeChien
        Dim maHordeAnimale As New TroupeauDeAnimal

        maMeuteCanine.Add(Rex)
        maHordeAnimale.Add(Rex)
        'maHordeAnimale = maMeuteCanine

        Dim monTroupeauCanin As New Troupeau(Of Chien)
        Dim monTroupeauAnimal As New Troupeau(Of Animal)
        monTroupeauCanin.Add(Rex)
        monTroupeauAnimal.Add(Rex)

        'monTroupeauAnimal = monTroupeauCanin
    End Sub

End Module

Class Animal

End Class

Class Chien
    Inherits Animal

End Class

Class Troupeau(Of T)
    Implements IAddAnimal(Of T), IEnumerable(Of T)

    Private ReadOnly tr As New List(Of T)

    Public Sub Add(a As T) Implements IAddAnimal(Of T).Add
        tr.Add(a)
    End Sub

    Public Function GetEnumerator() As System.Collections.Generic.IEnumerator(Of T) Implements System.Collections.Generic.IEnumerable(Of T).GetEnumerator
        Return tr.GetEnumerator
    End Function

    Public Function GetEnumerator1() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
        Return tr.GetEnumerator
    End Function
End Class


Interface IAddAnimal(Of In T)
    Sub Add(ByVal a As T)
End Interface

Class TroupeauDeAnimal
    Public Sub Add(ByVal a As Animal)

    End Sub
End Class

Class TroupeauDeChien
    Public Sub Add(ByVal c As Chien)

    End Sub
End Class
