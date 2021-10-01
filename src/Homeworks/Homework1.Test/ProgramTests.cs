using System.Collections.Generic;
using Xunit;

namespace Homework1.Test
{
	public class ProgramTests
	{
		[Fact]
		public void Main_CorrectExpression_ReturnZero()
		{
			var actual = Program.Main(new[] {"1", "+", "2"});
			Assert.Equal(0, actual);
		}

		[Theory]
		[MemberData(nameof(Expressions))]
		public void Main_IncorrectExpression_ReturnZero(string[] args, int expected)
		{
			var actual = Program.Main(args);
			Assert.Equal(expected, actual);
		}

		public static IEnumerable<object[]> Expressions()
		{
			yield return new object[] {new[] {"11", "^", "231"}, 2};
			yield return new object[] {new[] {"s", "+", "2"}, 1};
		}
	}
}