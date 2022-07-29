﻿using Ftl.Backoffice.Application.Contact;
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
        public async Task<ActionResult> Get()
        {
            var result = await _contactService.GetAsync();
            return result == null ?
                NotFound() :
                Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetOne(int id)
        {
            var result = await _contactService.GetOneAsync(id);
            return result == null ?
                NotFound() :
                Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult> Post(CreateContactDto createContactDto)
        {
            var result = await _contactService.CreateAsync(createContactDto);

            return CreatedAtAction(nameof(Get), new { id = result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, UpdateContactDto update)
        {
            var result = await _contactService.UpdateAsync(id, update);

            return result == null ?
                NotFound() :
                NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _contactService.DeleteAsync(id);

            return result == null ?
                NotFound() :
                Ok(result);
                
        }
    }
}
