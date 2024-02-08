using Microsoft.EntityFrameworkCore;
using EFData.Entities; // Zakładam, że masz przestrzeń nazw z Twoimi encjami

namespace EFData
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<ContactEntity> Contacts { get; set; }
        // DbSets dla innych encji

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Konfiguracja modelu za pomocą Fluent API
            modelBuilder.Entity<ContactEntity>(entity =>
            {
                entity.ToTable("Contacts"); // Opcjonalnie: nadanie nazwy tabeli
                entity.HasKey(e => e.Id); // Klucz główny
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(100);
                // Dodatkowe konfiguracje pól...
            });

            // Tutaj możesz dodać więcej konfiguracji dla innych encji...
        }
    }
}

