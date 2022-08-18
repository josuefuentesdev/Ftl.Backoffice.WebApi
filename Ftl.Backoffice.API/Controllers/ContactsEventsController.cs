using Ftl.Backoffice.Application.ContactEvent;
using Ftl.Backoffice.Application.ContactEvent.Dtos;
using Ftl.Backoffice.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ftl.Backoffice.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactEventsController : ControllerBase
    {
        private readonly IContactEventService _contactService;

        public ContactEventsController(IContactEventService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<IList<ContactEventItem>>> GetContactEvents([FromQuery] int? contactId)
        {
            var result = await _contactService.GetAsync(contactId);
            return result == null ?
                NotFound() :
                Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<ContactEventItem>> GetContactEventById(Guid id)
        {
            var result = await _contactService.GetOneAsync(id);
            return result == null ?
                NotFound() :
                Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<ActionResult<Guid>> CreateContactEvent(CreateContactEventDto ContactEventDto)
        {
            var result = await _contactService.CreateAsync(ContactEventDto);

            return CreatedAtAction(nameof(GetContactEventById), new { id = result.Id }, result.Id);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        public async Task<ActionResult> UpdateContactEvent(Guid id, UpdateContactEventDto update)
        {
            var result = await _contactService.UpdateAsync(id, update);

            return result == null ?
                NotFound() :
                NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        public async Task<ActionResult> DeleteContactEvent(Guid id)
        {
            var result = await _contactService.DeleteAsync(id);

            return result == null ?
                NotFound() :
                NoContent();
        }
    }
}
