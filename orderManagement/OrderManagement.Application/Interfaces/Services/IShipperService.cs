using OrderManagement.Application.Dtos;

namespace OrderManagement.Application.Interfaces.Services
{
    public interface IShipperService
    {
        Task<IEnumerable<ShipperDto>> GetAllAsync();
        Task<ShipperDto?> GetByIdAsync(int id);
        Task AddAsync(ShipperDto dto);
        Task UpdateAsync(ShipperDto dto);
        Task DeleteAsync(int id);
    }
}
