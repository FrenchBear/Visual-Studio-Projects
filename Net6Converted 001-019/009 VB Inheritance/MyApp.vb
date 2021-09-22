' 09 VB héritage
' Essais d'héritage de classes en VB
' 2001-10-27    PV
' 2006-10-01    PV  VS2005
' 2012-02-25	PV	VS2010
' 2021-09-17    PV  VS2022/Net6

Module Module1

    Sub Main()
        Dim d As New D()
        Console.ReadLine()
    End Sub

End Module

Class B

    Sub New()
        Console.WriteLine("B.ctor")
    End Sub

End Class

Class D
    Inherits B

    Sub New()
        'MyBase.New()   'Inutile, appelé automatiquement
        Console.WriteLine("D.ctor")
    End Sub

End Class