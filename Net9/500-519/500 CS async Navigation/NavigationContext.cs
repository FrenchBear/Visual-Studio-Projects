﻿// 2021-09-26   PV      VS2022; Net6
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12
// 2024-11-15	PV		Net9 C#13

using System.Threading.Tasks;
using System.Windows;

namespace CS500;

public interface INavigationContext<T, TResult> where T : UIElement
{
    Task<TResult> WaitForContinuationTask();

    T UIelement { get; }

    void Continuer(TResult returnValue);
}

// NavigationContext is implemented only one time, and a provider will give easy access
// (similar to the relation between IEnumerator and IEnumerable)
public class NavigationContext<T, TResult>(T element): INavigationContext<T, TResult> where T : UIElement
{

    // object behind "awaited tasks", maintains thread status for awaited tasks
    private TaskCompletionSource<TResult> cts;

    // Task<TResult> is awaitable
    public Task<TResult> WaitForContinuationTask()
    {
        cts = new TaskCompletionSource<TResult>();
        return cts.Task;
    }

    public T UIelement { get; } = element;

    public void Continuer(TResult returnValue) =>
        // terminates the task and return a result, freeing waiting contexts
        cts.SetResult(returnValue);
}

public interface INavigationContextProvider<T, TResult> where T : UIElement
{
    INavigationContext<T, TResult> GetNavigationContext();
}

// Trick: simple class to enable type inference by C# compiler on NavigationContext<T, TResult>
public class NavigationContext<TResult>
{
    // Since class is generic<TResult> and method is generic<T>, that means that actually
    // this method is generic <T, TResult>
#pragma warning disable CA1000 // Do not declare static members on generic types
    public static INavigationContext<T, TResult> Create<T>(T element) where T : UIElement => new NavigationContext<T, TResult>(element);
#pragma warning restore CA1000 // Do not declare static members on generic types
}

public enum NavigationResult
{
    Home,
    GoBackward,
    GoForward
}
