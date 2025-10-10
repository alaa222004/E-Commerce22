//REST APIS 
using E_Commerce.Domain.Contracts;
using E_Commerce.Persistence.DependencyInjection;
using E_Commerce.Service.DependencyInjection;
namespace E_Commerce.Web

{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
           
            builder.Services.AddControllers();
            builder.Services.AddApplicationServices();

            builder.Services.AddPersistenceServices(builder.Configuration);

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            #region INITIALIZE DB
            var scope = app.Services.CreateScope();
            var initializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
            await initializer.InitializeAsync();
            #endregion

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseStaticFiles();
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();//??

            app.Run();
        }
    }
}