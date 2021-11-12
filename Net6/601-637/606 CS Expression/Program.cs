// CS606 Expression
// Playing around Expressions and Visitors
//
// 2017-01-14   PV
// 2021-09-26   PV      VS2022; Net6

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using static System.Console;

namespace ExpressionApp;

internal class Program
{
    private static void Main(string[] args)
    {
        //Expression<Func<int, int, int>> e2 = (x, y) => (x - y + (x > y ? 1 : -1)) / (x * x * x + 2 * -x * y);
        Expression<Func<int, int, int>> e2 = (x, y) => x + 2 * -y;
        MyVisitor mv = new();

        _ = mv.VisiteExpression(e2);

        // A parameter for the lambda expression.
        ParameterExpression paramExpr = Expression.Parameter(typeof(int), "arg");

        // This expression represents a lambda expression that adds 1 to the parameter value.
        LambdaExpression lambdaExpr = Expression.Lambda(
            Expression.Add(
                paramExpr,
                Expression.Constant(1)
            ),
            new List<ParameterExpression>() { paramExpr }
        );

        Console.WriteLine();
        Console.WriteLine(lambdaExpr);
        Console.WriteLine(lambdaExpr.Compile().DynamicInvoke(1));

        ParameterExpression paramX = Expression.Parameter(typeof(int), "x");
        ParameterExpression paramY = Expression.Parameter(typeof(int), "y");
        lambdaExpr = Expression.Lambda(
            Expression.AddChecked(
                paramX,
                Expression.MultiplyChecked(
                    Expression.Constant(2),
                    paramY
                )
            ),
            new List<ParameterExpression>() { paramX, paramY }
        );

        Console.WriteLine();
        Console.WriteLine(lambdaExpr);
        _ = mv.VisiteExpression(lambdaExpr);
        // Raises an exception
        //Console.WriteLine(lambdaExpr.Compile().DynamicInvoke(1<<30, 1<<30));
    }
}

public class MyVisitor : ExpressionVisitor
{
    public Expression VisiteExpression(Expression expression)
    {
        Write("VisiteExpression: ");
        Console.WriteLine(expression);
        return Visit(expression);
    }

    private int s = 0;

    private void PrintLine(string st) => Console.WriteLine(new string(' ', 4 * s) + st);

    protected override MemberMemberBinding VisitMemberMemberBinding(MemberMemberBinding node)
    {
        PrintLine($"MemberMemberBinding {node}");
        s++; var v = base.VisitMemberMemberBinding(node); s--; return v;
    }

    protected override SwitchCase VisitSwitchCase(SwitchCase node)
    {
        PrintLine($"SwitchCase {node}");
        s++; var v = base.VisitSwitchCase(node); s--; return v;
    }

    protected override CatchBlock VisitCatchBlock(CatchBlock node)
    {
        PrintLine($"CatchBlock {node}");
        s++; var v = base.VisitCatchBlock(node); s--; return v;
    }

    protected override ElementInit VisitElementInit(ElementInit node)
    {
        PrintLine($"ElementInit {node}");
        s++; var v = base.VisitElementInit(node); s--; return v;
    }

    protected override LabelTarget VisitLabelTarget(LabelTarget node)
    {
        PrintLine($"LabelTarget {node}");
        s++; var v = base.VisitLabelTarget(node); s--; return v;
    }

    protected override MemberAssignment VisitMemberAssignment(MemberAssignment node)
    {
        PrintLine($"MemberAssignment {node}");
        s++; var v = base.VisitMemberAssignment(node); s--; return v;
    }

    protected override MemberBinding VisitMemberBinding(MemberBinding node)
    {
        PrintLine($"MemberBinding {node}");
        s++; var v = base.VisitMemberBinding(node); s--; return v;
    }

    protected override MemberListBinding VisitMemberListBinding(MemberListBinding node)
    {
        PrintLine($"MemberListBinding {node}");
        s++; var v = base.VisitMemberListBinding(node); s--; return v;
    }

    protected override Expression VisitBinary(BinaryExpression node)
    {
        PrintLine($"Binary {node.NodeType} {node} -> {node.Type}");
        //WriteLine($"Binary {node.NodeType}  |  {node.Left}  |  {node.Right}");
        s++; var v = base.VisitBinary(node); s--; return v;
    }

    protected override Expression VisitBlock(BlockExpression node)
    {
        PrintLine($"Block {node}");
        s++; var v = base.VisitBlock(node); s--; return v;
    }

    protected override Expression VisitConditional(ConditionalExpression node)
    {
        PrintLine($"Conditional {node}");
        s++; var v = base.VisitConditional(node); s--; return v;
    }

    protected override Expression VisitConstant(ConstantExpression node)
    {
        PrintLine($"Constant {node.Type} {node}");
        s++; var v = base.VisitConstant(node); s--; return v;
    }

    protected override Expression VisitDebugInfo(DebugInfoExpression node)
    {
        PrintLine($"DebugInfo {node}");
        s++; var v = base.VisitDebugInfo(node); s--; return v;
    }

    protected override Expression VisitDefault(DefaultExpression node)
    {
        PrintLine($"Default {node}");
        s++; var v = base.VisitDefault(node); s--; return v;
    }

    protected override Expression VisitDynamic(DynamicExpression node)
    {
        PrintLine($"Dynamic {node}");
        s++; var v = base.VisitDynamic(node); s--; return v;
    }

    protected override Expression VisitExtension(Expression node)
    {
        PrintLine($"Extension {node}");
        s++; var v = base.VisitExtension(node); s--; return v;
    }

    protected override Expression VisitGoto(GotoExpression node)
    {
        PrintLine($"Goto {node}");
        s++; var v = base.VisitGoto(node); s--; return v;
    }

    protected override Expression VisitIndex(IndexExpression node)
    {
        PrintLine($"Index {node}");
        s++; var v = base.VisitIndex(node); s--; return v;
    }

    protected override Expression VisitInvocation(InvocationExpression node)
    {
        PrintLine($"Invocation {node}");
        s++; var v = base.VisitInvocation(node); s--; return v;
    }

    protected override Expression VisitLabel(LabelExpression node)
    {
        PrintLine($"Label {node}");
        s++; var v = base.VisitLabel(node); s--; return v;
    }

    protected override Expression VisitLambda<T>(Expression<T> node)
    {
        PrintLine($"Lambda<{typeof(T)}> {node}");
        s++; var v = base.VisitLambda(node); s--; return v;
    }

    protected override Expression VisitListInit(ListInitExpression node)
    {
        PrintLine($"ListInit {node}");
        s++; var v = base.VisitListInit(node); s--; return v;
    }

    protected override Expression VisitLoop(LoopExpression node)
    {
        PrintLine($"Loop {node}");
        s++; var v = base.VisitLoop(node); s--; return v;
    }

    protected override Expression VisitMember(MemberExpression node)
    {
        PrintLine($"Member {node}");
        s++; var v = base.VisitMember(node); s--; return v;
    }

    protected override Expression VisitMemberInit(MemberInitExpression node)
    {
        PrintLine($"MemberInit {node}");
        s++; var v = base.VisitMemberInit(node); s--; return v;
    }

    protected override Expression VisitMethodCall(MethodCallExpression node)
    {
        PrintLine($"MethodCall {node}");
        s++; var v = base.VisitMethodCall(node); s--; return v;
    }

    protected override Expression VisitNew(NewExpression node)
    {
        PrintLine($"New {node}");
        s++; var v = base.VisitNew(node); s--; return v;
    }

    protected override Expression VisitNewArray(NewArrayExpression node)
    {
        PrintLine($"NewArray {node}");
        s++; var v = base.VisitNewArray(node); s--; return v;
    }

    protected override Expression VisitParameter(ParameterExpression node)
    {
        PrintLine($"Parameter {node.Type} {node}");
        s++; var v = base.VisitParameter(node); s--; return v;
    }

    protected override Expression VisitRuntimeVariables(RuntimeVariablesExpression node)
    {
        PrintLine($"RuntimeVariables {node}");
        s++; var v = base.VisitRuntimeVariables(node); s--; return v;
    }

    protected override Expression VisitSwitch(SwitchExpression node)
    {
        PrintLine($"Switch {node}");
        s++; var v = base.VisitSwitch(node); s--; return v;
    }

    protected override Expression VisitTry(TryExpression node)
    {
        PrintLine($"Try {node}");
        s++; var v = base.VisitTry(node); s--; return v;
    }

    protected override Expression VisitTypeBinary(TypeBinaryExpression node)
    {
        PrintLine($"TypeBinary {node}");
        s++; var v = base.VisitTypeBinary(node); s--; return v;
    }

    protected override Expression VisitUnary(UnaryExpression node)
    {
        PrintLine($"Unitary {node.NodeType} {node} -> {node.Type}");
        s++; var v = base.VisitUnary(node); s--; return v;
    }
}