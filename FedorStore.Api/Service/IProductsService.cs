using FedorStore.Api.Models;

namespace FedorStore.Api.Service
{
    public interface IProductsService
    {
        Task<IEnumerable<ProductItem>> GetProducts();
        Task AddProduct(ProductItem productItem);
    }
}
