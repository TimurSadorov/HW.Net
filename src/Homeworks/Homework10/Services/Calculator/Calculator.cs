using System.Collections.Generic;
using System.Globalization;
using System.Linq.Expressions;

namespace WebApplication.Services.Calculator
{
    public class Calculator : ICalculator
    {
        private readonly Dictionary<string, int> _priorities = new()
        {
            {"+", 2},
            {"-", 2},
            {"*", 4},
            {"/", 4},
            {"(", 0}
        };

        private readonly Dictionary<string, ExpressionType> _expressionTypes = new()
        {
            {"+", ExpressionType.Add},
            {"-", ExpressionType.Subtract},
            {"*", ExpressionType.Multiply},
            {"/", ExpressionType.Divide}
        };

        private readonly Checker _checker = new();
        private readonly ParserForMathExpression _parser = new();
        private readonly CalculatorVisitor _visitor = new();
        
        public Result<string, string> Calculate(string expression)
        {
            var tokens = _parser.ParseToTokens(expression);
            if (tokens.Type == TypeResult.Error)
                return new Result<string, string>(error: tokens.Error);
            if (!_checker.IsCorrectExpression(tokens.Success, out var errorMessage))
                return new Result<string, string>(error: errorMessage);
            var convertedExpression = ConvertStringToExpression(tokens.Success);
            var resultExpression = _visitor.Visit(convertedExpression);
            var result = (double)((ConstantExpression)resultExpression).Value;
            return new Result<string, string>(success: result.ToString(CultureInfo.InvariantCulture));
        }

        private Expression ConvertStringToExpression(IEnumerable<Token> tokens)
        {
            var outputStack = new Stack<Expression>();
            var operatorStack = new Stack<Token>();
            var isNegativeNumber = false;
            Token? lastToken = null;
            foreach (var currentToken in tokens)
            {
                switch (currentToken.Type)
                {
                    case TokenType.Number:
                        outputStack.Push(Expression.Constant((isNegativeNumber
                                                                 ? -1
                                                                 : 1)
                                                             * double.Parse(currentToken.Value),
                            typeof(double)));
                        isNegativeNumber = false;
                        break;
                    case TokenType.Operation:
                        if (lastToken?.Value == "(")
                            isNegativeNumber = true;
                        else AddOperations(currentToken, outputStack, operatorStack);
                        break;
                    case TokenType.Bracket:
                        if (currentToken.Value == "(")
                            operatorStack.Push(currentToken);
                        else CalculateToOpenBracket(outputStack, operatorStack);
                        break;
                }

                lastToken = currentToken;
            }

            CalculateLastOperation(outputStack, operatorStack);

            return outputStack.Pop();
        }

        private void AddOperations(Token operation, Stack<Expression> outputStack, Stack<Token> operatorStack)
        {
            while (operatorStack.Count > 0 && _priorities[operatorStack.Peek().Value] >= _priorities[operation.Value])
                MakeBinaryExpression(outputStack, operatorStack.Pop());

            operatorStack.Push(operation);
        }

        private void CalculateToOpenBracket(Stack<Expression> outputStack, Stack<Token> operatorStack)
        {
            var operation = operatorStack.Pop();
            while (operatorStack.Count > 0 && operation.Value != "(")
            {
                MakeBinaryExpression(outputStack, operation);
                operation = operatorStack.Pop();
            }
        }

        private void CalculateLastOperation(Stack<Expression> outputStack, Stack<Token> operatorStack)
        {
            while (operatorStack.Count > 0)
                MakeBinaryExpression(outputStack, operatorStack.Pop());
        }
        
        
        private void MakeBinaryExpression(Stack<Expression> outputStack, Token operation)
        {
            var rightNode = outputStack.Pop();
            outputStack.Push(Expression.MakeBinary(_expressionTypes[operation.Value], outputStack.Pop(),
                rightNode));
        }
    }
}