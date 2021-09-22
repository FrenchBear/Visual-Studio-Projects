' Essai d'attribut perso...
' 2001-08-18    PV
' 2006-10-01    PV  VS2005
' 2012-02-25	PV  VS2010
' 2021-09-19    PV  VS2022, Net6

#Disable Warning IDE1006 ' Naming Styles

<AttributeUsage(AttributeTargets.Assembly)> Public Class AssemblyPVAttribute
    Inherits Attribute
    Private ReadOnly iPriv As Integer
    Private sInfo As String

    Public Sub New(iVal As Integer)
        iPriv = iVal
        sInfo = ""
    End Sub

    Public Property Info() As String
        Get
            Return sInfo
        End Get
        Set(Value As String)
            sInfo = Value
        End Set
    End Property

    Public ReadOnly Property iFlags() As Integer
        Get
            Return iPriv
        End Get
    End Property

End Class