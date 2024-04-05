// 203 CS Simple Event
// Simple example of class providing an event
// 2013-09-02   PV

using System;

namespace CS203
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var c1 = new Car("Car 1");
            var c2 = new Car("Car 2");

            c1.EngineStartedEvent += Car_EngineStartedEvent;
            c1.EngineStoppedEvent += Car_EngineStoppedEvent;
            c2.EngineStateChangedEvent += Car_EngineStateChangedEvent;

            c1.Start();
            c2.Start();
            c1.Stop();
            c2.Stop();

            c2.EngineStateChangedEvent -= Car_EngineStateChangedEvent;

            c1.Start();
            c2.Start();
            c1.Stop();
            c2.Stop();

            Console.WriteLine();
            Console.Write("(Pause)");
            Console.ReadLine();
        }

        private static void Car_EngineStartedEvent(object sender, EngineStateChangedEventArgs e) => Console.WriteLine("{0} engine started on {1}", (sender as Car).Name, e.StateChangedOn);

        private static void Car_EngineStoppedEvent(object sender, EngineStateChangedEventArgs e) => Console.WriteLine("{0} engine stopped on {1}", (sender as Car).Name, e.StateChangedOn);

        private static void Car_EngineStateChangedEvent(object sender, EngineStateChangedEventArgs e) => Console.WriteLine("{0} engine state changed on {1}, IsEngineOn={2}", (sender as Car).Name, e.StateChangedOn, (sender as Car).IsEngineOn);
    }

    public class EngineStateChangedEventArgs : EventArgs
    {
        public EngineStateChangedEventArgs(DateTime stateChangedOn) => StateChangedOn = stateChangedOn;

        public DateTime StateChangedOn { get; private set; }
    }

    public class Car
    {
        // --------------------------------------------
        // Construction

        public Car(string name) => Name = name;

        // --------------------------------------------
        // Event support

        // Signature of the event
        // Note that it can be not declared and replaced by EventHandler<EngineStateChangedEventArgs> when used
        public delegate void EngineStateChangedEventHandler(object sender, EngineStateChangedEventArgs e);

        // Declare the event
        public event EngineStateChangedEventHandler EngineStateChangedEvent;

        public event EventHandler<EngineStateChangedEventArgs> EngineStartedEvent;

        public event EventHandler<EngineStateChangedEventArgs> EngineStoppedEvent;

        // Mechanism raising the event that can be overridden in a derived class
        // Here to simplify we raise all three events
        protected virtual void OnEngineStateChanged(EngineStateChangedEventArgs args)
        {
            EngineStateChangedEvent?.Invoke(this, args);
            if (isEngineOn && EngineStartedEvent != null)
                EngineStartedEvent(this, args);
            if (!isEngineOn && EngineStoppedEvent != null)
                EngineStoppedEvent(this, args);
        }

        // --------------------------------------------
        // Some properties

        public string Name { get; private set; }

        private bool isEngineOn = false;

        public bool IsEngineOn
        {
            get => isEngineOn;
            set
            {
                if (isEngineOn != value)
                {
                    isEngineOn = value;
                    OnEngineStateChanged(new EngineStateChangedEventArgs(DateTime.Now));
                }
            }
        }

        // --------------------------------------------
        // Some methods

        public void Start() => IsEngineOn = true;

        public void Stop() => IsEngineOn = false;
    }
}