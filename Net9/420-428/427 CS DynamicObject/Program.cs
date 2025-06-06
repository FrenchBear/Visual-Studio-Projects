﻿// 427 CS DynamicObject
//
// 2021-09-23	PV		VS2022; Net6
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12
// 2024-11-15	PV		Net9 C#13

using System.Collections.Generic;
using System.Dynamic;
using static System.Console;

namespace CS427;

internal class Program
{
    private static void Main(string[] args)
    {
        // Creating a dynamic dictionary.
        dynamic person = new DynamicDictionary();

        // Adding new dynamic properties.
        // The TrySetMember method is called.
        person.FirstName = "Ellen";
        person.LastName = "Adams";

        // Getting values of the dynamic properties.
        // The TryGetMember method is called.
        // Note that property names are case-insensitive.

        WriteLine(person.firstname + " " + person.lastname);

        // Getting the value of the Count property.
        // The TryGetMember is not called,
        // because the property is defined in the class.
        WriteLine("Number of dynamic properties:" + person.Count);

        // The following statement throws an exception at run time.
        // There is no "address" property,
        // so the TryGetMember method returns false and this causes a
        // RuntimeBinderException.

        WriteLine(person.address);
    }
}

// The class derived from DynamicObject.
public class DynamicDictionary: DynamicObject
{
    // The inner dictionary.
    private readonly Dictionary<string, object> dictionary = [];

    // This property returns the number of elements
    // in the inner dictionary.

    public int Count => dictionary.Count;

    // If you try to get a value of a property
    // not defined in the class, this method is called.

    public override bool TryGetMember(GetMemberBinder binder, out object result)
    {
        // Converting the property name to lowercase
        // so that property names become case-insensitive.
        var name = binder.Name.ToLower();

        // If the property name is found in a dictionary,
        // set the result parameter to the property value and return true.
        // Otherwise, return false.
        return dictionary.TryGetValue(name, out result);
    }

    // If you try to set a value of a property that is
    // not defined in the class, this method is called.
    public override bool TrySetMember(SetMemberBinder binder, object value)
    {
        // Converting the property name to lowercase
        // so that property names become case-insensitive.
        dictionary[binder.Name.ToLower()] = value;

        // You can always add a value to a dictionary,
        // so this method always returns true.
        return true;
    }
}
