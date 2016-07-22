using ContactManager.Config;
using ContactManager.Entities;
using ContactManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ContactManager.Services
{
    public class ContactsDbRepository : IRepository<Contact>
    {
        private readonly IAppSettings appSettings;

        public ContactsDbRepository(IAppSettings appSettings)
        {
            this.appSettings = appSettings;
        }

        public Guid Add(Contact entity)
        {
            Guid id;

            using (var db = new ContactContext(appSettings))
            {
                db.Add(entity);
                db.SaveChanges();

                id = entity.ContactId;
            }

            return id;
        }

        public void DeleteByKey(Guid id)
        {
            using (var db = new ContactContext(appSettings))
            {
                Contact contact = db.Contacts.FirstOrDefault(x => x.ContactId == id);
                
                if (contact == null)
                {
                    throw new KeyNotFoundException(string.Format("Could not find key {0}", id.ToString()));
                }

                db.Remove(contact);
                db.SaveChanges();
            }
        }

        public IEnumerable<Contact> FindAll()
        {
            IEnumerable<Contact> contacts;

            using (var db = new ContactContext(appSettings))
            {
                contacts = db.Contacts.ToList();
            }

            return contacts;
        }

        public Contact FindByKey(Guid id)
        {
            Contact contact;

            using (var db = new ContactContext(appSettings))
            {
                contact = db.Contacts.FirstOrDefault(x => x.ContactId == id);
            }

            return contact;
        }

        public void Update(Contact entity)
        {
            using (var db = new ContactContext(appSettings))
            {
                var contact = db.Contacts.FirstOrDefault(x => x.ContactId == entity.ContactId);

                if (contact == null)
                {
                    throw new KeyNotFoundException(string.Format("Could not find entity with id of {0}", entity.ContactId.ToString()));
                }

                db.Update(entity);
                db.SaveChanges();
            }
        }

        public int Count
        {
            get
            {
                int count = 0;

                using (var db = new ContactContext(appSettings))
                {
                    count = db.Contacts.ToList().Count;
                }

                return count;
            }
        }
    }
}
