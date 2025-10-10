

using E_Commerce.Service.Services;
using E_Commerce.ServiceAbstraction;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace E_Commerce.Service.DependencyInjection;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IProductService, ProductService>();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        return services;
    }

}
