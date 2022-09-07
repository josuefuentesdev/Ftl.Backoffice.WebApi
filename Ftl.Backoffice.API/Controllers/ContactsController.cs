using Ftl.Backoffice.Application.Contact;
using Ftl.Backoffice.Application.Contact.Dtos;
using Ftl.Backoffice.Application.Order.Dtos;
using Ftl.Backoffice.Core.Entities;
using Microsoft.AspNetCore.Mvc;


namespace Ftl.Backoffice.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;
        private string _tokenSecret;

        public ContactsController(IContactService contactService, IConfiguration configuration)
        {
            _contactService = contactService;
            _tokenSecret = configuration.GetValue<string>("contacttoken");
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IList<GetContactsResponseDto>>> GetContacts([FromQuery] FilterContactDto filters)
        {
            var result = await _contactService.GetAsync(filters);
            return result == null ?
                NotFound() :
                Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<GetOneContactResponseDto>> GetContactById(int id, [FromQuery] string? token)
        {
            GetOneContactResponseDto result;
            if (_tokenSecret != null && token == _tokenSecret)
            {
                result = await _contactService.GetOneAsync(id, false);
            } else
            {
                result = await _contactService.GetOneAsync(id);
            }
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
                NoContent();
                
        }
    }
}
