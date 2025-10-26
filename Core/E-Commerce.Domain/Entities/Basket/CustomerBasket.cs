﻿

namespace E_Commerce.Domain.Entities.Basket;

public class CustomerBasket
{
    public string Id { get; set; } = default!;
    public List<BasketItem> Items { get; set; } = [];
}
