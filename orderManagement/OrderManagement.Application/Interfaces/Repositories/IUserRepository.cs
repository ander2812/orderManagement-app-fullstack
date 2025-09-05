using OrderManagement.Domain.Entities;

namespace OrderManagement.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetByUserNameAsync(string userName, CancellationToken ct = default);
    }
}
