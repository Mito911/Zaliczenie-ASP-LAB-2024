using Labolatorium_3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Labolatorium_3.Controllers
{
    
    public class EmployeeController : Controller
    {
        // Prosta imitacja bazy danych za pomocą statycznej listy
        static List<Employee> _employees = new List<Employee>()
    {
        // Przykładowe dane startowe
        new Employee { Id = 1, FirstName = "Jan", LastName = "Kowalski", PESEL = "90010112345", Position = "Inżynier", Department = "IT", EmploymentDate = new DateTime(2020, 1, 10) },
        // Dodaj więcej pracowników według potrzeb
    };

        public IActionResult Index()
        {
            return View(_employees); // Zwraca listę pracowników do widoku
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return NotFound(); // Jeśli nie znaleziono pracownika, zwraca błąd 404
            }
            return View(employee); // Zwraca znalezionego pracownika do widoku edycji
        }

        [HttpPost]
        public IActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                var existingEmployee = _employees.FirstOrDefault(e => e.Id == employee.Id);
                if (existingEmployee != null)
                {
                    // Tutaj można zaktualizować dane pracownika
                    _employees.Remove(existingEmployee);
                    _employees.Add(employee);
                    return RedirectToAction("Index"); // Po zaktualizowaniu przekierowuje do listy pracowników
                }
                return NotFound();
            }
            return View(employee); // Jeśli model nie jest poprawny, zwraca widok edycji z błędami walidacji
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                _employees.Remove(employee);
                return RedirectToAction("Index"); // Po usunięciu przekierowuje do listy pracowników
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employees.Add(employee); // Dodaj pracownika do "bazy danych"
                return RedirectToAction(nameof(Index));
            }
            return View(employee);
        }

        public IActionResult Details(int id)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return NotFound(); // Jeśli nie znaleziono pracownika, zwraca błąd 404
            }
            return View(employee); // Zwraca szczegóły pracownika do widoku
        }
    }

}
