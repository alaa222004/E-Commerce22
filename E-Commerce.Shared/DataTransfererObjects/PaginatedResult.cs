namespace E_Commerce.Shared.DataTransfererObjects;

public record PaginatedResult(
    int PageIndex,
    int TotalCount,
    int PageCount,
    IEnumerable<object> Data
);

