' 44 VB Attributes
' Essai d'utilisation des attributs en VB
'
' 2001-02-18    PV
' 2001-08-18    PV Beta2
' 2006-10-01    PV  VS2005
' 2012-02-25	PV  VS2010
' 2021-09-18    PV  VS2022, Net6

<AttributeUsage(AttributeTargets.Class)> Public Class MonAttribut
    Inherits Attribute

    Public Sub New(iVal As Integer)
        Flags = iVal
        Info = ""
    End Sub

    Public Property Info As String

    Public ReadOnly Property Flags As Integer
End Class

<MonAttribut(1, Info:="Info de MaClasse1")> Class MaClasse1

End Class

<MonAttribut(7)> Class MaClasse2

End Class

Class MyApp

    Public Shared Sub Main()
        Dim o1 As New MaClasse1()
        Dim o2 As New MaClasse2()

        Zap(o1)
        Zap(o2)

        'Console.ReadLine()
    End Sub

    Private Shared Sub Zap(o As Object)
        Dim tob As Type     ' Type de l'objet
        tob = o.GetType()
        WriteLine(tob.Name)

        Dim tat As Type     ' Type de l'attribut
        tat = GetType(MonAttribut)

        Dim m As MonAttribut
        m = CType(tob.GetCustomAttributes(tat, False)(0), MonAttribut)
        WriteLine("{0}, {1}", m.Flags, m.Info)
    End Sub

End Class