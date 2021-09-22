' 240 VB Lift
' 2012-02-25	PV  VS2010

Public Class frmScheduler

    Private Sub btnStart_Click(sender As System.Object, e As EventArgs) Handles btnStart.Click
        Trace("Start")

        ReDim tCar(NumberOfCars - 1)
        For i As Integer = 0 To NumberOfCars - 1
            tCar(i) = New Car With {
                .sName = "Car" & CStr(i),
                .sLabel = "Car " & CStr(i),
                .iFloor = 0,          ' Ground level
                .iDoorStatus = 3,     ' Door open
                .iDirection = 0      ' No direction
                }
        Next

        frmControl.Show()
    End Sub

    Sub Trace(sMsg As String)
        lbTrace.Items.Add(sMsg)
        lbTrace.SelectedIndex = lbTrace.Items.Count - 1
        lbTrace.Refresh()
    End Sub

End Class