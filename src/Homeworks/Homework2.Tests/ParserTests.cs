using System.Collections.Generic;
using Homework2.IL;
using Xunit;

namespace Homework2.Tests
{
	public class ParserTests
	{
		[Theory]
		[MemberData(nameof(CorrectArguments))]
		public void TryParseArguments_CorrectExpression_ReturnZero(string[] args)
		{
			var actual = Parser.TryParseArguments(args, out _, out _, out _);
			Assert.Equal(0, actual);
		}

		public static IEnumerable<object[]> CorrectArguments()
		{
			yield return new object[] {new[] {"10", "+", "2"}};
			yield return new object[] {new[] {"2", "-", "10"}};
			yield return new object[] {new[] {"20", "*", "10"}};
			yield return new object[] {new[] {"4", "/", "4"}};
			yield return new object[] {new[] {"50", ":", "2"}};
		}

		[Theory]
		[MemberData(nameof(InvalidArguments))]
		public void TryParseArguments_InvalidArguments_ReturnOne(string[] args)
		{
			var actual = Parser.TryParseArguments(args, out _, out _, out _);
			Assert.Equal(1, actual);
		}

		public static IEnumerable<object[]> InvalidArguments()
		{
			yield return new object[] {new[] {"x", "-", "2"}};
			yield return new object[] {new[] {"5", "+", "="}};
			yield return new object[] {new[] {"p", "+", "x"}};
		}

		[Theory]
		[MemberData(nameof(InvalidOperations))]
		public void TryParseArguments_InvalidOperation_ReturnTwo(string[] args)
		{
			var actual = Parser.TryParseArguments(args, out _, out _, out _);
			Assert.Equal(2, actual);
		}

		public static IEnumerable<object[]> InvalidOperations()
		{
			yield return new object[] {new[] {"10", "<", "2"}};
			yield return new object[] {new[] {"5", "\\", "5"}};
			yield return new object[] {new[] {"10", "%", "6"}};
		}
	}
}