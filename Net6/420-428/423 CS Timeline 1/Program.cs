// 423 CS TimeLine 1
// Core classes for a time-based simulation
//
// 2012-03-09   PV  First version, after *years* of thinking about it...
// 2021-09-23   PV  VS2022; Net6

using System;
using System.Collections.Generic;
using static System.Console;

namespace CS423;

internal class Program
{
    private const int maxLevel = 10;

    private static void Main(string[] args)
    {
        var t = new Timeline();
        var e1 = new TimelineEvent("start", null);
        var e2 = new TimelineEvent("stop", null);
        t.AddRelativeEvent(1.0, e1);
        t.AddRelativeEvent(2.0, e2);

        var r = new Random();
        for (int i = 0; i < 4; i++)
        {
            int arrivalLevel = r.Next(maxLevel + 1);
            int destinationLevel;
            do
                destinationLevel = r.Next(maxLevel + 1);
            while (destinationLevel == arrivalLevel);

            var e = new UserArrivedEvent(arrivalLevel, destinationLevel, "user", null);
            t.AddAbsoluteEvent(Math.Round(r.NextDouble() * 30, 1), e);
        }

        t.TimedEvent += new Timeline.TimedEventHandler(TimedEvent);

        t.StartSimulation();
    }

    private static void TimedEvent(double absoluteTime, TimelineEvent e)
    {
        WriteLine("TimedEvent t={0}, e={1}", absoluteTime, e.Name);
        if (e is UserArrivedEvent uae)
        {
            WriteLine("User {0} arrived on level {1}, going to level {2}", uae.NumUser, uae.ArrivalLevel, uae.DestinationLevel);
        }
    }
}

internal class SortedQueue<TKey, TValue> : SortedList<TKey, TValue>
{
    public KeyValuePair<TKey, TValue> TakeFirst()
    {
        if (Count == 0)
            throw new InvalidOperationException("SortedQueue is empty");
        var kvp = new KeyValuePair<TKey, TValue>(Keys[0], Values[0]);
        RemoveAt(0);
        return kvp;
    }
}

internal class Timeline
{
    private readonly SortedQueue<double, TimelineEvent> tl = new();
    private double nowTime = 0.0;

    public delegate void TimedEventHandler(double absoluteTime, TimelineEvent e);

    public event TimedEventHandler TimedEvent;

    public void AddAbsoluteEvent(double absoluteTime, TimelineEvent e)
    {
        if (absoluteTime < nowTime)
            throw new InvalidOperationException("Can't add an event in the past");
        tl.Add(absoluteTime, e);
    }

    public void AddRelativeEvent(double relativeTime, TimelineEvent e) => AddAbsoluteEvent(relativeTime + nowTime, e);

    public void StartSimulation()
    {
        while (tl.Count > 0)
        {
            KeyValuePair<double, TimelineEvent> kvp = tl.TakeFirst();
            nowTime = kvp.Key;
            TimedEvent?.Invoke(kvp.Key, kvp.Value);
            kvp.Value.ExecuteAction(nowTime);
        }
    }
}

internal class TimelineEvent
{
    private readonly string _name;
    private readonly Action<double, TimelineEvent> _action;

    public TimelineEvent(string name, Action<double, TimelineEvent> action)
    {
        _name = name;
        _action = action;
    }

    public string Name => _name;

    public void ExecuteAction(double nowTime) => _action?.Invoke(nowTime, this);
}

internal class UserArrivedEvent : TimelineEvent
{
    private static int numUserSource;

    private readonly int numUser;
    private readonly int arrivalLevel;
    private readonly int destinationLevel;

    public UserArrivedEvent(int arrivalLevel, int destinationLevel, string name, Action<double, TimelineEvent> action) : base(name, action)
    {
        numUser = ++numUserSource;
        this.arrivalLevel = arrivalLevel;
        this.destinationLevel = destinationLevel;
    }

    public int NumUser => numUser;

    public int ArrivalLevel => arrivalLevel;

    public int DestinationLevel => destinationLevel;
}