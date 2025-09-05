using OrderManagement.Domain.Entities;

namespace OrderManagement.Application.Interfaces.Repositories
{
    public interface IShipperRepository
    {
        Task<IEnumerable<Shipper>> GetAllAsync();
        Task<Shipper?> GetByIdAsync(int id);
        Task AddAsync(Shipper shipper);
        Task UpdateAsync(Shipper shipper);
        Task DeleteAsync(int id);
    }
}
