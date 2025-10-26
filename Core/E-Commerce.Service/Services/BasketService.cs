

using AutoMapper;
using E_Commerce.Domain.Contracts;
using E_Commerce.Domain.Entities.Basket;
using E_Commerce.ServiceAbstraction;
using E_Commerce.Shared.DataTransfererObjects.Basket;

namespace E_Commerce.Service.Services;

internal class BasketService(IBasketRepository basketRepository, IMapper mapper) : IBasketService
{
    public async Task<CustomerBasketDTO> CreateOrUpdateAsync(CustomerBasketDTO basketDTO)
    {

        var basket =mapper.Map<CustomerBasket>(basketDTO);
        var updateBasket = await basketRepository.CreateOrUpdateAsync(basket);
        return mapper.Map<CustomerBasketDTO>(updateBasket);
    }

    public Task<bool> DeleteAsync(string id)
    =>basketRepository.DeleteAsync(id);
    public async Task<CustomerBasketDTO> GetByIdAsync(string id)
    {
       var basket =await basketRepository.GetAsync(id);
        return mapper.Map<CustomerBasketDTO>(basket);
    }
}
