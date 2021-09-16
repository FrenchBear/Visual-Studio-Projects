// 424 CS Delegates Contravariance
// 2012-04-06   PV  Simple example of contravariance in delegates:
//                  allow the use of a delegate with less derived arguments than in its definition

using System;

#pragma warning disable IDE0051 // Remove unused private members
#pragma warning disable IDE0059 // Unnecessary assignment of a value

namespace CS424
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Action<Vehicle> maintenanceAction;

            maintenanceAction = VehicleMaintenance;             // "Normal" case
            maintenanceAction = ContraptionMaintenance;         // Contravariance use here, delegate use a less derived type
            //maintenanceAction = InflateBicycleTires;          // Not permitted, delegate can access members only present in Bicycle;

            var v = new Vehicle();
            maintenanceAction(v);

            Console.WriteLine();
            Console.Write("(Pause)");
            Console.ReadLine();
        }

        private static void ContraptionMaintenance(Contraption c)
        {
            Console.WriteLine("ContraptionMaintenance on {0}", c.GetType().ToString());
            // Can only access Contraption members
            c.ContraptionField = 0;
        }

        private static void VehicleMaintenance(Vehicle v)
        {
            Console.WriteLine("VehicleMaintenance on {0}", v.GetType().ToString());
            v.ContraptionField = 0;
            v.VehicleField = 0;
        }

        private static void BicycleMaintenance(Bicycle b)
        {
            Console.WriteLine("BicycleMaintenance on {0}", b.GetType().ToString());
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
}