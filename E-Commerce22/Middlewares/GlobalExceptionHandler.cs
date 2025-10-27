using E_Commerce.Service.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace E_Commerce22.Middlewares;

public class GlobalExceptionHandler(RequestDelegate next,
    ILogger<GlobalExceptionHandler> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await next.Invoke(context);

            if(context.Response.StatusCode==StatusCodes.Status404NotFound)
            {
                var problem=new ProblemDetails
                {
                    Title="Resource Not Found",
                    Detail=$"The resource at {context.Request.Path} was not found.",
                    Status= StatusCodes.Status404NotFound,
                    Instance=context.Request.Path,
                };
                await context.Response.WriteAsJsonAsync(problem);
            }


        }
        catch (Exception ex)
        {
            logger.LogError("Something Wrong", ex.Message);
            var problem = new ProblemDetails
            {
                Title = "Internal Server Error",
                Detail = ex.Message,
                Instance = context.Request.Path,
              Status =ex switch
                {
                    NotFoundExceptioncs => StatusCodes.Status404NotFound,
                    _ => StatusCodes.Status500InternalServerError
                }
            };
            context.Response.StatusCode = problem.Status.Value;
            await context.Response.WriteAsJsonAsync(problem);
        }
    }
}
public static class GlobalExceptionHandlerExtensions
{
   public static WebApplication UseCustomExceptionHandler(this WebApplication app)
    {
        app.UseMiddleware<GlobalExceptionHandler>();
        return app;
    }
}
