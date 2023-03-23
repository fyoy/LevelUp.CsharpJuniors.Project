using FedorStore.WebUI.Models;

namespace FedorStore.WebUI.Services
{
    public interface IProductsServiceProxy
    {
        Task<IEnumerable<ProductItem>> GetAllProducts();
        Task<ProductItem> GetProductById(Guid id);
    }
}
