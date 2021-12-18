using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;
using WebApplication.Services;
using WebApplication.Services.Calculator;

namespace WebApplication.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly ICalculator _calculator;

        public CalculatorController(ICalculator calculator)
        {
            _calculator = calculator;
        }
        
        [HttpGet]
        public IActionResult Calculate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Calculate(string expression)
        {
            var result = _calculator.Calculate(expression);
            ResultModel model;
            if (result.Type is TypeResult.Success)
                model = new ResultModel($"Result: {result.Success}");
            else
                model = new ResultModel($"Error: {result.Error}");
            return View(model);
        }
    }
}