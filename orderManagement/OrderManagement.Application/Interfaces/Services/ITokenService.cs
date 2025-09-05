using OrderManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static OrderManagement.Application.Dtos.AuthDto;

namespace OrderManagement.Application.Interfaces.Services
{
    public interface ITokenService
    {
        AuthResponse CreateAccessToken(User user);
    }
}
