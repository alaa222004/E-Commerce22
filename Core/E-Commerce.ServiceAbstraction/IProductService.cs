using E_Commerce.Shared.DataTransfererObjects.Products;

namespace E_Commerce.ServiceAbstraction;

public interface IProductService
{
    Task<ProductResponse>GetByIdAsync( int Id ,CancellationToken cancellationToken=default );
    Task<IEnumerable<ProductResponse>>GetProductsAsync( ProductQueryParameters parameters,CancellationToken cancellationToken=default);
    Task<IEnumerable<BrandResponse>>GetBrandsAsync(CancellationToken cancellationToken=default);
    Task<IEnumerable<TypeResponse>>GetTypesAsync(CancellationToken cancellationToken=default);


}
 