using Labolatorium_3.Models; // Upewnij się, że ta przestrzeń nazw zawiera klasę Contact
using Labolatorium_3.Mappers; // Upewnij się, że ta przestrzeń nazw zawiera klasę ContactMapper
using Data.Entities; // Załóżmy, że ta przestrzeń nazw zawiera klasę AppDbContext oraz ContactEntity
using System.Collections.Generic;
using System.Linq; // Potrzebne do używania metody Select i ToList

namespace Labolatorium_3.Services
{
    public class EFContactService : IContactService
    {
        private readonly AppDbContext _context;

        public EFContactService(AppDbContext context)
        {
            _context = context;
        }

        public int Add(Contact contact)
        {
            var entity = ContactMapper.ToEntity(contact);
            var result = _context.Contacts.Add(entity);
            _context.SaveChanges();
            return result.Entity.Id;
        }

        public void Delete(int id)
        {
            var entity = _context.Contacts.Find(id);
            if (entity != null)
            {
                _context.Contacts.Remove(entity);
                _context.SaveChanges();
            }
        }

        public List<Contact> FindAll()
        {
            return _context.Contacts
                           .Select(ContactMapper.FromEntity)
                           .ToList();
        }

        public Contact FindById(int id)
        {
            var entity = _context.Contacts.Find(id);
            return entity != null ? ContactMapper.FromEntity(entity) : null;
        }

        public void Update(Contact contact)
        {
            var entity = ContactMapper.ToEntity(contact);
            _context.Contacts.Update(entity);
            _context.SaveChanges();
        }
    }

    public interface IContactService
    {
        int Add(Contact contact);
        void Delete(int id);
        List<Contact> FindAll();
        Contact FindById(int id);
        void Update(Contact contact);
    }
}