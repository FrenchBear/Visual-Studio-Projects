' VB20
' Projet mixte C#+VB
' La classe de base B est définie en VB
' La classe dérivée D est définie en C#
'
' 2001-01-27    PV
' 2006-10-01 	PV		VS2005
' 2012-02-25	PV		VS2010
' 2017-04-30 	PV		VS2017, Git
' 2021-09-18 	PV		VS2022, Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-04-05    PV      Restart project from scratch to make it work with current Visual Studio and tools
' 2024-11-15	PV		Net9

'Namespace Mixte20

Public Class B

    Public Sub New()
        Console.WriteLine("B.ctor")
    End Sub

End Class

'End Namespace
