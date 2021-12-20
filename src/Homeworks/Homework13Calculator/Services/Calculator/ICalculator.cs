namespace Homework13Calculator.Services.Calculator
{
    public interface ICalculator
    {
        public Result<string, string> Calculate(string expression);
    }
}