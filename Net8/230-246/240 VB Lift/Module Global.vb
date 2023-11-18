' 240 VB Lift
'
' 2012-02-25	PV		VS2010
' 2021-09-20 	PV		VS2022; Net6
' 2023-01-10	PV		Net7

Module modGlobal
    Public NumberOfFloors = 8
    Public NumberOfCars = 4

    Public CurrentTimeIndex As Long

    ' Time/Delays in ms
    Public DoorClosingDelay = 1500

    Public TimeToMoveOneFloor = 1500

    ' Cars
    Public tCar() As Car

End Module
