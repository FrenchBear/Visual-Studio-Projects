' 240 VB Lift
'
' 2012-02-25	PV		VS2010
' 2021-09-20 	PV		VS2022; Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9
' 2026-01-19	PV		Net10

Public Class SchedulerForm

    Private Sub StartButton_Click(sender As Object, e As EventArgs) Handles StartButton.Click
        Trace("Start")

        ReDim tCar(NumberOfCars - 1)
        For i As Integer = 0 To NumberOfCars - 1
            tCar(i) = New Car With {
                .sName = "Car" & i,
                .sLabel = "Car " & i,
                .iFloor = 0,          ' Ground level
                .iDoorStatus = 3,     ' Door open
                .iDirection = 0      ' No direction
                }
        Next

        frmControl.Show()
    End Sub

    Public Sub Trace(sMsg As String)
        TraceLabel.Items.Add(sMsg)
        TraceLabel.SelectedIndex = TraceLabel.Items.Count - 1
        TraceLabel.Refresh()
    End Sub

End Class
