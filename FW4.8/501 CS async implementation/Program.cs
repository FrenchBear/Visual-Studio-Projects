using System;
using System.Runtime.CompilerServices;

namespace ConsoleApplication2
{
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
        public Awaiter GetAwaiter() => new Awaiter();
    }

    internal class Awaiter : INotifyCompletion
    {
        public bool BeginAwait(Action continuation) => false;

        public int EndAwait() => 1;

        public bool IsCompleted => true;

        public int GetResult() => 1;

        public void OnCompleted(Action continuation) => throw new NotImplementedException();
    }
}