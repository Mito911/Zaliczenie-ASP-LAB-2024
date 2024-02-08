using Labolatorium_3.Models.Labolatorium_3.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Labolatorium_3.Models
{
    
            public class Employee
        {
            [HiddenInput(DisplayValue = false)]
            public int Id { get; set; }

            [Required(ErrorMessage = "Proszę podać imię!")]
            public string FirstName { get; set; }

            [Required(ErrorMessage = "Proszę podać nazwisko!")]
            public string LastName { get; set; }

            [Required(ErrorMessage = "Proszę podać PESEL!")]
            public string PESEL { get; set; }

            public string Position { get; set; }
            public string Department { get; set; }

            [DataType(DataType.Date)]
            public DateTime EmploymentDate { get; set; }

            [DataType(DataType.Date)]
            public DateTime? TerminationDate { get; set; }

            [Display(Name = "Priorytet")]
            public Priority Priority { get; set; } // Dodana właściwość Priority
        }
    
}
