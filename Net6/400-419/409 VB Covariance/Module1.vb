﻿' 409 VB Covariance
' Tests on Covariance in VB
'
' 2011-09-28 PV
' 2021-09-23    PV  VS2022; Net6

#Disable Warning IDE0052 ' Remove unread private members

Module Module1
    ReadOnly ListBase As New List(Of Base)

    Sub Main()
        ' Example of covariant generic interface (almost natural, looks like polymorphism)
        Dim ld As IEnumerable(Of Derived) = New List(Of Derived)
        Dim lb As IEnumerable(Of Base) = ld    ' This is only permitted because of covariance of IEnumerable(Of Out T) interface: can use a type more derived than defined

        ' Contravariance
        Dim b As Action(Of Base) =
            Sub(target As Base)
                WriteLine(target.GetType.Name & ": " & target.ToString)
            End Sub
        Dim d As Action(Of Derived) = b         ' Contravariance, Because of definition Action(Of In T)(obj as T), type T is contravariant
        d(New Derived)

        ' Notes:
        ' In .Net 4, variant type parameters (covariant and contravariant) are restricted to generic interfaces and generic delegates types
        ' Variance only applies for reference types
    End Sub

End Module

Class Base

End Class

Class Derived : Inherits Base

End Class