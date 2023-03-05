using FedorStore.Api.Models;

namespace FedorStore.Api.Service
{
    public sealed class ProductService : IProductService
    {
        private Dictionary<Guid, ProductItem> _products = new();
        public ProductService()
        {
            InitProducts();
        }
        public IEnumerable<ProductItem> GetProducts()
        {
            return _products.Values;
        }

        private void InitProducts()
        {
            var guid1  = Guid.NewGuid();

            _products = new Dictionary<Guid, ProductItem>
            {
                {guid1, new  ProductItem(guid1,"Штаны","Чехословакия")}
            };
        }
    }
}
