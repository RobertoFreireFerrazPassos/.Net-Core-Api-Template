namespace Product.Domain.Repositories
{
    public interface IProductRepository
    {
        Task AddAsync(Entities.Product product);
        Task DeleteAsync(Entities.Product product);
        Task UpdateAsync(Entities.Product product);
        Task<Entities.Product?> GetAsync(Guid id);
        Task<(int total, IEnumerable<Entities.Product> products)> GetUsingPaginationAsync(int pageNumber, int pageSize, CancellationToken token);
    }
}
