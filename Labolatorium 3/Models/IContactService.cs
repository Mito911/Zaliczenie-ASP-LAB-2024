using Labolatorium_3.Models;
using System.Collections.Generic;

namespace Labolatorium_3.Services
{
    public interface IContactService
    {
        int Add(Contact contact); // Dodaje nowy kontakt i zwraca jego ID
        void Delete(int id); // Usuwa kontakt o określonym ID
        void Update(Contact contact); // Aktualizuje dane istniejącego kontaktu
        List<Contact> FindAll(); // Zwraca listę wszystkich kontaktów
        Contact FindById(int id); // Zwraca kontakt o określonym ID
    }
}

