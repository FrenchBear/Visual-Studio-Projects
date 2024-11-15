' 2021-09-19 	PV		VS2022; Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9

Imports System.Collections.ObjectModel

Friend Class Meute(Of T As Animal)
    Private ReadOnly mCol As Collection(Of T)

    Public Sub New()
        mCol = New Collection(Of T)
    End Sub

    Public Sub New(a1 As T)
        mCol = New Collection(Of T) From {
            a1
        }
    End Sub

    Public Sub Add(a1 As T)
        mCol.Add(a1)
    End Sub

    Public Sub Enerver()
        For Each a As T In mCol
            a.Enerver()
        Next
    End Sub

End Class

'' Custom Event Handler in VB
'Class Events
'    Private Event PreDrawEvent As EventHandler

'    Private Custom Event OnDraw As EventHandler
'        AddHandler(ByVal value As EventHandler)
'            SyncLock PreDrawEvent
'                AddHandler PreDrawEvent, value
'            End SyncLock
'        End AddHandler
'        RemoveHandler(ByVal value As EventHandler)
'            SyncLock PreDrawEvent
'                RemoveHandler PreDrawEvent, value
'            End SyncLock
'        End RemoveHandler
'    End Event
'
'End Class
