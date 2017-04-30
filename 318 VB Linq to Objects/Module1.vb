' Linq to Objects
' Tests of Linq queries
' 2008-08-31    PV
' 2012-02-25	PV  VS2010


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

        Console.WriteLine()
        Console.Write("(pause)")
        Console.ReadLine()
    End Sub


    ' Quick helpers to print an enumaration
    <Extension()>
    Public Sub Write(Of TSource)(ByVal Source As IEnumerable(Of TSource))
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
    Public Sub WriteLine(Of TSource)(ByVal Source As IEnumerable(Of TSource))
        Write(Of TSource)(Source)
        Console.WriteLine()
    End Sub



End Module

