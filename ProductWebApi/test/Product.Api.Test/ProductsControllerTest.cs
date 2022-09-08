using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Product.Api.Controllers;
using Product.DataContracts.Responses;
using Product.Domain.Services;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Product.Api.Test
{
    public class ProductsControllerTest
    {
        private readonly Mock<ILogger<ProductsController>> _loggerMock = new Mock<ILogger<ProductsController>>();

        private readonly Mock<IProductService> _productServiceMock = new Mock<IProductService>();

        [Fact]
        public async Task When_GetNoProduct_Must_ReturnStatus404()
        {
            // Arrange
            var id = Guid.NewGuid();
            var productsController = new ProductsController(_loggerMock.Object, _productServiceMock.Object);

            _productServiceMock
                .Setup(s => s.GetProductAsync(id))
                .ReturnsAsync(default(ProductReponse));

            // Act
            var result = await productsController.GetProductAsync(id) as NotFoundResult;

            // Assert
            result.StatusCode.Should().Be(404);
        }

        [Fact]
        public async Task When_GetProduct_Must_ReturnStatus200AndExpectedProduct()
        {
            // Arrange
            var id = Guid.NewGuid();
            var productsController = new ProductsController(_loggerMock.Object, _productServiceMock.Object);
            var expectedProduct = new ProductReponse()
            {
                Id = id,
                Name = "AnyValue",
                Price = 0,
                SkuCode = "AnyValue"
            };

            _productServiceMock
                .Setup(s => s.GetProductAsync(id))
                .ReturnsAsync(expectedProduct);

            // Act
            var result = await productsController.GetProductAsync(id) as OkObjectResult;

            // Assert
            result.StatusCode.Should().Be(200);
            result.Value.Should().Be(expectedProduct);
        }
    }
}