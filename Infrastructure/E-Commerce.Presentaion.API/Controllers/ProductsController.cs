

using E_Commerce.ServiceAbstraction;
using Microsoft.AspNetCore.Mvc;


namespace E_Commerce.Presentaion.API.Controllers;

public class ProductsController(IProductService service)
    : APIBaseController
{

    [HttpGet]
    public async Task<IActionResult> GetProducts(CancellationToken cancellationToken)
    {
        var response = await service.GetProductsAsync(cancellationToken);
        return Ok(response);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProduct(int id, CancellationToken cancellationToken)
    {
        var response = await service.GetByIdAsync(id, cancellationToken);
        return Ok(response);
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
