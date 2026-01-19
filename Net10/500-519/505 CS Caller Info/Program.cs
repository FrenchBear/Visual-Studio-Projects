// 505 CS Caller Info
// Test with VS2012 to retrieve caller info in a function
//
// 2013-01-28   PV
// 2021-09-26   PV      VS2022; Net6
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12
// 2024-11-15	PV		Net9 C#13
// 2026-01-19	PV		Net10 C#14

using System.ComponentModel;
using System.Runtime.CompilerServices;
using static System.Console;

#pragma warning disable IDE0059 // Unnecessary assignment of a value

namespace CS505;

internal class Program
{
    private static void Main(string[] args)
    {
        TracedFunction(1);
        InternalFunction();
        var v = new InternalObject();
    }

    private static void InternalFunction() => TracedFunction(2);

    public static void TracedFunction(int i,
        [CallerMemberName] string memberName = "",
        [CallerFilePath] string sourceFilePath = "",
        [CallerLineNumber] int sourceLineNumber = 0)
    {
        WriteLine("member name: " + memberName);
        WriteLine("source file path: " + sourceFilePath);
        WriteLine("source line number: " + sourceLineNumber);
        WriteLine(i);
        WriteLine();
    }

    // ========================================
    // Practical use for WPF Properties

    public event PropertyChangedEventHandler PropertyChanged;

    public string UserName
    {
        get;
        set
        {
            field = value;
            RaisePropertyChanged();  // no more RaisePropertyChanged(“UserName”)!
        }
    }

    protected void RaisePropertyChanged([CallerMemberName] string member = "") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(member));

    // ========================================
}

public class InternalObject
{
    public InternalObject() => Program.TracedFunction(3);
}
