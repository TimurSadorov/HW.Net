namespace WebApplication.Services.Calculator
{
    public interface ICalculator
    {
        public Result<string, string> Calculate(string expression);
    }
}