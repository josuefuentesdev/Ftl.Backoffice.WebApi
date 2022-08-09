using Ftl.Backoffice.Application.Order;
using Ftl.Backoffice.Application.Order.Dtos;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ftl.Backoffice.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _contactService;

        public OrdersController(IOrderService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult> GetOrders(string? executionId)
        {
            var result = await _contactService.GetAsync(executionId);
            return result == null ?
                NotFound() :
                Ok(result);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        public async Task<ActionResult> GetOrderById(int id)
        {
            var result = await _contactService.GetOneAsync(id);
            return result == null ?
                NotFound() :
                Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<ActionResult<int>> CreateOrder(CreateOrderDto createOrderDto)
        {
            var result = await _contactService.CreateAsync(createOrderDto);
            
            return CreatedAtAction(nameof(GetOrderById), new { id = result.Id }, result.Id);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(204)]
        public async Task<ActionResult> UpdateOrder(int id, UpdateOrderDto update)
        {
            var result = await _contactService.UpdateAsync(id, update);

            return result == null ?
                NotFound() :
                NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        public async Task<ActionResult> DeleteOrder(int id)
        {
            var result = await _contactService.DeleteAsync(id);

            return result == null ?
                NotFound() :
                NoContent();
        }
    }
}
