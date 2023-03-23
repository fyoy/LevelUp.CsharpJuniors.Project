using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;

namespace FedorStore.Api.Controllers
{
    [ApiController]
    [Microsoft.AspNetCore.Mvc.Route("[controller]")]
    public sealed class ProductsController : ControllerBase
    {
        private IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<ProductItem>>> GetAllProducts()
        {
            var products = await _productsService.GetAllProducts();
            return Ok(products);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddProduct(ProductItem productItem)
        {
            await _productsService.AddProduct(productItem);
            return Ok(productItem);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductItem>> GetProduct(Guid id)
        {
            var result = await _productsService.GetProduct(id);
            return Ok(result);
        }
    }
}