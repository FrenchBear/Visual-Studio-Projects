' 240 VB Lift
'
' 2012-02-25	PV  VS2010
' 2021-09-20    PV  VS2022; Net6

#Disable Warning IDE0059 ' Unnecessary assignment of a value
#Disable Warning IDE1006 ' Naming Styles

Public Class frmControl

    Private Sub frmControl_Load(sender As Object, e As EventArgs) Handles Me.Load
        ' Create floor buttons
        For i As Integer = 0 To NumberOfFloors - 1
            Dim fb As ucFloorButtons
            fb = New ucFloorButtons

            paFloorButtons.Controls.Add(fb)
            fb.Location = New Point(3, 3 + i * (fb.Height + 3))
            fb.Name = "FloorButton" & Str(NumberOfFloors - 1 - i)
            fb.FloorLabel = "Floor " & CStr(NumberOfFloors - 1 - i)

            AddHandler fb.FloorRequestUp, AddressOf UcFloorButtons_FloorRequestUp
            AddHandler fb.FloorRequestDown, AddressOf UcFloorButtons_FloorRequestDown
        Next

        ' Create cars
        For i As Integer = 0 To NumberOfCars - 1
            Dim cb As CarButtonsUserControl
            cb = New CarButtonsUserControl(i)

            paCarButtons.Controls.Add(cb)
            cb.Location = New Point(3 + i * (cb.Width + 3), 3)
            cb.Name = tCar(i).sName             ' From Control
            cb.Label = tCar(i).sLabel
            cb.DoorStatus = tCar(i).iDoorStatus
            cb.Direction = tCar(i).iDirection
            cb.CarPosition = "Floor " & CStr(tCar(i).iFloor)

            AddHandler cb.CarRequest, AddressOf UcCarButtons_CarRequest
        Next

        ' Create Event list
        llEvents = New LinkedList(Of LiftEvent)
    End Sub

    Private Sub UcFloorButtons_FloorRequestUp(ucfb As ucFloorButtons)
        SchedulerForm.Trace("FloorRequestUp " & ucfb.FloorLabel)
        ucfb.CallStatusUp = Not ucfb.CallStatusUp
    End Sub

    Private Sub UcFloorButtons_FloorRequestDown(ucfb As ucFloorButtons)
        SchedulerForm.Trace("FloorRequestDown " & ucfb.FloorLabel)
        ucfb.CallStatusDown = Not ucfb.CallStatusDown
    End Sub

    Private Sub UcCarButtons_CarRequest(uccb As CarButtonsUserControl, iFloor As Integer)
        SchedulerForm.Trace("CarRequest from " & uccb.Label & " for Floor " & iFloor)
        uccb.CallStatus(iFloor) = Not uccb.CallStatus(iFloor)
        SetInMotion(uccb.Index)
    End Sub

    Dim llEvents As LinkedList(Of LiftEvent)

    Sub SetInMotion(iCar As Integer)
        ' Already an event in the queue for this cabin ?
        Dim bFound As Boolean = False
        Dim e As LiftEvent
        For Each e In llEvents
            If e.iCar = iCar Then Exit Sub
        Next

        ' Ok, have to insert a starting event for this cabin
        e = New LiftEvent With {
            .letType = LiftEvent.LiftEventType.letDoorClosed,
            .iCar = iCar,
            .TimeIndex = CurrentTimeIndex + DoorClosingDelay
        }

        InsertEvent(e)
    End Sub

    ''' <summary>
    ''' Insert a new event at a correct TimeIndex position in llEvents
    ''' </summary>
    Private Sub InsertEvent(ByRef eNew As LiftEvent)
        Dim lln As LinkedListNode(Of LiftEvent)
        ' Go through the linked list
        lln = llEvents.First
        Do Until lln Is Nothing
            If lln.Value.TimeIndex >= eNew.TimeIndex Then
                llEvents.AddBefore(lln, eNew)
                Exit Sub
            End If
            lln = lln.Next
        Loop
        ' List empty, or TimeIndex greated to all TimeIndex
        llEvents.AddLast(eNew)
    End Sub

End Class

Class LiftEvent

    Enum LiftEventType As Integer
        letDoorOpened
        letDoorClosed
        letFloorContact
    End Enum

    Public letType As LiftEventType
    Public iCar As Integer
    Public TimeIndex As Long
End Class