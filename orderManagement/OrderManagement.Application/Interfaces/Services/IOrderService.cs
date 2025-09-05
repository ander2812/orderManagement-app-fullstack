using OrderManagement.Application.Dtos;
using OrderManagement.Domain.Entities;

namespace OrderManagement.Application.Interfaces.Services
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDto>> GetAllAsync();
        Task<OrderDto?> GetByIdAsync(int id);
        Task AddAsync(OrderDto dto);
        Task UpdateAsync(OrderDto dto);
        Task DeleteAsync(int id);
        Task<IEnumerable<Order>> GetOrdersByCustomerIdAsync(int customerId);
    }
}