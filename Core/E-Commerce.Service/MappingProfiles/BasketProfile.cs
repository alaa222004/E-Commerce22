using AutoMapper;
using E_Commerce.Domain.Entities.Basket;
using E_Commerce.Shared.DataTransfererObjects.Basket;


namespace E_Commerce.Service.MappingProfiles;

public class BasketProfile:Profile
{
    public BasketProfile()
    {
        CreateMap<BasketItem, BasketItemDTO>().ReverseMap();
        CreateMap<CustomerBasket, CustomerBasketDTO>().ReverseMap();
    }
}
