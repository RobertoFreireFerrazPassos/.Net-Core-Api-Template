using Microsoft.AspNetCore.Mvc;
using Product.DataContracts.Requests;
using Product.Domain.Services;

namespace Product.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;

        private readonly IProductService _productService;

        public ProductsController(
            ILogger<ProductsController> logger,
            IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductsAsync([FromQuery] ProductsPaginationQueryParameters pagination, CancellationToken token)
        {
            try
            {
                return Ok(await _productService.GetProductsAsync(pagination, token));
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred", ex);

                return StatusCode(500);
            }
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetProductAsync([FromRoute] Guid id)
        {
            try
            {
                var product = await _productService.GetProductAsync(id);

                if (product is null) 
                {
                    return NotFound();
                }

                return Ok(product);
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred", ex);

                return StatusCode(500);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductAsync(UpdateProductRequest updateProductRequest)
        {
            try
            {
                await _productService.UpdateProductAsync(updateProductRequest);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred", ex);

                return StatusCode(500);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddProductAsync(AddProductRequest addProductRequest)
        {
            try
            {
                await _productService.AddProductAsync(addProductRequest);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred", ex);

                return StatusCode(500);
            }
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteProductAsync([FromRoute] Guid id)
        {
            try
            {
                await _productService.DeleteProductAsync(id);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred", ex);

                return StatusCode(500);
            }
        }
    }
}