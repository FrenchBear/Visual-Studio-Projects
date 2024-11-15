' 240 VB Lift
'
' 2012-02-25	PV		VS2010
' 2021-09-20 	PV		VS2022; Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9

Public Class Car
    Public sName As String
    Public sLabel As String
    Public iDoorStatus As Integer       ' 0:Closed 1:Closing 2:Opening 3:Open
    Public iDirection As Integer        ' -1:Down  0:Steady  1:up
    Public iFloor As Integer
End Class
