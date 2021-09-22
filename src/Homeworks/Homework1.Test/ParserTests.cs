using System.Collections.Generic;
using Xunit;

namespace Homework1.Test
{
    public class ParserTests
    {
        [Fact]
        public void TryParseArguments_CorrectExpression_ReturnZero()
        {
            var actual = Parser.TryParseArguments(
                new[] {"1", "+", "2"}, out _, out _, out _);
            Assert.Equal(0, actual);
        }

        [Theory]
        [MemberData(nameof(InvalidArguments))]
        public void TryParseArguments_InvalidArguments_ReturnOne(string[] args)
        {
            var actual = Parser.TryParseArguments(
                args, out _, out _, out _);
            Assert.Equal(1, actual);
        }

        public static IEnumerable<object[]> InvalidArguments()
        {
            yield return new object[] {new[]{"x", "-", "2"}};
            yield return new object[] {new[]{"5", "+", "="}};
            yield return new object[] {new[]{"p", "+", "x"}};
        }
        
        [Theory]
        [MemberData(nameof(InvalidOperations))]
        public void TryParseArguments_InvalidOperation_ReturnTwo(string[] args)
        {
            var actual = Parser.TryParseArguments(
                args, out _, out _, out _);
            Assert.Equal(2, actual);
        }

        public static IEnumerable<object[]> InvalidOperations()
        {
            yield return new object[] {new[]{"10", "<", "2"}};
            yield return new object[] {new[]{"5", "\\", "5"}};
            yield return new object[] {new[]{"10", "%", "6"}};
        }
    }
}