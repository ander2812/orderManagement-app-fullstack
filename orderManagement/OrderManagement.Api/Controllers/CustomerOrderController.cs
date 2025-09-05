using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application.Dtos;
using OrderManagement.Application.Interfaces.Services;

namespace OrderManagement.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerOrderController : ControllerBase
    {
        private readonly ICustomerOrderService _customerOrderService;

        public CustomerOrderController(ICustomerOrderService customerOrderService)
        {
            _customerOrderService = customerOrderService;
        }

        [HttpGet("salespredictions")]
        public async Task<ActionResult<List<SalesPredictionDto>>> GetSalesPredictions(
            [FromQuery] int pageIndex,
            [FromQuery] int pageSize,
            [FromQuery] string sortField,
            [FromQuery] string sortOrder,
            [FromQuery] string? filterValue)
        {
            var predictions = await _customerOrderService.GetSalesPredictionsAsync(
                pageIndex,
                pageSize,
                sortField,
                sortOrder,
                filterValue
            );

            return Ok(new
            {
                data = predictions,
                total = predictions.Count()
            });
        }
    }
}