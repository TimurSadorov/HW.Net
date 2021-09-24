using Homework2.IL;
using Xunit;

namespace Homework2.Tests
{
    public class CalculatorTests
    {
        [Theory]
        [InlineData(1 , 2, "+", 3)]
        [InlineData(-2, 3, "+", 1)]
        [InlineData(2, -4, "+", -2)]
        [InlineData(-3, -4, "+", -7)]
        public void Calculate_AddTwoNumbers_NumberShouldAddUp(
            int firstNum, int secondNum, string operation, int expected)
        {
            var actual = Calculator.Calculate(firstNum, operation, secondNum);
            Assert.Equal(expected, actual);
        }
        
        [Theory]
        [InlineData(5 , 2, "-", 3)]
        [InlineData(2, -6, "-", 8)]
        [InlineData(-3, 4, "-", -7)]
        [InlineData(-8, -2, "-", -6)]
        public void Calculate_DifferenceBetweenTwoNumbers_SecondNumberShouldBeDeductedFromFirstNumber(
            int firstNum, int secondNum, string operation, int expected)
        {
            var actual = Calculator.Calculate(firstNum, operation, secondNum);
            Assert.Equal(expected, actual);
        }
        
        [Theory]
        [InlineData(0, 0, "*")]
        [InlineData(0, -6, "*")]
        [InlineData(4, 0, "*")]
        public void Calculate_MultiplicationByZero_ProductShouldBeZero(
            int firstNum, int secondNum, string operation)
        {
            var actual = Calculator.Calculate(firstNum, operation, secondNum);
            Assert.Equal(0, actual);
        }
        
        [Theory]
        [InlineData(1, 20, "*", 20)]
        [InlineData(3, -2, "*", -6)]
        [InlineData(-5, -3, "*", 15)]
        public void Calculate_ProductOfTwoNonZeroNumbers_ProductOfTwoNumbers(
            int firstNum, int secondNum, string operation, int expected)
        {
            var actual = Calculator.Calculate(firstNum, operation, secondNum);
            Assert.Equal(expected, actual);
        }
        
        [Theory]
        [InlineData(0, 2, "/")]
        [InlineData(0, -10, "/")]
        public void Calculate_DivisibleByZero_QuotientIsZero(
            int firstNum, int secondNum, string operation)
        {
            var actual = Calculator.Calculate(firstNum, operation, secondNum);
            Assert.Equal(0, actual);
        }
        
        [Theory]
        [InlineData(20, 2, "/", 10)]
        [InlineData(10, -5, "/", -2)]
        [InlineData(-9, -9, "/", 1)]
        public void Calculate_DividingTwoNonZeroNumbersBySlash_DividingFirstBySecond(
            int firstNum, int secondNum, string operation, int expected)
        {
            var actual = Calculator.Calculate(firstNum, operation, secondNum);
            Assert.Equal(expected, actual);
        }
        
        [Theory]
        [InlineData(20, 2, ":", 10)]
        [InlineData(10, -5, ":", -2)]
        [InlineData(-9, -9, ":", 1)]
        public void Calculate_DividingTwoNonZeroNumbersByColons_DividingFirstBySecond(
            int firstNum, int secondNum, string operation, int expected)
        {
            var actual = Calculator.Calculate(firstNum, operation, secondNum);
            Assert.Equal(expected, actual);
        }
        
        [Theory]
        [InlineData(20, 2, ">")]
        [InlineData(10, -5, "?")]
        [InlineData(-9, -9, "%")]
        public void Calculate_UnknownOperations_ReturnZero(
            int firstNum, int secondNum, string operation)
        {
            var actual = Calculator.Calculate(firstNum, operation, secondNum);
            Assert.Equal(0, actual);
        }
    }
}