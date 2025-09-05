using OrderManagement.Application.Dtos;
using OrderManagement.Application.Interfaces.Repositories;
using OrderManagement.Application.Interfaces.Services;

namespace OrderManagement.Application.Services
{
    public class CustomerOrderService : ICustomerOrderService
    {
        private readonly ICustomerOrderRepository _repository;

        public CustomerOrderService(ICustomerOrderRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<SalesPredictionDto>> GetSalesPredictionsAsync(
            int pageIndex,
            int pageSize,
            string sortField,
            string sortOrder,
            string? filterValue)
        {
            var predictions = await _repository.GetCustomerSalesPredictionsAsync();

            if (!string.IsNullOrEmpty(filterValue))
            {
                predictions = predictions
                    .Where(p => p.CustomerName.Contains(filterValue, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            if (sortOrder.ToLower() == "desc")
            {
                predictions = predictions.OrderByDescending(p => p.CustomerName).ToList();
            }
            else
            {
                predictions = predictions.OrderBy(p => p.CustomerName).ToList();
            }
            
            predictions = predictions
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return predictions;
        }
    }
}
