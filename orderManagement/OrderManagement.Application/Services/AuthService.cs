using OrderManagement.Application.Interfaces.Repositories;
using OrderManagement.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OrderManagement.Application.Dtos.AuthDto;

namespace OrderManagement.Application.Services
{
    public class AuthService: IAuthService
    {
        private readonly IUserRepository _users;
        private readonly IPasswordService _pwd;
        private readonly ITokenService _tokens;

        public AuthService(IUserRepository users, IPasswordService pwd, ITokenService tokens)
        {
            _users = users; _pwd = pwd; _tokens = tokens;
        }

        public async Task<AuthResponse?> LoginAsync(LoginRequest request, CancellationToken ct = default)
        {
            var user = await _users.GetByUserNameAsync(request.UserName, ct);
            if (user is null) return null;
            if (!_pwd.Verify(request.Password, user.PasswordHash)) return null;

            return _tokens.CreateAccessToken(user);
        }
    }
}
