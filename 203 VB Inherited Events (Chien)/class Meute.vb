Imports System.Collections.ObjectModel


Class Meute(Of T As Animal)
    Private ReadOnly mCol As Collection(Of T)

    Sub New()
        mCol = New Collection(Of T)
    End Sub

    Sub New(ByVal a1 As T)
        mCol = New Collection(Of T)
        mCol.Add(a1)
    End Sub

    Sub Add(ByVal a1 As T)
        mCol.Add(a1)
    End Sub

    Sub Enerver()
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