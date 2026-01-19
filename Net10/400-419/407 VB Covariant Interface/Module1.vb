' VB407 Covariant Interface
' Tests on covariance
'
' 2011-07-12    PV
' 2021-09-23 	PV		VS2022; Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9
' 2026-01-19	PV		Net10

Friend Module Module1
    Public Sub Main()

        Dim d As New Dictionary(Of ITypedEurodatKey(Of BC), BC)

        Dim k As New EurodatKey With {.SqlId = 123, .IncId = 456}
        Dim k1 As TypedEurodatKey(Of BC1) = k
        Dim k2 As TypedEurodatKey(Of BC2) = k

        d.Add(k1, New BC1)
        d.Add(k2, New BC1)
    End Sub

End Module

Public Structure EurodatKey
    Public SqlId As Short
    Public IncId As Integer
End Structure

' Out represents covariance
Public Interface ITypedEurodatKey(Of Out T)

End Interface

Public Structure TypedEurodatKey(Of T)
    Implements ITypedEurodatKey(Of T)

    Public key As EurodatKey

    Public Shared Widening Operator CType(key As EurodatKey) As TypedEurodatKey(Of T)
        Dim tk = New TypedEurodatKey(Of T) With {
            .key = key
        }
    End Operator

End Structure

Friend Class BC1
    Inherits BC
End Class

Friend Class BC2
    Inherits BC
End Class

Public Class BC

End Class
