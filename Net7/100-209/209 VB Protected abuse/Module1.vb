' 209 VB Protected abuse
' Attempt to misuse protected... but doesn't work :-)
'
' 2012-02-25	PV  VS2010
' 2021-09-19    PV  VS2022; Net6
' 2023-01-10	PV		Net7

Module Module1

    Sub Main()
        Dim x As New C1
        CType(x, C2).Pp = 3         ' Can't cast to a more derived type of course!
    End Sub

    Class C2 : Inherits C1

        Property Pp() As Integer
            Get
                Return p
            End Get
            Set(value As Integer)
                p = value
            End Set
        End Property

    End Class

End Module

Class C1
    Protected p As Integer
End Class
