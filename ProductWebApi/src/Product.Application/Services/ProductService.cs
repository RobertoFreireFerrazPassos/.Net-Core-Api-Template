using Product.DataContracts.Dtos;
using Product.DataContracts.Requests;
using Product.DataContracts.Responses;
using Product.Domain.Repositories;
using Product.Domain.Services;

namespace Product.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task AddProductAsync(AddProductRequest addProductRequest)
        {
            var product = new Domain.Entities.Product()
            {
                Id = Guid.NewGuid(),
                Name = addProductRequest.Name,
                SkuCode = addProductRequest.SkuCode,
                Price = addProductRequest.Price,
            };

            await _productRepository.AddAsync(product);
        }

        public async Task UpdateProductAsync(UpdateProductRequest updateProductRequest)
        {
            var product = new Domain.Entities.Product()
            {
                Id = updateProductRequest.Id,
                Name = updateProductRequest.Name,
                SkuCode = updateProductRequest.SkuCode,
                Price = updateProductRequest.Price,
            };

            await _productRepository.UpdateAsync(product);
        }

        public async Task DeleteProductAsync(Guid id)
        {
            var product = new Domain.Entities.Product()
            {
                Id = id,
            };

            await _productRepository.DeleteAsync(product);
        }

        public async Task<ProductReponse?> GetProductAsync(Guid id)
        {
            var product = await _productRepository.GetAsync(id);

            if (product is null) return default(ProductReponse);

            return new ProductReponse()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                SkuCode = product.SkuCode
            };
        }

        public async Task<ProductsPaginationReponse> GetProductsAsync(ProductsPaginationQueryParameters pagination, CancellationToken token)
        {
            (var total, var products) = await _productRepository.GetUsingPaginationAsync(pagination.PageNumber, pagination.PageSize, token);
            
            return new ProductsPaginationReponse()
            {
                Products = products.Select(p => new ProductDto()
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    SkuCode = p.SkuCode
                }),
                PageNumber = pagination.PageNumber,
                PageSize = pagination.PageSize,
                Total = total,
            };
        }
    }
}