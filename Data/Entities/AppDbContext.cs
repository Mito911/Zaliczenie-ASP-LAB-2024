using Microsoft.EntityFrameworkCore;
using System;

namespace Data.Entities
{
    public class AppDbContext : DbContext
    {
        public DbSet<OrganizationEntity> Organizations { get; set; }
        public DbSet<MyEntity> MyEntities { get; set; }
        public DbSet<ContactEntity> Contacts { get; set; }

        private string DbPath { get; set; }

        public AppDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "contacts.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
            options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Konfiguracja danych startowych dla ContactEntity
            modelBuilder.Entity<ContactEntity>().HasData(
                new ContactEntity() { Id = 1, Name = "Adam", Email = "adam@wsei.edu.pl", Phone = "127813268163", Birth = new DateTime(2000, 10, 10) },
                new ContactEntity() { Id = 2, Name = "Ewa", Email = "ewa@wsei.edu.pl", Phone = "293443823478", Birth = new DateTime(1999, 8, 10) }

                
            )  ;

            // Konfiguracja Address jako typu własnościowego dla OrganizationEntity
            modelBuilder.Entity<OrganizationEntity>()
                .OwnsOne(o => o.Address, a =>
                {
                    a.Property(ad => ad.City).HasColumnName("City");
                    a.Property(ad => ad.Street).HasColumnName("Street");
                    a.Property(ad => ad.PostalCode).HasColumnName("PostalCode");
                    a.Property(ad => ad.Region).HasColumnName("Region");
                });

            // Dodaj tutaj więcej konfiguracji modelu...
        }

        public class OrganizationEntity
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Regon { get; set; }
            public string Nip { get; set; }
            public Address Address { get; set; }
            public ICollection<ContactEntity> Contacts { get; set; }
        }

        public class Address
        {
            public string City { get; set; }
            public string Street { get; set; }
            public string PostalCode { get; set; }
            public string Region { get; set; }
        }

    }
}

