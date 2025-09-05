using Microsoft.EntityFrameworkCore;
using OrderManagement.Application.Interfaces.Repositories;
using OrderManagement.Domain.Entities;
using OrderManagement.Infrastructure.Data;

namespace OrderManagement.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _db;
        public UserRepository(ApplicationDbContext db) => _db = db;

        public Task<User?> GetByUserNameAsync(string userName, CancellationToken ct = default) =>
            _db.Set<User>().FirstOrDefaultAsync(u => u.UserName == userName && u.IsActive, ct);
    }
}
