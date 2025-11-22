using E_Commerce.Domain.Entities.Auth;
using E_Commerce.Persistence.AuthContext;
using E_Commerce.Persistence.Context;
using Microsoft.AspNetCore.Identity;

namespace E_Commerce.Persistence.DbInitializers;

public class AuthDbInitializer
{
    private readonly Context.AuthDbContext _context;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public AuthDbInitializer(
        Context.AuthDbContext context,
        UserManager<ApplicationUser> userManager,
        RoleManager<IdentityRole> roleManager)
    {
        _context = context;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public async Task InitializeAsync()
    {
        // Ensure database is created
        await _context.Database.EnsureCreatedAsync();

        // Create roles if they don't exist
        if (!await _roleManager.RoleExistsAsync("Admin"))
        {
            await _roleManager.CreateAsync(new IdentityRole("Admin"));
        }

        if (!await _roleManager.RoleExistsAsync("User"))
        {
            await _roleManager.CreateAsync(new IdentityRole("User"));
        }

        // Create default admin user if it doesn't exist
        var adminEmail = "admin@ecommerce.com";
        var adminUser = await _userManager.FindByEmailAsync(adminEmail);

        if (adminUser == null)
        {
            adminUser = new ApplicationUser
            {
                Email = adminEmail,
                UserName = adminEmail,
                DisplayName = "Administrator"
            };

            var result = await _userManager.CreateAsync(adminUser, "Admin@123");
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(adminUser, "Admin");
            }
        }

        // Create default test user if it doesn't exist
        var testEmail = "user@ecommerce.com";
        var testUser = await _userManager.FindByEmailAsync(testEmail);

        if (testUser == null)
        {
            testUser = new ApplicationUser
            {
                Email = testEmail,
                UserName = testEmail,
                DisplayName = "Test User"
            };

            var result = await _userManager.CreateAsync(testUser, "User@123");
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(testUser, "User");
            }
        }
    }
}

