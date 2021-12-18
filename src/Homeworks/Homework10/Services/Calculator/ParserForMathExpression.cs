using System.Collections.Generic;
using System.Linq;

namespace WebApplication.Services.Calculator
{
    internal class ParserForMathExpression
    {
        private readonly char[] brackets = {'(', ')'};
        private readonly char[] operations = {'+', '-', '/', '*'};

        public Result<List<Token>, string> ParseToTokens(string expression)
        {
            if (string.IsNullOrEmpty(expression))
                return new Result<List<Token>, string>(new List<Token>());
            var tokens = new List<Token>();
            var num = "";
            var errorMessageForNum = "There is no such number ";
            foreach (var c in expression.Replace(" ", ""))
            {
                if (brackets.Contains(c))
                {
                    if (!TryAddToken(ref num, tokens, c, TokenType.Bracket))
                        return new Result<List<Token>, string>(errorMessageForNum + num);
                }
                else if (operations.Contains(c))
                {
                    if (!TryAddToken(ref num, tokens, c, TokenType.Operation))
                        return new Result<List<Token>, string>(errorMessageForNum + num);
                }
                else if (char.IsDigit(c) || c == ',')
                    num += c;
                else
                    return new Result<List<Token>, string>($"Unknown character {c}");
            }

            if (!string.IsNullOrEmpty(num))
                if (!double.TryParse(num, out _))
                    return new Result<List<Token>, string>(errorMessageForNum + num);
                else 
                    tokens.Add(new Token(TokenType.Number, num));
            return new Result<List<Token>, string>(tokens);
        }

        private bool TryAddToken(ref string num, ICollection<Token> tokens, char tokenValue, TokenType tokenType)
        {
            if (!string.IsNullOrEmpty(num))
            {
                if (!double.TryParse(num, out _))
                    return false;
                tokens.Add(new Token(TokenType.Number, num));
                num = "";
            }

            tokens.Add(new Token(tokenType, tokenValue.ToString()));
            return true;
        }
    }
}