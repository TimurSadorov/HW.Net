using System.Collections.Generic;
using System.Linq;

namespace WebApplication.Services.Calculator
{
    internal class Checker
    {
        public bool IsCorrectExpression(IEnumerable<Token> expressionInTokens, out string errorMessage)
        {
            errorMessage = "";
            if (!expressionInTokens.Any())
            {
                errorMessage = "Empty string";
                return false;
            }
            Token? lastToken = null;
            foreach (var currentToken in expressionInTokens)
            {
                switch (currentToken.Type)
                {
                    case TokenType.Number:
                        break;
                    case TokenType.Operation:
                        if (lastToken?.Type is TokenType.Operation)
                            errorMessage = $"There are two operations in a row {lastToken.Value.Value} and {currentToken.Value}";
                        else if (lastToken?.Value == "(" && currentToken.Value != "-")
                            errorMessage = "After the opening brackets, only negation can go:" +
                                           $" {lastToken.Value.Value}{currentToken.Value}";
                        break;
                    case TokenType.Bracket:
                        if (lastToken?.Type is TokenType.Operation && currentToken.Value == ")")
                            errorMessage = "There is only a number before the closing parenthesis" +
                                           $" {lastToken.Value.Value}{currentToken.Value}";
                        break;
                }

                if (!string.IsNullOrEmpty(errorMessage))
                    return false;
                lastToken = currentToken;
            }

            return true;
        }
    }
}