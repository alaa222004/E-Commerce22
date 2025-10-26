

using E_Commerce.Shared.DataTransfererObjects.Basket;

namespace E_Commerce.ServiceAbstraction;

public interface IBasketService
{
    Task<CustomerBasketDTO> CreateOrUpdateAsync(CustomerBasketDTO basketDTO);
    Task<CustomerBasketDTO> GetByIdAsync(string id);
    Task<bool> DeleteAsync(string id);
}
