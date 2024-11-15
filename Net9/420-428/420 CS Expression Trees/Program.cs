﻿// 420 CS Expression Trees
// http://msdn.microsoft.com/en-us/library/bb397951(v=vs.110).aspx
//
// 2012-03-04   PV
// 2021-09-23	PV		VS2022; Net6
// 2023-01-10	PV		Net7
// 2023-11-18	PV		Net8 C#12
// 2024-11-15	PV		Net9 C#13

using System;
using System.Diagnostics;
using System.Linq.Expressions;
using static System.Console;

namespace CS420;

internal class Program
{
    private static void Main(string[] args)
    {
        Expression<Func<int, int>> Signe = x => x == 0 ? 0 : x > 0 ? 1 : -1;

        // Decompose the expression tree.
        var param = Signe.Parameters[0];
        var operation = (ConditionalExpression)Signe.Body;
        var test = (BinaryExpression)operation.Test;
        var ifTrue = (ConstantExpression)operation.IfTrue;
        var ifFalse = operation.IfFalse;
        /*
        ParameterExpression left = (ParameterExpression)operation.;
        ConstantExpression right = (ConstantExpression)operation.Right;
        */

        WriteLine("Decomposed expression: {0} => {1} ? {2} : {3}",
            param.Name, test, ifTrue, ifFalse);

        var SigneCompiled = Signe.Compile();
        var s1 = SigneCompiled(3);
        var s2 = SigneCompiled(0);
        var s3 = SigneCompiled(-7);

        /* Does not work...
        Expression<Func<long, long>> Factorial1 = x => x <= 2 ? x : x * Factorial1(x - 1);
        Expression<Func<long, long>> Factorial2 = delegate(long x)
                                                    {
                                                        long res = 1;
                                                        for (int i = 2; i < x; i++)
                                                            res *= i;
                                                        return res;
                                                    };
        */

        // Creating a parameter expression.
        var value = Expression.Parameter(typeof(int), "value");

        // Creating an expression to hold a local variable.
        var result = Expression.Parameter(typeof(int), "result");

        // Creating a label to jump to from a loop.
        var label = Expression.Label(typeof(int));

        // Creating a method body.
        var block = Expression.Block(
            // Adding a local variable.
            [result],
            // Assigning a constant to a local variable: result = 1
            Expression.Assign(result, Expression.Constant(1)),
            // Adding a loop.
            Expression.Loop(
                // Adding a conditional block into the loop.
                Expression.IfThenElse(
                    // Condition: value > 1
                    Expression.GreaterThan(value, Expression.Constant(1)),
                    // If true: result *= value --
                    Expression.MultiplyAssign(result,
                        Expression.PostDecrementAssign(value)),
                    // If false, exit the loop and go to the label.
                    Expression.Break(label, result)
                ),
                // Label to jump to.
                label
            )
        );

        var factorialTree = Expression.Lambda<Func<int, int>>(block, value);

        // Compile and execute an expression tree.
        var factorial = Expression.Lambda<Func<int, int>>(block, value).Compile()(5);

        WriteLine(factorial);

        Debugger.Break();
    }
}
