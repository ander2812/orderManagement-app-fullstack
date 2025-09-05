namespace OrderManagement.Application.Interfaces.Context
{
    public interface IUserContext
    {
        Guid? UserId { get; }
        string? Role { get; }
        int? CustomerId { get; }
        int? EmployeeId { get; }
        bool IsInRole(string role);
    }
}
