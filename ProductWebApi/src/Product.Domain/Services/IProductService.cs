using Product.DataContracts.Requests;
using Product.DataContracts.Responses;

namespace Product.Domain.Services
{
    public interface IProductService
    {
        Task<ProductsPaginationReponse> GetProductsAsync(ProductsPaginationQueryParameters pagination, CancellationToken token);
        Task<ProductReponse?> GetProductAsync(Guid id);
        Task UpdateProductAsync(UpdateProductRequest updateProductRequest);
        Task AddProductAsync(AddProductRequest addProductRequest);
        Task DeleteProductAsync(Guid id);
    }
}
