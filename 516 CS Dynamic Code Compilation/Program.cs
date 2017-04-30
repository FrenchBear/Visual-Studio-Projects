// 516 CS Dynamic Code Compilation
// Test of compilation and execution at run-time
// http://stackoverflow.com/questions/3188882/compile-and-run-dynamic-code-without-generating-exe
// http://stackoverflow.com/questions/826398/is-it-possible-to-dynamically-compile-and-execute-c-sharp-code-fragments
// 2013-09-15   PV

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Reflection;

class Program
{
    static void Main(string[] args)
    {
        // v4.0 actually means 4.5, see http://stackoverflow.com/questions/13253967/how-to-target-net-4-5-with-csharpcodeprovider

        using (CSharpCodeProvider csc = new Microsoft.CSharp.CSharpCodeProvider(new Dictionary<string, string>() { { "CompilerVersion", "v4.0" } }))
        {
            string source = @"using System.Linq;
            public class Program {
              public double Moyenne(double[] args) {
                double s=0.0;
                int n=0;
                foreach(double d in args)
                {
                  s+=d;
                  n++;
                }
                return s/n;
              }
            }";

            var parameters = new CompilerParameters(new[] { "mscorlib.dll", "System.Core.dll" }, @"c:\temp\foo.dll", false);
            //parameters.GenerateInMemory = true;
            var res = csc.CompileAssemblyFromSource(parameters, source);

            Console.WriteLine(res.PathToAssembly);
            Console.WriteLine();

            res.Errors.Cast<CompilerError>().ToList().ForEach(error => Console.WriteLine(error.ErrorText));

            Type type = res.CompiledAssembly.GetType("Program");
            var obj = Activator.CreateInstance(type);
            MethodInfo methodInfo = type.GetMethod("Moyenne");
            object[] parametersArray = new object[]
            {
                new double[] { 2,3,5,7,11}
            };
            var output = methodInfo.Invoke(obj, parametersArray);

            Console.WriteLine("r={0}", output);
        }

        Console.WriteLine();
        Console.Write("(Pause)");
        Console.ReadLine();
    }
}