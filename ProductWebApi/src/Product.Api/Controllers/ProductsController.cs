using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> GetProductAsync()
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("An error occurred",ex);

                return StatusCode(500);
            }
        }
    }
}