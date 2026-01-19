' 213 VB Custom Attribute
'
' 2012-02-25	PV		VS2010
' 2021-09-19 	PV		VS2022; Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9
' 2026-01-19	PV		Net10

Imports System.Attribute

#Disable Warning IDE0060 ' Remove unused parameter
#Disable Warning CA1822 ' Mark members as static

Friend Module Module1
    Public Sub Main()
        Dim x As New MaClasse
        x.RetrieveAttribute()
    End Sub

End Module

<Test("Test string")>
Friend Class MaClasse
    Public Sub RetrieveAttribute()
        Dim Attr As Attribute
        Dim CustAttr As TestAttribute

        Attr = GetCustomAttribute(GetType(MaClasse),
                                  GetType(TestAttribute), False)
        CustAttr = CType(Attr, TestAttribute)

        If CustAttr Is Nothing Then
            MsgBox("The attribute was not found.")
        Else
            'Get the label and value from the custom attribute.
            MsgBox("The attribute label is: " & CustAttr.SomeValue)
        End If
    End Sub

End Class

<AttributeUsage(AttributeTargets.All)>
Friend Class TestAttribute
    Inherits Attribute

    Public Sub New(value As String)
        SomeValue = value
    End Sub

    Public Sub Attr(attrValue As String)
        'Add method code here.
    End Sub

    Public Property SomeValue As String
End Class
