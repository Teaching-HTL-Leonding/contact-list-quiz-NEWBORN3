using System.Collections.Generic;
namespace AddressBookApi.Services
{
    public interface IContactsRepository
    {
        Person Add(Person person);
        IEnumerable<Person> GetAllContacts();
        Person GetContactById(int id);
        void Delete(int id);
    }
}