// 424 CS Delegates Contravariance
//
// 2012-04-06   PV  Simple example of contravariance in delegates:
//                  allow the use of a delegate with less derived arguments than in its definition
// 2021-09-23   PV  VS2022; Net6
// 2023-01-10	PV		Net7

using System;
using static System.Console;

#pragma warning disable IDE0051 // Remove unused private members
#pragma warning disable IDE0059 // Unnecessary assignment of a value

namespace CS424;

internal class Program
{
    private static void Main(string[] args)
    {
        var maintenanceAction = VehicleMaintenance;             // "Normal" case
        maintenanceAction = ContraptionMaintenance;         // Contravariance use here, delegate use a less derived type
        //maintenanceAction = InflateBicycleTires;          // Not permitted, delegate can access members only present in Bicycle;

        var v = new Vehicle();
        maintenanceAction(v);
    }

    private static void ContraptionMaintenance(Contraption c)
    {
        WriteLine("ContraptionMaintenance on {0}", c.GetType());
        // Can only access Contraption members
        c.ContraptionField = 0;
    }

    private static void VehicleMaintenance(Vehicle v)
    {
        WriteLine("VehicleMaintenance on {0}", v.GetType());
        v.ContraptionField = 0;
        v.VehicleField = 0;
    }

    private static void BicycleMaintenance(Bicycle b)
    {
        WriteLine("BicycleMaintenance on {0}", b.GetType());
        // Can access Contraption, Vehicle and Bicycle members
        b.ContraptionField = 0;
        b.VehicleField = 0;
        b.BicycleField = 0;
    }
}

internal class Contraption
{
    public int ContraptionField;
}

internal class Vehicle : Contraption
{
    public int VehicleField;
}

internal class Bicycle : Vehicle
{
    public int BicycleField;
}
