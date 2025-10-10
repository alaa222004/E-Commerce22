

namespace E_Commerce.Shared.DataTransfererObjects;

public record ProductResponse

{
#nullable disable
    public int Id { get; init; }
    public string Name { get; init; } 
    public string Description { get; init; }
    public decimal Price { get; init; }
    public string PictureUrl { get; init; } 
    public string Brand { get; init; } 
    public string Type { get; init; } 
}
