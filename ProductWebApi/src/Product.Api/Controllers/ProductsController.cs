using Microsoft.AspNetCore.Mvc;
using Product.DataContracts.Requests;

namespace Product.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ILogger<ProductsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetProductsAsync([FromQuery] ProductsPaginationQueryParameters pagination)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred", ex);

                return StatusCode(500);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetProductAsync([FromRoute]  int id)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred", ex);

                return StatusCode(500);
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateProductAsync([FromRoute] int id)
        {
            try
            {
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
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred", ex);

                return StatusCode(500);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteProductAsync([FromRoute] int id)
        {
            try
            {
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