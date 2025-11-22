using Microsoft.AspNetCore.Identity;

namespace E_Commerce.Domain.Entities.Auth;

public class ApplicationUser : IdentityUser
{
    public string DisplayName { get; set; } = string.Empty;
    public UserAddress? Address { get; set; }
}

