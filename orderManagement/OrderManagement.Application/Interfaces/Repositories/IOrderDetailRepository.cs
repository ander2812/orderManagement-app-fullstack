using OrderManagement.Domain.Entities;

namespace OrderManagement.Application.Interfaces.Repositories
{
    public interface IOrderDetailRepository
    {
        Task<IEnumerable<OrderDetail>> GetAllAsync();
        Task<OrderDetail?> GetByIdAsync(int id);
        Task AddAsync(OrderDetail orderDetail);
        Task UpdateAsync(OrderDetail orderDetail);
        Task DeleteAsync(int id);
    }
}
