using OrderManagement.Application.Dtos;

namespace OrderManagement.Application.Interfaces.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerDto>> GetAllAsync();
        Task<CustomerDto?> GetByIdAsync(int id);
        Task AddAsync(CustomerDto dto);
        Task UpdateAsync(CustomerDto dto);
        Task DeleteAsync(int id);
    }
}
