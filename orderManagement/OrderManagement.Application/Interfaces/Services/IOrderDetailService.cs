using OrderManagement.Application.Dtos;

namespace OrderManagement.Application.Interfaces.Services
{
    public interface IOrderDetailService
    {
        Task<IEnumerable<OrderDetailDto>> GetAllAsync();
        Task<OrderDetailDto?> GetByIdAsync(int id);
        Task AddAsync(OrderDetailDto dto);
        Task UpdateAsync(OrderDetailDto dto);
        Task DeleteAsync(int id);
    }
}
