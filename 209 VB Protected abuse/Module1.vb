' 209 VB Protected abuse
' Attempt to misuse protected... but doesn't work :-)
' 2012-02-25	PV  VS2010

Module Module1
    Sub Main()
        Dim x As c1 = New c1
        CType(x, c2).pp = 3         ' Can't cast to a more derived type of course!
    End Sub

    Class c2 : Inherits c1
        Property pp() As Integer
            Get
                Return p
            End Get
            Set(ByVal value As Integer)
                p = value
            End Set
        End Property
    End Class
End Module

Class c1
    Protected p As Integer
End Class
