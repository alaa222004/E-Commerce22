

using E_Commerce.ServiceAbstraction;
using E_Commerce.Shared.DataTransfererObjects.Basket;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Presentaion.API.Controllers;

public class BasketController (IBasketService basketService):APIBaseController
{
    [HttpPost]
    public async Task<ActionResult<CustomerBasketDTO>> Update(CustomerBasketDTO basketDTO)
    {
       return Ok(await basketService.CreateOrUpdateAsync(basketDTO));
    }
    [HttpGet]
    public async Task<ActionResult<CustomerBasketDTO>> Get(string Id)
    {
        return Ok( await basketService.GetByIdAsync(Id));
    }
    [HttpDelete]
    public async Task<ActionResult<CustomerBasketDTO>> Delete(string Id)
    {
        return Ok( await basketService.DeleteAsync(Id));
    }
}
