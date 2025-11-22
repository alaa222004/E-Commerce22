using E_Commerce.ServiceAbstraction;
using E_Commerce.Shared.DataTransfererObjects.Auth;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Presentaion.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<ActionResult<UserResponseDto>> Register(RegisterDto registerDto)
    {
        var result = await _authService.RegisterAsync(registerDto);

        if (!result.IsSuccess)
        {
            return BadRequest(result);
        }

        return Ok(result.User);
    }

    [HttpPost("login")]
    public async Task<ActionResult<UserResponseDto>> Login(LoginDto loginDto)
    {
        var result = await _authService.LoginAsync(loginDto);

        if (!result.IsSuccess)
        {
            return Unauthorized(result);
        }

        return Ok(result.User);
    }
}

