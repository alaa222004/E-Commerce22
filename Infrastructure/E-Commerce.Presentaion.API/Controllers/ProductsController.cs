

using E_Commerce.Presentaion.API.Attributes;
using E_Commerce.ServiceAbstraction;
using E_Commerce.Shared.DataTransfererObjects;
using E_Commerce.Shared.DataTransfererObjects.Products;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace E_Commerce.Presentaion.API.Controllers;

public class ProductsController(IProductService service)
    : APIBaseController
{
    [RadisCash(5)]
    [HttpGet]
    public async Task<IActionResult> GetProducts([FromQuery] ProductQueryParameters parameters,CancellationToken cancellationToken)
    {
        var response = await service.GetProductsAsync(parameters, cancellationToken);
        return Ok(response);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProduct(int id, CancellationToken cancellationToken)
    {
        var response = await service.GetByIdAsync(id, cancellationToken);
        return Ok(response);
        //    response is not null ? Ok(response) : NotFound();
        //NotFound(new ProblemDetails{
        //        Title="Product Not Found",
        //        Status=StatusCodes.Status404NotFound,
        //        Detail=$"Product with id {id} is not found"
        //        });
    }
    [HttpGet("brands")]
    public async Task<IActionResult> GetBrands(CancellationToken cancellationToken)
    {
        var response = await service.GetBrandsAsync(cancellationToken);
        return Ok(response);
    }
    [HttpGet("types")]
    public async Task<IActionResult> GetTypes(CancellationToken cancellationToken)
     {
         var response = await service.GetTypesAsync(cancellationToken);
         return Ok(response);
    }

}
