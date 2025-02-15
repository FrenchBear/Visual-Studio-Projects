﻿' Generic implementation of Min and Max using IComparable
'
' 2021-09-19 	PV		VS2022; Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9

Friend Module MinMax

    Public Delegate Function MinOuMax(Of t)(x1 As IComparable, x2 As IComparable) As t

    Public Function Min(Of t)(t1 As IComparable, t2 As IComparable) As t
        Return If(t1.CompareTo(t2) < 0, CType(t1, t), CType(t2, t))
    End Function

    Public Function Max(Of t)(t1 As IComparable, t2 As IComparable) As t
        Return If(t1.CompareTo(t2) > 0, CType(t1, t), CType(t2, t))
    End Function

End Module

' Generic implementation of Min and Max using >
' Doesn't work, but why ?
' Why the compiler says "Operator '<' is not defined for types 't' and 't'" ?
'Module MinMaxOperator
'    Public Delegate Function MinOuMaxOp(Of t)(ByVal x1 As t, ByVal x2 As t) As t

'    Public Function Min(Of t)(ByVal t1 As t, ByVal t2 As t) As t
'        If t1 < t2 Then
'            Return t1
'        Else
'            Return t2
'        End If
'    End Function

'End Module
