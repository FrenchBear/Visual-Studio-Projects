' Implémentation d'un énumérateur en VB
'
' 2001-02-18    PV
' 2006-10-01 	PV		VS2005
' 2012-02-25	PV		VS2010
' 2021-09-18 	PV		VS2022, Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9
' 2026-01-19	PV		Net10

#Disable Warning CA1710 ' Identifiers should have correct suffix
#Disable Warning CA1010 ' Generic interface should also be implemented
Public Class TroisEntiers
    Implements IEnumerable

    Private ReadOnly i1, i2, i3 As Integer

    Public Sub New(i1 As Integer, i2 As Integer, i3 As Integer)
        Me.i1 = i1
        Me.i2 = i2
        Me.i3 = i3
    End Sub

    Public Function GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
        Return New MonEnumérateur(Me)
    End Function

    Private Class MonEnumérateur
        Implements IEnumerator

        Private ReadOnly t As TroisEntiers
        Private iPos As Integer

        Public Sub New(t As TroisEntiers)
            Me.t = t
            iPos = -1
        End Sub

        Private Sub Reset() Implements IEnumerator.Reset
            iPos = -1
        End Sub

        Private ReadOnly Property Current() As Object Implements IEnumerator.Current
            Get
                Select Case iPos
                    Case 0 : Return t.i1
                    Case 1 : Return t.i2
                    Case 2 : Return t.i3
                    Case Else : Throw New InvalidOperationException()
                End Select
            End Get
        End Property

        Private Function MoveNext() As Boolean Implements IEnumerator.MoveNext
            If iPos < 2 Then
                iPos += 1
                Return True
            Else
                Return False
            End If
        End Function

    End Class

End Class
