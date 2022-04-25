using System;
using System.Collections.Generic;
using System.Linq;

namespace AddressBookApi.Services
{
    public class ContactsRepository : IContactsRepository
    {
        private List<Person> Persons = new List<Person>();

        public Person Add(Person person)
        {
            Persons.Add(person);
            return person;
        }

        public IEnumerable<Person> GetAllContacts()
        {
            return Persons;
        }

        public Person GetContactById(int id)
        {
            return Persons.FirstOrDefault(p => p.Id == id);
        }

        public void Delete(int id)
        {
            var personToDelete = Persons.FirstOrDefault(p => p.Id == id);
            if (personToDelete == null)
            {
                throw new ArgumentException("No event exists", nameof(id));
            }
            Persons.Remove(personToDelete);
        }

    }
}