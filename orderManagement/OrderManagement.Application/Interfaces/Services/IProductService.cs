using OrderManagement.Application.Dtos;

namespace OrderManagement.Application.Interfaces.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetAllAsync();
        Task<ProductDto?> GetByIdAsync(int id);
        Task AddAsync(ProductDto dto);
        Task UpdateAsync(ProductDto dto);
        Task DeleteAsync(int id);
    }
}
