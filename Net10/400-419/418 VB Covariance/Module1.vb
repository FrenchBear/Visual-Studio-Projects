' 2021-09-23 	PV		VS2022; Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9
' 2026-01-19	PV		Net10


#Disable Warning IDE0060 ' Remove unused parameter
#Disable Warning CA1822 ' Mark members as static

Friend Module Module1
    Public Sub Main()
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

Friend Class Animal

End Class

Friend Class Chien
    Inherits Animal

End Class

Friend Class Troupeau(Of T)
    Implements IAddAnimal(Of T), IEnumerable(Of T)

    Private ReadOnly tr As New List(Of T)

    Public Sub Add(a As T) Implements IAddAnimal(Of T).Add
        tr.Add(a)
    End Sub

    Public Function GetEnumerator() As IEnumerator(Of T) Implements IEnumerable(Of T).GetEnumerator
        Return tr.GetEnumerator
    End Function

    Public Function GetEnumerator1() As IEnumerator Implements IEnumerable.GetEnumerator
        Return tr.GetEnumerator
    End Function

End Class

Friend Interface IAddAnimal(Of In T)

    Sub Add(a As T)

End Interface

Friend Class TroupeauDeAnimal

    Public Sub Add(a As Animal)

    End Sub

End Class

Friend Class TroupeauDeChien

    Public Sub Add(c As Chien)

    End Sub

End Class
