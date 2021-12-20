using System.Collections.Generic;
using Homework13Calculator.Services.Calculator;

namespace Homework13Calculator.Services.HashedCalculator
{
	public class HashedCalculator : ICalculator
	{
		private static readonly Dictionary<string, string> HashedExpression = new();
		private readonly ICalculator _calculator;

		public HashedCalculator(ICalculator calculator)
		{
			_calculator = calculator;
		}

		public Result<string, string> Calculate(string expression)
		{
			var expressionWithoutSpace = expression?.Replace(" ", "");
			if(expressionWithoutSpace is not null && HashedExpression.ContainsKey(expressionWithoutSpace!))
				return new Result<string, string>(success: HashedExpression[expressionWithoutSpace]);

			var result = _calculator.Calculate(expression);
			if (result.Type == TypeResult.Error)
				return result;

			HashedExpression[expressionWithoutSpace] = result.Success;
			return result;
		}
	}
}