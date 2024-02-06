
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Zaliczenie_ASP_LAB.Models;


namespace Labolatorium__1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About([FromQuery(Name = "calc-op")] Operator op)
        {
            ViewBag.Op = op;
            return View();
        }
        public enum Operator
        {
            Add, Mul, Sub, Div
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public ActionResult Calculator(double? a, double? b, string operation)
        {
            string op = Request.Query["op"];
            ViewBag.Op = op;

            string errorMessage = null;
            string operationSymbol = "";



            double? result = 0;
            switch (operation)
            {
                case "add":
                    result = a + b;
                    operationSymbol = "+";
                    break;
                case "subtract":
                    result = a - b;
                    operationSymbol = "-";
                    break;
                case "multiply":
                    result = a * b;
                    operationSymbol = "*";
                    break;
                case "divide":
                    if (b != 0)
                    {
                        result = a / b;
                        operationSymbol = "/";
                    }
                    else
                    {
                        errorMessage = "Nie można dzielić przez zero.";

                    }

                    break;
                default:
                    errorMessage = "Nieznana operacja.";

                    break;
            }


            ViewBag.Result = result;
            ViewBag.A = a;
            ViewBag.B = b;
            ViewBag.OperationSymbol = operationSymbol;


            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
