using Homework2.IL;
using Xunit;

namespace Homework2.Tests
{
	public class CalculatorTests
	{
		[Theory]
		[InlineData(1, 2, "+", 3)]
		[InlineData(-2, 3, "+", 1)]
		[InlineData(2, -4, "+", -2)]
		[InlineData(-3, -4, "+", -7)]
		public void Calculate_Sum_ReturnSumNumbers(int firstNum, int secondNum, string operation, int expected)
		{
			var actual = Calculator.Calculate(firstNum, operation, secondNum);
			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData(5, 2, "-", 3)]
		[InlineData(2, -6, "-", 8)]
		[InlineData(-3, 4, "-", -7)]
		[InlineData(-8, -2, "-", -6)]
		public void Calculate_Subtraction_ReturnDifferenceNumbers(int firstNum,
			int secondNum,
			string operation,
			int expected)
		{
			var actual = Calculator.Calculate(firstNum, operation, secondNum);
			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData(0, 0, "*", 0)]
		[InlineData(0, -6, "*", 0)]
		[InlineData(4, 0, "*", 0)]
		[InlineData(1, 20, "*", 20)]
		[InlineData(3, -2, "*", -6)]
		[InlineData(-5, -3, "*", 15)]
		public void Calculate_Multiplication_ReturnProductNumbers(int firstNum,
			int secondNum,
			string operation,
			int expected)
		{
			var actual = Calculator.Calculate(firstNum, operation, secondNum);
			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData(0, 2, "/", 0)]
		[InlineData(0, -10, "/", 0)]
		[InlineData(20, 2, "/", 10)]
		[InlineData(10, -5, "/", -2)]
		[InlineData(-9, -9, "/", 1)]
		[InlineData(20, 2, ":", 10)]
		[InlineData(10, -5, ":", -2)]
		[InlineData(-9, -9, ":", 1)]
		public void Calculate_Division_ReturnQuotient(int firstNum, int secondNum, string operation, int expected)
		{
			var actual = Calculator.Calculate(firstNum, operation, secondNum);
			Assert.Equal(expected, actual);
		}

		[Theory]
		[InlineData(20, 2, ">")]
		[InlineData(10, -5, "?")]
		[InlineData(-9, -9, "%")]
		public void Calculate_UnknownOperations_ReturnZero(int firstNum, int secondNum, string operation)
		{
			var actual = Calculator.Calculate(firstNum, operation, secondNum);
			Assert.Equal(0, actual);
		}
	}
}