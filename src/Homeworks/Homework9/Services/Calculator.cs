using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;

namespace WebApplication.Services
{
    public class Calculator : ICalculator
    {
        private static readonly string[] operations = {"+", "-", "*", "/"};

        private static readonly Dictionary<string, int> priorities = new()
        {
            {"+", 2},
            {"-", 2},
            {"*", 4},
            {"/", 4},
            {"(", 0}
        };

        private static readonly Dictionary<string, ExpressionType> expressionTypes = new()
        {
            {"+", ExpressionType.Add},
            {"-", ExpressionType.Subtract},
            {"*", ExpressionType.Multiply},
            {"/", ExpressionType.Divide}
        };

        public string CalculateExpression(string expression)
        {
            var convertedExpression = TryConvertStringToExpression(expression);
            var res = new CalculatorExpression().CalculateExpression((BinaryExpression)convertedExpression);
            return res.ToString(CultureInfo.InvariantCulture);
        }

        private Expression TryConvertStringToExpression(string expression)
        {
            var stackValues = new Stack<Expression>();
            var stackOperations = new Stack<string>();
            var parsedStr = expression.Split(" ");
            foreach (var param in parsedStr)
            {
                if (operations.Contains(param))
                    AddOperations(param, stackValues, stackOperations);
                else if (param[0] == '(')
                {
                    stackOperations.Push("(");
                    var num = param[1..];
                    stackValues.Push(Expression.Constant(double.Parse(num), typeof(double)));
                }
                else if (param.Last() == ')')
                {
                    stackValues.Push(Expression.Constant(double.Parse(param[..^1]), typeof(double)));
                    TakeOperation(stackValues, stackOperations);
                }
                else if (double.TryParse(param, out var num))
                    stackValues.Push(Expression.Constant(num, typeof(double)));
                else
                    throw new Exception("Че то случилось");
            }

            CalculateLast(stackValues, stackOperations);

            return stackValues.Pop();
        }

        private void AddOperations(string operation, Stack<Expression> stackValues, Stack<string> stackOperations)
        {
            while (stackOperations.Count > 0 && priorities[stackOperations.Peek()] >= priorities[operation])
            {
                var rightNode = stackValues.Pop();
                stackValues.Push(Expression.MakeBinary(expressionTypes[stackOperations.Pop()], stackValues.Pop(),
                    rightNode));
            }

            stackOperations.Push(operation);
        }

        private void TakeOperation(Stack<Expression> stackValues, Stack<string> stackOperations)
        {
            var operation = stackOperations.Pop();
            do
            {
                var rightNode = stackValues.Pop();
                stackValues.Push(Expression.MakeBinary(expressionTypes[operation], stackValues.Pop(), rightNode));
                operation = stackOperations.Pop();
            } while (stackOperations.Count > 0 && operation != "(");
        }

        private void CalculateLast(Stack<Expression> stackValues, Stack<string> stackOperations)
        {
            while (stackOperations.Count > 0)
            {
                var rightNode = stackValues.Pop();
                stackValues.Push(Expression.MakeBinary(expressionTypes[stackOperations.Pop()], stackValues.Pop(),
                    rightNode));
            }
        }
    }
    public class CalculatorExpression
    {
        public double CalculateExpression(Expression node)
        {
            switch (node.NodeType)
            {
                case ExpressionType.Constant:
                    return (double)((ConstantExpression) node).Value;
                default:
                    var binaryNode = (BinaryExpression) node;
                    return node.NodeType switch
                    {
                        ExpressionType.Add => CalculateExpression(binaryNode.Left) +
                                              CalculateExpression(binaryNode.Right),
                        ExpressionType.Subtract => CalculateExpression(binaryNode.Left) -
                                                   CalculateExpression(binaryNode.Right),
                        ExpressionType.Multiply => CalculateExpression(binaryNode.Left) *
                                                   CalculateExpression(binaryNode.Right),
                        ExpressionType.Divide => CalculateExpression(binaryNode.Left) /
                                                 CalculateExpression(binaryNode.Right),
                        _ => throw new Exception()
                    };
            }
        }
    }
}