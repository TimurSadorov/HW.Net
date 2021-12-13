using Homework8.Interface;
using Homework8.Models;
using Microsoft.AspNetCore.Mvc;

namespace Homework8.Controllers
{
	public class CalculatorController : Controller
	{
		public IActionResult Add([FromServices] ICalculator calculator, double val1, double val2)
		{
			var result = calculator.Add(val1, val2);
			return View("Calculator", new CalculatorModel(result));
		}

		public IActionResult Subtract([FromServices] ICalculator calculator, double val1, double val2)
		{
			var result = calculator.Subtract(val1, val2);
			return View("Calculator", new CalculatorModel(result));
		}

		public IActionResult Divide([FromServices] ICalculator calculator, double val1, double val2)
		{
			var result = calculator.Divide(val1, val2);
			return View("Calculator", new CalculatorModel(result));
		}

		public IActionResult Multiply([FromServices] ICalculator calculator, double val1, double val2)
		{
			var result = calculator.Multiply(val1, val2);
			return View("Calculator", new CalculatorModel(result));
		}
	}
}