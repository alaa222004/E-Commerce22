using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Shared.DataTransfererObjects.Auth;

public record RegisterDto(
    [Required]
    [EmailAddress]
    string Email,

    [Required]
    string DisplayName,

    [Required]
    [StringLength(100, MinimumLength = 6)]
    string Password
);

