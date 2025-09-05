using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Application.Dtos
{
    public class AuthDto
    {
        public sealed record LoginRequest(string UserName, string Password);
        public sealed record AuthResponse(string AccessToken, DateTime ExpiresAt, string UserName, string Role, int? CustomerId, int? EmployeeId);
    }
}
