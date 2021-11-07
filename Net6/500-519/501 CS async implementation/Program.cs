// 2021-09-26   PV      VS2022; Net6

using System;
using System.Runtime.CompilerServices;

#pragma warning disable CA1822 // Mark members as static

namespace ConsoleApplication2;

internal class Program
{
    private static event EventHandler SomeEvent;

    private static void Main()
    {
        SomeEvent += Program_SomeEvent;
        SomeEvent(null, null);
    }

    private static async void Program_SomeEvent(object sender, EventArgs e)
    {
        await new Awaitable();
    }
}

internal class Awaitable
{
    public Awaiter GetAwaiter()
    {
        return new Awaiter();
    }
}

internal class Awaiter : INotifyCompletion
{
    public bool BeginAwait(Action continuation)
    {
        return false;
    }

    public int EndAwait()
    {
        return 1;
    }

    public bool IsCompleted
    {
        get { return true; }
    }

    public int GetResult()
    {
        return 1;
    }

    public void OnCompleted(Action continuation)
    {
        throw new NotImplementedException();
    }
}