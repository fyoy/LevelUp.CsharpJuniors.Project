namespace FedorStore.Api.Service
{
    public interface IProductsService
    {
        Task<IEnumerable<ProductItem>> GetAllProducts();
        Task AddProduct(ProductItem productItem);
        Task UpdateProduct(ProductItem productItem);
        Task DeleteProduct(Guid id);
        Task<ProductItem> GetProduct(Guid id);
    }
}
