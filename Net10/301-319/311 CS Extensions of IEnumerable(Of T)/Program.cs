// 311 CS Extensions of IEnumerable(Of T)
//
// 2012-03-03   PV
// 2021-09-20	PV		VS2022; Net6
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12
// 2024-11-15	PV		Net9 C#13
// 2026-01-19	PV		Net10 C#14

using System.Linq;

namespace CS311;

internal class Program
{
    private static void Main(string[] args)
    {
        var r = Enumerable.Range(10, 10).DoubleListe();
        r.WriteLine();
    }
}
