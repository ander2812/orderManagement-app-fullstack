using OrderManagement.Application.Dtos;

namespace OrderManagement.Application.Interfaces.Services
{
    public interface ICustomerOrderService
    {
        Task<List<SalesPredictionDto>> GetSalesPredictionsAsync(
            int pageIndex,
            int pageSize,
            string sortField,
            string sortOrder,
            string? filterValue);
    }
}
