using System;
using System.Linq;

namespace Homework1
{
	public static class Parser
	{
		private static readonly string[] SupportedOperations = {"+", "-", "*", "/"};

		public static int TryParseArguments(string[] args, out int val1, out string operation, out int val2)
		{
			var isVal1Int = int.TryParse(args[0], out val1);
			operation = args[1];
			var isVal2Int = int.TryParse(args[2], out val2);

			if (!isVal1Int || !isVal2Int)
			{
				Console.WriteLine($"{args[0]}{args[1]}{args[2]} is not a valid calculate syntax");
				return 1;
			}

			if (!SupportedOperations.Contains(operation))
			{
				Console.WriteLine($"{args[0]}{args[1]}{args[2]} is not a valid calculate syntax" +
				                  $"\nSupported operations are:{SupportedOperations.Aggregate((x, y) => x + " " + y)}");
				return 2;
			}

			return 0;
		}
	}
}