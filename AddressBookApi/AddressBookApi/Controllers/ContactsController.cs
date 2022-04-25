using System.Net.Mail;
using System.Net;
using System.Collections;
using AddressBookApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace AddressBookApi.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ContactsController : ControllerBase
    {
        private IContactsRepository repo;
        public ContactsController(IContactsRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Person>))]
        public IActionResult GetAll()
        {
            return Ok(repo.GetAllContacts());
        }

        [HttpGet("{personId}", Name = nameof(GetById))]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Person))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public IActionResult GetById(int personId)
        {
            var person = repo.GetContactById(personId);
            return person != null ? Ok(person) : BadRequest("Invalid or missing name");
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Person))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddContact([FromBody] Person person)
        {
            if (person.Id == 0 || person.Email == null)
            {
                return BadRequest("Invalid Input, rquired field missing");
            }
            repo.Add(person);
            return CreatedAtAction(nameof(GetById), new { personId = person.Id }, person);
        }

        [HttpDelete("{personId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Delete(int personId)
        {
            if (personId < 1) return BadRequest("Invalid ID supplied");
            var personToDelete = repo.GetContactById(personId);
            if (personToDelete == null) return NotFound();
            repo.Delete(personId);
            return NoContent();
        }
    }
}