﻿' 232 VB String ShallowCopy
'
' 2012-02-25	PV		VS2010
' 2021-09-20 	PV		VS2022; Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8

Module Module1

    Sub Main()
        Dim t1 As String() = {"A", "B", "C"}
        Dim t2 As String() = t1.Clone
        t2(0) = "Z"
        WriteLine(t1(0))
    End Sub

End Module
