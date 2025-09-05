using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OrderManagement.Domain.Entities;
using OrderManagement.Application.Auth;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static OrderManagement.Application.Dtos.AuthDto;
using OrderManagement.Application.Interfaces.Services;

namespace OrderManagement.Application.Services;

public class TokenService : ITokenService
{
    private readonly JwtOptions _opts;
    public TokenService(IOptions<JwtOptions> opts) => _opts = opts.Value;

    public AuthResponse CreateAccessToken(User user)
    {
        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Name, user.UserName),
            new(ClaimTypes.Role, user.Role)
        };

        if (user.CustomerId.HasValue)
            claims.Add(new("customer_id", user.CustomerId.Value.ToString()));
        if (user.EmployeeId.HasValue)
            claims.Add(new("employee_id", user.EmployeeId.Value.ToString()));

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_opts.Key));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expires = DateTime.UtcNow.AddMinutes(_opts.AccessTokenMinutes);

        var token = new JwtSecurityToken(
            issuer: _opts.Issuer,
            audience: _opts.Audience,
            claims: claims,
            expires: expires,
            signingCredentials: creds
        );

        var jwt = new JwtSecurityTokenHandler().WriteToken(token);
        return new AuthResponse(jwt, expires, user.UserName, user.Role, user.CustomerId, user.EmployeeId);
    }
}
