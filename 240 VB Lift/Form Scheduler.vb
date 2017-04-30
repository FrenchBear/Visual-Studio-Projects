' 240 VB Lift
' 2012-02-25	PV  VS2010

Public Class frmScheduler
    Private Sub btnStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart.Click
        Trace("Start")

        ReDim tCar(NumberOfCars - 1)
        For i As Integer = 0 To NumberOfCars - 1
            tCar(i) = New Car
            tCar(i).sName = "Car" & CStr(i)
            tCar(i).sLabel = "Car " & CStr(i)
            tCar(i).iFloor = 0          ' Ground level
            tCar(i).iDoorStatus = 3     ' Door open
            tCar(i).iDirection = 0      ' No direction
        Next

        frmControl.Show()
    End Sub

    Sub Trace(ByVal sMsg As String)
        lbTrace.Items.Add(sMsg)
        lbTrace.SelectedIndex = lbTrace.Items.Count - 1
        lbTrace.Refresh()
    End Sub
End Class
