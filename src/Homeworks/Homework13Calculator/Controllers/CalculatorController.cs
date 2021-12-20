using System;
using Homework13Calculator.Models;
using Homework13Calculator.Services;
using Homework13Calculator.Services.Calculator;
using Microsoft.AspNetCore.Mvc;

namespace Homework13Calculator.Controllers
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
        
        [HttpPost]
        public void StartCalculateTenMillion()
        {
            var random = new Random();
            int v1, v2;
            for (var i = 0; i < 10000000; i++)
            {
                v1 = random.Next();
                v2 = random.Next();
                _calculator.Calculate($"{v1} + {v2}");
            }
        }
    }
}