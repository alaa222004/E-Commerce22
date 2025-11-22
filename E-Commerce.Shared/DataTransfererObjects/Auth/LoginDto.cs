using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Shared.DataTransfererObjects.Auth;

public record LoginDto(
    [Required]
    [EmailAddress]
    string Email,

    [Required]
    string Password
);

