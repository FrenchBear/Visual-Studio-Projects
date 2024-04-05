// 402 VB Initializers
// New possibilities in .Net Framework 4 to intialize objects and collections
// 2010-02-24 FPVI

using System;
using System.Collections;
using System.Collections.Generic;

#pragma warning disable IDE0059 // Unnecessary assignment of a value

// For extension method
internal static class Module1
{
    public static void Main()
    {
        // Object initializer (with)
        var z1 = new Complexe
        {
            real = 2.3,
            imaginary = 3.5
        };

        // Collection initializer (from)
        var ls = new List<string> {
            "Once",
            "upon",
            "a",
            "time",
            "was",
            "a",
            "fairy"
        };

        // Both collection initializer and object initializer
        var lc = new List<Complexe> {
            new Complexe {
                real = 0,
                imaginary = 0
            },
            new Complexe {
                real = 3.2,
                imaginary = 1.7
            },
            z1
        };

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

        Console.WriteLine();
        Console.WriteLine("(Pause)");
        Console.ReadLine();
    }

    public static void Add(this List<Customer> genericList, int id, string name, OrderCollection orders) => genericList.Add(new Customer(id, name, orders));
}

internal class Complexe
{
    public double real;
    public double imaginary;
}

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public OrderCollection Orders { get; set; }

    public Customer(int id, string name, OrderCollection orders)
    {
        Id = id;
        Name = name;
        Orders = orders;
    }
}

public class Order
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public DateTime OrderDate { get; set; }

    public Order(int id, int customerId, DateTime orderDate)
    {
        Id = id;
        CustomerId = customerId;
        OrderDate = orderDate;
    }
}

public class OrderCollection : IEnumerable<Order>
{
    private readonly List<Order> items = new List<Order>();

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