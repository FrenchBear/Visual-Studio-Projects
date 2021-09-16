' 213 VB Custom Attribute
' 2012-02-25	PV  VS2010

Imports System.Attribute

#Disable Warning IDE0060 ' Remove unused parameter

Module Module1

    Sub Main()
        Dim x As New MaClasse
        x.RetrieveAttribute()
    End Sub

End Module

<Test("Test string")>
Class MaClasse

    Sub RetrieveAttribute()
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

<AttributeUsage(AttributeTargets.All)> Class TestAttribute
    Inherits Attribute
    Private m_SomeValue As String

    Public Sub New(Value As String)
        m_SomeValue = Value
    End Sub

    Public Sub Attr(AttrValue As String)
        'Add method code here.
    End Sub

    Public Property SomeValue() As String  ' A named parameter.
        Get
            Return m_SomeValue
        End Get
        Set(Value As String)
            m_SomeValue = Value
        End Set
    End Property

End Class