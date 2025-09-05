using OrderManagement.Application.Dtos;

namespace OrderManagement.Application.Interfaces.Repositories
{
    public interface ICustomerOrderRepository
    {
        Task<List<SalesPredictionDto>> GetCustomerSalesPredictionsAsync();
    }
}
