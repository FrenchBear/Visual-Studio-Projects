' Linq to Objects
' Tests of Linq queries
'
' 2008-08-31    PV
' 2012-02-25    PV  VS2010
' 2021-09-20    PV  VS2022; Net6

Option Compare Text

Imports System.Runtime.CompilerServices

Module Module1

    Sub Main()
        InitDB()

        Dim queryClientsFrance = From cust In Customers
                                 Where cust.Country = "France"
                                 Select cust.CustomerID, cust.CompanyName
        Console.Write("French Clients: ")
        queryClientsFrance.WriteLine()
        Console.WriteLine()

        'Dim queryResults = From cust In Customers, ord In Orders _
        '                   Where cust.CustomerID = ord.CustomerID _
        '                   Select cust, ord
        'queryResults.WriteLine()
    End Sub

    ' Quick helpers to print an enumeration
    <Extension()>
    Public Sub Write(Of TSource)(Source As IEnumerable(Of TSource))
        Dim bFirst As Boolean = True
        For Each element As TSource In Source
            If bFirst Then
                bFirst = False
            Else
                Console.Write(", ")
            End If
            Console.Write(element)
        Next
    End Sub

    <Extension()>
    Public Sub WriteLine(Of TSource)(Source As IEnumerable(Of TSource))
        Source.Write()
        Console.WriteLine()
    End Sub

End Module
