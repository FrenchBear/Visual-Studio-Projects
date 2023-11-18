
// 402 VB Initializers
// New possibilities in .Net Framework 4 to intialize objects and collections
//
// 2010-02-24   PV
// 2021-09-23   PV      VS2022; Net6
// 2023-01-10	PV		Net7

#pragma warning disable CA1050 // Declare types in namespaces

using System;
using System.Collections;
using System.Collections.Generic;

// For extension method
internal static class Module1
{
    public static void Main()
    {
        // Object initializer (with)
        Complexe z1 = new()
        {
            real = 2.3,
            imaginary = 3.5
        };

        // Collection initializer (from)
        List<string> ls =
        [
            "Once",
            "upon",
            "a",
            "time",
            "was",
            "a",
            "fairy"
        ];

        // Both collection initializer and object initializer
        List<Complexe> lc =
        [
            new Complexe
            {
                real = 0,
                imaginary = 0
            },
            new Complexe
            {
                real = 3.2,
                imaginary = 1.7
            },
            z1
        ];

        // Example of help (How to: Create a Collection Used by a Collection Initializer)
        // anonymous structures can be added because there is a Add() extension method to List(Of Customer),
        // and OrderCollection type also contains a Add() method
        var customerList = new List<Customer>
          {
            {1, "John Rodman", new OrderCollection {{9, 1, new DateTime(2008,6,12)},
                                                         {8, 1, new DateTime(2008,6,11)},
                                                         {5, 1, new DateTime(2008,5,1)}}
        //,
        //    {2, "Ariane Berthier", New OrderCollection From {{2, 2, #1/18/2008#},
        //                                                     {4, 2, #3/8/2008#},
        //                                                     {6, 2, #3/18/2008#},
        //                                                     {7, 2, #5/14/2008#},
        //                                                     {5, 2, #4/4/2008#}}},
        //     {3, "Brian Perry", New OrderCollection From {{1, 3, #1/15/2008#},
        //                                                  {3, 3, #3/8/2008#}}}
        }};
    }

    public static void Add(this List<Customer> genericList, int id, string name, OrderCollection orders) => genericList.Add(new Customer(id, name, orders));
}

internal class Complexe
{
    public double real;
    public double imaginary;
}

public class Customer(int id, string name, OrderCollection orders)
{
    public int Id { get; set; } = id;
    public string Name { get; set; } = name;
    public OrderCollection Orders { get; set; } = orders;
}

public class Order(int id, int customerId, DateTime orderDate)
{
    public int Id { get; set; } = id;
    public int CustomerId { get; set; } = customerId;
    public DateTime OrderDate { get; set; } = orderDate;
}

public class OrderCollection: IEnumerable<Order>
{
    private readonly List<Order> items = [];

    public Order this[int index]
    {
        get => items[index];
        set => items[index] = value;
    }

    public void Add(int id, int customerID, DateTime orderDate) => items.Add(new Order(id, customerID, orderDate));

    public IEnumerator<Order> GetEnumerator() => items.GetEnumerator();

    public IEnumerator GetEnumerator1() => GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator1();
}
