using System;

namespace Homework1
{
    static class Program
    {
        private static int Main(string[] args)
        {
            var isVal1Int = int.TryParse(args[0], out var val1);
            var operation = args[1];
            var isVal2Int = int.TryParse(args[2], out var val2);

            if (!CalculatorParser.TryParse(args, isVal1Int, isVal2Int, operation, out var res))
                return res;

            var result = Calclulate(operation, val2, val1);

            Console.WriteLine($"{val1}+{val2}={result}");
            return 0;
        }

        private static double Calclulate(string operation, int val2, int val1)
        {
            double result = operation switch
            {
                "+" => val1 + val2,
                "-" => val1 - val2,
                "*" => val1 * val2,
                "/" => val1 / val2,
                _ => 0
            };
            return result;
        }
    }
}