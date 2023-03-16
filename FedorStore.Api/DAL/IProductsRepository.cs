using FedorStore.Api.DAL.Entities;

namespace FedorStore.Api.DAL
{
    public interface IProductsRepository
    {
        public Task<IEnumerable<ProductEntity>> GetAll();
        public Task Create(ProductEntity entity);
    }
}
