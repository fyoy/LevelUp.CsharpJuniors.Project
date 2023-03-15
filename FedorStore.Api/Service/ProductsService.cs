using FedorStore.Api.DAL;
using FedorStore.Api.DAL.Entities;
using FedorStore.Api.Models;

namespace FedorStore.Api.Service
{
    public sealed class ProductsService : IProductsService
    {
        private readonly IProductsRepository _productRepository;

        public ProductsService(IProductsRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductItem>> GetProducts()
        {
            var entities = await _productRepository.GetAll();
            return entities.Select(e => new ProductItem(e.Id, e.Name, e.CategoryId, e.Description));
        }

        public async Task AddProduct(ProductItem productItem)
        {
            var productEntity = new ProductEntity
            {
                Id = productItem.Id,
                CategoryId = productItem.CategoryId,
                Name = productItem.Name,
                Description = productItem.Description
            };
            
            await _productRepository.Create(productEntity);
        }
    }
}
