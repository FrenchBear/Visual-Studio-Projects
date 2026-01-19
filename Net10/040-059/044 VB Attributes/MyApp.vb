' 44 VB Attributes
' Essai d'utilisation des attributs en VB
'
' 2001-02-18    PV
' 2001-08-18    PV Beta2
' 2006-10-01 	PV		VS2005
' 2012-02-25	PV		VS2010
' 2021-09-18 	PV		VS2022, Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9
' 2026-01-19	PV		Net10

<AttributeUsage(AttributeTargets.Class)> Public Class MyAttribute
    Inherits Attribute

    Public Sub New(iVal As Integer)
        Flags = iVal
        Info = ""
    End Sub

    Public Property Info As String

    Public ReadOnly Property Flags As Integer
End Class

<My(1, Info:="Info de MaClasse1")>
Friend Class MaClasse1

End Class

<My(7)>
Friend Class MaClasse2

End Class

Friend Class MyApp

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
        tat = GetType(MyAttribute)

        Dim m As MyAttribute
        m = CType(tob.GetCustomAttributes(tat, False)(0), MyAttribute)
        WriteLine("{0}, {1}", m.Flags, m.Info)
    End Sub

End Class
