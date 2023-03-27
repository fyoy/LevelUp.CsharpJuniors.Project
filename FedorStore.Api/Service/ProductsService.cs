using System.Xml.Linq;

namespace FedorStore.Api.Service
{
    public sealed class ProductsService : IProductsService
    {
        private readonly IProductsRepository _productRepository;

        public ProductsService(IProductsRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductItem>> GetAllProducts()
        {
            var entities = await _productRepository.GetAll();
            return entities.Select(e => new ProductItem(e.Id, e.Name, e.CategoryId, e.Description,e.Price));
        }

        public async Task AddProduct(ProductItem productItem)
        {
            var productEntity = new ProductEntity
            {
                Id = productItem.Id,
                CategoryId = productItem.CategoryId,
                Name = productItem.Name,
                Description = productItem.Description,
                Price = productItem.Price
            };
            
            await _productRepository.Create(productEntity);
        }

        public async Task<ProductItem> GetProduct(Guid id)
        {
          var e2 = await _productRepository.GetById(id);

            if (e2 == null)
            {
                var e4 = new ProductEntity
                {
                    Id = Guid.NewGuid(),
                    CategoryId = Guid.NewGuid(),
                    Name = "Наименование продукта",
                    Description = "Описание продукта",
                    Price = decimal.Zero
                };

                e2 = e4;
            }
            return new ProductItem(e2.Id, e2.Name, e2.CategoryId, e2.Description, e2.Price);
        }

        public async Task UpdateProduct(ProductItem productItem)
        {
            var productEntity = new ProductEntity
            {
                Id = productItem.Id,
                CategoryId = productItem.CategoryId,
                Name = productItem.Name,
                Description = productItem.Description,
                Price = productItem.Price
            };
            
            await _productRepository.Update(productEntity);
        }

        public async Task DeleteProduct(Guid id)
        {
            await _productRepository.Delete(id);
        }
    }
}
