using E_Commerce.ServiceAbstraction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Mime;
using System.Text;

namespace E_Commerce.Presentaion.API.Attributes;

internal class RadisCashAttribute(int durationInMin) : ActionFilterAttribute
{
    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
       var cashService= context.HttpContext.RequestServices.GetRequiredService<ICashService>();

        string Key=GenerateCashKey(context.HttpContext.Request);

        var cachedValue = await cashService.GetAsync(Key);
        if (cashService != null)
        {
            context.Result = new ContentResult
            {
                Content = cachedValue,
                ContentType = "application/json",
                StatusCode=StatusCodes.Status200OK,
            };
            return;
        }

     var actionExecutedContext=  await next.Invoke();
        var result= actionExecutedContext.Result;
        if (result is OkObjectResult okResult)
        {
            await cashService.SetAsync(Key, okResult.Value,TimeSpan.FromMinutes(durationInMin));
        }
        throw new NotImplementedException();
    }
    private static string GenerateCashKey(HttpRequest request)
    {
        var sb = new StringBuilder();
        foreach (var Kvp in request.Query.OrderBy(x => x.Key))
        {
            sb.Append($"{Kvp.Key}-{Kvp.Value}");
        }
        return sb.ToString().Trim('-');
    }
}
