using Microsoft.AspNetCore.Http;
using OrderManagement.Application.Interfaces.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagement.Infrastructure.Data;

public sealed class HttpUserContext : IUserContext
{
    private readonly IHttpContextAccessor _http;
    public HttpUserContext(IHttpContextAccessor http) => _http = http;

    private ClaimsPrincipal? Principal => _http.HttpContext?.User;

    public Guid? UserId => Guid.TryParse(Principal?.FindFirstValue(ClaimTypes.NameIdentifier), out var g) ? g : null;
    public string? Role => Principal?.FindFirstValue(ClaimTypes.Role);
    public int? CustomerId => int.TryParse(Principal?.FindFirstValue("customer_id"), out var x) ? x : null;
    public int? EmployeeId => int.TryParse(Principal?.FindFirstValue("employee_id"), out var x) ? x : null;
    public bool IsInRole(string role) => Principal?.IsInRole(role) == true;
}
