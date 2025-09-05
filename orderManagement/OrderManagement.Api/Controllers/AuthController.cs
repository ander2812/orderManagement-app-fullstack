using OrderManagement.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Application.Dtos;
using static OrderManagement.Application.Dtos.AuthDto;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _auth;
    public AuthController(IAuthService auth) => _auth = auth;

    [HttpPost("login")]
    [ProducesResponseType(typeof(AuthResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<IActionResult> Login([FromBody] LoginRequest request, CancellationToken ct)
    {
        var result = await _auth.LoginAsync(request, ct);
        if (result is null) return Unauthorized();
        return Ok(result);
    }
}
