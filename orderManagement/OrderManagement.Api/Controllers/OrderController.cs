using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application.Dtos;
using OrderManagement.Application.Interfaces.Services;
namespace OrderManagement.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _service;

        public OrderController(IOrderService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() =>

            Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var order = await _service.GetByIdAsync(id);
            return order is null ? NotFound() : Ok(order);
        }

        [HttpGet("customer/{customerId}")]
        public async Task<IActionResult> GetOrdersByCustomerId(int customerId)
        {
            var orders = await _service.GetOrdersByCustomerIdAsync(customerId);

            return Ok(new
            {
                data = orders,
                total = orders.Count()
            });
        }

        [HttpPost]
        [Authorize(Roles = "SalesManager")]
        public async Task<IActionResult> Post([FromBody] OrderDto dto)
        {
            await _service.AddAsync(dto);
            return CreatedAtAction(nameof(Get), new { id = dto.OrderId }, dto);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "SalesManager")]
        public async Task<IActionResult> Put(int id, [FromBody] OrderDto dto)
        {
            if (id != dto.OrderId) return BadRequest();
            await _service.UpdateAsync(dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "SalesManager")]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
