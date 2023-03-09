using FedorStore.Api.Models;

namespace FedorStore.Api.Service
{
    public interface IProductService
    {
        IEnumerable<ProductItem> GetProducts();
        ProductItem GetProductById(Guid guid);
    }
}
