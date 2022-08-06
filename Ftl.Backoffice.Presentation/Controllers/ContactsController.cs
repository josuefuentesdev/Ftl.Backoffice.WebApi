using Ftl.Backoffice.Application.Contact;
using Ftl.Backoffice.Application.Contact.Dtos;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ftl.Backoffice.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult> GetContacts()
        {
            var result = await _contactService.GetAsync();
            return result == null ?
                NotFound() :
                Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        public async Task<ActionResult> GetContactById(int id)
        {
            var result = await _contactService.GetOneAsync(id);
            return result == null ?
                NotFound() :
                Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<ActionResult<int>> CreateContact(CreateContactDto createContactDto)
        {
            var result = await _contactService.CreateAsync(createContactDto);
            
            return CreatedAtAction(nameof(GetContactById), new { id = result.Id }, result.Id);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        public async Task<ActionResult> UpdateContact(int id, UpdateContactDto update)
        {
            var result = await _contactService.UpdateAsync(id, update);

            return result == null ?
                NotFound() :
                NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        public async Task<ActionResult> DeleteContact(int id)
        {
            var result = await _contactService.DeleteAsync(id);

            return result == null ?
                NotFound() :
                Ok(result);
                
        }
    }
}
