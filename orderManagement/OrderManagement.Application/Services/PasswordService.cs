using OrderManagement.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Application.Services
{

    public class BcryptPasswordService : IPasswordService
    {
        public bool Verify(string password, string passwordHash) =>
            BCrypt.Net.BCrypt.Verify(password, passwordHash);

        public string Hash(string password) =>
            BCrypt.Net.BCrypt.HashPassword(password);
    }
}
