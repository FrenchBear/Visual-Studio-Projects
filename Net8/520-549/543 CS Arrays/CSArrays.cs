// 543 CS Arrays
// Play with arrays in C#
//
// 2016-08-05   PV
// 2021-09-26   PV      VS2022; Net6
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12

using static System.Console;

namespace ConsoleApplication3;

internal class CSArrays
{
    private static void Main(string[] args)
    {
        var mat3 = new int[2, 3, 4];
        var jag2 = new int[2][] { [1, 2, 3], [4, 5, 6, 7, 8, 9] };

        Write($"mat3: {mat3.Length} = ");
        for (var i = 0; i < mat3.Rank; i++)
        {
            if (i > 0)
                Write(" * ");
            Write(mat3.GetLength(i));
        }
        WriteLine();

        mat3[1, 1, 1] = 111;
        mat3[0, 1, 2] = 12;
        foreach (var m in mat3)
            Write($"{m} ");
        WriteLine();

        Write($"jag2: {jag2.Length}: ");
        for (var i = 0; i < jag2.Length; i++)
        {
            Write($"[{i}] = {jag2[i].Length}  ");
        }
        WriteLine();
    }
}
