using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        static event EventHandler SomeEvent;

        static void Main()
        {
            SomeEvent += Program_SomeEvent;
            SomeEvent(null, null);
        }

        static async void Program_SomeEvent(object sender, EventArgs e)
        {
            await new Awaitable();
        }
    }

    class Awaitable
    {
        public Awaiter GetAwaiter()
        {
            return new Awaiter();
        }
    }

    class Awaiter : INotifyCompletion
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
}
