using Laboratorium_2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Laboratorium_2.Controllers
{
    public class CalculatorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Result(double? x, string operation, double? y)
        {
            var model = new Calculator
            {
                X = x,
                Y = y,
                Operator = MapStringToOperator(operation) // Zmiana tutaj z 'operator' na 'operation'
            };

            if (!model.IsValid())
            {
                return View("Error");
            }
            return View("Result", model); // Upewnij się, że nazwa widoku jest poprawna.
        }

        private Operators MapStringToOperator(string operationString)
        {
            switch (operationString)
            {
                case "add":
                    return Operators.Add;
                case "sub":
                    return Operators.Sub;
                case "mul":
                    return Operators.Mul;
                case "div":
                    return Operators.Div;
                default:
                    return Operators.Unknown;
            }
        }

    }
}