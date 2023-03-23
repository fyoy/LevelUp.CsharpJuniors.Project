namespace FedorStore.Api.Service
{
    public interface IProductsService
    {
        Task<IEnumerable<ProductItem>> GetAllProducts();
        Task AddProduct(ProductItem productItem);
        Task<ProductItem> GetProduct(Guid id);
    }
}
