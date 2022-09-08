using Microsoft.EntityFrameworkCore;
using Product.Domain.Repositories;

namespace Product.Infra.DataAccess
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _productDbContext;

        public ProductRepository(ProductDbContext productDbContext)
        {
            _productDbContext = productDbContext;
        }

        public async Task AddAsync(Domain.Entities.Product product)
        {
            _productDbContext.Products.Add(product);

            await _productDbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(Domain.Entities.Product product)
        {
            _productDbContext.Products.Update(product);

            await _productDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Domain.Entities.Product product)
        {
            _productDbContext.Products.Remove(product);

            await _productDbContext.SaveChangesAsync();
        }

        public async Task<Domain.Entities.Product?> GetAsync(Guid id)
        {
            return await _productDbContext.Products
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<(int total,IEnumerable<Domain.Entities.Product> products)> GetUsingPaginationAsync(int pageNumber, int pageSize, CancellationToken token)
        {
            var countTask = _productDbContext.Products
                .CountAsync();

            var getProductsTask = _productDbContext.Products
                .OrderBy(p => p.Name)
                .Skip(pageSize*(pageNumber - 1))
                .Take(pageSize)
                .ToListAsync(token);

            await Task.WhenAll(countTask, getProductsTask);

            return (countTask.Result, getProductsTask.Result);
        }
    }
}
