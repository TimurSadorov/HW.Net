using System.Linq;
using Homework10.DbModels;
using WebApplication.Services.Calculator;

namespace WebApplication.Services.HashedCalculator
{
	public class HashedCalculator : ICalculator
	{
		private readonly ApplicationContext _hashedExpression;
		private readonly ICalculator _calculator;

		public HashedCalculator(ApplicationContext hashedExpression, ICalculator calculator)
		{
			_hashedExpression = hashedExpression;
			_calculator = calculator;
		}

		public string Calculate(string expression)
		{
			var expressionWithoutSpace = expression?.Replace(" ", "");
			var possibleResult = _hashedExpression.SolvingExpressions
				.FirstOrDefault(exp => exp.Expression == expressionWithoutSpace)?.Result;
			if (possibleResult is not null)
				return possibleResult;

			var result = _calculator.Calculate(expression);

			var solvingExpression = new SolvingExpression {Expression = expressionWithoutSpace, Result = result};
			_hashedExpression.Add(solvingExpression);
			_hashedExpression.SaveChanges();
			return result;
		}
	}
}