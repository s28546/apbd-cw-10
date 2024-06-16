using Microsoft.AspNetCore.Mvc;
using WebApplication1.DTO;
using WebApplication1.Services;
using RegisterRequest = WebApplication1.DTO.RegisterRequest;
using LoginRequest = WebApplication1.DTO.LoginRequest;

namespace WebApplication1.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IAuthService _authService;

    public AuthController(IUserService userService, IAuthService authService)
    {
        _userService = userService;
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        await _userService.Register(request);
        return Ok();
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var tokenResponse = await _authService.Authenticate(request);
        if (tokenResponse == null) 
            return Unauthorized();
        return Ok(tokenResponse);
    }

    [HttpPost("refresh")]
    public async Task<IActionResult> Refresh(RefreshTokenRequest request)
    {
        var tokenResponse = await _authService.RefreshToken(request);
        if (tokenResponse == null)
            return Unauthorized();
        return Ok(tokenResponse);
    }
}