' 403: Linq for Objects in VB
' Various Linq possibilies in VB
' Note: Linq in C# is different! (no aggregate, no group join)
'
' 2011-05-06 FPVI
' 2021-09-23 	PV		VS2022; Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9
' 2026-01-19	PV		Net10

Public Class Form1

    Public custList As List(Of Customer)
    Public counList As List(Of Country)
    Public persList As List(Of Person)

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        custList = New List(Of Customer) From {
                 New Customer With {.custId = 1, .custName = "Strawberry Fields", .custCountryId = 1},
                 New Customer With {.custId = 2, .custName = "Joe Banana", .custCountryId = 1},
                 New Customer With {.custId = 3, .custName = "Kiwi Zone", .custCountryId = 1},
                 New Customer With {.custId = 4, .custName = "Orange County", .custCountryId = 3}
             }
        counList = New List(Of Country) From {
                 New Country With {.counId = 1, .counName = "USA"},
                 New Country With {.counId = 2, .counName = "Australia"},
                 New Country With {.counId = 3, .counName = "UK"}
             }
        persList = New List(Of Person) From {
                 New Person With {.persId = 1, .persName = "Pierre"},
                 New Person With {.persId = 2, .persName = "Jean"}
             }
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' By default, it's a simple cartesian product
        OutText.AppendText("Test 1, cartesian product" & vbCrLf)
        Dim qry1 = From cu In custList, co In counList
                   Select cu, co
        For Each x In qry1
            OutText.AppendText(x.co.counName & ",  " & x.cu.custName & vbCrLf)
        Next

        ' Add a filter on cartesian product
        OutText.AppendText(vbCrLf & "Test 2, filter" & vbCrLf)
        Dim qry2 = From cu In custList
                   From co In counList
                   Where cu.custCountryId = co.counId
        'Select cu, co
        For Each x In qry2
            OutText.AppendText(x.co.counName & ",  " & x.cu.custName & vbCrLf)
        Next

        ' Grup Join: Left join/hierarchical query
        OutText.AppendText(vbCrLf & "Test 3, Group Join" & vbCrLf)
        Dim qry3 = From co In counList
                   Group Join cu In custList
                        On cu.custCountryId Equals co.counId
                        Into customers = Group,
                             nb = Count()
                   Select co, customers, nb
        For Each x In qry3
            OutText.AppendText(x.co.counName & ": " & x.nb.ToString & vbCrLf)
            For Each y In x.customers
                OutText.AppendText("    " & y.custName & vbCrLf)
            Next
        Next

        ' Join: combine a second collection with a first one
        OutText.AppendText(vbCrLf & "Test 4, join" & vbCrLf)
        Dim qry4 = From cu In custList
                   Join co In counList
                        On cu.custCountryId Equals co.counId
                   Select cu, co
        For Each x In qry4
            OutText.AppendText(x.co.counName & ",  " & x.cu.custName & vbCrLf)
        Next

        ' Group By, simple grouping
        OutText.AppendText(vbCrLf & "Test 5, group by" & vbCrLf)
        Dim qry5 = From cu In custList
                   From co In counList
                   Where cu.custCountryId = co.counId
                   Group By co.counName
                        Into CountryGroup = Group,
                             nb = Count()
                   Select CountryGroup, nb
        For Each x In qry5
            OutText.AppendText(x.CountryGroup.First.co.counName & ",  " & x.nb & vbCrLf)
            For Each y In x.CountryGroup
                OutText.AppendText("    " & y.cu.custName & vbCrLf)
            Next
        Next

        ' Aggregate
        OutText.AppendText(vbCrLf & "Test 6, aggregate" & vbCrLf)
        Dim qry6 = From co In counList
                   Aggregate cu In custList
                        Where cu.custCountryId = co.counId
                        Into nbCust = Count()
                   Select co, nbCust
        For Each x In qry6
            OutText.AppendText(x.co.counName & ",  " & x.nbCust.ToString & vbCrLf)
        Next

        ' Take whi
        OutText.AppendText(vbCrLf & "Test 7, take while" & vbCrLf)
        Dim qry7 = From cu In custList
                   Select cu
                   Take While (cu.custId Mod 2) = 1
        For Each x In qry7
            OutText.AppendText(x.custId.ToString & " " & x.custName & vbCrLf)
        Next

        ' Union/Distict
        OutText.AppendText(vbCrLf & "Test 8, union and distinct" & vbCrLf)
        Dim qry8a = From cu In custList
        Dim qry8b = From cu In custList Where (cu.custId Mod 2) = 1
        Dim qry8c = qry8a.Union(qry8b)
        Dim qry8 = From cu In qry8c
                   Select cu
                   Distinct
        For Each x In qry8
            OutText.AppendText(x.custId.ToString & " " & x.custName & vbCrLf)
        Next

    End Sub

End Class

Public Class Customer
    Public custId As Integer
    Public custName As String
    Public custCountryId As Integer
End Class

Public Class Country
    Public counId As Integer
    Public counName As String
End Class

Public Class Person
    Public persId As Integer
    Public persName As String
End Class
