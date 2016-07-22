using ContactManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactManager.Services
{
    public class ContactsInMemoryRepository : IRepository<Contact>
    {
        private List<Contact> contacts;

        public ContactsInMemoryRepository()
        {
            contacts = new List<Contact>();
        }

        public Guid Add(Contact entity)
        {
            entity.ContactId = Guid.NewGuid();
            contacts.Add(entity);

            return entity.ContactId;
        }

        public void DeleteByKey(Guid id)
        {
            Contact contact = contacts.FirstOrDefault(x => x.ContactId == id);

            if (contact == null)
            {
                throw new KeyNotFoundException(string.Format("Cannot find a contact with the id of {0}", id));
            }

            contacts.Remove(contact);
        }

        public IEnumerable<Contact> FindAll()
        {
            return contacts;
        }

        public Contact FindByKey(Guid id)
        {
            Contact contact = contacts.First(x => x.ContactId == id);

            return contact;
        }

        public void Update(Contact entity)
        {
            Contact contact = contacts.FirstOrDefault(x => x.ContactId == entity.ContactId);

            if (contact == null)
            {
                throw new KeyNotFoundException(string.Format("Cannot find a contact with the id of {0}", entity.ContactId.ToString()));
            }

            contact = entity;
        }

        public int Count
        {
            get
            {
                return contacts.ToList().Count;
            }
        }
    }
}
