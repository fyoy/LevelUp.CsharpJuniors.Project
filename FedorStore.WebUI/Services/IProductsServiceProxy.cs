using FedorStore.WebUI.Models;
using Microsoft.AspNetCore.Components;

namespace FedorStore.WebUI.Services
{
    public interface IProductsServiceProxy
    {
        Task<IEnumerable<ProductItem>> GetAllProducts();
        Task<ProductItem> GetProductById(Guid id);
        public Task CreateProduct(ProductItem productItem);
        public Task DeleteProduct(Guid id);
        public Task UpdateProduct(ProductItem productItem);
    }
}
