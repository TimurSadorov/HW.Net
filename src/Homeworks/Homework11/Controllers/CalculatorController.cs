using System;
using Homework11.Exceptions;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;
using WebApplication.Services.Calculator;

namespace WebApplication.Controllers
{
    public class CalculatorController : Controller
    {
        private readonly ICalculator _calculator;
        private readonly IExceptionHandler _exceptionHandler;

        public CalculatorController(ICalculator calculator, IExceptionHandler exceptionHandler)
        {
            _calculator = calculator;
            _exceptionHandler = exceptionHandler;
        }
        
        [HttpGet]
        public IActionResult Calculate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Calculate(string expression)
        {
            ResultModel model;
            try
            {
                var result = _calculator.Calculate(expression);
                model = new ResultModel($"Result: {result}");
            }
            catch (Exception e)
            {
                _exceptionHandler.HandleException(e);
                model = new ResultModel($"Error: {e.Message}");
            }
            return View(model);
        }
    }
}