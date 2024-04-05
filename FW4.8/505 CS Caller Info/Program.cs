// 505 CS Caller Info
// Test with VS2012 to retrieve caller info in a function
// 2013-01-28   PV

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

#pragma warning disable IDE0059 // Unnecessary assignment of a value

namespace _505_CS_Caller_Info
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            TracedFunction(1);
            InternalFunction();
            var v = new InternalObject();

            Console.WriteLine();
            Console.Write("(Pause)");
            Console.ReadLine();
        }

        private static void InternalFunction() => TracedFunction(2);

        public static void TracedFunction(int i,
                                          [CallerMemberName] string memberName = "",
                                          [CallerFilePath] string sourceFilePath = "",
                                          [CallerLineNumber] int sourceLineNumber = 0)
        {
            Console.WriteLine("member name: " + memberName);
            Console.WriteLine("source file path: " + sourceFilePath);
            Console.WriteLine("source line number: " + sourceLineNumber);
            Console.WriteLine(i);
            Console.WriteLine();
        }

        // ========================================
        // Practical use for WPF Properties
        private string _userName;

        public event PropertyChangedEventHandler PropertyChanged;

        public string UserName
        {
            get => _userName;
            set
            {
                _userName = value;
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
}