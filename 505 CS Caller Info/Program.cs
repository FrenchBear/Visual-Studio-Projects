// 505 CS Caller Info
// Test with VS2012 to retrieve caller info in a function
// 2013-01-28   PV

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _505_CS_Caller_Info
{
    class Program
    {
        static void Main(string[] args)
        {
            TracedFunction(1);
            InternalFunction();
            var v = new InternalObject();

            Console.WriteLine();
            Console.Write("(Pause)");
            Console.ReadLine();
        }

        static void InternalFunction()
        {
            TracedFunction(2);
        }

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
            get { return _userName; }
            set
            {
                _userName = value;
                RaisePropertyChanged();  // no more RaisePropertyChanged(“UserName”)!   
            }
        }

        protected void RaisePropertyChanged([CallerMemberName] string member = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(member));
            }
        }
        // ========================================
    }

    public class InternalObject
    {
        public InternalObject()
        {
            Program.TracedFunction(3);
        }
    }

}
