using System.Collections.Generic;
namespace AddressBookApi.Services
{
    public interface IContactsRepository
    {
        Person Add(Person person);
        IEnumerable<Person> GetAllContacts();
        Person GetContactByName(string name);
        void Delete(int id);
    }
}