using AutoMapper;
using E_Commerce.Domain.Contracts;
using E_Commerce.Domain.Entities.Products;
using E_Commerce.ServiceAbstraction;
using E_Commerce.Shared.DataTransfererObjects;

namespace E_Commerce.Service.Services;

internal class ProductService (IUnitOfWork unitOfWork,IMapper mapper)
    : IProductService
{
    public async Task<IEnumerable<BrandResponse>> GetBrandsAsync(CancellationToken cancellationToken = default)
    {
      var brands=await  unitOfWork.GetRepository<ProductBrand, int>()
        .GetAllAsync(cancellationToken);
        return mapper.Map<IEnumerable<BrandResponse>>(brands);
     
    }

    public Task<ProductResponse> GetByIdAsync(int Id, CancellationToken cancellationToken = default)
    {
        var product = unitOfWork.GetRepository<Product, int>()
          .GetByIdAsync(Id, cancellationToken);
        return mapper.Map<Task<ProductResponse>>(product);
    }

    public async Task<IEnumerable<ProductResponse>> GetProductsAsync(CancellationToken cancellationToken = default)
    {

        var products = await unitOfWork.GetRepository<Product, int>()
          .GetAllAsync(cancellationToken);
        return mapper.Map<IEnumerable<ProductResponse>>(products);
    }

    public async Task<IEnumerable<TypeResponse>> GetTypesAsync(CancellationToken cancellationToken = default)
    {
        var types = await unitOfWork.GetRepository<ProductType, int>()
         .GetAllAsync(cancellationToken);
        return mapper.Map<IEnumerable<TypeResponse>>(types);
    }
}
