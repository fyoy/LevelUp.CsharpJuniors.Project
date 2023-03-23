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
          var e = await _productRepository.GetById(id);

          return new ProductItem(e.Id, e.Name, e.CategoryId, e.Description, e.Price);
        }
    }
}
