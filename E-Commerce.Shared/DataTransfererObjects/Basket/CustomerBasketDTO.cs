

namespace E_Commerce.Shared.DataTransfererObjects.Basket;

public class CustomerBasketDTO
{
    public string Id { get; set; }
    public ICollection<BasketItemDTO> Items { get; set; }

}
public class BasketItemDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public string PictureUrl { get; set; }
  
}
