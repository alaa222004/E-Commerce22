using E_Commerce.Service.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce22.Handlers;

public class NotFoundExceptionHandler(ILogger<NotFoundExceptionHandler> logger) : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext Context, Exception ex, CancellationToken cancellationToken)
    {
        if (ex is NotFoundExceptioncs)
        {
            logger.LogError("Something Wrong", ex.Message);
            var problem = new ProblemDetails
            {
                Title = "Internal Server Error",
                Detail = ex.Message,
                Instance = Context.Request.Path,
                Status = StatusCodes.Status404NotFound,
            };
            Context.Response.StatusCode = problem.Status.Value;
            await Context.Response.WriteAsJsonAsync(problem, cancellationToken);
            return true;
        }
        return false;
    }
}
