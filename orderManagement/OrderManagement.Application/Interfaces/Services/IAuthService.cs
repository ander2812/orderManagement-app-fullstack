using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OrderManagement.Application.Dtos.AuthDto;

namespace OrderManagement.Application.Interfaces.Services
{
    public interface IAuthService
    {
        Task<AuthResponse?> LoginAsync(LoginRequest request, CancellationToken ct = default);
    }
}
