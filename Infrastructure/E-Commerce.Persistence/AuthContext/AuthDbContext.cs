

using E_Commerce.Domain.Entities.Auth;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace E_Commerce.Persistence.AuthContext;

public class AuthDbContext(DbContextOptions<AuthDbContext> options):
    IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Address> Addresses { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
    }
}
