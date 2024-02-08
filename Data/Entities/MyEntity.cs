
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Entities; // Dodaj tę linię, jeśli MyEntity jest w tej przestrzeni nazw
using Microsoft.EntityFrameworkCore;

namespace Data.Entities
{
    [Table("MyEntities")] // Określa nazwę tabeli w bazie danych
    public class MyEntity
    {
        [Key] // Określa, że pole Id jest kluczem głównym
        public int Id { get; set; }

        [Required] // Pole nie może być null
        [MaxLength(100)] // Maksymalna długość łańcucha znaków to 100
        public string Property1 { get; set; }

        public int Property2 { get; set; }

        [Column("CustomColumnName")] // Określa niestandardową nazwę kolumny w bazie danych
        public bool Property3 { get; set; }
    }
} 

