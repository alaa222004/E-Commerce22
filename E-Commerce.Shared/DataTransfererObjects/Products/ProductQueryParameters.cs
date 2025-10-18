namespace E_Commerce.Shared.DataTransfererObjects.Products
{
    public class ProductQueryParameters
    {
        private int maxPageSize = 10;
        private int defaultPageSize = 5;
        public int ? BrandId { get; set; }
        public int ? TypeId { get; set; }
        public string? Search { get; set; }
        public ProductSortingOptions? Sort { get; set; }
        private int  pageSize ;
        public int PageSize 
        { 
            get=> pageSize;
            set=>PageSize=value>maxPageSize?defaultPageSize:value<defaultPageSize?defaultPageSize:value; 
        }
        public int PageIndex { get; set; } = 1;
    }
    public enum ProductSortingOptions
    {
        NameAscending = 1,
        NameDescending = 2,
        PriceAscending = 3,
        PriceDescending = 4

    }

    
}
