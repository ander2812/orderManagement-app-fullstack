using OrderManagement.Application.Dtos;

namespace OrderManagement.Application.Interfaces.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDto>> GetAllAsync();
        Task<EmployeeDto?> GetByIdAsync(int id);
        Task AddAsync(EmployeeDto dto);
        Task UpdateAsync(EmployeeDto dto);
        Task DeleteAsync(int id);
    }
}
