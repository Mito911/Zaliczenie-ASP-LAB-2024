using Labolatorium_3.Models; // Zakładam, że klasa Contact znajduje się tutaj
using Labolatorium_3.Models.Labolatorium_3.Models;
using Labolatorium_3.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Laboratorium_3___App_ns.Services // Zaktualizowana przestrzeń nazw
{
    public class MemoryContactService : IContactService
    {
        private readonly Dictionary<int, Contact> _items = new Dictionary<int, Contact>()
        {
            {1, new Contact {Id = 1, Name = "Maciej", Email = "Maciej@wsei.edu.pl", Phone = "111222333", Birth = new DateTime(2001, 6, 6), Priority = Priority.Normal } },
            {2, new Contact {Id = 2, Name = "Ola", Email = "Ola@wsei.edu.pl", Phone = "222444555", Birth = new DateTime(2003, 3, 21), Priority = Priority.High } }
        };

        private int _nextId = 3;
        private readonly IDateTimeProvider _timeProvider;

        public MemoryContactService(IDateTimeProvider timeProvider)
        {
            _timeProvider = timeProvider;
        }

        public int Add(Contact contact)
        {
            contact.Id = _nextId++;
            contact.Created = _timeProvider.GetCurrentDateTime(); // Zakładam, że dodałeś właściwość Created do klasy Contact
            _items[contact.Id] = contact;
            return contact.Id;
        }

        public Contact? FindById(int id)
        {
            _items.TryGetValue(id, out var contact);
            return contact;
        }

        public List<Contact> FindAll()
        {
            return _items.Values.ToList();
        }

        public void Delete(int id) // Zmieniłem nazwę z RemoveById na Delete dla spójności z interfejsem
        {
            _items.Remove(id);
        }

        public void Update(Contact contact)
        {
            if (_items.ContainsKey(contact.Id))
            {
                _items[contact.Id] = contact;
            }
        }
    }
}
