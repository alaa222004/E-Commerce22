namespace E_Commerce.Shared.DataTransfererObjects.Auth;

public class AuthResult
{
    public bool IsSuccess { get; set; }
    public string? Message { get; set; }
    public UserResponseDto? User { get; set; }
    public IEnumerable<string>? Errors { get; set; }

    public static AuthResult Success(UserResponseDto user, string? message = null)
    {
        return new AuthResult
        {
            IsSuccess = true,
            User = user,
            Message = message ?? "Operation completed successfully"
        };
    }

    public static AuthResult Failure(string message, IEnumerable<string>? errors = null)
    {
        return new AuthResult
        {
            IsSuccess = false,
            Message = message,
            Errors = errors
        };
    }
}

