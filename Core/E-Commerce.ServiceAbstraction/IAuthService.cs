using E_Commerce.Shared.DataTransfererObjects.Auth;

namespace E_Commerce.ServiceAbstraction;

public interface IAuthService
{
    Task<AuthResult> RegisterAsync(RegisterDto registerDto);
    Task<AuthResult> LoginAsync(LoginDto loginDto);
}

