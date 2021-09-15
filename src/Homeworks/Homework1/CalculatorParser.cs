using System;
using System.Linq;

namespace Homework1
{
    public static class CalculatorParser
    {
        private static readonly string[] SupportedOperations = {"+", "-", "*", "/"};

        public static bool TryParse(string[] args, bool isVal1Int, bool isVal2Int, string operation, out int res)
        {
            if (!isVal1Int || !isVal2Int)
            {
                Console.WriteLine($"{args[0]}{args[1]}{args[2]} is not a valid calculate syntax");
                res = 1;
                return false;
            }

            if (!SupportedOperations.Contains(operation))
            {
                Console.WriteLine($"{args[0]}{args[1]}{args[2]} is not a valid calculate syntax" +
                                  $"\nSupported operations are:{SupportedOperations.Aggregate((x, y) => x + " " + y)}");
                res = 2;
                return false;
            }

            res = 0;
            return true;
        }
    }
}