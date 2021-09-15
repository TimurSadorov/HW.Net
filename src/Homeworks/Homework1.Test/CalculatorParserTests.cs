using System;
using Xunit;

namespace Homework1.Test
{
    public class CalculatorParserTests
    {
        [Fact]
        public void TryParse_AllExpressionIsCorrect_ReturnTrue()
        {
            var actual = CalculatorParser.TryParse(new[] {"1", "+", "2"}, true,
                true, "+", out var res);
            Assert.True(actual);
        }
    }
}