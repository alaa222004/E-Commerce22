
using E_Commerce.Persistence.DbInitializers;
using E_Commerce.Persistence.Repositories;
using E_Commerce.Persistence.Services;
using E_Commerce.ServiceAbstraction;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace E_Commerce.Persistence.DependencyInjection;

public static class persistenceServiceExtensions
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ICashService, CashService>();
        services.AddScoped<IBasketRepository, BasketRepository>();
        services.AddSingleton<IConnectionMultiplexer>(cfg=>
        {
        return ConnectionMultiplexer.Connect(configuration.GetConnectionString("RedisConnection"));
        });
        services.AddDbContext<ApplicationDBContext>(options =>
        {
            var connection = configuration.GetConnectionString("SQLConnection");
            options.UseSqlServer(connection);
        });
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IDbInitializer, DbInitializer>();
        return services;
    }

}