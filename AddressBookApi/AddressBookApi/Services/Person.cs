using System.ComponentModel.DataAnnotations;

namespace AddressBookApi.Services
{
    public class Person
    {
        [Required]
        public int Id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        [Required]
        public string Email { get; set; }
    }
}