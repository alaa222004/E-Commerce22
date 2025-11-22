namespace E_Commerce.Shared.DataTransfererObjects.Auth;

public record UserResponseDto(
    string Email,
    string DisplayName,
    string? Token
);

