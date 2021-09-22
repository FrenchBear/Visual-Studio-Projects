' VB20
' Projet mixte C#+VB
' La classe de base B est définie en VB
' La classe dérivée D est définie en C#
'
' 2001-01-27    PV
' 2006-10-01    PV  VS2005
' 2012-02-25	PV  VS2010
' 2017-04-30    PV  VS2017, Git

Namespace Mixte20

    Public Class B

        Public Sub New()
            Console.WriteLine("B.ctor")
        End Sub

    End Class

End Namespace