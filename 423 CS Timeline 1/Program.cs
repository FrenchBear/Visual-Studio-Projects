// 423 CS TimeLine 1
// Core classes for a time-based simulation
// 2012-03-09   PV  First version, after *years* of thinking about it...

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CS423
{
    class Program
    {
        const int maxLevel = 10;
        static void Main(string[] args)
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

            t.TimedEvent += new Timeline.TimedEventHandler(t_TimedEvent);

            t.StartSimulation();

            Console.WriteLine();
            Console.Write("(Pause)");
            Console.ReadLine();
        }

        static void t_TimedEvent(double absoluteTime, TimelineEvent e)
        {
            Console.WriteLine("TimedEvent t={0}, e={1}", absoluteTime, e.name);
            UserArrivedEvent uae = e as UserArrivedEvent;
            if (uae != null)
            {
                Console.WriteLine("User {0} arrived on level {1}, going to level {2}", uae.NumUser, uae.ArrivalLevel, uae.DestinationLevel);
            }
        }

    }

    class SortedQueue<TKey, TValue> : SortedList<TKey, TValue>
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

    class Timeline
    {
        SortedQueue<double, TimelineEvent> tl = new SortedQueue<double, TimelineEvent>();
        double nowTime = 0.0;

        public delegate void TimedEventHandler(double absoluteTime, TimelineEvent e);
        public event TimedEventHandler TimedEvent;

        public void AddAbsoluteEvent(double absoluteTime, TimelineEvent e)
        {
            if (absoluteTime < nowTime)
                throw new InvalidOperationException("Can't add an event in the past");
            tl.Add(absoluteTime, e);
        }

        public void AddRelativeEvent(double relativeTime, TimelineEvent e)
        {
            AddAbsoluteEvent(relativeTime + nowTime, e);
        }

        public void StartSimulation()
        {
            while (tl.Count > 0)
            {
                KeyValuePair<double, TimelineEvent> kvp = tl.TakeFirst();
                nowTime = kvp.Key;
                if (TimedEvent != null)
                    TimedEvent(kvp.Key, kvp.Value);
                kvp.Value.ExecuteAction(nowTime);
            }
        }
    }



    class TimelineEvent
    {
        private string _name;
        private Action<double, TimelineEvent> _action;

        public TimelineEvent(string name, Action<double, TimelineEvent> action)
        {
            _name = name;
            _action = action;
        }

        public string name
        {
            get { return _name; }
        }

        public void ExecuteAction(double nowTime)
        {
            if (_action != null)
                _action(nowTime, this);
        }
    }

    class UserArrivedEvent : TimelineEvent
    {
        private static int numUserSource;

        private int numUser;
        private int arrivalLevel;
        private int destinationLevel;

        public UserArrivedEvent(int arrivalLevel, int destinationLevel, string name, Action<double, TimelineEvent> action) : base(name, action)
        {
            numUser = ++numUserSource;
            this.arrivalLevel = arrivalLevel;
            this.destinationLevel = destinationLevel;
        }

        public int NumUser
        {
            get { return numUser; }
        }

        public int ArrivalLevel
        {
            get { return arrivalLevel; }
        }

        public int DestinationLevel
        {
            get { return destinationLevel; }
        }
    }

}
