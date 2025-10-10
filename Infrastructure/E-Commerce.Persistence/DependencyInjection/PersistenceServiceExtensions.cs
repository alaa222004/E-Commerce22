
using E_Commerce.Domain.Contracts;
using E_Commerce.Persistence.Context;
using E_Commerce.Persistence.DbInitializers;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace E_Commerce.Persistence.DependencyInjection
{
    public static class persistenceServiceExtensions
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDBContext>(options =>
            {
                var connection = configuration.GetConnectionString("SQLConnection");
                options.UseSqlServer(connection);
            });
            services.AddScoped<IDbInitializer, DbInitializer>();
            return services;
        }

    }
}