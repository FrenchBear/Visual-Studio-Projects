﻿' 402 VB Initializers
' New possibilities in .Net Framework 4 to intialize objects and collections
'
' 2010-02-24    PV
' 2021-09-23 	PV		VS2022; Net6
' 2023-01-10	PV		Net7
' 2023-11-18	PV		Net8
' 2024-11-15	PV		Net9


' For extension method
Imports System.Runtime.CompilerServices

Friend Module Module1
    Public Sub Main()
        ' Object initializer (with)
        Dim z1 As New Complexe With {.real = 2.3, .imaginary = 3.5}

        ' Collection initializer (from)
        Dim ls As New List(Of String) From {"Once", "upon", "a", "time", "was", "a", "fairy"}

        ' Both collection initializer and object initializer
        Dim lc As New List(Of Complexe) From {New Complexe With {.real = 0, .imaginary = 0}, New Complexe With {.real = 3.2, .imaginary = 1.7}, z1}

        ' Example of help (How to: Create a Collection Used by a Collection Initializer)
        ' anonymous structures can be added because there is a Add() extension method to List(Of Customer),
        ' and OrderCollection type also contains a Add() method
        Dim customerList = New List(Of Customer) From
          {
            {1, "John Rodman", New OrderCollection From {{9, 1, #6/12/2008#},
                                                         {8, 1, #6/11/2008#},
                                                         {5, 1, #5/1/2008#}}},
            {2, "Ariane Berthier", New OrderCollection From {{2, 2, #1/18/2008#},
                                                             {4, 2, #3/8/2008#},
                                                             {6, 2, #3/18/2008#},
                                                             {7, 2, #5/14/2008#},
                                                             {5, 2, #4/4/2008#}}},
             {3, "Brian Perry", New OrderCollection From {{1, 3, #1/15/2008#},
                                                          {3, 3, #3/8/2008#}}}
          }
    End Sub

    <Extension()>
    Public Sub Add(genericList As List(Of Customer),
id As Integer,
name As String,
orders As OrderCollection)

        genericList.Add(New Customer(id, name, orders))
    End Sub

End Module

Friend Class Complexe
    Public real As Double
    Public imaginary As Double
End Class

Public Class Customer
    Public Property Id As Integer
    Public Property Name As String
    Public Property Orders As OrderCollection

    Public Sub New(id As Integer, name As String, orders As OrderCollection)
        Me.Id = id
        Me.Name = name
        Me.Orders = orders
    End Sub

End Class

Public Class Order
    Public Property Id As Integer
    Public Property CustomerId As Integer
    Public Property OrderDate As Date

    Public Sub New(id As Integer,
customerId As Integer,
orderDate As Date)
        Me.Id = id
        Me.CustomerId = customerId
        Me.OrderDate = orderDate
    End Sub

End Class

Public Class OrderCollection
    Implements IEnumerable(Of Order)

    Private ReadOnly items As New List(Of Order)

    Public Property Item(index As Integer) As Order
        Get
            Return Me(index)
        End Get
        Set(value As Order)
            items(index) = value
        End Set
    End Property

    Public Sub Add(id As Integer, customerID As Integer, orderDate As Date)
        items.Add(New Order(id, customerID, orderDate))
    End Sub

    Public Function GetEnumerator() As IEnumerator(Of Order) Implements IEnumerable(Of Order).GetEnumerator
        Return items.GetEnumerator()
    End Function

    Public Function GetEnumerator1() As IEnumerator Implements IEnumerable.GetEnumerator
        Return GetEnumerator()
    End Function

End Class
