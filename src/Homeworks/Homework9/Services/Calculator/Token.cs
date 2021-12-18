namespace WebApplication.Services.Calculator
{
    internal enum TokenType
    {
        Number,
        Operation,
        Bracket
    }

    internal readonly struct Token
    {
        public readonly TokenType Type;
        public readonly string Value;

        public Token(TokenType type, string value)
        {
            Type = type;
            Value = value;
        }
    }
}