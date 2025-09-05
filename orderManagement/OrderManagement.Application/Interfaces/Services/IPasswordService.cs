namespace OrderManagement.Application.Interfaces.Services
{
    public interface IPasswordService
    {
        bool Verify(string password, string passwordHash);
        string Hash(string password);
    }
}
