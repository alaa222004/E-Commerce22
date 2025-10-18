﻿using System.Linq.Expressions;
using System.Xml.Linq;
using E_Commerce.Domain.Entities.Products;
using E_Commerce.Shared.DataTransfererObjects.Products;

namespace E_Commerce.Service.Specifications
{
    internal class ProductWithBrandTypeSpecification: BaseSpecification<Product>
    {
        public ProductWithBrandTypeSpecification(ProductQueryParameters parameters)
            : base(CreateCriteria(parameters))
        {
            Includes.Add(p => p.ProductBrand);
            Includes.Add(p => p.ProductType);
            ApplyPagination(parameters.PageSize, parameters.PageIndex);

            switch (parameters.Sort)
            {
                case ProductSortingOptions.NameAscending:
                    AddOrderBy(p => p.Name);
                    break;
                case ProductSortingOptions.NameDescending:
                    AddOrderByDesc(p => p.Name);
                    break;
                case ProductSortingOptions.PriceDescending:
                    AddOrderByDesc(p => p.Price);
                    break;
                case ProductSortingOptions.PriceAscending:
                    AddOrderBy(p => p.Price);
                    break;
                default:
                    AddOrderBy(p => p.Name);
                    break;
            }
        }
        private static Expression<Func<Product, bool>> CreateCriteria(ProductQueryParameters parameters)
        {
            return p => (!parameters.BrandId.HasValue || p.BrandId == parameters.BrandId) &&
                       (!parameters.TypeId.HasValue ||p.TypeId == parameters.TypeId)
                       &&(string.IsNullOrWhiteSpace(parameters.Search) || p.Name.Contains(parameters.Search));
                    

        }
        public ProductWithBrandTypeSpecification(int id) 
            : base(p=>p.Id==id)
        {
            Includes.Add(p => p.ProductBrand);
            Includes.Add(p => p.ProductType);
        }
    }
}
