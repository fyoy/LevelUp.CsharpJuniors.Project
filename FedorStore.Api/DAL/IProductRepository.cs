using FedorStore.Api.DAL.Entities;

namespace FedorStore.Api.DAL
{
    public interface IProductRepository
    {
        public Task<IEnumerable<ProductEntity>> GetAll();

        public Task<ProductEntity?> GetById(Guid id);
    }
}