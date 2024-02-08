using System;
using System.ComponentModel.DataAnnotations;
using Labolatorium_3.Models.Labolatorium_3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Labolatorium_3.Models // Zmień Labolatorium_3 na nazwę Twojej przestrzeni nazw, jeśli jest inna
{
    public class Contact
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Proszę podać imię!")]
        [Display(Name = "Imię")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Proszę podać nazwisko!")]
        [Display(Name = "Nazwisko")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Proszę podać adres email!")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Proszę podać numer telefonu!")]
        [Phone]
        [Display(Name = "Telefon")]
        public string Phone { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data urodzenia")]
        public DateTime Birth { get; set; }

        [Display(Name = "Priorytet")]
        public Priority Priority { get; set; } // Zakładam, że masz już zdefiniowany enum Priority

        public DateTime Created { get; set; }
    }
}
