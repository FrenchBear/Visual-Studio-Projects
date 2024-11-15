// 2021-09-26   PV      VS2022; Net6
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12
// 2024-11-15	PV		Net9 C#13

using System;
using System.Runtime.CompilerServices;

#pragma warning disable CA1822 // Mark members as static

namespace CS501;

internal class Program
{
    private static event EventHandler SomeEvent;

    private static void Main()
    {
        SomeEvent += Program_SomeEvent;
        SomeEvent(null, null);
    }

    private static async void Program_SomeEvent(object sender, EventArgs e) => await new Awaitable();
}

internal class Awaitable
{
    public Awaiter GetAwaiter() => new();
}

internal class Awaiter: INotifyCompletion
{
    public bool BeginAwait(Action continuation) => false;

    public int EndAwait() => 1;

    public bool IsCompleted => true;

    public int GetResult() => 1;

    public void OnCompleted(Action continuation) => throw new NotImplementedException();
}
