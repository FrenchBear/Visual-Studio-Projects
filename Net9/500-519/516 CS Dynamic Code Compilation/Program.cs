// 516 CS Dynamic Code Compilation
// Test of compilation and execution at run-time
// http://stackoverflow.com/questions/3188882/compile-and-run-dynamic-code-without-generating-exe
// https://stackoverflow.com/questions/826398/is-it-possible-to-dynamically-compile-and-execute-c-sharp-code-fragments
//
// 2013-09-15   PV
// 2021-09-26   PV      CSharpCodeProvider is obsolete on .Net Core, should be raplaced by Roslyn (https://www.nuget.org/packages/Microsoft.CodeAnalysis.CSharp)
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12
// 2024-04-05   PV      Using Roselyn, old code using System.CodeDom.Compiler is definitely obsolete (source: 2nd http reference)
// 2024-11-15	PV		Net9 C#13

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Emit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

internal class Program
{
    private static void Main(string[] args)
    {
        SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(@"using System.Linq;
            namespace DynamicCodeTest;
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
            }");

        // define other necessary objects for compilation
        string assemblyName = Path.GetRandomFileName();
        MetadataReference[] references =
        [
                MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
                MetadataReference.CreateFromFile(typeof(Enumerable).Assembly.Location)
        ];

        // analyse and generate IL code from syntax tree
        var compilation = CSharpCompilation.Create(
            assemblyName,
            syntaxTrees: [syntaxTree],
            references: references,
            options: new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

        using var ms = new MemoryStream();

        // write IL code into memory
        EmitResult result = compilation.Emit(ms);

        if (!result.Success)
        {
            // handle exceptions
            IEnumerable<Diagnostic> failures = result.Diagnostics.Where(diagnostic =>
                diagnostic.IsWarningAsError ||
                diagnostic.Severity == DiagnosticSeverity.Error);

            foreach (Diagnostic diagnostic in failures)
            {
                Console.Error.WriteLine("{0}: {1}", diagnostic.Id, diagnostic.GetMessage());
            }
        }
        else
        {
            // load this 'virtual' DLL so that we can use
            ms.Seek(0, SeekOrigin.Begin);
            var assembly = Assembly.Load(ms.ToArray());

            // create instance of the desired class and call the desired function
            Type type = assembly.GetType("DynamicCodeTest.Program");
            object obj = Activator.CreateInstance(type);
            var res = type.InvokeMember("Moyenne",
                BindingFlags.Default | BindingFlags.InvokeMethod,
                null,
                obj,
                [new Double[] { 5, 12 }]);
            Console.WriteLine($"Moyenne(5,12) = {res}");
        }
    }
}
