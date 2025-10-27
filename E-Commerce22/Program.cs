//REST APIS 
using E_Commerce.Domain.Contracts;
using E_Commerce.Persistence.DependencyInjection;
using E_Commerce.Service.DependencyInjection;
using E_Commerce22.Handlers;
using E_Commerce22.Middlewares;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
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
            builder.Services.AddExceptionHandler<NotFoundExceptionHandler>();
            builder.Services.AddProblemDetails();
            builder.Services.Configure<ApiBehaviorOptions>(Options =>
            {
                Options.InvalidModelStateResponseFactory = ActionContext =>
                {
                    var errors = ActionContext.ModelState
                        .Where(e => e.Value.Errors.Count > 0)
                        .ToDictionary(
                            kvp => kvp.Key,
                            kvp => kvp.Value.Errors.
                            Select(e => e.ErrorMessage).ToArray());

                    var problemDetails = new ValidationProblemDetails(errors)
                    {
                        Title = "validation errors occurred.",
                        Status = StatusCodes.Status400BadRequest,
                        Detail = "See the errors property for details.",
                        Extensions = { { "eroor",errors } }
                    };

                    return new BadRequestObjectResult("problemDetails");
                };
            });

            var app = builder.Build();

            #region INITIALIZE DB
            var scope = app.Services.CreateScope();
            var initializer = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
            await initializer.InitializeAsync();
            #endregion


            //app.Use(async (context, next) =>
            //{
            //    try
            //    {
            //        await next.Invoke(context);
            //    }
            //    catch(Exception ex)
            //    {
            //        Console.WriteLine(ex.Message);
            //        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            //        await context.Response.WriteAsJsonAsync(new 
            //        {
            //          StatusCodes= StatusCodes.Status500InternalServerError,
            //          Massage=ex.Message

            //        });

            //    }

            //});
            //app.UseCustomExceptionHandler();
            app.UseExceptionHandler();


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