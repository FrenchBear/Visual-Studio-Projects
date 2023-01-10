' Essai d'attribut perso...
' 2001-08-18    PV
' 2006-10-01    PV  VS2005
' 2012-02-25	PV  VS2010
' 2021-09-19    PV  VS2022, Net6
' 2023-01-10	PV		Net7

<AttributeUsage(AttributeTargets.Assembly)> Public Class AssemblyPvAttribute
    Inherits Attribute

    Public Sub New(iVal As Integer)
        Flags = iVal
        Info = ""
    End Sub

    Public Property Info As String

    Public ReadOnly Property Flags As Integer
End Class
