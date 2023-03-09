using FedorStore.Api.Models;
using FedorStore.Api.Service;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace FedorStore.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public sealed class ProductController : ControllerBase
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("all")]
        public ActionResult<IEnumerable<ProductItem>> GetProducts()
        {
            return Ok(_productService.GetProducts());
        }

        //Добавлен метод получения продукта по его guid
        [HttpGet("id")]
        public ActionResult<ProductItem> GetProductId(Guid guid)
        {
            var product = _productService.GetProductById(guid);
            if (product == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(product);
            }
        }
    }
}