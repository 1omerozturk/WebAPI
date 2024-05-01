using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductApp.Models;

namespace ProductApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ILogger<ProductsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = new List<Product>()
            {
                new Product { Id = 1,ProductName="Laptop"},
                new Product { Id = 2,ProductName="Monitor"},
                new Product { Id = 3,ProductName="Keyboard"},
                new Product { Id = 4,ProductName="Mouse"}
            };
            _logger.LogInformation("GetAllProducts action been called. ");
            return Ok(products);
        }
        [HttpPost]
        public IActionResult GetAllProducts([FromBody] Product product)
        {
            _logger.LogWarning("Product Has been created");
            return StatusCode(201); // created.
        }
    }
}
