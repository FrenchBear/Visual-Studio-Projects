// VS 2015 What's New
// 2015-07-22   PC

using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;                // Using Static

namespace CS532
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // String interpolation and nameof
            WriteLine($"{nameof(ThreeTimes)}(1234) = {ThreeTimes(1234)}");

            // Dictionary initializer
            Dictionary<string, Person> directory = new Dictionary<string, Person>
            {
                ["Pierre"] = new Person { FirstName = "Pierre", LastName = "Violent" }
            };

            // Null-conditional operators ?[ and ?. (note that ?[ is useless on a dictionary since it'll raise an exception if the index does not exist...)
            int? i = directory?["Pierre"].Company?.Length;

            string jsonText = @"{
                'ForegroundColor': {
                    'Error': 'Red',
                    'Warning': 'Red',
                    'Normal': 'Yellow',
                    'Verbose': 'White'
                    }
                }";

            JObject consoleColorConfiguration = JObject.Parse(jsonText);
            // Null-conditional operator ?[ since JSon indexer does not raise an exception
            string colorText = consoleColorConfiguration?["ForegroundColor"]?["Normal"]?.Value<string>();
            ConsoleColor color;
            if (Enum.TryParse<ConsoleColor>(colorText, out color))
                Console.ForegroundColor = color;

            Console.WriteLine();
            Console.Write("(Pause)");
            Console.ReadLine();
        }

        // Single expression (lambda) function body
        private static double ThreeTimes(double x) => 3 * x;
    }

    public struct Person
    {
        /*
        public Person() :
            this("", "", "")
        {
        }
        */

        public Person(string first, string last, string company)
        {
            FirstName = first;
            LastName = last;
            Company = company;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
    }
}